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
    public partial class Billrep : Form
    {
        Data data = new Data();
        public Billrep()
        {
            InitializeComponent();
        }
       
        private void Billrep_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter(Data.query, data.conString);
             WelcomeFabric.Report.DataSet2 ds = new WelcomeFabric.Report.DataSet2();
             adp.Fill(ds, "InvoicePrint");
        
            CrystalDecisions.CrystalReports.Engine.ReportDocument repdoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            repdoc = new WelcomeFabric.Report.BillPrint();
            repdoc.SetDataSource(ds);
            crystalReportViewer1.ReportSource = repdoc;
            crystalReportViewer1.Dock = DockStyle.Fill;
        }
    }
}