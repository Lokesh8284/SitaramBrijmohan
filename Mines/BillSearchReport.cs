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
    public partial class BillSearchReport : Form
    {
        Data data = new Data();
        DataSet ds = new DataSet();
        int totAmt1 = 0;
        string totalqty;
        string query;
        string query1;
        DataSet ds1 = new DataSet();
        public BillSearchReport()
        {
            InitializeComponent();
        }

        private void BillSearchReport_Load(object sender, EventArgs e)
        {
            label13.Text = Data.Area;
            fillpartyname();
            fillcity();
        }
        public void fillpartyname()
        {
            // query = " SELECT DISTINCT tblclient.Name, tblclient.id, tblclient.Name FROM tblclient INNER JOIN tblpending ON tblclient.id = tblpending.Client_Id";
            query = " SELECT DISTINCT tblclient.Name, tblclient.id, tblclient.Name FROM tblclient ";
            query += " where tblclient.firmid=" + Data.id + " ";
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
        public void fillcity()
        {
            query = " SELECT distinct City,id from tblclient where city<>''";
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
            search();
        }
        //private int getTotalAmt1()
        //{
        //    int totAmt1 = 0;
        //    //grdTest.Rows.Clear();
        //    for (int i = 0; i < grdTest.Rows.Count; i++)
        //    {
        //        totAmt1 += int.Parse(grdTest.Rows[i].Cells["NetAmount"].Value.ToString());
        //    }
        //    return totAmt1;
        //}

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdTest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdTest.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "View Bill")
            {
                string id = grdTest.Rows[e.RowIndex].Cells["Clientid"].Value.ToString();
                string billno = grdTest.Rows[e.RowIndex].Cells["Billnumber"].Value.ToString();

                query = " SELECT tblclient.Address ,tblclient.website, tblitem.itemname,tblbill.Disc, tblbilldetail.price,tblbill.discount,tblbill.aftdis,tblbill.disrat, tblbill.grno, tblbill.grdate, tblbill.dispatch, tblbill.fright, tblbill.totalamt, tblbill.amount AS netamount, tblbill.amount AS charnetamount, tblbilldetail.billdat, tblbilldetail.amount, tblbilldetail.chalandate, tblbilldetail.qty, tblbill.billno, tblbill.Vat, tblbilldetail.ravanano, tblbilldetail.chalanno, tblclient.Name, tblfirm.Mob as firmmob, tblfirm.Phone as firmphone, tblfirm.Address as firmaddress, tblfirm.officephone as firmoffice, tblfirm.compname, tblfirm.tin";
                query += " FROM ((tblbill INNER JOIN tblclient ON tblbill.clientid = tblclient.id) INNER JOIN (tblbilldetail INNER JOIN tblitem ON tblbilldetail.itemid = tblitem.itemid) ON tblbill.billno = tblbilldetail.billno) INNER JOIN tblfirm ON tblitem.firmid = tblfirm.firmid";
                query += " where tblbill.clientid=" + id + " and tblbilldetail.firmid=" + Data.id + " and tblbill.billno=" + billno + " and tblbill.sessionid=" + Data.sessionid + "";
                query += " order by tblbilldetail.chalanno,tblbilldetail.billdat";

                query1 = " select sum(qty)as qty from tblbilldetail where tblbilldetail.firmid=" + Data.id + " and tblbilldetail.billno=" + billno + " and tblbilldetail.sessionid=" + Data.sessionid + " ";
                ds1 = data.getDataSet(query1);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    totalqty = ds1.Tables[0].Rows[0]["qty"].ToString();
                }
                else
                {
                    totalqty = "";
                }
                Data.BillingAmt = totalqty;
                Data.query = query;
                Data.calvat = grdTest.Rows[e.RowIndex].Cells["vatrate"].Value.ToString();
                Billrep rep = new Billrep();
                rep.Show();
            }
        }
        public void search()
        {
            query = " SELECT tblclient.Name, tblclient.id, convert(char(11),tblbill.billdate,103) AS billdate, tblbill.vatrate, tblbill.billno, tblclient.Address, tblbill.Vat, tblbill.Disc, tblbill.amount, tblbill.totalamt, tblfirm.Address as firmaddress, tblfirm.compname as firmname";
            query += " FROM (tblclient INNER JOIN tblbill ON tblclient.id = tblbill.clientid) INNER JOIN tblfirm ON tblbill.firmid = tblfirm.firmid where tblbill.firmid=" + Data.id + " and tblbill.sessionid=" + Data.sessionid + "";
            if (drpPatientId.SelectedIndex > 0)
            {
                query += " and tblbill.clientid=" + drpPatientId.SelectedValue + "";
            }
            if (drpArea.SelectedIndex > 0)
            {
                query += " and tblclient.city='" + drpArea.Text + "'";
            }
            if (dateTimePicker1.Checked == true && dateTimePicker2.Checked == true)
            {
                if (dateTimePicker1.Text == dateTimePicker2.Text)
                {
                    query += " and tblbill.billdate='" + data.getDateMMDDYYYY(dateTimePicker1.Text) + "'";
                }
                else
                {
                    query += " and tblbill.billdate>='" + data.getDateMMDDYYYY(dateTimePicker1.Text) + "' and tblbill.billdate<='" +data.getDateMMDDYYYY(dateTimePicker2.Text) + "'";
                }
            }
            query += " ORDER BY tblbill.billno";
            ds = data.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdTest.Rows.Clear();
                txtTotAmt.Text = "";
                totAmt1 = 0;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    grdTest.Rows.Add();
                    grdTest.Rows[i].Cells["Date"].Value = ds.Tables[0].Rows[i]["billdate"].ToString();
                    grdTest.Rows[i].Cells["ClientID"].Value = ds.Tables[0].Rows[i]["id"].ToString();
                    grdTest.Rows[i].Cells["ClientName"].Value= ds.Tables[0].Rows[i]["name"].ToString();
                    grdTest.Rows[i].Cells["Billnumber"].Value = ds.Tables[0].Rows[i]["billno"].ToString();
                    grdTest.Rows[i].Cells["address"].Value = ds.Tables[0].Rows[i]["address"].ToString();
                    grdTest.Rows[i].Cells["TotAmount"].Value = ds.Tables[0].Rows[i]["totalamt"].ToString();
                    grdTest.Rows[i].Cells["Discount"].Value = ds.Tables[0].Rows[i]["Disc"].ToString();
                    grdTest.Rows[i].Cells["vat"].Value = ds.Tables[0].Rows[i]["vat"].ToString();
                    grdTest.Rows[i].Cells["vatrate"].Value = ds.Tables[0].Rows[i]["vatrate"].ToString();
                    grdTest.Rows[i].Cells["NetAmount"].Value =ds.Tables[0].Rows[i]["amount"].ToString();
                    grdTest.Rows[i].Cells["ViewBill"].Value = "View Bill";
                    totAmt1 += int.Parse(grdTest.Rows[i].Cells["NetAmount"].Value.ToString());
                }
                txtTotAmt.Text = totAmt1.ToString();
            }
            else
            {
                grdTest.Rows.Clear();
                MessageBox.Show("No Record Found......");
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            Data.query = query;
            billingrep rep = new billingrep();
            rep.ShowDialog();
        }
        private void drpPatientId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                this.ProcessTabKey(true);
            }
            if (e.Control == true)
            {
                if (e.KeyCode == Keys.S)
                {
                    // save();
                }

                else if (e.KeyCode == Keys.F)
                {
                    search();
                }
            }
            if (e.KeyCode == Keys.F1)
            {
                this.Close();
            }
        }
    }
}