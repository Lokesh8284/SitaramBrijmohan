using System;
using System.Windows.Forms;

namespace WelcomeFabric
{
    public partial class Databasebackup : Form
    {
        public Databasebackup()
        {
            InitializeComponent();
        }

        private void Databasebackup_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Database backup is currently disabled.", "Database Backup",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBackUp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Database backup is currently disabled.", "Database Backup",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
