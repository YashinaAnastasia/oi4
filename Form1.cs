using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Fourier_Transformatie.Fourier;

namespace Fourier_Transformatie {
    public partial class Form1 : Form {
        private FMan fm;

        public Form1() {
            InitializeComponent();
        }

        private void button_Inladen_Click(object sender, EventArgs e) {
            fm = new FMan();
            OpenFileDialog o = new OpenFileDialog();

            if (o.ShowDialog() == DialogResult.OK) {
                this.pictureBox_Origineel.Image = fm.LoadImage(o.FileName);
                pictureBox_Origineel.SizeMode = PictureBoxSizeMode.StretchImage;
                //this.pictureBox_grijs.Image = fm.CreateGreyscaleBitmap();

                // leeg maken afbeeldingen
                this.pictureBox_Backward.Image = null;
                //this.pictureBox_Fase.Image = null;
                this.pictureBox_Mag.Image = null;

                //enable buttons
                this.button_Forward.Enabled = true;

                //disable buttons
                this.button_Backwards.Enabled = false;
                //this.button_Save.Enabled = false;
                this.numericUpDown_mag.Enabled = false;
                //this.numericUpDown_Phase.Enabled = false;
            } else {
                MessageBox.Show("Failed to load image!");
            }
        }

        private void button_Save_Click(object sender, EventArgs e) {
            FolderBrowserDialog f = new FolderBrowserDialog();

            if (f.ShowDialog() == DialogResult.OK) {
                fm.SaveImage(f.SelectedPath);
            }            
        }

        private void button_Forward_Click(object sender, EventArgs e) {
            fm.performFFT((int)this.numericUpDown_mag.Value, true);
            this.pictureBox_Mag.Image = fm.getModPlot();
            //this.pictureBox_Fase.Image = fm.getArgPlot();

            //enable buttons
            this.button_Backwards.Enabled = true;
            this.numericUpDown_mag.Enabled = true;
            //this.numericUpDown_Phase.Enabled = true;
        }

        private void button_Backwards_Click(object sender, EventArgs e) {
            this.pictureBox_Backward.Image = fm.reverseFFT();
            //disable buttons
            this.button_Backwards.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
