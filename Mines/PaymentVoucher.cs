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
    public partial class PaymentVoucher : Form
    {
        Data data = new Data();
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DataSet ds1 = new DataSet();
        int maxid = 0;
        string query;
        string amt;
        string predrCr;
        string predrCr1;
        public PaymentVoucher()
        {
            InitializeComponent();
        }

        private void PaymentVoucher_Load(object sender, EventArgs e)
        {
            label19.Text = Data.Area;
            fillpartyname();
            fillVoucherNo();
            drpMode.Text = "By Cash";
            drpPatientId.Focus();
        }
        public void fillpartyname()
        {
            query = " SELECT distinct tblclient.Name,tblclient.PartyType,tblclient.id, tblchalan.BillConf FROM tblclient INNER JOIN tblchalan ON tblclient.id = tblchalan.clientid where tblchalan.firmid=" + Data.id + " and tblchalan.sessionid=" + Data.sessionid + "";
            query += " ORDER BY tblclient.Name";
            ds = data.getDataSet(query);
            if (ds.Tables[0].Rows[0]["PartyType"].ToString() == "Vendor" && ds.Tables[0].Rows[0]["PartyType"].ToString() == "RawMaterial")
            {
                DataRow newrow = ds.Tables[0].NewRow();
                newrow["id"] = "0";
                newrow["name"] = "---Select Party Name----";
                ds.Tables[0].Rows.InsertAt(newrow, 0);
                drpPatientId.DataSource = ds.Tables[0];
                drpPatientId.DisplayMember = "name";
                drpPatientId.ValueMember = "id";
            }
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
                txtVocNo.Text = maxid.ToString();
            }
            dr.Close();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void drpPatientId_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (drpPatientId.SelectedIndex > 0)
            //{
            //    query = " SELECT DISTINCT tblclient.Name, tblclient.id, tblclient.Name, tblpending.Amount, tblpending.DrCr";
            //    query += " FROM tblclient INNER JOIN tblpending ON tblclient.id = tblpending.Client_Id where tblpending.Client_Id=" + drpPatientId.SelectedValue + " and tblpending.firmid=" + Data.id + " and tblpending.sessionid=" + Data.sessionid + "";
            //    dr = data.getDataReader(query);
            //    if (dr.Read())
            //    {
            //        txtnetamt.Text = dr["Amount"].ToString();
            //        lbldr.Text = dr["DrCr"].ToString();
            //        amt = dr["Amount"].ToString();
            //    }
            //    dr.Close();
            //}
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
        }
        public void clear()
        {

            fillVoucherNo();
            drpMode.Text = "By Cash";
            txtBank.Text = "";
            txtCheck.Text = "";
            txtPayment.Text = "";
            fillVoucherNo();
            //lblAmtWitIntrest.Text = "0.00";
            lblBillAmt.Text = "0.00";
            lblRemainigAmt.Text = "0.00";
            drpMode.Text = "";
            dateTimePicker4.ResetText();
            txtRemark.Text = "";
            drpPatientId.SelectedIndex = 0;
            drpMode.Text = "By Cash";
            txtnetamt.Text = "0";
        }
        private void txtPayment_TextChanged(object sender, EventArgs e)
        {
            if (txtPayment.Text == "")
            {
                txtPayment.Text = "0";
            }
            calc();
        }
        public void calc()
        {
            double pending = Convert.ToDouble(txtnetamt.Text);
            double payment = Convert.ToDouble(txtPayment.Text);
            double totpend = pending - payment;
            lblRemainigAmt.Text = Convert.ToString(totpend);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }
        public void save()
        {
            if (drpPatientId.SelectedIndex == 0)
            {
                MessageBox.Show("Customer Name must be select");
                drpPatientId.Focus();
                return;
            }
            string trim = lblRemainigAmt.Text.Replace("-", "");
            trim = trim.Replace("-", " ");
            string aa = lblRemainigAmt.Text;
            if (aa.Contains("-") == true)
            {
                predrCr = "Cr";
                predrCr1 = "Cr";
            }
            else
            {
                predrCr = "Dr";
                predrCr1 = "Cr";
            }
            query = " insert into tblldg (Client_Id,CrDr,VocType,BillAmt,VoucherBy,Dat,receptno,chkno,bank,narra,firmid,sessionid)values(@Client_Id,@CrDr,@VocType,@BillAmt,@VoucherBy,@Dat,@receptno,@chkno,@bank,@narra,@firmid,@sessionid)";
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@Client_Id", drpPatientId.SelectedValue);
            cmd.Parameters.AddWithValue("@CrDr", predrCr1);
            cmd.Parameters.AddWithValue("@VocType", "Payment Received");
            cmd.Parameters.AddWithValue("@BillAmt", txtPayment.Text);
            
            cmd.Parameters.AddWithValue("@VoucherBy", drpMode.Text);
            cmd.Parameters.AddWithValue("@Dat", data.getDateMMDDYYYY(dateTimePicker4.Text));
            cmd.Parameters.AddWithValue("@receptno", txtVocNo.Text);
            cmd.Parameters.AddWithValue("@chkno", txtCheck.Text);
            cmd.Parameters.AddWithValue("@bank", txtBank.Text);
            cmd.Parameters.AddWithValue("@narra", txtRemark.Text);
            cmd.Parameters.AddWithValue("@firmid", Data.id);
            cmd.Parameters.AddWithValue("@sessionid", Data.sessionid);
            data.executeCommand(cmd);
            cmd.Parameters.Clear();

            query = " delete from tblpending where Client_Id=" + drpPatientId.SelectedValue + " and firmid=" + Data.id + " and sessionid=" + Data.sessionid + "";
            data.executeCommand(query);
            query = "insert into tblPending (Client_Id,Amount,DrCr,Dat,firmid,sessionid)";
            query += " VALUES(" + drpPatientId.SelectedValue + "," + trim + ",'" + predrCr + "','" + data.getDateMMDDYYYY(dateTimePicker4.Text) + "'," + Data.id + "," + Data.sessionid + ")";
            data.executeCommand(query);
            clear();
            MessageBox.Show("Data Save Sussessfully");
        }
        private void dateTimePicker4_KeyDown(object sender, KeyEventArgs e)
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
                //else if (e.KeyCode == Keys.A)
                //{
                //    Add();
                //}
                //else if (e.KeyCode == Keys.C)
                //{
                //    // clearAll();
                //}
                //else if (e.KeyCode == Keys.D)
                //{
                //    delete();
                //}
            }
            if (e.KeyCode == Keys.F1)
            {
                this.Close();
            }
        }

        private void drpMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpMode.Text == "By Cash") // By Cash //By Cheque// By NEFT
            {
                label14.Visible = false;
                label15.Visible = false;
                txtBank.Visible = false;
                txtCheck.Visible = false;
            }
            else
            {
                label14.Visible = true;
                label15.Visible = true;
                txtBank.Visible = true;
                txtCheck.Visible = true;
            }
        }

    }
}