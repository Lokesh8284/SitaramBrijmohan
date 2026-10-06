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
    public partial class VoucherReport : Form
    {
        Data data = new Data();
        DataSet ds = new DataSet();
        string query;
        double totAmt1 = 0;
        public VoucherReport()
        {
            InitializeComponent();
        }

      

        private void VoucherReport_Load(object sender, EventArgs e)
        {
            fillpartyname();
            fillcity();
        }
        public void fillpartyname()
        {
            query = " SELECT * from tblclient where firmid=" + Data.id + "";
            query += " ORDER BY Name";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["id"] = "0";
            newrow["name"] = "---Select Party Name----";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            drpPatientId.DataSource = ds.Tables[0];
            drpPatientId.DisplayMember = "name";
            drpPatientId.ValueMember = "id";
        }
        public void fillcity()
        {
            query = " SELECT distinct City,id from tblclient where firmid="+Data.id+"";
            query += " ORDER BY City";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["id"] = "0";
            newrow["City"] = "---Select City Name----";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            drpArea.DataSource = ds.Tables[0];
            drpArea.DisplayMember = "City";
            drpArea.ValueMember = "id";
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //query = "SELECT tblclient.Name,tblclient.id, tblclient.Address, tblclient.city, tblldg.BillAmt,tblldg.narra, tblldg.CrDr,tblldg.receptno, tblldg.VocType, tblldg.VoucherBy,format(tblldg.dat,'dd/MM/yyyy')as dat";
            //query += " FROM tblclient INNER JOIN tblldg ON tblclient.id = tblldg.Client_Id
           query = " SELECT tblclient.Name, tblclient.id, tblclient.Address, tblclient.city, tblldg.BillAmt, tblldg.narra, tblldg.CrDr, tblldg.receptno, tblldg.VocType, tblldg.VoucherBy, convert(char(11),tblldg.dat,103) AS dat, tblfirm.Address as firmaddress, tblfirm.compname";
            query += " FROM (tblclient INNER JOIN tblldg ON tblclient.id = tblldg.Client_Id) INNER JOIN tblfirm ON tblldg.firmid = tblfirm.firmid";
            query += " where tblldg.firmid=" + Data.id + "";
            if(drpPatientId.SelectedIndex>0)
            {
            query +=" and tblldg.Client_Id="+drpPatientId.SelectedValue+" ";
            }
            if(drpArea.SelectedIndex>0)
            {
            query +=" and tblclient.city='"+drpArea.Text+"' ";
            }
            if (dateTimePicker1.Checked == true && dateTimePicker2.Checked == true)
            {
                if (dateTimePicker1.Text == dateTimePicker2.Text)
                {
                    query += " and tblldg.Dat='" + data.getDateMMDDYYYY(dateTimePicker1.Text) + "'";
                }
                else
                {
                    query += " and tblldg.Dat>='" + data.getDateMMDDYYYY(dateTimePicker1.Text) + "' and tblldg.Dat<='" + data.getDateMMDDYYYY(dateTimePicker2.Text) + "'";
                }
            }
            query += " and tblldg.CrDr='Dr' order by receptno,tblclient.name,Dat";
            ds = data.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdTest.Rows.Clear();
                totAmt1 = 0;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    grdTest.Rows.Add();
                    grdTest.Rows[i].Cells["Date"].Value = ds.Tables[0].Rows[i]["dat"].ToString();
                    grdTest.Rows[i].Cells["ClientID"].Value = ds.Tables[0].Rows[i]["id"].ToString();
                    grdTest.Rows[i].Cells["ClientName"].Value = ds.Tables[0].Rows[i]["name"].ToString();
                    grdTest.Rows[i].Cells["ReceiptNo"].Value = ds.Tables[0].Rows[i]["receptno"].ToString();
                   grdTest.Rows[i].Cells["address"].Value = ds.Tables[0].Rows[i]["address"].ToString();
                    grdTest.Rows[i].Cells["Paid"].Value = ds.Tables[0].Rows[i]["BillAmt"].ToString();
                    grdTest.Rows[i].Cells["PaymentMode"].Value = ds.Tables[0].Rows[i]["VoucherBy"].ToString();
                    grdTest.Rows[i].Cells["remark"].Value = ds.Tables[0].Rows[i]["narra"].ToString();
                    totAmt1 += Convert.ToDouble(grdTest.Rows[i].Cells["Paid"].Value.ToString());
                }
                txtTotAmt.Text = totAmt1.ToString();
            }
            else
            {
                grdTest.Rows.Clear();
                MessageBox.Show("No Record Found.....");
                
            }
           
        }
        private int getTotalAmt1()
        {
            int totAmt1 = 0;
            for (int i = 0; i < grdTest.Rows.Count; i++)
            {
                totAmt1 += int.Parse(grdTest.Rows[i].Cells["Paid"].Value.ToString());
            }
            return totAmt1;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Data.query = query;
            voucherrep rep = new voucherrep();
            rep.ShowDialog();
        }

    }
}