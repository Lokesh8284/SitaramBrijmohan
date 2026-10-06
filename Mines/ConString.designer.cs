namespace WelcomeFabric
{
    partial class ConString
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
            this.btn_Chk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCon = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btn_Save = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Chk
            // 
            this.btn_Chk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Chk.Location = new System.Drawing.Point(96, 48);
            this.btn_Chk.Name = "btn_Chk";
            this.btn_Chk.Size = new System.Drawing.Size(107, 31);
            this.btn_Chk.TabIndex = 0;
            this.btn_Chk.Text = "Check";
            this.btn_Chk.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // txtCon
            // 
            this.txtCon.Location = new System.Drawing.Point(54, 13);
            this.txtCon.Name = "txtCon";
            this.txtCon.Size = new System.Drawing.Size(639, 20);
            this.txtCon.TabIndex = 4;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btn_Save
            // 
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.Location = new System.Drawing.Point(287, 48);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(107, 31);
            this.btn_Save.TabIndex = 5;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(475, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 31);
            this.button2.TabIndex = 6;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ConString
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 85);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.txtCon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Chk);
            this.Name = "ConString";
            this.Text = "ConString";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Chk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCon;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_Save;
    }
}