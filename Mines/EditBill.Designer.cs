namespace WelcomeFabric
{
    partial class EditBill
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.cmbClientName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpBillDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btndelete = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvInvoice = new System.Windows.Forms.DataGridView();
            this.srno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceDetailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qnty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.txttotalAmount = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtTotalFright = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.rdovat = new System.Windows.Forms.RadioButton();
            this.txtafterdis = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.rdoPercent = new System.Windows.Forms.RadioButton();
            this.rdoFlat = new System.Windows.Forms.RadioButton();
            this.txtDisc1 = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.txtvatcal = new System.Windows.Forms.TextBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtvat = new System.Windows.Forms.TextBox();
            this.txtNetAmt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lst = new System.Windows.Forms.ListBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).BeginInit();
            this.pnlTotal.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.cmbClientName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dtpBillDate);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(300, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(927, 120);
            this.panel1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Maroon;
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(378, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(289, 48);
            this.button2.TabIndex = 10;
            this.button2.Text = "INVOICE EDIT FORM";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // cmbClientName
            // 
            this.cmbClientName.FormattingEnabled = true;
            this.cmbClientName.Location = new System.Drawing.Point(391, 83);
            this.cmbClientName.Name = "cmbClientName";
            this.cmbClientName.Size = new System.Drawing.Size(472, 22);
            this.cmbClientName.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(290, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "Client Name";
            // 
            // dtpBillDate
            // 
            this.dtpBillDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpBillDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBillDate.Location = new System.Drawing.Point(135, 83);
            this.dtpBillDate.Name = "dtpBillDate";
            this.dtpBillDate.Size = new System.Drawing.Size(127, 22);
            this.dtpBillDate.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "Bill Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(19, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(844, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "_________________________________________________________________________________" +
                "____________";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSearch.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(238, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(116, 40);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(22, 36);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(158, 22);
            this.txtSearch.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search Invoice/Bill No.";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btndelete);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.dgvInvoice);
            this.panel2.Controls.Add(this.pnlTotal);
            this.panel2.Location = new System.Drawing.Point(299, 138);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(927, 456);
            this.panel2.TabIndex = 1;
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btndelete.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelete.ForeColor = System.Drawing.Color.White;
            this.btndelete.Location = new System.Drawing.Point(706, 416);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(116, 40);
            this.btndelete.TabIndex = 34444;
            this.btndelete.Text = "DELETE";
            this.btndelete.UseVisualStyleBackColor = false;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(521, 416);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(116, 40);
            this.button3.TabIndex = 34443;
            this.button3.Text = "NEW";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(401, 416);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 40);
            this.button1.TabIndex = 34442;
            this.button1.Text = "UPDATE";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvInvoice
            // 
            this.dgvInvoice.AllowUserToAddRows = false;
            this.dgvInvoice.AllowUserToDeleteRows = false;
            this.dgvInvoice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInvoice.BackgroundColor = System.Drawing.Color.White;
            this.dgvInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.srno,
            this.InvoiceDetailID,
            this.ProductName,
            this.ProductID,
            this.Qnty,
            this.Price,
            this.TAmount});
            this.dgvInvoice.Location = new System.Drawing.Point(0, 3);
            this.dgvInvoice.Name = "dgvInvoice";
            this.dgvInvoice.RowHeadersVisible = false;
            this.dgvInvoice.Size = new System.Drawing.Size(921, 270);
            this.dgvInvoice.TabIndex = 34441;
            this.dgvInvoice.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvoice_CellValidated);
            // 
            // srno
            // 
            this.srno.HeaderText = "S.No.";
            this.srno.Name = "srno";
            // 
            // InvoiceDetailID
            // 
            this.InvoiceDetailID.HeaderText = "InvoiceDetailID";
            this.InvoiceDetailID.Name = "InvoiceDetailID";
            this.InvoiceDetailID.Visible = false;
            // 
            // ProductName
            // 
            this.ProductName.HeaderText = "Item Name";
            this.ProductName.Name = "ProductName";
            // 
            // ProductID
            // 
            this.ProductID.HeaderText = "Item ID";
            this.ProductID.Name = "ProductID";
            this.ProductID.Visible = false;
            // 
            // Qnty
            // 
            this.Qnty.HeaderText = "Qnty";
            this.Qnty.Name = "Qnty";
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            // 
            // TAmount
            // 
            this.TAmount.HeaderText = "Amount";
            this.TAmount.Name = "TAmount";
            // 
            // pnlTotal
            // 
            this.pnlTotal.Controls.Add(this.txttotalAmount);
            this.pnlTotal.Controls.Add(this.label23);
            this.pnlTotal.Controls.Add(this.txtTotalFright);
            this.pnlTotal.Controls.Add(this.label22);
            this.pnlTotal.Controls.Add(this.rdovat);
            this.pnlTotal.Controls.Add(this.txtafterdis);
            this.pnlTotal.Controls.Add(this.label15);
            this.pnlTotal.Controls.Add(this.rdoPercent);
            this.pnlTotal.Controls.Add(this.rdoFlat);
            this.pnlTotal.Controls.Add(this.txtDisc1);
            this.pnlTotal.Controls.Add(this.label31);
            this.pnlTotal.Controls.Add(this.txtvatcal);
            this.pnlTotal.Controls.Add(this.txtDiscount);
            this.pnlTotal.Controls.Add(this.txtvat);
            this.pnlTotal.Controls.Add(this.txtNetAmt);
            this.pnlTotal.Controls.Add(this.label7);
            this.pnlTotal.Controls.Add(this.txtTotal);
            this.pnlTotal.Controls.Add(this.label8);
            this.pnlTotal.Location = new System.Drawing.Point(3, 279);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Size = new System.Drawing.Size(921, 124);
            this.pnlTotal.TabIndex = 34428;
            // 
            // txttotalAmount
            // 
            this.txttotalAmount.BackColor = System.Drawing.Color.White;
            this.txttotalAmount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttotalAmount.Location = new System.Drawing.Point(790, 86);
            this.txttotalAmount.Name = "txttotalAmount";
            this.txttotalAmount.Size = new System.Drawing.Size(117, 21);
            this.txttotalAmount.TabIndex = 34433;
            this.txttotalAmount.Leave += new System.EventHandler(this.txtTotal_Leave);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(658, 89);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(87, 13);
            this.label23.TabIndex = 34440;
            this.label23.Text = "Grand Total ";
            // 
            // txtTotalFright
            // 
            this.txtTotalFright.BackColor = System.Drawing.Color.White;
            this.txtTotalFright.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalFright.Location = new System.Drawing.Point(791, 40);
            this.txtTotalFright.Name = "txtTotalFright";
            this.txtTotalFright.Size = new System.Drawing.Size(117, 21);
            this.txtTotalFright.TabIndex = 34431;
            this.txtTotalFright.Leave += new System.EventHandler(this.txtTotal_Leave);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(658, 44);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(91, 13);
            this.label22.TabIndex = 34439;
            this.label22.Text = "Total Freight";
            // 
            // rdovat
            // 
            this.rdovat.AutoSize = true;
            this.rdovat.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdovat.Location = new System.Drawing.Point(661, 18);
            this.rdovat.Name = "rdovat";
            this.rdovat.Size = new System.Drawing.Size(61, 17);
            this.rdovat.TabIndex = 34438;
            this.rdovat.TabStop = true;
            this.rdovat.Text = "GST@";
            this.rdovat.UseVisualStyleBackColor = true;
            // 
            // txtafterdis
            // 
            this.txtafterdis.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtafterdis.Location = new System.Drawing.Point(518, 63);
            this.txtafterdis.Name = "txtafterdis";
            this.txtafterdis.ReadOnly = true;
            this.txtafterdis.Size = new System.Drawing.Size(116, 21);
            this.txtafterdis.TabIndex = 34428;
            this.txtafterdis.Text = "0";
            this.txtafterdis.Leave += new System.EventHandler(this.txtTotal_Leave);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(418, 66);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 13);
            this.label15.TabIndex = 34437;
            this.label15.Text = "After Discount";
            // 
            // rdoPercent
            // 
            this.rdoPercent.AutoSize = true;
            this.rdoPercent.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoPercent.Location = new System.Drawing.Point(439, 42);
            this.rdoPercent.Name = "rdoPercent";
            this.rdoPercent.Size = new System.Drawing.Size(75, 17);
            this.rdoPercent.TabIndex = 34426;
            this.rdoPercent.TabStop = true;
            this.rdoPercent.Text = "Percent";
            this.rdoPercent.UseVisualStyleBackColor = true;
            // 
            // rdoFlat
            // 
            this.rdoFlat.AutoSize = true;
            this.rdoFlat.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoFlat.Location = new System.Drawing.Point(388, 42);
            this.rdoFlat.Name = "rdoFlat";
            this.rdoFlat.Size = new System.Drawing.Size(50, 17);
            this.rdoFlat.TabIndex = 34425;
            this.rdoFlat.TabStop = true;
            this.rdoFlat.Text = "Flat";
            this.rdoFlat.UseVisualStyleBackColor = true;
            // 
            // txtDisc1
            // 
            this.txtDisc1.BackColor = System.Drawing.Color.White;
            this.txtDisc1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisc1.Location = new System.Drawing.Point(306, 40);
            this.txtDisc1.Name = "txtDisc1";
            this.txtDisc1.Size = new System.Drawing.Size(68, 21);
            this.txtDisc1.TabIndex = 34424;
            this.txtDisc1.Text = "0";
            this.txtDisc1.Leave += new System.EventHandler(this.txtTotal_Leave);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(232, 44);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(63, 13);
            this.label31.TabIndex = 34436;
            this.label31.Text = "Discount";
            // 
            // txtvatcal
            // 
            this.txtvatcal.BackColor = System.Drawing.Color.White;
            this.txtvatcal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtvatcal.Location = new System.Drawing.Point(791, 16);
            this.txtvatcal.Name = "txtvatcal";
            this.txtvatcal.Size = new System.Drawing.Size(116, 21);
            this.txtvatcal.TabIndex = 34430;
            this.txtvatcal.Text = "0";
            this.txtvatcal.Leave += new System.EventHandler(this.txtTotal_Leave);
            // 
            // txtDiscount
            // 
            this.txtDiscount.BackColor = System.Drawing.Color.White;
            this.txtDiscount.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.Location = new System.Drawing.Point(518, 40);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(116, 21);
            this.txtDiscount.TabIndex = 34427;
            this.txtDiscount.Text = "0";
            this.txtDiscount.Leave += new System.EventHandler(this.txtTotal_Leave);
            // 
            // txtvat
            // 
            this.txtvat.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtvat.Location = new System.Drawing.Point(740, 16);
            this.txtvat.Name = "txtvat";
            this.txtvat.Size = new System.Drawing.Size(44, 21);
            this.txtvat.TabIndex = 34429;
            this.txtvat.Text = "5";
            this.txtvat.Leave += new System.EventHandler(this.txtTotal_Leave);
            // 
            // txtNetAmt
            // 
            this.txtNetAmt.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNetAmt.Location = new System.Drawing.Point(791, 63);
            this.txtNetAmt.Name = "txtNetAmt";
            this.txtNetAmt.ReadOnly = true;
            this.txtNetAmt.Size = new System.Drawing.Size(116, 21);
            this.txtNetAmt.TabIndex = 34432;
            this.txtNetAmt.Leave += new System.EventHandler(this.txtTotal_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(658, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 34435;
            this.label7.Text = "Net Amount";
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(518, 16);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(116, 21);
            this.txtTotal.TabIndex = 34423;
            this.txtTotal.Text = "0";
            this.txtTotal.Leave += new System.EventHandler(this.txtTotal_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(424, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 13);
            this.label8.TabIndex = 34434;
            this.label8.Text = "Total Amount";
            // 
            // lst
            // 
            this.lst.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst.FormattingEnabled = true;
            this.lst.ItemHeight = 12;
            this.lst.Location = new System.Drawing.Point(22, 69);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(258, 520);
            this.lst.TabIndex = 34378;
            this.lst.Click += new System.EventHandler(this.lst_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(163, 35);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(117, 23);
            this.button6.TabIndex = 34393;
            this.button6.Text = "Search";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(135, 15);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(22, 14);
            this.label24.TabIndex = 34394;
            this.label24.Text = "To";
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd/MM/yyyy";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(163, 12);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(117, 22);
            this.dtpTo.TabIndex = 34396;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(12, 12);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(117, 22);
            this.dtpFrom.TabIndex = 34395;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(12, 36);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(117, 22);
            this.textBox2.TabIndex = 34392;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(9, 18);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(87, 14);
            this.label19.TabIndex = 34391;
            this.label19.Text = "Rawanna No";
            this.label19.Visible = false;
            // 
            // EditBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1239, 606);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.lst);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "EditBill";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.EditBill_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).EndInit();
            this.pnlTotal.ResumeLayout(false);
            this.pnlTotal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpBillDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbClientName;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.TextBox txttotalAmount;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtTotalFright;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.RadioButton rdovat;
        private System.Windows.Forms.TextBox txtafterdis;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RadioButton rdoPercent;
        private System.Windows.Forms.RadioButton rdoFlat;
        private System.Windows.Forms.TextBox txtDisc1;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox txtvatcal;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox txtvat;
        private System.Windows.Forms.TextBox txtNetAmt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvInvoice;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn srno;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceDetailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qnty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn TAmount;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.ListBox lst;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label19;
    }
}