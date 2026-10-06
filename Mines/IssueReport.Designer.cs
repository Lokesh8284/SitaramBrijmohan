namespace WelcomeFabric
{
    partial class IssueReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IssueReport));
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTest)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(602, 31);
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
            this.label1.Size = new System.Drawing.Size(148, 23);
            this.label1.TabIndex = 42;
            this.label1.Text = "Issue Report";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(97, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(790, 77);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Option";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(521, 31);
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
            this.dateTimePicker2.Location = new System.Drawing.Point(363, 32);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.ShowCheckBox = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(121, 20);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(309, 36);
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
            this.dateTimePicker1.Location = new System.Drawing.Point(170, 32);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowCheckBox = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(121, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 36);
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
            this.grdTest.Location = new System.Drawing.Point(97, 149);
            this.grdTest.Name = "grdTest";
            this.grdTest.ReadOnly = true;
            this.grdTest.RowHeadersVisible = false;
            this.grdTest.Size = new System.Drawing.Size(790, 211);
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
            this.Billnumber.Visible = false;
            // 
            // ClientName
            // 
            this.ClientName.DataPropertyName = "Name";
            this.ClientName.HeaderText = "Client Name";
            this.ClientName.Name = "ClientName";
            this.ClientName.ReadOnly = true;
            this.ClientName.Visible = false;
            this.ClientName.Width = 130;
            // 
            // Labour
            // 
            this.Labour.HeaderText = "Labour";
            this.Labour.Name = "Labour";
            this.Labour.ReadOnly = true;
            this.Labour.Visible = false;
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
            this.price.Visible = false;
            this.price.Width = 70;
            // 
            // amount
            // 
            this.amount.DataPropertyName = "amount";
            this.amount.HeaderText = "Amount";
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            this.amount.Visible = false;
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
            this.TotAmount.Visible = false;
            // 
            // ravanano
            // 
            this.ravanano.DataPropertyName = "ravanano";
            this.ravanano.FillWeight = 70F;
            this.ravanano.HeaderText = "Ravana No.";
            this.ravanano.Name = "ravanano";
            this.ravanano.ReadOnly = true;
            this.ravanano.Visible = false;
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
            // IssueReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(943, 466);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.grdTest);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "IssueReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Issue Report";
            this.Load += new System.EventHandler(this.ChallanDetailReport_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.drpPatientId_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView grdTest;
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