using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WelcomeFabric.Report
{
    public partial class rpt_frm : Form
    {
        Data data = new Data();
        DataSet ds;

        public rpt_frm()
        {
            InitializeComponent();
        }

        private void rpt_frm_Load(object sender, EventArgs e)
        {
            DataTable dt = Data.dt;

            if (Data.reportformatdataset == "AppUserDetails")
            {
                ds = new Report.DataSet2();
            }
            CrystalDecisions.CrystalReports.Engine.ReportDocument repdoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            if (Data.reportformat == "AppUserDetails")
            {
                ds.Tables["AppUserDetails"].Merge(dt);
                repdoc = new Report.AppUserDetails();
            }

            repdoc.SetDataSource(ds);
            repdoc.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
            crystalReportViewer1.ReportSource = repdoc;
            crystalReportViewer1.Dock = DockStyle.Fill;

        }
    }
}
