using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

// My references
using Fourier_Transformatie.IO;

namespace Fourier_Transformatie.Fourier {
    class FMan {
        private Bitmap original;
        private Bitmap modPlot;
        private Bitmap argPlot;
        private Bitmap revPlot;

        private int[,] greyPixelArray;
        private ComplexGetal[,] fourierResult;

        #region public

        /// <summary>
        /// Laadt een afbeelding in en herschaal ze naar afmetingen die een macht van 2 zijn.
        /// </summary>
        /// <param name="location">De locatie van de afbeelding</param>
        /// <returns>De afbeelding met afmetingen 512x512, om aan de gebruiker te tonen</returns>
        public Bitmap LoadImage(string location) {
            original = CutOut(LukeFilewalker.readFromLocation(location));
            generateGrayScaleArray();
            return resize(original, 512, 512);
        }

        /// <summary>
        /// Sla de bekomen afbeeldingen op
        /// </summary>
        /// <param name="location">De locatie waar de afbeeldingen komen</param>
        public void SaveImage(string location) {
            LukeFilewalker.writeToLocation(location + "\\org.png", original, ImageFormat.Png);
            LukeFilewalker.writeToLocation(location + "\\mod.png", modPlot, ImageFormat.Png);
            LukeFilewalker.writeToLocation(location + "\\arg.png", argPlot, ImageFormat.Png);
            LukeFilewalker.writeToLocation(location + "\\rev.png", revPlot, ImageFormat.Png);
        }

        public unsafe Bitmap CreateGreyscaleBitmap() {
            Bitmap b = new Bitmap(greyPixelArray.GetLength(1), greyPixelArray.GetLength(1));
            BitmapData bitmapData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            int bpp = Bitmap.GetPixelFormatSize(b.PixelFormat) / 8; 
            int HeightInPixels = bitmapData.Height;
            int WidthInBytes = bitmapData.Width * bpp;
            byte* ptrFirstPixel = (byte*)bitmapData.Scan0; 

            for (int y = 0; y < HeightInPixels; y++) {
                
                byte* currentLine = ptrFirstPixel + (y * bitmapData.Stride);

                for (int x = 0; x < WidthInBytes; x = x + bpp) {
                    currentLine[x] = (byte)greyPixelArray[y, x / bpp];
                    currentLine[x + 1] = (byte)greyPixelArray[y, x / bpp];
                    currentLine[x + 2] = (byte)greyPixelArray[y, x / bpp];
                    currentLine[x + 3] = (byte)255;
                }
            }

            //Plaats de bewerkte BitmapData terug in de afbeelding
            b.UnlockBits(bitmapData);
            return resize(b, 256, 256);
        }

        public void performFFT(int scale1, bool shift) {
            Object[] returnVar = Fourier.forwardFFT(greyPixelArray, true, scale1);

            fourierResult = (ComplexGetal[,])returnVar[0];
            modPlot = (Bitmap)returnVar[1];
            argPlot = (Bitmap)returnVar[2];
        }

       
        public Bitmap getModPlot() {
            return resize(modPlot, 256, 256);
        }

        public Bitmap getArgPlot() {
            return resize(argPlot, 256, 256);
        }

        public Bitmap reverseFFT() {
            revPlot = Fourier.backwardFFT(fourierResult);
            return resize(revPlot, 256, 256);
        }

#endregion public

        #region private

        private unsafe void generateGrayScaleArray() {
            greyPixelArray = new int[original.Height, original.Width];

            BitmapData bitmapData = original.LockBits(new Rectangle(0, 0, original.Width, original.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            int bpp = Bitmap.GetPixelFormatSize(original.PixelFormat) / 8; 
            int HeightInPixels = bitmapData.Height;
            int WidthInBytes = bitmapData.Width * bpp;
            byte* ptrFirstPixel = (byte*)bitmapData.Scan0;

            for (int y = 0; y < HeightInPixels; y++) {
                
                byte* currentLine = ptrFirstPixel + (y * bitmapData.Stride);

                for (int x = 0; x < WidthInBytes; x = x + bpp) {
                    greyPixelArray[y, x / bpp] = (currentLine[x] + currentLine[x + 1] + currentLine[x + 2]) / 3;
                }
            }

            original.UnlockBits(bitmapData);
        }

        private Bitmap CutOut(Bitmap b) {
            int var = (b.Width > b.Height ? b.Height : b.Width);

           
            if ((var & (var - 1)) == 0) { 

            }
            else { 
                var--;
                var |= var >> 1;
                var |= var >> 2;
                var |= var >> 4;
                var |= var >> 8;
                var |= var >> 16;
                var++;
                var /= 2;
            }

            return resize(b, var, var);
        }

        
        private Bitmap resize(Bitmap image, int w, int h) {
            var destRect = new Rectangle(0, 0, w, h);
            var destImage = new Bitmap(w, h);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage)) {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes()) {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        #endregion private

    }
}
