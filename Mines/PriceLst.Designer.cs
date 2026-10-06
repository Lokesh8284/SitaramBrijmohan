namespace WelcomeFabric
{
    partial class PriceLst
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PriceLst));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtsno = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpUnit = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnadd = new System.Windows.Forms.Button();
            this.txtrate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.drpitem = new System.Windows.Forms.ComboBox();
            this.drpparty = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grdtest1 = new System.Windows.Forms.DataGridView();
            this.Sn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit1 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.del = new System.Windows.Forms.DataGridViewLinkColumn();
            this.btnsave = new System.Windows.Forms.Button();
            this.lst = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdtest1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(452, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Party Wise Price";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtsno);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtpUnit);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnadd);
            this.groupBox1.Controls.Add(this.txtrate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.drpitem);
            this.groupBox1.Controls.Add(this.drpparty);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(197, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(801, 96);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Party Wise Price";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(435, 64);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Clear";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(631, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Sno";
            // 
            // txtsno
            // 
            this.txtsno.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtsno.Location = new System.Drawing.Point(671, 29);
            this.txtsno.Name = "txtsno";
            this.txtsno.ReadOnly = true;
            this.txtsno.Size = new System.Drawing.Size(100, 20);
            this.txtsno.TabIndex = 8;
            this.txtsno.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(162, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Unit";
            // 
            // dtpUnit
            // 
            this.dtpUnit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.dtpUnit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.dtpUnit.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.dtpUnit.FormattingEnabled = true;
            this.dtpUnit.Location = new System.Drawing.Point(202, 64);
            this.dtpUnit.Name = "dtpUnit";
            this.dtpUnit.Size = new System.Drawing.Size(110, 21);
            this.dtpUnit.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Rate";
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(339, 64);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(75, 23);
            this.btnadd.TabIndex = 8;
            this.btnadd.Text = "Add";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtrate
            // 
            this.txtrate.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtrate.Location = new System.Drawing.Point(76, 64);
            this.txtrate.Name = "txtrate";
            this.txtrate.Size = new System.Drawing.Size(79, 20);
            this.txtrate.TabIndex = 3;
            this.txtrate.Text = "0";
            this.txtrate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtrate_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(336, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Select Item";
            // 
            // drpitem
            // 
            this.drpitem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.drpitem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.drpitem.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.drpitem.FormattingEnabled = true;
            this.drpitem.Location = new System.Drawing.Point(399, 31);
            this.drpitem.Name = "drpitem";
            this.drpitem.Size = new System.Drawing.Size(205, 21);
            this.drpitem.TabIndex = 2;
            this.drpitem.SelectedIndexChanged += new System.EventHandler(this.drpitem_SelectedIndexChanged);
            // 
            // drpparty
            // 
            this.drpparty.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.drpparty.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.drpparty.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.drpparty.FormattingEnabled = true;
            this.drpparty.Location = new System.Drawing.Point(94, 31);
            this.drpparty.Name = "drpparty";
            this.drpparty.Size = new System.Drawing.Size(238, 21);
            this.drpparty.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Company Name";
            // 
            // grdtest1
            // 
            this.grdtest1.AllowUserToAddRows = false;
            this.grdtest1.AllowUserToDeleteRows = false;
            this.grdtest1.AllowUserToResizeColumns = false;
            this.grdtest1.AllowUserToResizeRows = false;
            this.grdtest1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdtest1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sn,
            this.id,
            this.Name,
            this.itemid,
            this.Item,
            this.Unit,
            this.rate,
            this.Edit1,
            this.del});
            this.grdtest1.Location = new System.Drawing.Point(197, 139);
            this.grdtest1.Name = "grdtest1";
            this.grdtest1.ReadOnly = true;
            this.grdtest1.RowHeadersVisible = false;
            this.grdtest1.Size = new System.Drawing.Size(801, 252);
            this.grdtest1.TabIndex = 31;
            this.grdtest1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdtest1_CellContentClick);
            // 
            // Sn
            // 
            this.Sn.HeaderText = "S.No";
            this.Sn.Name = "Sn";
            this.Sn.ReadOnly = true;
            this.Sn.Width = 50;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "clid";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // Name
            // 
            this.Name.DataPropertyName = "Name";
            this.Name.HeaderText = "PartyName";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            this.Name.Width = 150;
            // 
            // itemid
            // 
            this.itemid.DataPropertyName = "itemid";
            this.itemid.HeaderText = "itemid";
            this.itemid.Name = "itemid";
            this.itemid.ReadOnly = true;
            this.itemid.Visible = false;
            // 
            // Item
            // 
            this.Item.DataPropertyName = "Item";
            this.Item.HeaderText = "Item Name";
            this.Item.Name = "Item";
            this.Item.ReadOnly = true;
            this.Item.Width = 150;
            // 
            // Unit
            // 
            this.Unit.DataPropertyName = "Unit";
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            this.Unit.Width = 50;
            // 
            // rate
            // 
            this.rate.DataPropertyName = "price";
            this.rate.HeaderText = "Rate";
            this.rate.Name = "rate";
            this.rate.ReadOnly = true;
            // 
            // Edit1
            // 
            this.Edit1.HeaderText = "Edit";
            this.Edit1.Name = "Edit1";
            this.Edit1.ReadOnly = true;
            this.Edit1.Width = 40;
            // 
            // del
            // 
            this.del.HeaderText = "Delete";
            this.del.Name = "del";
            this.del.ReadOnly = true;
            this.del.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.del.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.del.Width = 45;
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(410, 405);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 38);
            this.btnsave.TabIndex = 10;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // lst
            // 
            this.lst.FormattingEnabled = true;
            this.lst.Location = new System.Drawing.Point(12, 34);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(163, 355);
            this.lst.TabIndex = 32;
            this.lst.Click += new System.EventHandler(this.lst_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(596, 405);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 38);
            this.button1.TabIndex = 12;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(506, 405);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 38);
            this.button3.TabIndex = 11;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // PriceLst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1010, 489);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lst);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.grdtest1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            //this.Name = "PriceLst";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Party Wise Price List";
            this.Load += new System.EventHandler(this.PriceLst_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.drpparty_KeyDown);
            this.InputLanguageChanging += new System.Windows.Forms.InputLanguageChangingEventHandler(this.PriceLst_InputLanguageChanging);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdtest1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtrate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox drpitem;
        private System.Windows.Forms.ComboBox drpparty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.DataGridView grdtest1;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.ListBox lst;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtsno;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox dtpUnit;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sn;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn rate;
        private System.Windows.Forms.DataGridViewLinkColumn Edit1;
        private System.Windows.Forms.DataGridViewLinkColumn del;
    }
}