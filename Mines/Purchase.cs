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
    public partial class Purchase : Form
    {
        Data data = new Data();
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        string query;
        int curr = 0;
        int currow = 0;
        int max = 0;
        int max1 = 0;
        public Purchase()
        {
            InitializeComponent();
        }
        private void ChalanForm_Load(object sender, EventArgs e)
        {
            label13.Text = Data.Area;

            // itemname();
            partyname();
            maxchalan();
            filllst();
            drpname.Focus();
            filllabour();
            // labourate();
            drpname.Focus();
            btndel.Enabled = false;
            dtpUnit1.SelectedIndex = 1;

        }
        public void cleardata()
        {
            dateTimePicker1.Text = DateTime.Now.ToString();
        }
        public void partyname()
        {
            query = " select * from tblclient where firmid=" + Data.id + " order by compname";
            //query = " select * from tblclient where firmid=" + Data.id + " and PartyType='Vendor' order by name";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["id"] = "0";
            newrow["compname"] = "---Select Vendor ----";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            drpname.DataSource = ds.Tables[0];
            drpname.DisplayMember = "compname";
            drpname.ValueMember = "id";
        }

        public void filllabour()
        {
            query = " select * from tbllabour where firmid=" + Data.id + " order by labourname";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["lbrid"] = "0";
            newrow["labourname"] = "---Select Labour Name----";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            drplbr.DataSource = ds.Tables[0];
            drplbr.DisplayMember = "labourname";
            drplbr.ValueMember = "lbrid";
        }
        public void itemname()
        {
            //query = " select * from tblitem where firmid=" + Data.id + " order by itemname";
            //ds = data.getDataSet(query);
            //DataRow newrow = ds.Tables[0].NewRow();
            //newrow["itemid"] = "0";
            //newrow["itemname"] = "---Select Item Name----";
            //ds.Tables[0].Rows.InsertAt(newrow, 0);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    drpitem.DataSource = ds.Tables[0];
            //    drpitem.ValueMember = "itemid";
            //    drpitem.DisplayMember = "itemname";
            //}
        }
        private void drpitem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void drpname_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            grdtest1.Rows.Clear();
            drpname.SelectedIndex = 0;
            txtrate.Text = "0";
            maxchalan();
            filllst();
            btnsave.Text = "Save";
            txttotal.Text = "0";
            txtAddIGSTAmt.Text = txtAddCGSTAmt.Text = "0";
            txtAddSGSTAmt.Text = txtTotGSTAmt.Text = "0";
            txtRoundoff.Text = txtTotalTaxAmt.Text = "0";
            drpname.Focus();
            dateTimePicker1.Text = DateTime.Now.ToString();
            clear1();
            btndel.Enabled = false;
        }
        public void filllst()
        {
            //query = "SELECT tblclient.Name & '- '& tblchalan.chalanno as name,tblchalan.chalanno as chano FROM tblchalan INNER JOIN tblclient ON tblchalan.clientid = tblclient.id  where BillConf=0 and tblclient.firmid=" + Data.id + " and tblchalan.sessionid=" + Data.sessionid + "";
            //query += " order by tblchalan.chalanno ";
            query = "SELECT convert(char(7),tbl_PurchaseGST.chalanno)+ '- '+ tblclient.compname  as name,tbl_PurchaseGST.chalanno as chano, tbl_PurchaseGST.chalandate FROM tbl_PurchaseGST INNER JOIN tblclient ON tbl_PurchaseGST.clientid = tblclient.id   where tblclient.firmid=" + Data.id + " and BillConf=0 and tbl_PurchaseGST.sessionid=" + Data.sessionid + "";
            query += " and  tbl_PurchaseGST.chalandate >= '" + dtpFrom.Value.ToString("MM/dd/yyyy") + "' and tbl_PurchaseGST.chalandate <= '" + dtpTo.Value.ToString("MM/dd/yyyy") + "' ";
            query += " order by tbl_PurchaseGST.chalanno desc  ";
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
            double rat = Convert.ToDouble(txtrate.Text);
            //if (rat == 0)
            //{
            //    MessageBox.Show("Rate Must be Entered");
            //    txtrate.Focus();
            //    return;
            //}
            //if (drplbr.SelectedIndex == 0)
            //{
            //    MessageBox.Show("Labour Must be Entered");
            //    drplbr.Focus();
            //    return;
            //}
            if (drpitem.Text == "")
            {
                MessageBox.Show("Item Name Must be Enter");
                drpitem.Focus();
                return;
            }
            if (btnadd.Text == "Add")
            {
                grdtest1.Rows.Add();
                curr = grdtest1.Rows.Count - 1;
                int dd = curr + 1;
                grdtest1.Rows[curr].Cells["sno"].Value = dd;
                grdtest1.Rows[curr].Cells["itemid"].Value = "0";
                grdtest1.Rows[curr].Cells["Item"].Value = drpitem.Text;
                grdtest1.Rows[curr].Cells["rate"].Value = txtrate.Text;
                grdtest1.Rows[curr].Cells["qty"].Value = txtqty.Text;
                grdtest1.Rows[curr].Cells["amount"].Value = txtamout.Text;
                grdtest1.Rows[curr].Cells["HSNCode"].Value = txtHSNCode.Text;
                grdtest1.Rows[curr].Cells["TotalAmountAfterTax"].Value = txtAmtafterTax.Text;
                grdtest1.Rows[curr].Cells["Dis"].Value = txtDiscount.Text;
                grdtest1.Rows[curr].Cells["TaxableValue"].Value = txtTaxableValue.Text;
                grdtest1.Rows[curr].Cells["CGST"].Value = txtCGST.Text;
                grdtest1.Rows[curr].Cells["SGST"].Value = txtSGST.Text;
                grdtest1.Rows[curr].Cells["IGST"].Value = txtIGST.Text;
                // grdtest1.Rows[curr].Cells["ravanno"].Value = txtravanno.Text;
                grdtest1.Rows[curr].Cells["Unit"].Value = txtUnit.Text;
                grdtest1.Rows[curr].Cells["Edit1"].Value = "Edit";
                grdtest1.Rows[curr].Cells["del"].Value = "Delete";

            }
            else
            {
                int dd = currow + 1;
                grdtest1.Rows[currow].Cells["sno"].Value = dd;
                grdtest1.Rows[currow].Cells["itemid"].Value = "0";
                grdtest1.Rows[currow].Cells["Item"].Value = drpitem.Text;
                grdtest1.Rows[currow].Cells["rate"].Value = txtrate.Text;
                grdtest1.Rows[currow].Cells["qty"].Value = txtqty.Text;
                grdtest1.Rows[currow].Cells["amount"].Value = txtamout.Text;
                //grdtest1.Rows[currow].Cells["ravanno"].Value = txtravanno.Text;
                grdtest1.Rows[currow].Cells["HSNCode"].Value = txtHSNCode.Text;
                grdtest1.Rows[currow].Cells["TotalAmountAfterTax"].Value = txtAmtafterTax.Text;
                grdtest1.Rows[currow].Cells["Dis"].Value = txtDiscount.Text;
                grdtest1.Rows[currow].Cells["TaxableValue"].Value = txtTaxableValue.Text;
                grdtest1.Rows[currow].Cells["CGST"].Value = txtCGST.Text;
                grdtest1.Rows[currow].Cells["SGST"].Value = txtSGST.Text;
                grdtest1.Rows[currow].Cells["IGST"].Value = txtIGST.Text;
                grdtest1.Rows[currow].Cells["Unit"].Value = txtUnit.Text;
                grdtest1.Rows[currow].Cells["Edit1"].Value = "Edit";
                grdtest1.Rows[currow].Cells["del"].Value = "Delete";
            }
            drpitem.Focus();
            getTotalAmt1();
            //txttotal.Text = getTotalAmt().ToString();
            clear1();
            //if (txtDisount.Text == "0")
            //{
            //    txtNetAmount.Text = txttotal.Text;
            //}
        }

        private double getTotalAmt1()
        {
            double totAmt = 0;
            double totCGST = 0;
            double totSGST = 0;
            double totIGST = 0;
            for (int i = 0; i < grdtest1.Rows.Count; i++)
            {
                totAmt += Convert.ToDouble(grdtest1.Rows[i].Cells["TaxableValue"].Value.ToString());
                totCGST += Convert.ToDouble(grdtest1.Rows[i].Cells["CGST"].Value.ToString());
                totSGST += Convert.ToDouble(grdtest1.Rows[i].Cells["SGST"].Value.ToString());
                totIGST += Convert.ToDouble(grdtest1.Rows[i].Cells["IGST"].Value.ToString());
            }
            txttotal.Text = totAmt.ToString();
            txtAddCGSTAmt.Text = totCGST.ToString();
            txtAddSGSTAmt.Text = totSGST.ToString();
            txtAddIGSTAmt.Text = totIGST.ToString();
            txtTotGSTAmt.Text = Convert.ToDouble(Convert.ToDouble(txtAddCGSTAmt.Text) + Convert.ToDouble(txtAddSGSTAmt.Text) + Convert.ToDouble(txtAddIGSTAmt.Text)).ToString();
            txtTotalTaxAmt.Text = Convert.ToDouble(Convert.ToDouble(txttotal.Text) + Convert.ToDouble(txtTotGSTAmt.Text)).ToString();
            return totAmt;
            return totCGST;
            return totSGST;
            return totIGST;
        }

        public void maxchalan()
        {
            query = " select max(chalanno) as sno from tbl_PurchaseGST where firmid=" + Data.id + " and sessionid=" + Data.sessionid + "";
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
                    //txtravanno.Text = grdtest1.Rows[e.RowIndex].Cells["ravanno"].Value.ToString();
                    txtqty.Text = grdtest1.Rows[e.RowIndex].Cells["qty"].Value.ToString();
                    txtUnit.Text = grdtest1.Rows[e.RowIndex].Cells["Unit"].Value.ToString();
                    txtamout.Text = grdtest1.Rows[e.RowIndex].Cells["amount"].Value.ToString();
                    txtHSNCode.Text = grdtest1.Rows[e.RowIndex].Cells["HSNCode"].Value.ToString();
                    txtAmtafterTax.Text = grdtest1.Rows[e.RowIndex].Cells["TotalAmountAfterTax"].Value.ToString();
                    txtDiscount.Text = grdtest1.Rows[e.RowIndex].Cells["Dis"].Value.ToString();
                    txtTaxableValue.Text = grdtest1.Rows[e.RowIndex].Cells["TaxableValue"].Value.ToString();
                    txtCGST.Text= grdtest1.Rows[e.RowIndex].Cells["CGST"].Value.ToString();
                    txtSGST.Text = grdtest1.Rows[e.RowIndex].Cells["SGST"].Value.ToString();
                    txtIGST.Text = grdtest1.Rows[e.RowIndex].Cells["IGST"].Value.ToString();
                    btnadd.Text = "Update";
                }
                if (grdtest1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Delete")
                {
                    grdtest1.Rows.RemoveAt(e.RowIndex);
                }
            }
            catch
            { }
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            save();
        }
        private double getTotalAmt()
        {
            double totAmt = 0;
            for (int i = 0; i < grdtest1.Rows.Count; i++)
            {
                totAmt += Convert.ToDouble(grdtest1.Rows[i].Cells["amount"].Value.ToString());
            }
            return totAmt;
        }
        public void save()
        {
            if (drpname.SelectedIndex == 0)
            {
                MessageBox.Show("Name must be select");
                drpname.Focus();
                return;
            }
            if (grdtest1.Rows.Count == 0)
            {
                MessageBox.Show("Record's not fount");
                return;
            }
            if (txtInvoiceNo.Text == "")
            {
                MessageBox.Show("Purchase Invoice No must be entered");
                txtInvoiceNo.Focus();
                return;
            }
            if (btnsave.Text == "Save")
            {
                if (data.Exist("select chalanno from tbl_PurchaseGST where chalanno=" + txtchalanno.Text + " and firmid=" + Data.id + " and sessionid=" + Data.sessionid + " "))
                {
                    MessageBox.Show("Chalanno. already Exist");
                    txtchalanno.Focus();
                    return;
                }
                query = " insert into tbl_PurchaseGST(chalanno,totalamt,clientid,chalandate,firmid,lbrid,lbrrate,sessionid,InvoiceNo,InvoiceDate,ADDCGST,ADDSGST,ADDIGST,TOTALGST,RoundOFF,TotalAfterTax)values(@chalanno,@totalamt,@clientid,@chalandate,@firmid,@lbrid,@lbrrate,@sessionid,@InvoiceNo,@InvoiceDate,@ADDCGST,@ADDSGST,@ADDIGST,@TOTALGST,@RoundOFF,@TotalAfterTax)";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@chalanno", txtchalanno.Text);
                cmd.Parameters.AddWithValue("@totalamt", txttotal.Text);
                cmd.Parameters.AddWithValue("@clientid", drpname.SelectedValue);
                cmd.Parameters.AddWithValue("@chalandate", data.getDateMMDDYYYY(dateTimePicker1.Text));
                cmd.Parameters.AddWithValue("@firmid", Data.id);
                cmd.Parameters.AddWithValue("@lbrid", drplbr.SelectedValue);
                cmd.Parameters.AddWithValue("@lbrrate", txtlbrrate.Text);
                cmd.Parameters.AddWithValue("@sessionid", Data.sessionid);
                cmd.Parameters.AddWithValue("@InvoiceNo", txtInvoiceNo.Text);
                cmd.Parameters.AddWithValue("@InvoiceDate", data.getDateMMDDYYYY(dateTimePicker2.Text));  
                cmd.Parameters.AddWithValue("@ADDCGST", txtAddCGSTAmt.Text);
                cmd.Parameters.AddWithValue("@ADDSGST", txtAddSGSTAmt.Text);
                cmd.Parameters.AddWithValue("@ADDIGST", txtAddIGSTAmt.Text);
                cmd.Parameters.AddWithValue("@TOTALGST", txtTotGSTAmt.Text);
                cmd.Parameters.AddWithValue("@RoundOFF", txtRoundoff.Text);
                cmd.Parameters.AddWithValue("@TotalAfterTax", txtTotalTaxAmt.Text);
                data.executeCommand(cmd);
                cmd.Parameters.Clear();
                query = "";
                query = " insert into tbl_PurchaseDtailsGST(ItemName,chalanno,clientid,itemid,price,chalandate,qty,amount,firmid,sessionid,Unit,HSNCode, Discount, TaxableUalue,CGST,SGST,IGST,TotalTaxaValue)values(@ItemName,@chalanno,@clientid,@itemid,@price,@chalandate,@qty,@amount,@firmid,@sessionid,@Unit,@HSNCode, @Discount, @TaxableUalue,@CGST,@SGST,@IGST,@TotalTaxaValue)";
                cmd.CommandText = query;
                for (int i = 0; i < grdtest1.Rows.Count; i++)
                {
                    cmd.Parameters.AddWithValue("@ItemName", grdtest1.Rows[i].Cells["Item"].Value.ToString());
                    cmd.Parameters.AddWithValue("@chalanno", txtchalanno.Text);
                    cmd.Parameters.AddWithValue("@clientid", drpname.SelectedValue);
                    cmd.Parameters.AddWithValue("@itemid", grdtest1.Rows[i].Cells["itemid"].Value.ToString());
                    cmd.Parameters.AddWithValue("@price", grdtest1.Rows[i].Cells["rate"].Value.ToString());
                    cmd.Parameters.AddWithValue("@chalandate", data.getDateMMDDYYYY(dateTimePicker1.Text));
                    cmd.Parameters.AddWithValue("@qty", grdtest1.Rows[i].Cells["qty"].Value.ToString());
                    cmd.Parameters.AddWithValue("@amount", grdtest1.Rows[i].Cells["amount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@firmid", Data.id);
                    cmd.Parameters.AddWithValue("@Unit", grdtest1.Rows[i].Cells["Unit"].Value.ToString());
                    cmd.Parameters.AddWithValue("@HSNCode", grdtest1.Rows[i].Cells["HSNCode"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Discount", grdtest1.Rows[i].Cells["Dis"].Value.ToString());
                    cmd.Parameters.AddWithValue("@TaxableUalue", grdtest1.Rows[i].Cells["TaxableValue"].Value.ToString());
                    cmd.Parameters.AddWithValue("@CGST", grdtest1.Rows[i].Cells["CGST"].Value.ToString());
                    cmd.Parameters.AddWithValue("@SGST", grdtest1.Rows[i].Cells["SGST"].Value.ToString());
                    cmd.Parameters.AddWithValue("@IGST", grdtest1.Rows[i].Cells["IGST"].Value.ToString());
                    cmd.Parameters.AddWithValue("@TotalTaxaValue", grdtest1.Rows[i].Cells["TotalAmountAfterTax"].Value.ToString());
                    cmd.Parameters.AddWithValue("@sessionid", Data.sessionid);
                    data.executeCommand(cmd);
                    cmd.Parameters.Clear();
                }
            }
            else
            {
                query = "delete from tbl_PurchaseGST where chalanno=" + txtchalanno.Text + " and firmid=" + Data.id + " and sessionid=" + Data.sessionid + "";
                data.executeCommand(query);
                query = "delete from tbl_PurchaseDtailsGST where chalanno=" + txtchalanno.Text + " and firmid=" + Data.id + " and sessionid=" + Data.sessionid + "";
                data.executeCommand(query);
                if (data.Exist("select chalanno from tbl_PurchaseGST where chalanno=" + txtchalanno.Text + " and firmid=" + Data.id + "and sessionid=" + Data.sessionid + ""))
                {
                    MessageBox.Show("Chalanno. already Exist");
                    txtchalanno.Focus();
                    return;
                }
                query = " insert into tbl_PurchaseGST(chalanno,totalamt,clientid,chalandate,firmid,lbrid,lbrrate,sessionid,InvoiceNo,InvoiceDate,ADDCGST,ADDSGST,ADDIGST,TOTALGST,RoundOFF,TotalAfterTax)values(@chalanno,@totalamt,@clientid,@chalandate,@firmid,@lbrid,@lbrrate,@sessionid,@InvoiceNo,@InvoiceDate,@ADDCGST,@ADDSGST,@ADDIGST,@TOTALGST,@RoundOFF,@TotalAfterTax)";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@chalanno", txtchalanno.Text);
                cmd.Parameters.AddWithValue("@totalamt", getTotalAmt().ToString());
                cmd.Parameters.AddWithValue("@clientid", drpname.SelectedValue);
                cmd.Parameters.AddWithValue("@chalandate", data.getDateMMDDYYYY(dateTimePicker1.Text));
                cmd.Parameters.AddWithValue("@firmid", Data.id);
                cmd.Parameters.AddWithValue("@lbrid", drplbr.SelectedValue);
                cmd.Parameters.AddWithValue("@lbrrate", txtlbrrate.Text);
                cmd.Parameters.AddWithValue("@sessionid", Data.sessionid);
                cmd.Parameters.AddWithValue("@InvoiceNo", txtInvoiceNo.Text);
                cmd.Parameters.AddWithValue("@InvoiceDate", data.getDateMMDDYYYY(dateTimePicker2.Text));
                cmd.Parameters.AddWithValue("@ADDCGST", txtAddCGSTAmt.Text);
                cmd.Parameters.AddWithValue("@ADDSGST", txtAddSGSTAmt.Text);
                cmd.Parameters.AddWithValue("@ADDIGST", txtAddIGSTAmt.Text);
                cmd.Parameters.AddWithValue("@TOTALGST", txtTotGSTAmt.Text);
                cmd.Parameters.AddWithValue("@RoundOFF", txtRoundoff.Text);
                cmd.Parameters.AddWithValue("@TotalAfterTax", txtTotalTaxAmt.Text);
                data.executeCommand(cmd);
                cmd.Parameters.Clear();

                query = " insert into tbl_PurchaseDtailsGST(ItemName,chalanno,clientid,itemid,price,chalandate,qty,amount,firmid,sessionid,Unit,HSNCode, Discount, TaxableUalue,CGST,SGST,IGST,TotalTaxaValue)values(@ItemName,@chalanno,@clientid,@itemid,@price,@chalandate,@qty,@amount,@firmid,@sessionid,@Unit,@HSNCode, @Discount, @TaxableUalue,@CGST,@SGST,@IGST,@TotalTaxaValue)";
                cmd.CommandText = query;
                for (int i = 0; i < grdtest1.Rows.Count; i++)
                {
                    cmd.Parameters.AddWithValue("@ItemName", grdtest1.Rows[i].Cells["Item"].Value.ToString());
                    cmd.Parameters.AddWithValue("@chalanno", txtchalanno.Text);
                    cmd.Parameters.AddWithValue("@clientid", drpname.SelectedValue);
                    cmd.Parameters.AddWithValue("@itemid", grdtest1.Rows[i].Cells["itemid"].Value.ToString());
                    cmd.Parameters.AddWithValue("@price", grdtest1.Rows[i].Cells["rate"].Value.ToString());
                    cmd.Parameters.AddWithValue("@chalandate", data.getDateMMDDYYYY(dateTimePicker1.Text));
                    cmd.Parameters.AddWithValue("@qty", grdtest1.Rows[i].Cells["qty"].Value.ToString());
                    cmd.Parameters.AddWithValue("@amount", grdtest1.Rows[i].Cells["amount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@firmid", Data.id);
                    cmd.Parameters.AddWithValue("@Unit", grdtest1.Rows[i].Cells["Unit"].Value.ToString());
                    cmd.Parameters.AddWithValue("@sessionid", Data.sessionid);
                    cmd.Parameters.AddWithValue("@HSNCode", grdtest1.Rows[i].Cells["HSNCode"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Discount", grdtest1.Rows[i].Cells["Dis"].Value.ToString());
                    cmd.Parameters.AddWithValue("@TaxableUalue", grdtest1.Rows[i].Cells["TaxableValue"].Value.ToString());
                    cmd.Parameters.AddWithValue("@CGST", grdtest1.Rows[i].Cells["CGST"].Value.ToString());
                    cmd.Parameters.AddWithValue("@SGST", grdtest1.Rows[i].Cells["SGST"].Value.ToString());
                    cmd.Parameters.AddWithValue("@IGST", grdtest1.Rows[i].Cells["IGST"].Value.ToString());
                    cmd.Parameters.AddWithValue("@TotalTaxaValue", grdtest1.Rows[i].Cells["TotalAmountAfterTax"].Value.ToString());
                    data.executeCommand(cmd);
                    cmd.Parameters.Clear();
                }
            }
            MessageBox.Show(btnsave.Text + "Record Successfully !!!");
            clear();
        }
        private void lst_Click(object sender, EventArgs e)
        {
            fillclk();
        }
        public void fillclk()
        {
            string query1; /* INNER JOIN tbllabour ON tblchalan.lbrid = tbllabour.lbrid */
            txttotal.Text = "0";
            DataSet ds1 = new DataSet();
            query1 = "SELECT  tbl_PurchaseGST.InvoiceDate,tbl_PurchaseDtailsGST.price, tbl_PurchaseDtailsGST.amount, tbl_PurchaseGST.InvoiceNo,tbl_PurchaseDtailsGST.chalnid, tblclient.compname, tbl_PurchaseDtailsGST.ItemName, tbl_PurchaseDtailsGST.HSNCode, tbl_PurchaseDtailsGST.Discount,  tbl_PurchaseDtailsGST.TaxableUalue, tbl_PurchaseDtailsGST.Unit, tbl_PurchaseDtailsGST.qty, tbl_PurchaseDtailsGST.CGST, tbl_PurchaseDtailsGST.SGST,  ";
            query1 += " tbl_PurchaseDtailsGST.IGST, tbl_PurchaseDtailsGST.TotalTaxaValue, tbl_PurchaseGST.ADDSGST, tbl_PurchaseGST.ADDCGST, tbl_PurchaseDtailsGST.chalandate, tbl_PurchaseDtailsGST.chalanno, tbl_PurchaseGST.totalamt, tbl_PurchaseGST.ADDIGST, tbl_PurchaseGST.TOTALGST, tbl_PurchaseGST.RoundOFF, tbl_PurchaseGST.TotalAfterTax FROM tbl_PurchaseDtailsGST INNER JOIN tbl_PurchaseGST ON tbl_PurchaseDtailsGST.chalnid = tbl_PurchaseGST.chalid INNER JOIN tblfirm ON tbl_PurchaseDtailsGST.firmid = tblfirm.firmid INNER JOIN tblsession ON tbl_PurchaseDtailsGST.sessionid = tblsession.sessionid INNER JOIN tblclient ON tbl_PurchaseDtailsGST.clientid = tblclient.id  ";
            query1 += " where tbl_PurchaseDtailsGST.chalanno=" + lst.SelectedValue + " and tbl_PurchaseDtailsGST.firmid=" + Data.id + " and tbl_PurchaseGST.sessionid=" + Data.sessionid + " and tbl_PurchaseDtailsGST.sessionid=" + Data.sessionid + "";
            ds1 = data.getDataSet(query1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                grdtest1.Rows.Clear();
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    //drplbr.Text = ds1.Tables[0].Rows[i]["labourname"].ToString();
                    txtchalanno.Text = ds1.Tables[0].Rows[i]["chalanno"].ToString();
                    drpname.Text = ds1.Tables[0].Rows[i]["compname"].ToString();
                    dateTimePicker1.Text = ds1.Tables[0].Rows[0]["chalandate"].ToString();
                    dateTimePicker2.Text = ds1.Tables[0].Rows[0]["InvoiceDate"].ToString();
                    txttotal.Text = ds1.Tables[0].Rows[0]["totalamt"].ToString();
                    txtAddSGSTAmt.Text = ds1.Tables[0].Rows[0]["ADDSGST"].ToString();
                    txtAddIGSTAmt.Text = ds1.Tables[0].Rows[0]["ADDIGST"].ToString();
                    txtAddCGSTAmt.Text = ds1.Tables[0].Rows[0]["ADDCGST"].ToString();
                    txtTotGSTAmt.Text = ds1.Tables[0].Rows[0]["TOTALGST"].ToString();
                    txtRoundoff.Text = ds1.Tables[0].Rows[0]["RoundOFF"].ToString();
                    txtTotalTaxAmt.Text = ds1.Tables[0].Rows[0]["TotalAfterTax"].ToString();
                    grdtest1.Rows.Add();
                    grdtest1.Rows[i].Cells["sno"].Value = grdtest1.Rows.Count;
                    //grdtest1.Rows[i].Cells["itemid"].Value = ds1.Tables[0].Rows[i]["itemid"].ToString();
                    grdtest1.Rows[i].Cells["Item"].Value = ds1.Tables[0].Rows[i]["itemname"].ToString();
                    grdtest1.Rows[i].Cells["rate"].Value = ds1.Tables[0].Rows[i]["price"].ToString();
                    //  grdtest1.Rows[i].Cells["ravanno"].Value = ds1.Tables[0].Rows[i]["ravanano"].ToString();
                    grdtest1.Rows[i].Cells["qty"].Value = ds1.Tables[0].Rows[i]["qty"].ToString();
                    grdtest1.Rows[i].Cells["amount"].Value = ds1.Tables[0].Rows[i]["amount"].ToString();
                    grdtest1.Rows[i].Cells["Unit"].Value = ds1.Tables[0].Rows[i]["Unit"].ToString();
                    grdtest1.Rows[i].Cells["HSNCode"].Value = ds1.Tables[0].Rows[i]["HSNCode"].ToString();
                    grdtest1.Rows[i].Cells["TotalAmountAfterTax"].Value = ds1.Tables[0].Rows[i]["TaxableUalue"].ToString();
                    grdtest1.Rows[i].Cells["Dis"].Value = ds1.Tables[0].Rows[i]["Discount"].ToString();
                    grdtest1.Rows[i].Cells["TaxableValue"].Value = ds1.Tables[0].Rows[i]["TaxableUalue"].ToString();
                    grdtest1.Rows[i].Cells["CGST"].Value = ds1.Tables[0].Rows[i]["CGST"].ToString();
                    grdtest1.Rows[i].Cells["SGST"].Value = ds1.Tables[0].Rows[i]["SGST"].ToString();
                    grdtest1.Rows[i].Cells["IGST"].Value = ds1.Tables[0].Rows[i]["IGST"].ToString();
                    //grdtest1.Rows[i].Cells["Unit"].Value = ds1.Tables[0].Rows[i]["Unit"].ToString();
                    //txtDisount.Text = ds1.Tables[0].Rows[i]["Discount"].ToString();
                    //txtNetAmount.Text = ds1.Tables[0].Rows[i]["NetAmount"].ToString();
                    txtInvoiceNo.Text = ds1.Tables[0].Rows[i]["InvoiceNo"].ToString();
                    grdtest1.Rows[i].Cells["Edit1"].Value = "Edit";
                    grdtest1.Rows[i].Cells["del"].Value = "Delete";
                }
                btnsave.Text = "Update";
                btndel.Enabled = true;
            }
        }
        private void txtqty_TextChanged(object sender, EventArgs e)
        {
            if (txtqty.Text == "")
            {
                // txtqty.Text = "0";
            }
            try
            {
                double rate = Convert.ToDouble(txtrate.Text);
                double qty = Convert.ToDouble(txtqty.Text);
                double amt = rate * qty;
                txtamout.Text = Convert.ToString(amt);
            }
            catch
            {
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            clear1();
        }
        public void clear1()
        {
            txtrate.Text = "0";
            txtamout.Text = "0";
            txtqty.Text = "0";
            drpitem.Text = "";
            txtUnit.Text = txtDiscount.Text = txtTaxableValue.Text = txtAmtafterTax.Text = "";
            txtCGST.Text = txtSGST.Text = txtIGST.Text = txtTotalTaxAmt.Text = "";
            txtHSNCode.Text = "";
            //txtravanno.Text = "";
            btnadd.Text = "Add";
            drpitem.Focus();
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
            if (txtqty.Text == "")
            {
                txtqty.Text = "0";
            }
            try
            {
                double rate = Convert.ToDouble(txtrate.Text);
                double qty = Convert.ToDouble(txtqty.Text);
                double amt = rate * qty;
                txtamout.Text = Convert.ToString(amt);
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
                query = " delete from tbl_PurchaseDtails where firmid=" + Data.id + " and chalanno =" + lst.SelectedValue + " and sessionid=" + Data.sessionid + " ";
                data.executeCommand(query);
                query = " delete from tbl_Purchase where firmid=" + Data.id + " and chalanno=" + lst.SelectedValue + " and sessionid=" + Data.sessionid + " ";
                data.executeCommand(query);
                clear();
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                query = "SELECT tblclient.Name + '- '+ Convert(char(7),tbl_Purchase.chalanno) as name,tbl_Purchase.chalanno as chano FROM tbl_Purchase INNER JOIN tblclient ON tbl_Purchase.clientid = tblclient.id  where tblclient.firmid=" + Data.id + "";
                query += " and tbl_Purchase.chalanno Like '" + textBox1.Text.Trim() + "%' and tbl_Purchase.sessionid=" + Data.sessionid + " and BillConf=0";
                query += " order by tbl_Purchase.chalanno ";
                ds = data.getDataSet(query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lst.DataSource = ds.Tables[0];
                    lst.DisplayMember = "name";
                    lst.ValueMember = "chano";
                }
                else
                {
                    filllst();
                }
            }
            catch
            {
            }
            //query = " select * from tblproduct where productname Like '" + textBox1.Text.Trim() + "%'";
            //ds = data.getDataSet(query);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    lstproduct.DataSource = ds.Tables[0];
            //    lstproduct.DisplayMember = "productname";
            //    lstproduct.ValueMember = "proid";
            //}
            //else
            //{
            //    lstproduct.DataSource = null;
            //}
        }
        private void lst_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void drplbr_SelectedIndexChanged(object sender, EventArgs e)
        {
            labourate();
        }
        public void labourate()
        {
            query = " select * from tbllabourrate where  StaffId =" + drplbr.SelectedValue + " and  firmid=" + Data.id + " ";
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

        private void drplbr_Leave(object sender, EventArgs e)
        {
            labourate();
        }

        private void txtDisount_Leave(object sender, EventArgs e)
        {
            //string Ammount;
            //try
            //{
            //    Ammount = (Convert.ToDouble(txttotal.Text) * Convert.ToDouble(txtDisount.Text) / 100).ToString();
            //    txtNetAmount.Text = (Convert.ToDouble(txttotal.Text) - Convert.ToDouble(Ammount)).ToString();
            //}
            //catch
            //{
            //    txtDisount.Text = "0";
            //}
        }

        private void button6_Click(object sender, EventArgs e)
        {
            query = "SELECT tblclient.compname + '- '+ convert(char(7),tbl_Purchase.chalanno) as name,tbl_Purchase.chalanno as chano,tbl_Purchase.chalandate FROM tbl_Purchase INNER JOIN tblclient ON tbl_Purchase.clientid = tblclient.id  where tblclient.firmid=" + Data.id + " and BillConf=0 and tbl_Purchase.sessionid=" + Data.sessionid + "";
            query += " and  tbl_Purchase.chalandate >= '" + dtpFrom.Value.ToString("MM/dd/yyyy") + "' and tbl_Purchase.chalandate <= '" + dtpTo.Value.ToString("MM/dd/yyyy") + "' ";
            query += " order by tbl_Purchase.chalanno desc ";
            ds = data.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lst.DataSource = ds.Tables[0];
                lst.DisplayMember = "name";
                lst.ValueMember = "chano";
            }
            else
            {
                MessageBox.Show("Data Not Found");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string _search = "%";
            if (textBox2.Text.Trim() != "")
            {
                _search = textBox2.Text.Trim();
            }
            query = "SELECT tblclient.compname + '- '+ convert(char(7),tbl_Purchase.chalanno) as name,tbl_Purchase.chalanno as chano,tbl_Purchase.chalandate FROM tbl_Purchase INNER JOIN tblclient ON tbl_Purchase.clientid = tblclient.id  where tblclient.firmid=" + Data.id + " and BillConf=0 and tbl_Purchase.sessionid=" + Data.sessionid + "";
            query += " and  tbl_Purchase.chalandate >= '" + dtpFrom.Value.ToString("MM/dd/yyyy") + "' and tbl_Purchase.chalandate <= '" + dtpTo.Value.ToString("MM/dd/yyyy") + "' and tbl_Purchase.chalanno like " + _search + " ";
            query += " order by tbl_Purchase.chalanno desc ";
            ds = data.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lst.DataSource = ds.Tables[0];
                lst.DisplayMember = "name";
                lst.ValueMember = "chano";
            }
            else
            {
                MessageBox.Show("Data Not Found");
            }
        }

        private void txtRoundoff_TextChanged(object sender, EventArgs e)
        {
            if (txtRoundoff.Text == "")
            {
                txtRoundoff.Text = "0.00";
            }
            else
            {
                txtTotalTaxAmt.Text = ((Convert.ToDouble(txttotal.Text) + Convert.ToDouble(txtTotGSTAmt.Text)) - Convert.ToDouble(txtRoundoff.Text)).ToString("0.00");
            }
        }

        private void txtCGST_Leave(object sender, EventArgs e)
        {
            if (txtCGST.Text == "")
            {
                txtCGST.Text = "0";
            }
        }

        private void txtSGST_Leave(object sender, EventArgs e)
        {
            if (txtSGST.Text == "")
            {
                txtSGST.Text = "0";
            }
        }

        private void txtIGST_Leave(object sender, EventArgs e)
        {
            if (txtIGST.Text == "")
            {
                txtIGST.Text = "0";
            }
        }
    }
}
