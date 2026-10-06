namespace WelcomeFabric
{
    partial class StockReport
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnPrint = new System.Windows.Forms.Button();
            this.BtnReset = new System.Windows.Forms.Button();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.drpSupplier = new System.Windows.Forms.ComboBox();
            this.drpitem = new System.Windows.Forms.ComboBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.SNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Opening = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Purchase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnWhatsapp = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.BtnPrint);
            this.groupBox1.Controls.Add(this.BtnReset);
            this.groupBox1.Controls.Add(this.BtnSearch);
            this.groupBox1.Controls.Add(this.dtpFrom);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.drpSupplier);
            this.groupBox1.Controls.Add(this.drpitem);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1032, 120);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // BtnPrint
            // 
            this.BtnPrint.Location = new System.Drawing.Point(928, 46);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(75, 23);
            this.BtnPrint.TabIndex = 5;
            this.BtnPrint.Text = "Print";
            this.BtnPrint.UseVisualStyleBackColor = true;
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // BtnReset
            // 
            this.BtnReset.Location = new System.Drawing.Point(847, 46);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(75, 23);
            this.BtnReset.TabIndex = 4;
            this.BtnReset.Text = "Reset";
            this.BtnReset.UseVisualStyleBackColor = true;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(766, 46);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 3;
            this.BtnSearch.Text = "Search";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(588, 46);
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.ShowCheckBox = true;
            this.dtpFrom.Size = new System.Drawing.Size(145, 23);
            this.dtpFrom.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(597, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Stock As On";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Supplier";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(323, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Item Name";
            // 
            // drpSupplier
            // 
            this.drpSupplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.drpSupplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.drpSupplier.FormattingEnabled = true;
            this.drpSupplier.Location = new System.Drawing.Point(13, 48);
            this.drpSupplier.Margin = new System.Windows.Forms.Padding(4);
            this.drpSupplier.Name = "drpSupplier";
            this.drpSupplier.Size = new System.Drawing.Size(248, 24);
            this.drpSupplier.TabIndex = 0;
            // 
            // drpitem
            // 
            this.drpitem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.drpitem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.drpitem.FormattingEnabled = true;
            this.drpitem.Location = new System.Drawing.Point(269, 48);
            this.drpitem.Margin = new System.Windows.Forms.Padding(4);
            this.drpitem.Name = "drpitem";
            this.drpitem.Size = new System.Drawing.Size(297, 24);
            this.drpitem.TabIndex = 0;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SNO,
            this.Supplier,
            this.ItemName,
            this.Unit,
            this.Opening,
            this.Purchase,
            this.PR,
            this.Sale,
            this.SR,
            this.stock,
            this.Date});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgv.Location = new System.Drawing.Point(0, 120);
            this.dgv.Margin = new System.Windows.Forms.Padding(4);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.Size = new System.Drawing.Size(1032, 420);
            this.dgv.TabIndex = 1;
            // 
            // SNO
            // 
            this.SNO.DataPropertyName = "SNO";
            this.SNO.FillWeight = 20F;
            this.SNO.HeaderText = "S No";
            this.SNO.Name = "SNO";
            this.SNO.ReadOnly = true;
            // 
            // Supplier
            // 
            this.Supplier.DataPropertyName = "Supplier";
            this.Supplier.HeaderText = "Supplier";
            this.Supplier.Name = "Supplier";
            this.Supplier.ReadOnly = true;
            // 
            // ItemName
            // 
            this.ItemName.DataPropertyName = "ItemName";
            this.ItemName.FillWeight = 92.978F;
            this.ItemName.HeaderText = "ItemName";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            // 
            // Unit
            // 
            this.Unit.DataPropertyName = "Unit";
            this.Unit.FillWeight = 40F;
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            // 
            // Opening
            // 
            this.Opening.DataPropertyName = "Opening";
            this.Opening.FillWeight = 40F;
            this.Opening.HeaderText = "Opening";
            this.Opening.Name = "Opening";
            this.Opening.ReadOnly = true;
            // 
            // Purchase
            // 
            this.Purchase.DataPropertyName = "Purchase";
            this.Purchase.FillWeight = 40F;
            this.Purchase.HeaderText = "Purchase";
            this.Purchase.Name = "Purchase";
            this.Purchase.ReadOnly = true;
            // 
            // PR
            // 
            this.PR.DataPropertyName = "PR";
            this.PR.FillWeight = 40F;
            this.PR.HeaderText = "Purchase Return";
            this.PR.Name = "PR";
            this.PR.ReadOnly = true;
            // 
            // Sale
            // 
            this.Sale.DataPropertyName = "Sale";
            this.Sale.FillWeight = 40F;
            this.Sale.HeaderText = "Sale";
            this.Sale.Name = "Sale";
            this.Sale.ReadOnly = true;
            // 
            // SR
            // 
            this.SR.DataPropertyName = "SR";
            this.SR.FillWeight = 40F;
            this.SR.HeaderText = "Sale Return";
            this.SR.Name = "SR";
            this.SR.ReadOnly = true;
            // 
            // stock
            // 
            this.stock.DataPropertyName = "stock";
            this.stock.FillWeight = 40F;
            this.stock.HeaderText = "stock";
            this.stock.Name = "stock";
            this.stock.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(770, 550);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Total Stock Qty";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(894, 547);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(126, 23);
            this.txtTotal.TabIndex = 3;
            // 
            // btnWhatsapp
            // 
            this.btnWhatsapp.Location = new System.Drawing.Point(428, 550);
            this.btnWhatsapp.Name = "btnWhatsapp";
            this.btnWhatsapp.Size = new System.Drawing.Size(75, 23);
            this.btnWhatsapp.TabIndex = 6;
            this.btnWhatsapp.Text = "Whatsapp";
            this.btnWhatsapp.UseVisualStyleBackColor = true;
            this.btnWhatsapp.Click += new System.EventHandler(this.btnWhatsapp_Click);
            // 
            // StockReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 603);
            this.Controls.Add(this.btnWhatsapp);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "StockReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StockReport";
            this.Load += new System.EventHandler(this.StockReport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox drpitem;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Button BtnPrint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox drpSupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn SNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Opening;
        private System.Windows.Forms.DataGridViewTextBoxColumn Purchase;
        private System.Windows.Forms.DataGridViewTextBoxColumn PR;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sale;
        private System.Windows.Forms.DataGridViewTextBoxColumn SR;
        private System.Windows.Forms.DataGridViewTextBoxColumn stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.Button btnWhatsapp;
    }
}