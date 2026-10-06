namespace WelcomeFabric
{
    partial class CategoryMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryMaster));
            this.lst = new System.Windows.Forms.ListBox();
            this.GroupBox = new System.Windows.Forms.GroupBox();
            this.chkApp = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDisplayOrder = new System.Windows.Forms.TextBox();
            this.btnImage1Clear = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnIMage1 = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCategoryDescription = new System.Windows.Forms.TextBox();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.lblImage1Path = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.drpSupplier = new System.Windows.Forms.ComboBox();
            this.GroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lst
            // 
            this.lst.FormattingEnabled = true;
            this.lst.Location = new System.Drawing.Point(12, 27);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(160, 355);
            this.lst.TabIndex = 0;
            this.lst.Click += new System.EventHandler(this.lst_Click);
            // 
            // GroupBox
            // 
            this.GroupBox.Controls.Add(this.drpSupplier);
            this.GroupBox.Controls.Add(this.label3);
            this.GroupBox.Controls.Add(this.chkApp);
            this.GroupBox.Controls.Add(this.label10);
            this.GroupBox.Controls.Add(this.txtDisplayOrder);
            this.GroupBox.Controls.Add(this.btnImage1Clear);
            this.GroupBox.Controls.Add(this.pictureBox1);
            this.GroupBox.Controls.Add(this.btnIMage1);
            this.GroupBox.Controls.Add(this.btnDelete);
            this.GroupBox.Controls.Add(this.btnClose);
            this.GroupBox.Controls.Add(this.btnCancel);
            this.GroupBox.Controls.Add(this.btnSave);
            this.GroupBox.Controls.Add(this.label2);
            this.GroupBox.Controls.Add(this.label1);
            this.GroupBox.Controls.Add(this.txtCategoryDescription);
            this.GroupBox.Controls.Add(this.txtCategoryName);
            this.GroupBox.Location = new System.Drawing.Point(178, 27);
            this.GroupBox.Name = "GroupBox";
            this.GroupBox.Size = new System.Drawing.Size(362, 360);
            this.GroupBox.TabIndex = 1;
            this.GroupBox.TabStop = false;
            this.GroupBox.Text = "Category";
            // 
            // chkApp
            // 
            this.chkApp.AutoSize = true;
            this.chkApp.Location = new System.Drawing.Point(162, 288);
            this.chkApp.Name = "chkApp";
            this.chkApp.Size = new System.Drawing.Size(86, 17);
            this.chkApp.TabIndex = 6;
            this.chkApp.Text = "Show in App";
            this.chkApp.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 137);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 151;
            this.label10.Text = "Display Order";
            // 
            // txtDisplayOrder
            // 
            this.txtDisplayOrder.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDisplayOrder.Location = new System.Drawing.Point(93, 134);
            this.txtDisplayOrder.Name = "txtDisplayOrder";
            this.txtDisplayOrder.Size = new System.Drawing.Size(234, 20);
            this.txtDisplayOrder.TabIndex = 3;
            this.txtDisplayOrder.Text = "0";
            // 
            // btnImage1Clear
            // 
            this.btnImage1Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImage1Clear.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnImage1Clear.Image = ((System.Drawing.Image)(resources.GetObject("btnImage1Clear.Image")));
            this.btnImage1Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImage1Clear.Location = new System.Drawing.Point(162, 236);
            this.btnImage1Clear.Name = "btnImage1Clear";
            this.btnImage1Clear.Size = new System.Drawing.Size(96, 33);
            this.btnImage1Clear.TabIndex = 5;
            this.btnImage1Clear.Text = "Clear";
            this.btnImage1Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImage1Clear.UseVisualStyleBackColor = true;
            this.btnImage1Clear.Click += new System.EventHandler(this.btnImage1Clear_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(10, 180);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(123, 125);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnIMage1
            // 
            this.btnIMage1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIMage1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnIMage1.Image = ((System.Drawing.Image)(resources.GetObject("btnIMage1.Image")));
            this.btnIMage1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIMage1.Location = new System.Drawing.Point(162, 197);
            this.btnIMage1.Name = "btnIMage1";
            this.btnIMage1.Size = new System.Drawing.Size(96, 33);
            this.btnIMage1.TabIndex = 4;
            this.btnIMage1.Text = "Upload";
            this.btnIMage1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIMage1.UseVisualStyleBackColor = true;
            this.btnIMage1.Click += new System.EventHandler(this.btnIMage1_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(183, 316);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(264, 316);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(102, 315);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(21, 315);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Category Name";
            // 
            // txtCategoryDescription
            // 
            this.txtCategoryDescription.Location = new System.Drawing.Point(93, 88);
            this.txtCategoryDescription.Multiline = true;
            this.txtCategoryDescription.Name = "txtCategoryDescription";
            this.txtCategoryDescription.Size = new System.Drawing.Size(234, 41);
            this.txtCategoryDescription.TabIndex = 2;
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Location = new System.Drawing.Point(93, 62);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(234, 20);
            this.txtCategoryName.TabIndex = 1;
            // 
            // lblImage1Path
            // 
            this.lblImage1Path.AutoSize = true;
            this.lblImage1Path.Location = new System.Drawing.Point(310, 11);
            this.lblImage1Path.Name = "lblImage1Path";
            this.lblImage1Path.Size = new System.Drawing.Size(58, 13);
            this.lblImage1Path.TabIndex = 165;
            this.lblImage1Path.Text = "Item Code:";
            this.lblImage1Path.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 153;
            this.label3.Text = "Supplier";
            // 
            // drpSupplier
            // 
            this.drpSupplier.FormattingEnabled = true;
            this.drpSupplier.Location = new System.Drawing.Point(93, 32);
            this.drpSupplier.Name = "drpSupplier";
            this.drpSupplier.Size = new System.Drawing.Size(234, 21);
            this.drpSupplier.TabIndex = 0;
            // 
            // CategoryMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(552, 399);
            this.Controls.Add(this.lblImage1Path);
            this.Controls.Add(this.GroupBox);
            this.Controls.Add(this.lst);
            this.Name = "CategoryMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Category Master";
            this.Load += new System.EventHandler(this.UnitMaster_Load);
            this.GroupBox.ResumeLayout(false);
            this.GroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lst;
        private System.Windows.Forms.GroupBox GroupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCategoryDescription;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnImage1Clear;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnIMage1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDisplayOrder;
        private System.Windows.Forms.Label lblImage1Path;
        private System.Windows.Forms.CheckBox chkApp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox drpSupplier;
    }
}