using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
namespace WelcomeFabric
{
    public partial class pricerep : Form
    {
        Data data = new Data();
        public pricerep()
        {
            InitializeComponent();
        }
        private void pricerep_Load(object sender, EventArgs e)
        {
            CrystalDecisions.CrystalReports.Engine.ReportDocument repDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            WelcomeFabric.Report.DataSet2 ds = new WelcomeFabric.Report.DataSet2();
            ds.Tables["tblchalan"].Merge(Data.dttbl);
            repDoc = new WelcomeFabric.Report.PriceReport();
            repDoc.SetDataSource(ds);
            crystalReportViewer1.ReportSource = repDoc;
            crystalReportViewer1.Dock = DockStyle.Fill;
        }
    }
}