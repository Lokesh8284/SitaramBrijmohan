namespace WelcomeFabric
{
    partial class LabourMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LabourMaster));
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lst = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtprice = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtptype = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPanNo = new System.Windows.Forms.TextBox();
            this.dtpTDS = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIfscCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBranchName = new System.Windows.Forms.TextBox();
            this.txtBankNAme = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAcNo = new System.Windows.Forms.TextBox();
            this.txtAcName = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtdes = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(29, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 115;
            this.label11.Text = "Phone";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 88;
            this.label3.Text = "Name : ";
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(280, 358);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(283, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Staff Master";
            // 
            // lst
            // 
            this.lst.FormattingEnabled = true;
            this.lst.Location = new System.Drawing.Point(35, 34);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(175, 394);
            this.lst.TabIndex = 16;
            this.lst.Click += new System.EventHandler(this.lst_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 315);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 114;
            this.label2.Text = "Address";
            // 
            // txtprice
            // 
            this.txtprice.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtprice.Location = new System.Drawing.Point(119, 49);
            this.txtprice.Name = "txtprice";
            this.txtprice.Size = new System.Drawing.Size(240, 20);
            this.txtprice.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtptype);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtSalary);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtPanNo);
            this.groupBox1.Controls.Add(this.dtpTDS);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtIfscCode);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtBranchName);
            this.groupBox1.Controls.Add(this.txtBankNAme);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtAcNo);
            this.groupBox1.Controls.Add(this.txtAcName);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtprice);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.txtdes);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Location = new System.Drawing.Point(216, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 394);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // dtptype
            // 
            this.dtptype.FormattingEnabled = true;
            this.dtptype.Items.AddRange(new object[] {
            "Select",
            "Per Month",
            "Per CFT"});
            this.dtptype.Location = new System.Drawing.Point(245, 214);
            this.dtptype.Name = "dtptype";
            this.dtptype.Size = new System.Drawing.Size(114, 21);
            this.dtptype.TabIndex = 134;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(29, 214);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 13);
            this.label12.TabIndex = 133;
            this.label12.Text = "Salary";
            // 
            // txtSalary
            // 
            this.txtSalary.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSalary.Location = new System.Drawing.Point(119, 214);
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.Size = new System.Drawing.Size(120, 20);
            this.txtSalary.TabIndex = 132;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(29, 272);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 131;
            this.label10.Text = "PAN No";
            // 
            // txtPanNo
            // 
            this.txtPanNo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtPanNo.Location = new System.Drawing.Point(119, 271);
            this.txtPanNo.Name = "txtPanNo";
            this.txtPanNo.Size = new System.Drawing.Size(240, 20);
            this.txtPanNo.TabIndex = 130;
            // 
            // dtpTDS
            // 
            this.dtpTDS.FormattingEnabled = true;
            this.dtpTDS.Items.AddRange(new object[] {
            "Select",
            "Yes",
            "No"});
            this.dtpTDS.Location = new System.Drawing.Point(119, 243);
            this.dtpTDS.Name = "dtpTDS";
            this.dtpTDS.Size = new System.Drawing.Size(240, 21);
            this.dtpTDS.TabIndex = 8;
            this.dtpTDS.SelectedIndexChanged += new System.EventHandler(this.dtpTDS_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 243);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 127;
            this.label8.Text = "TDS";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 185);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 126;
            this.label9.Text = "IFSC Code";
            // 
            // txtIfscCode
            // 
            this.txtIfscCode.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtIfscCode.Location = new System.Drawing.Point(119, 185);
            this.txtIfscCode.Name = "txtIfscCode";
            this.txtIfscCode.Size = new System.Drawing.Size(240, 20);
            this.txtIfscCode.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 123;
            this.label6.Text = "Branch Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 122;
            this.label7.Text = "Bank Name";
            // 
            // txtBranchName
            // 
            this.txtBranchName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtBranchName.Location = new System.Drawing.Point(119, 159);
            this.txtBranchName.Name = "txtBranchName";
            this.txtBranchName.Size = new System.Drawing.Size(240, 20);
            this.txtBranchName.TabIndex = 6;
            // 
            // txtBankNAme
            // 
            this.txtBankNAme.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtBankNAme.Location = new System.Drawing.Point(119, 130);
            this.txtBankNAme.Name = "txtBankNAme";
            this.txtBankNAme.Size = new System.Drawing.Size(240, 20);
            this.txtBankNAme.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 119;
            this.label4.Text = "A/C No";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 118;
            this.label5.Text = "A/C Name";
            // 
            // txtAcNo
            // 
            this.txtAcNo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtAcNo.Location = new System.Drawing.Point(119, 104);
            this.txtAcNo.Name = "txtAcNo";
            this.txtAcNo.Size = new System.Drawing.Size(240, 20);
            this.txtAcNo.TabIndex = 4;
            // 
            // txtAcName
            // 
            this.txtAcName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtAcName.Location = new System.Drawing.Point(119, 75);
            this.txtAcName.Name = "txtAcName";
            this.txtAcName.Size = new System.Drawing.Size(240, 20);
            this.txtAcName.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(199, 358);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(106, 358);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(25, 358);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtdes
            // 
            this.txtdes.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtdes.Location = new System.Drawing.Point(118, 297);
            this.txtdes.Multiline = true;
            this.txtdes.Name = "txtdes";
            this.txtdes.Size = new System.Drawing.Size(241, 46);
            this.txtdes.TabIndex = 9;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtName.Location = new System.Drawing.Point(119, 20);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(240, 20);
            this.txtName.TabIndex = 1;
            // 
            // LabourMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(697, 436);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lst);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "LabourMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Staff Master";
            this.Load += new System.EventHandler(this.LabourMaster_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lst;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtprice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtdes;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtIfscCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBranchName;
        private System.Windows.Forms.TextBox txtBankNAme;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAcNo;
        private System.Windows.Forms.TextBox txtAcName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox dtpTDS;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPanNo;
        private System.Windows.Forms.ComboBox dtptype;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSalary;
    }
}