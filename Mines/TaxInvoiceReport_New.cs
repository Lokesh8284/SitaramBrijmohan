using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Data;
namespace WelcomeFabric
{
    public partial class TaxInvoiceReport_New : Form
    {
        CrystalDecisions.CrystalReports.Engine.ReportDocument RepDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        DataTable dt = new DataTable();
        Data data = new Data();
        DataSet ds = new WelcomeFabric.Report.DataSet1();
        string vv = "";
        string query = "";
        string _Type = "";
        string _TableName = "", _TableName2 = "", _TableName3 = "";
        string reportType = "";
        public TaxInvoiceReport_New()
        {
            InitializeComponent();
        }

        public TaxInvoiceReport_New(string InvNo)
        {
            InitializeComponent();
            vv = InvNo;
        }

        private void TaxInvoiceRepor_Load(object sender, EventArgs e)
        {
            if (_Type == "ALL")
            {
                RepDoc = new WelcomeFabric.Report.BillPrint_New();
            }
            if (_Type == "WithOutPrice")
            { 
                RepDoc = new WelcomeFabric.Report.BillPrint_NewQTYAmt();
            }
            if (_Type == "OnlyQty")
            {
                //RepDoc = new WelcomeFabric.Report.BillPrint_NewOnlyQty(); 
                RepDoc = new WelcomeFabric.Report.BillPrintonlyQty();

            }
            if (_Type == "GST")
            { 
                RepDoc = new WelcomeFabric.Report.GSTBillPrint_New();
            }
            if (_Type == "Label")
            { 
                RepDoc = new WelcomeFabric.Report.BillPrint();
            }
            if (_Type == "PDF")
            { 
                RepDoc = new WelcomeFabric.Report.SupplierGSTBillPrint_New();
            }
            ds.Tables[_TableName].Merge(dt);
            RepDoc.SetDataSource(ds);
            crystalReportViewer1.ReportSource = RepDoc;
            crystalReportViewer1.Dock = DockStyle.Fill;
        }

        public TaxInvoiceReport_New(DataTable dt, string _Type, string TableName )
        {
            InitializeComponent();
            this.dt = dt;
            this._TableName = TableName; 
            this._Type = _Type;
        } 
    }
}