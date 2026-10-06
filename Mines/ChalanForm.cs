using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.IO;
namespace WelcomeFabric
{
    public partial class ChalanForm : Form
    {
        double discount;
        string VoucherNo = "";
        int maxid = 0; string firmname;
        Data data = new Data();
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        string _Header = "";
        string _type = "";
        string query;
        int curr = 0;
        string id1 = "";
        int currow = 0;
        int max = 0;
        int max1 = 0;
        string NPara = "";
        DataSet ds1 = new DataSet();
        string a, b, c, d, f, g;
        TaxInvoiceRepor rep = new TaxInvoiceRepor();


        public ChalanForm(string Para)
        {
            InitializeComponent();  
            System.Threading.Thread.Sleep(200);
            if (Para != "a")
            {
                NPara = Para;
            }
        }
 
        public ChalanForm(string Para, string FormName)
        {

            InitializeComponent();  
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
            this.lblFormHeader.Text = _Header + " ENTRY";

            System.Threading.Thread.Sleep(200);
            if (Para != "a")
            {
                NPara = Para;
            }
        }

        private void ChalanForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
             
            clear();
            if (NPara != "")
            {
                fillclk(NPara);
            }
        }

        private void drpUnit()
        {
            query = " select * from tblUnit where delid=0 order by UnitName";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["UnitId"] = "0";
            newrow["UnitName"] = "Select Unit";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            dtpUnit.DataSource = ds.Tables[0];
            dtpUnit.DisplayMember = "UnitName";
            dtpUnit.ValueMember = "UnitId";
        }

        private void maxchalanGst()
        {
            query = " select max(chalanno) as Maxid from tbl_GstChallan where Delid=0 and EFlag='" + _type + "' and firmid=" + Data.id + " and sessionid=" + Data.sessionid + "";
            dr = data.getDataReader(query);
            if (dr.Read())
            {
                string sno = dr["Maxid"].ToString();
                if (sno == "")
                {
                    max1 = Convert.ToInt32(sno + 1);
                }
                else
                {
                    int dd = Convert.ToInt32(sno);
                    max1 = Convert.ToInt32(dd + 1);
                }
                txtmaxchallanid.Text = Convert.ToString(max1);
            }
            dr.Close();
        }



        public void cleardata()
        {
            dateTimePicker1.Text = DateTime.Now.ToString();
        }

        public void FillDeliverTo()
        {
            query = " select * from tbl_DeliveredTo where firmid=" + Data.id + " and delid=0 aorder by compname";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["id"] = "0";
            newrow["compname"] = "---Select Delivered ----";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            dtpDeliveredTo.DataSource = ds.Tables[0];
            dtpDeliveredTo.DisplayMember = "compname";
            dtpDeliveredTo.ValueMember = "id";
        }

        public void partyname()
        {
            query = " select id,Name,Address,maxid,PinCode,Phone,Mob,Mail,country,state,city,fax,email,website,remark,dateofjoin,officephone,compname,opening,CrDr,firmid,PartyType,PanNo,GstNo,AcNo,BankName,IfscCode,BranchName from tblclient where firmid=" + Data.id + " and Delid=0 order by compname";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["id"] = "0";
            newrow["compname"] = "---Select Party Name----";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            drpname.DataSource = ds.Tables[0];
            drpname.DisplayMember = "compname";
            drpname.ValueMember = "id";
        }

        public void labourate()
        {
            query = " select * from tbllabourrate where firmid=" + Data.id + " ";
            ds = data.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtlbrrate.Text = ds.Tables[0].Rows[0]["labourrate"].ToString();
            }
            else
            {
                txtlbrrate.Text = "";
            }
        }



        public void itemname()
        {
            query = " select * from tblitem where delid=0 and Firmid=" + Data.id
                + "order by itemname";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["itemid"] = "0";
            newrow["itemname"] = "---Select Item Name----";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                drpitem.DataSource = ds.Tables[0];
                drpitem.ValueMember = "itemid";
                drpitem.DisplayMember = "itemname";
            }
        }

        private void drpitem_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region
            if (drpitem.SelectedIndex > 0)
            {
                try
                {
                    if (id1 == "")
                    {
                        ClientENtry();
                    }
                    string dd = drpitem.SelectedValue.ToString();
                    query = "  select * from tblitem ";
                    query += " where tblitem.itemid=" + drpitem.SelectedValue + "";
                    //query += "  and tblitem.firmid=" + Data.id + "";
                    ds = data.getDataSet(query);
                    if (_type == "S")
                    {
                        getStockQty(dd);
                        if (SalePrice1.Checked == true)
                            txtrate.Text = ds.Tables[0].Rows[0]["MRP"].ToString();
                        else
                            txtrate.Text = ds.Tables[0].Rows[0]["MRP"].ToString();
                    }
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtBarcode.Text = ds.Tables[0].Rows[0]["ItemCode"].ToString();
                        drpitem.Text = ds.Tables[0].Rows[0]["itemname"].ToString();

                        txtSuppPrice.Text = ds.Tables[0].Rows[0]["SalePrice2"].ToString();

                        drpitem.SelectedValue = ds.Tables[0].Rows[0]["itemid"].ToString();
                        txtDiscount.Text = "0";
                        //txtupid.Text = "0";
                        txtHSNCode.Text = ds.Tables[0].Rows[0]["ItemCode"].ToString();
                        dtpUnit.Text = ds.Tables[0].Rows[0]["Unit"].ToString();
                        txtqty.Text = "1";
                        //txtqty.Focus();

                        int amt = (Convert.ToInt32(txtrate.Text)) * (Convert.ToInt32(txtqty.Text));
                        txtamout.Text = amt.ToString();
                        string qqqq = "select * from tblclient where id='" + id1 + "'";
                        DataSet ds2 = data.getDataSet(qqqq);
                        if (ds2.Tables[0].Rows.Count > 0)
                        {
                            if (ds2.Tables[0].Rows[0]["GSTFlag"].ToString() == "CGST")
                            {
                                txtCGST.Text = ds.Tables[0].Rows[0]["CGST"].ToString();
                                txtSGST.Text = ds.Tables[0].Rows[0]["SGST"].ToString();
                                txtIGST.Text = "0";
                                // cal();
                            }
                            if (ds2.Tables[0].Rows[0]["GSTFlag"].ToString() == "SGST")
                            {
                                txtCGST.Text = ds.Tables[0].Rows[0]["CGST"].ToString();
                                txtSGST.Text = ds.Tables[0].Rows[0]["SGST"].ToString();
                                txtIGST.Text = "0";
                                // cal();
                            }
                            if (ds2.Tables[0].Rows[0]["GSTFlag"].ToString() == "IGST")
                            {
                                txtCGST.Text = "0";
                                txtSGST.Text = "0";
                                txtIGST.Text = ds.Tables[0].Rows[0]["IGST"].ToString();
                                // cal();
                            }
                            txtCGST.Text = "0";
                            txtSGST.Text = "0";
                            txtIGST.Text = "0";
                            TaxCalc();
                            //double CGSTAmt;
                            //double SGSTAmt;
                            //double IGSTAmt;
                            //double Taxable;
                            //double total;

                            //try
                            //{
                            //    Taxable = Convert.ToDouble(txtqty.Text) * Convert.ToDouble(txtrate.Text);
                            //    // txtamout.Text = Convert.ToDouble(Taxable).ToString("0.00");
                            //    txtTaxableValue.Text = Convert.ToDouble(Taxable).ToString("0.00");
                            //    CGSTAmt = (Taxable * Convert.ToDouble(txtCGST.Text)) / 100;
                            //    txtCGSTAmount.Text = Convert.ToDouble(CGSTAmt).ToString("0.00");
                            //    SGSTAmt = (Taxable * Convert.ToDouble(txtSGST.Text)) / 100;
                            //    txtSGSTAmount.Text = Convert.ToDouble(SGSTAmt).ToString("0.00");
                            //    IGSTAmt = (Taxable * Convert.ToDouble(txtIGST.Text)) / 100;
                            //    txtIGSTAmount.Text = Convert.ToDouble(IGSTAmt).ToString("0.00");
                            //    total = Convert.ToDouble(Convert.ToDouble(Taxable) + Convert.ToDouble(CGSTAmt) + Convert.ToDouble(SGSTAmt) + Convert.ToDouble(IGSTAmt));
                            //    //txtGstTotalAmount.Text = Convert.ToDouble(total).ToString("0.00");
                            //    txtGstTotalAmount.Text = Convert.ToDouble(total).ToString("0.00");
                            //}
                            //catch
                            //{
                            //    // dgv.Rows[currow].Cells["VatAfter"].Value = "0";
                            //}
                        }

                    }
                    else
                    {
                        txtrate.Text = "0";
                    }
                }
                catch (Exception exx)
                {
                    filewrite(exx.ToString());
                }
            }
            else
            {
                // itemname();
            }
            #endregion
        }

        private void getStockQty(string ItemId)
        {
            double stockqty = 0;
            double gridqty = 0;

            DataSet dsSStock = data.getDataSet("select isnull(sum(Qty),0) SQty from Tbl_Stock where Delid=0 and type='S' and ItemId='" + ItemId + "' and Firmid='" + Data.id + "' and cast ([Date] as DAte)<= cast(('" + DateTime.Now + "') as date)");

            //CONVERT (NVARCHAR(10),Date,103) <='" + DateTime.Now.ToString("dd/MM/yyyy") + "'");

            DataSet dsPStock = data.getDataSet("select isnull(sum(Qty),0) PQty from Tbl_Stock where Delid=0 and type='P' and ItemId='" + ItemId + "' and Firmid='" + Data.id + "' and cast ([Date] as DAte)<= cast(('" + DateTime.Now + "') as date)");

            DataSet dsOPStock = data.getDataSet("select isnull(sum(Qty),0) OPQty from Tbl_Stock where Delid=0 and type='OP' and ItemId='" + ItemId + "' and Firmid='" + Data.id + "' and cast ([Date] as DAte)<= cast(('" + DateTime.Now + "') as date)");

            DataSet dsPRStock = data.getDataSet("select isnull(sum(Qty),0) PRQty from Tbl_Stock where Delid=0 and type='PR' and ItemId='" + ItemId + "' and Firmid='" + Data.id + "' and cast ([Date] as DAte)<= cast(('" + DateTime.Now + "') as date)");

            DataSet dsSRStock = data.getDataSet("select isnull(sum(Qty),0) SRQty from Tbl_Stock where Delid=0 and type='SR' and ItemId='" + ItemId + "' and Firmid='" + Data.id + "' and cast ([Date] as DAte)<= cast(('" + DateTime.Now + "') as date)");

            double sale = Convert.ToDouble(dsSStock.Tables[0].Rows[0]["SQty"]);
            double Pur = Convert.ToDouble(dsPStock.Tables[0].Rows[0]["PQty"]);
            double OP = Convert.ToDouble(dsOPStock.Tables[0].Rows[0]["OPQty"]);
            double PR = Convert.ToDouble(dsPRStock.Tables[0].Rows[0]["PRQty"]);
            double SR = Convert.ToDouble(dsSRStock.Tables[0].Rows[0]["SRQty"]);

            if (grdtest1.Rows.Count > 0)
            {
                for (int m = 0; m < grdtest1.Rows.Count; m++)
                {
                    string itemi = grdtest1.Rows[m].Cells["itemid"].Value.ToString();
                    if (itemi == ItemId)
                    {
                        gridqty += Convert.ToDouble(grdtest1.Rows[m].Cells["qty"].Value.ToString());
                    }
                }
            }

            stockqty = OP + Pur - sale - gridqty + SR - PR;
            txtStockQty.Text = stockqty.ToString();
        }

        private void cal()
        {
            double amt = 0.00;
            double amt1 = 0.00;
            double amt2 = 0.00;
            double amt3 = 0.00;
            double amt4 = 0.00;
            double Wages = 0.00;
            amt4 = Convert.ToDouble(Convert.ToDouble(txtamout.Text)) - ((Convert.ToDouble(txtamout.Text)) * (Convert.ToDouble(txtDiscount.Text)) / 100);
            Wages = Convert.ToDouble(txtTotalWages.Text);
            txtTaxableValue.Text = amt4.ToString("0.00");
            amt = Convert.ToDouble((amt4 * Convert.ToDouble(txtCGST.Text)) / 100);
            txtCGSTAmount.Text = amt.ToString("0.00");
            amt1 = Convert.ToDouble((amt4 * Convert.ToDouble(txtSGST.Text)) / 100);
            txtSGSTAmount.Text = amt1.ToString("0.00");
            amt2 = Convert.ToDouble((amt4 * Convert.ToDouble(txtIGST.Text)) / 100);
            txtIGSTAmount.Text = amt2.ToString("0.00");
            amt3 = (amt4 + amt + amt1 + amt2 + Wages);
            txtGstTotalAmount.Text = amt3.ToString("0.00");
        }

        private void drpname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpname.SelectedIndex > 0)
            {
                string aa = drpname.Text.ToString();
                query = " SELECT * from tblclient";
                query += " where  firmid=" + Data.id + " and Delid=0 ";
                query += " and id=" + drpname.SelectedValue + "";
                ds = data.getDataSet(query);
                txtMoblieNo.Text = ds.Tables[0].Rows[0]["Mob"].ToString();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtgstno.Text = ds.Tables[0].Rows[0]["GstNo"].ToString();
                }
                else
                {
                    dtpDeliveredTo.Text = "";
                    dtpDeliveredTo.Enabled = false;
                }

                query = " select * from tblclient where firmid=" + Data.id + " and compname='" + drpname.Text + "' and delid=0 order by compname";
                DataSet dss = data.getDataSet(query);
                if (dss.Tables[0].Rows.Count > 0)
                {
                    txtDeliveryAddress.Text = dss.Tables[0].Rows[0]["Address"].ToString();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clear();
        }

        public void clear()
        {
            if (_Header == "SALE")
            {
                SalePrice1.Checked = true;
                txtperdis.Text = "0.00";
                textBox2.Visible = false;
                label40.Visible = false;
            }
            else
            {

                SalePrice1.Visible = SalePrice2.Visible = false;
                txtperdis.Text = "0.00";
                if (_Header == "PURCHASE")
                {
                    label40.Visible = true;
                    textBox2.Visible = true;
                }
                else
                {
                    textBox2.Visible = false;
                    label40.Visible = false;
                }
            }
            panel2.Visible = false;
            btnWhatsapp.Visible = false;
            lblMainId.Text = txtOrderId.Text = "0";
            txtDueAmt.Text = txtPaidAmt.Text = "0.00";
            textBox2.Text = "";
            dateTimePicker2.Format = DateTimePickerFormat.Time;
            dateTimePicker2.ShowUpDown = true;
            itemname();
            maxchalan();
            maxchalanGst();
            filllst();
            lst.SelectedIndex = -1;
            drpUnit();
            lblDesignId.Text = "'0'";
            partyname();
            txtTax.Text = "";
            txtPlaceofSupply.Text = "";
            txtDis.Text = "0.00";
            drpPaymentMode.SelectedIndex = 0;
            txtTaxableValue.Text = "";
            dtpFrom.Text = dtpTo.Text = DateTime.Now.ToString();
            grdtest1.Rows.Clear();
            drpReverse.SelectedIndex = 2;
            dtpDeliveredTo.Text = "";
            txtrate.Text = "0";
            txtTotalTaxAmt.Text = "0";
            txtTotGSTAmt.Text = "0";
            txtgstno.Text = "";
            txtAddCGSTAmt.Text = "0";
            txtDeliveryAddress.Text = "";
            txtMoblieNo.Text = "";
            txtAddIGSTAmt.Text = "";
            txtAddSGSTAmt.Text = "";
            txtRoundOff.Text = "";
            btnsave.Text = "Save";
            txttotal.Text = "0";
            btnReprint.Visible = false;
            drpitem.SelectedIndex = 0;

            dtpVehicleNo.Text = "-- Select VehicleNo --";
            dateTimePicker1.Text = dateTimePicker3.Text = DateTime.Now.ToString();
            btndel.Enabled = false;
            txtTotalQty.Text = "";
            radioButton1.Checked = true;
            clear1();
            this.ActiveControl = drpname;
            drpname.Focus();
            id1 = "";
            txtStyle.Text = "";
            BindUnit();
            btnAll.Visible = false;
            btnLabel.Visible = false;
            btnGST.Visible = false;
            BtnWithoutPrice.Visible = false;
            BtnWithQty.Visible = false;
            btnWhatsapp.Visible = false;
        }

        public void filllst()
        {
            query = "GetAllChallans_GST " + Data.id + "," + Data.sessionid + ",'"
                + Convert.ToDateTime(dtpFrom.Value).ToString("MM/dd/yyyy") + "','" + Convert.ToDateTime(dtpTo.Value).ToString("MM/dd/yyyy") + "','%','" + _type + "'";
            ds = data.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lst.DataSource = ds.Tables[0];
                lst.DisplayMember = "name";
                lst.ValueMember = "chano";
            }
            else
            {
                lst.DataSource = null;
            }
        }

        private void btnitemadd_Click(object sender, EventArgs e)
        {
            Add();
        }

        public void Add()
        {
            try
            {
                if (_type == "S")
                {
                    if (txtqty.Text.Trim() != "")
                    {
                        double stock = Convert.ToDouble(txtStockQty.Text);
                        double qty = Convert.ToDouble(txtqty.Text);

                        if (stock < qty)
                        {
                            // MessageBox.Show("Qty is greater then Stock");
                            // btnadd.Enabled = false;
                            // txtqty.Focus();
                            // return;
                        }
                        else
                        {
                            btnadd.Enabled = true;
                        }
                    }
                }
                if (drpitem.SelectedIndex == 0)
                {
                    MessageBox.Show("Item Name Must be Select");
                    drpitem.Focus();
                    return;
                }
                if (dtpUnit.SelectedIndex == 0)
                {
                    MessageBox.Show("Unit Must be Select");
                    dtpUnit.Focus();
                    return;
                }
                if (txtqty.Text == "")
                {
                    MessageBox.Show("Quantity Must be Enter");
                    txtqty.Focus();
                    return;
                }
                if (btnadd.Text == "Add")
                {
                    grdtest1.Rows.Add();
                    curr = grdtest1.Rows.Count - 1;
                    int dd = curr + 1;
                    grdtest1.Rows[curr].Cells["sno"].Value = dd;
                    grdtest1.Rows[curr].Cells["itemid"].Value = drpitem.SelectedValue;
                    grdtest1.Rows[curr].Cells["Item"].Value = drpitem.Text;
                    grdtest1.Rows[curr].Cells["rate"].Value = txtrate.Text;
                    grdtest1.Rows[curr].Cells["qty"].Value = txtqty.Text;
                    grdtest1.Rows[curr].Cells["Discount1"].Value = txtperdis.Text;
                    grdtest1.Rows[curr].Cells["amount"].Value = txtamout.Text;
                    grdtest1.Rows[curr].Cells["ravanno"].Value = txtravanno.Text;
                    grdtest1.Rows[curr].Cells["CGST"].Value = txtCGST.Text;
                    grdtest1.Rows[curr].Cells["SGST"].Value = txtSGST.Text;
                    grdtest1.Rows[curr].Cells["IGST"].Value = txtIGST.Text;
                    grdtest1.Rows[curr].Cells["Unit"].Value = dtpUnit.Text;
                    grdtest1.Rows[curr].Cells["CGSTAmt"].Value = txtCGSTAmount.Text;
                    grdtest1.Rows[curr].Cells["SGSTAmt"].Value = txtSGSTAmount.Text;
                    grdtest1.Rows[curr].Cells["IGSTAmt"].Value = txtIGSTAmount.Text;
                    grdtest1.Rows[curr].Cells["Discount1"].Value = txtperdis.Text;
                    grdtest1.Rows[curr].Cells["TaxableValue"].Value = txtTaxableValue.Text;
                    grdtest1.Rows[curr].Cells["TotalAmt"].Value = txtGstTotalAmount.Text;
                    grdtest1.Rows[curr].Cells["MetricTon"].Value = txtMatricTon.Text;
                    grdtest1.Rows[curr].Cells["Barcode"].Value = txtBarcode.Text;
                    grdtest1.Rows[curr].Cells["HSNCode"].Value = txtHSNCode.Text;

                    grdtest1.Rows[curr].Cells["Wages"].Value = txtWages.Text;
                    grdtest1.Rows[curr].Cells["WagesAmt"].Value = txtWagesAmt.Text;
                    grdtest1.Rows[curr].Cells["SuppPrice"].Value = txtSuppPrice.Text;
                    grdtest1.Rows[curr].Cells["SuppAmt"].Value = txtSuppAmt.Text;
                    grdtest1.Rows[curr].Cells["upid"].Value = "0";
                    grdtest1.Rows[curr].Cells["Date"].Value = data.getDateMMDDYYYY(dateTimePicker1.Text);
                    grdtest1.Rows[curr].Cells["Edit1"].Value = "Edit";
                    grdtest1.Rows[curr].Cells["del"].Value = "Delete";
                    grdtest1.Rows[curr].Cells["orderDetlId"].Value = "0";
                }
                else
                {
                    int dd = currow + 1;
                    grdtest1.Rows[currow].Cells["sno"].Value = dd;
                    grdtest1.Rows[currow].Cells["itemid"].Value = drpitem.SelectedValue;
                    grdtest1.Rows[currow].Cells["Item"].Value = drpitem.Text;
                    grdtest1.Rows[currow].Cells["rate"].Value = txtrate.Text;
                    grdtest1.Rows[currow].Cells["qty"].Value = txtqty.Text;
                    grdtest1.Rows[currow].Cells["Discount1"].Value = txtperdis.Text;
                    grdtest1.Rows[currow].Cells["amount"].Value = txtamout.Text;
                    grdtest1.Rows[currow].Cells["ravanno"].Value = txtravanno.Text;
                    grdtest1.Rows[currow].Cells["CGST"].Value = txtCGST.Text;
                    grdtest1.Rows[currow].Cells["SGST"].Value = txtSGST.Text;
                    grdtest1.Rows[currow].Cells["IGST"].Value = txtIGST.Text;
                    grdtest1.Rows[currow].Cells["Unit"].Value = dtpUnit.Text;
                    grdtest1.Rows[currow].Cells["CGSTAmt"].Value = txtCGSTAmount.Text;
                    grdtest1.Rows[currow].Cells["SGSTAmt"].Value = txtSGSTAmount.Text;
                    grdtest1.Rows[currow].Cells["IGSTAmt"].Value = txtIGSTAmount.Text;
                    grdtest1.Rows[currow].Cells["Discount1"].Value = txtperdis.Text;
                    grdtest1.Rows[currow].Cells["TaxableValue"].Value = txtTaxableValue.Text;
                    grdtest1.Rows[currow].Cells["TotalAmt"].Value = txtGstTotalAmount.Text;
                    grdtest1.Rows[currow].Cells["MetricTon"].Value = txtMatricTon.Text;
                    grdtest1.Rows[currow].Cells["Barcode"].Value = txtBarcode.Text;
                    grdtest1.Rows[currow].Cells["HSNCode"].Value = txtHSNCode.Text;
                    grdtest1.Rows[currow].Cells["upid"].Value = txtupid.Text;
                    grdtest1.Rows[currow].Cells["Wages"].Value = txtWages.Text;
                    grdtest1.Rows[currow].Cells["WagesAmt"].Value = txtWagesAmt.Text;
                    grdtest1.Rows[currow].Cells["SuppPrice"].Value = txtSuppPrice.Text;
                    grdtest1.Rows[currow].Cells["SuppAmt"].Value = txtSuppAmt.Text;
                    grdtest1.Rows[currow].Cells["Date"].Value = data.getDateMMDDYYYY(dateTimePicker1.Text);
                    grdtest1.Rows[currow].Cells["Edit1"].Value = "Edit";
                    grdtest1.Rows[currow].Cells["del"].Value = "Delete";
                    grdtest1.Rows[curr].Cells["orderDetlId"].Value = txtOrderDetlId.Text;
                }
                txtRoundOff.Text = "0.00";
                txtBarcode.Focus();
                getTotalAmt();
                clear1();
            }
            catch (Exception ex)
            {
                data.LogError(ex.Message.ToLower(), ex.Message.ToString(), "Add Function", ex.StackTrace.ToString(), Data.id);
            }
        }

        public void maxchalan()
        {
            query = " select max(chalanno) as sno from tbl_GstChallan where Delid=0 and EFlag='" + _type + "' and firmid=" + Data.id + " and sessionid=" + Data.sessionid + "";
            dr = data.getDataReader(query);
            if (dr.Read())
            {
                string sno = dr["sno"].ToString();
                if (sno == "")
                {
                    max1 = Convert.ToInt32(sno + 1);
                }
                else
                {
                    int dd = Convert.ToInt32(sno);
                    max1 = Convert.ToInt32(dd + 1);
                }
                txtchalanno.Text = Convert.ToString(max1);
            }
            dr.Close();
        }

        private void grdtest1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            currow = e.RowIndex;
            try
            {
                if (grdtest1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Edit")
                {
                    drpitem.Text = grdtest1.Rows[e.RowIndex].Cells["Item"].Value.ToString();
                    txtrate.Text = grdtest1.Rows[e.RowIndex].Cells["rate"].Value.ToString();
                    txtqty.Text = grdtest1.Rows[e.RowIndex].Cells["qty"].Value.ToString();
                    txtTaxableValue.Text = grdtest1.Rows[e.RowIndex].Cells["TaxableValue"].Value.ToString();
                    txtamout.Text = grdtest1.Rows[e.RowIndex].Cells["amount"].Value.ToString();
                    txtupid.Text = grdtest1.Rows[e.RowIndex].Cells["upid"].Value.ToString();
                    txtGstTotalAmount.Text = grdtest1.Rows[e.RowIndex].Cells["TotalAmt"].Value.ToString();
                    dtpUnit.Text = grdtest1.Rows[e.RowIndex].Cells["Unit"].Value.ToString();
                    txtOrderDetlId.Text = grdtest1.Rows[e.RowIndex].Cells["orderDetlId"].Value.ToString();
                    txtWages.Text = grdtest1.Rows[e.RowIndex].Cells["Wages"].Value.ToString();
                    txtWagesAmt.Text = grdtest1.Rows[e.RowIndex].Cells["WagesAmt"].Value.ToString();
                    txtSuppPrice.Text = grdtest1.Rows[e.RowIndex].Cells["SuppPrice"].Value.ToString();
                    txtSuppAmt.Text = grdtest1.Rows[e.RowIndex].Cells["SuppAmt"].Value.ToString();

                    btnadd.Text = "Update";
                }
                if (grdtest1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Delete")
                {
                    string q1 = "update tbl_GstChallanDetails set delid=1 where chalnid=" + grdtest1.Rows[e.RowIndex].Cells["upid"].Value.ToString() + "";
                    data.executeCommand(q1);
                    grdtest1.Rows.RemoveAt(e.RowIndex);
                    getTotalAmt();
                }
            }
            catch (Exception ex)
            {
                data.LogError(ex.Message.ToLower(), ex.Message.ToString(), "grdtest1_CellContentClick", ex.StackTrace.ToString(), Data.id);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            save();
            //this.Close();
        }

        private double getTotalAmt()
        {
            double totAmt = 0;
            double totCGST = 0;
            double totSGST = 0;
            double totIGST = 0;
            double qty = 0;
            double Wages = 0;
            double SuppAmt = 0;
            for (int i = 0; i < grdtest1.Rows.Count; i++)
            {
                totAmt += Convert.ToDouble(grdtest1.Rows[i].Cells["TaxableValue"].Value.ToString());
                //totCGST += Convert.ToDouble(grdtest1.Rows[i].Cells["CGSTAmt"].Value.ToString());
                //totSGST += Convert.ToDouble(grdtest1.Rows[i].Cells["SGSTAmt"].Value.ToString());
                //totIGST += Convert.ToDouble(grdtest1.Rows[i].Cells["IGSTAmt"].Value.ToString());
                qty += Convert.ToDouble(grdtest1.Rows[i].Cells["qty"].Value.ToString());
                Wages += Convert.ToDouble(grdtest1.Rows[i].Cells["WagesAmt"].Value.ToString());
                SuppAmt += Convert.ToDouble(grdtest1.Rows[i].Cells["SuppAmt"].Value.ToString());
            }
            txtTotalQty.Text = qty.ToString();
            txtTax.Text = totAmt.ToString("0.00");
            txtAddCGSTAmt.Text = totCGST.ToString("0.00");
            txtAddSGSTAmt.Text = totSGST.ToString("0.00");
            txtAddIGSTAmt.Text = totIGST.ToString("0.00");
            txtTotGSTAmt.Text = Convert.ToDouble(Convert.ToDouble(txtAddCGSTAmt.Text) + Convert.ToDouble(txtAddSGSTAmt.Text) + Convert.ToDouble(txtAddIGSTAmt.Text)).ToString("0.00");
            double aaaaa = Convert.ToDouble(txtTax.Text) + Convert.ToDouble(txtTotGSTAmt.Text);
            double NetTotal = aaaaa + Wages;
            double roundvalue = Math.Round(aaaaa);
            txtRoundOff.Text = (roundvalue - aaaaa).ToString("0.00");
            txtTotalTaxAmt.Text = aaaaa.ToString("0.00");
            txttotal.Text = NetTotal.ToString("0.00");
            txtPaidAmt.Text = NetTotal.ToString("0.00");
            txtTotalWages.Text = Wages.ToString("0.00");
            txtTotalSupplier.Text = SuppAmt.ToString("0.00");
            return totAmt;
            return totCGST;
            return totSGST;
            return totIGST;
        }

        public void save()
        {
            string reference = "";
            string FirmShortName = "";
            string sessionyear = "";

            SqlConnection myConnection = new SqlConnection(data.conString);
            myConnection.Open();

            SqlCommand cmd = myConnection.CreateCommand();
            SqlTransaction myTrans;
            myTrans = myConnection.BeginTransaction();
            try
            {
                #region firmname
                string firm = "select * from tblfirm where firmid=" + Data.id;
                DataSet dsfirm = data.getDataSet(firm);
                if (dsfirm.Tables[0].Rows.Count > 0)
                {
                    FirmShortName = dsfirm.Tables[0].Rows[0]["ShortName"].ToString();
                }
                #endregion

                #region
                string session = "select * from tblsession where sessionid=" + Data.sessionid;
                DataSet dssession = data.getDataSet(session);
                if (dssession.Tables[0].Rows.Count > 0)
                {
                    sessionyear = dssession.Tables[0].Rows[0]["session"].ToString();
                }
                #endregion

                reference = FirmShortName + "/" + sessionyear + "/";


                if (drpReverse.SelectedIndex == 0)
                {
                    MessageBox.Show("Reverse Charge Must be Entered");
                    drpReverse.Focus();
                    return;
                }
                if (drpname.SelectedIndex == 0)
                {
                    MessageBox.Show("Name must be select");
                    drpname.Focus();
                    return;
                }
                if (grdtest1.Rows.Count == 0)
                {
                    MessageBox.Show("Record's not found");
                    return;
                }

                if (btnsave.Text == "Save")
                {
                    maxchalan();
                }

                if (data.Exist("select chalanno from tbl_GstChallan where EFlag='" + _type + "' and chalanno=" + txtchalanno.Text + " and firmid=" + Data.id + " and sessionid=" + Data.sessionid + " and Delid=0 and chalid!='" + lblMainId.Text + "'"))
                {
                    MessageBox.Show(" Chalanno. already Exist");
                    txtchalanno.Focus();
                    return;
                }


                cmd.Connection = myConnection;
                cmd.Transaction = myTrans;
                #region Main
                cmd.CommandText = "InvoiceSaveModify";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@chalid", lblMainId.Text);
                cmd.Parameters.AddWithValue("@Type1", btnsave.Text);
                cmd.Parameters.AddWithValue("@chalanno", txtchalanno.Text);
                cmd.Parameters.AddWithValue("@totalamt", txttotal.Text);
                cmd.Parameters.AddWithValue("@clientid", drpname.SelectedValue);
                cmd.Parameters.AddWithValue("@chalandate", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@firmid", Data.id);
                cmd.Parameters.AddWithValue("@mobileno", txtMoblieNo.Text);
                cmd.Parameters.AddWithValue("@sessionid", Data.sessionid);
                cmd.Parameters.AddWithValue("@TotalTaxAmt", txtTotalTaxAmt.Text);
                cmd.Parameters.AddWithValue("@MaxId", txtchalanno.Text);
                cmd.Parameters.AddWithValue("@EFlag", _type);
                cmd.Parameters.AddWithValue("@PaymentMode", drpPaymentMode.Text);
                cmd.Parameters.AddWithValue("@Discount", txtDis.Text);
                cmd.Parameters.AddWithValue("@GstBeforeAmt", txtTax.Text);
                cmd.Parameters.AddWithValue("@DateofSupply", DateTime.Now);
                cmd.Parameters.AddWithValue("@TotalQty", txtTotalQty.Text);
                cmd.Parameters.AddWithValue("@ReferenceNumber", reference);
                cmd.Parameters.AddWithValue("@DueAmount", txtDueAmt.Text);
                cmd.Parameters.AddWithValue("@PaidAmount", txtPaidAmt.Text);
                cmd.Parameters.AddWithValue("@AddSGSTAmt", txtAddSGSTAmt.Text);
                cmd.Parameters.AddWithValue("@AddIGSTAmt", txtAddIGSTAmt.Text);
                cmd.Parameters.AddWithValue("@AddCGSTAmt", txtAddCGSTAmt.Text);
                cmd.Parameters.AddWithValue("@TotalWages", txtTotalWages.Text);
                cmd.Parameters.AddWithValue("@TotalSuppAmt", txtTotalSupplier.Text);
                cmd.Parameters.AddWithValue("@DisType", (radioButton1.Checked == true) ? "Flat" : "Percentage");
                cmd.Parameters.AddWithValue("@GenerateBy", "Computer");
                cmd.Parameters.AddWithValue("@OrderId", txtOrderId.Text);
                SqlParameter pr = new SqlParameter("@return", SqlDbType.Int);
                pr.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pr);
                SqlParameter pr1 = new SqlParameter("@return1", SqlDbType.Int);
                pr1.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pr1);
                int res = cmd.ExecuteNonQuery();
                lblMainId.Text = cmd.Parameters["@return"].Value.ToString();
                txtchalanno.Text = cmd.Parameters["@return1"].Value.ToString();
                #endregion

                #region  InvoiceDetails
                for (int i = 0; i < grdtest1.Rows.Count; i++)
                {
                    cmd.Parameters.Clear();
                    if (grdtest1.Rows[i].Cells["upid"].Value.ToString() == "0")
                    {
                        //
                        query = " insert into tbl_GstChallanDetails(chalanno,clientid,itemid,price,chalandate,qty,amount,firmid,sessionid,Unit,GrossTotal,TaxableValue,MaxId,EFlag,MainId,GenerateBy,[CGST],[SGST],[IGST],[CGSTAmount],[SGSTAmount],[IGSTAmount],Wages,WagesAmt,SuppPrice,SuppAmt)values(@chalanno,@clientid,@itemid,@price,@chalandate,@qty,@amount,@firmid, @sessionid,@Unit,@GrossTotal,@TaxableValue,@MaxId,@EFlag,@MainId,@GenerateBy,@CGST,@SGST,@IGST,@CGSTAmount,@SGSTAmount,@IGSTAmount,@Wages,@WagesAmt,@SuppPrice,@SuppAmt)";
                    }
                    else
                    {
                        query = " update tbl_GstChallanDetails SET chalanno=@chalanno,clientid=@clientid,itemid=@itemid,price=@price,chalandate=@chalandate,qty=@qty,amount=@amount,firmid=@firmid,sessionid=@sessionid,Unit=@Unit,GrossTotal=@GrossTotal,TaxableValue=@TaxableValue,MaxId=@MaxId,EFlag=@EFlag,MainId=@MainId,GenerateBy=@GenerateBy,[CGST]=@CGST,[SGST]=@SGST,[IGST]=@IGST,[CGSTAmount]=@CGSTAmount,[SGSTAmount]=@SGSTAmount,[IGSTAmount] =@IGSTAmount,Wages=@Wages,WagesAmt=@WagesAmt,SuppPrice=@SuppPrice,SuppAmt=@SuppAmt where MaxId=" + txtchalanno.Text + " and chalnid=" + grdtest1.Rows[i].Cells["upid"].Value.ToString() + " and firmid=" + Data.id + " and sessionid=" + Data.sessionid + " and EFlag='" + _type + "' and Delid=0";
                    }
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@chalanno", txtchalanno.Text);
                    cmd.Parameters.AddWithValue("@clientid", drpname.SelectedValue);
                    cmd.Parameters.AddWithValue("@itemid", grdtest1.Rows[i].Cells["itemid"].Value.ToString());
                    cmd.Parameters.AddWithValue("@price", grdtest1.Rows[i].Cells["rate"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Unit", grdtest1.Rows[i].Cells["Unit"].Value.ToString());
                    cmd.Parameters.AddWithValue("@chalandate", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@qty", grdtest1.Rows[i].Cells["qty"].Value.ToString());
                    cmd.Parameters.AddWithValue("@amount", grdtest1.Rows[i].Cells["amount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@firmid", Data.id);
                    cmd.Parameters.AddWithValue("@TaxableValue", grdtest1.Rows[i].Cells["TaxableValue"].Value.ToString());
                    cmd.Parameters.AddWithValue("@GrossTotal", grdtest1.Rows[i].Cells["TotalAmt"].Value.ToString());

                    cmd.Parameters.AddWithValue("@CGST", grdtest1.Rows[i].Cells["CGST"].Value.ToString());
                    cmd.Parameters.AddWithValue("@SGST", grdtest1.Rows[i].Cells["SGST"].Value.ToString());
                    cmd.Parameters.AddWithValue("@IGST", grdtest1.Rows[i].Cells["IGST"].Value.ToString());
                    cmd.Parameters.AddWithValue("@CGSTAmount", grdtest1.Rows[i].Cells["CGSTAmt"].Value.ToString());
                    cmd.Parameters.AddWithValue("@SGSTAmount", grdtest1.Rows[i].Cells["SGSTAMt"].Value.ToString());
                    cmd.Parameters.AddWithValue("@IGSTAmount", grdtest1.Rows[i].Cells["IGSTAmt"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Wages", grdtest1.Rows[i].Cells["Wages"].Value.ToString());
                    cmd.Parameters.AddWithValue("@WagesAmt", grdtest1.Rows[i].Cells["WagesAmt"].Value.ToString());
                    cmd.Parameters.AddWithValue("@SuppPrice", grdtest1.Rows[i].Cells["SuppPrice"].Value.ToString());
                    cmd.Parameters.AddWithValue("@SuppAmt", grdtest1.Rows[i].Cells["SuppAmt"].Value.ToString());


                    cmd.Parameters.AddWithValue("@sessionid", Data.sessionid);
                    cmd.Parameters.AddWithValue("@MaxId", txtchalanno.Text);
                    cmd.Parameters.AddWithValue("@MainId", lblMainId.Text);
                    cmd.Parameters.AddWithValue("@GenerateBy", "Computer");
                    cmd.Parameters.AddWithValue("@EFlag", _type);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                #endregion


                #region Sale Update
                //else
                //{
                //    query = " update tbl_GstChallan SET chalanno=@chalanno,totalamt=@totalamt,clientid=@clientid,chalandate=@chalandate,firmid=@firmid,Transid=@Transid,VehicleNo=@VehicleNo,sessionid=@sessionid,AddCGSTAmt=@AddCGSTAmt,AddIGSTAmt=@AddIGSTAmt,AddSGSTAmt=@AddSGSTAmt,DeliveredTo=@DeliveredTo,DeliveryAddress=@DeliveryAddress,chalantime=@chalantime,mobileno=@mobileno,UID=@UID,ReverseCharge=@ReverseCharge,TotGSTAmt=@TotGSTAmt,TotalTaxAmt=@TotalTaxAmt,MaxId=@MaxId,lbrid=@lbrid,EFlag=@EFlag,RoundOff=@RoundOff,DeliveryChallanNo=@DeliveryChallanNo,PaymentMode=@PaymentMode,Frieght=@Frieght,Discount=@Discount,GstBeforeAmt=@GstBeforeAmt,PlaceofSupply=@PlaceofSupply,DateofSupply=@DateofSupply,TotalQty=@TotalQty,ReferenceNumber=@ReferenceNumber, DisType=@DisType,[PaidAmount]=@PaidAmount ,[DueAmount]=@DueAmount where MaxId=" + txtmaxchallanid.Text + " and firmid=" + Data.id + " and sessionid=" + Data.sessionid + " and EFlag='" + _type + "' and Delid=0";
                //    cmd.CommandText = query;
                //    cmd.Parameters.AddWithValue("@chalanno", txtchalanno.Text);
                //    cmd.Parameters.AddWithValue("@totalamt", txttotal.Text);
                //    cmd.Parameters.AddWithValue("@clientid", drpname.SelectedValue);
                //    cmd.Parameters.AddWithValue("@DeliveredTo", "0");
                //    cmd.Parameters.AddWithValue("@DeliveryAddress", txtDeliveryAddress.Text);
                //    cmd.Parameters.AddWithValue("@chalandate", dateTimePicker1.Value);
                //    cmd.Parameters.AddWithValue("@chalantime", dateTimePicker2.Text);
                //    cmd.Parameters.AddWithValue("@firmid", Data.id);
                //    cmd.Parameters.AddWithValue("@Transid", drplbr.SelectedValue);
                //    cmd.Parameters.AddWithValue("@VehicleNo", "0");
                //    cmd.Parameters.AddWithValue("@AddCGSTAmt", txtAddCGSTAmt.Text);
                //    cmd.Parameters.AddWithValue("@AddIGSTAmt", txtAddIGSTAmt.Text);
                //    cmd.Parameters.AddWithValue("@mobileno", txtMoblieNo.Text);
                //    cmd.Parameters.AddWithValue("@AddSGSTAmt", txtAddSGSTAmt.Text);
                //    cmd.Parameters.AddWithValue("@sessionid", Data.sessionid);
                //    cmd.Parameters.AddWithValue("@ReverseCharge", drpReverse.Text);
                //    cmd.Parameters.AddWithValue("@TotGSTAmt", txtTotGSTAmt.Text);
                //    cmd.Parameters.AddWithValue("@TotalTaxAmt", txtTotalTaxAmt.Text);
                //    cmd.Parameters.AddWithValue("@lbrid", drpLabour.SelectedValue);
                //    cmd.Parameters.AddWithValue("@MaxId", txtchalanno.Text);
                //    cmd.Parameters.AddWithValue("@EFlag", _type);
                //    cmd.Parameters.AddWithValue("@RoundOff", txtRoundOff.Text);
                //    cmd.Parameters.AddWithValue("@DeliveryChallanNo", textBox2.Text);
                //    cmd.Parameters.AddWithValue("@PaymentMode", drpPaymentMode.Text);
                //    cmd.Parameters.AddWithValue("@Frieght", txtFrieght.Text);
                //    cmd.Parameters.AddWithValue("@Discount", txtDis.Text);
                //    cmd.Parameters.AddWithValue("@GstBeforeAmt", txtTax.Text);
                //    cmd.Parameters.AddWithValue("@PlaceofSupply", txtPlaceofSupply.Text);
                //    cmd.Parameters.AddWithValue("@DateofSupply", dateTimePicker3.Value);
                //    cmd.Parameters.AddWithValue("@TotalQty", txtTotalQty.Text);
                //    cmd.Parameters.AddWithValue("@ReferenceNumber", reference);
                //    cmd.Parameters.AddWithValue("@PaidAmount", txtPaidAmt.Text);
                //    cmd.Parameters.AddWithValue("@DueAmount", txtDueAmt.Text);
                //    if (radioButton1.Checked == true)
                //        cmd.Parameters.AddWithValue("@DisType", "Flat");
                //    else
                //        cmd.Parameters.AddWithValue("@DisType", "Percentage");
                //    if (Data.UID == "")
                //    {
                //        cmd.Parameters.AddWithValue("@UID", 0);
                //    }
                //    else
                //    {
                //        cmd.Parameters.AddWithValue("@UID", Data.UID);
                //    }
                //    if (data.executeCommand(cmd) == 0)
                //    {
                //        a = "1";
                //        cmd.Parameters.Clear();

                //        //query = " insert into tbl_GstChallanDetails(chalanno,clientid,itemid,price,chalandate,qty,amount,firmid,ravanano,sessionid,Unit,CGST,SGST,IGST,CGSTAmount,SGSTAmount,IGSTAmount,Discount,GrossTotal,TaxableValue)values(@chalanno,@clientid,@itemid,@price,@chalandate,@qty,@amount,@firmid,@ravanano,@sessionid,@Unit,CGST,SGST,@IGST,@CGSTAmount,@SGSTAmount,@IGSTAmount,@Discount,@GrossTotal,@TaxableValue)";

                //        for (int i = 0; i < grdtest1.Rows.Count; i++)
                //        {
                //            if (grdtest1.Rows[i].Cells["upid"].Value.ToString() == "0")
                //            {
                //                query = " insert into tbl_GstChallanDetails(chalanno,clientid,itemid,price,chalandate,qty,amount,firmid,ravanano,sessionid,Unit,CGST,SGST,IGST,CGSTAmount,SGSTAmount,IGSTAmount,Discount,GrossTotal,TaxableValue,MaxId,EFlag,MetricTon,Barcode,HSNCode)values(@chalanno,@clientid,@itemid,@price,@chalandate,@qty,@amount,@firmid,@ravanano,@sessionid,@Unit,@CGST,@SGST,@IGST,@CGSTAmount,@SGSTAmount,@IGSTAmount,@Discount,@GrossTotal,@TaxableValue,@MaxId,@EFlag,@MetricTon,@Barcode,@HSNCode)";
                //                cmd.CommandText = query;

                //                cmd.Parameters.AddWithValue("@chalanno", txtchalanno.Text);
                //                cmd.Parameters.AddWithValue("@clientid", drpname.SelectedValue);
                //                cmd.Parameters.AddWithValue("@itemid", grdtest1.Rows[i].Cells["itemid"].Value.ToString());
                //                cmd.Parameters.AddWithValue("@price", grdtest1.Rows[i].Cells["rate"].Value.ToString());
                //                cmd.Parameters.AddWithValue("@chalandate", dateTimePicker1.Value);
                //                cmd.Parameters.AddWithValue("@qty", grdtest1.Rows[i].Cells["qty"].Value.ToString());
                //                cmd.Parameters.AddWithValue("@amount", grdtest1.Rows[i].Cells["amount"].Value.ToString());
                //                cmd.Parameters.AddWithValue("@firmid", Data.id);
                //                cmd.Parameters.AddWithValue("@ravanano", grdtest1.Rows[i].Cells["ravanno"].Value.ToString());
                //                cmd.Parameters.AddWithValue("@Unit", grdtest1.Rows[i].Cells["Unit"].Value.ToString());
                //                cmd.Parameters.AddWithValue("@CGST", grdtest1.Rows[i].Cells["CGST"].Value.ToString());
                //                cmd.Parameters.AddWithValue("@SGST", grdtest1.Rows[i].Cells["SGST"].Value.ToString());
                //                cmd.Parameters.AddWithValue("@IGST", grdtest1.Rows[i].Cells["IGST"].Value.ToString());
                //                cmd.Parameters.AddWithValue("@CGSTAmount", grdtest1.Rows[i].Cells["CGSTAmt"].Value.ToString());
                //                cmd.Parameters.AddWithValue("@SGSTAmount", grdtest1.Rows[i].Cells["SGSTAmt"].Value.ToString());
                //                cmd.Parameters.AddWithValue("@IGSTAmount", grdtest1.Rows[i].Cells["IGSTAmt"].Value.ToString());
                //                cmd.Parameters.AddWithValue("@Discount", grdtest1.Rows[i].Cells["Discount1"].Value.ToString());
                //                cmd.Parameters.AddWithValue("@TaxableValue", grdtest1.Rows[i].Cells["TaxableValue"].Value.ToString());
                //                cmd.Parameters.AddWithValue("@GrossTotal", grdtest1.Rows[i].Cells["TotalAmt"].Value.ToString());
                //                cmd.Parameters.AddWithValue("@MetricTon", grdtest1.Rows[i].Cells["MetricTon"].Value.ToString());
                //                cmd.Parameters.AddWithValue("@Barcode", grdtest1.Rows[i].Cells["Barcode"].Value.ToString());
                //                cmd.Parameters.AddWithValue("@HSNCode", grdtest1.Rows[i].Cells["HSNCode"].Value.ToString());
                //                cmd.Parameters.AddWithValue("@sessionid", Data.sessionid);
                //                cmd.Parameters.AddWithValue("@MaxId", txtchalanno.Text);
                //                cmd.Parameters.AddWithValue("@EFlag", _type);
                //                if (data.executeCommand(cmd) == 0)
                //                    b = "1";
                //                else
                //                    b = "0";
                //                cmd.Parameters.Clear();
                //            }
                //            else
                //            {
                //                query = " update tbl_GstChallanDetails SET chalanno=@chalanno,clientid=@clientid,itemid=@itemid,price=@price,chalandate=@chalandate,qty=@qty,amount=@amount,firmid=@firmid,ravanano=@ravanano,sessionid=@sessionid,Unit=@Unit,CGST=@CGST,SGST=@SGST,IGST=@IGST,CGSTAmount=@CGSTAmount,SGSTAmount=@SGSTAmount,IGSTAmount=@IGSTAmount,Discount=@Discount,GrossTotal=@GrossTotal,TaxableValue=@TaxableValue,MaxId=@MaxId,EFlag=@EFlag,MetricTon=@MetricTon,Barcode=@Barcode,HSNCode=@HSNCode where MaxId=" + txtmaxchallanid.Text + " and chalnid=" + grdtest1.Rows[i].Cells["upid"].Value.ToString() + " and firmid=" + Data.id + " and sessionid=" + Data.sessionid + " and EFlag='" + _type + "' and Delid=0";
                //                cmd.CommandText = query;
                //                cmd.Parameters.AddWithValue("@chalanno", txtchalanno.Text);
                //                cmd.Parameters.AddWithValue("@clientid", drpname.SelectedValue);
                //                cmd.Parameters.AddWithValue("@itemid", grdtest1.Rows[i].Cells["itemid"].Value.ToString());
                //                cmd.Parameters.AddWithValue("@price", grdtest1.Rows[i].Cells["rate"].Value.ToString());
                //                cmd.Parameters.AddWithValue("@chalandate", dateTimePicker1.Value);
                //                cmd.Parameters.AddWithValue("@qty", grdtest1.Rows[i].Cells["qty"].Value.ToString());
                //                cmd.Parameters.AddWithValue("@amount", grdtest1.Rows[i].Cells["amount"].Value.ToString());
                //                cmd.Parameters.AddWithValue("@firmid", Data.id);
                //                cmd.Parameters.AddWithValue("@ravanano", grdtest1.Rows[i].Cells["ravanno"].Value.ToString());
                //                cmd.Parameters.AddWithValue("@Unit", grdtest1.Rows[i].Cells["Unit"].Value.ToString());
                //                cmd.Parameters.AddWithValue("@CGST", grdtest1.Rows[i].Cells["CGST"].Value.ToString());
                //                cmd.Parameters.AddWithValue("@SGST", grdtest1.Rows[i].Cells["SGST"].Value.ToString());
                //                cmd.Parameters.AddWithValue("@IGST", grdtest1.Rows[i].Cells["IGST"].Value.ToString());
                //                cmd.Parameters.AddWithValue("@CGSTAmount", grdtest1.Rows[i].Cells["CGSTAmt"].Value.ToString());
                //                cmd.Parameters.AddWithValue("@SGSTAmount", grdtest1.Rows[i].Cells["SGSTAmt"].Value.ToString());
                //                cmd.Parameters.AddWithValue("@IGSTAmount", grdtest1.Rows[i].Cells["IGSTAmt"].Value.ToString());
                //                cmd.Parameters.AddWithValue("@Discount", grdtest1.Rows[i].Cells["Discount1"].Value.ToString());
                //                cmd.Parameters.AddWithValue("@TaxableValue", grdtest1.Rows[i].Cells["TaxableValue"].Value.ToString());
                //                cmd.Parameters.AddWithValue("@GrossTotal", grdtest1.Rows[i].Cells["TotalAmt"].Value.ToString());
                //                cmd.Parameters.AddWithValue("@MetricTon", grdtest1.Rows[i].Cells["MetricTon"].Value.ToString());
                //                cmd.Parameters.AddWithValue("@Barcode", grdtest1.Rows[i].Cells["Barcode"].Value.ToString());
                //                cmd.Parameters.AddWithValue("@HSNCode", grdtest1.Rows[i].Cells["HSNCode"].Value.ToString());
                //                cmd.Parameters.AddWithValue("@sessionid", Data.sessionid);
                //                cmd.Parameters.AddWithValue("@MaxId", txtchalanno.Text);
                //                cmd.Parameters.AddWithValue("@EFlag", _type);
                //                if (data.executeCommand(cmd) == 0)
                //                    b = "1";
                //                else
                //                    b = "0";
                //                cmd.Parameters.Clear();
                //            }
                //        }
                //    }
                //    else
                //    {
                //        a = "0";
                //    }
                //}
                #endregion

                #region StockEntry
                if (btnsave.Text.ToUpper() == "UPDATE")
                {
                    cmd.CommandText = "delete from Tbl_Stock where MainId='" + lblMainId.Text + "' and  type= '" + _type + "'";
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                //DataTable dt =
                foreach (DataGridViewRow dr11 in grdtest1.Rows)
                {
                    query = "INSERT INTO [Tbl_Stock]([ItemId],[type],[Qty],[Barcode],[Date],[Firmid],[chalanno],[MainId])";
                    query += " VALUES ('" + dr11.Cells["itemid"].Value + "','" + _type + "','" + dr11.Cells["qty"].Value + "','" + dr11.Cells["Barcode"].Value + "','" + dateTimePicker1.Value + "','" + Data.id + "','" + txtchalanno.Text + "','" + lblMainId.Text + "')";
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }

                #endregion

                #region LedgerEntry
                if (btnsave.Text.ToUpper() == "SAVE")
                {
                    query = " insert into tblldg (Client_Id,CrDr,VocType,BillAmt,VoucherBy,Dat,receptno,firmid,sessionid,Billno,type,MainId)values(@Client_Id,@CrDr,@VocType,@BillAmt,@VoucherBy,@Dat,@receptno,@firmid,@sessionid,@Billno,@type,@MainId)";
                }
                else
                {
                    query = "update tblldg set Client_Id=@Client_Id,CrDr=@CrDr,VocType=@VocType,BillAmt=@BillAmt,VoucherBy=@VoucherBy,Dat=@Dat,receptno=@receptno,firmid=@firmid,sessionid=@sessionid,Billno=@Billno,MainId=@MainId";
                    query += " where Billno='" + txtchalanno.Text + "' and  type= '" + _type + "' and firmid='" + Data.id + "' and sessionid='" + Data.sessionid + "'";
                }
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Client_Id", drpname.SelectedValue);
                if (_type == "S" || _type == "PR")
                {
                    cmd.Parameters.AddWithValue("@CrDr", "CR");
                    cmd.Parameters.AddWithValue("@VocType", "Amount Received");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@CrDr", "DR");
                    cmd.Parameters.AddWithValue("@VocType", "Amount PAID");
                }

                cmd.Parameters.AddWithValue("@BillAmt", txtTotalTaxAmt.Text);
                cmd.Parameters.AddWithValue("@VoucherBy", drpPaymentMode.Text);
                cmd.Parameters.AddWithValue("@Dat", data.getDateMMDDYYYY(dateTimePicker1.Text));
                cmd.Parameters.AddWithValue("@receptno", VoucherNo);
                cmd.Parameters.AddWithValue("@firmid", Data.id);
                cmd.Parameters.AddWithValue("@sessionid", Data.sessionid);
                cmd.Parameters.AddWithValue("@Billno", txtchalanno.Text);
                cmd.Parameters.AddWithValue("@type", _type);
                cmd.Parameters.AddWithValue("@MainId", lblMainId.Text);
                cmd.Parameters.AddWithValue("@OrderId", lblMainId.Text);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                #endregion
                myTrans.Commit();
                MessageBox.Show(btnsave.Text + "Record Successfully !!!");
                Print();
                clear();

            }
            catch (Exception ee)
            {
                try
                {
                    myTrans.Rollback();
                }
                catch (SqlException ex)
                {

                }
                MessageBox.Show("Check Your Entry...");
                filewrite(ee.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
                myConnection.Close();
            }
            //sms(); 
        }

        public void filewrite(string Whattowrite)
        {
            string path = "";
            try
            {
                string dir = Directory.GetCurrentDirectory() + "/Loger";

                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                path = dir + @"\LogFile" + DateTime.Now.ToString("-yyy-MM-dd") + ".txt";
                using (var sw = File.AppendText(path))
                {
                    sw.WriteLine(Whattowrite + " : " + DateTime.Now.ToShortTimeString());
                }
            }
            catch
            {
                string dir = Directory.GetCurrentDirectory() + "/Loger";

                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                path = dir + @"\LogFile" + DateTime.Now.ToString("-yyy-MM-dd") + ".txt";
                using (var sw = File.AppendText(path))
                {
                    sw.WriteLine(Whattowrite + " : " + DateTime.Now.ToShortTimeString());
                }
            }
        }

        private void Print()
        {
            #region print

            if (_type == "S")
            {
                if (MessageBox.Show("Do You want Print Record Press 'Yes' otherwise Press 'No'", "Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string query1 = "select * from InvoicePrint_View where Delid=0 and EFlag='" + _type + "' and chalid=" + lblMainId.Text + " and firmid=" + Data.id + " and  sessionid=" + Data.sessionid + " order by chalnid";
                    Data.query = query1;

                    if (_type == "S")
                    {
                        CustomMsg frm = new CustomMsg();
                        frm.ShowDialog();

                        //SqlDataAdapter adp = new SqlDataAdapter(Data.query, data.conString);
                        //WelcomeFabric.Report.DataSet2 ds = new WelcomeFabric.Report.DataSet2();
                        //adp.Fill(ds, "InvoicePrint_View");
                        //CrystalDecisions.CrystalReports.Engine.ReportDocument repdoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                        //repdoc = new WelcomeFabric.Report.BillPrint_New();
                        //repdoc.SetDataSource(ds);
                        //crystalReportViewer1.ReportSource = repdoc;
                        //crystalReportViewer1.Dock = DockStyle.Fill;
                        //System.Drawing.Printing.PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();
                        //repdoc.PrintOptions.PrinterName = printDocument.PrinterSettings.PrinterName;
                        //repdoc.PrintToPrinter(1, true, 0, 0);
                    } //air82341
                    else
                    {
                        //TaxInvoiceRepor rep = new TaxInvoiceRepor();
                        //rep.ShowDialog();
                    }
                }
            }
            #endregion
        }

        public void fillVoucherNo()
        {
            query = "select max(receptno) as maxId from tblldg where firmid=" + Data.id + " and sessionid=" + Data.sessionid + "";
            dr = data.getDataReader(query);
            if (dr.Read())
            {
                string maxvoc = dr["maxId"].ToString();
                if (maxvoc == "")
                {
                    maxid = 1;
                }
                else
                {
                    maxid = Convert.ToInt32(maxvoc) + 1;
                }
                VoucherNo = maxid.ToString();
            }
            dr.Close();
        }

        private void sms()
        {
            string query = "select * from tblfirm where firmid=" + Data.id + "";
            DataSet dss = data.getDataSet(query);
            if (dss.Tables[0].Rows.Count > 0)
            {
                firmname = dss.Tables[0].Rows[0]["compname"].ToString();
            }
            try
            {
                string message = "Dear " + drpname.Text + " your invoice no " + txtchalanno.Text + " Amt Rs." + txtTotalTaxAmt.Text + " generated on " + dateTimePicker1.Text + " in " + firmname + ". Thanks.";
                string url = "http://new.sssms.co.in/httpapi/smsapi?uname=welcomefab&password=Jaipur1234&sender=WELFAB&receiver=" + txtMoblieNo.Text + "&route=T&msgtype=1&sms=" + message + "";
                System.Net.WebClient wc = new System.Net.WebClient();
                byte[] ba = wc.DownloadData(url);
            }
            catch { }
        }

        private void lst_Click(object sender, EventArgs e)
        {
            if (lst.SelectedIndex >= 0)
            {
                string chno = Convert.ToString(lst.SelectedValue);
                fillclk(chno);
            }
        }

        public void fillclk(string ss)
        {
            try
            {
                string query1;
                txttotal.Text = "0";
                DataSet ds1 = new DataSet();
                query1 = "select * from InvoiceListClick_View where EFlag='" + _type + "' and chalid=" + ss + " and [Firmid]=" + Data.id + " and sessionid=" + Data.sessionid + "";
                query1 += " order by chalnid";
                ds1 = data.getDataSet(query1);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    lblMainId.Text = ds1.Tables[0].Rows[0]["chalid"].ToString();
                    txtmaxchallanid.Text = ds1.Tables[0].Rows[0]["MaxId"].ToString();
                    txtchalanno.Text = ds1.Tables[0].Rows[0]["chalanno"].ToString();
                    drpname.SelectedValue = ds1.Tables[0].Rows[0]["clientid"].ToString();
                    txtMoblieNo.Text = ds1.Tables[0].Rows[0]["mobileno"].ToString();
                    dateTimePicker1.Text = ds1.Tables[0].Rows[0]["chalandate"].ToString();
                    dateTimePicker2.Text = ds1.Tables[0].Rows[0]["chalantime"].ToString();
                    txttotal.Text = ds1.Tables[0].Rows[0]["totalamt"].ToString();
                    txtTotalTaxAmt.Text = ds1.Tables[0].Rows[0]["TotalTaxAmt"].ToString();
                    drpPaymentMode.Text = ds1.Tables[0].Rows[0]["PaymentMode"].ToString();
                    txtTax.Text = ds1.Tables[0].Rows[0]["GstBeforeAmt"].ToString();
                    txtTotalQty.Text = ds1.Tables[0].Rows[0]["TotalQty"].ToString();
                    txtPaidAmt.Text = ds1.Tables[0].Rows[0]["PaidAmount"].ToString();
                    txtDueAmt.Text = ds1.Tables[0].Rows[0]["DueAmount"].ToString();
                    txtOrderId.Text = ds1.Tables[0].Rows[0]["OrderId"].ToString();
                    if (ds1.Tables[0].Rows[0]["DisType"].ToString() == "Flat")
                        radioButton1.Checked = true;
                    else
                        radioButton2.Checked = true;
                    grdtest1.Rows.Clear();
                    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    {
                        grdtest1.Rows.Add();
                        grdtest1.Rows[i].Cells["sno"].Value = grdtest1.Rows.Count;
                        grdtest1.Rows[i].Cells["itemid"].Value = ds1.Tables[0].Rows[i]["itemid"].ToString();
                        grdtest1.Rows[i].Cells["Item"].Value = ds1.Tables[0].Rows[i]["itemname"].ToString();
                        grdtest1.Rows[i].Cells["rate"].Value = ds1.Tables[0].Rows[i]["price"].ToString();
                        grdtest1.Rows[i].Cells["qty"].Value = ds1.Tables[0].Rows[i]["qty"].ToString();
                        grdtest1.Rows[i].Cells["amount"].Value = ds1.Tables[0].Rows[i]["amount"].ToString();
                        grdtest1.Rows[i].Cells["Unit"].Value = ds1.Tables[0].Rows[i]["Unit"].ToString();
                        grdtest1.Rows[i].Cells["TotalAmt"].Value = ds1.Tables[0].Rows[i]["TaxableValue"].ToString();
                        grdtest1.Rows[i].Cells["TaxableValue"].Value = ds1.Tables[0].Rows[i]["TaxableValue"].ToString();

                        grdtest1.Rows[i].Cells["CGST"].Value = ds1.Tables[0].Rows[i]["CGST"].ToString();
                        grdtest1.Rows[i].Cells["SGST"].Value = ds1.Tables[0].Rows[i]["SGST"].ToString();
                        grdtest1.Rows[i].Cells["IGST"].Value = ds1.Tables[0].Rows[i]["IGST"].ToString();
                        grdtest1.Rows[i].Cells["CGSTAmt"].Value = ds1.Tables[0].Rows[i]["CGSTAmount"].ToString();
                        grdtest1.Rows[i].Cells["SGSTAmt"].Value = ds1.Tables[0].Rows[i]["SGSTAmount"].ToString();
                        grdtest1.Rows[i].Cells["IGSTAMt"].Value = ds1.Tables[0].Rows[i]["IGSTAmount"].ToString();

                        grdtest1.Rows[i].Cells["upid"].Value = ds1.Tables[0].Rows[i]["chalnid"].ToString();
                        grdtest1.Rows[i].Cells["orderDetlId"].Value = ds1.Tables[0].Rows[i]["orderDetlId"].ToString();
                        grdtest1.Rows[i].Cells["Edit1"].Value = "Edit";
                        grdtest1.Rows[i].Cells["del"].Value = "Delete";


                        grdtest1.Rows[i].Cells["Wages"].Value = ds1.Tables[0].Rows[i]["Wages"].ToString();
                        grdtest1.Rows[i].Cells["WagesAmt"].Value = ds1.Tables[0].Rows[i]["WagesAmt"].ToString();
                        grdtest1.Rows[i].Cells["SuppPrice"].Value = ds1.Tables[0].Rows[i]["SuppPrice"].ToString();
                        grdtest1.Rows[i].Cells["SuppAmt"].Value = ds1.Tables[0].Rows[i]["SuppAmt"].ToString();
                    }
                    getTotalAmt();
                    btnsave.Text = "Update";
                    if (_type == "S")
                    {
                        btnReprint.Visible = true;
                        btnWhatsapp.Visible = true;
                        btnAll.Visible = true;
                        btnLabel.Visible = true;
                        btnGST.Visible = true;
                        BtnWithoutPrice.Visible = true;
                        BtnWithQty.Visible = true;
                        btnWhatsapp.Visible = true;

                    }
                    btndel.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                data.LogError(ex.Message.ToLower(), ex.Message.ToString(), "lst_Click", ex.StackTrace.ToString(), Data.id);
            }
        }

        private void txtqty_TextChanged(object sender, EventArgs e)
        {

        }

        private void CheckQty()
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear1();
        }

        public void clear1()
        {
            try
            {
                if (_type == "S")
                {
                    txtStockQty.Visible = false;
                    lblStockQty.Visible = false;
                    txtperdis.Text = "0.00";
                }
                else
                {

                    txtStockQty.Visible = false;
                    lblStockQty.Visible = false;
                    txtperdis.Text = "0.00";
                }
                txtStockQty.Text = "0";
                checkBox1.Checked = true;
                // TaxCalc();
                txtBarcode.Text = "";
                txtrate.Text = txtOrderDetlId.Text = "0";
                txtamout.Text = "0";
                txtqty.Text = "0";
                drpitem.SelectedIndex = 0;
                txtCGST.Text = "0";
                txtCGSTAmount.Text = "0";
                txtSGST.Text = "0";
                txtSGSTAmount.Text = "0";
                txtIGST.Text = "0";
                txtIGSTAmount.Text = "0";
                txtDiscount.Text = "0";
                txtMatricTon.Text = "";
                txtGstTotalAmount.Text = "0";
                txtravanno.Text = "";
                btnadd.Text = "Add";
                btnadd.Enabled = true;
                txtBarcode.Focus();
                dtpUnit.SelectedIndex = 0;
                txtupid.Text = "0";
                txtTaxableValue.Text = "";
                txtHSNCode.Text = "";
                drpitem.Focus();
                txtSuppAmt.Text = txtSuppPrice.Text = txtWages.Text = txtWagesAmt.Text = "0";
            }
            catch { }
        }

        private void drpname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                this.ProcessTabKey(true);
            }
            if (e.Control == true)
            {
                if (e.KeyCode == Keys.S)
                {
                    save();
                }
                else if (e.KeyCode == Keys.A)
                {
                    Add();
                }
                else if (e.KeyCode == Keys.C)
                {
                }
            }
            if (e.KeyCode == Keys.F1)
            {
                this.Close();
            }
        }

        private void txtrate_TextChanged(object sender, EventArgs e)
        {
            AmountCalculation();
            //checkBox1.Focus();
        }

        private void AmountCalculation()
        {
            if (txtqty.Text == "")
            {
                txtqty.Text = "0";
            }
            try
            {
                double rate = Convert.ToDouble(txtrate.Text);
                double Wages = Convert.ToDouble(txtWages.Text);
                double SuppPrice = Convert.ToDouble(txtSuppPrice.Text);
                double qty = Convert.ToDouble(txtqty.Text);
                double PerDis = Convert.ToDouble(txtperdis.Text);
                double amt = (rate * qty * (100 - PerDis)) / 100;
                double SuppAmt = SuppPrice * qty;
                double WagesAmt = Wages * qty;

                txtamout.Text = Convert.ToString(amt);
                txtWagesAmt.Text = Convert.ToString(WagesAmt);
                txtSuppAmt.Text = Convert.ToString(SuppAmt);
                //cal();
                TaxCalc();
            }
            catch
            {
            }
        }

        private void txtqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ch = (int)e.KeyChar;
            if ((ch < 48 || ch > 58) && (ch != 8) && (ch != 46))
                e.KeyChar = '\0';
        }

        private void txttotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ch = (int)e.KeyChar;
            if ((ch < 48 || ch > 58) && (ch != 8) && (ch != 46))
                e.KeyChar = '\0';
        }

        private void btndel_Click(object sender, EventArgs e)
        {
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
                    cmd.CommandText = " Update tbl_GstChallanDetails set delid=1 where EFlag='" + _type + "' and firmid=" + Data.id + " and MainId =" + lblMainId.Text + " and sessionid=" + Data.sessionid + " ";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = " update tbl_GstChallan set delid=1 where EFlag='" + _type + "' and firmid=" + Data.id + " and chalid=" + lblMainId.Text + " and sessionid=" + Data.sessionid + " ";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = " update tblldg set delid=1 where type='" + _type + "' and firmid=" + Data.id + " and MainId=" + lblMainId.Text + " and sessionid=" + Data.sessionid + " ";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = " update Tbl_Stock set delid=1 where type='" + _type + "' and Firmid=" + Data.id + " and MainId=" + lblMainId.Text + "";
                    cmd.ExecuteNonQuery();

                    myTrans.Commit();
                    MessageBox.Show("Record Delete Successfully");
                    clear();
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
                    filewrite(ee.ToString());
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                    myConnection.Close();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string _search = "%";
                if (textBox1.Text.Trim() != "")
                {
                    _search = textBox1.Text.Trim();
                }
                query = "GetAllChallans_GST " + Data.id + "," + Data.sessionid + ",'"
                 + dtpFrom.Value + "','" + dtpTo.Value + "','" + _search + "'";
                ds = data.getDataSet(query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lst.DataSource = ds.Tables[0];
                    lst.DisplayMember = "name";
                    lst.ValueMember = "chalanno";
                }
                else
                {
                    lst.DataSource = null;
                }
            }
            catch
            {
            }
        }

        private void drplbr_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (drplbr.SelectedIndex > 0)
            {
                query = "  SELECT tbl_Vehicle.VehicleNo,tbl_Transport.lbrid FROM (tbl_Vehicle INNER JOIN tbl_Transport ON tbl_Vehicle.clientid = tbl_Transport.lbrid)";
                query += " where tbl_Transport.lbrid=" + drplbr.SelectedValue;
                ds = data.getDataSet(query);

                DataRow newrow = ds.Tables[0].NewRow();
                newrow["lbrid"] = "0";
                newrow["VehicleNo"] = "---Select VehicleNo ---";
                ds.Tables[0].Rows.InsertAt(newrow, 0);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dtpVehicleNo.DataSource = ds.Tables[0];
                    dtpVehicleNo.DisplayMember = "VehicleNo";
                }
            }
        }

        private void txtDisount_Leave(object sender, EventArgs e)
        {
            string Ammount;
            try
            {
                Ammount = (Convert.ToDouble(txttotal.Text) * Convert.ToDouble(txtAddCGSTAmt.Text) / 100).ToString();
                txtAddIGSTAmt.Text = (Convert.ToDouble(txttotal.Text) - Convert.ToDouble(Ammount)).ToString();
            }
            catch
            {
                txtAddCGSTAmt.Text = "0";
            }

        }

        private void txtFright_Leave(object sender, EventArgs e)
        {
            string Ammount;
            try
            {
                Ammount = Convert.ToDouble(txttotal.Text).ToString();
                txtAddIGSTAmt.Text = (Convert.ToDouble(txtAddSGSTAmt.Text) + Convert.ToDouble(Ammount)).ToString();
            }
            catch
            {
                txtAddSGSTAmt.Text = "0";
            }
        }

        private void btnReprint_Click(object sender, EventArgs e)
        {
            string query1 = "select * from InvoicePrint_View where EFlag='" + _type + "' and  Delid=0 and chalanno=" + txtchalanno.Text + " and firmid=" + Data.id + "  and sessionid=" + Data.sessionid + " order by chalnid";
            Data.query = query1;
            CustomMsg frm = new CustomMsg();
            frm.Show();
        }

        private void PrintR(string _TT, string _Query)
        {
            string query1 = "select * from " + _Query + " where EFlag='" + _type + "' and  Delid=0 and chalanno=" + txtchalanno.Text + " and firmid=" + Data.id + "  and sessionid=" + Data.sessionid + " order by chalnid";
            Data.query = query1;
            rep.Print(_TT);
            rep.Show();
            //clear();
        }


        private void btnAll_Click(object sender, EventArgs e)
        {
            string query1 = "select * from InvoicePrint_View where EFlag='" + _type + "' and  Delid=0 and chalanno=" + txtchalanno.Text + " and firmid=" + Data.id + "  and sessionid=" + Data.sessionid + " order by chalnid";
            DataTable dt = data.GetDataTable(query1);
            TaxInvoiceReport_New frm = new TaxInvoiceReport_New(dt, "ALL", "InvoicePrint_View");
            frm.ShowDialog();

            //PrintR("", "");
        }

        private void BtnWithoutPrice_Click(object sender, EventArgs e)
        {
            string query1 = "select * from InvoicePrint_View where EFlag='" + _type + "' and  Delid=0 and chalanno=" + txtchalanno.Text + " and firmid=" + Data.id + "  and sessionid=" + Data.sessionid + " order by chalnid";
            DataTable dt = data.GetDataTable(query1);
            TaxInvoiceReport_New frm = new TaxInvoiceReport_New(dt, "WithOutPrice", "InvoicePrint_View");
            frm.ShowDialog();
        }

        private void BtnWithQty_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel2.Focus();
        }

        private void btnGST_Click(object sender, EventArgs e)
        {
            string query1 = "select * from GSTInvoicePrint_View where EFlag='" + _type + "' and  Delid=0 and chalanno=" + txtchalanno.Text + " and firmid=" + Data.id + "  and sessionid=" + Data.sessionid + " order by chalnid";
            DataTable dt = data.GetDataTable(query1);
            TaxInvoiceReport_New frm = new TaxInvoiceReport_New(dt, "GST", "InvoicePrint");
            frm.ShowDialog();
        }

        private void btnLabel_Click(object sender, EventArgs e)
        {
            string query1 = "select * from InvoicePrint_View where EFlag='" + _type + "' and  Delid=0 and chalanno=" + txtchalanno.Text + " and firmid=" + Data.id + "  and sessionid=" + Data.sessionid + " order by chalnid";
            DataTable dt = data.GetDataTable(query1);
            TaxInvoiceReport_New frm = new TaxInvoiceReport_New(dt, "Label", "InvoicePrint_View");
            frm.ShowDialog();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string _search = "%";
                if (textBox1.Text.Trim() != "")
                {
                    _search = textBox1.Text.Trim();
                }
                query = "GetAllChallans_GST " + Data.id + "," + Data.sessionid + ",'"
                 + Convert.ToDateTime(dtpFrom.Value).ToString("MM/dd/yyyy") + "','" + Convert.ToDateTime(dtpTo.Value).ToString("MM/dd/yyyy") + "','" + _search + "','" + _type + "'";
                ds = data.getDataSet(query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lst.DataSource = ds.Tables[0];
                    lst.DisplayMember = "name";
                    lst.ValueMember = "chano";
                }
                else
                {
                    lst.DataSource = null;
                }
            }
            catch
            {
            }
        }

        private void dtpDeliveredTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = " select * from tbl_DeliveredTo where firmid=" + Data.id + " and compname='" + dtpDeliveredTo.Text + "' and delid=0 order by compname";
            DataSet dss = data.getDataSet(query);
            if (dss.Tables[0].Rows.Count > 0)
            {
                txtDeliveryAddress.Text = dss.Tables[0].Rows[0]["Address"].ToString();
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            discount = (Convert.ToDouble(txtamout.Text) * Convert.ToDouble(txtDiscount.Text)) / 100;
            txtDisAmount.Text = discount.ToString("0.00");
            cal();

        }

        private void txtRoundOff_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    if (radioButton1.Checked == true)
            //    {
            //        txtTotalTaxAmt.Text = ((Convert.ToDouble(txttotal.Text) + Convert.ToDouble(txtTotGSTAmt.Text)) + Convert.ToDouble(txtRoundOff.Text)).ToString("0.00");
            //    }
            //    else
            //    {
            //        txtTotalTaxAmt.Text = ((Convert.ToDouble(txttotal.Text) + Convert.ToDouble(txtTotGSTAmt.Text)) - Convert.ToDouble(txtRoundOff.Text)).ToString("0.00");
            //    }
            //}
            //catch
            //{
            //    txtRoundOff.Text = "0.00";
            //}
        }

        private void check()
        {
            try
            {
                if (radioButton1.Checked == true)
                {
                    cal1();
                }
                else
                {
                    double per = (Convert.ToDouble(txtTotalTaxAmt.Text) * Convert.ToDouble(txtDis.Text)) / 100;
                    // txtDis.Text = per.ToString("0.00");
                    double am = (Convert.ToDouble(txtTotalTaxAmt.Text) - per);
                    double roundvalue = Math.Round(am);
                    txtRoundOff.Text = (roundvalue - am).ToString("0.00");
                    txttotal.Text = roundvalue.ToString("0.00");
                }
            }
            catch
            {
                txtRoundOff.Text = "0.00";
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                check();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                check();
            }
        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)32 || e.KeyChar == (char)13)
            //{
            //    if (txtBarcode.Text.Trim() != "")
            //    {
            //        string LengthBarcode = txtBarcode.Text.Length.ToString();
            //        InsertINMenus(LengthBarcode);
            //    }
            //}
        }

        public void InsertINMenus(string LengthBarcode)
        {
            if (drpname.Text == "Select Vendor")
            {
                MessageBox.Show("Select Vendor Type");
                drpname.Focus();
                return;
            }
            else
            {
                #region Barcode Item Name  By Fill
                string query = " select * from tblitem where Delid=0 and  ItemCode ='" + txtBarcode.Text + "'";
                if (data.Exist(query))
                {
                    string str = drpitem.Text;
                    DataSet ds = data.getDataSet(query);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        drpitem.Text = ds.Tables[0].Rows[0]["itemname"].ToString();
                        drpitem.SelectedValue = ds.Tables[0].Rows[0]["itemid"].ToString();

                        string dd = drpitem.SelectedValue.ToString();
                        if (_type == "S")
                        {
                            getStockQty(dd);
                            if (SalePrice1.Checked == true)
                                txtrate.Text = ds.Tables[0].Rows[0]["MRP"].ToString();
                            else
                                txtrate.Text = ds.Tables[0].Rows[0]["MRP"].ToString();
                        }
                        txtDiscount.Text = "0";
                        //txtupid.Text = "0";
                        txtHSNCode.Text = ds.Tables[0].Rows[0]["ItemCode"].ToString();
                        dtpUnit.Text = ds.Tables[0].Rows[0]["Unit"].ToString();


                        double qty = Convert.ToDouble(txtqty.Text);
                        //qty = qty ;
                        txtqty.Text = qty.ToString();
                        double price = Convert.ToDouble(txtrate.Text);
                        txtamout.Text = txtrate.Text;
                        string q34 = " select * from tblclient where id='" + id1 + "'";
                        DataSet ds2 = data.getDataSet(q34);
                        if (ds2.Tables[0].Rows.Count > 0)
                        {
                            if (ds2.Tables[0].Rows[0]["GSTFlag"].ToString() == "CGST")
                            {
                                txtCGST.Text = ds.Tables[0].Rows[0]["CGST"].ToString();
                                txtSGST.Text = ds.Tables[0].Rows[0]["SGST"].ToString();
                                txtIGST.Text = "0";
                            }
                            if (ds2.Tables[0].Rows[0]["GSTFlag"].ToString() == "SGST")
                            {
                                txtCGST.Text = ds.Tables[0].Rows[0]["CGST"].ToString();
                                txtSGST.Text = ds.Tables[0].Rows[0]["SGST"].ToString();
                                txtIGST.Text = "0";
                            }
                            if (ds2.Tables[0].Rows[0]["GSTFlag"].ToString() == "IGST")
                            {
                                txtCGST.Text = "0";
                                txtSGST.Text = "0";
                                txtIGST.Text = ds.Tables[0].Rows[0]["IGST"].ToString();
                            }
                            double CGSTAmt;
                            double SGSTAmt;
                            double IGSTAmt;
                            double Taxable;
                            double total;

                            try
                            {
                                Taxable = qty * Convert.ToDouble(txtrate.Text);
                                // txtamout.Text = Convert.ToDouble(Taxable).ToString("0.00");
                                txtTaxableValue.Text = Convert.ToDouble(Taxable).ToString("0.00");
                                CGSTAmt = (Taxable * Convert.ToDouble(txtCGST.Text)) / 100;
                                txtCGSTAmount.Text = Convert.ToDouble(CGSTAmt).ToString("0.00");
                                SGSTAmt = (Taxable * Convert.ToDouble(txtSGST.Text)) / 100;
                                txtSGSTAmount.Text = Convert.ToDouble(SGSTAmt).ToString("0.00");
                                IGSTAmt = (Taxable * Convert.ToDouble(txtIGST.Text)) / 100;
                                txtIGSTAmount.Text = Convert.ToDouble(IGSTAmt).ToString("0.00");
                                total = Convert.ToDouble(Convert.ToDouble(Taxable) + Convert.ToDouble(CGSTAmt) + Convert.ToDouble(SGSTAmt) + Convert.ToDouble(IGSTAmt));
                                //txtGstTotalAmount.Text = Convert.ToDouble(total).ToString("0.00");
                                txtGstTotalAmount.Text = Convert.ToDouble(Taxable).ToString("0.00");
                            }
                            catch
                            {
                                // dgv.Rows[currow].Cells["VatAfter"].Value = "0";
                            }
                            //dgv.Rows[currow].Cells["SaleRate"].Value = ds.Tables[0].Rows[0]["MRP"].ToString();
                            txtBarcode.Text = ds.Tables[0].Rows[0]["ItemCode"].ToString();
                        }
                    }
                    txtqty.Focus();
                }
                else
                {
                    MessageBox.Show("Item Not In Stock");
                    txtBarcode.Focus();
                }
                #endregion
            }
        }

        private void txtDis_Leave(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                cal1();
            }
            else
            {
                check();
                cal1();
            }
        }

        private void txtFrieght_Leave(object sender, EventArgs e)
        {
            cal1();
        }

        private void cal1()
        {
            double tax = 0;
            tax = Convert.ToDouble(txtTotalTaxAmt.Text) - Convert.ToDouble(txtDis.Text) + Convert.ToDouble(txtFrieght.Text);
            // double am = (Convert.ToDouble(txtTotalTaxAmt.Text) - tax);
            double roundvalue = Math.Round(tax);
            txtRoundOff.Text = (roundvalue - tax).ToString("0.00");
            txttotal.Text = roundvalue.ToString("0.00");
            //txttotal.Text = tax.ToString("0.00");
            //string q34 = " select * from tblclient where id='" + drpname.SelectedValue + "'";
            //DataSet ds2 = data.getDataSet(q34);
            //if (ds2.Tables[0].Rows.Count > 0)
            //{
            //    if (ds2.Tables[0].Rows[0]["GSTFlag"].ToString() == "CGST")
            //    {
            //        txtAddCGSTAmt.Text = ((tax * 9) / 100).ToString("0.00");
            //        txtAddSGSTAmt.Text = ((tax * 9) / 100).ToString("0.00");
            //        //txtCGST.Text = ds.Tables[0].Rows[0]["CGST"].ToString();
            //        //txtSGST.Text = ds.Tables[0].Rows[0]["SGST"].ToString();
            //        txtAddIGSTAmt.Text = "0.00";
            //    }
            //    if (ds2.Tables[0].Rows[0]["GSTFlag"].ToString() == "SGST")
            //    {
            //        txtAddCGSTAmt.Text = ((tax * 9) / 100).ToString("0.00");
            //        txtAddSGSTAmt.Text = ((tax * 9) / 100).ToString("0.00");
            //        txtAddIGSTAmt.Text = "0.00";
            //    }
            //    if (ds2.Tables[0].Rows[0]["GSTFlag"].ToString() == "IGST")
            //    {
            //        txtAddCGSTAmt.Text = "0.00";
            //        txtAddSGSTAmt.Text = "0.00";
            //        txtAddIGSTAmt.Text = ((tax * 18) / 100).ToString("0.00");
            //    }
            //}
            //txtTotGSTAmt.Text = (Convert.ToDouble(txtAddCGSTAmt.Text) + Convert.ToDouble(txtAddSGSTAmt.Text) + Convert.ToDouble(txtAddIGSTAmt.Text)).ToString("0.00");
            //// txtTotalTaxAmt.Text = (Convert.ToDouble(txtTax.Text) + Convert.ToDouble(txtTotGSTAmt.Text)).ToString("0.00");


            //double aaaaa = Convert.ToDouble(txtTax.Text) + Convert.ToDouble(txtTotGSTAmt.Text);
            ////= Convert.ToDouble(txtGrandTotal.Text) + Convert.ToDouble(txtTotGSTAmt.Text);
            //double roundvalue = Math.Round(aaaaa);
            //txtRoundOff.Text = (roundvalue - aaaaa).ToString("0.00");
            //txtTotalTaxAmt.Text = roundvalue.ToString("0.00");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            TaxCalc();
        }

        public void TaxCalc()
        {
            double GST = 0;
            //GST = Convert.ToDouble(txtCGST.Text) + Convert.ToDouble(txtSGST.Text);
            if (checkBox1.Checked)
            {
                txtGstTotalAmount.Text = txtamout.Text;
                double taxamount = ((Convert.ToDouble(txtamout.Text) - discount) / (GST / 100 + 1));
                //double taxamount = ((Convert.ToDouble(txtamout.Text) - discount)- (Convert.ToDouble(txtamout.Text) / (GST / 100 + 1)));
                //txtrate.Text = (taxamount / Convert.ToDouble(txtqty.Text)).ToString("0.00");
                txtamout.Text = Convert.ToDouble(taxamount).ToString("0.00");
                cal();

                ////txtamout.Text = txtGstTotalAmount.Text;
                ////txtrate.Text = (Convert.ToDouble(txtamout.Text) / Convert.ToDouble(txtqty.Text)).ToString("0.00");
                //double taxamount = ((Convert.ToDouble(txtamout.Text) - discount) * GST / 100);
                //cal();
            }
            else
            {
                //txtamout.Text = txtGstTotalAmount.Text;
                //txtrate.Text = (Convert.ToDouble(txtamout.Text) / Convert.ToDouble(txtqty.Text)).ToString("0.00");
                double taxamount = ((Convert.ToDouble(txtamout.Text) - discount) * GST / 100);
                cal();
                //txtGstTotalAmount.Text = txtamout.Text;
                //double taxamount = ((Convert.ToDouble(txtamout.Text) - discount) / (GST / 100 + 1));
                ////double taxamount = ((Convert.ToDouble(txtamout.Text) - discount)- (Convert.ToDouble(txtamout.Text) / (GST / 100 + 1)));
                ////txtrate.Text = (taxamount / Convert.ToDouble(txtqty.Text)).ToString("0.00");
                //txtamout.Text = Convert.ToDouble(taxamount).ToString("0.00");
                //cal();
            }
        }

        private void drpname_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyData.ToString() == "Return")
            {
                this.ProcessTabKey(true);
            }
            if (e.Control == true)
            {
                if (e.KeyCode == Keys.N)
                {
                    PartyMaster fas = new PartyMaster();
                    fas.ShowDialog();
                    partyname();
                }
            }
        }

        private void drplbr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.ToString() == "Return")
            {
                this.ProcessTabKey(true);
            }
        }

        private void drpitem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.ToString() == "Return")
            {
                this.ProcessTabKey(true);
            }
            if (e.Control == true)
            {
                if (e.KeyCode == Keys.N)
                {
                    ItemMaster fas = new ItemMaster();
                    fas.ShowDialog();
                    itemname();
                }
            }
        }

        private void txtamout_Leave(object sender, EventArgs e)
        {
            checkBox1.Focus();
        }

        private void txtBarcode_Leave(object sender, EventArgs e)
        {
            if (txtBarcode.Text.Trim() != "")
            {
                if (id1 == "")
                {
                    ClientENtry();
                }
                string LengthBarcode = txtBarcode.Text.Length.ToString();
                //InsertINMenus(LengthBarcode);
            }
        }

        public void ClientENtry()
        {
            if (!data.Exist("select * from tblclient where compname='" + drpname.Text.ToString() + "' and Firmid=" + Data.id))
            {
                DataSet ds = data.getDataSet("SELECT (ISNULL(MAX(ISNULL(MaxId,0)), 0) + 1) as getno FROM tblclient where Firmid=" + Data.id);
                string Max = ds.Tables[0].Rows[0]["getno"].ToString();

                data.executeCommand("insert into tblclient ([Address] ,[Mob] ,[country],[state] ,[dateofjoin] ,[compname],[CrDr],[firmid] ,[PartyType] ,[GstNo] ,[MaxId],[GSTFlag],[GSTRegistration],[StateCode]) Values ('" + txtDeliveryAddress.Text.Trim() + "','" + txtMoblieNo.Text.Trim() + "','INDIA','RAJASTHAN','" + DateTime.Now + "','" + drpname.Text.Trim() + "','Dr','" + Data.id + "','Consumer', '" + txtgstno.Text.Trim() + "','" + Max + "','CGST','UN-REGISTERED','08')");

                DataSet ds1 = data.getDataSet("SELECT MAX(id) as getno FROM tblclient");
                id1 = ds1.Tables[0].Rows[0]["getno"].ToString();
            }
            else
            {
                id1 = drpname.SelectedValue.ToString();
            }
        }

        private void txtPaidAmt_TextChanged(object sender, EventArgs e)
        {
            double actualAmt = 0, dueAmt = 0;
            if (txtPaidAmt.Text != "")
            {
                actualAmt = Convert.ToDouble(txttotal.Text);
                dueAmt = Convert.ToDouble(txttotal.Text) - Convert.ToDouble(txtPaidAmt.Text);
                txtDueAmt.Text = dueAmt.ToString("0.00");
            }
        }

        private void btnWhatsapp_Click(object sender, EventArgs e)
        {

            string query1 = "select * from InvoicePrint_View where EFlag='" + _type + "' and  Delid=0 and chalanno=" + txtchalanno.Text + " and firmid=" + Data.id + "  and sessionid=" + Data.sessionid + " ";
            Data.query = query1;
            CustomButton frm = new CustomButton();
            frm.Show();
        }

        private void dtpUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dtpUnit.SelectedIndex > 0)
            {
                DataSet dsWages = data.getDataSet("select wages from tblUnit where UnitId=" + dtpUnit.SelectedValue);
                txtWages.Text = dsWages.Tables[0].Rows[0]["Wages"].ToString();
            }
            else
            {
                txtWages.Text = "0";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string query1 = "select * from InvoicePrint_View where EFlag='" + _type + "' and  Delid=0 and chalanno=" + txtchalanno.Text + " and firmid=" + Data.id + "  and sessionid=" + Data.sessionid + "";
            if (lblDesignId.Text != "0")
            {
                query1 += " and Unit in (" + lblDesignId.Text.Replace(",,", ",") + ")";
            }
            query1 += " order by chalnid";
            DataTable dt = data.GetDataTable(query1);
            TaxInvoiceReport_New frm = new TaxInvoiceReport_New(dt, "OnlyQty", "InvoicePrint_View");
            frm.ShowDialog();
        }

        private void dgvUnit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvDesigns.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name.ToString() == "Chk")
                {
                    DataGridViewCheckBoxCell cbc = (dgvDesigns.CurrentRow.Cells[e.ColumnIndex] as DataGridViewCheckBoxCell);
                    object checker = cbc.Value;

                    if (checker == null)
                    {
                        dgvDesigns.CurrentCell.Value = true;
                        if (lblDesignId.Text != "")
                        {
                            lblDesignId.Text += ",'" + dgvDesigns.Rows[e.RowIndex].Cells["UnitName"].Value.ToString() + "'";
                        }
                    }
                    else
                    {
                        if ((bool)checker == true)
                        {
                            dgvDesigns.CurrentCell.Value = false;
                            string _ddEsignId = "'" + dgvDesigns.Rows[e.RowIndex].Cells["UnitName"].Value.ToString() + "'";
                            if (lblDesignId.Text != "")
                            {
                                lblDesignId.Text = lblDesignId.Text.Replace(_ddEsignId, "");
                                lblDesignId.Text = lblDesignId.Text.Replace(",,", ",");
                            }
                        }
                        else
                        {
                            dgvDesigns.CurrentCell.Value = true;
                            if (lblDesignId.Text != "")
                            {
                                lblDesignId.Text += ",'" + dgvDesigns.Rows[e.RowIndex].Cells["UnitName"].Value.ToString() + "'";
                            }
                        }
                    }
                }
            }
        }

        private void txtStyle_TextChanged(object sender, EventArgs e)
        {
            BindUnit();
        }

        private void BindUnit()
        {
            string query = "select * from tblUnit where Delid=0 and isactive=1";
            if (txtStyle.Text.Trim() != "")
            {
                query += " and UnitName like '%" + txtStyle.Text.Trim() + "%'";
            }
            query += " order by UnitName";
            DataSet dsDesign = data.getDataSet(query);
            dgvDesigns.AutoGenerateColumns = false;
            dgvDesigns.DataSource = dsDesign.Tables[0];
        }

        private void label61_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        
    }
}