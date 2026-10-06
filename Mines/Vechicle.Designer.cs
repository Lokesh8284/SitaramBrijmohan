namespace WelcomeFabric
{
    partial class Vechicle
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtVehicleNo = new System.Windows.Forms.TextBox();
            this.btnadd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.drpparty = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.grdtest1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VehicleNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit1 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.del = new System.Windows.Forms.DataGridViewLinkColumn();
            this.btnsave = new System.Windows.Forms.Button();
            this.lst = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txtsno = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdtest1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(361, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "VEHICLE MASTER";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtVehicleNo);
            this.groupBox1.Controls.Add(this.btnadd);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.drpparty);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(315, 33);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(513, 111);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vechicle Entry";
            // 
            // txtVehicleNo
            // 
            this.txtVehicleNo.Location = new System.Drawing.Point(141, 67);
            this.txtVehicleNo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtVehicleNo.Name = "txtVehicleNo";
            this.txtVehicleNo.Size = new System.Drawing.Size(264, 22);
            this.txtVehicleNo.TabIndex = 1;
            // 
            // btnadd
            // 
            this.btnadd.Location = new System.Drawing.Point(413, 68);
            this.btnadd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(92, 25);
            this.btnadd.TabIndex = 2;
            this.btnadd.Text = "Add";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 68);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "Vehicle No";
            // 
            // drpparty
            // 
            this.drpparty.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.drpparty.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.drpparty.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.drpparty.FormattingEnabled = true;
            this.drpparty.Location = new System.Drawing.Point(141, 33);
            this.drpparty.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.drpparty.Name = "drpparty";
            this.drpparty.Size = new System.Drawing.Size(264, 22);
            this.drpparty.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "Select Transporter";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.CausesValidation = false;
            this.maskedTextBox1.Location = new System.Drawing.Point(16, 437);
            this.maskedTextBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.maskedTextBox1.Mask = "00-00-00-0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(340, 22);
            this.maskedTextBox1.TabIndex = 4;
            this.maskedTextBox1.Visible = false;
            this.maskedTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.maskedTextBox1_KeyPress);
            // 
            // grdtest1
            // 
            this.grdtest1.AllowUserToAddRows = false;
            this.grdtest1.AllowUserToDeleteRows = false;
            this.grdtest1.AllowUserToResizeColumns = false;
            this.grdtest1.AllowUserToResizeRows = false;
            this.grdtest1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdtest1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Sn,
            this.Name,
            this.VehicleNo,
            this.Edit1,
            this.del});
            this.grdtest1.Location = new System.Drawing.Point(315, 156);
            this.grdtest1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grdtest1.Name = "grdtest1";
            this.grdtest1.ReadOnly = true;
            this.grdtest1.RowHeadersVisible = false;
            this.grdtest1.Size = new System.Drawing.Size(513, 271);
            this.grdtest1.TabIndex = 31;
            this.grdtest1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdtest1_CellContentClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "clid";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // Sn
            // 
            this.Sn.HeaderText = "S.No";
            this.Sn.Name = "Sn";
            this.Sn.ReadOnly = true;
            this.Sn.Width = 50;
            // 
            // Name
            // 
            this.Name.DataPropertyName = "Name";
            this.Name.HeaderText = "Transporter Name";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            this.Name.Width = 150;
            // 
            // VehicleNo
            // 
            this.VehicleNo.DataPropertyName = "VehicleNo";
            this.VehicleNo.HeaderText = "VehicleNo";
            this.VehicleNo.Name = "VehicleNo";
            this.VehicleNo.ReadOnly = true;
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
            // btnsave
            // 
            this.btnsave.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.Location = new System.Drawing.Point(434, 432);
            this.btnsave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(100, 38);
            this.btnsave.TabIndex = 3;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.button2_Click);
            // 
            // lst
            // 
            this.lst.FormattingEnabled = true;
            this.lst.ItemHeight = 14;
            this.lst.Location = new System.Drawing.Point(16, 65);
            this.lst.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(291, 368);
            this.lst.TabIndex = 32;
            this.lst.Click += new System.EventHandler(this.lst_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(682, 432);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 38);
            this.button1.TabIndex = 5;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(562, 432);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 38);
            this.button3.TabIndex = 4;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtsno
            // 
            this.txtsno.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtsno.Location = new System.Drawing.Point(696, 6);
            this.txtsno.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtsno.Name = "txtsno";
            this.txtsno.ReadOnly = true;
            this.txtsno.Size = new System.Drawing.Size(132, 22);
            this.txtsno.TabIndex = 8;
            this.txtsno.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(634, 12);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "Sno";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(16, 37);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(291, 22);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 14);
            this.label4.TabIndex = 4;
            this.label4.Text = "SEARCH TRANSPORTER";
            // 
            // Vechicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(840, 489);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtsno);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lst);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.grdtest1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            //this.Name = "Vechicle";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox drpparty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.DataGridView grdtest1;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.ListBox lst;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtsno;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtVehicleNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehicleNo;
        private System.Windows.Forms.DataGridViewLinkColumn Edit1;
        private System.Windows.Forms.DataGridViewLinkColumn del;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label4;
    }
}