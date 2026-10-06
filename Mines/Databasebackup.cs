using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Server;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.IO;
using Microsoft.Win32;


namespace WelcomeFabric
{
    public partial class Databasebackup : Form
    {
        string dir = "";
        string path = "";
        string bpath = "";
        private static Server srvSql;
        bool iserror = true;
        Data data = new Data();
        public Databasebackup()
        {
            InitializeComponent();
        }

        private void Databasebackup_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Please Close All Forms Before Performing The DataBase Backup", "DataBase BackUp", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBackUp_Click(object sender, EventArgs e)
        {
            if (chBoxDb.Checked)
            {
                string dir = Directory.GetCurrentDirectory();
                if (System.IO.Directory.Exists(dir + "/Backup") == false)
                {
                    System.IO.Directory.CreateDirectory(dir + "/Backup");
                }
                string a = dir + "/Backup/";

                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\DryFruits");
                string conString = key.GetValue("OnlineServer").ToString();

                string tokens = conString.Split(';')[1].ToString();
                string database = tokens.Split('=')[1].ToString();

                string query = "BACKUP DATABASE " + database + " TO DISK = '" + a + "\\(" + DateTime.Now.ToString("dd-MM-yy#hh-mm") + ").BAK'";
                //string query = "BACKUP DATABASE db_SKTraders TO DISK = '" + a + "//(" + DateTime.Now.ToString("dd-MM-yy#hh-mm") + ").BAK'";
                data.executeCommand(query);
                MessageBox.Show("DataBase Backup Completed");
            }
            else
            {
                MessageBox.Show("Click Then Right Sign In Check Box !!!");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}