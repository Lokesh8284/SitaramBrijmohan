namespace WelcomeFabric
{
    partial class PaymentVoucher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentVoucher));
            this.label18 = new System.Windows.Forms.Label();
            this.drpPatientId = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.txtnetamt = new System.Windows.Forms.TextBox();
            this.dateTimePicker4 = new System.Windows.Forms.DateTimePicker();
            this.btnClose = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txtBank = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCheck = new System.Windows.Forms.TextBox();
            this.drpMode = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPayment = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtVocNo = new System.Windows.Forms.TextBox();
            this.lblRemainigAmt = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblBillAmt = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbldr = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(588, 81);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(90, 13);
            this.label18.TabIndex = 110;
            this.label18.Text = "Net Panding Amt:";
            this.label18.Visible = false;
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
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(14, 27);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(36, 13);
            this.label52.TabIndex = 24;
            this.label52.Text = "Date :";
            // 
            // txtnetamt
            // 
            this.txtnetamt.Location = new System.Drawing.Point(593, 97);
            this.txtnetamt.Name = "txtnetamt";
            this.txtnetamt.ReadOnly = true;
            this.txtnetamt.Size = new System.Drawing.Size(100, 20);
            this.txtnetamt.TabIndex = 109;
            this.txtnetamt.Visible = false;
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
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(455, 318);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(125, 244);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 13);
            this.label17.TabIndex = 106;
            this.label17.Text = "Narration : ";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(222, 244);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(403, 53);
            this.txtRemark.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(374, 318);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(292, 318);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(387, 209);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 13);
            this.label15.TabIndex = 101;
            this.label15.Text = "Bank Name: ";
            // 
            // txtBank
            // 
            this.txtBank.Location = new System.Drawing.Point(479, 205);
            this.txtBank.Name = "txtBank";
            this.txtBank.Size = new System.Drawing.Size(145, 20);
            this.txtBank.TabIndex = 6;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(125, 208);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 13);
            this.label14.TabIndex = 100;
            this.label14.Text = "Check No. : ";
            // 
            // txtCheck
            // 
            this.txtCheck.Location = new System.Drawing.Point(222, 206);
            this.txtCheck.Name = "txtCheck";
            this.txtCheck.Size = new System.Drawing.Size(145, 20);
            this.txtCheck.TabIndex = 5;
            // 
            // drpMode
            // 
            this.drpMode.FormattingEnabled = true;
            this.drpMode.Items.AddRange(new object[] {
            "By Cash",
            "By Cheque",
            "By NEFT"});
            this.drpMode.Location = new System.Drawing.Point(480, 163);
            this.drpMode.Name = "drpMode";
            this.drpMode.Size = new System.Drawing.Size(145, 21);
            this.drpMode.TabIndex = 4;
            this.drpMode.SelectedIndexChanged += new System.EventHandler(this.drpMode_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(387, 166);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 13);
            this.label13.TabIndex = 99;
            this.label13.Text = "Payment Mode : ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(125, 166);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 13);
            this.label12.TabIndex = 98;
            this.label12.Text = "Payment Amount : ";
            // 
            // txtPayment
            // 
            this.txtPayment.Location = new System.Drawing.Point(222, 163);
            this.txtPayment.Name = "txtPayment";
            this.txtPayment.Size = new System.Drawing.Size(145, 20);
            this.txtPayment.TabIndex = 3;
            this.txtPayment.TextChanged += new System.EventHandler(this.txtPayment_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(500, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 97;
            this.label9.Text = "P No. :";
            // 
            // txtVocNo
            // 
            this.txtVocNo.Location = new System.Drawing.Point(579, 35);
            this.txtVocNo.Name = "txtVocNo";
            this.txtVocNo.ReadOnly = true;
            this.txtVocNo.Size = new System.Drawing.Size(122, 20);
            this.txtVocNo.TabIndex = 96;
            // 
            // lblRemainigAmt
            // 
            this.lblRemainigAmt.AutoSize = true;
            this.lblRemainigAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemainigAmt.Location = new System.Drawing.Point(675, 152);
            this.lblRemainigAmt.Name = "lblRemainigAmt";
            this.lblRemainigAmt.Size = new System.Drawing.Size(32, 13);
            this.lblRemainigAmt.TabIndex = 92;
            this.lblRemainigAmt.Text = "0.00";
            this.lblRemainigAmt.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(659, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 91;
            this.label7.Text = "Remaining Amount : ";
            this.label7.Visible = false;
            // 
            // lblBillAmt
            // 
            this.lblBillAmt.AutoSize = true;
            this.lblBillAmt.Location = new System.Drawing.Point(733, 171);
            this.lblBillAmt.Name = "lblBillAmt";
            this.lblBillAmt.Size = new System.Drawing.Size(28, 13);
            this.lblBillAmt.TabIndex = 86;
            this.lblBillAmt.Text = "0.00";
            this.lblBillAmt.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(659, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 85;
            this.label4.Text = "Bill Amount : ";
            this.label4.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(250, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 23);
            this.label1.TabIndex = 84;
            this.label1.Text = "Payment Voucher";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.drpPatientId);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label52);
            this.groupBox1.Controls.Add(this.dateTimePicker4);
            this.groupBox1.Location = new System.Drawing.Point(110, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(477, 68);
            this.groupBox1.TabIndex = 75;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Option";
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
            // PaymentVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(783, 344);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.lbldr);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtnetamt);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtBank);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtCheck);
            this.Controls.Add(this.drpMode);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtPayment);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtVocNo);
            this.Controls.Add(this.lblRemainigAmt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblBillAmt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "PaymentVoucher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PaymentVoucher";
            this.Load += new System.EventHandler(this.PaymentVoucher_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dateTimePicker4_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox drpPatientId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.TextBox txtnetamt;
        private System.Windows.Forms.DateTimePicker dateTimePicker4;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtBank;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtCheck;
        private System.Windows.Forms.ComboBox drpMode;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPayment;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtVocNo;
        private System.Windows.Forms.Label lblRemainigAmt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblBillAmt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbldr;
        private System.Windows.Forms.Label label19;
    }
}