namespace WelcomeFabric
{
    partial class SearchVoucher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchVoucher));
            this.label9 = new System.Windows.Forms.Label();
            this.txtVocNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbldr = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.drpPatientId = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtnetamt = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.dateTimePicker4 = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(500, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 97;
            this.label9.Text = "Sr No. :";
            // 
            // txtVocNo
            // 
            this.txtVocNo.Location = new System.Drawing.Point(581, 57);
            this.txtVocNo.Name = "txtVocNo";
            this.txtVocNo.ReadOnly = true;
            this.txtVocNo.Size = new System.Drawing.Size(122, 20);
            this.txtVocNo.TabIndex = 96;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(250, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 23);
            this.label1.TabIndex = 84;
            this.label1.Text = "Search Voucher";
            // 
            // lbldr
            // 
            this.lbldr.AutoSize = true;
            this.lbldr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldr.Location = new System.Drawing.Point(703, 100);
            this.lbldr.Name = "lbldr";
            this.lbldr.Size = new System.Drawing.Size(0, 15);
            this.lbldr.TabIndex = 111;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Stencil", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label19.Location = new System.Drawing.Point(12, 9);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(20, 19);
            this.label19.TabIndex = 34414;
            this.label19.Text = "d";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(274, 225);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(356, 225);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(437, 225);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.drpPatientId);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.txtnetamt);
            this.groupBox1.Controls.Add(this.label52);
            this.groupBox1.Controls.Add(this.dateTimePicker4);
            this.groupBox1.Location = new System.Drawing.Point(40, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(701, 72);
            this.groupBox1.TabIndex = 75;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Option";
            // 
            // drpPatientId
            // 
            this.drpPatientId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.drpPatientId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.drpPatientId.FormattingEnabled = true;
            this.drpPatientId.Location = new System.Drawing.Point(273, 22);
            this.drpPatientId.Name = "drpPatientId";
            this.drpPatientId.Size = new System.Drawing.Size(176, 21);
            this.drpPatientId.TabIndex = 2;
            this.drpPatientId.SelectedIndexChanged += new System.EventHandler(this.drpPatientId_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Client Name : ";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(460, 23);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(46, 13);
            this.label18.TabIndex = 110;
            this.label18.Text = "Amount:";
            // 
            // txtnetamt
            // 
            this.txtnetamt.Location = new System.Drawing.Point(541, 22);
            this.txtnetamt.Name = "txtnetamt";
            this.txtnetamt.ReadOnly = true;
            this.txtnetamt.Size = new System.Drawing.Size(100, 20);
            this.txtnetamt.TabIndex = 3;
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(14, 27);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(36, 13);
            this.label52.TabIndex = 24;
            this.label52.Text = "Date :";
            // 
            // dateTimePicker4
            // 
            this.dateTimePicker4.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker4.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker4.Location = new System.Drawing.Point(56, 23);
            this.dateTimePicker4.Name = "dateTimePicker4";
            this.dateTimePicker4.Size = new System.Drawing.Size(122, 20);
            this.dateTimePicker4.TabIndex = 1;
            // 
            // SearchVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(783, 344);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.lbldr);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtVocNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "SearchVoucher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Voucher";
            this.Load += new System.EventHandler(this.PaymentVoucher_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dateTimePicker4_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtVocNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbldr;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox drpPatientId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtnetamt;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.DateTimePicker dateTimePicker4;
    }
}