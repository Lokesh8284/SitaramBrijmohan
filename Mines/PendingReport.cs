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
    public partial class PendingReports : Form
    {
        Data data = new Data();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        string query;
        string query1;
        string query2;
        DataTable tbl1 = new DataTable();

        public PendingReports()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Data.dttbl = tbl1;
            PendingRepamt rep = new PendingRepamt();
            rep.ShowDialog();
        }

        private void PendingReport_Load(object sender, EventArgs e)
        {
            label13.Text = Data.Area;
            DataColumn cl1 = new DataColumn("Dat",typeof(string));
           // cl1.ColumnName = "Dat";
            DataColumn cl2 = new DataColumn();
            cl2.ColumnName = "Name";
            DataColumn cl3 = new DataColumn();
            cl3.ColumnName = "Mob";
            DataColumn cl4 = new DataColumn();
            cl4.ColumnName = "Address";
            DataColumn cl5 = new DataColumn("PrincipalAmt",typeof(double));
            //cl5.ColumnName = "PrincipalAmt";
            DataColumn cl6 = new DataColumn("Receivedamt",typeof(double));
            //cl6.ColumnName = "Receivedamt";
            DataColumn cl7 = new DataColumn("pend",typeof(double));
           // cl7.ColumnName = "pend";
            DataColumn cl8 = new DataColumn();
            cl8.ColumnName = "CrDr";
            DataColumn cl9 = new DataColumn();
            cl9.ColumnName = "compname";
            DataColumn cl10= new DataColumn();
            cl10.ColumnName = "firmaddress";
            tbl1.Columns.Add(cl1);

            tbl1.Columns.Add(cl2);
            tbl1.Columns.Add(cl3);
            tbl1.Columns.Add(cl4);
            tbl1.Columns.Add(cl5);
            tbl1.Columns.Add(cl6);
            tbl1.Columns.Add(cl7);
            tbl1.Columns.Add(cl8);
            tbl1.Columns.Add(cl9);
            tbl1.Columns.Add(cl10);
            fillcity();
            fillpartyname();
        }
        public void fillpartyname()
        {
            query = " SELECT DISTINCT tblclient.Name, tblclient.id, tblclient.Name FROM tblclient INNER JOIN tblpending ON tblclient.id = tblpending.Client_Id where tblclient.firmid=" + Data.id + "";
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
            query = " SELECT distinct City,id from tblclient where tblclient.firmid=" + Data.id + "";
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
            //query = "SELECT tblclient.Name, tblpending.Amount, tblpending.DrCr, tblldg.BillAmt, tblldg.CrDr, tblldg.VocType, tblclient.Address, tblclient.Mob";
            //query += " FROM (tblclient INNER JOIN tblpending ON tblclient.id = tblpending.Client_Id) INNER JOIN tblldg ON tblpending.Client_Id = tblldg.Client_Id";
            //query += " WHERE client_Id<>0";
            query = " SELECT DISTINCT tblclient.Name, tblpending.Amount, convert(char(11),tblpending.Dat,103) AS Dat, tblpending.DrCr, tblclient.id, tblclient.Mob, tblclient.Phone, tblclient.Address, tblfirm.compname, tblfirm.Address as firmaddress";
            query += " FROM (tblclient INNER JOIN tblpending ON tblclient.id = tblpending.Client_Id) INNER JOIN tblfirm ON tblclient.firmid = tblfirm.firmid where tblpending.firmid=" + Data.id + " and tblpending.Amount<>0";
          query += " and tblpending.sessionid="+Data.sessionid+"";
            if (drpPatientId.SelectedIndex > 0)
            {
                query += " and tblpending.client_id="+drpPatientId.SelectedValue+"";
            }
            if (drpArea.SelectedIndex > 0)
            {
                query += " and tblclient.city=" + drpArea.Text + "";
            }
            
             if (dateTimePicker1.Text == dateTimePicker2.Text)
             {
                  //query += " and tblpending.Dat=#" + Convert.ToDateTime(dateTimePicker1.Text).ToShortDateString() + "#";
             }
             else
             {
                 query += " and tblpending.Dat>='" + data.getDateMMDDYYYY(dateTimePicker1.Text) + "' and tblpending.Dat<='" + data.getDateMMDDYYYY(dateTimePicker2.Text) + "'";
             }
             query += " ORDER BY tblclient.Name";
            ds = data.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                tbl1.Rows.Clear();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string id = ds.Tables[0].Rows[i]["id"].ToString();
                    query1 = " select sum (BillAmt)as PrincipalAmt from tblldg where client_Id=" + id + " and CrDr='Dr'";
                    ds1 = data.getDataSet(query1);
                    query2 = " select sum (BillAmt)as Receivedamt from tblldg where client_Id=" + id + " and CrDr='Cr'";
                    ds2 = data.getDataSet(query2);
                    tbl1.Rows.Add();
                     
                    tbl1.Rows[i]["Dat"] = ds.Tables[0].Rows[i]["Dat"].ToString();
                    tbl1.Rows[i]["Name"] = ds.Tables[0].Rows[i]["Name"].ToString();
                    tbl1.Rows[i]["Mob"] = ds.Tables[0].Rows[i]["Mob"].ToString();
                    tbl1.Rows[i]["Address"] = ds.Tables[0].Rows[i]["Address"].ToString();

                    string dd = ds.Tables[0].Rows[i]["Amount"].ToString();
                    string trim = dd.Replace("-", "");
                    trim = trim.Replace("-", " ");
                    tbl1.Rows[i]["pend"] = trim;
                    tbl1.Rows[i]["CrDr"] = ds.Tables[0].Rows[i]["DrCr"].ToString();
                    tbl1.Rows[i]["firmaddress"] = ds.Tables[0].Rows[i]["firmaddress"].ToString();
                    tbl1.Rows[i]["compname"] = ds.Tables[0].Rows[i]["compname"].ToString();
                    for (int k = 0; k < ds1.Tables[0].Rows.Count; k++)
                    {
                        try
                        {
                            tbl1.Rows[i]["PrincipalAmt"] = ds1.Tables[0].Rows[k]["PrincipalAmt"].ToString();
                        }
                        catch
                        { }
                    }
                    for (int j= 0; j < ds2.Tables[0].Rows.Count;j++)
                    {
                        string dds = ds2.Tables[0].Rows[j]["Receivedamt"].ToString();
                        if (dds == "")
                        {
                            tbl1.Rows[i]["Receivedamt"] = 0;
                        }
                        else
                        {
                            tbl1.Rows[i]["Receivedamt"] = ds2.Tables[0].Rows[j]["Receivedamt"].ToString();
                        }
                    }
                }
                grdTest.DataSource = tbl1;
            }
            else
            {
                tbl1.Rows.Clear();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}