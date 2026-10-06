namespace WelcomeFabric
{
    partial class SaleReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaleReport));
            this.label47 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.drpPatientId = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.drpbrand = new System.Windows.Forms.ComboBox();
            this.drpcreate = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.grdTest = new System.Windows.Forms.DataGridView();
            this.sno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.na = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Billnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Labour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ravanano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotAmt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txttotwt = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTest)).BeginInit();
            this.SuspendLayout();
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(14, 22);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(67, 13);
            this.label47.TabIndex = 30;
            this.label47.Text = "Client Name:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(348, 91);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(360, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 23);
            this.label1.TabIndex = 42;
            this.label1.Text = "Sale Report";
            // 
            // drpPatientId
            // 
            this.drpPatientId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.drpPatientId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.drpPatientId.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.drpPatientId.FormattingEnabled = true;
            this.drpPatientId.Location = new System.Drawing.Point(92, 19);
            this.drpPatientId.Name = "drpPatientId";
            this.drpPatientId.Size = new System.Drawing.Size(282, 21);
            this.drpPatientId.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.drpbrand);
            this.groupBox1.Controls.Add(this.drpcreate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.drpPatientId);
            this.groupBox1.Controls.Add(this.label47);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(97, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(790, 131);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Option";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(577, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 43;
            this.label7.Text = "Item:";
            // 
            // drpbrand
            // 
            this.drpbrand.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.drpbrand.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.drpbrand.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.drpbrand.FormattingEnabled = true;
            this.drpbrand.Location = new System.Drawing.Point(614, 19);
            this.drpbrand.Name = "drpbrand";
            this.drpbrand.Size = new System.Drawing.Size(176, 21);
            this.drpbrand.TabIndex = 42;
            // 
            // drpcreate
            // 
            this.drpcreate.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.drpcreate.FormattingEnabled = true;
            this.drpcreate.Items.AddRange(new object[] {
            "Confirm",
            "Not Confirm"});
            this.drpcreate.Location = new System.Drawing.Point(454, 18);
            this.drpcreate.Name = "drpcreate";
            this.drpcreate.Size = new System.Drawing.Size(121, 21);
            this.drpcreate.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(390, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Create Bill:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(267, 91);
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
            this.dateTimePicker2.Location = new System.Drawing.Point(357, 55);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.ShowCheckBox = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(121, 20);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(303, 59);
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
            this.dateTimePicker1.Location = new System.Drawing.Point(164, 55);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowCheckBox = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(121, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Date Between  ";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(385, 429);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 41;
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
            this.sno,
            this.Date,
            this.na,
            this.Billnumber,
            this.ClientName,
            this.Labour,
            this.itemname,
            this.qty,
            this.price,
            this.amount,
            this.Address,
            this.TotAmount,
            this.ravanano});
            this.grdTest.Location = new System.Drawing.Point(12, 189);
            this.grdTest.Name = "grdTest";
            this.grdTest.ReadOnly = true;
            this.grdTest.RowHeadersVisible = false;
            this.grdTest.Size = new System.Drawing.Size(919, 211);
            this.grdTest.TabIndex = 39;
            this.grdTest.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdTest_CellContentClick);
            // 
            // sno
            // 
            this.sno.DataPropertyName = "sno";
            this.sno.HeaderText = "sno";
            this.sno.Name = "sno";
            this.sno.ReadOnly = true;
            this.sno.Width = 50;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Dat";
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 80;
            // 
            // na
            // 
            this.na.DataPropertyName = "Client_ID";
            this.na.HeaderText = "Client ID";
            this.na.Name = "na";
            this.na.ReadOnly = true;
            this.na.Visible = false;
            // 
            // Billnumber
            // 
            this.Billnumber.DataPropertyName = "BillNo";
            this.Billnumber.FillWeight = 70F;
            this.Billnumber.HeaderText = "ChallanNo";
            this.Billnumber.Name = "Billnumber";
            this.Billnumber.ReadOnly = true;
            // 
            // ClientName
            // 
            this.ClientName.DataPropertyName = "Name";
            this.ClientName.HeaderText = "Client Name";
            this.ClientName.Name = "ClientName";
            this.ClientName.ReadOnly = true;
            this.ClientName.Width = 130;
            // 
            // Labour
            // 
            this.Labour.HeaderText = "Labour";
            this.Labour.Name = "Labour";
            this.Labour.ReadOnly = true;
            this.Labour.Width = 120;
            // 
            // itemname
            // 
            this.itemname.DataPropertyName = "itemname";
            this.itemname.HeaderText = "ItemName";
            this.itemname.Name = "itemname";
            this.itemname.ReadOnly = true;
            // 
            // qty
            // 
            this.qty.DataPropertyName = "qty";
            this.qty.HeaderText = "Qty";
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            this.qty.Width = 70;
            // 
            // price
            // 
            this.price.DataPropertyName = "price";
            this.price.HeaderText = "Rate";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            this.price.Width = 70;
            // 
            // amount
            // 
            this.amount.DataPropertyName = "amount";
            this.amount.HeaderText = "Amount";
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            this.amount.Width = 90;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            this.Address.Visible = false;
            // 
            // TotAmount
            // 
            this.TotAmount.DataPropertyName = "TotAmount";
            this.TotAmount.HeaderText = "Total Amt";
            this.TotAmount.Name = "TotAmount";
            this.TotAmount.ReadOnly = true;
            // 
            // ravanano
            // 
            this.ravanano.DataPropertyName = "ravanano";
            this.ravanano.FillWeight = 70F;
            this.ravanano.HeaderText = "Ravana No.";
            this.ravanano.Name = "ravanano";
            this.ravanano.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(684, 409);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Total Billing Amount : ";
            // 
            // txtTotAmt
            // 
            this.txtTotAmt.Location = new System.Drawing.Point(799, 402);
            this.txtTotAmt.Name = "txtTotAmt";
            this.txtTotAmt.ReadOnly = true;
            this.txtTotAmt.Size = new System.Drawing.Size(127, 20);
            this.txtTotAmt.TabIndex = 40;
            this.txtTotAmt.Text = "0.00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(503, 413);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 45;
            this.label6.Text = "Total Wt.";
            // 
            // txttotwt
            // 
            this.txttotwt.Location = new System.Drawing.Point(560, 406);
            this.txttotwt.Name = "txttotwt";
            this.txttotwt.ReadOnly = true;
            this.txttotwt.Size = new System.Drawing.Size(127, 20);
            this.txttotwt.TabIndex = 44;
            this.txttotwt.Text = "0.00";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Stencil", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label19.Location = new System.Drawing.Point(12, 9);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(20, 19);
            this.label19.TabIndex = 34415;
            this.label19.Text = "d";
            // 
            // SaleReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(943, 466);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txttotwt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.grdTest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTotAmt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "SaleReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sale Report";
            this.Load += new System.EventHandler(this.ChallanDetailReport_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.drpPatientId_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox drpPatientId;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView grdTest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotAmt;
        private System.Windows.Forms.ComboBox drpcreate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txttotwt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox drpbrand;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DataGridViewTextBoxColumn sno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn na;
        private System.Windows.Forms.DataGridViewTextBoxColumn Billnumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Labour;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemname;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ravanano;
    }
}