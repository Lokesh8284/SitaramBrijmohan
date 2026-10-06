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
    public partial class GstReportSale : Form
    {
        Data data = new Data();
        //public void static string amt;
        public GstReportSale()
        {
            InitializeComponent();
        }

        private void GstReportSale_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter(Data.query, data.conString); 
            WelcomeFabric.Report.DataSet1 ds = new WelcomeFabric.Report.DataSet1();
            adp.Fill(ds, "ABC"); 
            CrystalDecisions.CrystalReports.Engine.ReportDocument repdoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            repdoc = new WelcomeFabric.Report.GSTSaleReport1();
            repdoc.SetDataSource(ds);
            crystalReportViewer1.ReportSource = repdoc;
            crystalReportViewer1.Dock = DockStyle.Fill;
        }
    }
}