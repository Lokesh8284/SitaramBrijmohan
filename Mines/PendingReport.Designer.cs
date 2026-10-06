namespace WelcomeFabric
{
    partial class PendingReports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PendingReports));
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.grdTest = new System.Windows.Forms.DataGridView();
            this.Dat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firmaddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Client_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameHindi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrincipalAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Receivedamt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pend = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CrDr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Narration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccTyp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPrint = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.drpPatientId = new System.Windows.Forms.ComboBox();
            this.label47 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.drpArea = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdTest)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(301, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "To";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(172, 67);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(121, 20);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Date Between  ";
            // 
            // grdTest
            // 
            this.grdTest.AllowUserToAddRows = false;
            this.grdTest.AllowUserToDeleteRows = false;
            this.grdTest.AllowUserToResizeColumns = false;
            this.grdTest.AllowUserToResizeRows = false;
            this.grdTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Dat,
            this.compname,
            this.firmaddress,
            this.Client_Id,
            this.Name,
            this.NameHindi,
            this.Mob,
            this.Address,
            this.PrincipalAmt,
            this.Receivedamt,
            this.pend,
            this.CrDr,
            this.Narration,
            this.AccTyp});
            this.grdTest.Location = new System.Drawing.Point(35, 180);
            this.grdTest.Name = "grdTest";
            this.grdTest.ReadOnly = true;
            this.grdTest.RowHeadersVisible = false;
            this.grdTest.Size = new System.Drawing.Size(779, 226);
            this.grdTest.TabIndex = 44;
            // 
            // Dat
            // 
            this.Dat.DataPropertyName = "Dat";
            this.Dat.HeaderText = "Date";
            this.Dat.Name = "Dat";
            this.Dat.ReadOnly = true;
            // 
            // compname
            // 
            this.compname.DataPropertyName = "compname";
            this.compname.HeaderText = "compname";
            this.compname.Name = "compname";
            this.compname.ReadOnly = true;
            this.compname.Visible = false;
            // 
            // firmaddress
            // 
            this.firmaddress.DataPropertyName = "firmaddress";
            this.firmaddress.HeaderText = "firmaddress";
            this.firmaddress.Name = "firmaddress";
            this.firmaddress.ReadOnly = true;
            this.firmaddress.Visible = false;
            // 
            // Client_Id
            // 
            this.Client_Id.DataPropertyName = "Client_Id";
            this.Client_Id.HeaderText = "ClientId";
            this.Client_Id.Name = "Client_Id";
            this.Client_Id.ReadOnly = true;
            this.Client_Id.Visible = false;
            // 
            // Name
            // 
            this.Name.DataPropertyName = "Name";
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            // 
            // NameHindi
            // 
            this.NameHindi.DataPropertyName = "NameHindi";
            this.NameHindi.HeaderText = "NameHindi";
            this.NameHindi.Name = "NameHindi";
            this.NameHindi.ReadOnly = true;
            this.NameHindi.Visible = false;
            // 
            // Mob
            // 
            this.Mob.DataPropertyName = "Mob";
            this.Mob.HeaderText = "Mobile No.";
            this.Mob.Name = "Mob";
            this.Mob.ReadOnly = true;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            this.Address.Width = 120;
            // 
            // PrincipalAmt
            // 
            this.PrincipalAmt.DataPropertyName = "PrincipalAmt";
            this.PrincipalAmt.HeaderText = "PrincipalAmt";
            this.PrincipalAmt.Name = "PrincipalAmt";
            this.PrincipalAmt.ReadOnly = true;
            this.PrincipalAmt.Width = 80;
            // 
            // Receivedamt
            // 
            this.Receivedamt.DataPropertyName = "Receivedamt";
            this.Receivedamt.HeaderText = "Received Amt";
            this.Receivedamt.Name = "Receivedamt";
            this.Receivedamt.ReadOnly = true;
            // 
            // pend
            // 
            this.pend.DataPropertyName = "pend";
            this.pend.HeaderText = "Pending Amount";
            this.pend.Name = "pend";
            this.pend.ReadOnly = true;
            // 
            // CrDr
            // 
            this.CrDr.DataPropertyName = "CrDr";
            this.CrDr.HeaderText = "DrCr";
            this.CrDr.Name = "CrDr";
            this.CrDr.ReadOnly = true;
            this.CrDr.Width = 30;
            // 
            // Narration
            // 
            this.Narration.DataPropertyName = "Narration";
            this.Narration.HeaderText = "Narration";
            this.Narration.Name = "Narration";
            this.Narration.ReadOnly = true;
            this.Narration.Visible = false;
            // 
            // AccTyp
            // 
            this.AccTyp.DataPropertyName = "AccType";
            this.AccTyp.HeaderText = "AccType";
            this.AccTyp.Name = "AccTyp";
            this.AccTyp.ReadOnly = true;
            this.AccTyp.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(374, 426);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 42;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.drpPatientId);
            this.groupBox1.Controls.Add(this.label47);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.drpArea);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(171, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(496, 126);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Option";
            // 
            // drpPatientId
            // 
            this.drpPatientId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.drpPatientId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.drpPatientId.FormattingEnabled = true;
            this.drpPatientId.Location = new System.Drawing.Point(137, 23);
            this.drpPatientId.Name = "drpPatientId";
            this.drpPatientId.Size = new System.Drawing.Size(160, 21);
            this.drpPatientId.TabIndex = 1;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(50, 26);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(81, 13);
            this.label47.TabIndex = 32;
            this.label47.Text = "Account Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(324, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "City";
            // 
            // drpArea
            // 
            this.drpArea.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.drpArea.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.drpArea.FormattingEnabled = true;
            this.drpArea.Location = new System.Drawing.Point(363, 23);
            this.drpArea.Name = "drpArea";
            this.drpArea.Size = new System.Drawing.Size(121, 21);
            this.drpArea.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(232, 97);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(151, 97);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(327, 67);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(121, 20);
            this.dateTimePicker2.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(328, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 23);
            this.label1.TabIndex = 43;
            this.label1.Text = "Pending Report";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Stencil", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label13.Location = new System.Drawing.Point(12, 14);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 19);
            this.label13.TabIndex = 34369;
            this.label13.Text = "d";
            // 
            // PendingReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(826, 453);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.grdTest);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            //this.Name = "PendingReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PendingReport";
            this.Load += new System.EventHandler(this.PendingReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdTest)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView grdTest;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox drpPatientId;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox drpArea;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dat;
        private System.Windows.Forms.DataGridViewTextBoxColumn compname;
        private System.Windows.Forms.DataGridViewTextBoxColumn firmaddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Client_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameHindi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mob;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrincipalAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Receivedamt;
        private System.Windows.Forms.DataGridViewTextBoxColumn pend;
        private System.Windows.Forms.DataGridViewTextBoxColumn CrDr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Narration;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccTyp;
        private System.Windows.Forms.Label label13;
    }
}