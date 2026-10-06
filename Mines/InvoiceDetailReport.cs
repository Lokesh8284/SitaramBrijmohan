using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq;
using WelcomeFabric;
using System.IO;

namespace WelcomeFabric
{
    public partial class InvoiceReport : Form
    {
        #region Declaration
        Data data = new Data();
        DataSet ds1 = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        string query;
        double totAmt1 = 0;
        string _type = "";
        string _FormName = "";
        string _Header = "";
        #endregion

        #region Initialization
        public InvoiceReport()
        {
            InitializeComponent();
        }
        public InvoiceReport(string FormName)
        {
            InitializeComponent();
            _FormName = FormName;
            if (FormName.ToUpper() == "SALE")
            {
                _type = "S";
            }
            if (FormName.ToUpper() == "PURCHASE")
            {
                _type = "P";
            }
            if (FormName.ToUpper() == "SALE RETURN")
            {
                _type = "SR";
            }
            if (FormName.ToUpper() == "PURCHASE RETURN")
            {
                _type = "PR";
            }
            _Header = FormName.ToUpper();
            this.tabPage1.Text = this.lblHeaderDetails.Text = _Header + " DETAILS REPORT";
            this.tabPage2.Text = this.lblHeaderSummary.Text = _Header + " SUMMARY REPORT";

        }
        #endregion

        #region Control and Events

        private void ChallanDetailReport_Load(object sender, EventArgs e)
        {
            if (_type == "S")
            {
                CreateTableSale();
            }
            else
            {
                CreateTablePur();
            }
            label19.Text = Data.Area;
            fillpartyname(); 
            fillitemname();
            drpOrderType.SelectedIndex = 0;
            drpcreate.SelectedIndex = 1;
            btnClose2.Click += new EventHandler(btnClose2_Click);
        }


        public void CreateTableSale()
        {
            DataColumn c1 = new DataColumn("Date", typeof(string));
            DataColumn c12 = new DataColumn("DateAdd", typeof(string));
            DataColumn c2 = new DataColumn("CLientName", typeof(string));
            DataColumn c3 = new DataColumn("VoucherType", typeof(string));
            DataColumn c4 = new DataColumn("VchNo", typeof(double));
            DataColumn c5 = new DataColumn("GSTIN", typeof(string));
            DataColumn c6 = new DataColumn("NetTotal", typeof(double));
            DataColumn c8 = new DataColumn("CGST", typeof(double));
            DataColumn c9 = new DataColumn("SGST", typeof(double));
            DataColumn c7 = new DataColumn("SaleGST", typeof(double));
            DataColumn c10 = new DataColumn("SaleIGST", typeof(double));
            DataColumn c11 = new DataColumn("IGST", typeof(double));
            DataColumn c14 = new DataColumn("FirmName", typeof(string));
            DataColumn c13 = new DataColumn("FirmAddress", typeof(string));

            dt.Columns.Add(c1);
            dt.Columns.Add(c2);
            dt.Columns.Add(c3);
            dt.Columns.Add(c4);
            dt.Columns.Add(c5);
            dt.Columns.Add(c6);
            dt.Columns.Add(c7);
            dt.Columns.Add(c10);
            dt.Columns.Add(c8);
            dt.Columns.Add(c9);
            dt.Columns.Add(c11);
            dt.Columns.Add(c12);
            dt.Columns.Add(c13);
            dt.Columns.Add(c14);
        }

        public void CreateTablePur()
        {
            DataColumn c1 = new DataColumn("Date", typeof(string));
            DataColumn c12 = new DataColumn("DateAdd", typeof(string));
            DataColumn c2 = new DataColumn("CLientName", typeof(string));
            DataColumn c3 = new DataColumn("VoucherType", typeof(string));
            DataColumn c4 = new DataColumn("VchNo", typeof(double));
            DataColumn c5 = new DataColumn("GSTIN", typeof(string));
            DataColumn c6 = new DataColumn("NetTotal", typeof(double));
            DataColumn c8 = new DataColumn("CGST", typeof(double));
            DataColumn c9 = new DataColumn("SGST", typeof(double));
            DataColumn c7 = new DataColumn("PurGST", typeof(double));
            DataColumn c10 = new DataColumn("PurIGST", typeof(double));
            DataColumn c11 = new DataColumn("IGST", typeof(double));
            DataColumn c14 = new DataColumn("FirmName", typeof(string));
            DataColumn c13 = new DataColumn("FirmAddress", typeof(string));

            dt.Columns.Add(c1);
            dt.Columns.Add(c2);
            dt.Columns.Add(c3);
            dt.Columns.Add(c4);
            dt.Columns.Add(c5);
            dt.Columns.Add(c6);
            dt.Columns.Add(c7);
            dt.Columns.Add(c10);
            dt.Columns.Add(c8);
            dt.Columns.Add(c9);
            dt.Columns.Add(c11);
            dt.Columns.Add(c12);
            dt.Columns.Add(c13);
            dt.Columns.Add(c14);
        }

        void btnClose2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Data.query = query;
            PrintPreview rep = new PrintPreview();
            WelcomeFabric.Report.InvoiceDetailReportSingle reps = new WelcomeFabric.Report.InvoiceDetailReportSingle();
            SqlDataAdapter adp = new SqlDataAdapter(Data.query, data.conString);
            WelcomeFabric.Report.DataSet1 ds = new WelcomeFabric.Report.DataSet1();
            adp.Fill(ds, "GetGSTInvoiceDetailsReport");
            reps.SetDataSource(ds);
            rep.crystalReportViewer1.ReportSource = reps;
            rep.crystalReportViewer1.Dock = DockStyle.Fill;
            rep.ShowDialog();
        }

        private void drpPatientId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                this.ProcessTabKey(true);
            }
        }

        private void btnSearch2_Click(object sender, EventArgs e)
        {
            GetChallanSummaryReport();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetChallanReport();
        }
        #endregion

        #region Bind Functions


        public void fillitemname()
        {
            query = " select itemid, (cast(ItemCode as nvarchar(50))+' - '+upper(itemname)) itemname from tblitem where delid=0 and firmid=" + Data.id + "  order by ItemCode";
            //query = " select * from tblitem where firmid=" + Data.id + " order by itemname";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["itemid"] = "0";
            newrow["itemname"] = "---Select Item Name----";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                drpbrand.DataSource = ds.Tables[0];
                drpbrand.ValueMember = "itemid";
                drpbrand.DisplayMember = "itemname";
            }
            else
            {
                drpbrand.SelectedIndex = 0;
            }


        }
        public void fillpartyname()
        {
            query = " select * from tblclient";
            query += " where  firmid=" + Data.id + " ORDER BY compname";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["id"] = "0";
            newrow["compname"] = "---Select Party Name----";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            drpPatientId.DataSource = ds.Tables[0];
            drpPatientId.DisplayMember = "compname";
            drpPatientId.ValueMember = "id";

            //summary
            cmbClientName.DataSource = ds.Tables[0];
            cmbClientName.DisplayMember = "compname";
            cmbClientName.ValueMember = "id";
        }
        public void BindUsers()
        {
            query = " select * from tbl_User";
            query += " where  firmid=" + Data.id + " ORDER BY UserName";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["id"] = "0";
            newrow["UserName"] = "---Select User Name----";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            cmbUser.DataSource = ds.Tables[0];
            cmbUser.DisplayMember = "UserName";
            cmbUser.ValueMember = "id";

            //summary
            cmbUserName.DataSource = ds.Tables[0];
            cmbUserName.DisplayMember = "UserName";
            cmbUserName.ValueMember = "id";

        }

        #endregion

        #region User Functions
        int aaaa = 0;
        int aaaa1 = 0;
        public void GetChallanReport()
        {
            #region Comment
            //query = "GetInvoice " + Data.id + "," + Data.sessionid + "";
            //query = "GetGSTInvoiceDetailsReport " + Data.id + "," + Data.sessionid + "";

            //query = " SELECT   tbl_GstChallanDetails.chalanno, tbl_User.Name as UserName, tblsession.session, tbl_GstChallanDetails.IGST, tbl_GstChallanDetails.SGST, ";
            //query += " tbl_GstChallanDetails.CGST, tbl_GstChallanDetails.CGSTAmount, tbl_GstChallanDetails.SGSTAmount, tblitem.itemname, ";
            //query += " tbl_GstChallanDetails.TaxableValue, tbl_GstChallanDetails.GrossTotal, tbl_GstChallanDetails.Discount, ";
            //query += " tbl_GstChallanDetails.IGSTAmount, tbl_GstChallanDetails.ravanano, tbl_GstChallanDetails.amount, tbl_GstChallanDetails.qty,  ";
            //query += " tbl_GstChallanDetails.price, tblitem.itemname,  Convert(char(11),tbl_GstChallanDetails.chalandate,103) AS chalandate, ";
            //query += " tbl_GstChallanDetails.Unit, tblclient.compname as PartyName FROM tbl_GstChallan INNER JOIN ";
            //query += " tbl_GstChallanDetails ON tbl_GstChallan.MaxId = tbl_GstChallanDetails.MaxId INNER JOIN ";
            //query += " tblsession ON tbl_GstChallanDetails.sessionid = tblsession.sessionid INNER JOIN ";
            //query += " tblfirm ON tbl_GstChallanDetails.firmid = tblfirm.firmid INNER JOIN ";
            //query += " tblitem ON tbl_GstChallanDetails.itemid = tblitem.itemid INNER JOIN ";
            //query += " tblclient ON tbl_GstChallanDetails.clientid = tblclient.id left JOIN  tbl_User on tbl_User.id=tbl_GstChallan.uid ";
            //query += "  WHERE  tbl_GstChallanDetails.firmid=" + Data.id + "  and tbl_GstChallanDetails.sessionid=" + Data.sessionid + "";
            #endregion
            DataSet dsfirm = data.getDataSet("select * from tblfirm where firmid=" + Data.id);
            query = "select * from InvoiceDetailReport_View where EFlag='" + _type + "' and [GCD.EFlag] ='" + _type + "' and delid=0 and firmid=" + Data.id + " and GCDfirmid=" + Data.id + " and sessionid=" + Data.sessionid + "";

            #region Filters
            if (drpPatientId.SelectedIndex > 0)
            {
                query += "and clientid=" + drpPatientId.SelectedValue + "";
            }
            if (drpbrand.SelectedIndex > 0)
            {
                query += "and itemid=" + drpbrand.SelectedValue + "";
            }
            if (txtBillNo.Text.Trim() != "")
            {
                query += "and chalanno =" + txtBillNo.Text + "";
            }
            if (cmbUser.SelectedIndex > 0)
            {
                //query += " and tbl_User.ID = " + cmbUser.SelectedValue + "";
            }
            if (dateTimePicker1.Checked == true && dateTimePicker2.Checked == true)
            {
                //query += " and CONVERT(date,chalandate) between '" + data.getDateMMDDYYYY(dateTimePicker1.Text) + "' and   '" + data.getDateMMDDYYYY(dateTimePicker2.Text) + "'";
                query += " and cast(chalandate as date)   between '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' and   '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "'";
            }
            query += " ORDER BY  chalanno ";

            string dd = dateTimePicker1.Text + " to " + dateTimePicker2.Text;
            #endregion

            ds1 = data.getDataSet(query);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                grdTest.Rows.Clear();
                totAmt1 = 0;
                txttotwt.Text = "0";
                txtTotAmt.Text = "";
                foreach (DataRow dr in ds1.Tables[0].Rows)
                {
                    grdTest.Rows.Add();
                    int currow = grdTest.Rows.Count - 1;
                    grdTest.Rows[currow].Cells["sno"].Value = currow + 1;
                    grdTest.Rows[currow].Cells["BillNo"].Value = dr["chalanno"].ToString();
                    grdTest.Rows[currow].Cells["BillDate"].Value = dr["Date"].ToString();
                    grdTest.Rows[currow].Cells["PartyName"].Value = dr["PartyName"].ToString();
                    grdTest.Rows[currow].Cells["ItemName"].Value = dr["ItemName"].ToString();
                    grdTest.Rows[currow].Cells["Qty"].Value = dr["Qty"].ToString();
                    grdTest.Rows[currow].Cells["Price"].Value = dr["Price"].ToString();
                    grdTest.Rows[currow].Cells["Amount"].Value = dr["Amount"].ToString();
                    //grdTest.Rows[currow].Cells["UserName"].Value = dr["UserName"].ToString();
                    grdTest.Rows[currow].Cells["Unit"].Value = dr["Unit"].ToString();
                    grdTest.Rows[currow].Cells["IGST"].Value = dr["IGST"].ToString();
                    grdTest.Rows[currow].Cells["SGST"].Value = dr["SGST"].ToString();
                    grdTest.Rows[currow].Cells["CGST"].Value = dr["CGST"].ToString();
                    grdTest.Rows[currow].Cells["CGSTAmt"].Value = dr["CGSTAmount"].ToString();
                    grdTest.Rows[currow].Cells["SGSTAmt"].Value = dr["SGSTAmount"].ToString();
                    grdTest.Rows[currow].Cells["TaxableValue"].Value = dr["TaxableValue"].ToString();
                    grdTest.Rows[currow].Cells["Total"].Value = dr["GrossTotal"].ToString();
                    grdTest.Rows[currow].Cells["Discount1"].Value = dr["Discount"].ToString();
                    grdTest.Rows[currow].Cells["IGSTAmt"].Value = dr["IGSTAmount"].ToString();
                    grdTest.Rows[currow].Cells["RAWANA"].Value = dr["ravanano"].ToString();

                    #region Comment
                    //if (_type == "S")
                    //{
                    //    dt.Rows.Add();
                    //    dt.Rows[currow]["FirmName"] = dsfirm.Tables[0].Rows[0]["Name"].ToString();
                    //    dt.Rows[currow]["FirmAddress"] = dsfirm.Tables[0].Rows[0]["Address"].ToString();
                    //    dt.Rows[currow]["DateAdd"] = dd;
                    //    dt.Rows[currow]["Date"] = dr["chalandate"].ToString();
                    //    dt.Rows[currow]["CLientName"] = dr["PartyName"].ToString(); ;
                    //    dt.Rows[currow]["VoucherType"] = "Sale";
                    //    dt.Rows[currow]["VchNo"] = dr["chalanno"].ToString();
                    //    dt.Rows[currow]["GSTIN"] = dr["GstNo"].ToString();
                    //    dt.Rows[currow]["NetTotal"] = dr["Amount"].ToString();

                    //    if (ds.Tables[0].Rows[currow]["CGSTAmount"].ToString() == "0")
                    //    {
                    //        dt.Rows[currow]["SaleIGST"] = ds.Tables[0].Rows[currow]["ServiceTaxAmount"].ToString();
                    //        dt.Rows[currow]["IGST"] = ds.Tables[0].Rows[currow]["TotalIGST"].ToString();
                    //    }
                    //    else
                    //    {
                    //        dt.Rows[currow]["SaleGST"] = ds.Tables[0].Rows[currow]["ServiceTaxAmount"].ToString();
                    //        dt.Rows[currow]["SGST"] = dr["CGSTAmount"].ToString();
                    //        dt.Rows[currow]["CGST"] = dr["CGSTAmount"].ToString();
                    //    }
                    //}
                    //if (_type == "P")
                    //{
                    //    dt.Rows.Add();
                    //    dt.Rows[currow]["FirmName"] = dsfirm.Tables[0].Rows[0]["Name"].ToString();
                    //    dt.Rows[currow]["FirmAddress"] = dsfirm.Tables[0].Rows[0]["Address"].ToString();
                    //    dt.Rows[currow]["DateAdd"] = ds.Tables[0].Rows[currow]["Date12"].ToString();
                    //    dt.Rows[currow]["Date"] = ds.Tables[0].Rows[currow]["dddate"];
                    //    dt.Rows[currow]["CLientName"] = ds.Tables[0].Rows[currow]["clientname"].ToString();
                    //    dt.Rows[currow]["VoucherType"] = "Purchase";
                    //    dt.Rows[currow]["VchNo"] = ds.Tables[0].Rows[currow]["Invoicenum"].ToString();
                    //    dt.Rows[currow]["GSTIN"] = ds.Tables[0].Rows[currow]["GSTNo"].ToString();
                    //    dt.Rows[currow]["NetTotal"] = ds.Tables[0].Rows[currow]["NetAmount"].ToString();

                    //    if (ds.Tables[0].Rows[currow]["TotalSGST"].ToString() == "0")
                    //    {
                    //        dt.Rows[currow]["PurIGST"] = ds.Tables[0].Rows[currow]["ServiceTaxAmount"].ToString();
                    //        dt.Rows[currow]["IGST"] = ds.Tables[0].Rows[currow]["TotalIGST"].ToString();
                    //    }
                    //    else
                    //    {
                    //        dt.Rows[currow]["SaleGST"] = ds.Tables[0].Rows[currow]["ServiceTaxAmount"].ToString();
                    //        dt.Rows[currow]["SGST"] = ds.Tables[0].Rows[currow]["TotalSGST"].ToString();
                    //        dt.Rows[currow]["CGST"] = ds.Tables[0].Rows[currow]["TotalCGST"].ToString();
                    //    }
                    //}
                    #endregion
                    aaaa++;
                    aaaa1++;
                }
                calcTotal();
            }

            else
            {
                grdTest.Rows.Clear();
                MessageBox.Show("Record Not Found");
            }
        }

        public void GetChallanSummaryReport()
        {
            grdTest1.Rows.Clear();
            query = "select * from InvoiceSummaryReport_View where EFlag='" + _type + "' and Delid=0 and firmid=" + Data.id + " and sessionid=" + Data.sessionid + "";


            #region Filters
            if (cmbClientName.SelectedIndex > 0)
            {
                query += " and clientid= " + cmbClientName.SelectedValue + "";
            }
            if (txtBillNo2.Text.Trim() != "")
            {
                query += " and InvoiceNo =" + txtBillNo2.Text + "";
            }
            if (cmbUser.SelectedIndex > 0)
            {
                query += " and UID = " + cmbUser.SelectedValue + "";
            }
            if (dtpFrom.Checked == true && dtpTo.Checked == true)
            {
                query += " and CONVERT(date,InvoiceDate) between '" + data.getDateMMDDYYYY(dtpFrom.Text) + "' and   '" + data.getDateMMDDYYYY(dtpTo.Text) + "'";
            }
            if (drpOrderType.SelectedIndex > 0)
            {
                string _GenerateBy = (drpOrderType.Text == "Online") ? "W" : "Computer";
                query += " and GenerateBy='" + _GenerateBy + "'";
            }
            query += " ORDER BY InvoiceNo ";
            #endregion

            ds1 = data.getDataSet(query);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                grdTest1.Rows.Clear();
                totAmt1 = 0;
                txttotwt.Text = "0";
                txtTotAmt.Text = "";
                foreach (DataRow dr in ds1.Tables[0].Rows)
                {
                    grdTest1.Rows.Add();
                    int currow = grdTest1.Rows.Count - 1;
                    grdTest1.Rows[currow].Cells["sno1"].Value = currow + 1;
                    grdTest1.Rows[currow].Cells["BillNo1"].Value = dr["InvoiceNo"].ToString();
                    grdTest1.Rows[currow].Cells["BillDate2"].Value = dr["Date"].ToString();
                    grdTest1.Rows[currow].Cells["PartyName1"].Value = dr["ClientName"].ToString();
                    grdTest1.Rows[currow].Cells["TotalAmount"].Value = dr["GstBeforeAmt"].ToString();
                    grdTest1.Rows[currow].Cells["SGST1"].Value = dr["AddSGSTAmt"].ToString();
                    grdTest1.Rows[currow].Cells["CGST1"].Value = dr["AddCGSTAmt"].ToString();
                    grdTest1.Rows[currow].Cells["IGST1"].Value = dr["AddIGSTAmt"].ToString();
                    grdTest1.Rows[currow].Cells["NetAmount"].Value = dr["NetAmount"].ToString();
                    //grdTest1.Rows[currow].Cells["UserName1"].Value = dr["UserName"].ToString();
                    grdTest1.Rows[currow].Cells["View"].Value = "View";
                    grdTest1.Rows[currow].Cells["Edit"].Value = "Edit";
                    grdTest1.Rows[currow].Cells["Delete"].Value = "Delete";
                    grdTest1.Rows[currow].Cells["ChalanId"].Value = dr["chalid"].ToString();
                    grdTest1.Rows[currow].Cells["PaymentMode"].Value = dr["PaymentMode"].ToString();
                }
                calcTotal();
            }
            else
            {
                grdTest.Rows.Clear();
                MessageBox.Show("Record Not Found");
            }
        }

        void calcTotal()
        {
            txtAfterTax.Text = grdTest.Rows.Cast<DataGridViewRow>().Sum(d => Convert.ToDouble(d.Cells["Total"].Value)).ToString("0.00");
            txtAmtbTax.Text = grdTest.Rows.Cast<DataGridViewRow>().Sum(d => Convert.ToDouble(d.Cells["TaxableValue"].Value)).ToString("0.00");
            txtAfterTax1.Text = grdTest1.Rows.Cast<DataGridViewRow>().Sum(d => Convert.ToDouble(d.Cells["NetAmount"].Value)).ToString("0.00");
            txtAmtbTax1.Text = grdTest1.Rows.Cast<DataGridViewRow>().Sum(d => Convert.ToDouble(d.Cells["TotalAmount"].Value)).ToString("0.00");
        }
        #endregion

        private void btnPrint2_Click(object sender, EventArgs e)
        {
            Data.query = query;
            PrintPreview rep = new PrintPreview();
            WelcomeFabric.Report.InvoiceSummaryReport reps = new WelcomeFabric.Report.InvoiceSummaryReport();
            SqlDataAdapter adp = new SqlDataAdapter(Data.query, data.conString);
            WelcomeFabric.Report.DataSet1 ds = new WelcomeFabric.Report.DataSet1();
            adp.Fill(ds, "InvoiceSummaryReport");
            reps.SetDataSource(ds);
            rep.crystalReportViewer1.ReportSource = reps;
            rep.crystalReportViewer1.Dock = DockStyle.Fill;
            rep.ShowDialog();
        }

        private void grdTest1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string query1;
            if (e.RowIndex >= 0)
            {
                if (grdTest1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "View")
                {
                    query1 = "select * from InvoicePrint_View where chalid=" + grdTest1.Rows[e.RowIndex].Cells["ChalanId"].Value.ToString() + " and firmid=" + Data.id + "   and sessionid=" + Data.sessionid + "  order by chalnid";
                    Data.query = query1;
                    //TaxInvoiceRepor rep = new TaxInvoiceRepor();
                    //rep.Print("ALL");
                    //rep.Show();
                    CustomMsg frm = new CustomMsg();
                    frm.Show();
                }
                if (grdTest1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Edit")
                {
                    string ss = grdTest1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    ChalanForm ch = new ChalanForm(ss, _FormName);
                    ch.Show();
                }
                if (grdTest1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Delete")
                {
                    string ss = grdTest1.Rows[e.RowIndex].Cells["ChalanId"].Value.ToString();
                    if (MessageBox.Show("Do you want Delete Recored Press 'Yes' otherwise Press 'No'", "Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SqlConnection myConnection = new SqlConnection(data.conString);
                        myConnection.Open();

                        SqlCommand cmd = myConnection.CreateCommand();
                        SqlTransaction myTrans;
                        myTrans = myConnection.BeginTransaction();
                        try
                        {
                            this.Cursor = Cursors.WaitCursor;

                            cmd.Connection = myConnection;
                            cmd.Transaction = myTrans;
                            cmd.CommandText = " Update tbl_GstChallanDetails set delid=1 where EFlag='" + _type + "' and firmid=" + Data.id + " and MainId =" + ss + " and sessionid=" + Data.sessionid + " ";
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = " update tbl_GstChallan set delid=1 where EFlag='" + _type + "' and firmid=" + Data.id + " and chalid=" + ss + " and sessionid=" + Data.sessionid + " ";
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = " update tblldg set delid=1 where type='" + _type + "' and firmid=" + Data.id + " and MainId=" + ss + " and sessionid=" + Data.sessionid + " ";
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = " update Tbl_Stock set delid=1 where type='" + _type + "' and Firmid=" + Data.id + " and MainId=" + ss + "";
                            cmd.ExecuteNonQuery();

                            myTrans.Commit();
                            MessageBox.Show("Record Delete Successfully");
                            GetChallanSummaryReport();
                        }
                        catch (Exception ee)
                        {
                            try
                            {
                                myTrans.Rollback();
                            }
                            catch (SqlException ex)
                            {
                                int code = ex.ErrorCode;
                            }
                            MessageBox.Show("Check Your Entry...");
                        }
                        finally
                        {
                            this.Cursor = Cursors.Default;
                            myConnection.Close();
                        }
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ExportXML frm = new ExportXML();
            frm.Show();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (grdTest1.Rows.Count > 0)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    foreach (DataGridViewRow drr in grdTest1.Rows)
                    {
                        Data.query = "select * from InvoicePrint_View where MaxId=" + drr.Cells["BillNo1"].Value.ToString() + " and firmid=" + Data.id + "   and sessionid=" + Data.sessionid + "  order by chalnid";
                        TaxInvoiceRepor rep = new TaxInvoiceRepor(drr.Cells["BillNo1"].Value.ToString());
                        rep.Print("ALL");
                    }
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("All Invoice Export.");
                    string dir = Directory.GetCurrentDirectory() + "/PDF";
                    System.Diagnostics.Process.Start(dir);
                }
                catch
                {
                    MessageBox.Show("Error.");
                }
            }
        }
    }
}