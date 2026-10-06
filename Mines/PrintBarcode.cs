using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WelcomeFabric
{
    public partial class PrintBarcode : Form
    {
        public PrintBarcode()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            CrystalDecisions.CrystalReports.Engine.ReportDocument repDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            WelcomeFabric.Report.DataSet2 ds = new WelcomeFabric.Report.DataSet2();
            ds.Tables["Barcode"].Merge(Data.dttbl);
            repDoc = new WelcomeFabric.Report.BarcodePrint();
            repDoc.SetDataSource(ds);
            crystalReportViewer1.ReportSource = repDoc;
            crystalReportViewer1.Dock = DockStyle.Fill;
        }
    }
}
