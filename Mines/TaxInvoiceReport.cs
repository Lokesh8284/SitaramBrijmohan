using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Data;
namespace WelcomeFabric
{
    public partial class TaxInvoiceRepor : Form
    {
        Data data = new Data();
        DataSet ds = new DataSet();
        string vv = "";
        public TaxInvoiceRepor()
        {
            InitializeComponent();
        }

        public TaxInvoiceRepor(string InvNo)
        {
            InitializeComponent();
            vv = InvNo;
        }

        private void TaxInvoiceRepor_Load(object sender, EventArgs e)
        {
            // Print();
        }

        public void Print(string Type)
        {
            SqlDataAdapter adp = new SqlDataAdapter(Data.query, data.conString);
            ds = new WelcomeFabric.Report.DataSet2();
            adp.Fill(ds, "InvoicePrint_View");
            CrystalDecisions.CrystalReports.Engine.ReportDocument repdoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            if (Type == "ALL")
            {
                repdoc = new WelcomeFabric.Report.BillPrint_New();
            }
            if (Type == "WithOutPrice")
            {
                repdoc = new WelcomeFabric.Report.BillPrint_NewQTYAmt();
            }
            if (Type == "OnlyQty")
            {
                repdoc = new WelcomeFabric.Report.BillPrint_NewOnlyQty();
            }
            if (Type == "GST")
            {
                ds = new WelcomeFabric.Report.DataSet1();
                adp.Fill(ds, "InvoicePrint");
                repdoc = new WelcomeFabric.Report.GSTBillPrint_New();
            }
            if (Type == "Label")
            { 
                repdoc = new WelcomeFabric.Report.BillPrint();
            }
            if (Type == "PDF")
            {
                ds = new WelcomeFabric.Report.DataSet1();
                adp.Fill(ds, "InvoicePrint");
                repdoc = new WelcomeFabric.Report.SupplierGSTBillPrint_New();
            }
            repdoc.SetDataSource(ds);
            crystalReportViewer1.ReportSource = repdoc;
            crystalReportViewer1.Dock = DockStyle.Fill;
            crystalReportViewer1.Show();
            if (vv != "")
            {
                string dir = Directory.GetCurrentDirectory();
                if (System.IO.Directory.Exists(dir + "/PDF") == false)
                {
                    System.IO.Directory.CreateDirectory(dir + "/PDF");
                }
                string a = dir + "/PDF/InvNo-" + vv + ".pdf";
                repdoc.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, a);
            }
            else
            {
                crystalReportViewer1.PrintReport();
            } 
        }
    }
}