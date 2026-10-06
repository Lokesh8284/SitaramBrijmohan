using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Data.SqlClient;
using WelcomeFabric;

namespace WelcomeFabric
{
    public partial class EditBill : Form
    {
        Data data = new Data();
        string query;
        DataSet ds = new DataSet();
        public EditBill()
        {
            InitializeComponent();
        }

        private void EditBill_Load(object sender, EventArgs e)
        {
            Clear();
            btndelete.Visible = false;
        }

        void txtTotal_Leave(object sender, EventArgs e)
        {
            Calc_Amount();
        }

        public void fillpartyname()
        {
            query = " SELECT distinct tblchalan.clientid,tblclient.id,tblclient.compName FROM tblchalan INNER JOIN tblclient ON tblchalan.clientid = tblclient.id ";
            query += " where tblclient.firmid=" + Data.id + " and tblchalan.BillConf=0 ORDER BY tblclient.CompName";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["id"] = "0";
            newrow["compname"] = "---Select Client---";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            cmbClientName.DataSource = ds.Tables[0];
            cmbClientName.DisplayMember = "compname";
            cmbClientName.ValueMember = "id";
        }


        public void GetChallanReport()
        {
            if (txtSearch.Text == "")
            {
                query = "GetInvoiceDetailForEdit " + Data.id + "," + Data.sessionid + ",'" + lst.SelectedValue + "'";

                DataSet ds1 = data.getDataSet(query);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    txtSearch.ReadOnly = true;
                    dtpBillDate.Value = Convert.ToDateTime(ds1.Tables[0].Rows[0]["IDate"].ToString());
                    cmbClientName.SelectedValue = ds1.Tables[0].Rows[0]["ClientID"].ToString();
                    txtDiscount.Text = ds1.Tables[0].Rows[0]["ClientID"].ToString();
                    // txtvatcal.Text = ds1.Tables[0].Rows[0]["Vat"].ToString();
                    txtNetAmt.Text = ds1.Tables[0].Rows[0]["NetAmount"].ToString();
                    txttotalAmount.Text = ds1.Tables[0].Rows[0]["NetAmount"].ToString();
                    txtTotalFright.Text = ds1.Tables[0].Rows[0]["Fright"].ToString();
                    txtvat.Text = ds1.Tables[0].Rows[0]["Vat"].ToString();
                    dgvInvoice.Rows.Clear();
                    foreach (DataRow dr in ds1.Tables[0].Rows)
                    {
                        dgvInvoice.Rows.Add();
                        int currow = dgvInvoice.Rows.Count - 1;
                        dgvInvoice.Rows[currow].Cells["InvoiceDetailID"].Value = dr["InvoiceDetailID"].ToString();
                        dgvInvoice.Rows[currow].Cells["srno"].Value = currow + 1;
                        dgvInvoice.Rows[currow].Cells["ProductName"].Value = dr["ItemName"].ToString();
                        dgvInvoice.Rows[currow].Cells["ProductID"].Value = "0";
                        dgvInvoice.Rows[currow].Cells["Price"].Value = dr["Price"].ToString();
                        if (dr["Amount"].ToString() == "0.00")
                        {
                            dgvInvoice.Rows[currow].Cells["TAmount"].Value = "";
                        }
                        else
                        {
                            dgvInvoice.Rows[currow].Cells["TAmount"].Value = dr["Amount"].ToString();
                        }
                        dgvInvoice.Rows[currow].Cells["Qnty"].Value = dr["quantity"].ToString();
                    }
                    Calc_Amount();
                }
                else
                {
                    dgvInvoice.Rows.Clear();
                    MessageBox.Show("Record Not Found");
                }
            }
            else
            {
                query = "GetInvoiceDetailForEdit " + Data.id + "," + Data.sessionid + ",'" + txtSearch.Text + "'";

                DataSet ds1 = data.getDataSet(query);

                if (ds1.Tables[0].Rows.Count > 0)
                {
                    txtSearch.ReadOnly = true;
                    dtpBillDate.Value = Convert.ToDateTime(ds1.Tables[0].Rows[0]["IDate"].ToString());
                    cmbClientName.SelectedValue = ds1.Tables[0].Rows[0]["ClientID"].ToString();
                    txtDiscount.Text = ds1.Tables[0].Rows[0]["ClientID"].ToString();
                    // txtvatcal.Text = ds1.Tables[0].Rows[0]["Vat"].ToString();
                    txtNetAmt.Text = ds1.Tables[0].Rows[0]["NetAmount"].ToString();
                    txttotalAmount.Text = ds1.Tables[0].Rows[0]["NetAmount"].ToString();
                    txtTotalFright.Text = ds1.Tables[0].Rows[0]["Fright"].ToString();
                    txtvat.Text = ds1.Tables[0].Rows[0]["Vat"].ToString();
                    dgvInvoice.Rows.Clear();
                    foreach (DataRow dr in ds1.Tables[0].Rows)
                    {
                        dgvInvoice.Rows.Add();
                        int currow = dgvInvoice.Rows.Count - 1;
                        dgvInvoice.Rows[currow].Cells["InvoiceDetailID"].Value = dr["InvoiceDetailID"].ToString();
                        dgvInvoice.Rows[currow].Cells["srno"].Value = currow + 1;
                        dgvInvoice.Rows[currow].Cells["ProductName"].Value = dr["ItemName"].ToString();
                        dgvInvoice.Rows[currow].Cells["ProductID"].Value = "0";
                        dgvInvoice.Rows[currow].Cells["Price"].Value = dr["Price"].ToString();
                        if (dr["Amount"].ToString() != "")
                        {
                            dgvInvoice.Rows[currow].Cells["TAmount"].Value = dr["Amount"].ToString();
                        }
                        else
                        {
                            dgvInvoice.Rows[currow].Cells["TAmount"].Value = "0.00";
                        }
                        dgvInvoice.Rows[currow].Cells["Qnty"].Value = dr["quantity"].ToString();
                    }

                    Calc_Amount();
                }
                else
                {
                    dgvInvoice.Rows.Clear();
                    MessageBox.Show("Record Not Found");
                }
            }
        }

        private void dgvInvoice_CellValidated(object sender, DataGridViewCellEventArgs e)
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
            txtDiscount.Text = _Discount.ToString("0.00");
            txtafterdis.Text = _AfterDiscount.ToString("0.00");
            txtvatcal.Text = _Vat.ToString("0.00");   
            txtNetAmt.Text = _NetTotal.ToString("0.00");
            txttotalAmount.Text = _NetTotal.ToString("0.00");
            #endregion
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetChallanReport();
            btndelete.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                MessageBox.Show("Invoice Can't Be Empty");
                txtSearch.Focus();
                return;
            }
            if (dgvInvoice.Rows.Count <= 0)
            {
                MessageBox.Show("Data Can't Be Empty");
                dgvInvoice.Focus();
                return;
            }
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "IUInvoice";
            cmd.Parameters.Add("@InvoiceID", SqlDbType.BigInt);
            cmd.Parameters["@InvoiceID"].Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@InvoiceNo", txtSearch.Text);
            cmd.Parameters.AddWithValue("@InvoiceDate", dtpBillDate.Value);
            cmd.Parameters.AddWithValue("@ClientID", cmbClientName.SelectedValue);
            cmd.Parameters.AddWithValue("@TotalAmount", txtTotal.Text);
            cmd.Parameters.AddWithValue("@Discount", txtDiscount.Text);
            cmd.Parameters.AddWithValue("@Vat", txtvatcal.Text);
            cmd.Parameters.AddWithValue("@Fright", txtTotalFright.Text);
            cmd.Parameters.AddWithValue("@NetAmount", txtNetAmt.Text);
            cmd.Parameters.AddWithValue("@FirmID", Data.id);
            cmd.Parameters.AddWithValue("@SessionID", Data.sessionid);
            cmd.Parameters.AddWithValue("@UserID", Data.UID);
            cmd.Parameters.AddWithValue("@Mode", "UPDATE");
            if (data.executeCommand(cmd) == 0)
            {
                foreach (DataGridViewRow row in dgvInvoice.Rows)
                {
                    //int _InvoiceID = Convert.ToInt32(cmd.Parameters["@InvoiceID"].Value);
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "IUInvoiceDetails";
                    cmd.Parameters.AddWithValue("@InvoiceDetailID", row.Cells["InvoiceDetailID"].Value.ToString());
                    cmd.Parameters.AddWithValue("@InvoiceID", 0);
                    cmd.Parameters.AddWithValue("@ItemID", row.Cells["ProductID"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Quantity", row.Cells["Qnty"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Price", row.Cells["Price"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Amount", row.Cells["TAmount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@Mode", "UPDATE");
                    data.executeCommand(cmd);
                }

                if (MessageBox.Show("Do You want Print Record Press 'Yes' otherwise Press 'No'", "Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Data.query = " RptInvoice " + cmbClientName.SelectedValue + "," + Data.id + "," + Data.sessionid + "," + txtSearch.Text + "";
                    Billrep rep = new Billrep();
                    rep.Show();
                }
                Clear();
            }


        }

        public void Clear()
        {
            filllst();
            fillpartyname();
            txtSearch.Text = "";
            txtSearch.ReadOnly = false;
            dgvInvoice.Rows.Clear();
            txtTotal.Text = "0.00";
            txtNetAmt.Text = "0.00";
            txtTotalFright.Text = "0.00";
            txttotalAmount.Text = "0";
            txtDisc1.Text = "0";
            txtafterdis.Text = "0";

            txtvatcal.Text = "";
            btndelete.Visible = false;
        }
        public void filllst()
        {
            query = "SELECT  + 'Date('+ convert(nvarchar(15), t1.InvoiceDate,103) + ' )- InvoiceNo - '+ convert(nvarchar(15),t1.InvoiceNo) as bDate";
            query += " , t1.InvoiceNo,c1.compname as ClientName  FROM tbl_Invoice t1 ";
            query += " LEFT JOIN tblclient c1 ON t1.ClientID=c1.id where t1.InvoiceDate >= '" + dtpFrom.Value + "' and t1.InvoiceDate <= '" + dtpTo.Value + "'";
            ds = data.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lst.DataSource = ds.Tables[0];
                lst.DisplayMember = "bDate";
                lst.ValueMember = "InvoiceNo";
            }
            else
            {
                lst.DataSource = null;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You want Delete Record Press 'Yes' otherwise Press 'No'", "Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string delete = "delete from tbl_Invoice where FirmID= " + Data.id + " and SessionID=" + Data.sessionid + " and InvoiceNo='" + txtSearch.Text + "'";
                data.executeCommand(delete);

                string delete2 = " delete from tbl_InvoiceDetails where FirmID= " + Data.id + " and SessionID=" + Data.sessionid + " and InvoiceNo='" + txtSearch.Text + "'";
                data.executeCommand(delete2);

                string delete3 = " delete from tblbill where FirmID= " + Data.id + " and SessionID=" + Data.sessionid + " and billno='" + txtSearch.Text + "'";
                data.executeCommand(delete3);

                string delete4 = " delete from tblbilldetail where FirmID= " + Data.id + " and SessionID=" + Data.sessionid + " and billno='" + txtSearch.Text + "'";
                data.executeCommand(delete4);

                string Update = " Update tblchalan set BillConf=0 , billno=null where FirmID= " + Data.id + " and SessionID=" + Data.sessionid + " and billno='" + txtSearch.Text + "'  ";
                data.executeCommand(Update);
                string Update1 = " Update chalandetail set BillConf=0 , billno=null where FirmID= " + Data.id + " and SessionID=" + Data.sessionid + " and billno='" + txtSearch.Text + "'  ";
                data.executeCommand(Update1);
                MessageBox.Show(" Records Delete Successfully !!!! ");
            }
            else
            {

            }
        }

        private void lst_Click(object sender, EventArgs e)
        {
            GetChallanReport();
            btndelete.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            query = "SELECT  + 'Date('+ convert(nvarchar(15), t1.InvoiceDate,103) + ' )- InvoiceNo - '+ convert(nvarchar(15),t1.InvoiceNo) as bDate";
            query += " , t1.InvoiceNo,c1.compname as ClientName  FROM tbl_Invoice t1 ";
            query += " LEFT JOIN tblclient c1 ON t1.ClientID=c1.id  where t1.InvoiceDate >= '" + dtpFrom.Value.ToString("MM/dd/yyyy") + "' and t1.InvoiceDate <= '" + dtpTo.Value.ToString("MM/dd/yyyy") + "' ";
            ds = data.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lst.DataSource = ds.Tables[0];
                lst.DisplayMember = "bDate";
                lst.ValueMember = "InvoiceNo";
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
            query = "SELECT  + 'Date('+ convert(nvarchar(15), t1.InvoiceDate,103) + ' )- InvoiceNo - '+ convert(nvarchar(15),t1.InvoiceNo) as bDate";
            query += " , t1.InvoiceNo,c1.compname as ClientName  FROM tbl_Invoice t1 ";
            query += " LEFT JOIN tblclient c1 ON t1.ClientID=c1.id  where t1.InvoiceDate >= '" + dtpFrom.Value.ToString("MM/dd/yyyy") + "' and t1.InvoiceDate <= '" + dtpTo.Value.ToString("MM/dd/yyyy") + "' and t1.InvoiceNo like " + _search + "  ";
            ds = data.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lst.DataSource = ds.Tables[0];
                lst.DisplayMember = "bDate";
                lst.ValueMember = "InvoiceNo";
            }
            else
            {
                MessageBox.Show("Data Not Found");
            }
        }
    }
}
