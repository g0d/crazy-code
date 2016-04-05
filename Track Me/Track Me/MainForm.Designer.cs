namespace TrackMe
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CrossBox = new System.Windows.Forms.PictureBox();
            this.LifeBox = new System.Windows.Forms.PictureBox();
            this.CaptureBox = new System.Windows.Forms.PictureBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.HSVCaptureBox = new System.Windows.Forms.PictureBox();
            this.lblLoading = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CrossBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LifeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CaptureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HSVCaptureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CrossBox
            // 
            this.CrossBox.Image = global::TrackMe.Properties.Resources.Gate;
            this.CrossBox.Location = new System.Drawing.Point(772, 449);
            this.CrossBox.Name = "CrossBox";
            this.CrossBox.Size = new System.Drawing.Size(100, 100);
            this.CrossBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CrossBox.TabIndex = 0;
            this.CrossBox.TabStop = false;
            // 
            // LifeBox
            // 
            this.LifeBox.Image = global::TrackMe.Properties.Resources.Life;
            this.LifeBox.Location = new System.Drawing.Point(12, 12);
            this.LifeBox.Name = "LifeBox";
            this.LifeBox.Size = new System.Drawing.Size(32, 32);
            this.LifeBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LifeBox.TabIndex = 1;
            this.LifeBox.TabStop = false;
            // 
            // CaptureBox
            // 
            this.CaptureBox.BackColor = System.Drawing.Color.DimGray;
            this.CaptureBox.Location = new System.Drawing.Point(12, 369);
            this.CaptureBox.Name = "CaptureBox";
            this.CaptureBox.Size = new System.Drawing.Size(240, 180);
            this.CaptureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CaptureBox.TabIndex = 2;
            this.CaptureBox.TabStop = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.ForeColor = System.Drawing.Color.White;
            this.radioButton1.Location = new System.Drawing.Point(776, 12);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(96, 17);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Track my head";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Visible = false;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.ForeColor = System.Drawing.Color.White;
            this.radioButton2.Location = new System.Drawing.Point(776, 35);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(95, 17);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.Text = "Track my color";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Visible = false;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // HSVCaptureBox
            // 
            this.HSVCaptureBox.BackColor = System.Drawing.Color.DimGray;
            this.HSVCaptureBox.Location = new System.Drawing.Point(258, 369);
            this.HSVCaptureBox.Name = "HSVCaptureBox";
            this.HSVCaptureBox.Size = new System.Drawing.Size(240, 180);
            this.HSVCaptureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.HSVCaptureBox.TabIndex = 5;
            this.HSVCaptureBox.TabStop = false;
            this.HSVCaptureBox.Visible = false;
            // 
            // lblLoading
            // 
            this.lblLoading.AutoSize = true;
            this.lblLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoading.ForeColor = System.Drawing.Color.White;
            this.lblLoading.Location = new System.Drawing.Point(410, 251);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(88, 20);
            this.lblLoading.TabIndex = 6;
            this.lblLoading.Text = "Loading...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.lblLoading);
            this.Controls.Add(this.LifeBox);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.CaptureBox);
            this.Controls.Add(this.CrossBox);
            this.Controls.Add(this.HSVCaptureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Track Me";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CrossBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LifeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CaptureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HSVCaptureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox CrossBox;
        private System.Windows.Forms.PictureBox LifeBox;
        private System.Windows.Forms.PictureBox CaptureBox;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.PictureBox HSVCaptureBox;
        private System.Windows.Forms.Label lblLoading;
    }
}

