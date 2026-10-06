using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WelcomeFabric;

namespace WelcomeFabric
{
    public partial class HomePage : Form
    {
        private int childFormNumber = 0;
        Data data = new Data();
        public HomePage()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            // Create a new instance of the child form.
            Form childForm = new Form();
            // Make it a child of this MDI form before showing it.
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
                // TODO: Add code here to open the file.
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
                // TODO: Add code here to save the current contents of the form to a file.
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Use System.Windows.Forms.Clipboard to insert the selected text or images into the clipboard
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Use System.Windows.Forms.Clipboard to insert the selected text or images into the clipboard
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Use System.Windows.Forms.Clipboard.GetText() or System.Windows.Forms.GetData to retrieve information from the clipboard.
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void Mines_Shown(object sender, EventArgs e)
        {
            //PnlDashboard.Visible = false;
            lblSession.Visible = false;
            lblCompanyName.Visible = false;
            lblDate.Visible = false;
            lbltime.Visible = false;
            label1.Visible = false;
            lblUserName.Visible = false;
            menuStrip.Visible = false;
            statusStrip.Visible = false;
            loginform loginrep = new loginform();
            loginrep.ShowDialog();
            if (loginrep.loginsussess)
            {
                //PnlDashboard.Visible = true;
                label1.Text = Data.Area;
                timer1.Start();
                Tm_Reload.Start();
                lblCompanyName.Text = Data.ComapnyName.ToUpper();
                lblSession.Visible = true;
                lblDate.Visible = true;
                lbltime.Visible = true;
                lblSession.Text = Data.Area;
                lblUserName.Visible = true;
                lblCompanyName.Visible = true;
                lblUserName.Text = Data.UserId;
                menuStrip.Visible = loginrep.loginsussess;
                statusStrip.Visible = loginrep.loginsussess;
                checkadmin();
                //CheckPendingOrder();
            }
        }

        private void CheckPendingOrder()
        {
            DataTable dtt = data.GetDataTable("Select * from getpendingorder where Firmid=" + Data.id);
            dgvPending.AutoGenerateColumns = false;
            dgvPending.DataSource = dtt;
        }
        string query;
        DataSet ds = new DataSet();

        private void checkadmin()
        {
            query = " select * from login where UserName='" + Data.UserId + "'";
            ds = data.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblCompanyName.Visible = true;
                lblUserName.Visible = true;
                lblCompanyName.Text = Data.ComapnyName.ToUpper();
                lblUserName.Text = Data.UserId;
                billingToolStripMenuItem.Visible = false;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            lbltime.Text = DateTime.Now.ToString("T");
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void partyMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 rep = new Form1();
            rep.ShowDialog();
        }

        private void itemMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemMaster rep = new ItemMaster();
            rep.ShowDialog();
        }

        private void partyWisePriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PriceLst rep = new PriceLst();
            rep.ShowDialog();
        }

        private void chalanFormToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void chalanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChalanForm rep = new ChalanForm("a", "Sale");
            rep.MdiParent = this;
            rep.Show();
        }

        private void billToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Billing rep = new Billing();
            rep.Show();
        }

        private void receiptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReceiptVoucher rep = new ReceiptVoucher();
            rep.Show();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void accountStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountStatus rep = new AccountStatus();
            rep.ShowDialog();
        }

        private void clientInfromationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientSearchReport rep = new ClientSearchReport();
            rep.ShowDialog();
        }

        private void pendingAmountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PendingReports rep = new PendingReports();
            rep.ShowDialog();
        }

        private void billSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BillSearchReport rep = new BillSearchReport();
            rep.ShowDialog();
        }

        private void voucherReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VoucherReport rep = new VoucherReport();
            rep.ShowDialog();
        }

        private void firmMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FirmMaster rep = new FirmMaster();
            rep.ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip.Visible = false;
            loginform loginrep = new loginform();
            loginrep.ShowDialog();
            if (loginrep.loginsussess)
            {
                label1.Text = Data.Area;
                timer1.Start();
                lblCompanyName.Text = Data.ComapnyName.ToUpper();
                lblSession.Visible = true;
                lblDate.Visible = true;
                lbltime.Visible = true;
                lblSession.Text = Data.Area;
                lblUserName.Visible = true;
                lblCompanyName.Visible = true;
                lblUserName.Text = Data.UserId;
                menuStrip.Visible = loginrep.loginsussess;
                statusStrip.Visible = loginrep.loginsussess;
                checkadmin();
            }
        }

        private void challanReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChallanDetailReport rep = new ChallanDetailReport();
            rep.ShowDialog();
        }

        private void labourMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LabourMaster rep = new LabourMaster();
            rep.ShowDialog();
        }

        private void labourRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LabourRate rep = new LabourRate();
            rep.ShowDialog();
        }

        private void priceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pricelist rep = new Pricelist();
            rep.ShowDialog();
        }

        private void sessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SessionMaster rep = new SessionMaster();
            rep.ShowDialog();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void vToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vechicle rep = new Vechicle();
            rep.ShowDialog();
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Purchase rep = new Purchase();
            //rep.ShowDialog();
        }

        private void processToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process rep = new Process();
            rep.ShowDialog();
        }

        private void transportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transport rep = new Transport();
            rep.ShowDialog();
        }

        private void purchaseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseReport rep = new PurchaseReport();
            rep.ShowDialog();
        }

        private void issueReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueReport rep = new IssueReport();
            rep.ShowDialog();
        }

        private void itemWiseSaleReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemWiseSaleReport rep = new ItemWiseSaleReport();
            rep.ShowDialog();
        }

        private void itemWiseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemWiseReport rep = new ItemWiseReport();
            rep.ShowDialog();
        }

        private void receiveReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReceiveReport rep = new ReceiveReport();
            rep.ShowDialog();
        }

        private void transportWiseSaleReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransportReport rep = new TransportReport();
            rep.ShowDialog();
        }

        private void challanReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ChallanDetailReport rep = new ChallanDetailReport();
            rep.ShowDialog();
        }

        private void saleReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaleReport rep = new SaleReport();
            rep.ShowDialog();
        }

        private void inventoryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InventoryReport rep = new InventoryReport();
            rep.ShowDialog();
        }

        private void directChallanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DirectChallan rep = new DirectChallan();
            rep.ShowDialog();
        }

        private void normalPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Purchase rep = new Purchase();
            rep.ShowDialog();
        }

        private void chaseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            RawMaterial rep = new RawMaterial();
            rep.ShowDialog();
        }

        private void deliveredMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeliveredMaster rep = new DeliveredMaster();
            rep.ShowDialog();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchVoucher rep = new SearchVoucher();
            rep.Show();
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaymentVoucher rep = new PaymentVoucher();
            rep.Show();
        }

        private void rowMaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //PaymentVoucher rep = new PaymentVoucher();
            //rep.Show();
        }

        private void purchaselPriceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //PaymentVoucher rep = new PaymentVoucher();
            //rep.Show();
        }

        private void challanReportToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ChallanDetailReport rep = new ChallanDetailReport();
            rep.ShowDialog();
        }

        private void saleStatementReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvoiceReport frm = new InvoiceReport("SALE");
            frm.ShowDialog();
        }

        private void miningRawannaReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //RawannaReport rep = new RawannaReport();
            //rep.Show();
        }

        private void transporterReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransporterReport rep = new TransporterReport();
            rep.Show();
        }

        private void itemReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemReport rep = new ItemReport();
            rep.Show();
        }

        private void inventoryReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //PaymentVoucher rep = new PaymentVoucher();
            //rep.Show();
        }

        private void Mines_Load(object sender, EventArgs e)
        {

        }

        private void bILLEDITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditBill frm = new EditBill();
            frm.Show();
        }

        private void challanReport1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChallanDetailReport1 rep = new ChallanDetailReport1();
            rep.ShowDialog();
        }

        private void rOWMARERIALToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RawMaterialNew rep = new RawMaterialNew();
            rep.ShowDialog();
        }

        private void rowMaterialRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RowMaterialRegistrationReport rep = new RowMaterialRegistrationReport();
            rep.ShowDialog();
        }

        private void rowMaterialRegisterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PurchaseRegisterReport rep = new PurchaseRegisterReport();
            rep.ShowDialog();
        }

        private void sTAFFMASTERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LabourMaster1 rep = new LabourMaster1();
            rep.ShowDialog();
        }

        private void pASSWORDCHANGEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasswordChange rep = new PasswordChange();
            rep.ShowDialog();
        }

        private void mANUALINVOICEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaualChalanForm rep = new MaualChalanForm();
            rep.ShowDialog();
        }

        private void uNITMASTERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnitMaster rep = new UnitMaster();
            rep.ShowDialog();
        }

        private void labourReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sALEREPORTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ChallanDetailReport rep = new ChallanDetailReport("Sale");
            rep.ShowDialog();
        }

        private void rawannaReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RawannaReport1 rep = new RawannaReport1();
            rep.Show();
        }

        private void miningRawannaReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RawannaReport rep = new RawannaReport();
            rep.Show();
        }

        private void saleReportToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            GSTSaleReport rep = new GSTSaleReport("S");
            rep.Show();
        }

        private void purchaseReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //GSTPurchaseReport rep = new GSTPurchaseReport();
            GSTSaleReport rep = new GSTSaleReport("P");
            rep.Show();
        }

        private void normalPurchaseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PurchaseReport1 rep = new PurchaseReport1();
            rep.Show();
        }

        private void bRANDMASTERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoryMaster frm = new CategoryMaster();
            frm.ShowDialog();
        }

        private void bACKUPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //BackupDataBase frm = new BackupDataBase();
            Databasebackup frm = new Databasebackup();
            frm.Show();
        }

        private void reportsToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void barcodePrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PricerepBarcode frm = new PricerepBarcode();
            frm.Show();
        }

        private void exportXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportXML frm = new ExportXML();
            frm.Show();
        }

        private void pURCHASEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ChalanForm rep = new ChalanForm("a", "Purchase");
            rep.ShowDialog();
        }

        private void purchaseReportToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            InvoiceReport frm = new InvoiceReport("Purchase");
            frm.ShowDialog();
        }

        private void stockRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockReport frm = new StockReport();
            frm.Show();
        }

        private void barcodeStickerPrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_BarcodePrint frm = new frm_BarcodePrint();
            frm.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ChalanForm rep = new ChalanForm("a", "Sale Return");
            rep.ShowDialog();
        }

        private void pURCHASERETURNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChalanForm rep = new ChalanForm("a", "Purchase RETURN");
            rep.ShowDialog();
        }

        private void purchaseReturnReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvoiceReport frm = new InvoiceReport("PURCHASE RETURN");
            frm.ShowDialog();
        }

        private void saleReturnReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvoiceReport frm = new InvoiceReport("SALE RETURN");
            frm.ShowDialog();
        }

        private void iTEMREPORTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ItemReport_New frm = new ItemReport_New();
            frm.ShowDialog();
        }

        private void HomePage_MdiChildActivate(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                lblCompanyName.SendToBack();
                pnlHome.SendToBack();
            }
            else
            {
                pnlHome.BringToFront();
                lblCompanyName.BringToFront();
                //Reset();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uSERMASTERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserMaster frm = new UserMaster();
            frm.MdiParent = this;
            frm.Show();
        }

        private void Tm_Reload_Tick(object sender, EventArgs e)
        {
            //CheckPendingOrder();
        }

        private void dgvPending_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvPending.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().ToUpper() == "BILL")
                {
                    string _IDD = dgvPending.Rows[e.RowIndex].Cells["OrderId"].Value.ToString();
                    MobileBill bill = new MobileBill();
                    bill.Save(_IDD);
                }
            }
        }

        private void approvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PartyApprove frm = new PartyApprove();
            frm.Show();
        }

        private void categoryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoryReport frm = new CategoryReport();
            frm.MdiParent = this;
            frm.Show();
        }

        private void appUsersDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppUserReport frm = new AppUserReport();
            frm.MdiParent = this;
            frm.Show();
        }

        private void gSTMASTERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mst_GSTMaster frm = new mst_GSTMaster();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want Delete Recored Press 'Yes' otherwise Press 'No'", "Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                data.executeCommand("Delete from tbl_GstChallan where FirmId=" + Data.id + " and eflag='S'");
                data.executeCommand("Delete from tbl_GstChallanDetails where FirmId=" + Data.id + " and eflag='S'");
                data.executeCommand("Delete from Tbl_Stock where FirmId=" + Data.id + " and type='S'");
            }
        }

        private void cLEARSALEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want Delete Recored Press 'Yes' otherwise Press 'No'", "Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                data.executeCommand("Delete from tbl_GstChallan where FirmId=" + Data.id + " and eflag='S'");
                data.executeCommand("Delete from tbl_GstChallanDetails where FirmId=" + Data.id + " and eflag='S'");
                data.executeCommand("Delete from Tbl_Stock where FirmId=" + Data.id + " and type='S'");
            }
        }
    }
}
