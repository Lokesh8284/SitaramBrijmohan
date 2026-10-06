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
    public partial class RawannaReport : Form
    {
        Data data = new Data();
        DataSet ds1 = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DataSet ds = new DataSet();
        string query;
        double totAmt1 = 0;
        public RawannaReport()
        {
            InitializeComponent();
        }

        private void ChallanDetailReport_Load(object sender, EventArgs e)
        {
            label19.Text = Data.Area;
            partyname();
        }
        public void partyname()
        {
            query = " select * from tblitem where firmid=" + Data.id + "  order by itemid ";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["itemid"] = "0";
            newrow["itemname"] = "---Select Item Name ----";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            drpStaff.DataSource = ds.Tables[0];
            drpStaff.DisplayMember = "itemname";
            drpStaff.ValueMember = "itemid";

        }
        string query1;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet ds1 = new DataSet();
            query1 = " SELECT tbl_GstChallanDetails.Unit, tbl_GstChallan.chalantime,tbl_GstChallan.VehicleNo,  tblitem.itemid,  tblitem.itemname, tbl_GstChallanDetails.qty, tbl_GstChallanDetails.ravanano,tbl_GstChallanDetails.chalandate,tblitem.firmid,tblitem.sessionid FROM tbl_GstChallanDetails INNER JOIN tblitem ON tbl_GstChallanDetails.itemid = tblitem.itemid AND tbl_GstChallanDetails.firmid = tblitem.firmid  ";
            query1 += " inner join tbl_GstChallan on tbl_GstChallan.MaxId =tbl_GstChallanDetails.MaxId  where  tbl_GstChallanDetails.firmid=" + Data.id + " and tbl_GstChallanDetails.sessionid=" + Data.sessionid + "";

            if (drpStaff.SelectedIndex > 0)
            {
                query1 += " and tblitem.itemid = " + drpStaff.SelectedValue + " ";
            }
            if (dateTimePicker1.Checked == true && dateTimePicker2.Checked == true)
            {
                if (dateTimePicker1.Text == dateTimePicker2.Text)
                {
                    query1 += " and tbl_GstChallanDetails.chalandate ='" + data.getDateMMDDYYYY(dateTimePicker1.Text) + "'";
                }
                else
                {
                    query1 += " and tbl_GstChallanDetails.chalandate  >='" + data.getDateMMDDYYYY(dateTimePicker1.Text) + "' and tbl_GstChallanDetails.chalandate <='" + data.getDateMMDDYYYY(dateTimePicker2.Text) + "'";
                }
            }
            query1 += " order by tbl_GstChallanDetails.chalandate ";
            ds1 = data.getDataSet(query1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                grdTest.Rows.Clear();
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    grdTest.Rows.Add();
                    grdTest.Rows[i].Cells["sno"].Value = grdTest.Rows.Count;
                    grdTest.Rows[i].Cells["Rawanna"].Value = ds1.Tables[0].Rows[i]["ravanano"].ToString();
                    grdTest.Rows[i].Cells["Date"].Value = Convert.ToDateTime(ds1.Tables[0].Rows[i]["chalandate"].ToString()).ToString("MM/dd/yyyy");
                    grdTest.Rows[i].Cells["Item"].Value = ds1.Tables[0].Rows[i]["itemname"].ToString();
                    grdTest.Rows[i].Cells["qty"].Value = ds1.Tables[0].Rows[i]["qty"].ToString();
                    grdTest.Rows[i].Cells["Unit"].Value = ds1.Tables[0].Rows[i]["Unit"].ToString();
                    grdTest.Rows[i].Cells["Time"].Value = ds1.Tables[0].Rows[i]["chalantime"].ToString();
                    grdTest.Rows[i].Cells["VehicleNo"].Value = ds1.Tables[0].Rows[i]["VehicleNo"].ToString();
                }
                ds = data.getDataSet(query);
            }
            else
            {
                grdTest.Rows.Clear();
                MessageBox.Show("Record Not Found");
            }
        }

        private void grdTest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Data.query = query1;
            RawannaRep rep = new RawannaRep();
            rep.ShowDialog();
        }

        private void drpPatientId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                this.ProcessTabKey(true);
            }
        }


    }
}