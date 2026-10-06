namespace WelcomeFabric
{
    partial class ItemReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemReport));
            this.label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.drpitem1 = new System.Windows.Forms.ComboBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.grdTest = new System.Windows.Forms.DataGridView();
            this.sno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxableValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CGST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SGST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IGST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTaxable = new System.Windows.Forms.TextBox();
            this.txtCGST = new System.Windows.Forms.TextBox();
            this.txtSGST = new System.Windows.Forms.TextBox();
            this.txtIGST = new System.Windows.Forms.TextBox();
            this.txtNetTotal = new System.Windows.Forms.TextBox();
            this.txtTotalQty = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTest)).BeginInit();
            this.SuspendLayout();
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Stencil", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label19.Location = new System.Drawing.Point(14, 9);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(20, 19);
            this.label19.TabIndex = 34415;
            this.label19.Text = "d";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(495, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 23);
            this.label1.TabIndex = 42;
            this.label1.Text = "Item Sale Report";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.drpitem1);
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(14, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1146, 61);
            this.groupBox1.TabIndex = 34416;
            this.groupBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 34378;
            this.label7.Text = "Item Name";
            // 
            // drpitem1
            // 
            this.drpitem1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.drpitem1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.drpitem1.BackColor = System.Drawing.Color.White;
            this.drpitem1.FormattingEnabled = true;
            this.drpitem1.Location = new System.Drawing.Point(112, 25);
            this.drpitem1.Name = "drpitem1";
            this.drpitem1.Size = new System.Drawing.Size(297, 21);
            this.drpitem1.TabIndex = 34375;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(1036, 25);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(87, 23);
            this.btnPrint.TabIndex = 41;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(941, 25);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(847, 25);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 23);
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
            this.dateTimePicker2.Location = new System.Drawing.Point(671, 25);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.ShowCheckBox = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(140, 21);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(640, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "To";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Checked = false;
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(475, 25);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowCheckBox = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(140, 21);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(433, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "From";
            // 
            // grdTest
            // 
            this.grdTest.AllowUserToAddRows = false;
            this.grdTest.AllowUserToDeleteRows = false;
            this.grdTest.AllowUserToResizeColumns = false;
            this.grdTest.AllowUserToResizeRows = false;
            this.grdTest.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdTest.ColumnHeadersHeight = 26;
            this.grdTest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sno,
            this.Date,
            this.Item,
            this.Rate,
            this.qty,
            this.TaxableValue,
            this.CGST,
            this.SGST,
            this.IGST,
            this.NetTotal});
            this.grdTest.Location = new System.Drawing.Point(14, 114);
            this.grdTest.Name = "grdTest";
            this.grdTest.ReadOnly = true;
            this.grdTest.RowHeadersVisible = false;
            this.grdTest.Size = new System.Drawing.Size(1146, 411);
            this.grdTest.TabIndex = 34417;
            // 
            // sno
            // 
            this.sno.DataPropertyName = "SNo";
            this.sno.FillWeight = 40F;
            this.sno.HeaderText = "S No";
            this.sno.Name = "sno";
            this.sno.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.FillWeight = 70F;
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // Item
            // 
            this.Item.DataPropertyName = "itemname";
            this.Item.HeaderText = "Item";
            this.Item.Name = "Item";
            this.Item.ReadOnly = true;
            // 
            // Rate
            // 
            this.Rate.DataPropertyName = "price";
            this.Rate.FillWeight = 60F;
            this.Rate.HeaderText = "Rate";
            this.Rate.Name = "Rate";
            this.Rate.ReadOnly = true;
            // 
            // qty
            // 
            this.qty.DataPropertyName = "qty";
            this.qty.FillWeight = 60F;
            this.qty.HeaderText = "Quantity";
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            // 
            // TaxableValue
            // 
            this.TaxableValue.DataPropertyName = "TaxableValue";
            this.TaxableValue.FillWeight = 70F;
            this.TaxableValue.HeaderText = "Taxable Value";
            this.TaxableValue.Name = "TaxableValue";
            this.TaxableValue.ReadOnly = true;
            // 
            // CGST
            // 
            this.CGST.DataPropertyName = "CGSTAmount";
            this.CGST.FillWeight = 70F;
            this.CGST.HeaderText = "CGST";
            this.CGST.Name = "CGST";
            this.CGST.ReadOnly = true;
            // 
            // SGST
            // 
            this.SGST.DataPropertyName = "CGSTAmount";
            this.SGST.FillWeight = 70F;
            this.SGST.HeaderText = "SGST";
            this.SGST.Name = "SGST";
            this.SGST.ReadOnly = true;
            // 
            // IGST
            // 
            this.IGST.DataPropertyName = "IGSTAmount";
            this.IGST.FillWeight = 70F;
            this.IGST.HeaderText = "IGST";
            this.IGST.Name = "IGST";
            this.IGST.ReadOnly = true;
            // 
            // NetTotal
            // 
            this.NetTotal.DataPropertyName = "GrossTotal";
            this.NetTotal.FillWeight = 70F;
            this.NetTotal.HeaderText = "Net Total";
            this.NetTotal.Name = "NetTotal";
            this.NetTotal.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(313, 536);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 34418;
            this.label2.Text = "Total";
            // 
            // txtTaxable
            // 
            this.txtTaxable.Location = new System.Drawing.Point(553, 533);
            this.txtTaxable.Name = "txtTaxable";
            this.txtTaxable.Size = new System.Drawing.Size(116, 21);
            this.txtTaxable.TabIndex = 34419;
            // 
            // txtCGST
            // 
            this.txtCGST.Location = new System.Drawing.Point(675, 533);
            this.txtCGST.Name = "txtCGST";
            this.txtCGST.Size = new System.Drawing.Size(116, 21);
            this.txtCGST.TabIndex = 34420;
            // 
            // txtSGST
            // 
            this.txtSGST.Location = new System.Drawing.Point(797, 533);
            this.txtSGST.Name = "txtSGST";
            this.txtSGST.Size = new System.Drawing.Size(116, 21);
            this.txtSGST.TabIndex = 34421;
            // 
            // txtIGST
            // 
            this.txtIGST.Location = new System.Drawing.Point(919, 533);
            this.txtIGST.Name = "txtIGST";
            this.txtIGST.Size = new System.Drawing.Size(116, 21);
            this.txtIGST.TabIndex = 34420;
            // 
            // txtNetTotal
            // 
            this.txtNetTotal.Location = new System.Drawing.Point(1041, 533);
            this.txtNetTotal.Name = "txtNetTotal";
            this.txtNetTotal.Size = new System.Drawing.Size(116, 21);
            this.txtNetTotal.TabIndex = 34421;
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.Location = new System.Drawing.Point(431, 533);
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.Size = new System.Drawing.Size(116, 21);
            this.txtTotalQty.TabIndex = 34419;
            // 
            // ItemReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1184, 566);
            this.Controls.Add(this.txtNetTotal);
            this.Controls.Add(this.txtSGST);
            this.Controls.Add(this.txtIGST);
            this.Controls.Add(this.txtCGST);
            this.Controls.Add(this.txtTotalQty);
            this.Controls.Add(this.txtTaxable);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grdTest);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "ItemReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item Report";
            this.Load += new System.EventHandler(this.ChallanDetailReport_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.drpPatientId_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox drpitem1;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView grdTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn sno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxableValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn CGST;
        private System.Windows.Forms.DataGridViewTextBoxColumn SGST;
        private System.Windows.Forms.DataGridViewTextBoxColumn IGST;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTaxable;
        private System.Windows.Forms.TextBox txtCGST;
        private System.Windows.Forms.TextBox txtSGST;
        private System.Windows.Forms.TextBox txtIGST;
        private System.Windows.Forms.TextBox txtNetTotal;
        private System.Windows.Forms.TextBox txtTotalQty;
    }
}