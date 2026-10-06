using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WelcomeFabric
{
    public partial class ClientSearchReport : Form
    {
        Data data = new Data();
        string query;
        DataSet ds = new DataSet();
        public ClientSearchReport()
        {
            InitializeComponent();
        }
        private void ClientSearchReport_Load(object sender, EventArgs e)
        {
            label19.Text = Data.Area;
            fillpartyname();
        }
        public void fillpartyname()
        {
            query = " SELECT * from tblclient where firmid="+Data.id+"";
            query += " ORDER BY tblclient.Name";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["id"] = "0";
            newrow["name"] = "---Select Party Name----";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            drpPatientId.DataSource = ds.Tables[0];
            drpPatientId.DisplayMember = "name";
            drpPatientId.ValueMember = "id";
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            query = " SELECT tblfirm.compname as firmname, tblfirm.Address as firmaddress, tblclient.Name, tblclient.Address, tblclient.PinCode, tblclient.Phone, tblclient.Mob, tblclient.country, tblclient.state, tblclient.city, tblclient.fax, tblclient.website, tblclient.remark, tblclient.dateofjoin, tblclient.officephone, tblclient.compname, tblclient.id";
            query += " FROM tblclient INNER JOIN tblfirm ON tblclient.firmid = tblfirm.firmid where tblclient.firmid=" + Data.id + "";
            if (drpPatientId.SelectedIndex > 0)
            {
                query += " and tblclient.id=" + drpPatientId.SelectedValue + "";
            }
            query += " order by tblclient.city,tblclient.name";
            ds = data.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdTest.Rows.Clear();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    grdTest.Rows.Add();
                    grdTest.Rows[i].Cells["doj"].Value = ds.Tables[0].Rows[i]["dateofjoin"].ToString();
                    grdTest.Rows[i].Cells["ClientName"].Value = ds.Tables[0].Rows[i]["name"].ToString();
                    grdTest.Rows[i].Cells["mob"].Value = ds.Tables[0].Rows[i]["Mob"].ToString();
                    grdTest.Rows[i].Cells["Phone"].Value = ds.Tables[0].Rows[i]["Phone"].ToString();
                    grdTest.Rows[i].Cells["city"].Value = ds.Tables[0].Rows[i]["city"].ToString();
                    grdTest.Rows[i].Cells["address"].Value = ds.Tables[0].Rows[i]["address"].ToString();
                }
            }
            else
            {
                grdTest.Rows.Clear();
                MessageBox.Show("No Record found.....");
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            Data.query = query;
            ClientRep rep = new ClientRep();
            rep.ShowDialog();
        }
    }
}