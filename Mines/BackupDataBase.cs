using System;
using System.Windows.Forms;

namespace WelcomeFabric
{
    public partial class BackupDataBase : Form
    {
        public BackupDataBase()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Database backup is currently disabled.", "Database Backup",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtBackup_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Database backup is currently disabled.", "Database Backup",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Database backup is currently disabled.", "Database Backup",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
