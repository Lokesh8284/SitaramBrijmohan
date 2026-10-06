namespace WelcomeFabric
{
    partial class RawMaterial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RawMaterial));
            this.label1 = new System.Windows.Forms.Label();
            this.txtchalanno = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dtpUnit = new System.Windows.Forms.ComboBox();
            this.txtamout = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtqty = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtrate = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.drpitem = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grdtest1 = new System.Windows.Forms.DataGridView();
            this.Sno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit1 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.del = new System.Windows.Forms.DataGridViewLinkColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.txttotal = new System.Windows.Forms.TextBox();
            this.lst = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtlbrrate = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.drplbr = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.drpname = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.drpTransporter = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btndel = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtNetAmount = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.dtpVehicleNo = new System.Windows.Forms.ComboBox();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtFright = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdtest1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label1.Location = new System.Drawing.Point(455, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 23);
            this.label1.TabIndex = 34344;
            this.label1.Text = "Raw Material  Entry";
            // 
            // txtchalanno
            // 
            this.txtchalanno.BackColor = System.Drawing.Color.White;
            this.txtchalanno.Location = new System.Drawing.Point(890, 14);
            this.txtchalanno.Name = "txtchalanno";
            this.txtchalanno.Size = new System.Drawing.Size(100, 20);
            this.txtchalanno.TabIndex = 34354;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(892, 42);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(101, 20);
            this.dateTimePicker1.TabIndex = 34353;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(827, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 34352;
            this.label3.Text = "Bill Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(827, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 34351;
            this.label2.Text = "Sr No";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.dtpUnit);
            this.groupBox3.Controls.Add(this.txtamout);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtqty);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.btnadd);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtrate);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.drpitem);
            this.groupBox3.Location = new System.Drawing.Point(240, 164);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(781, 66);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
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
            this.dtpUnit.TabIndex = 6;
            // 
            // txtamout
            // 
            this.txtamout.BackColor = System.Drawing.Color.White;
            this.txtamout.Location = new System.Drawing.Point(473, 37);
            this.txtamout.Name = "txtamout";
            this.txtamout.Size = new System.Drawing.Size(100, 20);
            this.txtamout.TabIndex = 8;
            this.txtamout.Text = "0";
            this.txtamout.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtqty_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(490, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 34364;
            this.label9.Text = "Amount";
            // 
            // txtqty
            // 
            this.txtqty.BackColor = System.Drawing.Color.White;
            this.txtqty.Location = new System.Drawing.Point(163, 35);
            this.txtqty.Name = "txtqty";
            this.txtqty.Size = new System.Drawing.Size(84, 20);
            this.txtqty.TabIndex = 5;
            this.txtqty.TextChanged += new System.EventHandler(this.txtqty_TextChanged);
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
            this.button3.Location = new System.Drawing.Point(718, 34);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(48, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(633, 34);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(72, 23);
            this.btnadd.TabIndex = 9;
            this.btnadd.Text = "Add";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnitemadd_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(401, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 34357;
            this.label5.Text = "Rate";
            // 
            // txtrate
            // 
            this.txtrate.BackColor = System.Drawing.Color.White;
            this.txtrate.Location = new System.Drawing.Point(367, 36);
            this.txtrate.Name = "txtrate";
            this.txtrate.Size = new System.Drawing.Size(100, 20);
            this.txtrate.TabIndex = 7;
            this.txtrate.TextChanged += new System.EventHandler(this.txtrate_TextChanged);
            this.txtrate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtqty_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(41, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 13);
            this.label16.TabIndex = 8;
            this.label16.Text = "Item Name";
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
            this.drpitem.TabIndex = 4;
            this.drpitem.SelectedIndexChanged += new System.EventHandler(this.drpitem_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 34361;
            this.label6.Text = "Rawanna No";
            this.label6.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Client Name";
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
            this.rate,
            this.amount,
            this.Edit1,
            this.del});
            this.grdtest1.Location = new System.Drawing.Point(259, 234);
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
            this.Item.HeaderText = "Item Name";
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
            // rate
            // 
            this.rate.DataPropertyName = "price";
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(846, 499);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 34363;
            this.label7.Text = "Total Amount";
            // 
            // txttotal
            // 
            this.txttotal.BackColor = System.Drawing.Color.White;
            this.txttotal.Location = new System.Drawing.Point(922, 492);
            this.txttotal.Name = "txttotal";
            this.txttotal.ReadOnly = true;
            this.txttotal.Size = new System.Drawing.Size(100, 20);
            this.txttotal.TabIndex = 34362;
            this.txttotal.Text = "0";
            this.txttotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttotal_KeyPress);
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
            this.button1.Location = new System.Drawing.Point(535, 567);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(625, 567);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(439, 567);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 15;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtlbrrate);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.drplbr);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.drpname);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(246, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 48);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // txtlbrrate
            // 
            this.txtlbrrate.BackColor = System.Drawing.Color.White;
            this.txtlbrrate.Location = new System.Drawing.Point(617, 15);
            this.txtlbrrate.Name = "txtlbrrate";
            this.txtlbrrate.ReadOnly = true;
            this.txtlbrrate.Size = new System.Drawing.Size(100, 20);
            this.txtlbrrate.TabIndex = 9;
            this.txtlbrrate.Visible = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(554, 21);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(63, 13);
            this.label19.TabIndex = 11;
            this.label19.Text = "LabourRate";
            this.label19.Visible = false;
            // 
            // drplbr
            // 
            this.drplbr.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.drplbr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.drplbr.BackColor = System.Drawing.Color.White;
            this.drplbr.FormattingEnabled = true;
            this.drplbr.Location = new System.Drawing.Point(379, 18);
            this.drplbr.Name = "drplbr";
            this.drplbr.Size = new System.Drawing.Size(168, 21);
            this.drplbr.TabIndex = 8;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(303, 22);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(73, 13);
            this.label20.TabIndex = 10;
            this.label20.Text = "Select Labour";
            // 
            // drpname
            // 
            this.drpname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.drpname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.drpname.BackColor = System.Drawing.Color.White;
            this.drpname.FormattingEnabled = true;
            this.drpname.Location = new System.Drawing.Point(74, 21);
            this.drpname.Name = "drpname";
            this.drpname.Size = new System.Drawing.Size(184, 21);
            this.drpname.TabIndex = 3;
            this.drpname.SelectedIndexChanged += new System.EventHandler(this.drpname_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(474, 501);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "Vehicle No";
            this.label12.Visible = false;
            // 
            // drpTransporter
            // 
            this.drpTransporter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.drpTransporter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.drpTransporter.BackColor = System.Drawing.Color.White;
            this.drpTransporter.FormattingEnabled = true;
            this.drpTransporter.Location = new System.Drawing.Point(273, 516);
            this.drpTransporter.Name = "drpTransporter";
            this.drpTransporter.Size = new System.Drawing.Size(168, 21);
            this.drpTransporter.TabIndex = 11;
            this.drpTransporter.Visible = false;
            this.drpTransporter.SelectedIndexChanged += new System.EventHandler(this.drpTransporter_SelectedIndexChanged);
            this.drpTransporter.Leave += new System.EventHandler(this.drpTransporter_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(270, 501);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Select Transporter";
            this.label11.Visible = false;
            // 
            // btndel
            // 
            this.btndel.Location = new System.Drawing.Point(706, 567);
            this.btndel.Name = "btndel";
            this.btndel.Size = new System.Drawing.Size(75, 23);
            this.btndel.TabIndex = 18;
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
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(846, 550);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(63, 13);
            this.label18.TabIndex = 34378;
            this.label18.Text = "Net Amount";
            // 
            // txtNetAmount
            // 
            this.txtNetAmount.BackColor = System.Drawing.Color.White;
            this.txtNetAmount.Location = new System.Drawing.Point(922, 548);
            this.txtNetAmount.Name = "txtNetAmount";
            this.txtNetAmount.Size = new System.Drawing.Size(100, 20);
            this.txtNetAmount.TabIndex = 14;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(846, 524);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(49, 13);
            this.label17.TabIndex = 34377;
            this.label17.Text = "Discount";
            // 
            // txtDiscount
            // 
            this.txtDiscount.BackColor = System.Drawing.Color.White;
            this.txtDiscount.Location = new System.Drawing.Point(922, 522);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(100, 20);
            this.txtDiscount.TabIndex = 13;
            this.txtDiscount.Text = "0";
            this.txtDiscount.Leave += new System.EventHandler(this.txtDiscount_Leave);
            // 
            // dtpVehicleNo
            // 
            this.dtpVehicleNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.dtpVehicleNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.dtpVehicleNo.BackColor = System.Drawing.Color.White;
            this.dtpVehicleNo.FormattingEnabled = true;
            this.dtpVehicleNo.Location = new System.Drawing.Point(477, 516);
            this.dtpVehicleNo.Name = "dtpVehicleNo";
            this.dtpVehicleNo.Size = new System.Drawing.Size(125, 21);
            this.dtpVehicleNo.TabIndex = 12;
            this.dtpVehicleNo.Visible = false;
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.BackColor = System.Drawing.Color.White;
            this.txtInvoiceNo.Location = new System.Drawing.Point(892, 66);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(100, 20);
            this.txtInvoiceNo.TabIndex = 1;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(894, 89);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(101, 20);
            this.dateTimePicker2.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(817, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 34374;
            this.label10.Text = "Invoice Date";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(817, 71);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 13);
            this.label15.TabIndex = 34373;
            this.label15.Text = "Invoice No";
            // 
            // txtFright
            // 
            this.txtFright.BackColor = System.Drawing.Color.White;
            this.txtFright.Location = new System.Drawing.Point(731, 496);
            this.txtFright.Name = "txtFright";
            this.txtFright.Size = new System.Drawing.Size(100, 20);
            this.txtFright.TabIndex = 12;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(686, 500);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(39, 13);
            this.label21.TabIndex = 13;
            this.label21.Text = "Freight";
            // 
            // RawMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1061, 602);
            this.Controls.Add(this.txtFright);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dtpVehicleNo);
            this.Controls.Add(this.txtInvoiceNo);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.drpTransporter);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtNetAmount);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btndel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.lst);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.grdtest1);
            this.Controls.Add(this.txttotal);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtchalanno);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "RawMaterial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RawMaterial";
            this.Load += new System.EventHandler(this.ChalanForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.drpname_KeyDown);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdtest1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtrate;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox drpitem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView grdtest1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txttotal;
        private System.Windows.Forms.ListBox lst;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.TextBox txtamout;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtqty;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox drpTransporter;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btndel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox drpname;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox dtpUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sno;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewLinkColumn Edit1;
        private System.Windows.Forms.DataGridViewLinkColumn del;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtNetAmount;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.ComboBox dtpVehicleNo;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtlbrrate;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox drplbr;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtFright;
        private System.Windows.Forms.Label label21;
    }
}