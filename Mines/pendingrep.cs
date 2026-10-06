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
    public partial class pendingrep : Form
    {
        Data data = new Data();
        public pendingrep()
        {
            InitializeComponent();
        }

        private void pendingrep_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adp = new SqlDataAdapter(Data.query, data.conString);
            WelcomeFabric.Report.DataSet2 ds = new WelcomeFabric.Report.DataSet2();
            adp.Fill(ds, "tblldg");
            for (int i = 0; i < ds.Tables["tblldg"].Rows.Count; i++)
            {
                try
                {
                    ds.Tables["tblldg"].Rows[i]["BillAmt1"] = Data.receiptAmt;
                }
                catch
                { }
                ds.Tables["tblldg"].Rows[i]["PreDrCr"] = Data.Area;
               ds.Tables["tblldg"].Rows[i]["Pendingamt"] = Data.BillingAmt;
            }
            SqlDataAdapter adp1 = new SqlDataAdapter(Data.query1, data.conString);
            WelcomeFabric.Report.DataSet2 ds1 = new WelcomeFabric.Report.DataSet2();
            adp1.Fill(ds, "tblldg1");

           
            CrystalDecisions.CrystalReports.Engine.ReportDocument repdoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            repdoc = new WelcomeFabric.Report.AccountStatus();
            repdoc.SetDataSource(ds);
            crystalReportViewer1.ReportSource = repdoc;
            crystalReportViewer1.Dock = DockStyle.Fill;
        }
    }
}