using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace WelcomeFabric
{
    public partial class ConString : Form
    {
        public ConString()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (ValidateData() == 0)
            {

            }
            else
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\DryFruits");
                string SConString = txtCon.Text.Trim();
                key.SetValue("OnlineServer", SConString);
                key.Close();
                MessageBox.Show("Local Address Saved..!!"); 
            }
        }
        private int ValidateData()
        {
            int flag = 1;
            if (txtCon.Text == "")
            {
                txtCon.Focus();
                errorProvider1.SetError(txtCon, "* Required");
                flag = 0;
            }
            return flag;
        }
    }
}
