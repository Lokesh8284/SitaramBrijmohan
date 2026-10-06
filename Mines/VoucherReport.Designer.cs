namespace WelcomeFabric
{
    partial class VoucherReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoucherReport));
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotAmt = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.grdTest = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Paid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ViewBill = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.drpArea = new System.Windows.Forms.ComboBox();
            this.drpPatientId = new System.Windows.Forms.ComboBox();
            this.label47 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdTest)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(546, 416);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Total  Amount : ";
            // 
            // txtTotAmt
            // 
            this.txtTotAmt.Location = new System.Drawing.Point(670, 413);
            this.txtTotAmt.Name = "txtTotAmt";
            this.txtTotAmt.ReadOnly = true;
            this.txtTotAmt.Size = new System.Drawing.Size(134, 20);
            this.txtTotAmt.TabIndex = 39;
            this.txtTotAmt.Text = "0.00";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(378, 447);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 40;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // grdTest
            // 
            this.grdTest.AllowUserToAddRows = false;
            this.grdTest.AllowUserToDeleteRows = false;
            this.grdTest.AllowUserToResizeColumns = false;
            this.grdTest.AllowUserToResizeRows = false;
            this.grdTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.ReceiptNo,
            this.ClientID,
            this.ClientName,
            this.Address,
            this.PaymentMode,
            this.Paid,
            this.Remark,
            this.ViewBill});
            this.grdTest.Location = new System.Drawing.Point(42, 203);
            this.grdTest.Name = "grdTest";
            this.grdTest.ReadOnly = true;
            this.grdTest.RowHeadersVisible = false;
            this.grdTest.Size = new System.Drawing.Size(860, 188);
            this.grdTest.TabIndex = 42;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Dat";
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // ReceiptNo
            // 
            this.ReceiptNo.DataPropertyName = "ReceiptNo";
            this.ReceiptNo.HeaderText = "Receipt No";
            this.ReceiptNo.Name = "ReceiptNo";
            this.ReceiptNo.ReadOnly = true;
            // 
            // ClientID
            // 
            this.ClientID.DataPropertyName = "Client_ID";
            this.ClientID.HeaderText = "Client ID";
            this.ClientID.Name = "ClientID";
            this.ClientID.ReadOnly = true;
            this.ClientID.Visible = false;
            // 
            // ClientName
            // 
            this.ClientName.DataPropertyName = "Name";
            this.ClientName.HeaderText = "Client Name";
            this.ClientName.Name = "ClientName";
            this.ClientName.ReadOnly = true;
            this.ClientName.Width = 150;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            this.Address.Width = 150;
            // 
            // PaymentMode
            // 
            this.PaymentMode.DataPropertyName = "PaymentMode";
            this.PaymentMode.HeaderText = "Payment Mode";
            this.PaymentMode.Name = "PaymentMode";
            this.PaymentMode.ReadOnly = true;
            // 
            // Paid
            // 
            this.Paid.DataPropertyName = "Paid";
            this.Paid.HeaderText = "Paid Amount";
            this.Paid.Name = "Paid";
            this.Paid.ReadOnly = true;
            // 
            // Remark
            // 
            this.Remark.DataPropertyName = "Remark";
            this.Remark.HeaderText = "Remark";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            this.Remark.Width = 150;
            // 
            // ViewBill
            // 
            this.ViewBill.DataPropertyName = "ViewBill";
            this.ViewBill.HeaderText = "";
            this.ViewBill.Name = "ViewBill";
            this.ViewBill.ReadOnly = true;
            this.ViewBill.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ViewBill.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ViewBill.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.drpArea);
            this.groupBox1.Controls.Add(this.drpPatientId);
            this.groupBox1.Controls.Add(this.label47);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(207, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(661, 131);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Option";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(336, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "City:";
            // 
            // drpArea
            // 
            this.drpArea.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.drpArea.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.drpArea.FormattingEnabled = true;
            this.drpArea.Location = new System.Drawing.Point(390, 22);
            this.drpArea.Name = "drpArea";
            this.drpArea.Size = new System.Drawing.Size(121, 21);
            this.drpArea.TabIndex = 31;
            // 
            // drpPatientId
            // 
            this.drpPatientId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.drpPatientId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.drpPatientId.FormattingEnabled = true;
            this.drpPatientId.Location = new System.Drawing.Point(125, 19);
            this.drpPatientId.Name = "drpPatientId";
            this.drpPatientId.Size = new System.Drawing.Size(176, 21);
            this.drpPatientId.TabIndex = 1;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(47, 22);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(67, 13);
            this.label47.TabIndex = 30;
            this.label47.Text = "Client Name:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(275, 94);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(194, 94);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Checked = false;
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(364, 58);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.ShowCheckBox = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(121, 20);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(310, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "To";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Checked = false;
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(171, 58);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowCheckBox = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(121, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Date Between  ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(380, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 23);
            this.label1.TabIndex = 41;
            this.label1.Text = "Voucher Report";
            // 
            // VoucherReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 471);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTotAmt);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.grdTest);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VoucherReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VoucherReport";
            this.Load += new System.EventHandler(this.VoucherReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdTest)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotAmt;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView grdTest;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox drpPatientId;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox drpArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Paid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.DataGridViewLinkColumn ViewBill;
    }
}