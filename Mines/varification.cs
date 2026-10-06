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
    public partial class varification : Form
    {
        Data data = new Data();
        DataSet ds = new DataSet();
        string query;
        SqlDataReader dr;
        DateTime startdate;
        DateTime EndDate;
        public varification()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            query = "select * from TblHDD where HDD='" + txtVarify.Text.Trim() + "'";
            dr = data.getDataReader(query);
            if (dr.Read())
            {
                string aa = dr["HDD"].ToString();
                if (aa == "sscompusoft123456789")
                {
                    this.Close();
                    loginform Loginrep = new loginform();
                    Loginrep.ShowDialog();
                }
                else
                {

                }
                dr.Close();
            }
            else
            {
                dr.Close();
                if (txtVarify.Text.Trim() == "sscompusoft123456789")
                {
                    startdate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    EndDate = startdate.AddDays(365);
                    query = "insert into TblHDD(HDD,startdate,enddate) values('" + txtVarify.Text.Trim() + "','" + startdate + "','" + EndDate + "')";
                    data.executeCommand(query);
                    MessageBox.Show("You are varified to use this software, Please Start Again to use");
                    //this.Close();
                    //Login Loginrep = new Login();
                    //Loginrep.ShowDialog();
                    Application.Exit();
                }
                else
                {
                    txtVarify.Text = "";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}