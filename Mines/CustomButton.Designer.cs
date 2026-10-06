namespace WelcomeFabric
{
    partial class CustomButton
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
            this.btnAll = new System.Windows.Forms.Button();
            this.BtnWithoutPrice = new System.Windows.Forms.Button();
            this.BtnWithQty = new System.Windows.Forms.Button();
            this.btnGST = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAll
            // 
            this.btnAll.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAll.Location = new System.Drawing.Point(46, 26);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(120, 28);
            this.btnAll.TabIndex = 0;
            this.btnAll.Text = "All";
            this.btnAll.UseVisualStyleBackColor = false;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // BtnWithoutPrice
            // 
            this.BtnWithoutPrice.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnWithoutPrice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BtnWithoutPrice.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtnWithoutPrice.Location = new System.Drawing.Point(172, 26);
            this.BtnWithoutPrice.Name = "BtnWithoutPrice";
            this.BtnWithoutPrice.Size = new System.Drawing.Size(120, 28);
            this.BtnWithoutPrice.TabIndex = 1;
            this.BtnWithoutPrice.Text = "Supplier";
            this.BtnWithoutPrice.UseVisualStyleBackColor = false;
            this.BtnWithoutPrice.Click += new System.EventHandler(this.BtnWithoutPrice_Click);
            // 
            // BtnWithQty
            // 
            this.BtnWithQty.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnWithQty.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BtnWithQty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtnWithQty.Location = new System.Drawing.Point(298, 26);
            this.BtnWithQty.Name = "BtnWithQty";
            this.BtnWithQty.Size = new System.Drawing.Size(120, 28);
            this.BtnWithQty.TabIndex = 2;
            this.BtnWithQty.Text = "Customer";
            this.BtnWithQty.UseVisualStyleBackColor = false;
            this.BtnWithQty.Click += new System.EventHandler(this.BtnWithQty_Click);
            // 
            // btnGST
            // 
            this.btnGST.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGST.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnGST.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnGST.Location = new System.Drawing.Point(424, 26);
            this.btnGST.Name = "btnGST";
            this.btnGST.Size = new System.Drawing.Size(120, 28);
            this.btnGST.TabIndex = 3;
            this.btnGST.Text = "Owner";
            this.btnGST.UseVisualStyleBackColor = false;
            this.btnGST.Click += new System.EventHandler(this.btnGST_Click);
            // 
            // CustomButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(597, 90);
            this.Controls.Add(this.btnGST);
            this.Controls.Add(this.BtnWithQty);
            this.Controls.Add(this.BtnWithoutPrice);
            this.Controls.Add(this.btnAll);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomButton";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Print";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button BtnWithoutPrice;
        private System.Windows.Forms.Button BtnWithQty;
        private System.Windows.Forms.Button btnGST;
    }
}