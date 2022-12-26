using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Fourier_Transformatie.Fourier
{
    public static class Fourier
    {

        public static Object[] forwardFFT(int[,] greyArray, bool shift, int scale1)
        {

            Object[] ret = new Object[3];

            ComplexGetal[,] complexeArray = new ComplexGetal[greyArray.GetLength(0), greyArray.GetLength(1)];

            for (int i = 0; i < greyArray.GetLength(0); i++)
            {
                for (int j = 0; j < greyArray.GetLength(1); j++)
                {
                    complexeArray[i, j] = new ComplexGetal(greyArray[i, j], 0);
                }
            }

            complexeArray = FFT2D(complexeArray, FourierDirection.Forward);
            ret[0] = complexeArray;

            if (shift) complexeArray = shiftFFTResult(complexeArray);

            ret[1] = plotMod(complexeArray, scale1);


           // ret[2] = plotArg(complexeArray, scale2);

            return ret;
        }


        public static Bitmap backwardFFT(ComplexGetal[,] fourier)
        {
            float[,] greyscale = new float[fourier.GetLength(0), fourier.GetLength(1)];

            fourier = FFT2D(fourier, FourierDirection.Backward);

            for (int i = 0; i < fourier.GetLength(0); i++)
            {
                for (int j = 0; j < fourier.GetLength(1); j++)
                {
                    greyscale[i, j] = fourier[i, j].Modul;
                }
            }

            return createImage(greyscale, 1);
        }

        #region Fourier2D
        private static ComplexGetal[,] FFT2D(ComplexGetal[,] invoer, FourierDirection dir)
        {
            float[] len = new float[invoer.GetLength(1)];
            float[] imaginair = new float[invoer.GetLength(1)];
            ComplexGetal[,] resultaat = invoer;

            
            for (int i = 0; i < invoer.GetLength(0); i++)
            {
                for (int j = 0; j < invoer.GetLength(1); j++)
                {
                    len[j] = invoer[i, j].Real;
                    imaginair[j] = invoer[i, j].Imagin;
                }
                
                FFT1D(dir, len, imaginair);

                for (int j = 0; j < resultaat.GetLength(1); j++)
                {
                    resultaat[i, j].Real = len[j];
                    resultaat[i, j].Imagin = imaginair[j];
                }
            }

            for (int i = 0; i < resultaat.GetLength(1); i++)
            {
                for (int j = 0; j < resultaat.GetLength(0); j++)
                {
                    len[j] = resultaat[j, i].Real;
                    imaginair[j] = resultaat[j, i].Imagin;
                }

                FFT1D(dir, len, imaginair);

                for (int j = 0; j < resultaat.GetLength(0); j++)
                {
                    resultaat[j, i].Real = len[j];
                    resultaat[j, i].Imagin = imaginair[j];
                }
            }

            return resultaat;
        }


        private static Bitmap plotMod(ComplexGetal[,] array, int scale)
        {
            float[,] modulusPlot = new float[array.GetLength(0), array.GetLength(1)];
            float max = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    modulusPlot[i, j] = (float)Math.Log(1 + array[i, j].Modul);

                    if (modulusPlot[i, j] > max) max = modulusPlot[i, j];
                }
            }

            for (int i = 0; i < modulusPlot.GetLength(0); i++)
            {
                for (int j = 0; j < modulusPlot.GetLength(1); j++)
                {
                    modulusPlot[i, j] /= max;
                }
            }

            return createImage(modulusPlot, scale);
        }

        private static Bitmap plotArg(ComplexGetal[,] array, int scale)
        {
            float[,] argumentPlot = new float[array.GetLength(0), array.GetLength(1)];
            float max = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    argumentPlot[i, j] = (float)Math.Log(1 + Math.Abs(array[i, j].Argument));

                    // Bepaal de hoogste waarde
                    if (argumentPlot[i, j] > max) max = argumentPlot[i, j];
                }
            }

            for (int i = 0; i < argumentPlot.GetLength(0); i++)
            {
                for (int j = 0; j < argumentPlot.GetLength(1); j++)
                {
                    argumentPlot[i, j] = argumentPlot[i, j] / max;
                }
            }

            return createImage(argumentPlot, scale);
        }


        private static ComplexGetal[,] shiftFFTResult(ComplexGetal[,] result)
        {
            int a = result.GetLength(0);
            int b = result.GetLength(1);
            ComplexGetal[,] shiftResult = new ComplexGetal[a, b];

            for (int i = 0; i < (a / 2); i++)
            {
                for (int j = 0; j < (b / 2); j++)
                {
                    shiftResult[i + (a / 2), j + (b / 2)] = result[i, j];
                    shiftResult[i + (a / 2), j] = result[i, j + (b / 2)];
                    shiftResult[i, j + (b / 2)] = result[i + (a / 2), j];
                    shiftResult[i, j] = result[i + (a / 2), j + (b / 2)];
                }
            }

            return shiftResult;
        }


        private unsafe static Bitmap createImage(float[,] source, int rescale)
        {
            Bitmap img = new Bitmap(source.GetLength(1), source.GetLength(1));
            BitmapData bitmapData = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            int bpp = Bitmap.GetPixelFormatSize(img.PixelFormat) / 8;
            int HeightInPixels = bitmapData.Height;
            int WidthInBytes = bitmapData.Width * bpp;
            byte* ptrFirstPixel = (byte*)bitmapData.Scan0;

            for (int y = 0; y < HeightInPixels; y++)
            {

                byte* currentLine = ptrFirstPixel + (y * bitmapData.Stride);

                for (int x = 0; x < WidthInBytes; x = x + bpp)
                {
                    currentLine[x] = (byte)(source[y, x / bpp] * rescale);
                    currentLine[x + 1] = (byte)(source[y, x / bpp] * rescale);
                    currentLine[x + 2] = (byte)(source[y, x / bpp] * rescale);
                    currentLine[x + 3] = (byte)255;
                }
            }


            img.UnlockBits(bitmapData);
            return img;
        }

        #endregion Fourier2D

        #region Fourier1D

        private static void FFT1D(FourierDirection dir, float[] x, float[] y)
        {
            long nn, i, i1, j, k, i2, l, l1, l2;
            float c1, c2, tx, ty, t1, t2, u1, u2, z;

            if (x.Length != y.Length)
                throw new FormatException("Real values and imaginary values arrays lengths do not match");

            int m = (int)Math.Log(x.Length, 2);
            if (m != Math.Log(x.Length, 2))
                throw new FormatException("Data arrays lenght is no power of two");

            /* Calculate the number of points */
            nn = 1;
            for (i = 0; i < m; i++)
                nn *= 2;
            /* Do the bit reversal */
            i2 = nn >> 1;
            j = 0;
            for (i = 0; i < nn - 1; i++)
            {
                if (i < j)
                {
                    tx = x[i];
                    ty = y[i];
                    x[i] = x[j];
                    y[i] = y[j];
                    x[j] = tx;
                    y[j] = ty;
                }
                k = i2;
                while (k <= j)
                {
                    j -= k;
                    k >>= 1;
                }
                j += k;
            }
            /* Compute the FFT */
            c1 = -1f;
            c2 = 0f;
            l2 = 1;
            for (l = 0; l < m; l++)
            {
                l1 = l2;
                l2 <<= 1;
                u1 = 1;
                u2 = 0;
                for (j = 0; j < l1; j++)
                {
                    for (i = j; i < nn; i += l2)
                    {
                        i1 = i + l1;
                        t1 = u1 * x[i1] - u2 * y[i1];
                        t2 = u1 * y[i1] + u2 * x[i1];
                        x[i1] = x[i] - t1;
                        y[i1] = y[i] - t2;
                        x[i] += t1;
                        y[i] += t2;
                    }
                    z = u1 * c1 - u2 * c2;
                    u2 = u1 * c2 + u2 * c1;
                    u1 = z;
                }
                c2 = (float)Math.Sqrt((1f - c1) / 2f);
                if (dir == FourierDirection.Forward)
                    c2 = -c2;
                c1 = (float)Math.Sqrt((1f + c1) / 2f);
            }
            /* Scaling for forward transform */
            if (dir == FourierDirection.Forward)
            {
                for (i = 0; i < nn; i++)
                {
                    x[i] /= nn;
                    y[i] /= nn;

                }
            }
        }
        #endregion Fourier1D
    }

    #region FourierDirection
    /// <summary>
    /// <p>The direction of the fourier transform.</p>
    /// </summary>
    public enum FourierDirection : int
    {
        /// <summary>
        /// Forward direction.  Usually in reference to moving from temporal
        /// representation to frequency representation
        /// </summary>
        Forward = 1,
        /// <summary>
        /// Backward direction. Usually in reference to moving from frequency
        /// representation to temporal representation
        /// </summary>
        Backward = -1,
    }
    #endregion FourierDirection

}