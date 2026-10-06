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
    public partial class loginform : Form
    {
        Data data = new Data();
        DataSet ds = new DataSet();
        SqlDataReader dr;
        string query;
        string stdate = "";
        string endDat = "";
        DateTime EndDate;
        bool loginflag = false;
        public loginform()
        {
            InitializeComponent();
        }
        public bool loginsussess
        {
            get
            { return loginflag; }
            set
            { loginflag = value; }
        }
        private void loginform_Load(object sender, EventArgs e)
        {
            query = "select * from TblHDD";
            dr = data.getDataReader(query);
            if (dr.Read())
            {
                if (dr["HDD"].ToString() != "")
                {
                    stdate = dr["StartDate"].ToString();
                    endDat = dr["EndDate"].ToString();
                    EndDate = Convert.ToDateTime(endDat);
                    if (EndDate < Convert.ToDateTime(DateTime.Now.ToString()))
                    {
                        MessageBox.Show("Your Time is over, Please contact Provider");
                        // string aa = "";
                        return;
                    }
                }
                else
                {
                    this.Close();
                    varification Loginrep = new varification();
                    Loginrep.ShowDialog();
                }
            }
            else
            {
                this.Close();
                varification Loginrep = new varification();
                Loginrep.ShowDialog();
            }
            dr.Close();
            fillsession();
            Data.sessionid = drpsession.SelectedValue.ToString();
            fillfirm();
            txtUserName.Focus();
            this.ActiveControl = txtUserName;
        }
        public void fillsession()
        {
            query = "select  * from tblsession order by session desc";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["session"] = " --- Select session---";
            newrow["sessionid"] = "0";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            drpsession.DataSource = ds.Tables[0];
            drpsession.DisplayMember = "session";
            drpsession.ValueMember = "sessionid";

            drpsession.SelectedIndex = 1;
        }
        public void fillfirm()
        {
            query = " SELECT * from tblfirm order by compname";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["firmid"] = "0";
            newrow["compname"] = "---Select Party Name----";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            drpfirm.DataSource = ds.Tables[0];
            drpfirm.DisplayMember = "compname";
            drpfirm.ValueMember = "Firmid";

            drpfirm.SelectedIndex = 1;
        }
        private void bt_login_Click(object sender, EventArgs e)
        {
            if (drpsession.SelectedIndex == 0)
            {
                MessageBox.Show("Session Must be Select");
                return;
            }
            if (txtUserName.Text == "")
            {
                MessageBox.Show("User Name Must be entered");
                return;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Password must be entered");
                return;
            }
            else
            {
                query = "select tblfirm.Name,login.firmid,login.UserName,login.Password from tblfirm inner join  login on login.firmid= tblfirm.firmid  where login.username='" + txtUserName.Text + "' and login.password = '" + txtPassword.Text + "' and login.firmid=" + drpfirm.SelectedValue + "";
                ds = data.getDataSet(query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Data.Area = drpsession.Text.ToString();
                    Data.UserId = txtUserName.Text.Trim();
                    loginsussess = true;
                    this.Close();
                    Data.id = drpfirm.SelectedValue.ToString();
                    Data.sessionid = drpsession.SelectedValue.ToString();
                    Data.UID = "0";
                    Data.ComapnyName = drpfirm.Text;
                    Data.NameUser = ds.Tables[0].Rows[0]["Name"].ToString();

                }
                else
                {
                    //query = "Select * from tbl_User where UserName='" + txtUserName.Text + "' and Password = '" + txtPassword.Text + "' and firmid=" + drpfirm.SelectedValue + "";
                    //ds = data.getDataSet(query);
                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    //    Data.Area = drpsession.Text.ToString();
                    //    Data.UserId = txtUserName.Text.Trim();
                    //    loginsussess = true;
                    //    this.Close();
                    //    Data.UID = ds.Tables[0].Rows[0]["id"].ToString();
                    //    Data.id = drpfirm.SelectedValue.ToString();
                    //    Data.sessionid = drpsession.SelectedValue.ToString();
                    //    Data.ComapnyName = drpfirm.Text;
                    //}
                    //else
                    //{
                    MessageBox.Show("Invalid User name or Password", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUserName.Focus();
                    txtPassword.Text = "";
                    txtUserName.Text = "";
                    //}
                }
            }
        }
        private void drpfirm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                this.ProcessTabKey(true);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginform_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}