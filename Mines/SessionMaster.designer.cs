namespace WelcomeFabric
{
    partial class SessionMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SessionMaster));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtsessno = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.drpmont = new System.Windows.Forms.ComboBox();
            this.txtforyear = new System.Windows.Forms.TextBox();
            this.drpmonthfrom = new System.Windows.Forms.ComboBox();
            this.btnclose = new System.Windows.Forms.Button();
            this.btndel = new System.Windows.Forms.Button();
            this.btncncl = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.txtname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkallmonth = new System.Windows.Forms.CheckBox();
            this.Session = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.drpmonthto = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtsessno);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.drpmont);
            this.groupBox1.Controls.Add(this.txtforyear);
            this.groupBox1.Controls.Add(this.drpmonthfrom);
            this.groupBox1.Controls.Add(this.btnclose);
            this.groupBox1.Controls.Add(this.btndel);
            this.groupBox1.Controls.Add(this.btncncl);
            this.groupBox1.Controls.Add(this.btnsave);
            this.groupBox1.Controls.Add(this.txtname);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(221, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 193);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = ".";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "Session No.";
            // 
            // txtsessno
            // 
            this.txtsessno.Location = new System.Drawing.Point(121, 14);
            this.txtsessno.Name = "txtsessno";
            this.txtsessno.Size = new System.Drawing.Size(75, 20);
            this.txtsessno.TabIndex = 46;
            this.txtsessno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtsessno_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(343, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Year";
            this.label4.Visible = false;
            // 
            // drpmont
            // 
            this.drpmont.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.drpmont.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.drpmont.FormattingEnabled = true;
            this.drpmont.Location = new System.Drawing.Point(103, 119);
            this.drpmont.Name = "drpmont";
            this.drpmont.Size = new System.Drawing.Size(187, 21);
            this.drpmont.TabIndex = 43;
            this.drpmont.Visible = false;
            // 
            // txtforyear
            // 
            this.txtforyear.Location = new System.Drawing.Point(296, 82);
            this.txtforyear.Name = "txtforyear";
            this.txtforyear.Size = new System.Drawing.Size(75, 20);
            this.txtforyear.TabIndex = 42;
            this.txtforyear.Visible = false;
            // 
            // drpmonthfrom
            // 
            this.drpmonthfrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.drpmonthfrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.drpmonthfrom.FormattingEnabled = true;
            this.drpmonthfrom.Location = new System.Drawing.Point(100, 81);
            this.drpmonthfrom.Name = "drpmonthfrom";
            this.drpmonthfrom.Size = new System.Drawing.Size(187, 21);
            this.drpmonthfrom.TabIndex = 39;
            this.drpmonthfrom.Visible = false;
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(297, 146);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 29);
            this.btnclose.TabIndex = 10;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btndel
            // 
            this.btndel.Location = new System.Drawing.Point(216, 146);
            this.btndel.Name = "btndel";
            this.btndel.Size = new System.Drawing.Size(75, 29);
            this.btndel.TabIndex = 9;
            this.btndel.Text = "Delete";
            this.btndel.UseVisualStyleBackColor = true;
            // 
            // btncncl
            // 
            this.btncncl.Location = new System.Drawing.Point(135, 146);
            this.btncncl.Name = "btncncl";
            this.btncncl.Size = new System.Drawing.Size(75, 29);
            this.btncncl.TabIndex = 8;
            this.btncncl.Text = "Cancel";
            this.btncncl.UseVisualStyleBackColor = true;
            this.btncncl.Click += new System.EventHandler(this.btncncl_Click);
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(54, 146);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 29);
            this.btnsave.TabIndex = 7;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(121, 40);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(190, 20);
            this.txtname.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Session";
            // 
            // chkallmonth
            // 
            this.chkallmonth.AutoSize = true;
            this.chkallmonth.Location = new System.Drawing.Point(538, 12);
            this.chkallmonth.Name = "chkallmonth";
            this.chkallmonth.Size = new System.Drawing.Size(55, 17);
            this.chkallmonth.TabIndex = 41;
            this.chkallmonth.Text = "Yearly";
            this.chkallmonth.UseVisualStyleBackColor = true;
            this.chkallmonth.Visible = false;
            // 
            // Session
            // 
            this.Session.FormattingEnabled = true;
            this.Session.Location = new System.Drawing.Point(24, 55);
            this.Session.Name = "Session";
            this.Session.Size = new System.Drawing.Size(166, 238);
            this.Session.TabIndex = 7;
            this.Session.Click += new System.EventHandler(this.Session_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(271, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Session Master";
            // 
            // drpmonthto
            // 
            this.drpmonthto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.drpmonthto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.drpmonthto.FormattingEnabled = true;
            this.drpmonthto.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.drpmonthto.Location = new System.Drawing.Point(124, 96);
            this.drpmonthto.Name = "drpmonthto";
            this.drpmonthto.Size = new System.Drawing.Size(187, 21);
            this.drpmonthto.TabIndex = 43;
            // 
            // SessionMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 312);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Session);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkallmonth);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SessionMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SessionMaster";
            this.Load += new System.EventHandler(this.SessionMaster_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btndel;
        private System.Windows.Forms.Button btncncl;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox Session;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkallmonth;
        private System.Windows.Forms.ComboBox drpmonthfrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox drpmonthto;
        private System.Windows.Forms.TextBox txtforyear;
        private System.Windows.Forms.TextBox txtsessno;
        private System.Windows.Forms.ComboBox drpmont;
        private System.Windows.Forms.Label label3;
    }
}