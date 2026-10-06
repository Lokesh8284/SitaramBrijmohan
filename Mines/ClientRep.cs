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
    public partial class ClientRep : Form
    {
        Data data = new Data();

        public ClientRep()
        {
            InitializeComponent();
            SqlDataAdapter adp = new SqlDataAdapter(Data.query, data.conString);
            WelcomeFabric.Report.DataSet2 ds = new WelcomeFabric.Report.DataSet2();
            adp.Fill(ds, "tblclient");
            CrystalDecisions.CrystalReports.Engine.ReportDocument repdoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            repdoc = new WelcomeFabric.Report.CustomerReport();
            repdoc.SetDataSource(ds);
            crystalReportViewer1.ReportSource = repdoc;
            crystalReportViewer1.Dock = DockStyle.Fill;
        }

        private void ClientRep_Load(object sender, EventArgs e)
        {

        }
    }
}