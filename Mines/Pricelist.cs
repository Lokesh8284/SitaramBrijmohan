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
    public partial class Pricelist : Form
    {
        Data data = new Data();
        DataSet ds = new DataSet();
        string query;
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DataTable tbl1 = new DataTable();
        string dd;
        public Pricelist()
        {
            InitializeComponent();
        }

        private void Pricelist_Load(object sender, EventArgs e)
        {
            label13.Text = Data.Area;
            DataColumn cl1 = new DataColumn();
            cl1.ColumnName = "sno";
            DataColumn cl2 = new DataColumn();
            cl2.ColumnName = "ravanno";
            DataColumn cl3 = new DataColumn();
            cl3.ColumnName = "qty";
            DataColumn cl4 = new DataColumn();
            cl4.ColumnName = "Name";
            DataColumn cl5 = new DataColumn("chalandate", typeof(string));
            DataColumn cl6 = new DataColumn();
            cl6.ColumnName = "month";
            DataColumn cl7 = new DataColumn();
            cl7.ColumnName = "itemname";
            DataColumn cl8 = new DataColumn();
            cl8.ColumnName = "labourname";
            DataColumn cl9 = new DataColumn();
            cl9.ColumnName = "lbrrate";
            DataColumn cl10 = new DataColumn();
            cl10.ColumnName = "labouramt";
          
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
            fillpartyname();
            filllabour();
            itemname();
            labourate();
        }
        public void fillpartyname()
        {
            // query = " SELECT DISTINCT tblclient.Name, tblclient.id, tblclient.Name FROM tblclient INNER JOIN tblpending ON tblclient.id = tblpending.Client_Id";
            query = " SELECT  tblclient.Name, tblclient.id, tblclient.Name FROM tblclient ";
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
        public void filllabour()
        {
            query = " SELECT  * from tbllabour";
            query += " where firmid=" + Data.id + " ";
            query += " ORDER BY tbllabour.labourname";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["lbrid"] = "0";
            newrow["labourname"] = "---Select Labour Name----";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            drplbr.DataSource = ds.Tables[0];
            drplbr.DisplayMember = "labourname";
            drplbr.ValueMember = "lbrid";
        }
        public void labourate()
        {
            query = " select * from tbllabourrate where firmid=" + Data.id + " ";
            ds = data.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtlbrrate.Text = ds.Tables[0].Rows[0]["labourrate"].ToString();
            }
            else
            {
                txtlbrrate.Text = "";
            }
        }
        public void itemname()
        {
            query = " select * from tblitem where firmid=" + Data.id + " order by itemname";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["itemid"] = "0";
            newrow["itemname"] = "---Select Item Name----";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                drpbrand.DataSource = ds.Tables[0];
                drpbrand.ValueMember = "itemid";
                drpbrand.DisplayMember = "itemname";
            }
            else
            {
                drpbrand.SelectedIndex = 0;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            query = " SELECT tblclient.Name as cliname, tblitem.itemname, tblchalan.chalandate, tblchalan.chalanno, datepart(mm,tblchalan.chalandate) as month, chalandetail.amount, chalandetail.qty, chalandetail.qty*tblchalan.lbrrate AS labourrate,tblfirm.compname, tblfirm.Address, chalandetail.ravanano, tblchalan.lbrrate,tbllabour.labourname";
            query += " FROM ((((tblclient INNER JOIN tblchalan ON tblclient.id = tblchalan.clientid) INNER JOIN chalandetail ON (tblchalan.chalanno = chalandetail.chalanno) AND (tblchalan.firmid = chalandetail.firmid)) INNER JOIN tblitem ON chalandetail.itemid = tblitem.itemid) INNER JOIN tbllabour ON tblchalan.lbrid = tbllabour.lbrid) INNER JOIN tblfirm ON tblchalan.firmid = tblfirm.firmid";
           query += " where chalandetail.firmid=" + Data.id + "";
           query += " and chalandetail.sessionid=" + Data.sessionid + "";
           if (drpPatientId.SelectedIndex > 0)
           {
               query += " and tblclient.id="+drpPatientId.SelectedValue+"";
           }
           if (txtravanno.Text != "")
           {
               query += " and chalandetail.ravanano='" + txtravanno.Text + "'";
           }
           if (dateTimePicker1.Checked == true)
           {
               query += " and  tblchalan.chalandate='" + Convert.ToDateTime(dateTimePicker1.Text).ToShortDateString() + "'";
           }
           if (drpbrand.SelectedIndex > 0)
           {
               query += " and tblitem.itemid=" + drpbrand.SelectedValue + "";
           }
           if (drplbr.SelectedIndex > 0)
           {
               query += " and tbllabour.lbrid=" + drplbr.SelectedValue + "";
           }
           if (txtlbrrate.Text != "")
           {
               query += " and tblchalan.lbrrate=" + txtlbrrate.Text + "";
           }
           if (drpmonth.Text != "")
           {
               if (drpmonth.SelectedIndex > 9)
               {
                   dd = drpmonth.SelectedIndex.ToString();
               }
               else
               {
                   dd = "0" + drpmonth.SelectedIndex;
               }
               query += " and datepart(mm,tblchalan.chalandate)='" + dd + "'";
           }
           if (drpyear.Text != "")
           {
               query += " and datepart(yyyy,tblchalan.chalandate)='" + drpyear.Text + "'";
           }
           query += " order by  tblchalan.chalandate,tblchalan.chalanno";
           ds = data.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                tbl1.Rows.Clear();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                tbl1.Rows.Add();
                tbl1.Rows[i]["sno"] =tbl1.Rows.Count;
                tbl1.Rows[i]["chalandate"] = ds.Tables[0].Rows[i]["chalandate"].ToString();
                tbl1.Rows[i]["Name"] = ds.Tables[0].Rows[i]["cliname"].ToString();
                tbl1.Rows[i]["ravanno"] = ds.Tables[0].Rows[i]["ravanano"].ToString();
                tbl1.Rows[i]["qty"] = ds.Tables[0].Rows[i]["qty"].ToString();
                tbl1.Rows[i]["month"] = ds.Tables[0].Rows[i]["month"].ToString();
                tbl1.Rows[i]["itemname"] = ds.Tables[0].Rows[i]["itemname"].ToString();
                tbl1.Rows[i]["labourname"] = ds.Tables[0].Rows[i]["labourname"].ToString();
                tbl1.Rows[i]["lbrrate"] = ds.Tables[0].Rows[i]["lbrrate"].ToString();
                tbl1.Rows[i]["labouramt"] = ds.Tables[0].Rows[i]["labourrate"].ToString();
            }
            grdtest1.DataSource = tbl1;
            }
            else
            {
              tbl1.Rows.Clear();
              MessageBox.Show("Data not found.....!");
           }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtlbrrate_KeyDown(object sender, KeyEventArgs e)
        {
        }
        private void txtlbrrate_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ch = (int)e.KeyChar;
            if ((ch < 48 || ch > 58) && (ch != 8) && (ch != 46))
             e.KeyChar = '\0';
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Data.dttbl = tbl1;
            pricerep rep = new pricerep();
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