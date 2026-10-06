namespace WelcomeFabric
{
    partial class Pricelist
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pricelist));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.drpyear = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.drpmonth = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtlbrrate = new System.Windows.Forms.TextBox();
            this.drplbr = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.drpbrand = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtravanno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.drpPatientId = new System.Windows.Forms.ComboBox();
            this.label47 = new System.Windows.Forms.Label();
            this.grdtest1 = new System.Windows.Forms.DataGridView();
            this.Sno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ravanno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chalandate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.month = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labourname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbrrate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labouramt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button3 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdtest1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.drpyear);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.drpmonth);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtlbrrate);
            this.groupBox1.Controls.Add(this.drplbr);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.drpbrand);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtravanno);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.drpPatientId);
            this.groupBox1.Controls.Add(this.label47);
            this.groupBox1.Location = new System.Drawing.Point(74, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(838, 152);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(503, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 52;
            this.label8.Text = "Year Wise:";
            // 
            // drpyear
            // 
            this.drpyear.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.drpyear.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.drpyear.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.drpyear.FormattingEnabled = true;
            this.drpyear.Items.AddRange(new object[] {
            "",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "",
            ""});
            this.drpyear.Location = new System.Drawing.Point(494, 100);
            this.drpyear.Name = "drpyear";
            this.drpyear.Size = new System.Drawing.Size(103, 21);
            this.drpyear.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(394, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 50;
            this.label6.Text = "Month Wise:";
            // 
            // drpmonth
            // 
            this.drpmonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.drpmonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.drpmonth.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.drpmonth.FormattingEnabled = true;
            this.drpmonth.Items.AddRange(new object[] {
            "",
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "Augest",
            "September",
            "October",
            "November",
            "December"});
            this.drpmonth.Location = new System.Drawing.Point(385, 100);
            this.drpmonth.Name = "drpmonth";
            this.drpmonth.Size = new System.Drawing.Size(103, 21);
            this.drpmonth.TabIndex = 7;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Checked = false;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(422, 38);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowCheckBox = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(142, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(757, 101);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 20);
            this.button2.TabIndex = 47;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(663, 100);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 20);
            this.button1.TabIndex = 9;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(273, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 45;
            this.label5.Text = "Labour Rate:";
            // 
            // txtlbrrate
            // 
            this.txtlbrrate.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtlbrrate.Location = new System.Drawing.Point(201, 101);
            this.txtlbrrate.Name = "txtlbrrate";
            this.txtlbrrate.Size = new System.Drawing.Size(178, 20);
            this.txtlbrrate.TabIndex = 6;
            this.txtlbrrate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtlbrrate_KeyDown);
            this.txtlbrrate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtlbrrate_KeyPress);
            // 
            // drplbr
            // 
            this.drplbr.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.drplbr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.drplbr.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.drplbr.FormattingEnabled = true;
            this.drplbr.Location = new System.Drawing.Point(19, 101);
            this.drplbr.Name = "drplbr";
            this.drplbr.Size = new System.Drawing.Size(176, 21);
            this.drplbr.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Labour Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(637, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Brand:";
            // 
            // drpbrand
            // 
            this.drpbrand.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.drpbrand.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.drpbrand.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.drpbrand.FormattingEnabled = true;
            this.drpbrand.Location = new System.Drawing.Point(582, 38);
            this.drpbrand.Name = "drpbrand";
            this.drpbrand.Size = new System.Drawing.Size(176, 21);
            this.drpbrand.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(461, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Date:";
            // 
            // txtravanno
            // 
            this.txtravanno.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtravanno.Location = new System.Drawing.Point(214, 38);
            this.txtravanno.Name = "txtravanno";
            this.txtravanno.Size = new System.Drawing.Size(178, 20);
            this.txtravanno.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(273, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Ravana no:";
            // 
            // drpPatientId
            // 
            this.drpPatientId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.drpPatientId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.drpPatientId.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.drpPatientId.FormattingEnabled = true;
            this.drpPatientId.Location = new System.Drawing.Point(19, 38);
            this.drpPatientId.Name = "drpPatientId";
            this.drpPatientId.Size = new System.Drawing.Size(176, 21);
            this.drpPatientId.TabIndex = 1;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(62, 22);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(67, 13);
            this.label47.TabIndex = 34;
            this.label47.Text = "Client Name:";
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
            this.ravanno,
            this.weight,
            this.name,
            this.chalandate,
            this.month,
            this.item,
            this.labourname,
            this.lbrrate,
            this.labouramt});
            this.grdtest1.GridColor = System.Drawing.SystemColors.Desktop;
            this.grdtest1.Location = new System.Drawing.Point(9, 189);
            this.grdtest1.Name = "grdtest1";
            this.grdtest1.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdtest1.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdtest1.RowHeadersVisible = false;
            this.grdtest1.Size = new System.Drawing.Size(926, 286);
            this.grdtest1.TabIndex = 34357;
            // 
            // Sno
            // 
            this.Sno.DataPropertyName = "sno";
            this.Sno.HeaderText = "S.No";
            this.Sno.Name = "Sno";
            this.Sno.ReadOnly = true;
            this.Sno.Width = 50;
            // 
            // ravanno
            // 
            this.ravanno.DataPropertyName = "ravanno";
            this.ravanno.HeaderText = "Ravanano";
            this.ravanno.Name = "ravanno";
            this.ravanno.ReadOnly = true;
            // 
            // weight
            // 
            this.weight.DataPropertyName = "qty";
            this.weight.HeaderText = "Weight";
            this.weight.Name = "weight";
            this.weight.ReadOnly = true;
            this.weight.Width = 50;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "Party Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 150;
            // 
            // chalandate
            // 
            this.chalandate.DataPropertyName = "chalandate";
            this.chalandate.HeaderText = "Date";
            this.chalandate.Name = "chalandate";
            this.chalandate.ReadOnly = true;
            // 
            // month
            // 
            this.month.DataPropertyName = "month";
            this.month.HeaderText = "Month";
            this.month.Name = "month";
            this.month.ReadOnly = true;
            // 
            // item
            // 
            this.item.DataPropertyName = "itemname";
            this.item.HeaderText = "Brand";
            this.item.Name = "item";
            this.item.ReadOnly = true;
            // 
            // labourname
            // 
            this.labourname.DataPropertyName = "labourname";
            this.labourname.HeaderText = "Bhari Karne Wala";
            this.labourname.Name = "labourname";
            this.labourname.ReadOnly = true;
            // 
            // lbrrate
            // 
            this.lbrrate.DataPropertyName = "lbrrate";
            this.lbrrate.HeaderText = "labourrate";
            this.lbrrate.Name = "lbrrate";
            this.lbrrate.ReadOnly = true;
            this.lbrrate.Width = 70;
            // 
            // labouramt
            // 
            this.labouramt.DataPropertyName = "labouramt";
            this.labouramt.HeaderText = "labouramt";
            this.labouramt.Name = "labouramt";
            this.labouramt.ReadOnly = true;
            this.labouramt.Width = 70;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(444, 481);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 20);
            this.button3.TabIndex = 51;
            this.button3.Text = "Print";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(419, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 22);
            this.label7.TabIndex = 34358;
            this.label7.Text = "Price List";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Stencil", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label13.Location = new System.Drawing.Point(48, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 19);
            this.label13.TabIndex = 34369;
            this.label13.Text = "d";
            // 
            // Pricelist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(933, 502);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.grdtest1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(949, 540);
            this.Name = "Pricelist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pricelist";
            this.Load += new System.EventHandler(this.Pricelist_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.drpPatientId_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdtest1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox drpbrand;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtravanno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox drpPatientId;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtlbrrate;
        private System.Windows.Forms.ComboBox drplbr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox drpmonth;
        private System.Windows.Forms.DataGridView grdtest1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sno;
        private System.Windows.Forms.DataGridViewTextBoxColumn ravanno;
        private System.Windows.Forms.DataGridViewTextBoxColumn weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn chalandate;
        private System.Windows.Forms.DataGridViewTextBoxColumn month;
        private System.Windows.Forms.DataGridViewTextBoxColumn item;
        private System.Windows.Forms.DataGridViewTextBoxColumn labourname;
        private System.Windows.Forms.DataGridViewTextBoxColumn lbrrate;
        private System.Windows.Forms.DataGridViewTextBoxColumn labouramt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox drpyear;
        private System.Windows.Forms.Label label13;
    }
}