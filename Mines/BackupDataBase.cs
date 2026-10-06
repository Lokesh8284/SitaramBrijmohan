using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
namespace WelcomeFabric
{
    public partial class BackupDataBase : Form
    {
        DataTable dtServers = SmoApplication.EnumAvailableSqlServers(true);
        private static Server srvr;
        ServerConnection conn;
        public BackupDataBase()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ServerConnection srvConn = new ServerConnection("Data Source=108.178.51.226,1533;Initial Catalog=aa_Paint_db;User Id=paint_user;Password=asdfghlkj@123654;");
            srvConn.LoginSecure = true;
            srvr = new Server(srvConn);
            foreach (Database dbServer in srvr.Databases)
            {
                cmbDataBase.Items.Add(dbServer.Name);
            }
            txtPath.Text = "E:\\Lokesh\\Backup1";
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDlg = new FolderBrowserDialog();
            folderBrowserDlg.ShowNewFolderButton = false;
            DialogResult dlgResult = folderBrowserDlg.ShowDialog();
            if (dlgResult.Equals(DialogResult.OK))
            {
                txtPath.Text = folderBrowserDlg.SelectedPath;
                Environment.SpecialFolder rootFolder = folderBrowserDlg.RootFolder;
            }
        }
        private void txtBackup_Click(object sender, EventArgs e)
        {
            Backup bkp = new Backup();
            conn = new ServerConnection();
            srvr = new Server(conn);
            try
            {
                string databaseName = cmbDataBase.Text;
                bkp.Action = BackupActionType.Database;
                bkp.Database = databaseName;
                string path;
                if (!(txtPath.Text.EndsWith("\\")))
                {
                    path = txtPath.Text + "\\";
                }
                else
                {
                    path = txtPath.Text;
                }
                BackupDeviceItem bkpDevice = new BackupDeviceItem(path + databaseName + ".bak", DeviceType.File);
                bkp.Devices.Add(bkpDevice);
                bkp.Incremental = false;
                bkp.SqlBackup(srvr);
                MessageBox.Show("Database Backup created successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}