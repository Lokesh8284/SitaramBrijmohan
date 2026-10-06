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
    public partial class AccountStatus : Form
    {
        Data data = new Data();
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DataSet ds1 = new DataSet();
        string query;
        string query1;
        string query2;
        double totAmt = 0;
        double totAmt1 = 0;
        string query3;
        double opbal;
        string trim;
        DataSet ds2 = new DataSet();
        string totbillamt, totbillamt1;
        public AccountStatus()
        {
            InitializeComponent();
        }

        private void AccountStatus_Load(object sender, EventArgs e)
        {
            fillpartyname();
        }
        public void fillpartyname()
        {
           // query = " SELECT DISTINCT tblclient.Name, tblclient.id, tblclient.Name FROM tblclient INNER JOIN tblpending ON tblclient.id = tblpending.Client_Id";
            query = " SELECT DISTINCT tblclient.Name, tblclient.id, tblclient.Name, tblclient.Name";
            query += " FROM tblclient INNER JOIN tblldg ON tblclient.id = tblldg.Client_Id where tblldg.firmid="+Data.id+"";
             query += " ORDER BY tblclient.Name";
            //query += " ORDER BY tblclient.Name";
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
                query =" SELECT tblclient.Name, tblclient.Address, tblclient.city, tblclient.Phone, tblclient.Mob, tblldg.CrDr, tblldg.VocType, tblldg.BillAmt, convert(char(11),tblldg.Dat,103) AS Dat, tblldg.Billno, tblfirm.compname, tblfirm.Address as firmaddress";
                query +="  FROM (tblclient INNER JOIN tblldg ON tblclient.id = tblldg.Client_Id) INNER JOIN tblfirm ON tblldg.firmid = tblfirm.firmid";
                query += " where tblldg.CrDr='Dr'";
                query += " and tblldg.Client_Id="+drpPatientId.SelectedValue+"";
                query += " and tblldg.firmid="+Data.id+"";
                query += " and tblldg.sessionid=" + Data.sessionid + "";
                query += " and tblldg.billamt<>0";
                  if (dateTimePicker1.Checked == true && dateTimePicker2.Checked == true)
                  {
                      if (dateTimePicker1.Text == dateTimePicker2.Text)
                      {
                          query += " and  tblldg.Dat='" + data.getDateMMDDYYYY(dateTimePicker1.Text)+ "'";
                          
                      }
                      else
                      {
                          query += " and tblldg.Dat,'mm/dd/yyyy')>='" + data.getDateMMDDYYYY(dateTimePicker1.Text) + "' and  tblldg.Dat<='" + data.getDateMMDDYYYY(dateTimePicker2.Text) + "'";
                      }
                      query3 = " select sum(BillAmt) as amt from tblldg where CrDr='Dr' and tblldg.Dat<'" + data.getDateMMDDYYYY(dateTimePicker1.Text) + "'";
                          query3 += " and tblldg.sessionid="+Data.sessionid+"";
                          ds2 = data.getDataSet(query3);
                          if (ds2.Tables[0].Rows.Count > 0)
                          {
                              totbillamt = ds2.Tables[0].Rows[0]["amt"].ToString();
                          }
                          else
                          {

                          }
                          query3 = " select sum(BillAmt) as amt from tblldg where CrDr='Cr' and convert(char(11), tblldg.Dat,103)<'" + data.getDateMMDDYYYY(dateTimePicker1.Text) + "'";
                          query3 += " and tblldg.sessionid=" + Data.sessionid + "";
                          ds2 = data.getDataSet(query3);
                          if (ds2.Tables[0].Rows.Count > 0)
                          {
                              totbillamt1 = ds2.Tables[0].Rows[0]["amt"].ToString();
                          }
                          else
                          {

                          }
                          if (totbillamt1 == "")
                              totbillamt1 = "0";
                          
                           opbal = Convert.ToDouble(totbillamt) - Convert.ToDouble(totbillamt1);
                          txtPreBalance.Text = opbal.ToString();
                          string ddk = txtPreBalance.Text;

                          if (ddk.Contains("-"))
                          {
                              trim = txtPreBalance.Text.Replace("-", "");
                              trim = trim.Replace("-", " ");
                              txtPreBalance.Text = trim;
                              PreBalanceCrDr.Text = "Cr";
                              txtprebaldr.Text = "0";
                              prebaldr.Text = "";
                          }
                          else
                          {
                              txtPreBalance.Text = "0";
                              PreBalanceCrDr.Text = "";
                              txtprebaldr.Text = opbal.ToString();
                              prebaldr.Text = "Dr";
                          }
                              
                      
                  }
                  query += " Order by tblldg.dat,tblldg.id";
                  ds = data.getDataSet(query);
                  if (ds.Tables[0].Rows.Count > 0)
                  {
                      grdTest.Rows.Clear();
                       totAmt = 0;
                      for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                      {
                          grdTest.Rows.Add();
                         

                          grdTest.Rows[i].Cells["BillingDate"].Value = ds.Tables[0].Rows[i]["Dat"].ToString();
                          grdTest.Rows[i].Cells["VoucherTyp"].Value = ds.Tables[0].Rows[i]["VocType"].ToString();
                          grdTest.Rows[i].Cells["BillAmt"].Value = ds.Tables[0].Rows[i]["BillAmt"].ToString();
                          string dd = ds.Tables[0].Rows[i]["BillAmt"].ToString();
                          if (dd != "")
                          {
                              totAmt += Convert.ToDouble(grdTest.Rows[i].Cells["BillAmt"].Value.ToString());
                                 // int.Parse(grdTest.Rows[i].Cells["BillAmt"].Value.ToString());
                          }

                      }
                      //double ddd = totAmt;
                      //double dd1 = totAmt1;
                      //double chkamt = totAmt - totAmt1;
                      //grdTest.Rows.Add();
                      //grdTest.Rows[0].Cells["VoucherTyp"].Value = "Balance C/F";
                      //grdTest.Rows[0].Cells["BillAmt"].Value = chkamt;
                      txttotbillAmt.Text = totAmt.ToString();
                  }
                  else
                  {
                      grdTest.Rows.Clear();
                  }
                  //query1 = "SELECT tblclient.Name, tblldg.CrDr, tblldg.VocType, tblldg.BillAmt, Format(tblldg.Dat,'dd/MM/yyyy')as Dat, tblldg.Billno";
                  //query1 += " FROM tblclient INNER JOIN tblldg ON tblclient.id = tblldg.Client_Id";
            query1 =" SELECT tblclient.Name, tblldg.CrDr, tblldg.VocType, tblldg.BillAmt, convert(char(11),tblldg.Dat,103) AS Dat, tblldg.Billno, tblfirm.Address as firmaddress, tblfirm.compname";
                   query1 += " FROM (tblclient INNER JOIN tblldg ON tblclient.id = tblldg.Client_Id) INNER JOIN tblfirm ON tblldg.firmid = tblfirm.firmid";
                  query1 += " where tblldg.CrDr='Cr'";
                  query1 += " and tblldg.Client_Id=" + drpPatientId.SelectedValue + "";
                  query1 += " and tblldg.firmid=" + Data.id + "";
                  query1 += " and tblldg.sessionid=" + Data.sessionid + "";
                  if (dateTimePicker1.Checked == true && dateTimePicker2.Checked == true)
                  {
                      if (dateTimePicker1.Text == dateTimePicker2.Text)
                      {
                          query1 += " and tblldg.Dat='" + data.getDateMMDDYYYY(dateTimePicker1.Text) + "'";
                         // query += " and  format( tblldg.Dat,'dd/mm/yyyy')='"+dateTimePicker1.Text+ "'";
                          //query += " and  format( tblldg.Dat,'dd/mm/yyyy')=#" + Convert.ToDateTime(dateTimePicker1.Text).ToShortDateString() + "#";
                         // query += " and format(tblldg.Dat,'dd/mm/yyyy')='" + dateTimePicker1.Text + "'";
                      }
                      else
                      {

                          query1 += " and  tblldg.Dat>='" + data.getDateMMDDYYYY(dateTimePicker1.Text) + "' and  tblldg.Dat<='" + Convert.ToDateTime(dateTimePicker2.Text).ToShortDateString() + "'";
                          string query3;
                          query3 = " select sum(BillAmt) as amt from tblldg where CrDr='Cr' and tblldg.Dat<'" + data.getDateMMDDYYYY(dateTimePicker1.Text) + "'";
                          query3 += " and tblldg.sessionid=" + Data.sessionid + "";
                      }
                  }
                  query1 += "  Order by tblldg.dat,tblldg.id";
                  ds = data.getDataSet(query1);
                  if (ds.Tables[0].Rows.Count > 0)
                  {
                      grdReceipt.Rows.Clear();
                       totAmt1 = 0;
                      for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                      {
                          grdReceipt.Rows.Add();
                          grdReceipt.Rows[i].Cells["receiptDate"].Value = ds.Tables[0].Rows[i]["Dat"].ToString();
                          grdReceipt.Rows[i].Cells["VoucherTyp1"].Value = ds.Tables[0].Rows[i]["VocType"].ToString();
                          grdReceipt.Rows[i].Cells["ReceiptAmt"].Value = ds.Tables[0].Rows[i]["BillAmt"].ToString();
                          totAmt1 += Convert.ToDouble(grdReceipt.Rows[i].Cells["ReceiptAmt"].Value.ToString());
                      }
                      txtTotReceiptAmt.Text = totAmt1.ToString();
                  }
                  else
                  {
                      grdReceipt.Rows.Clear();
                      txtTotReceiptAmt.Text = "0.00";
                  }
                  query2 = " select amount,DrCr from tblpending where client_Id="+drpPatientId.SelectedValue+"";
                  query2 += " and tblpending.sessionid=" + Data.sessionid + "";
                  ds = data.getDataSet(query2);
                  if (ds.Tables[0].Rows.Count > 0)
                  {
                      lblBalDrCr.Text = ds.Tables[0].Rows[0]["DrCr"].ToString();
                      txtBalWthOutInt.Text = ds.Tables[0].Rows[0]["amount"].ToString();
                      string trim = txtBalWthOutInt.Text.Replace("-", "");
                      trim = trim.Replace("-", " ");
                      txtBalWthOutInt.Text = trim;
                  }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            Data.query = query;
            Data.query1 = query1;
            Data.receiptAmt = txtTotReceiptAmt.Text;
            Data.Area = lblBalDrCr.Text;
            Data.BillingAmt = txtBalWthOutInt.Text;
            pendingrep rep = new pendingrep();
            rep.ShowDialog();
        }
        private void txtPreBalance_TextChanged(object sender, EventArgs e)
        {

        }
    }
}