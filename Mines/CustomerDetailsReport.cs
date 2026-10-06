using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WelcomeFabric
{
    public partial class AppUserReport : Form
    {
        Data data = new Data();
        DataSet ds = new DataSet();
        DataTable dtprint = new DataTable();


        public AppUserReport()
        {
            InitializeComponent();
        }

        private void CustomerDetailsReport_Load(object sender, EventArgs e)
        {
            //string Query = " select ROW_NUMBER()over (order by CompanyName) as SNo,* From tbl_TempClient where IsApproved = '1' ";

            //ds = data.getDataSet(Query);
            DataSet dss = data.getDataSet("select ROW_NUMBER()over (order by CompName) as SNo, Id, compname as companyname, Name,address,mob as mobileno from tblclient where Delid=0 and IsUser=1 and firmid=" + Data.id);
            dtprint = dss.Tables[0];
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dss.Tables[0];            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Data.dt = dtprint;
            Data.reportformat = "AppUserDetails";
            Data.reportformatdataset = "AppUserDetails";
            Report.rpt_frm rp = new WelcomeFabric.Report.rpt_frm();
            rp.Show();
        }
    }
}
