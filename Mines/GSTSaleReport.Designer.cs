namespace WelcomeFabric
{
    partial class GSTSaleReport
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtIGST = new System.Windows.Forms.TextBox();
            this.txtSGST = new System.Windows.Forms.TextBox();
            this.txtCGST = new System.Windows.Forms.TextBox();
            this.txtAmt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblSummary = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.grdTest = new System.Windows.Forms.DataGridView();
            this.srno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CGST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SGST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IGST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxableValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtTotal1 = new System.Windows.Forms.TextBox();
            this.txtIGST1 = new System.Windows.Forms.TextBox();
            this.txtSGST1 = new System.Windows.Forms.TextBox();
            this.txtCGST1 = new System.Windows.Forms.TextBox();
            this.txtAmt1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDetails = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.drpGST = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePicker4 = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.btnPrint1 = new System.Windows.Forms.Button();
            this.btnClose1 = new System.Windows.Forms.Button();
            this.btnSearch1 = new System.Windows.Forms.Button();
            this.grdTest1 = new System.Windows.Forms.DataGridView();
            this.srno1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceDate1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceNo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CGST1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SGST1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IGST1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxableValue1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTest)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTest1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(881, 478);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtTotal);
            this.tabPage1.Controls.Add(this.txtIGST);
            this.tabPage1.Controls.Add(this.txtSGST);
            this.tabPage1.Controls.Add(this.txtCGST);
            this.tabPage1.Controls.Add(this.txtAmt);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.lblSummary);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.grdTest);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(873, 452);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "GST Report";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(745, 414);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(100, 20);
            this.txtTotal.TabIndex = 34434;
            this.txtTotal.Text = "0";
            // 
            // txtIGST
            // 
            this.txtIGST.Enabled = false;
            this.txtIGST.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIGST.Location = new System.Drawing.Point(639, 414);
            this.txtIGST.Name = "txtIGST";
            this.txtIGST.Size = new System.Drawing.Size(100, 20);
            this.txtIGST.TabIndex = 34433;
            this.txtIGST.Text = "0";
            // 
            // txtSGST
            // 
            this.txtSGST.Enabled = false;
            this.txtSGST.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSGST.Location = new System.Drawing.Point(533, 414);
            this.txtSGST.Name = "txtSGST";
            this.txtSGST.Size = new System.Drawing.Size(100, 20);
            this.txtSGST.TabIndex = 34432;
            this.txtSGST.Text = "0";
            // 
            // txtCGST
            // 
            this.txtCGST.Enabled = false;
            this.txtCGST.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCGST.Location = new System.Drawing.Point(427, 414);
            this.txtCGST.Name = "txtCGST";
            this.txtCGST.Size = new System.Drawing.Size(100, 20);
            this.txtCGST.TabIndex = 34431;
            this.txtCGST.Text = "0";
            // 
            // txtAmt
            // 
            this.txtAmt.Enabled = false;
            this.txtAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmt.Location = new System.Drawing.Point(321, 414);
            this.txtAmt.Name = "txtAmt";
            this.txtAmt.Size = new System.Drawing.Size(100, 20);
            this.txtAmt.TabIndex = 34430;
            this.txtAmt.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(232, 421);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 34429;
            this.label2.Text = "Total";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Stencil", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label19.Location = new System.Drawing.Point(67, 14);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(20, 19);
            this.label19.TabIndex = 34428;
            this.label19.Text = "d";
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.Font = new System.Drawing.Font("Verdana", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSummary.Location = new System.Drawing.Point(348, 14);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(185, 23);
            this.lblSummary.TabIndex = 34427;
            this.lblSummary.Text = "GST Sale Report";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Location = new System.Drawing.Point(21, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(824, 60);
            this.groupBox1.TabIndex = 34426;
            this.groupBox1.TabStop = false;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Checked = false;
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(318, 25);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.ShowCheckBox = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(107, 20);
            this.dateTimePicker2.TabIndex = 44;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(287, 28);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 14);
            this.label4.TabIndex = 45;
            this.label4.Text = "To";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Checked = false;
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(163, 25);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowCheckBox = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(116, 20);
            this.dateTimePicker1.TabIndex = 43;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 14);
            this.label3.TabIndex = 42;
            this.label3.Text = "Date Between  ";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(730, 24);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(80, 23);
            this.btnPrint.TabIndex = 41;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(618, 24);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(490, 24);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // grdTest
            // 
            this.grdTest.AllowUserToAddRows = false;
            this.grdTest.AllowUserToDeleteRows = false;
            this.grdTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.srno,
            this.InvoiceDate,
            this.InvoiceNo,
            this.Amount,
            this.CGST,
            this.SGST,
            this.IGST,
            this.TaxableValue});
            this.grdTest.Location = new System.Drawing.Point(21, 111);
            this.grdTest.Name = "grdTest";
            this.grdTest.ReadOnly = true;
            this.grdTest.RowHeadersVisible = false;
            this.grdTest.Size = new System.Drawing.Size(824, 297);
            this.grdTest.TabIndex = 34425;
            // 
            // srno
            // 
            this.srno.HeaderText = "S.No";
            this.srno.Name = "srno";
            this.srno.ReadOnly = true;
            // 
            // InvoiceDate
            // 
            this.InvoiceDate.HeaderText = "Invoice Date";
            this.InvoiceDate.Name = "InvoiceDate";
            this.InvoiceDate.ReadOnly = true;
            // 
            // InvoiceNo
            // 
            this.InvoiceNo.HeaderText = "Invoice No";
            this.InvoiceNo.Name = "InvoiceNo";
            this.InvoiceNo.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // CGST
            // 
            this.CGST.HeaderText = "CGST";
            this.CGST.Name = "CGST";
            this.CGST.ReadOnly = true;
            // 
            // SGST
            // 
            this.SGST.HeaderText = "SGST";
            this.SGST.Name = "SGST";
            this.SGST.ReadOnly = true;
            // 
            // IGST
            // 
            this.IGST.HeaderText = "IGST";
            this.IGST.Name = "IGST";
            this.IGST.ReadOnly = true;
            // 
            // TaxableValue
            // 
            this.TaxableValue.HeaderText = "Total Amount";
            this.TaxableValue.Name = "TaxableValue";
            this.TaxableValue.ReadOnly = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtTotal1);
            this.tabPage2.Controls.Add(this.txtIGST1);
            this.tabPage2.Controls.Add(this.txtSGST1);
            this.tabPage2.Controls.Add(this.txtCGST1);
            this.tabPage2.Controls.Add(this.txtAmt1);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.lblDetails);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.grdTest1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(873, 452);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "GST Report1";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtTotal1
            // 
            this.txtTotal1.Enabled = false;
            this.txtTotal1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal1.Location = new System.Drawing.Point(758, 416);
            this.txtTotal1.Name = "txtTotal1";
            this.txtTotal1.Size = new System.Drawing.Size(100, 20);
            this.txtTotal1.TabIndex = 34434;
            this.txtTotal1.Text = "0";
            // 
            // txtIGST1
            // 
            this.txtIGST1.Enabled = false;
            this.txtIGST1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIGST1.Location = new System.Drawing.Point(652, 416);
            this.txtIGST1.Name = "txtIGST1";
            this.txtIGST1.Size = new System.Drawing.Size(100, 20);
            this.txtIGST1.TabIndex = 34433;
            this.txtIGST1.Text = "0";
            // 
            // txtSGST1
            // 
            this.txtSGST1.Enabled = false;
            this.txtSGST1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSGST1.Location = new System.Drawing.Point(546, 416);
            this.txtSGST1.Name = "txtSGST1";
            this.txtSGST1.Size = new System.Drawing.Size(100, 20);
            this.txtSGST1.TabIndex = 34432;
            this.txtSGST1.Text = "0";
            // 
            // txtCGST1
            // 
            this.txtCGST1.Enabled = false;
            this.txtCGST1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCGST1.Location = new System.Drawing.Point(440, 416);
            this.txtCGST1.Name = "txtCGST1";
            this.txtCGST1.Size = new System.Drawing.Size(100, 20);
            this.txtCGST1.TabIndex = 34431;
            this.txtCGST1.Text = "0";
            // 
            // txtAmt1
            // 
            this.txtAmt1.Enabled = false;
            this.txtAmt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmt1.Location = new System.Drawing.Point(334, 416);
            this.txtAmt1.Name = "txtAmt1";
            this.txtAmt1.Size = new System.Drawing.Size(100, 20);
            this.txtAmt1.TabIndex = 34430;
            this.txtAmt1.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(268, 419);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 34429;
            this.label5.Text = "Total";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Stencil", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(46, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 19);
            this.label6.TabIndex = 34428;
            this.label6.Text = "d";
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.Font = new System.Drawing.Font("Verdana", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetails.Location = new System.Drawing.Point(330, 16);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(257, 23);
            this.lblDetails.TabIndex = 34427;
            this.lblDetails.Text = "GST Sale Detail Report";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.drpGST);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.dateTimePicker3);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.dateTimePicker4);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.btnPrint1);
            this.groupBox2.Controls.Add(this.btnClose1);
            this.groupBox2.Controls.Add(this.btnSearch1);
            this.groupBox2.Location = new System.Drawing.Point(34, 42);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(824, 60);
            this.groupBox2.TabIndex = 34426;
            this.groupBox2.TabStop = false;
            // 
            // drpGST
            // 
            this.drpGST.FormattingEnabled = true;
            this.drpGST.Items.AddRange(new object[] {
            "Select",
            "5",
            "12",
            "18",
            "28"});
            this.drpGST.Location = new System.Drawing.Point(44, 22);
            this.drpGST.Name = "drpGST";
            this.drpGST.Size = new System.Drawing.Size(109, 21);
            this.drpGST.TabIndex = 47;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 46;
            this.label10.Text = "GST";
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Checked = false;
            this.dateTimePicker3.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker3.Location = new System.Drawing.Point(445, 26);
            this.dateTimePicker3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.ShowCheckBox = true;
            this.dateTimePicker3.Size = new System.Drawing.Size(107, 20);
            this.dateTimePicker3.TabIndex = 44;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(414, 29);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 14);
            this.label8.TabIndex = 45;
            this.label8.Text = "To";
            // 
            // dateTimePicker4
            // 
            this.dateTimePicker4.Checked = false;
            this.dateTimePicker4.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker4.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker4.Location = new System.Drawing.Point(290, 26);
            this.dateTimePicker4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dateTimePicker4.Name = "dateTimePicker4";
            this.dateTimePicker4.ShowCheckBox = true;
            this.dateTimePicker4.Size = new System.Drawing.Size(116, 20);
            this.dateTimePicker4.TabIndex = 43;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(174, 26);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 14);
            this.label9.TabIndex = 42;
            this.label9.Text = "Date Between  ";
            // 
            // btnPrint1
            // 
            this.btnPrint1.Location = new System.Drawing.Point(736, 24);
            this.btnPrint1.Name = "btnPrint1";
            this.btnPrint1.Size = new System.Drawing.Size(80, 23);
            this.btnPrint1.TabIndex = 41;
            this.btnPrint1.Text = "Print";
            this.btnPrint1.UseVisualStyleBackColor = true;
            this.btnPrint1.Click += new System.EventHandler(this.btnPrint1_Click);
            // 
            // btnClose1
            // 
            this.btnClose1.Location = new System.Drawing.Point(655, 24);
            this.btnClose1.Name = "btnClose1";
            this.btnClose1.Size = new System.Drawing.Size(75, 23);
            this.btnClose1.TabIndex = 6;
            this.btnClose1.Text = "Close";
            this.btnClose1.UseVisualStyleBackColor = true;
            this.btnClose1.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSearch1
            // 
            this.btnSearch1.Location = new System.Drawing.Point(570, 25);
            this.btnSearch1.Name = "btnSearch1";
            this.btnSearch1.Size = new System.Drawing.Size(75, 23);
            this.btnSearch1.TabIndex = 5;
            this.btnSearch1.Text = "Search";
            this.btnSearch1.UseVisualStyleBackColor = true;
            this.btnSearch1.Click += new System.EventHandler(this.btnSearch1_Click);
            // 
            // grdTest1
            // 
            this.grdTest1.AllowUserToAddRows = false;
            this.grdTest1.AllowUserToDeleteRows = false;
            this.grdTest1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTest1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.srno1,
            this.InvoiceDate1,
            this.InvoiceNo1,
            this.Amount1,
            this.CGST1,
            this.SGST1,
            this.IGST1,
            this.TaxableValue1,
            this.GST});
            this.grdTest1.Location = new System.Drawing.Point(34, 113);
            this.grdTest1.Name = "grdTest1";
            this.grdTest1.ReadOnly = true;
            this.grdTest1.RowHeadersVisible = false;
            this.grdTest1.Size = new System.Drawing.Size(824, 297);
            this.grdTest1.TabIndex = 34425;
            // 
            // srno1
            // 
            this.srno1.HeaderText = "S.No";
            this.srno1.Name = "srno1";
            this.srno1.ReadOnly = true;
            // 
            // InvoiceDate1
            // 
            this.InvoiceDate1.HeaderText = "Invoice Date";
            this.InvoiceDate1.Name = "InvoiceDate1";
            this.InvoiceDate1.ReadOnly = true;
            // 
            // InvoiceNo1
            // 
            this.InvoiceNo1.HeaderText = "Invoice No";
            this.InvoiceNo1.Name = "InvoiceNo1";
            this.InvoiceNo1.ReadOnly = true;
            // 
            // Amount1
            // 
            this.Amount1.HeaderText = "Amount";
            this.Amount1.Name = "Amount1";
            this.Amount1.ReadOnly = true;
            // 
            // CGST1
            // 
            this.CGST1.HeaderText = "CGST";
            this.CGST1.Name = "CGST1";
            this.CGST1.ReadOnly = true;
            // 
            // SGST1
            // 
            this.SGST1.HeaderText = "SGST";
            this.SGST1.Name = "SGST1";
            this.SGST1.ReadOnly = true;
            // 
            // IGST1
            // 
            this.IGST1.HeaderText = "IGST";
            this.IGST1.Name = "IGST1";
            this.IGST1.ReadOnly = true;
            // 
            // TaxableValue1
            // 
            this.TaxableValue1.HeaderText = "Total Amount";
            this.TaxableValue1.Name = "TaxableValue1";
            this.TaxableValue1.ReadOnly = true;
            // 
            // GST
            // 
            this.GST.HeaderText = "GST";
            this.GST.Name = "GST";
            this.GST.ReadOnly = true;
            this.GST.Visible = false;
            // 
            // GSTSaleReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(916, 502);
            this.Controls.Add(this.tabControl1);
            this.Name = "GSTSaleReport";
            this.Text = "GSTSaleReport";
            this.Load += new System.EventHandler(this.GSTSaleReport_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTest)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTest1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtIGST;
        private System.Windows.Forms.TextBox txtSGST;
        private System.Windows.Forms.TextBox txtCGST;
        private System.Windows.Forms.TextBox txtAmt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView grdTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn srno;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn CGST;
        private System.Windows.Forms.DataGridViewTextBoxColumn SGST;
        private System.Windows.Forms.DataGridViewTextBoxColumn IGST;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxableValue;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtTotal1;
        private System.Windows.Forms.TextBox txtIGST1;
        private System.Windows.Forms.TextBox txtSGST1;
        private System.Windows.Forms.TextBox txtCGST1;
        private System.Windows.Forms.TextBox txtAmt1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePicker4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnPrint1;
        private System.Windows.Forms.Button btnClose1;
        private System.Windows.Forms.Button btnSearch1;
        private System.Windows.Forms.DataGridView grdTest1;
        private System.Windows.Forms.ComboBox drpGST;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn srno1;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceDate1;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceNo1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CGST1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SGST1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IGST1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxableValue1;
        private System.Windows.Forms.DataGridViewTextBoxColumn GST;

    }
}