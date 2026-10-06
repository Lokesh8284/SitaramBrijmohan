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
    public partial class PasswordChange : Form
    {
        Data data = new Data();
        DataSet ds = new DataSet();
        SqlDataReader dr;
        string query;
        // bool loginflag = false;
        string stdate = "";
        string endDat = "";
        DateTime EndDate;
        bool loginflag = false;
        public PasswordChange()
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
            txtUserName.Text = Data.UserId;

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
                        //MessageBox.Show("Your Time is over, Please contact Provider");
                        string aa = "";
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

        }


        private void bt_login_Click(object sender, EventArgs e)
        {

            if (txtoldpassword.Text.Trim() == "")
            {
                MessageBox.Show("Must be entered old password");
                return;
            }
            if (txtnewpass.Text.Trim() == "")
            {
                MessageBox.Show("Must be entered new password");
                return;
            }
            if (txtreconfirm.Text.Trim() == "")
            {
                MessageBox.Show("Must be entered re-confirm password");
                return;
            }
            if (txtnewpass.Text != txtreconfirm.Text)
            {
                MessageBox.Show("New Password and Confirm Password not match");
                return;
            }
            else
            {
                if (Data.UID == "0")
                {
                    query = "select * from login where password='" + txtoldpassword.Text + "' and firmid=" + Data.id;
                    if (data.Exist(query))
                    {
                        query = "update login set password='" + txtreconfirm.Text + "'where firmid=" + Data.id;
                        data.executeCommand(query);
                        MessageBox.Show("Password Change successfully");
                        this.Close();
                        loginform Loginrep = new loginform();
                        Loginrep.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Sorry,Incorrect Old Password");
                        return;
                    }
                }
                else
                {
                    query = "select * from tbl_User where firmid=" + Data.id + " and Password='" + txtoldpassword.Text + "'";
                    if (data.Exist(query))
                    {
                        query = "update tbl_User set Password='" + txtreconfirm.Text + "' where firmid=" + Data.id + " and id=" + Data.UID + "";
                        data.executeCommand(query);
                        MessageBox.Show("Password Change successfully");
                        this.Close();
                        loginform Loginrep = new loginform();
                        Loginrep.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Sorry,Incorrect Old Password");
                        return;
                    }
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