namespace WelcomeFabric
{
    partial class Process
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Process));
            this.label1 = new System.Windows.Forms.Label();
            this.txtchalanno = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpUnit = new System.Windows.Forms.ComboBox();
            this.txtqty = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.drpitem = new System.Windows.Forms.ComboBox();
            this.grdtest1 = new System.Windows.Forms.DataGridView();
            this.Sno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit1 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.del = new System.Windows.Forms.DataGridViewLinkColumn();
            this.lst = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.btndel = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdtest1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label1.Location = new System.Drawing.Point(543, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 23);
            this.label1.TabIndex = 34344;
            this.label1.Text = "Process Entry";
            // 
            // txtchalanno
            // 
            this.txtchalanno.BackColor = System.Drawing.Color.White;
            this.txtchalanno.Location = new System.Drawing.Point(893, 59);
            this.txtchalanno.Name = "txtchalanno";
            this.txtchalanno.Size = new System.Drawing.Size(100, 20);
            this.txtchalanno.TabIndex = 34354;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(895, 87);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(101, 20);
            this.dateTimePicker1.TabIndex = 34353;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(830, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 34352;
            this.label3.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(830, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 34351;
            this.label2.Text = "Sr No";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.dtpUnit);
            this.groupBox3.Controls.Add(this.txtqty);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.btnadd);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.drpitem);
            this.groupBox3.Location = new System.Drawing.Point(259, 111);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(762, 66);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(365, 35);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 34370;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(374, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 34369;
            this.label4.Text = "Receive Item";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(304, 18);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 13);
            this.label14.TabIndex = 34368;
            this.label14.Text = "Unit";
            // 
            // dtpUnit
            // 
            this.dtpUnit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.dtpUnit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.dtpUnit.BackColor = System.Drawing.Color.White;
            this.dtpUnit.FormattingEnabled = true;
            this.dtpUnit.Items.AddRange(new object[] {
            "Select",
            "CFT",
            "TON"});
            this.dtpUnit.Location = new System.Drawing.Point(275, 36);
            this.dtpUnit.Name = "dtpUnit";
            this.dtpUnit.Size = new System.Drawing.Size(74, 21);
            this.dtpUnit.TabIndex = 34367;
            // 
            // txtqty
            // 
            this.txtqty.BackColor = System.Drawing.Color.White;
            this.txtqty.Location = new System.Drawing.Point(163, 35);
            this.txtqty.Name = "txtqty";
            this.txtqty.Size = new System.Drawing.Size(84, 20);
            this.txtqty.TabIndex = 3;
            this.txtqty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtqty_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(195, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 13);
            this.label8.TabIndex = 34362;
            this.label8.Text = "Qty";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(683, 34);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(48, 23);
            this.button3.TabIndex = 34359;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(625, 34);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(45, 23);
            this.btnadd.TabIndex = 7;
            this.btnadd.Text = "Add";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnitemadd_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(31, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(55, 13);
            this.label16.TabIndex = 8;
            this.label16.Text = "Issue Item";
            // 
            // drpitem
            // 
            this.drpitem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.drpitem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.drpitem.BackColor = System.Drawing.Color.White;
            this.drpitem.FormattingEnabled = true;
            this.drpitem.Location = new System.Drawing.Point(19, 35);
            this.drpitem.Name = "drpitem";
            this.drpitem.Size = new System.Drawing.Size(137, 21);
            this.drpitem.TabIndex = 2;
            this.drpitem.SelectedIndexChanged += new System.EventHandler(this.drpitem_SelectedIndexChanged);
            // 
            // grdtest1
            // 
            this.grdtest1.AllowUserToAddRows = false;
            this.grdtest1.AllowUserToDeleteRows = false;
            this.grdtest1.AllowUserToResizeColumns = false;
            this.grdtest1.AllowUserToResizeRows = false;
            this.grdtest1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdtest1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sno,
            this.id,
            this.itemid,
            this.Item,
            this.qty,
            this.Unit,
            this.Edit1,
            this.del});
            this.grdtest1.Location = new System.Drawing.Point(259, 188);
            this.grdtest1.Name = "grdtest1";
            this.grdtest1.ReadOnly = true;
            this.grdtest1.RowHeadersVisible = false;
            this.grdtest1.Size = new System.Drawing.Size(762, 252);
            this.grdtest1.TabIndex = 34356;
            this.grdtest1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdtest1_CellContentClick);
            // 
            // Sno
            // 
            this.Sno.DataPropertyName = "sno";
            this.Sno.HeaderText = "S.No";
            this.Sno.Name = "Sno";
            this.Sno.ReadOnly = true;
            this.Sno.Width = 50;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "clid";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
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
            this.Item.HeaderText = "Goods";
            this.Item.Name = "Item";
            this.Item.ReadOnly = true;
            this.Item.Width = 150;
            // 
            // qty
            // 
            this.qty.DataPropertyName = "qty";
            this.qty.HeaderText = "Qty";
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            // 
            // Unit
            // 
            this.Unit.DataPropertyName = "Unit";
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            this.Unit.Width = 50;
            // 
            // Edit1
            // 
            this.Edit1.HeaderText = "Edit";
            this.Edit1.Name = "Edit1";
            this.Edit1.ReadOnly = true;
            this.Edit1.Width = 70;
            // 
            // del
            // 
            this.del.HeaderText = "Delete";
            this.del.Name = "del";
            this.del.ReadOnly = true;
            this.del.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.del.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.del.Width = 70;
            // 
            // lst
            // 
            this.lst.FormattingEnabled = true;
            this.lst.Location = new System.Drawing.Point(2, 71);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(230, 511);
            this.lst.TabIndex = 34364;
            this.lst.SelectedIndexChanged += new System.EventHandler(this.lst_SelectedIndexChanged);
            this.lst.Click += new System.EventHandler(this.lst_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(533, 465);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(623, 465);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(437, 465);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 8;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btndel
            // 
            this.btndel.Location = new System.Drawing.Point(704, 465);
            this.btndel.Name = "btndel";
            this.btndel.Size = new System.Drawing.Size(75, 23);
            this.btndel.TabIndex = 34366;
            this.btndel.Text = "Delete";
            this.btndel.UseVisualStyleBackColor = true;
            this.btndel.Click += new System.EventHandler(this.btndel_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(12, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(210, 20);
            this.textBox1.TabIndex = 34367;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label13.Location = new System.Drawing.Point(24, 5);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(19, 20);
            this.label13.TabIndex = 34368;
            this.label13.Text = "d";
            // 
            // Process
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1024, 586);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btndel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.lst);
            this.Controls.Add(this.grdtest1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtchalanno);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Process";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Process Entry";
            this.Load += new System.EventHandler(this.ChalanForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.drpname_KeyDown);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdtest1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtchalanno;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox drpitem;
        private System.Windows.Forms.DataGridView grdtest1;
        private System.Windows.Forms.ListBox lst;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.TextBox txtqty;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btndel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox dtpUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sno;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewLinkColumn Edit1;
        private System.Windows.Forms.DataGridViewLinkColumn del;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
    }
}