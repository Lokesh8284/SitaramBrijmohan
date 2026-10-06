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
    public partial class TaxInvoiceReportTransport : Form
    {
        Data data = new Data();
        public TaxInvoiceReportTransport()
        {
            InitializeComponent();
        }

        private void TaxInvoiceRepor_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter(Data.query, data.conString);
            WelcomeFabric.Report.DataSet2 ds = new WelcomeFabric.Report.DataSet2();
            adp.Fill(ds, "TaxInvoice");
            CrystalDecisions.CrystalReports.Engine.ReportDocument repdoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument(); 
            repdoc = new WelcomeFabric.Report.TaxInvoiceReport4Transport_New(); 
            repdoc.SetDataSource(ds); 
            crystalReportViewer1.ReportSource = repdoc; 
          crystalReportViewer1.Dock = DockStyle.Fill;
        }
    }
}