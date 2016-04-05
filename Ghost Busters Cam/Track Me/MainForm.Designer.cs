namespace GhostBustersCam
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.GBBox = new System.Windows.Forms.PictureBox();
            this.CaptureBox = new System.Windows.Forms.PictureBox();
            this.lblLoading = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.RadarBox = new System.Windows.Forms.PictureBox();
            this.CamBox = new System.Windows.Forms.PictureBox();
            this.GhostBox = new System.Windows.Forms.PictureBox();
            this.lblGhost = new System.Windows.Forms.Label();
            this.lblGhostAlert = new System.Windows.Forms.Label();
            this.AlertTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.GBBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CaptureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RadarBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GhostBox)).BeginInit();
            this.SuspendLayout();
            // 
            // GBBox
            // 
            this.GBBox.Image = ((System.Drawing.Image)(resources.GetObject("GBBox.Image")));
            this.GBBox.Location = new System.Drawing.Point(12, 12);
            this.GBBox.Name = "GBBox";
            this.GBBox.Size = new System.Drawing.Size(114, 97);
            this.GBBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GBBox.TabIndex = 1;
            this.GBBox.TabStop = false;
            this.GBBox.Visible = false;
            // 
            // CaptureBox
            // 
            this.CaptureBox.BackColor = System.Drawing.Color.DimGray;
            this.CaptureBox.Location = new System.Drawing.Point(178, 177);
            this.CaptureBox.Name = "CaptureBox";
            this.CaptureBox.Size = new System.Drawing.Size(530, 360);
            this.CaptureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CaptureBox.TabIndex = 2;
            this.CaptureBox.TabStop = false;
            this.CaptureBox.Visible = false;
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
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.Color.White;
            this.lblDescription.Location = new System.Drawing.Point(210, 147);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(465, 20);
            this.lblDescription.TabIndex = 7;
            this.lblDescription.Text = "Switch off the lights and let the camera hunt for ghosts...";
            this.lblDescription.Visible = false;
            // 
            // RadarBox
            // 
            this.RadarBox.Image = ((System.Drawing.Image)(resources.GetObject("RadarBox.Image")));
            this.RadarBox.Location = new System.Drawing.Point(772, 12);
            this.RadarBox.Name = "RadarBox";
            this.RadarBox.Size = new System.Drawing.Size(97, 97);
            this.RadarBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RadarBox.TabIndex = 8;
            this.RadarBox.TabStop = false;
            this.RadarBox.Visible = false;
            // 
            // CamBox
            // 
            this.CamBox.BackColor = System.Drawing.Color.Transparent;
            this.CamBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CamBox.Image = ((System.Drawing.Image)(resources.GetObject("CamBox.Image")));
            this.CamBox.Location = new System.Drawing.Point(12, 12);
            this.CamBox.Name = "CamBox";
            this.CamBox.Size = new System.Drawing.Size(24, 24);
            this.CamBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.CamBox.TabIndex = 9;
            this.CamBox.TabStop = false;
            this.CamBox.Visible = false;
            // 
            // GhostBox
            // 
            this.GhostBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.GhostBox.Location = new System.Drawing.Point(755, 434);
            this.GhostBox.Name = "GhostBox";
            this.GhostBox.Size = new System.Drawing.Size(114, 103);
            this.GhostBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GhostBox.TabIndex = 10;
            this.GhostBox.TabStop = false;
            this.GhostBox.Visible = false;
            // 
            // lblGhost
            // 
            this.lblGhost.AutoSize = true;
            this.lblGhost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGhost.ForeColor = System.Drawing.Color.White;
            this.lblGhost.Location = new System.Drawing.Point(782, 404);
            this.lblGhost.Name = "lblGhost";
            this.lblGhost.Size = new System.Drawing.Size(58, 20);
            this.lblGhost.TabIndex = 11;
            this.lblGhost.Text = "Ghost";
            this.lblGhost.Visible = false;
            // 
            // lblGhostAlert
            // 
            this.lblGhostAlert.AutoSize = true;
            this.lblGhostAlert.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGhostAlert.ForeColor = System.Drawing.Color.Red;
            this.lblGhostAlert.Location = new System.Drawing.Point(356, 49);
            this.lblGhostAlert.Name = "lblGhostAlert";
            this.lblGhostAlert.Size = new System.Drawing.Size(183, 20);
            this.lblGhostAlert.TabIndex = 12;
            this.lblGhostAlert.Text = "<< GHOST ALERT >>";
            this.lblGhostAlert.Visible = false;
            // 
            // AlertTimer
            // 
            this.AlertTimer.Interval = 270;
            this.AlertTimer.Tick += new System.EventHandler(this.AlertTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.lblGhostAlert);
            this.Controls.Add(this.lblGhost);
            this.Controls.Add(this.GhostBox);
            this.Controls.Add(this.CamBox);
            this.Controls.Add(this.RadarBox);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblLoading);
            this.Controls.Add(this.GBBox);
            this.Controls.Add(this.CaptureBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ghost Busters Cam";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GBBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CaptureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RadarBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CamBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GhostBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox GBBox;
        private System.Windows.Forms.PictureBox CaptureBox;
        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.PictureBox RadarBox;
        private System.Windows.Forms.PictureBox CamBox;
        private System.Windows.Forms.PictureBox GhostBox;
        private System.Windows.Forms.Label lblGhost;
        private System.Windows.Forms.Label lblGhostAlert;
        private System.Windows.Forms.Timer AlertTimer;
    }
}

