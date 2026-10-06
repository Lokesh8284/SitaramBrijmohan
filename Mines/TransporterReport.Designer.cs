namespace WelcomeFabric
{
    partial class TransporterReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransporterReport));
            this.label19 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Sno1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vechicel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Transporter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTimePicker4 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.drplbr = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.dtpVehicleNo = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
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
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sno1,
            this.Date1,
            this.Vechicel,
            this.Item1,
            this.Quantity1,
            this.Transporter});
            this.dataGridView1.Location = new System.Drawing.Point(16, 131);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1017, 370);
            this.dataGridView1.TabIndex = 34416;
            // 
            // Sno1
            // 
            this.Sno1.HeaderText = "sno";
            this.Sno1.Name = "Sno1";
            this.Sno1.ReadOnly = true;
            // 
            // Date1
            // 
            this.Date1.HeaderText = "Date";
            this.Date1.Name = "Date1";
            this.Date1.ReadOnly = true;
            // 
            // Vechicel
            // 
            this.Vechicel.HeaderText = "Vechicel";
            this.Vechicel.Name = "Vechicel";
            this.Vechicel.ReadOnly = true;
            // 
            // Item1
            // 
            this.Item1.HeaderText = "Item";
            this.Item1.Name = "Item1";
            this.Item1.ReadOnly = true;
            // 
            // Quantity1
            // 
            this.Quantity1.HeaderText = "Quantity";
            this.Quantity1.Name = "Quantity1";
            this.Quantity1.ReadOnly = true;
            // 
            // Transporter
            // 
            this.Transporter.DataPropertyName = "Transporter";
            this.Transporter.HeaderText = "Transporter Name";
            this.Transporter.Name = "Transporter";
            this.Transporter.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(360, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 23);
            this.label1.TabIndex = 42;
            this.label1.Text = "Transporter Report";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(426, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "From";
            // 
            // dateTimePicker4
            // 
            this.dateTimePicker4.Checked = false;
            this.dateTimePicker4.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker4.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker4.Location = new System.Drawing.Point(630, 25);
            this.dateTimePicker4.Name = "dateTimePicker4";
            this.dateTimePicker4.ShowCheckBox = true;
            this.dateTimePicker4.Size = new System.Drawing.Size(121, 20);
            this.dateTimePicker4.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(604, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "To";
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Checked = false;
            this.dateTimePicker3.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker3.Location = new System.Drawing.Point(462, 24);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.ShowCheckBox = true;
            this.dateTimePicker3.Size = new System.Drawing.Size(121, 20);
            this.dateTimePicker3.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(763, 23);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Search";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(844, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(930, 23);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 34379;
            this.button3.Text = "Print";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.drplbr);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.dtpVehicleNo);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.dateTimePicker4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.dateTimePicker3);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(16, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1017, 61);
            this.groupBox2.TabIndex = 34379;
            this.groupBox2.TabStop = false;
            // 
            // drplbr
            // 
            this.drplbr.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.drplbr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.drplbr.BackColor = System.Drawing.Color.White;
            this.drplbr.FormattingEnabled = true;
            this.drplbr.Location = new System.Drawing.Point(79, 23);
            this.drplbr.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.drplbr.Name = "drplbr";
            this.drplbr.Size = new System.Drawing.Size(139, 21);
            this.drplbr.TabIndex = 34383;
            this.drplbr.SelectedIndexChanged += new System.EventHandler(this.drplbr_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(20, 29);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(61, 13);
            this.label18.TabIndex = 34382;
            this.label18.Text = "Transporter";
            // 
            // dtpVehicleNo
            // 
            this.dtpVehicleNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.dtpVehicleNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.dtpVehicleNo.BackColor = System.Drawing.Color.White;
            this.dtpVehicleNo.FormattingEnabled = true;
            this.dtpVehicleNo.Location = new System.Drawing.Point(290, 24);
            this.dtpVehicleNo.Name = "dtpVehicleNo";
            this.dtpVehicleNo.Size = new System.Drawing.Size(125, 21);
            this.dtpVehicleNo.TabIndex = 34380;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(225, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 13);
            this.label12.TabIndex = 34381;
            this.label12.Text = "Vehicle No";
            // 
            // TransporterReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1045, 513);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "TransporterReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transporter Report";
            this.Load += new System.EventHandler(this.ChallanDetailReport_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.drpPatientId_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateTimePicker4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox drplbr;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox dtpVehicleNo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sno1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vechicel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Transporter;
    }
}