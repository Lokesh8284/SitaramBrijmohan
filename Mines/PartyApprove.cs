using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WelcomeFabric
{
    public partial class PartyApprove : Form
    {
        Data data = new Data();
        DataTable dt = new DataTable();
        public PartyApprove()
        {
            InitializeComponent();
        }

        private void PartyApprove_Load(object sender, EventArgs e)
        {
            Fillgrid();
        }

        private void Fillgrid()
        {
            //    dt = data.GetDataTable("select tbl_TempClient.*,'Approve' as [Approve],'Reject' as [Reject],(Row_number() over (order by CompanyName))SNo from tbl_TempClient where IsApproved=0 and Isreject=0 order by CompanyName");
            dt = data.GetDataTable("select id,name,compname as CompanyName,Address,mob,Password,IsApproved,IsSync,'Approve' as [Approve],'Reject' as [Reject],(Row_number() over (order by compname))SNo from tblclient where IsApproved=0   order by compname");
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Fillgrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string Name = dataGridView1.Rows[e.RowIndex].Cells["CName"].Value.ToString();
                string id = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();
                string Address = dataGridView1.Rows[e.RowIndex].Cells["Address"].Value.ToString();
                string MobileNo = dataGridView1.Rows[e.RowIndex].Cells["MobileNo"].Value.ToString();
                string CompanyName = dataGridView1.Rows[e.RowIndex].Cells["CompanyName"].Value.ToString();
                string firmid = Data.id;
                string Password = dataGridView1.Rows[e.RowIndex].Cells["Password"].Value.ToString();

                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Approve")
                {
                    //string query = "INSERT INTO [tblclient]([Name],[Address],[Mob],[compname],[firmid],[Password])";
                    //query += " Values('" + Name + "','" + Address + "','" + MobileNo + "','" + CompanyName + "','" + firmid + "','" + Password + "' ) ";
                    //if (data.executeCommand(query) == 0)
                    //{
                    //    MessageBox.Show("Party Approve..");
                    data.executeCommand("update tblclient set IsSync=0, IsApproved=1 where id=" + id);
                    MessageBox.Show("Party Approve..");
                    Fillgrid();

                }
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Reject")
                {
                    data.executeCommand("update tblclient set IsSync=0,Isreject=1 where id=" + id);
                    Fillgrid();
                }
            }
        }
    }
}
