namespace WelcomeFabric
{
    partial class CategoryReport
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.drpCategory = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisplayOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.View = new System.Windows.Forms.DataGridViewLinkColumn();
            this.ImageName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.drpSupplier = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Category,
            this.Supplier,
            this.ItemName,
            this.Price,
            this.Unit,
            this.MaxQuantity,
            this.DisplayOrder,
            this.View,
            this.ImageName1});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv.Location = new System.Drawing.Point(0, 92);
            this.dgv.Margin = new System.Windows.Forms.Padding(4);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.Size = new System.Drawing.Size(995, 383);
            this.dgv.TabIndex = 0;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(329, 33);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 16);
            this.label7.TabIndex = 45;
            this.label7.Text = "Category";
            // 
            // drpCategory
            // 
            this.drpCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.drpCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.drpCategory.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.drpCategory.FormattingEnabled = true;
            this.drpCategory.Location = new System.Drawing.Point(254, 57);
            this.drpCategory.Margin = new System.Windows.Forms.Padding(4);
            this.drpCategory.Name = "drpCategory";
            this.drpCategory.Size = new System.Drawing.Size(233, 24);
            this.drpCategory.TabIndex = 44;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(505, 57);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 24);
            this.btnSearch.TabIndex = 46;
            this.btnSearch.Text = "Show";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(586, 57);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 24);
            this.btnReset.TabIndex = 47;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // Category
            // 
            this.Category.DataPropertyName = "CategoryName";
            this.Category.FillWeight = 150F;
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            // 
            // Supplier
            // 
            this.Supplier.DataPropertyName = "Supplier";
            this.Supplier.FillWeight = 150F;
            this.Supplier.HeaderText = "Supplier";
            this.Supplier.Name = "Supplier";
            this.Supplier.ReadOnly = true;
            // 
            // ItemName
            // 
            this.ItemName.DataPropertyName = "itemname";
            this.ItemName.FillWeight = 180F;
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "MRP";
            this.Price.FillWeight = 70F;
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // Unit
            // 
            this.Unit.DataPropertyName = "Unit";
            this.Unit.FillWeight = 50F;
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            // 
            // MaxQuantity
            // 
            this.MaxQuantity.DataPropertyName = "MaxQuantity";
            this.MaxQuantity.FillWeight = 70F;
            this.MaxQuantity.HeaderText = "Max Qty";
            this.MaxQuantity.Name = "MaxQuantity";
            this.MaxQuantity.ReadOnly = true;
            // 
            // DisplayOrder
            // 
            this.DisplayOrder.DataPropertyName = "DisplayOrder";
            this.DisplayOrder.FillWeight = 70F;
            this.DisplayOrder.HeaderText = "Display Order";
            this.DisplayOrder.Name = "DisplayOrder";
            this.DisplayOrder.ReadOnly = true;
            // 
            // View
            // 
            this.View.DataPropertyName = "View";
            this.View.FillWeight = 60F;
            this.View.HeaderText = "View";
            this.View.Name = "View";
            this.View.ReadOnly = true;
            this.View.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.View.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ImageName1
            // 
            this.ImageName1.DataPropertyName = "ImageName1";
            this.ImageName1.HeaderText = "ImageName1";
            this.ImageName1.Name = "ImageName1";
            this.ImageName1.ReadOnly = true;
            this.ImageName1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 49;
            this.label1.Text = "Supplier";
            // 
            // drpSupplier
            // 
            this.drpSupplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.drpSupplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.drpSupplier.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.drpSupplier.FormattingEnabled = true;
            this.drpSupplier.Location = new System.Drawing.Point(13, 57);
            this.drpSupplier.Margin = new System.Windows.Forms.Padding(4);
            this.drpSupplier.Name = "drpSupplier";
            this.drpSupplier.Size = new System.Drawing.Size(233, 24);
            this.drpSupplier.TabIndex = 48;
            this.drpSupplier.SelectedIndexChanged += new System.EventHandler(this.drpSupplier_SelectedIndexChanged);
            // 
            // CategoryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(995, 475);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.drpSupplier);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.drpCategory);
            this.Controls.Add(this.dgv);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CategoryReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CategoryReport";
            this.Load += new System.EventHandler(this.CategoryReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox drpCategory;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayOrder;
        private System.Windows.Forms.DataGridViewLinkColumn View;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImageName1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox drpSupplier;
    }
}