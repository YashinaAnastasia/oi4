namespace Fourier_Transformatie {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.button_Inladen = new System.Windows.Forms.Button();
            this.button_Forward = new System.Windows.Forms.Button();
            this.button_Backwards = new System.Windows.Forms.Button();
            this.label_origineel = new System.Windows.Forms.Label();
            this.label_Magnitude = new System.Windows.Forms.Label();
            this.pictureBox_Mag = new System.Windows.Forms.PictureBox();
            this.label_Reverse = new System.Windows.Forms.Label();
            this.pictureBox_Backward = new System.Windows.Forms.PictureBox();
            this.numericUpDown_mag = new System.Windows.Forms.NumericUpDown();
            this.pictureBox_Origineel = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Mag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Backward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_mag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Origineel)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Inladen
            // 
            this.button_Inladen.Location = new System.Drawing.Point(11, 585);
            this.button_Inladen.Name = "button_Inladen";
            this.button_Inladen.Size = new System.Drawing.Size(110, 25);
            this.button_Inladen.TabIndex = 1;
            this.button_Inladen.Text = "Add image";
            this.button_Inladen.UseVisualStyleBackColor = true;
            this.button_Inladen.Click += new System.EventHandler(this.button_Inladen_Click);
            // 
            // button_Forward
            // 
            this.button_Forward.Enabled = false;
            this.button_Forward.Location = new System.Drawing.Point(192, 588);
            this.button_Forward.Name = "button_Forward";
            this.button_Forward.Size = new System.Drawing.Size(110, 25);
            this.button_Forward.TabIndex = 2;
            this.button_Forward.Text = "Forward FFT";
            this.button_Forward.UseVisualStyleBackColor = true;
            this.button_Forward.Click += new System.EventHandler(this.button_Forward_Click);
            // 
            // button_Backwards
            // 
            this.button_Backwards.Enabled = false;
            this.button_Backwards.Location = new System.Drawing.Point(308, 588);
            this.button_Backwards.Name = "button_Backwards";
            this.button_Backwards.Size = new System.Drawing.Size(110, 25);
            this.button_Backwards.TabIndex = 3;
            this.button_Backwards.Text = "Backward FFT";
            this.button_Backwards.UseVisualStyleBackColor = true;
            this.button_Backwards.Click += new System.EventHandler(this.button_Backwards_Click);
            // 
            // label_origineel
            // 
            this.label_origineel.AutoSize = true;
            this.label_origineel.Location = new System.Drawing.Point(12, 9);
            this.label_origineel.Name = "label_origineel";
            this.label_origineel.Size = new System.Drawing.Size(37, 13);
            this.label_origineel.TabIndex = 6;
            this.label_origineel.Text = "Origin:";
            // 
            // label_Magnitude
            // 
            this.label_Magnitude.AutoSize = true;
            this.label_Magnitude.Location = new System.Drawing.Point(295, 9);
            this.label_Magnitude.Name = "label_Magnitude";
            this.label_Magnitude.Size = new System.Drawing.Size(31, 13);
            this.label_Magnitude.TabIndex = 11;
            this.label_Magnitude.Text = "DFT:";
            // 
            // pictureBox_Mag
            // 
            this.pictureBox_Mag.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox_Mag.Location = new System.Drawing.Point(268, 25);
            this.pictureBox_Mag.Name = "pictureBox_Mag";
            this.pictureBox_Mag.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_Mag.TabIndex = 10;
            this.pictureBox_Mag.TabStop = false;
            // 
            // label_Reverse
            // 
            this.label_Reverse.AutoSize = true;
            this.label_Reverse.Location = new System.Drawing.Point(12, 307);
            this.label_Reverse.Name = "label_Reverse";
            this.label_Reverse.Size = new System.Drawing.Size(58, 13);
            this.label_Reverse.TabIndex = 13;
            this.label_Reverse.Text = "Backward:";
            // 
            // pictureBox_Backward
            // 
            this.pictureBox_Backward.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox_Backward.Location = new System.Drawing.Point(11, 323);
            this.pictureBox_Backward.Name = "pictureBox_Backward";
            this.pictureBox_Backward.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_Backward.TabIndex = 12;
            this.pictureBox_Backward.TabStop = false;
            // 
            // numericUpDown_mag
            // 
            this.numericUpDown_mag.Location = new System.Drawing.Point(581, 593);
            this.numericUpDown_mag.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown_mag.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numericUpDown_mag.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numericUpDown_mag.Name = "numericUpDown_mag";
            this.numericUpDown_mag.Size = new System.Drawing.Size(8, 20);
            this.numericUpDown_mag.TabIndex = 19;
            this.numericUpDown_mag.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // pictureBox_Origineel
            // 
            this.pictureBox_Origineel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Origineel.Location = new System.Drawing.Point(11, 25);
            this.pictureBox_Origineel.Name = "pictureBox_Origineel";
            this.pictureBox_Origineel.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_Origineel.TabIndex = 0;
            this.pictureBox_Origineel.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 661);
            this.Controls.Add(this.numericUpDown_mag);
            this.Controls.Add(this.label_Reverse);
            this.Controls.Add(this.pictureBox_Backward);
            this.Controls.Add(this.label_Magnitude);
            this.Controls.Add(this.pictureBox_Mag);
            this.Controls.Add(this.label_origineel);
            this.Controls.Add(this.button_Backwards);
            this.Controls.Add(this.button_Forward);
            this.Controls.Add(this.button_Inladen);
            this.Controls.Add(this.pictureBox_Origineel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1080, 700);
            this.MinimumSize = new System.Drawing.Size(600, 700);
            this.Name = "Form1";
            this.Text = "Fourier Transformatie";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Mag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Backward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_mag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Origineel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_Inladen;
        private System.Windows.Forms.Button button_Forward;
        private System.Windows.Forms.Button button_Backwards;
        private System.Windows.Forms.Label label_origineel;
        private System.Windows.Forms.Label label_Magnitude;
        private System.Windows.Forms.PictureBox pictureBox_Mag;
        private System.Windows.Forms.Label label_Reverse;
        private System.Windows.Forms.PictureBox pictureBox_Backward;
        private System.Windows.Forms.NumericUpDown numericUpDown_mag;
        private System.Windows.Forms.PictureBox pictureBox_Origineel;
    }
}

