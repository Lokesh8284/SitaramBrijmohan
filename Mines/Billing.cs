using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq;
namespace WelcomeFabric
{

    public partial class Billing : Form
    {

        #region Declaration
        Data data = new Data();
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DataSet ds1 = new DataSet();
        string query;
        int max = 0;
        int max1 = 0;
        string totalamount;
        string totalamount1;
        string query1;
        string pending;
        string DrCr;
        double calamt;
        string PreDrCr;
        double chkamt;
        double chkamt1;
        string ddid;
        string ddid1;
        double dec;
        string amt;
        string pendrcr;
        string billamt;
        double floorValue;
        double netamt, chkam, penamt;
        #endregion

        #region Initialization
        public Billing()
        {
            InitializeComponent();
        }
        #endregion

        #region Control & Events
        private void Billing_Load(object sender, EventArgs e)
        {
            pnlTotal.Visible = false;
            txtTotalFright.Text = "0.00";
            label19.Text = Data.Area;
            fillpartyname();
            fillchalan();
            maxsno();
            filllst();
            FillDeliverTo();
            btndelete.Enabled = false;
            rdovat.Checked = true;
            dgvInvoice.Visible = false;
            dateTimePicker1.Text = DateTime.Now.ToString();
            clear();
            txtTotal.Leave += new EventHandler(txtTotal_Leave);
            rdoFlat.CheckedChanged += new EventHandler(rdoFlat_CheckedChanged);
            btnConvertToBill.Click += new EventHandler(btnConvertToBill_Click);
        }

        void btnConvertToBill_Click(object sender, EventArgs e)
        {
            if (dgvInvoice.Visible == false)
            {
                pnlTotal.Visible = true;
                dgvInvoice.Rows.Clear();
                dgvInvoice.BringToFront();
                btnConvertToBill.Text = "<<<<Hide";
                dgvInvoice.Visible = true;
                string _ChallanNo = "0";
                data.executeCommand("Truncate table TblTemp");
                double _ffr = 0;
                string _cn = "";
                foreach (DataGridViewRow drow in grdtest1.Rows)
                {

                    if (Convert.ToBoolean(drow.Cells["SelectChallan"].Value))
                    {
                        data.executeCommand("Insert into tblTemp(Temp) values(" + drow.Cells["chalanno"].Value + ")");
                        if (drow.Cells["chalanno"].Value.ToString() != _cn)
                        {
                            _cn = drow.Cells["chalanno"].Value.ToString();
                            _ffr += Convert.ToDouble(drow.Cells["freight"].Value);
                        }
                    }
                }
                txtTotalFright.Text = _ffr.ToString();
                DataSet dsChallan = data.getDataSet("GetAllChallanForBill '" + _ChallanNo + "'," + Data.id + "," + Data.sessionid);
                if (dsChallan != null)
                {
                    foreach (DataRow dr in dsChallan.Tables[0].Rows)
                    {
                        dgvInvoice.Rows.Add();
                        int currow = dgvInvoice.Rows.Count - 1;
                        dgvInvoice.Rows[currow].Cells["srno"].Value = currow + 1;
                        dgvInvoice.Rows[currow].Cells["ProductID"].Value = dr["ItemID"].ToString();
                        dgvInvoice.Rows[currow].Cells["ProductName"].Value = dr["ItemName"].ToString();
                        dgvInvoice.Rows[currow].Cells["Price"].Value = dr["Price"].ToString();
                        dgvInvoice.Rows[currow].Cells["Qnty"].Value = dr["Qty"].ToString();
                        dgvInvoice.Rows[currow].Cells["TAmount"].Value = dr["Amount"].ToString();

                    }
                }
            }
            else
            {
                pnlTotal.Visible = false;
                dgvInvoice.SendToBack();
                btnConvertToBill.Text = "Create Bill";
                dgvInvoice.Visible = false;
            }
            Calc_Amount();
        }

        void rdoFlat_CheckedChanged(object sender, EventArgs e)
        {
            Calc_Amount();
        }

        void txtTotal_Leave(object sender, EventArgs e)
        {
            Calc_Amount();
        }

        private void drpname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpname.SelectedIndex > 0)
            {
                query = "SELECT tblclient.Name, tblchalan.chalanno FROM tblchalan INNER JOIN tblclient ON tblchalan.clientid = tblclient.id";
                query += " where tblchalan.clientid=" + drpname.SelectedValue + " and tblclient.firmid=" + Data.id + "";
                ds = data.getDataSet(query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    drpchalan.DataSource = ds.Tables[0];
                    drpchalan.DisplayMember = "chalanno";
                    drpchalan.ValueMember = "chalanno";
                }
                else
                {
                    drpchalan.DataSource = null;
                }
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            Add();
            Calc_Amount();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear();
            drpname.SelectedIndex = 0;
            drpname.Focus();
            txtTotal.Text = "0";
            txttotalwt.Text = "0";
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            save();
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
                    // clearAll();
                }
                else if (e.KeyCode == Keys.D)
                {
                    // delete();
                }
            }
            if (e.KeyCode == Keys.F1)
            {
                this.Close();
            }
        }

        private void lst_Click(object sender, EventArgs e)
        {
            clicklst();
        }

        private void btnrepint_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You want RePrint Record Press 'Yes' otherwise Press 'No'", "Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Data.query = " RptInvoice '%'," + Data.id + "," + Data.sessionid + "," + txtSearch.Text + "";
                Billrep rep = new Billrep();
                rep.Show();
            }
        }

        private void txtDisc1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ch = (int)e.KeyChar;
            if ((ch < 48 || ch > 58) && (ch != 8) && (ch != 46))
                e.KeyChar = '\0';
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You want Delete Record Press 'Yes' otherwise Press 'No'", "Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    #region Delete Code
                    for (int i = 0; i < grdtest1.Rows.Count; i++)
                    {
                        string chalanno = grdtest1.Rows[i].Cells["chalanno"].Value.ToString();
                        query = " update  chalandetail set BillConf =0 where firmid=" + Data.id + " and chalanno=" + chalanno + " and sessionid=" + Data.sessionid + "";
                        data.executeCommand(query);
                        query = " update  tblchalan set BillConf =0 where firmid=" + Data.id + " and chalanno=" + chalanno + " and sessionid=" + Data.sessionid + "";
                        data.executeCommand(query);
                    }
                    query = " select BillAmt from tblldg where billno=" + lst.SelectedValue + " and firmid=" + Data.id + " and sessionid=" + Data.sessionid + "";
                    ds = data.getDataSet(query);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        billamt = ds.Tables[0].Rows[0]["Billamt"].ToString();
                    }
                    query = " select Amount as Amt,DrCr from tblpending where client_Id=" + ddid + " and firmid=" + Data.id + " and sessionid=" + Data.sessionid + "";
                    ds = data.getDataSet(query);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        amt = ds.Tables[0].Rows[0]["Amt"].ToString();
                        pendrcr = ds.Tables[0].Rows[0]["DrCr"].ToString();
                    }
                    double aamt = Convert.ToDouble(amt);
                    if (aamt > 0)
                    {
                        if (pendrcr == "Dr")
                        {
                            chkam = Convert.ToDouble(billamt);
                            penamt = Convert.ToDouble(amt);
                            netamt = penamt - chkam;
                        }
                        else
                        {
                            chkam = Convert.ToDouble(billamt);
                            penamt = Convert.ToDouble(amt);
                            netamt = penamt + chkam;
                        }
                        string chkdr = Convert.ToString(netamt);
                        if (chkdr.Contains("-"))
                        {
                            pendrcr = "Cr";
                        }
                        else
                        {
                            pendrcr = "Dr";
                        }
                        query = " update tblpending where Amount=" + netamt + " and DrCr='" + pendrcr + "' and client_id=" + ddid + " and firmid=" + Data.id + " and sessionid=" + Data.sessionid + "";
                        data.executeCommand(query);
                    }
                    if (netamt > 0)
                    {
                    }
                    else
                    {
                        query = " delete from tblpending  where client_id=" + ddid + " and firmid=" + Data.id + "and sessionid=" + Data.sessionid + "";
                        data.executeCommand(query);
                    }
                    query = " delete from tblbill where billno=" + lst.SelectedValue + " and firmid=" + Data.id + "and sessionid=" + Data.sessionid + "";
                    data.executeCommand(query);
                    query = " delete from tblbilldetail where billno=" + lst.SelectedValue + " and firmid=" + Data.id + "and sessionid=" + Data.sessionid + "";
                    data.executeCommand(query);
                    query = " delete from tblldg where billno=" + lst.SelectedValue + " and firmid=" + Data.id + "and sessionid=" + Data.sessionid + "";
                    data.executeCommand(query);
                    filllst();
                    clear();
                    #endregion
                }
                catch
                {

                }
            }
        }

        private void grdtest1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                double _Rate = Convert.ToDouble(dgvInvoice.Rows[e.RowIndex].Cells["Price"].Value);
                double _Qty = Convert.ToDouble(dgvInvoice.Rows[e.RowIndex].Cells["Qnty"].Value);
                double _Amount = _Rate * _Qty;
                dgvInvoice.Rows[e.RowIndex].Cells["TAmount"].Value = _Amount.ToString("0.00");

                Calc_Amount();
            }

        }
        private void grdtest1_CellValueChanged1(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    double _Rate = Convert.ToDouble(grdtest1.Rows[e.RowIndex].Cells["Rate"].Value);
            //    double _Qty = Convert.ToDouble(grdtest1.Rows[e.RowIndex].Cells["Qty"].Value);
            //    double _Amount = _Rate * _Qty;
            //    grdtest1.Rows[e.RowIndex].Cells["Amount"].Value = _Amount.ToString("0.00");
            //    grdtest1.Rows[e.RowIndex].Cells["Amount"].Tag = _Amount.ToString("0.00");
            //    grdtest1.Refresh();
            //    grdtest1.NotifyCurrentCellDirty(true);
            //    Calc_Amount();
            //}

        }
        #endregion

        #region Save and Update
        public void save()
        {
            if (grdtest1.Rows.Count == 0)
            {
                MessageBox.Show("Data must be entered");
                return;
            }

            if (btnsave.Text == "Save")
            {
                if (data.Exist("select billno from tblbill where billno=" + txtbillno.Text + " and firmid=" + Data.id + " and sessionid=" + Data.sessionid + " "))
                {
                    MessageBox.Show("Bill No Already Exist");
                    txtbillno.Focus();
                    return;
                }
                cmd.Parameters.Clear();
                query = "IUBILL";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@billno", txtbillno.Text);
                cmd.Parameters.AddWithValue("@totalamt", txtTotal.Text);
                cmd.Parameters.AddWithValue("@clientid", drpname.SelectedValue);
                cmd.Parameters.AddWithValue("@billdate", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@amount", txtNetAmt.Text);
                cmd.Parameters.AddWithValue("@vat", txtvatcal.Text);
                cmd.Parameters.AddWithValue("@Disc", txtDisc1.Text);
                cmd.Parameters.AddWithValue("@grno", txtgr.Text);
                if (dateTimePicker2.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@grdate", dateTimePicker2.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@grdate", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@dispatch", txtdispatch.Text);
                cmd.Parameters.AddWithValue("@fright", txtfright.Text);
                cmd.Parameters.AddWithValue("@vatrate", txtvat.Text);
                cmd.Parameters.AddWithValue("@firmid", Data.id);
                cmd.Parameters.AddWithValue("@aftdis", txtafterdis.Text);
                cmd.Parameters.AddWithValue("@totFright", txtTotalFright.Text);
                cmd.Parameters.AddWithValue("@totQty", txtTotalQty.Text);
                cmd.Parameters.AddWithValue("@TotalAmount", txttotalAmount.Text);
                cmd.Parameters.AddWithValue("@NewDate", DateTime.Now);
                if (rdoFlat.Checked == true)
                {
                    string flat = "F";
                    cmd.Parameters.AddWithValue("@disrat", flat);
                }
                else if (rdoPercent.Checked == true)
                {
                    string flat = "P";
                    cmd.Parameters.AddWithValue("@disrat", flat);
                }
                else
                {
                    string flat = "ND";
                    cmd.Parameters.AddWithValue("@disrat", flat);
                }
                cmd.Parameters.AddWithValue("@discount", txtDiscount.Text);
                cmd.Parameters.AddWithValue("@sessionid", Data.sessionid);
                if (rdovat.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@taxtype", "Vat");
                }
                else if (rdocst.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@taxtype", "Cst");
                }
                cmd.Parameters.AddWithValue("mode", "SAVE");
                if (data.executeCommand(cmd) == 0)
                {
                    cmd.Parameters.Clear();
                    query = "IUBILLDETAILS";
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.StoredProcedure;
                    for (int i = 0; i < grdtest1.Rows.Count; i++)
                    {
                        cmd.Parameters.AddWithValue("@chalanno", grdtest1.Rows[i].Cells["chalanno"].Value.ToString());
                        cmd.Parameters.AddWithValue("@clientid", drpname.SelectedValue);
                        cmd.Parameters.AddWithValue("@itemid", grdtest1.Rows[i].Cells["itemid"].Value.ToString());
                        cmd.Parameters.AddWithValue("@price", grdtest1.Rows[i].Cells["rate"].Value.ToString());
                        cmd.Parameters.AddWithValue("@chalandate", data.getDateMMDDYYYY(grdtest1.Rows[i].Cells["chalandat"].Value.ToString()));
                        cmd.Parameters.AddWithValue("@qty", grdtest1.Rows[i].Cells["qty"].Value.ToString());
                        cmd.Parameters.AddWithValue("@amount", grdtest1.Rows[i].Cells["amount"].Value.ToString());
                        cmd.Parameters.AddWithValue("@ravanano", grdtest1.Rows[i].Cells["ravanano"].Value.ToString());
                        cmd.Parameters.AddWithValue("@billno", txtbillno.Text);
                        cmd.Parameters.AddWithValue("@billdat", data.getDateMMDDYYYY(dateTimePicker1.Text));
                        cmd.Parameters.AddWithValue("@firmid", Data.id);
                        cmd.Parameters.AddWithValue("@sessionid", Data.sessionid);
                        cmd.Parameters.AddWithValue("@Mode", "Save");
                        cmd.Parameters.AddWithValue("@NewDate", DateTime.Now);
                        data.executeCommand(cmd);
                        cmd.Parameters.Clear();
                        if (Convert.ToBoolean(grdtest1.Rows[i].Cells["SelectChallan"].Value))
                        {
                            string chalan = grdtest1.Rows[i].Cells["chalanno"].Value.ToString();
                            int billcon = 1;
                            query = " update tblchalan set BillNo=" + txtbillno.Text + ", BillConf=" + billcon + ", BillDate='" + dateTimePicker1.Value + "' where chalanno=" + chalan + " and firmid=" + Data.id + " and sessionid=" + Data.sessionid + "";
                            data.executeCommand(query);
                            query = " update chalandetail set BillNo=" + txtbillno.Text + ",BillConf=" + billcon + " where chalanno=" + chalan + " and firmid=" + Data.id + " and sessionid=" + Data.sessionid + "";
                            data.executeCommand(query);
                        }
                    }


                    //Invoice Details In other Table
                    // Shakti singh solanki

                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "IUInvoice";
                    cmd.Parameters.Add("@InvoiceID", SqlDbType.BigInt);
                    cmd.Parameters["@InvoiceID"].Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@InvoiceNo", txtbillno.Text);
                    cmd.Parameters.AddWithValue("@InvoiceDate", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@ClientID", drpname.SelectedValue);
                    cmd.Parameters.AddWithValue("@TotalAmount", txtTotal.Text);
                    cmd.Parameters.AddWithValue("@Discount", txtDiscount.Text);
                    cmd.Parameters.AddWithValue("@Vat", txtvatcal.Text);
                    cmd.Parameters.AddWithValue("@Fright", txtTotalFright.Text);
                    cmd.Parameters.AddWithValue("@NetAmount", txtNetAmt.Text);
                    cmd.Parameters.AddWithValue("@FirmID", Data.id);
                    cmd.Parameters.AddWithValue("@SessionID", Data.sessionid);
                    cmd.Parameters.AddWithValue("@UserID", Data.UID);
                    cmd.Parameters.AddWithValue("@Mode", "SAVE");
                    cmd.Parameters.AddWithValue("@NewDate", DateTime.Now);
                    if (data.executeCommand(cmd) == 0)
                    {
                        foreach (DataGridViewRow row in dgvInvoice.Rows)
                        {
                            int _InvoiceID = Convert.ToInt32(cmd.Parameters["@InvoiceID"].Value);
                            cmd.Parameters.Clear();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "IUInvoiceDetails";
                            cmd.Parameters.AddWithValue("@InvoiceDetailID", 0);
                            cmd.Parameters.AddWithValue("@InvoiceID", _InvoiceID);
                            cmd.Parameters.AddWithValue("@ItemID", row.Cells["ProductID"].Value.ToString());
                            cmd.Parameters.AddWithValue("@Quantity", row.Cells["Qnty"].Value.ToString());
                            cmd.Parameters.AddWithValue("@Price", row.Cells["Price"].Value.ToString());
                            cmd.Parameters.AddWithValue("@Amount", row.Cells["TAmount"].Value.ToString());
                            cmd.Parameters.AddWithValue("@Mode", "SAVE");
                            cmd.Parameters.AddWithValue("@NewDate", DateTime.Now);
                            data.executeCommand(cmd);
                        }
                    }
                }
                MessageBox.Show(btnsave.Text + "Record Successfully !!!");
            }
            else
            {
            }
            // clear();
            if (MessageBox.Show("Do You want Print Record Press 'Yes' otherwise Press 'No'", "Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Data.query = " RptInvoice " + drpname.SelectedValue + "," + Data.id + "," + Data.sessionid + "," + txtbillno.Text + "";
                Billrep rep = new Billrep();
                Data.BillingAmt = txttotalwt.Text;
                rep.Show();
            }

            clear();

            #region Clear Datagrid
            query = "GetAllChallan " + 0 + "," + 0 + "," + 0 + "";
            if (dtpDeliveredTo.SelectedIndex > 0)
                query += "," + dtpDeliveredTo.SelectedValue;
            else
                query += ",'%'";
            if (dateTimePicker4.Checked == true && dateTimePicker3.Checked == true)
            {

                query += ",'" + dateTimePicker4.Value + "','" + dateTimePicker3.Value + "',1";
            }
            else
            {
                query += ",'" + dateTimePicker4.Value + "','" + dateTimePicker3.Value + "',0";
            }
            //******************************************
            ds1 = data.getDataSet(query);
            grdtest1.DataSource = ds1.Tables[0];
            #endregion
        }
        #endregion

        #region User Function

        private void Calc_Amount()
        {
            #region Local Variables
            double _Discount = 0;
            double _DiscountAmount = 0;
            double _AfterDiscount = 0;
            double _Fright = 0;
            double _NetTotal = 0;
            double _Vat = 0;
            double _totalQnty = 0;
            double _TotalAmount = 0;
            #endregion

            #region Calcualtions
            _totalQnty = dgvInvoice.Rows.Cast<DataGridViewRow>().Sum(d => Convert.ToDouble(d.Cells["qnty"].Value));
            _TotalAmount = dgvInvoice.Rows.Cast<DataGridViewRow>().Sum(d => Convert.ToDouble(d.Cells["TAmount"].Value));
            _Discount = Convert.ToDouble(txtDisc1.Text);
            if (rdoPercent.Checked)
            {
                _Discount = _Discount / 100 * _TotalAmount;
            }
            _DiscountAmount = _Discount;
            _AfterDiscount = _TotalAmount - _DiscountAmount;
            _Fright = Convert.ToDouble(txtTotalFright.Text);
            _Vat = Convert.ToDouble(txtvat.Text) / 100 * _TotalAmount;
            _NetTotal = _TotalAmount - _DiscountAmount + _Fright + _Vat;
            #endregion

            #region Set Values
            txtTotal.Text = _TotalAmount.ToString("0.00");
            txtTotalQty.Text = _totalQnty.ToString("0");
            txtDiscount.Text = _Discount.ToString("0.00");
            txtafterdis.Text = _AfterDiscount.ToString("0.00");
            txtvatcal.Text = _Vat.ToString("0.00");
            txtNetAmt.Text = _NetTotal.ToString("0.00");
            txttotalAmount.Text = _NetTotal.ToString("0.00");
            #endregion
        }

        public void Add()
        {
            //CREATE PROCEDURE FOR GET ALL CHALLAN OF SELECTED CLIENT
            // CODE BY SHAKTI

            grdtest1.ReadOnly = false;

            query = "GetAllChallan " + drpname.SelectedValue + "," + Data.sessionid + "," + Data.id + "";
            if (dtpDeliveredTo.SelectedIndex > 0)
                query += "," + dtpDeliveredTo.SelectedValue;
            else
                query += ",'%'";
            if (dateTimePicker4.Checked == true && dateTimePicker3.Checked == true)
            {

                query += ",'" + dateTimePicker4.Value + "','" + dateTimePicker3.Value + "',1";
            }
            else
            {
                query += ",'" + dateTimePicker4.Value + "','" + dateTimePicker3.Value + "',0";
            }
            //******************************************
            ds1 = data.getDataSet(query);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                #region Unused
                //grdtest1.Rows.Clear();
                //for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                //{
                //    drpname.Text = ds1.Tables[0].Rows[i]["name"].ToString();
                //    grdtest1.Rows.Add();
                //    grdtest1.Rows[i].Cells["sno"].Value = grdtest1.Rows.Count;
                //    grdtest1.Rows[i].Cells["DeliveredTo"].Value = ds1.Tables[0].Rows[i]["compname"].ToString();
                //    grdtest1.Rows[i].Cells["DeliveredID"].Value = ds1.Tables[0].Rows[i]["DeliveredTo"].ToString();
                //    grdtest1.Rows[i].Cells["chalanno"].Value = ds1.Tables[0].Rows[i]["chalanno"].ToString();
                //    grdtest1.Rows[i].Cells["itemid"].Value = ds1.Tables[0].Rows[i]["itemid"].ToString();
                //    grdtest1.Rows[i].Cells["Item"].Value = ds1.Tables[0].Rows[i]["itemname"].ToString();
                //    grdtest1.Rows[i].Cells["rate"].Value = ds1.Tables[0].Rows[i]["price"].ToString();
                //    grdtest1.Rows[i].Cells["chalandat"].Value = ds1.Tables[0].Rows[i]["chalandate"].ToString();
                //    grdtest1.Rows[i].Cells["qty"].Value = ds1.Tables[0].Rows[i]["qty"].ToString();
                //    grdtest1.Rows[i].Cells["amount"].Value = ds1.Tables[0].Rows[i]["amount"].ToString();
                //    grdtest1.Rows[i].Cells["ravanano"].Value = ds1.Tables[0].Rows[i]["ravanano"].ToString();



                //    Calc_Amount();
                //    txtTotal.Text = Calc_Amount().ToString();
                //    txtTotalQty.Text = gettotalwet().ToString();
                //} 
                #endregion
                grdtest1.DataSource = ds1.Tables[0];
                if (ds1.Tables[1].Rows.Count > 0)
                {
                    txtTotalFright.Text = ds1.Tables[1].Rows[0][0].ToString();
                }
            }
            else
            {
                MessageBox.Show("No Record Found");
                grdtest1.DataSource = ds1.Tables[0];
                txtfright.Text = "";
                txtgr.Text = "";
                txtTotal.Text = "0";
                txtDiscount.Text = "";
                txtafterdis.Text = "";
                txtvatcal.Text = "";
                txtNetAmt.Text = "";
                txttotalwt.Text = "";

            }
            drpname.Focus();
        }

        public void clicklst()
        {
            //if (lst.SelectedValue != null)
            //{
            //    query1 = "SELECT tblclient.Name, tblclient.id,tblbill.totFright, tblbill.totQty,tblbill.TotalAmount, tblbill.totalamt, tblbill.sessionid, tblbill.billno, tblbill.discount, tblbill.disrat, tblbill.aftdis, tblbill.Disc, tblbilldetail.chalanno, tblbill.billdate, tblbill.amount, tblbill.Vat, tblbill.Disc, tblbill.grno, tblbill.grdate, tblbill.dispatch, tblbill.fright, tblbill.taxtype, convert(char(11),tblbilldetail.chalandate,103) AS chalandate, tblbilldetail.ravanano, tblitem.itemid, tblbilldetail.amount AS amt, tblbilldetail.qty, tblbilldetail.price, tblitem.itemname FROM ((tblclient INNER JOIN tblbill ON tblclient.id = tblbill.clientid) INNER JOIN tblbilldetail ON (tblbilldetail.sessionid = tblbill.sessionid) AND (tblbill.billno = tblbilldetail.billno) AND (tblbill.firmid = tblbilldetail.firmid)) INNER JOIN tblitem ON tblbilldetail.itemid = tblitem.itemid";
            //    query1 += " where tblbill.billno=" + lst.SelectedValue + "";
            //    query1 += " and tblbill.firmid=" + Data.id + "";
            //    query1 += " and tblbill.sessionid=" + Data.sessionid + "";
            //    query1 += " and tblbilldetail.sessionid=" + Data.sessionid + "";
            //    query1 += " order by tblbilldetail.chalanno";
            //    ds1 = data.getDataSet(query1);
            //    if (ds1.Tables[0].Rows.Count > 0)
            //    {
            //        grdtest1.Rows.Clear();
            //        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            //        {
            //            string chkdd = ds1.Tables[0].Rows[0]["disrat"].ToString();
            //            if (chkdd == "P")
            //            {
            //                rdoPercent.Checked = true;
            //            }
            //            else if (chkdd == "F")
            //            {
            //                rdoFlat.Checked = true;
            //            }
            //            grdtest1.Rows.Add();
            //            grdtest1.Rows[i].Cells["sno"].Value = grdtest1.Rows.Count;
            //            grdtest1.Rows[i].Cells["chalanno"].Value = ds1.Tables[0].Rows[i]["chalanno"].ToString();
            //            grdtest1.Rows[i].Cells["itemid"].Value = ds1.Tables[0].Rows[i]["itemid"].ToString();
            //            grdtest1.Rows[i].Cells["Item"].Value = ds1.Tables[0].Rows[i]["itemname"].ToString();
            //            grdtest1.Rows[i].Cells["rate"].Value = ds1.Tables[0].Rows[i]["price"].ToString();
            //            grdtest1.Rows[i].Cells["chalandat"].Value = ds1.Tables[0].Rows[i]["chalandate"].ToString();
            //            grdtest1.Rows[i].Cells["qty"].Value = ds1.Tables[0].Rows[i]["qty"].ToString();
            //            grdtest1.Rows[i].Cells["amount"].Value = ds1.Tables[0].Rows[i]["amt"].ToString();
            //            //grdtest1.Rows[i].Cells["Edit1"].Value = "Edit";
            //            //grdtest1.Rows[i].Cells["del"].Value = "Delete";
            //            grdtest1.Rows[i].Cells["ravanano"].Value = ds1.Tables[0].Rows[i]["ravanano"].ToString();
            //        }
            //        drpname.Text = ds1.Tables[0].Rows[0]["name"].ToString();
            //        ddid1 = ds1.Tables[0].Rows[0]["id"].ToString();
            //        dateTimePicker1.Text = ds1.Tables[0].Rows[0]["billdate"].ToString();
            //        txtbillno.Text = ds1.Tables[0].Rows[0]["billno"].ToString();
            //        txtTotal.Text = ds1.Tables[0].Rows[0]["totalamt"].ToString();
            //        txtDisc1.Text = ds1.Tables[0].Rows[0]["Disc"].ToString();
            //        txtDiscount.Text = ds1.Tables[0].Rows[0]["Discount"].ToString();
            //        txtafterdis.Text = ds1.Tables[0].Rows[0]["aftdis"].ToString();
            //        txtvatcal.Text = ds1.Tables[0].Rows[0]["Vat"].ToString();
            //        txtNetAmt.Text = ds1.Tables[0].Rows[0]["amount"].ToString();
            //        txtTotalFright.Text = ds1.Tables[0].Rows[0]["totFright"].ToString();
            //        txtTotalQty.Text = ds1.Tables[0].Rows[0]["totQty"].ToString();
            //        txttotalAmount.Text = ds1.Tables[0].Rows[0]["TotalAmount"].ToString();
            //        string tax = ds1.Tables[0].Rows[0]["taxtype"].ToString();
            //        if (tax == "Vat")
            //        {
            //            rdovat.Checked = true;
            //        }
            //        else if (tax == "Cst")
            //        {
            //            rdocst.Checked = true;
            //        }
            //    }
            //    btnsave.Enabled = false;
            //    btndelete.Enabled = true;
            //    Calc_Amount();
            //}
        }

        public void clear()
        {
            pnlTotal.Visible = false;
            txtvat.Text = "0";
            DataSet dg = new DataSet();
            dg = data.getDataSet("Select fax from tblfirm where firmid=" + Data.id);
            if (dg.Tables[0].Rows.Count > 0)
            {
                if (dg.Tables[0].Rows[0]["fax"].ToString() == ""
                    || dg.Tables[0].Rows[0]["fax"].ToString() == null)
                {
                    txtvat.Text = "0";
                }
                else
                {
                    txtvat.Text = dg.Tables[0].Rows[0]["fax"].ToString();
                }
            }
            dgvInvoice.SendToBack();
            btnConvertToBill.Text = "Create Bill";
            dgvInvoice.Visible = false;
            dateTimePicker4.Text = DateTime.Now.ToString();
            dateTimePicker3.Text = DateTime.Now.ToString();
            dateTimePicker2.Text = DateTime.Now.ToString();
            dateTimePicker1.Text = DateTime.Now.ToString();
            //DataSet dss = new DataSet();
            //ds1.Tables[0].Rows.Clear();
            //grdtest1.DataSource = ds1;
            drpname.SelectedIndex = 0;
            dgvInvoice.Visible = false;
            dgvInvoice.Rows.Clear();
            txtTotal.Text = "0.00";
            txtNetAmt.Text = "0.00";
            txtTotalFright.Text = "0.00";
            txttotalwt.Text = "0";
            txtAdv.Text = "0.00";
            txtDisc1.Text = "0";
            txtafterdis.Text = "0";
            fillpartyname();
            maxsno();
            filllst();
            btnsave.Text = "Save";
            btnsave.Enabled = true;
            btndelete.Enabled = false;
            rdocst.Checked = false;
            rdovat.Checked = true;
        }

        public void filllst()
        {
            query = "SELECT   Convert(char(7),tblbill.billno) + '-' + tblclient.compname  as name,tblclient.id,tblbill.billno FROM tblclient INNER JOIN tblbill ON tblclient.id = tblbill.clientid where tblbill.firmid=" + Data.id + " and tblbill.sessionid=" + Data.sessionid + " order by billno ";
            ds = data.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lst.DataSource = ds.Tables[0];
                lst.DisplayMember = "name";
                lst.ValueMember = "billno";
                ddid = ds.Tables[0].Rows[0]["id"].ToString();
            }
            else
            {
                lst.DataSource = null;
            }
        }

        public void FillDeliverTo()
        {
            query = " select * from tbl_DeliveredTo where firmid=" + Data.id + " order by name";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["id"] = "0";
            newrow["compname"] = "---Select Delivered ----";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            dtpDeliveredTo.DataSource = ds.Tables[0];
            dtpDeliveredTo.DisplayMember = "compname";
            dtpDeliveredTo.ValueMember = "id";
        }

        public void fillpartyname()
        {
            query = " SELECT distinct tblchalan.clientid,tblclient.id,tblclient.compName FROM tblchalan INNER JOIN tblclient ON tblchalan.clientid = tblclient.id ";
            query += " where tblclient.firmid=" + Data.id + " and tblchalan.BillConf=0 ORDER BY tblclient.CompName";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["id"] = "0";
            newrow["compname"] = "---Select Party Name----";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            drpname.DataSource = ds.Tables[0];
            drpname.DisplayMember = "compname";
            drpname.ValueMember = "id";
        }

        public void fillchalan()
        {
            //query = " select * from tblchalan order by chalanno";
            //ds = data.getDataSet(query);
            //DataRow newrow = ds.Tables[0].NewRow();
            //newrow["chalanno"] = "0";
            //newrow["chalanno"] = "---All Chalan----";
            //ds.Tables[0].Rows.InsertAt(newrow, 0);
            //drpchalan.DataSource = ds.Tables[0];
            //drpchalan.DisplayMember = "chalanno";
            //drpchalan.ValueMember = "chalanno";
        }

        public void maxsno()
        {
            query = " select max(billno) as sno from tblbill where firmid=" + Data.id + " and sessionid=" + Data.sessionid + "";
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
                txtbillno.Text = Convert.ToString(max1);
            }
            dr.Close();
        }
        #endregion

        private void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (grdtest1.Rows.Count > 0)
            {
                foreach (DataGridViewRow dr in grdtest1.Rows)
                {
                    dr.Cells["SelectChallan"].Value = chkSelect.Checked;
                }
            }
        }
    }
}
