namespace WelcomeFabric
{
    partial class MobileBill
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
            this.lblFormHeader = new System.Windows.Forms.Label();
            this.drpname = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMoblieNo = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtchalanno = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.button4 = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lst = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdtest1 = new System.Windows.Forms.DataGridView();
            this.txtTotalQty = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.txtTotalTaxAmt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txttotal = new System.Windows.Forms.TextBox();
            this.btnReprint = new System.Windows.Forms.Button();
            this.btndel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.Sno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HSNCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxableValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CGST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CGSTAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SGST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SGSTAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IGST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IGSTAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ravanno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MetricTon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.upid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit1 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.del = new System.Windows.Forms.DataGridViewLinkColumn();
            this.lstPending = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMainId = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdtest1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFormHeader
            // 
            this.lblFormHeader.AutoSize = true;
            this.lblFormHeader.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormHeader.ForeColor = System.Drawing.Color.Maroon;
            this.lblFormHeader.Location = new System.Drawing.Point(305, 9);
            this.lblFormHeader.Name = "lblFormHeader";
            this.lblFormHeader.Size = new System.Drawing.Size(409, 29);
            this.lblFormHeader.TabIndex = 34345;
            this.lblFormHeader.Text = "INVOICE ENTRY (With Order)";
            // 
            // drpname
            // 
            this.drpname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.drpname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.drpname.BackColor = System.Drawing.Color.White;
            this.drpname.FormattingEnabled = true;
            this.drpname.Location = new System.Drawing.Point(96, 23);
            this.drpname.Name = "drpname";
            this.drpname.Size = new System.Drawing.Size(345, 21);
            this.drpname.TabIndex = 34346;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 34347;
            this.label4.Text = "Party Name";
            // 
            // txtMoblieNo
            // 
            this.txtMoblieNo.BackColor = System.Drawing.Color.White;
            this.txtMoblieNo.Location = new System.Drawing.Point(96, 50);
            this.txtMoblieNo.MaxLength = 10;
            this.txtMoblieNo.Name = "txtMoblieNo";
            this.txtMoblieNo.Size = new System.Drawing.Size(151, 21);
            this.txtMoblieNo.TabIndex = 34372;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(16, 54);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(62, 13);
            this.label23.TabIndex = 34373;
            this.label23.Text = "Mobile No";
            // 
            // txtchalanno
            // 
            this.txtchalanno.BackColor = System.Drawing.Color.White;
            this.txtchalanno.Location = new System.Drawing.Point(540, 50);
            this.txtchalanno.Name = "txtchalanno";
            this.txtchalanno.Size = new System.Drawing.Size(116, 21);
            this.txtchalanno.TabIndex = 34377;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(540, 23);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(117, 21);
            this.dateTimePicker1.TabIndex = 34374;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(454, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 34376;
            this.label3.Text = "Invoice Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(466, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 34375;
            this.label2.Text = "Invoice No";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.DisplayGroupTree = false;
            this.crystalReportViewer1.DisplayStatusBar = false;
            this.crystalReportViewer1.Location = new System.Drawing.Point(1, 383);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(209, 58);
            this.crystalReportViewer1.TabIndex = 34415;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            this.crystalReportViewer1.Visible = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(140, 45);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(108, 23);
            this.button4.TabIndex = 34411;
            this.button4.Text = "Search";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(119, 25);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(20, 13);
            this.label24.TabIndex = 34412;
            this.label24.Text = "To";
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd/MM/yyyy";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(140, 22);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(108, 21);
            this.dtpTo.TabIndex = 34414;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(1, 22);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(117, 21);
            this.dtpFrom.TabIndex = 34413;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(1, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(117, 21);
            this.textBox1.TabIndex = 34410;
            // 
            // lst
            // 
            this.lst.FormattingEnabled = true;
            this.lst.Location = new System.Drawing.Point(1, 74);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(250, 303);
            this.lst.TabIndex = 34409;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(-2, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 34408;
            this.label6.Text = "Rawanna No";
            this.label6.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.drpname);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtMoblieNo);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtchalanno);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Location = new System.Drawing.Point(257, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(663, 94);
            this.groupBox1.TabIndex = 34416;
            this.groupBox1.TabStop = false;
            // 
            // grdtest1
            // 
            this.grdtest1.AllowUserToAddRows = false;
            this.grdtest1.AllowUserToDeleteRows = false;
            this.grdtest1.AllowUserToResizeColumns = false;
            this.grdtest1.AllowUserToResizeRows = false;
            this.grdtest1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdtest1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdtest1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sno,
            this.OrderNo,
            this.Item,
            this.Barcode,
            this.HSNCode,
            this.Unit,
            this.qty,
            this.Discount1,
            this.rate,
            this.amount,
            this.TaxableValue,
            this.CGST,
            this.CGSTAmt,
            this.SGST,
            this.SGSTAmt,
            this.IGST,
            this.IGSTAmt,
            this.TotalAmt,
            this.ravanno,
            this.id,
            this.MetricTon,
            this.itemid,
            this.upid,
            this.Edit1,
            this.del});
            this.grdtest1.Location = new System.Drawing.Point(257, 143);
            this.grdtest1.Name = "grdtest1";
            this.grdtest1.ReadOnly = true;
            this.grdtest1.RowHeadersVisible = false;
            this.grdtest1.Size = new System.Drawing.Size(663, 234);
            this.grdtest1.TabIndex = 34417;
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.BackColor = System.Drawing.Color.White;
            this.txtTotalQty.Location = new System.Drawing.Point(446, 383);
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.Size = new System.Drawing.Size(70, 21);
            this.txtTotalQty.TabIndex = 34419;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(388, 387);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(58, 13);
            this.label50.TabIndex = 34418;
            this.label50.Text = "Total Qty";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(516, 387);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(82, 13);
            this.label36.TabIndex = 34424;
            this.label36.Text = "Total Amount";
            // 
            // txtTotalTaxAmt
            // 
            this.txtTotalTaxAmt.BackColor = System.Drawing.Color.White;
            this.txtTotalTaxAmt.Enabled = false;
            this.txtTotalTaxAmt.Location = new System.Drawing.Point(598, 383);
            this.txtTotalTaxAmt.Name = "txtTotalTaxAmt";
            this.txtTotalTaxAmt.ReadOnly = true;
            this.txtTotalTaxAmt.Size = new System.Drawing.Size(116, 21);
            this.txtTotalTaxAmt.TabIndex = 34423;
            this.txtTotalTaxAmt.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(714, 387);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 34422;
            this.label7.Text = "Actual Amount";
            // 
            // txttotal
            // 
            this.txttotal.BackColor = System.Drawing.Color.White;
            this.txttotal.Enabled = false;
            this.txttotal.Location = new System.Drawing.Point(804, 383);
            this.txttotal.Name = "txttotal";
            this.txttotal.ReadOnly = true;
            this.txttotal.Size = new System.Drawing.Size(116, 21);
            this.txttotal.TabIndex = 34421;
            this.txttotal.Text = "0";
            // 
            // btnReprint
            // 
            this.btnReprint.Location = new System.Drawing.Point(231, 424);
            this.btnReprint.Name = "btnReprint";
            this.btnReprint.Size = new System.Drawing.Size(87, 31);
            this.btnReprint.TabIndex = 34430;
            this.btnReprint.Text = "Reprint";
            this.btnReprint.UseVisualStyleBackColor = true;
            this.btnReprint.Visible = false;
            // 
            // btndel
            // 
            this.btndel.Location = new System.Drawing.Point(615, 424);
            this.btndel.Name = "btndel";
            this.btndel.Size = new System.Drawing.Size(87, 31);
            this.btndel.TabIndex = 34429;
            this.btndel.Text = "Delete";
            this.btndel.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(423, 424);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 31);
            this.button1.TabIndex = 34427;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(519, 424);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 31);
            this.button2.TabIndex = 34428;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(327, 424);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(87, 31);
            this.btnsave.TabIndex = 34426;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // Sno
            // 
            this.Sno.DataPropertyName = "sno";
            this.Sno.FillWeight = 40F;
            this.Sno.HeaderText = "SNo";
            this.Sno.Name = "Sno";
            this.Sno.ReadOnly = true;
            // 
            // OrderNo
            // 
            this.OrderNo.FillWeight = 60F;
            this.OrderNo.HeaderText = "Order No";
            this.OrderNo.Name = "OrderNo";
            this.OrderNo.ReadOnly = true;
            // 
            // Item
            // 
            this.Item.DataPropertyName = "Item";
            this.Item.FillWeight = 150F;
            this.Item.HeaderText = "Item Name";
            this.Item.Name = "Item";
            this.Item.ReadOnly = true;
            // 
            // Barcode
            // 
            this.Barcode.FillWeight = 60F;
            this.Barcode.HeaderText = "ItemCode";
            this.Barcode.Name = "Barcode";
            this.Barcode.ReadOnly = true;
            this.Barcode.Visible = false;
            // 
            // HSNCode
            // 
            this.HSNCode.HeaderText = "HSN Code";
            this.HSNCode.Name = "HSNCode";
            this.HSNCode.ReadOnly = true;
            this.HSNCode.Visible = false;
            // 
            // Unit
            // 
            this.Unit.DataPropertyName = "Unit";
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            // 
            // qty
            // 
            this.qty.DataPropertyName = "qty";
            this.qty.FillWeight = 50F;
            this.qty.HeaderText = "Qty";
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            // 
            // Discount1
            // 
            this.Discount1.HeaderText = "Discount";
            this.Discount1.Name = "Discount1";
            this.Discount1.ReadOnly = true;
            this.Discount1.Visible = false;
            // 
            // rate
            // 
            this.rate.DataPropertyName = "price";
            this.rate.FillWeight = 50F;
            this.rate.HeaderText = "Rate";
            this.rate.Name = "rate";
            this.rate.ReadOnly = true;
            // 
            // amount
            // 
            this.amount.DataPropertyName = "amount";
            this.amount.HeaderText = "Amount";
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            this.amount.Visible = false;
            // 
            // TaxableValue
            // 
            this.TaxableValue.FillWeight = 70F;
            this.TaxableValue.HeaderText = "Taxable Value";
            this.TaxableValue.Name = "TaxableValue";
            this.TaxableValue.ReadOnly = true;
            this.TaxableValue.Visible = false;
            // 
            // CGST
            // 
            this.CGST.DataPropertyName = "CGST";
            this.CGST.HeaderText = "CGST";
            this.CGST.Name = "CGST";
            this.CGST.ReadOnly = true;
            this.CGST.Visible = false;
            // 
            // CGSTAmt
            // 
            this.CGSTAmt.HeaderText = "CGSTAmt";
            this.CGSTAmt.Name = "CGSTAmt";
            this.CGSTAmt.ReadOnly = true;
            this.CGSTAmt.Visible = false;
            // 
            // SGST
            // 
            this.SGST.DataPropertyName = "SGST";
            this.SGST.HeaderText = "SGST";
            this.SGST.Name = "SGST";
            this.SGST.ReadOnly = true;
            this.SGST.Visible = false;
            // 
            // SGSTAmt
            // 
            this.SGSTAmt.HeaderText = "SGSTAmt";
            this.SGSTAmt.Name = "SGSTAmt";
            this.SGSTAmt.ReadOnly = true;
            this.SGSTAmt.Visible = false;
            // 
            // IGST
            // 
            this.IGST.DataPropertyName = "IGST";
            this.IGST.HeaderText = "IGST";
            this.IGST.Name = "IGST";
            this.IGST.ReadOnly = true;
            this.IGST.Visible = false;
            // 
            // IGSTAmt
            // 
            this.IGSTAmt.HeaderText = "IGSTAmt";
            this.IGSTAmt.Name = "IGSTAmt";
            this.IGSTAmt.ReadOnly = true;
            this.IGSTAmt.Visible = false;
            // 
            // TotalAmt
            // 
            this.TotalAmt.DataPropertyName = "TotalAmt";
            this.TotalAmt.FillWeight = 80F;
            this.TotalAmt.HeaderText = "Total";
            this.TotalAmt.Name = "TotalAmt";
            this.TotalAmt.ReadOnly = true;
            // 
            // ravanno
            // 
            this.ravanno.DataPropertyName = "ravanno";
            this.ravanno.HeaderText = "RawannaNo";
            this.ravanno.Name = "ravanno";
            this.ravanno.ReadOnly = true;
            this.ravanno.Visible = false;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "clid";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // MetricTon
            // 
            this.MetricTon.HeaderText = "Metric Ton";
            this.MetricTon.Name = "MetricTon";
            this.MetricTon.ReadOnly = true;
            this.MetricTon.Visible = false;
            // 
            // itemid
            // 
            this.itemid.DataPropertyName = "itemid";
            this.itemid.HeaderText = "itemid";
            this.itemid.Name = "itemid";
            this.itemid.ReadOnly = true;
            this.itemid.Visible = false;
            // 
            // upid
            // 
            this.upid.HeaderText = "upid";
            this.upid.Name = "upid";
            this.upid.ReadOnly = true;
            this.upid.Visible = false;
            // 
            // Edit1
            // 
            this.Edit1.FillWeight = 50F;
            this.Edit1.HeaderText = "Edit";
            this.Edit1.Name = "Edit1";
            this.Edit1.ReadOnly = true;
            this.Edit1.Visible = false;
            // 
            // del
            // 
            this.del.FillWeight = 50F;
            this.del.HeaderText = "Delete";
            this.del.Name = "del";
            this.del.ReadOnly = true;
            this.del.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.del.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // lstPending
            // 
            this.lstPending.FormattingEnabled = true;
            this.lstPending.Location = new System.Drawing.Point(926, 74);
            this.lstPending.Name = "lstPending";
            this.lstPending.Size = new System.Drawing.Size(141, 303);
            this.lstPending.TabIndex = 34431;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(952, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 34378;
            this.label1.Text = "Pending Orders";
            // 
            // lblMainId
            // 
            this.lblMainId.AutoSize = true;
            this.lblMainId.Location = new System.Drawing.Point(841, 30);
            this.lblMainId.Name = "lblMainId";
            this.lblMainId.Size = new System.Drawing.Size(14, 13);
            this.lblMainId.TabIndex = 34432;
            this.lblMainId.Text = "0";
            this.lblMainId.Visible = false;
            // 
            // MobileBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1079, 463);
            this.Controls.Add(this.lblMainId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstPending);
            this.Controls.Add(this.btnReprint);
            this.Controls.Add(this.btndel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.txtTotalTaxAmt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txttotal);
            this.Controls.Add(this.txtTotalQty);
            this.Controls.Add(this.label50);
            this.Controls.Add(this.grdtest1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lst);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblFormHeader);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MobileBill";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MobileBill_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdtest1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFormHeader;
        private System.Windows.Forms.ComboBox drpname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMoblieNo;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtchalanno;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox lst;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grdtest1;
        private System.Windows.Forms.TextBox txtTotalQty;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox txtTotalTaxAmt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txttotal;
        private System.Windows.Forms.Button btnReprint;
        private System.Windows.Forms.Button btndel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sno;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn Barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn HSNCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount1;
        private System.Windows.Forms.DataGridViewTextBoxColumn rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxableValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn CGST;
        private System.Windows.Forms.DataGridViewTextBoxColumn CGSTAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn SGST;
        private System.Windows.Forms.DataGridViewTextBoxColumn SGSTAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn IGST;
        private System.Windows.Forms.DataGridViewTextBoxColumn IGSTAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ravanno;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn MetricTon;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemid;
        private System.Windows.Forms.DataGridViewTextBoxColumn upid;
        private System.Windows.Forms.DataGridViewLinkColumn Edit1;
        private System.Windows.Forms.DataGridViewLinkColumn del;
        private System.Windows.Forms.ListBox lstPending;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMainId;
    }
}