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
    public partial class PurchaseRegisterReport : Form
    {
        Data data = new Data();
        DataSet ds1 = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DataSet ds = new DataSet();
        string query;
        double totAmt1 = 0;
        public PurchaseRegisterReport()
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
            query = " select * from tblclient where firmid=" + Data.id + " and PartyType='Vendor' order by name";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["id"] = "0";
            newrow["Compname"] = "---Select Vendor ----";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            drpStaff.DataSource = ds.Tables[0];
            drpStaff.DisplayMember = "COMPname";
            drpStaff.ValueMember = "id";

        }
        string query1;
        private void btnSearch_Click(object sender, EventArgs e)
        {

            DataSet ds1 = new DataSet();
            query1 = "SELECT  tblfirm.Name as CName,tblclient.Name,tblclient.compname, tbl_PurchaseDtails.itemname,tbl_PurchaseDtails.Unit,tbl_PurchaseDtails.price, tbl_PurchaseDtails.qty, tbl_PurchaseDtails.amount,convert(varchar(15), tbl_PurchaseDtails.chalandate,103) as chalandate, tbl_PurchaseDtails.chalanno, tbl_PurchaseDtails.itemid, tbl_Purchase.totalamt ";
            query1 += " ,tbl_Purchase.Discount,tbl_Purchase.NetAmount,tbl_Purchase.InvoiceNo,tbl_Purchase.InvoiceDate FROM (((tblclient INNER JOIN tbl_PurchaseDtails ON tblclient.id = tbl_PurchaseDtails.clientid) left JOIN tblitem ON tbl_PurchaseDtails.itemid = tblitem.itemid) INNER JOIN tbl_Purchase ON (tbl_PurchaseDtails.chalanno = tbl_Purchase.chalanno) AND (tblclient.firmid = tbl_Purchase.firmid)) ";
            query1 += " inner join  tblfirm on tblfirm.firmid =tbl_Purchase.firmid where  tbl_PurchaseDtails.firmid=" + Data.id + " and tbl_Purchase.sessionid=" + Data.sessionid + " and tbl_PurchaseDtails.sessionid=" + Data.sessionid + "";

            if (dateTimePicker1.Checked == true && dateTimePicker2.Checked == true)
            {
                if (dateTimePicker1.Text == dateTimePicker2.Text)
                {
                    query1 += " and tbl_PurchaseDtails.chalandate='" + data.getDateMMDDYYYY(dateTimePicker1.Text) + "'";
                }
                else
                {
                    query1 += " and tbl_PurchaseDtails.chalandate>='" + Convert.ToDateTime(dateTimePicker1.Text) + "' and tbl_PurchaseDtails.chalandate<='" + data.getDateMMDDYYYY(dateTimePicker2.Text) + "'";
                }
            }
            query1 += " order by tbl_PurchaseDtails.chalandate ";
            ds1 = data.getDataSet(query1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                grdTest.Rows.Clear();
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    grdTest.Rows.Add();
                    grdTest.Rows[i].Cells["sno"].Value = grdTest.Rows.Count;
                    grdTest.Rows[i].Cells["Vendor"].Value = ds1.Tables[0].Rows[i]["compname"].ToString();
                    grdTest.Rows[i].Cells["Date"].Value = ds1.Tables[0].Rows[i]["chalandate"].ToString();
                    grdTest.Rows[i].Cells["Item"].Value = ds1.Tables[0].Rows[i]["itemname"].ToString();
                    grdTest.Rows[i].Cells["rate"].Value = ds1.Tables[0].Rows[i]["price"].ToString();
                    grdTest.Rows[i].Cells["qty"].Value = ds1.Tables[0].Rows[i]["qty"].ToString();
                    grdTest.Rows[i].Cells["amount"].Value = ds1.Tables[0].Rows[i]["amount"].ToString();
                    grdTest.Rows[i].Cells["Unit"].Value = ds1.Tables[0].Rows[i]["Unit"].ToString();
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
            PurchaseSummaryrep rep = new PurchaseSummaryrep();
            rep.ShowDialog();
        }

        private void drpPatientId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                this.ProcessTabKey(true);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Data.query = query1;
            PurchaseDetailrep rep = new PurchaseDetailrep();
            rep.ShowDialog();
        }
    }
}