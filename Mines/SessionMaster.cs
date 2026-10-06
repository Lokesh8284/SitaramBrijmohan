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
    public partial class SessionMaster : Form
    {
        Data data = new Data();
        DataSet ds = new DataSet();
        string query;
        SqlDataReader dr;
        Int64 maxid1 = 0;
        SqlCommand cmd = new SqlCommand();
         
        public SessionMaster()
        {
            InitializeComponent();
        }


        private void SessionMaster_Load(object sender, EventArgs e)
        {
            string forMont = DateTime.Now.Month.ToString();
            fillmonth();
            filltomonth1();
            fillsession();
            fillmaxslip();
        }
        public void fillmaxslip()
        {
            query = " select max (seqno) as maxid from tblsession";
            dr = data.getDataReader(query);
            if (dr.Read())
            {
                string id = dr["maxid"].ToString();
                if (id == "")
                {
                    maxid1 = 1;
                    txtsessno.Text = Convert.ToString(maxid1);
                }
                else
                {
                    int maxid = Convert.ToInt32(dr["maxid"].ToString());
                    maxid1 = maxid + 1;
                    txtsessno.Text = Convert.ToString(maxid1);
                }
                dr.Close();
            }
        }
        public void fillmonth()
        {
            //query = " select * from tblmonth";
            //ds = data.getDataSet(query);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    DataRow newrow = ds.Tables[0].NewRow();
            //    newrow["monthname1"] = "--Select---";
            //    newrow["monthid1"] = " 0";
            //    drpmonthfrom.DataSource = ds.Tables[0];
            //    drpmonthfrom.DisplayMember = "monthname1";
            //    drpmonthfrom.ValueMember = "monthid1";
            //}
        }
        public void filltomonth1()
        {
            //query = " select * from tblmonth";
            //ds = data.getDataSet(query);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    DataRow newrow = ds.Tables[0].NewRow();
            //    newrow["monthname1"] = "--Select---";
            //    newrow["monthid1"] = " 0";
            //    ds.Tables[0].Rows.InsertAt(newrow, 0);
            //    drpmont.DataSource = ds.Tables[0];
            //    drpmont.DisplayMember = "monthname1";
            //    drpmont.ValueMember = "monthid1";
            //}
        }
        public void fillsession()
        {
            query = " select * from tblsession order by seqno";
            ds = data.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session.DataSource = ds.Tables[0];
                Session.DisplayMember = "session";
                Session.ValueMember = "sessionid";
            }
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtname.Text == "")
            {
                MessageBox.Show("Can't Blank");
            }
            if (btnsave.Text == "Save")
            {
                if (data.Exist("select [session] from tblsession where [session]='" + txtname.Text.Trim() + "'"))
                {
                    MessageBox.Show("Session " + txtname.Text + " already Exist");
                    return;
                }
                query = " insert into tblsession ([session],seqno)values(@session,@seqno)";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@session", txtname.Text);
                cmd.Parameters.AddWithValue("@seqno", txtsessno.Text);
                data.executeCommand(cmd);
                cmd.Parameters.Clear();
            }
            else
            {
                query = " update tblsession set [session]=@session,seqno=@seqno where sessionid=" + Session.SelectedValue + " ";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@session", txtname.Text);
                cmd.Parameters.AddWithValue("@seqno", txtsessno.Text);
                data.executeCommand(cmd);
                cmd.Parameters.Clear();
            }
            clear();
        }
        public void clear()
        {
            txtname.Text = "";
            drpmonthto.SelectedIndex = -1;
            drpmonthfrom.SelectedIndex = -1;
            txtforyear.Text = "";
            txtsessno.Text = "";
            btnsave.Text = "Save";
            fillsession();
            fillmaxslip();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Session_Click(object sender, EventArgs e)
        {
            if (Session.SelectedValue != null)
            {
                query = " select * from tblsession where sessionid=" + Session.SelectedValue + " ";
                ds = data.getDataSet(query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtname.Text = ds.Tables[0].Rows[0]["session"].ToString();
                    txtsessno.Text = ds.Tables[0].Rows[0]["seqno"].ToString();
                    btnsave.Text = "Update";
                }
            }
        }

        private void btncncl_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void txtsessno_KeyPress(object sender, KeyPressEventArgs e)
        {

            int ch = (int)e.KeyChar;
            if ((ch < 48 || ch > 58) && (ch != 8) && (ch != 46))
                e.KeyChar = '\0';
        }

    }
}