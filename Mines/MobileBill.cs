using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace WelcomeFabric
{
    public partial class MobileBill : Form
    {
        Data data = new Data();
        string query = "";
        DataSet ds = new DataSet();
        int max1 = 0;
        string _IDD = "";
        public MobileBill()
        {
            InitializeComponent();
        }
        public MobileBill(string idd)
        {
            InitializeComponent();
            this._IDD = idd;
        }

        private void MobileBill_Load(object sender, EventArgs e)
        {
            Reset();
            if (_IDD != "")
            {
                GetPendingOrder(_IDD);
            }
        }

        private void Reset()
        {
            maxchalan();
            filllst();
            partyname();
            grdtest1.Rows.Clear();
            CheckPendingOrder();
            btnsave.Text = "Save";
            btndel.Enabled = false;
            btnReprint.Visible = false;
            txtMoblieNo.Text = "";
            txttotal.Text = txtTotalQty.Text = txtTotalTaxAmt.Text = "0";
        }

        private void GetPendingOrder(string OrderId)
        {
            DataTable dtt = data.GetDataTable("select Row_number() over (order by itemname)SNo, * from GetPendingOrders where firmid='" + Data.id + "' and OD.OrderID=" + OrderId + " order by itemname");
            grdtest1.AutoGenerateColumns = false;
            grdtest1.DataSource = dtt;
        }

        public void maxchalan()
        {
            query = " select max(chalanno) as sno from tbl_GstChallan where Delid=0 and EFlag='S' and firmid=" + Data.id + " and sessionid=" + Data.sessionid + "";
            SqlDataReader dr = data.getDataReader(query);
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

        private void CheckPendingOrder()
        {
            DataTable dtt = data.GetDataTable("Select P.*,'Bill' as Bill,(Row_number() over (Order By p.id))SNo,U.Name  from tbl_TempOrder P inner join tbl_user U on U.id=P.CreatedBy where P.IsGenerateBill=0 and P.Firmid=" + Data.id);
            lstPending.DataSource = dtt;
            lstPending.DisplayMember = "OrderNo";
            lstPending.ValueMember = "id";
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

        public void filllst()
        {
            query = "GetAllChallans_GST " + Data.id + "," + Data.sessionid + ",'"
                + Convert.ToDateTime(dtpFrom.Value).ToString("MM/dd/yyyy") + "','" + Convert.ToDateTime(dtpTo.Value).ToString("MM/dd/yyyy") + "','%','S'";
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            Save("");
        }

        public void Save(string OrderId)
        {
            #region firmname
            DataSet dsfirm = data.getDataSet("select ShortName from tblfirm where firmid=" + Data.id);

            DataSet dssession = data.getDataSet("select session from tblsession where sessionid=" + Data.sessionid);
            #endregion

            string reference = dsfirm.Tables[0].Rows[0]["ShortName"].ToString() + "/" + dssession.Tables[0].Rows[0]["session"].ToString() + "/";

            SqlConnection myConnection = new SqlConnection(data.conString);
            myConnection.Open();

            SqlCommand cmd = myConnection.CreateCommand();
            SqlTransaction myTrans;
            myTrans = myConnection.BeginTransaction();
            try
            {
                cmd.Connection = myConnection;
                cmd.Transaction = myTrans;

                DataTable dtt = data.GetDataTable("select * from GetOrderDetails where id=" + OrderId);

                #region Main
                cmd.CommandText = "InvoiceSaveModify";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@chalid", lblMainId.Text);
                cmd.Parameters.AddWithValue("@Type1", btnsave.Text);
                cmd.Parameters.AddWithValue("@chalanno", "0");
                cmd.Parameters.AddWithValue("@totalamt", dtt.Rows[0]["TotalAmount"].ToString());
                cmd.Parameters.AddWithValue("@clientid", dtt.Rows[0]["PartyID"].ToString());
                cmd.Parameters.AddWithValue("@chalandate", DateTime.Now);
                cmd.Parameters.AddWithValue("@firmid", Data.id);
                cmd.Parameters.AddWithValue("@mobileno", dtt.Rows[0]["Mob"].ToString());
                cmd.Parameters.AddWithValue("@sessionid", Data.sessionid);
                cmd.Parameters.AddWithValue("@TotalTaxAmt", dtt.Rows[0]["TotalAmount"].ToString());
                cmd.Parameters.AddWithValue("@MaxId", "0");
                cmd.Parameters.AddWithValue("@EFlag", "S");
                cmd.Parameters.AddWithValue("@PaymentMode", "Cash");
                cmd.Parameters.AddWithValue("@Discount", "0");
                cmd.Parameters.AddWithValue("@GstBeforeAmt", dtt.Rows[0]["TotalAmount"].ToString());
                cmd.Parameters.AddWithValue("@DateofSupply", DateTime.Now);
                cmd.Parameters.AddWithValue("@TotalQty", dtt.Rows[0]["TotalQty"].ToString());
                cmd.Parameters.AddWithValue("@ReferenceNumber", reference);
                cmd.Parameters.AddWithValue("@DueAmount", "0");
                cmd.Parameters.AddWithValue("@PaidAmount", "0");
                cmd.Parameters.AddWithValue("@DisType", "Flat");
                cmd.Parameters.AddWithValue("@GenerateBy", "Mobile");
                cmd.Parameters.AddWithValue("@OrderId", dtt.Rows[0]["id"].ToString());
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
                foreach (DataRow drr in dtt.Rows)
                {
                    cmd.Parameters.Clear();
                    query = " insert into tbl_GstChallanDetails(chalanno,clientid,itemid,price,chalandate,qty,amount,firmid,sessionid,Unit,GrossTotal,TaxableValue,MaxId,EFlag,MainId,GenerateBy,OrderId,OrderDetlId)values(@chalanno,@clientid,@itemid,@price,@chalandate,@qty,@amount,@firmid,@sessionid,@Unit,@GrossTotal,@TaxableValue,@MaxId,@EFlag,@MainId,@GenerateBy,@OrderId,@OrderDetlId)";
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@chalanno", txtchalanno.Text);
                    cmd.Parameters.AddWithValue("@clientid", drr["PartyID"].ToString());
                    cmd.Parameters.AddWithValue("@itemid", drr["ItemID"].ToString());
                    cmd.Parameters.AddWithValue("@price", drr["Rate"].ToString());
                    cmd.Parameters.AddWithValue("@chalandate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@qty", drr["Qty"].ToString());
                    cmd.Parameters.AddWithValue("@amount", drr["Amount"].ToString());
                    cmd.Parameters.AddWithValue("@firmid", Data.id);
                    cmd.Parameters.AddWithValue("@Unit", drr["Unit"].ToString());
                    cmd.Parameters.AddWithValue("@TaxableValue", drr["Amount"].ToString());
                    cmd.Parameters.AddWithValue("@GrossTotal", drr["Amount"].ToString());
                    cmd.Parameters.AddWithValue("@OrderId", drr["id"].ToString());
                    cmd.Parameters.AddWithValue("@OrderDetlId", drr["DetailID"].ToString());
                    cmd.Parameters.AddWithValue("@sessionid", Data.sessionid);
                    cmd.Parameters.AddWithValue("@MaxId", txtchalanno.Text);
                    cmd.Parameters.AddWithValue("@MainId", lblMainId.Text);
                    cmd.Parameters.AddWithValue("@GenerateBy", "Mobile");
                    cmd.Parameters.AddWithValue("@EFlag", "S");
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
                #endregion

                #region StockEntry
                foreach (DataRow drr in dtt.Rows)
                {
                    query = "INSERT INTO [Tbl_Stock]([ItemId],[type],[Qty],[Date],[Firmid],[chalanno],[MainId])";
                    query += " VALUES ('" + drr["itemid"].ToString() + "','S','" + drr["Qty"].ToString() + "','" + DateTime.Now + "','" + Data.id + "','" + txtchalanno.Text + "','" + lblMainId.Text + "')";
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                #endregion

                #region LedgerEntry
                query = " insert into tblldg (Client_Id,CrDr,VocType,BillAmt,VoucherBy,Dat,firmid,sessionid,Billno,type,MainId)values(@Client_Id,@CrDr,@VocType,@BillAmt,@VoucherBy,@Dat,@firmid,@sessionid,@Billno,@type,@MainId)";
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Client_Id", dtt.Rows[0]["PartyId"].ToString());
                cmd.Parameters.AddWithValue("@CrDr", "CR");
                cmd.Parameters.AddWithValue("@VocType", "Amount Received");
                cmd.Parameters.AddWithValue("@BillAmt", dtt.Rows[0]["TotalAmount"].ToString());
                cmd.Parameters.AddWithValue("@VoucherBy", "Cash");
                cmd.Parameters.AddWithValue("@Dat", DateTime.Now);
                cmd.Parameters.AddWithValue("@firmid", Data.id);
                cmd.Parameters.AddWithValue("@sessionid", Data.sessionid);
                cmd.Parameters.AddWithValue("@Billno", txtchalanno.Text);
                cmd.Parameters.AddWithValue("@type", "S");
                cmd.Parameters.AddWithValue("@MainId", lblMainId.Text);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                #endregion

                #region
                cmd.CommandText = "update tbl_TempOrder set IsGenerateBill=1,IsSync=0 where id=" + dtt.Rows[0]["id"].ToString();
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                #endregion

                myTrans.Commit();
                Print(lblMainId.Text);
                Reset();
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
        private void Print(string MainId)
        {
            if (MessageBox.Show("Do You want Print Record Press 'Yes' otherwise Press 'No'", "Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string query1 = "select * from InvoicePrint_View where Delid=0 and EFlag='S' and chalid=" + MainId + " and firmid=" + Data.id + " and  sessionid=" + Data.sessionid + " order by chalnid";
                Data.query = query1;
                CustomMsg frm = new CustomMsg();
                frm.Show();
            }
        }
    }
}
