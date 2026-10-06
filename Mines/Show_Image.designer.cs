namespace WelcomeFabric
{
    partial class Show_Image
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
            this.PnlImage = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDesignName = new System.Windows.Forms.Label();
            this.lblPnlClose = new System.Windows.Forms.Label();
            this.PnlImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlImage
            // 
            this.PnlImage.Controls.Add(this.pictureBox1);
            this.PnlImage.Controls.Add(this.lblDesignName);
            this.PnlImage.Controls.Add(this.lblPnlClose);
            this.PnlImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlImage.Location = new System.Drawing.Point(0, 0);
            this.PnlImage.Name = "PnlImage";
            this.PnlImage.Size = new System.Drawing.Size(379, 321);
            this.PnlImage.TabIndex = 27;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(379, 274);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // lblDesignName
            // 
            this.lblDesignName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDesignName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesignName.ForeColor = System.Drawing.Color.Maroon;
            this.lblDesignName.Location = new System.Drawing.Point(0, 23);
            this.lblDesignName.Name = "lblDesignName";
            this.lblDesignName.Size = new System.Drawing.Size(379, 24);
            this.lblDesignName.TabIndex = 19;
            this.lblDesignName.Text = "Godown Name";
            // 
            // lblPnlClose
            // 
            this.lblPnlClose.BackColor = System.Drawing.Color.DarkRed;
            this.lblPnlClose.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPnlClose.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPnlClose.ForeColor = System.Drawing.Color.Transparent;
            this.lblPnlClose.Location = new System.Drawing.Point(0, 0);
            this.lblPnlClose.Name = "lblPnlClose";
            this.lblPnlClose.Size = new System.Drawing.Size(379, 23);
            this.lblPnlClose.TabIndex = 19;
            this.lblPnlClose.Text = "X";
            this.lblPnlClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPnlClose.Click += new System.EventHandler(this.lblPnlClose_Click);
            // 
            // Show_Image
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 321);
            this.Controls.Add(this.PnlImage);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Show_Image";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show_Image";
            this.Load += new System.EventHandler(this.Show_Image_Load);
            this.PnlImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlImage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblDesignName;
        private System.Windows.Forms.Label lblPnlClose;
    }
}