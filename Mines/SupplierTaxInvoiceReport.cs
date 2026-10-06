using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.Net;
namespace WelcomeFabric
{
    public partial class SupplierTaxInvoiceReport : Form
    {
        Data data = new Data();
        DataSet ds = new DataSet();
        SMS sms = new SMS();
        public SupplierTaxInvoiceReport()
        {
            InitializeComponent();
        }

        private void TaxInvoiceRepor_Load(object sender, EventArgs e)
        {
            // Print();
        }

        public void PrintSupplier()
        {
            DataSet dss = data.getDataSet(Data.query);
            DataView view = dss.Tables[0].DefaultView;
            DataTable distinctValues = view.ToTable(true, "SupplierName");

            foreach (DataRow drr in distinctValues.Rows)
            {
                view.RowFilter = " SupplierName= '" + drr["SupplierName"] + "'";
                DataTable dttt = view.ToTable();
                string _FileName = drr["SupplierName"] + " INVNO" + dttt.Rows[0]["chalanno"].ToString();
                string _MobileNO = dttt.Rows[0]["chalanno"].ToString();

                CrystalDecisions.CrystalReports.Engine.ReportDocument repdoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

                string query = Data.query;
                query += " and SupplierName= '" + drr["SupplierName"] + "'";
                DataSet dssSum = data.getDataSet(query);

                int TotalBill = Convert.ToInt32(dssSum.Tables[0].Compute("sum(SuppAmt)", string.Empty));

                Data.query1 = query;
                SqlDataAdapter adp = new SqlDataAdapter(Data.query1, data.conString);
                ds = new WelcomeFabric.Report.DataSet1();
                adp.Fill(ds, "InvoicePrint");
                repdoc = new WelcomeFabric.Report.SupplierGSTBillPrint_New();

                repdoc.SetDataSource(ds);
                crystalReportViewer1.ReportSource = repdoc;
                crystalReportViewer1.Dock = DockStyle.Fill;
                crystalReportViewer1.Show();

                string dir = Directory.GetCurrentDirectory();
                if (System.IO.Directory.Exists(dir + "/PDF") == false)
                {
                    System.IO.Directory.CreateDirectory(dir + "/PDF");
                }
                string a = dir + "/PDF/InvNo-" + _FileName + ".pdf";
                repdoc.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, a);

                string Item = "";
                for (int i = 0; i < dttt.Rows.Count; i++)
                {
                    int SNo = i + 1;
                    Item += " %0a *" + SNo + ".* " + dttt.Rows[i]["itemName"].ToString() + " (*" + dttt.Rows[i]["Qty"].ToString() + "* X" + dttt.Rows[i]["SuppPrice"].ToString() + ")";
                }
                Item += " %0a %0a *Total Bill AMount :" + TotalBill + "*";

                string message = "Dear  " + drr["SupplierName"] + " %0a Order No. *" + dttt.Rows[0]["chalanno"].ToString() + "* %0a Date *" + dttt.Rows[0]["chalandate"].ToString().Trim() + "*";
                message += "%0a Details %0a " + Item + " %0a Confirmed. SB";


                sms.SendWhatsapp(dttt.Rows[0]["SupplierMobName"].ToString(), message);
            }
        }

        public void PrintCustmer()
        {
            DataSet dss = data.getDataSet(Data.query);
            DataTable dttt = dss.Tables[0];
            string _FileName = dttt.Rows[0]["chalanno"].ToString();

            int TotalWages = Convert.ToInt32(dttt.Rows[0]["TotalWages"]);
            int NetBill = Convert.ToInt32(dttt.Rows[0]["totalamt"]);
            int TotalBill = Convert.ToInt32(dttt.Rows[0]["TotalTaxAmt"]);


            CrystalDecisions.CrystalReports.Engine.ReportDocument repdoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

            SqlDataAdapter adp = new SqlDataAdapter(Data.query, data.conString);
            ds = new WelcomeFabric.Report.DataSet2();
            adp.Fill(ds, "InvoicePrint_View");
            repdoc = new WelcomeFabric.Report.BillPrint_NewQTYAmt();

            repdoc.SetDataSource(ds);
            crystalReportViewer1.ReportSource = repdoc;
            crystalReportViewer1.Dock = DockStyle.Fill;
            crystalReportViewer1.Show();

            string dir = Directory.GetCurrentDirectory();
            if (System.IO.Directory.Exists(dir + "/PDF") == false)
            {
                System.IO.Directory.CreateDirectory(dir + "/PDF");
            }
            string a = dir + "/PDF/InvNo-" + _FileName + ".pdf";
            repdoc.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, a);
            UploadFileToFTP("InvNo-" + _FileName + ".pdf", a);
            string Item = "";
            for (int i = 0; i < dttt.Rows.Count; i++)
            {
                int SNo = i + 1;
                Item += " %0a *" + SNo + ".* " + dttt.Rows[i]["itemName"].ToString() + " (*" + dttt.Rows[i]["Qty"].ToString() + "* X" + dttt.Rows[i]["Price"].ToString() + ")";
            }
            Item += " %0a %0a *Total Amount :" + TotalBill + "*";
            Item += " %0a %0a *Wages :" + TotalWages + "*";
            Item += " %0a %0a *Net AMount :" + NetBill + "*";

            string message = "Dear  " + dttt.Rows[0]["Name"].ToString() + " %0a Order No. *" + dttt.Rows[0]["chalanno"].ToString() + "* %0a Date *" + dttt.Rows[0]["chalandate"].ToString().Trim() + "*";
            message += "%0a Details %0a " + Item + " %0a Confirmed. SB";



            //sms.SendWhatsapp(dttt.Rows[0]["Mob"].ToString(), message);
            sms.SendWhatsappPDF(dttt.Rows[0]["Mob"].ToString(), "InvNo" + _FileName, "InvNo-" + _FileName + ".pdf");

        }

        public void UploadFileToFTP(string Name, string _Path)
        {
            try
            {

                DataTable DtFTP = data.GetDataTable("select * from tbl_FTP where Delid=0");
                string FIlePath = DtFTP.Rows[0]["FtpPath"].ToString();
                string ftpusername = DtFTP.Rows[0]["FtpUser"].ToString();
                string ftppassword = DtFTP.Rows[0]["FtpPWd"].ToString();
                string ftpurl = @"ftp://" + DtFTP.Rows[0]["Ftp"].ToString();

                string _FIleName = ftpurl + "/PDF/" + Name;

                FtpWebRequest ftpClient = (FtpWebRequest)FtpWebRequest.Create(_FIleName);
                ftpClient.Credentials = new System.Net.NetworkCredential(ftpusername, ftppassword);
                ftpClient.Method = System.Net.WebRequestMethods.Ftp.UploadFile;
                ftpClient.UseBinary = true;
                ftpClient.KeepAlive = true;
                System.IO.FileInfo fi = new System.IO.FileInfo(@"" + _Path);
                ftpClient.ContentLength = fi.Length;
                byte[] buffer = new byte[4097];
                int bytes = 0;
                int total_bytes = (int)fi.Length;
                System.IO.FileStream fs = fi.OpenRead();
                System.IO.Stream rs = ftpClient.GetRequestStream();
                while (total_bytes > 0)
                {
                    bytes = fs.Read(buffer, 0, buffer.Length);
                    rs.Write(buffer, 0, bytes);
                    total_bytes = total_bytes - bytes;
                }
                //fs.Flush();
                fs.Close();
                rs.Close();
                FtpWebResponse uploadResponse = (FtpWebResponse)ftpClient.GetResponse();
                //value = uploadResponse.StatusDescription;
                uploadResponse.Close();
                File.Delete(_Path);
            }
            catch
            { }
        }
        public void PrintOwner()
        {
            DataSet dss = data.getDataSet(Data.query);
            DataTable dttt = dss.Tables[0];
            string _FileName = dttt.Rows[0]["chalanno"].ToString() + " INV NO" + dttt.Rows[0]["chalanno"].ToString();

            int TotalWages = Convert.ToInt32(dttt.Rows[0]["TotalWages"]);
            int TotalBill = Convert.ToInt32(dttt.Rows[0]["GstBeforeAmt"]);
            int Supplier = Convert.ToInt32(dttt.Rows[0]["TotalSuppAmt"]);
            int NetBill = Convert.ToInt32(dttt.Rows[0]["totalamt"]);
            int Profit = NetBill - Supplier;


            CrystalDecisions.CrystalReports.Engine.ReportDocument repdoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

            SqlDataAdapter adp = new SqlDataAdapter(Data.query, data.conString);
            ds = new WelcomeFabric.Report.DataSet1();
            adp.Fill(ds, "InvoicePrint");
            repdoc = new WelcomeFabric.Report.SupplierGSTBillPrint_New();

            repdoc.SetDataSource(ds);
            crystalReportViewer1.ReportSource = repdoc;
            crystalReportViewer1.Dock = DockStyle.Fill;
            crystalReportViewer1.Show();

            string dir = Directory.GetCurrentDirectory();
            if (System.IO.Directory.Exists(dir + "/PDF") == false)
            {
                System.IO.Directory.CreateDirectory(dir + "/PDF");
            }
            string a = dir + "/PDF/Inv No-" + _FileName + ".pdf";
            repdoc.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, a);

            string Item = "";
            for (int i = 0; i < dttt.Rows.Count; i++)
            {
                int SNo = i + 1;
                Item += " %0a *" + SNo + ".* " + dttt.Rows[i]["itemName"].ToString() + " (*" + dttt.Rows[i]["Qty"].ToString() + "* X" + dttt.Rows[i]["Price"].ToString() + ")";
            }
            Item += " %0a %0a *Total Amount :" + TotalBill + "*";
            Item += " %0a %0a *Wages :" + TotalWages + "*";
            Item += " %0a %0a *Customer Amount :" + NetBill + "*";
            Item += " %0a %0a *Supplier Amount :" + Supplier + "*";
            Item += " %0a %0a *Profit :" + Profit + "*";

            string message = "Dear  " + dttt.Rows[0]["Name"].ToString() + " %0a Order No. *" + dttt.Rows[0]["chalanno"].ToString() + "* %0a Date *" + dttt.Rows[0]["chalandate"].ToString().Trim() + "*";
            message += "%0a Details %0a " + Item + " %0a %0a Confirmed. SB";


            sms.SendWhatsapp(dttt.Rows[0]["m1"].ToString(), message);
        }

    }
}