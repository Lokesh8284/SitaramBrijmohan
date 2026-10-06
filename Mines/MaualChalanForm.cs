
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
    public partial class MaualChalanForm : Form
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
        public MaualChalanForm()
        {
            InitializeComponent();
        }

        private void ChalanForm_Load(object sender, EventArgs e)
        {
            dtpFrom.Text = dtpTo.Text = DateTime.Now.ToString();
            dateTimePicker2.Format = DateTimePickerFormat.Time;
            dateTimePicker2.ShowUpDown = true;
            label13.Text = Data.Area;
            itemname();
            maxchalan();
            maxchalanGst();
            txtAddSGSTAmt.Text = "0";
            filllst();
            drpname.Focus();
            filllabour();
            fillabourname();
            drpUnit();
            // labourate();
            // FillDeliverTo();
            partyname();
            drpname.Focus();
            btndel.Enabled = false;
            dtpUnit.SelectedIndex = 0;
            drpReverse.SelectedIndex = 2;
            dtpVehicleNo.Text = "-- Select VehicleNo--";
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
            query = " select max(maxid) as Maxid from tbl_GstChallan where EFlag!='C' and  firmid=" + Data.id + " and sessionid=" + Data.sessionid + "";
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

        private void fillabourname()
        {
            query = " select * from tbllabour where firmid=" + Data.id + " order by labourname";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["lbrid"] = "0";
            newrow["labourname"] = "---Select Labour Name ----";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            drpLabour.DataSource = ds.Tables[0];
            drpLabour.DisplayMember = "labourname";
            drpLabour.ValueMember = "lbrid";
        }
        public void cleardata()
        {
            dateTimePicker1.Text = DateTime.Now.ToString();
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
        public void partyname()
        {
            query = " select id,Name,Address,PinCode,Phone,Mob,Mail,country,state,city,fax,email,website,remark,dateofjoin,officephone,compname,opening,CrDr,firmid,PartyType,PanNo,GstNo,AcNo,BankName,IfscCode,BranchName from tblclient where firmid=" + Data.id + " ";
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
        public void filllabour()
        {
            query = " select * from tbl_Transport where firmid=" + Data.id + " order by TransportName";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["lbrid"] = "0";
            newrow["TransportName"] = "---Select Transporter ----";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            drplbr.DataSource = ds.Tables[0];
            drplbr.DisplayMember = "TransportName";
            drplbr.ValueMember = "lbrid";
        }
        public void itemname()
        {
            query = " select * from tblitem where firmid=" + Data.id + " order by itemname";
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
            if (drpitem.SelectedIndex > 0)
            {
                try
                {
                    //string dd = drpitem.SelectedValue.ToString();
                    query = "  select * from tblitem ";
                    query += " where tblitem.itemid=" + drpitem.SelectedValue + "";
                    query += "  and tblitem.firmid=" + Data.id + "";
                    ds = data.getDataSet(query);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dtpUnit.Text = ds.Tables[0].Rows[0]["Unit"].ToString();
                        txtqty.Text = "1";
                        txtrate.Text = ds.Tables[0].Rows[0]["price"].ToString();
                        int amt = (Convert.ToInt32(txtrate.Text)) * (Convert.ToInt32(txtqty.Text));
                        txtamout.Text = amt.ToString();
                        string qqqq = "select * from tblclient where id='" + drpname.SelectedValue + "'";
                        DataSet ds2 = data.getDataSet(qqqq);
                        if (ds2.Tables[0].Rows.Count > 0)
                        {
                            if (ds2.Tables[0].Rows[0]["GSTFlag"].ToString() == "CGST")
                            {
                                txtCGST.Text = ds.Tables[0].Rows[0]["CGST"].ToString();
                                txtSGST.Text = ds.Tables[0].Rows[0]["SGST"].ToString();
                                txtIGST.Text = "0";
                                cal();
                            }
                            if (ds2.Tables[0].Rows[0]["GSTFlag"].ToString() == "SGST")
                            {
                                txtCGST.Text = ds.Tables[0].Rows[0]["CGST"].ToString();
                                txtSGST.Text = ds.Tables[0].Rows[0]["SGST"].ToString();
                                txtIGST.Text = "0";
                                cal();
                            }
                            if (ds2.Tables[0].Rows[0]["GSTFlag"].ToString() == "IGST")
                            {
                                txtCGST.Text = "0";
                                txtSGST.Text = "0";
                                txtIGST.Text = ds.Tables[0].Rows[0]["IGST"].ToString();
                                cal();
                            }
                        }

                    }
                    else
                    {
                        txtrate.Text = "0";
                    }
                }
                catch
                { }
            }
            else
            {
                // itemname();
            }
        }

        private void cal()
        {
            double amt = 0.00;
            double amt1 = 0.00;
            double amt2 = 0.00;
            double amt3 = 0.00;
            double amt4 = 0.00;
            amt4 = Convert.ToDouble(Convert.ToDouble(txtamout.Text)) - (Convert.ToDouble(txtDiscount.Text));
            txtTaxableValue.Text = amt4.ToString();
            amt = Convert.ToDouble((amt4 * Convert.ToDouble(txtCGST.Text)) / 100);
            txtCGSTAmount.Text = amt.ToString();
            amt1 = Convert.ToDouble((amt4 * Convert.ToDouble(txtSGST.Text)) / 100);
            txtSGSTAmount.Text = amt1.ToString();
            amt2 = Convert.ToDouble((amt4 * Convert.ToDouble(txtIGST.Text)) / 100);
            txtIGSTAmount.Text = amt2.ToString();
            amt3 = (amt4 + amt + amt1 + amt2);
            txtGstTotalAmount.Text = amt3.ToString();
        }
        private void drpname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpname.SelectedIndex > 0)
            {
                string aa = drpname.Text.ToString();
                query = " SELECT * from tblclient";
                query += " where  firmid=" + Data.id + "";
                query += " and id=" + drpname.SelectedValue + "";
                ds = data.getDataSet(query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtgstno.Text = ds.Tables[0].Rows[0]["GstNo"].ToString();
                    query = " select * from tbl_DeliveredTo where firmid=" + Data.id + " and PartyType='" + aa + "' order by compname";
                    ds = data.getDataSet(query);
                    DataRow newrow = ds.Tables[0].NewRow();
                    newrow["id"] = "0";
                    newrow["compname"] = "---Select Delivered ----";
                    ds.Tables[0].Rows.InsertAt(newrow, 0);
                    dtpDeliveredTo.DataSource = ds.Tables[0];
                    dtpDeliveredTo.DisplayMember = "compname";
                    dtpDeliveredTo.ValueMember = "id";
                    dtpDeliveredTo.Enabled = true;

                }
                else
                {
                    dtpDeliveredTo.Text = "";
                    dtpDeliveredTo.Enabled = false;
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
            drpLabour.SelectedIndex = 0;
            dtpFrom.Text = dtpTo.Text = DateTime.Now.ToString();
            grdtest1.Rows.Clear();
            drpReverse.SelectedIndex = 0;
            drpname.SelectedIndex = 0;
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
            maxchalan();
            maxchalanGst();
            filllst();
            btnsave.Text = "Save";
            txttotal.Text = "0";
            drpname.Focus();
            drpitem.SelectedIndex = 0;
            drplbr.SelectedIndex = 0;
            dtpVehicleNo.Text = "-- Select VehicleNo --";
            dateTimePicker1.Text = DateTime.Now.ToString();
            btndel.Enabled = false;
        }
        public void filllst()
        {
            query = "GetAllChallans_GST " + Data.id + "," + Data.sessionid + ",'"
                + dtpFrom.Value + "','" + dtpTo.Value + "','%'";
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
            //double rat = Convert.ToDouble(txtrate.Text);
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
            if (txtravanno.Text == "")
            {
                MessageBox.Show("Rawanna No Must be Enter");
                txtravanno.Focus();
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
                grdtest1.Rows[curr].Cells["amount"].Value = txtamout.Text;
                grdtest1.Rows[curr].Cells["ravanno"].Value = txtravanno.Text;
                grdtest1.Rows[curr].Cells["CGST"].Value = txtCGST.Text;
                grdtest1.Rows[curr].Cells["SGST"].Value = txtSGST.Text;
                grdtest1.Rows[curr].Cells["IGST"].Value = txtIGST.Text;
                grdtest1.Rows[curr].Cells["Unit"].Value = dtpUnit.Text;
                grdtest1.Rows[curr].Cells["CGSTAmt"].Value = txtCGSTAmount.Text;
                grdtest1.Rows[curr].Cells["SGSTAmt"].Value = txtSGSTAmount.Text;
                grdtest1.Rows[curr].Cells["IGSTAmt"].Value = txtIGSTAmount.Text;
                grdtest1.Rows[curr].Cells["Discount"].Value = txtDiscount.Text;
                grdtest1.Rows[curr].Cells["TaxableValue"].Value = txtTaxableValue.Text;
                grdtest1.Rows[curr].Cells["TotalAmt"].Value = txtGstTotalAmount.Text;
                grdtest1.Rows[curr].Cells["Date"].Value = data.getDateMMDDYYYY(dateTimePicker1.Text);
                grdtest1.Rows[curr].Cells["Edit1"].Value = "Edit";
                grdtest1.Rows[curr].Cells["del"].Value = "Delete";

            }
            else
            {
                int dd = currow + 1;
                grdtest1.Rows[currow].Cells["sno"].Value = dd;
                grdtest1.Rows[currow].Cells["itemid"].Value = drpitem.SelectedValue;
                grdtest1.Rows[currow].Cells["Item"].Value = drpitem.Text;
                grdtest1.Rows[currow].Cells["rate"].Value = txtrate.Text;
                grdtest1.Rows[currow].Cells["qty"].Value = txtqty.Text;
                grdtest1.Rows[currow].Cells["amount"].Value = txtamout.Text;
                grdtest1.Rows[currow].Cells["ravanno"].Value = txtravanno.Text;
                grdtest1.Rows[currow].Cells["CGST"].Value = txtCGST.Text;
                grdtest1.Rows[currow].Cells["SGST"].Value = txtSGST.Text;
                grdtest1.Rows[currow].Cells["IGST"].Value = txtIGST.Text;
                grdtest1.Rows[currow].Cells["Unit"].Value = dtpUnit.Text;
                grdtest1.Rows[currow].Cells["CGSTAmt"].Value = txtCGSTAmount.Text;
                grdtest1.Rows[currow].Cells["SGSTAmt"].Value = txtSGSTAmount.Text;
                grdtest1.Rows[currow].Cells["IGSTAmt"].Value = txtIGSTAmount.Text;
                grdtest1.Rows[currow].Cells["Discount"].Value = txtDiscount.Text;
                grdtest1.Rows[currow].Cells["TaxableValue"].Value = txtTaxableValue.Text;
                grdtest1.Rows[currow].Cells["TotalAmt"].Value = txtGstTotalAmount.Text;
                grdtest1.Rows[currow].Cells["Date"].Value = data.getDateMMDDYYYY(dateTimePicker1.Text);
                grdtest1.Rows[currow].Cells["Edit1"].Value = "Edit";
                grdtest1.Rows[currow].Cells["del"].Value = "Delete";
            }
            drpitem.Focus();
            getTotalAmt();
            clear1();
        }
        public void maxchalan()
        {
            query = " select max(chalanno) as sno from tbl_GstChallan where EFlag!='C' and   firmid=" + Data.id + " and sessionid=" + Data.sessionid + "";
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
                    txtravanno.Text = grdtest1.Rows[e.RowIndex].Cells["ravanno"].Value.ToString();
                    txtqty.Text = grdtest1.Rows[e.RowIndex].Cells["qty"].Value.ToString();
                    txtCGST.Text = grdtest1.Rows[e.RowIndex].Cells["CGST"].Value.ToString();
                    txtSGST.Text = grdtest1.Rows[e.RowIndex].Cells["SGST"].Value.ToString();
                    txtIGST.Text = grdtest1.Rows[e.RowIndex].Cells["IGST"].Value.ToString();
                    txtCGSTAmount.Text = grdtest1.Rows[e.RowIndex].Cells["CGSTAmt"].Value.ToString();
                    txtSGSTAmount.Text = grdtest1.Rows[e.RowIndex].Cells["SGSTAmt"].Value.ToString();
                    txtIGSTAmount.Text = grdtest1.Rows[e.RowIndex].Cells["IGSTAmt"].Value.ToString();
                    txtDiscount.Text = grdtest1.Rows[e.RowIndex].Cells["Discount"].Value.ToString();
                    txtTaxableValue.Text = grdtest1.Rows[e.RowIndex].Cells["TaxableValue"].Value.ToString();
                    txtamout.Text = grdtest1.Rows[e.RowIndex].Cells["amount"].Value.ToString();
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
            //this.Close();
        }
        private double getTotalAmt()
        {
            double totAmt = 0;
            double totCGST = 0;
            double totSGST = 0;
            double totIGST = 0;
            for (int i = 0; i < grdtest1.Rows.Count; i++)
            {
                totAmt += Convert.ToDouble(grdtest1.Rows[i].Cells["amount"].Value.ToString());
                totCGST += Convert.ToDouble(grdtest1.Rows[i].Cells["CGSTAmt"].Value.ToString());
                totSGST += Convert.ToDouble(grdtest1.Rows[i].Cells["SGSTAmt"].Value.ToString());
                totIGST += Convert.ToDouble(grdtest1.Rows[i].Cells["IGSTAmt"].Value.ToString());
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
        public void save()
        {

            #region validation

            if (btnsave.Text == "Save")
            {

                //Check Back Challan No and Date for Validation for Maximum Date of New Challan No.
                if (data.Exist("CheckChallanDate_Maximum " + Data.id + "," + Data.sessionid + ",'" + dateTimePicker1.Value.ToString("dd-MMM-yyyy") + "'"))
                {
                    MessageBox.Show("Challan Date Should be Maximum of last Challan Date and No.");
                    return;
                }
            }
            #endregion

            if (drplbr.SelectedIndex == 0)
            {
                MessageBox.Show("Transporter Must be Entered");
                drplbr.Focus();
                return;
            }
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
            if (dtpVehicleNo.SelectedIndex == 0)
            {
                MessageBox.Show("Vehicle No must be select");
                dtpVehicleNo.Focus();
                return;
            }
            if (txtDeliveryAddress.Text == "")
            {
                MessageBox.Show("Delivery Address must be Enter");
                txtDeliveryAddress.Focus();
                return;
            }
            if (grdtest1.Rows.Count == 0)
            {
                MessageBox.Show("Record's not found");
                return;
            }
            if (drpLabour.SelectedIndex == 0)
            {
                MessageBox.Show("Labour Name Must be select");
                drpLabour.Focus();
                return;
            }
            if (btnsave.Text == "Save")
            {
                if (data.Exist("select chalanno from tbl_GstChallan where chalanno=" + txtchalanno.Text + " and firmid=" + Data.id + " and sessionid=" + Data.sessionid + " "))
                {
                    MessageBox.Show(" Chalanno. already Exist");
                    txtchalanno.Focus();
                    return;
                }
                query = " insert into tbl_GstChallan(chalanno,totalamt,clientid,chalandate,firmid,Transid,VehicleNo,sessionid,AddCGSTAmt,AddIGSTAmt,AddSGSTAmt,DeliveredTo,DeliveryAddress,chalantime,mobileno,UID,ReverseCharge,TotGSTAmt,TotalTaxAmt,lbrid,MaxId,EFlag)values(@chalanno,@totalamt,@clientid,@chalandate,@firmid,@Transid,@VehicleNo,@sessionid,@AddCGSTAmt,@AddIGSTAmt,@AddSGSTAmt,@DeliveredTo,@DeliveryAddress,@chalantime,@mobileno,@UID,@ReverseCharge,@TotGSTAmt,@TotalTaxAmt,@lbrid,@MaxId,@EFlag)";
                cmd.Parameters.Clear();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@chalanno", txtchalanno.Text);
                cmd.Parameters.AddWithValue("@totalamt", txttotal.Text);
                cmd.Parameters.AddWithValue("@clientid", drpname.SelectedValue);
                if (dtpDeliveredTo.Text == "")
                {
                    cmd.Parameters.AddWithValue("@DeliveredTo", 0);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DeliveredTo", dtpDeliveredTo.SelectedValue);
                }
                cmd.Parameters.AddWithValue("@DeliveryAddress", txtDeliveryAddress.Text);
                cmd.Parameters.AddWithValue("@chalandate", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@chalantime", dateTimePicker2.Text);
                cmd.Parameters.AddWithValue("@firmid", Data.id);
                cmd.Parameters.AddWithValue("@Transid", drplbr.SelectedValue);
                cmd.Parameters.AddWithValue("@VehicleNo", dtpVehicleNo.Text);
                cmd.Parameters.AddWithValue("@AddCGSTAmt", txtAddCGSTAmt.Text);
                cmd.Parameters.AddWithValue("@AddIGSTAmt", txtAddIGSTAmt.Text);
                cmd.Parameters.AddWithValue("@mobileno", txtMoblieNo.Text);
                cmd.Parameters.AddWithValue("@AddSGSTAmt", txtAddSGSTAmt.Text);
                cmd.Parameters.AddWithValue("@sessionid", Data.sessionid);
                cmd.Parameters.AddWithValue("@ReverseCharge", drpReverse.Text);
                cmd.Parameters.AddWithValue("@TotGSTAmt", txtTotGSTAmt.Text);
                cmd.Parameters.AddWithValue("@TotalTaxAmt", txtTotalTaxAmt.Text);
                cmd.Parameters.AddWithValue("@lbrid", drpLabour.SelectedValue);
                cmd.Parameters.AddWithValue("@MaxId", txtmaxchallanid.Text);
                cmd.Parameters.AddWithValue("@EFlag", "M");

                if (Data.UID == "0")
                {
                    cmd.Parameters.AddWithValue("@UID", 0);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@UID", Data.UID);
                }
                if (data.executeCommand(cmd) == 0)
                {
                    cmd.Parameters.Clear();

                    query = " insert into tbl_GstChallanDetails(chalanno,clientid,itemid,price,chalandate,qty,amount,firmid,ravanano,sessionid,Unit,CGST,SGST,IGST,CGSTAmount,SGSTAmount,IGSTAmount,Discount,GrossTotal,TaxableValue,EFlag)values(@chalanno,@clientid,@itemid,@price,@chalandate,@qty,@amount,@firmid,@ravanano,@sessionid,@Unit,@CGST,@SGST,@IGST,@CGSTAmount,@SGSTAmount,@IGSTAmount,@Discount,@GrossTotal,@TaxableValue,@EFlag)";
                    cmd.CommandText = query;
                    for (int i = 0; i < grdtest1.Rows.Count; i++)
                    {
                        cmd.Parameters.AddWithValue("@chalanno", txtchalanno.Text);
                        cmd.Parameters.AddWithValue("@clientid", drpname.SelectedValue);
                        cmd.Parameters.AddWithValue("@itemid", grdtest1.Rows[i].Cells["itemid"].Value.ToString());
                        cmd.Parameters.AddWithValue("@price", grdtest1.Rows[i].Cells["rate"].Value.ToString());
                        cmd.Parameters.AddWithValue("@chalandate", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@qty", grdtest1.Rows[i].Cells["qty"].Value.ToString());
                        cmd.Parameters.AddWithValue("@amount", grdtest1.Rows[i].Cells["amount"].Value.ToString());
                        cmd.Parameters.AddWithValue("@firmid", Data.id);
                        cmd.Parameters.AddWithValue("@ravanano", grdtest1.Rows[i].Cells["ravanno"].Value.ToString());
                        cmd.Parameters.AddWithValue("@Unit", grdtest1.Rows[i].Cells["Unit"].Value.ToString());
                        cmd.Parameters.AddWithValue("@CGST", grdtest1.Rows[i].Cells["CGST"].Value.ToString());
                        cmd.Parameters.AddWithValue("@SGST", grdtest1.Rows[i].Cells["SGST"].Value.ToString());
                        cmd.Parameters.AddWithValue("@IGST", grdtest1.Rows[i].Cells["IGST"].Value.ToString());
                        cmd.Parameters.AddWithValue("@CGSTAmount", grdtest1.Rows[i].Cells["CGSTAmt"].Value.ToString());
                        cmd.Parameters.AddWithValue("@SGSTAmount", grdtest1.Rows[i].Cells["SGSTAmt"].Value.ToString());
                        cmd.Parameters.AddWithValue("@IGSTAmount", grdtest1.Rows[i].Cells["IGSTAmt"].Value.ToString());
                        cmd.Parameters.AddWithValue("@Discount", grdtest1.Rows[i].Cells["Discount"].Value.ToString());
                        cmd.Parameters.AddWithValue("@TaxableValue", grdtest1.Rows[i].Cells["TaxableValue"].Value.ToString());
                        cmd.Parameters.AddWithValue("@GrossTotal", grdtest1.Rows[i].Cells["TotalAmt"].Value.ToString());
                        cmd.Parameters.AddWithValue("@sessionid", Data.sessionid);
                        cmd.Parameters.AddWithValue("@EFlag", "M");
                        data.executeCommand(cmd);
                        cmd.Parameters.Clear();
                    }
                }
            }
            else
            {
                //query = "delete from tbl_GstChallan where chalanno=" + txtchalanno.Text + " and firmid=" + Data.id + " and sessionid=" + Data.sessionid + "";
                //data.executeCommand(query);
                //query = "delete from tbl_GstChallanDetails where chalanno=" + txtchalanno.Text + " and firmid=" + Data.id + " and sessionid=" + Data.sessionid + "";

                //data.executeCommand(query);
                //if (data.Exist("select chalanno from tbl_GstChallan where chalanno=" + txtchalanno.Text + " and firmid=" + Data.id + "and sessionid=" + Data.sessionid + ""))
                //{
                //    MessageBox.Show("Chalanno. already Exist");
                //    txtchalanno.Focus();
                //    return;
                //}
                //query = " insert into tbl_GstChallan(chalanno,totalamt,clientid,chalandate,firmid,Transid,VehicleNo,sessionid,AddCGSTAmt,AddIGSTAmt,AddSGSTAmt,DeliveredTo,DeliveryAddress,chalantime,mobileno,UID,ReverseCharge,TotGSTAmt,TotalTaxAmt,lbrid,MaxId)values(@chalanno,@totalamt,@clientid,@chalandate,@firmid,@Transid,@VehicleNo,@sessionid,@AddCGSTAmt,@AddIGSTAmt,@AddSGSTAmt,@DeliveredTo,@DeliveryAddress,@chalantime,@mobileno,@UID,@ReverseCharge,@TotGSTAmt,@TotalTaxAmt,@lbrid,@MaxId)";
                query = " update tbl_GstChallan SET chalanno=@chalanno,totalamt=@totalamt,clientid=@clientid,chalandate=@chalandate,firmid=@firmid,Transid=@Transid,VehicleNo=@VehicleNo,sessionid=@sessionid,AddCGSTAmt=@AddCGSTAmt,AddIGSTAmt=@AddIGSTAmt,AddSGSTAmt=@AddSGSTAmt,DeliveredTo=@DeliveredTo,DeliveryAddress=@DeliveryAddress,chalantime=@chalantime,mobileno=@mobileno,UID=@UID,ReverseCharge=@ReverseCharge,TotGSTAmt=@TotGSTAmt,TotalTaxAmt=@TotalTaxAmt,MaxId=@MaxId,lbrid=@lbrid,EFlag=@EFlag where MaxId=" + txtmaxchallanid.Text + " and firmid=" + Data.id + " and sessionid=" + Data.sessionid + "";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@chalanno", txtchalanno.Text);
                cmd.Parameters.AddWithValue("@totalamt", txttotal.Text);
                cmd.Parameters.AddWithValue("@clientid", drpname.SelectedValue);
                if (dtpDeliveredTo.Text == "")
                {
                    cmd.Parameters.AddWithValue("@DeliveredTo", 0);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@DeliveredTo", dtpDeliveredTo.SelectedValue);
                }
                //cmd.Parameters.AddWithValue("@DeliveredTo", dtpDeliveredTo.SelectedValue);
                cmd.Parameters.AddWithValue("@DeliveryAddress", txtDeliveryAddress.Text);
                cmd.Parameters.AddWithValue("@chalandate", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@chalantime", dateTimePicker2.Text);
                cmd.Parameters.AddWithValue("@firmid", Data.id);
                cmd.Parameters.AddWithValue("@Transid", drplbr.SelectedValue);
                cmd.Parameters.AddWithValue("@VehicleNo", dtpVehicleNo.Text);
                cmd.Parameters.AddWithValue("@AddCGSTAmt", txtAddCGSTAmt.Text);
                cmd.Parameters.AddWithValue("@AddIGSTAmt", txtAddIGSTAmt.Text);
                cmd.Parameters.AddWithValue("@mobileno", txtMoblieNo.Text);
                cmd.Parameters.AddWithValue("@AddSGSTAmt", txtAddSGSTAmt.Text);
                cmd.Parameters.AddWithValue("@sessionid", Data.sessionid);
                cmd.Parameters.AddWithValue("@ReverseCharge", drpReverse.Text);
                cmd.Parameters.AddWithValue("@TotGSTAmt", txtTotGSTAmt.Text);
                cmd.Parameters.AddWithValue("@TotalTaxAmt", txtTotalTaxAmt.Text);
                cmd.Parameters.AddWithValue("@lbrid", drpLabour.SelectedValue);
                cmd.Parameters.AddWithValue("@MaxId", txtmaxchallanid.Text);
                cmd.Parameters.AddWithValue("@EFlag", "M");

                if (Data.UID == "")
                {
                    cmd.Parameters.AddWithValue("@UID", 0);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@UID", Data.UID);
                }
                if (data.executeCommand(cmd) == 0)
                {
                    cmd.Parameters.Clear();

                    //query = " insert into tbl_GstChallanDetails(chalanno,clientid,itemid,price,chalandate,qty,amount,firmid,ravanano,sessionid,Unit,CGST,SGST,IGST,CGSTAmount,SGSTAmount,IGSTAmount,Discount,GrossTotal,TaxableValue)values(@chalanno,@clientid,@itemid,@price,@chalandate,@qty,@amount,@firmid,@ravanano,@sessionid,@Unit,CGST,SGST,@IGST,@CGSTAmount,@SGSTAmount,@IGSTAmount,@Discount,@GrossTotal,@TaxableValue)";

                    for (int i = 0; i < grdtest1.Rows.Count; i++)
                    {
                        query = " update tbl_GstChallanDetails SET chalanno=@chalanno,clientid=@clientid,itemid=@itemid,price=@price,chalandate=@chalandate,qty=@qty,amount=@amount,firmid=@firmid,ravanano=@ravanano,sessionid=@sessionid,Unit=@Unit,CGST=@CGST,SGST=@SGST,IGST=@IGST,CGSTAmount=@CGSTAmount,SGSTAmount=@SGSTAmount,IGSTAmount=@IGSTAmount,Discount=@Discount,GrossTotal=@GrossTotal,TaxableValue=@TaxableValue,MaxId=@MaxId,EFlag=@EFlag where MaxId=" + txtmaxchallanid.Text + " and  itemid=" + grdtest1.Rows[i].Cells["itemid"].Value + " and firmid=" + Data.id + " and sessionid=" + Data.sessionid + "";
                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@chalanno", txtchalanno.Text);
                        cmd.Parameters.AddWithValue("@clientid", drpname.SelectedValue);
                        cmd.Parameters.AddWithValue("@itemid", grdtest1.Rows[i].Cells["itemid"].Value.ToString());
                        cmd.Parameters.AddWithValue("@price", grdtest1.Rows[i].Cells["rate"].Value.ToString());
                        cmd.Parameters.AddWithValue("@chalandate", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@qty", grdtest1.Rows[i].Cells["qty"].Value.ToString());
                        cmd.Parameters.AddWithValue("@amount", grdtest1.Rows[i].Cells["amount"].Value.ToString());
                        cmd.Parameters.AddWithValue("@firmid", Data.id);
                        cmd.Parameters.AddWithValue("@ravanano", grdtest1.Rows[i].Cells["ravanno"].Value.ToString());
                        cmd.Parameters.AddWithValue("@Unit", grdtest1.Rows[i].Cells["Unit"].Value.ToString());
                        cmd.Parameters.AddWithValue("@CGST", grdtest1.Rows[i].Cells["CGST"].Value.ToString());
                        cmd.Parameters.AddWithValue("@SGST", grdtest1.Rows[i].Cells["SGST"].Value.ToString());
                        cmd.Parameters.AddWithValue("@IGST", grdtest1.Rows[i].Cells["IGST"].Value.ToString());
                        cmd.Parameters.AddWithValue("@CGSTAmount", grdtest1.Rows[i].Cells["CGSTAmt"].Value.ToString());
                        cmd.Parameters.AddWithValue("@SGSTAmount", grdtest1.Rows[i].Cells["SGSTAmt"].Value.ToString());
                        cmd.Parameters.AddWithValue("@IGSTAmount", grdtest1.Rows[i].Cells["IGSTAmt"].Value.ToString());
                        cmd.Parameters.AddWithValue("@Discount", grdtest1.Rows[i].Cells["Discount"].Value.ToString());
                        cmd.Parameters.AddWithValue("@TaxableValue", grdtest1.Rows[i].Cells["TaxableValue"].Value.ToString());
                        cmd.Parameters.AddWithValue("@GrossTotal", grdtest1.Rows[i].Cells["TotalAmt"].Value.ToString());
                        cmd.Parameters.AddWithValue("@sessionid", Data.sessionid);
                        cmd.Parameters.AddWithValue("@MaxId", txtmaxchallanid.Text);
                        cmd.Parameters.AddWithValue("@EFlag", "M");
                        data.executeCommand(cmd);
                        cmd.Parameters.Clear();
                    }
                }
            }
            MessageBox.Show(btnsave.Text + " Record Successfully !!!");
            if (MessageBox.Show("Do You want Print Record Press 'Yes' otherwise Press 'No'", "Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string query2 = "SELECT tblfirm.GstNo as tin,tblfirm.Address,upper(tblfirm.compname) as compname,tblclient.compname as Name,tbl_GstChallan.mobileno as Mob,tbl_GstChallan.ReverseCharge,tbl_GstChallan.DeliveryAddress, tblitem.itemname, tbl_GstChallanDetails.ravanano,tbl_GstChallanDetails.CGST,tbl_GstChallanDetails.SGST,tbl_GstChallanDetails.IGST, tbl_GstChallanDetails.price, tbl_GstChallanDetails.qty, tbl_GstChallanDetails.amount, Convert(char(11),tbl_GstChallanDetails.chalandate,103) as chalandate, tbl_GstChallanDetails.chalanno, tbl_GstChallanDetails.itemid,tbl_GstChallan.chalantime,tbl_GstChallan.totalamt,tblfirm.mail as CursorAddress  ";
                query2 += " ,tbl_GstChallan.AddIGSTAmt as NetAmount,tbl_GstChallan.AddCGSTAmt as Discount,tbl_GstChallan.AddSGSTAmt as Fright,tbl_GstChallan.VehicleNo,tbl_GstChallanDetails.Unit ,tbl_Transport.TransportName ,tbl_DeliveredTo.compname as labourname  FROM (((tblclient INNER JOIN tbl_GstChallanDetails ON tblclient.id = tbl_GstChallanDetails.clientid) INNER JOIN tblitem ON tbl_GstChallanDetails.itemid = tblitem.itemid) INNER JOIN tbl_GstChallan ON (tbl_GstChallanDetails.chalanno = tbl_GstChallan.chalanno) AND (tblclient.firmid = tbl_GstChallan.firmid)) ";
                query2 += " inner join tbl_Transport on tbl_Transport.lbrid=tbl_GstChallan.Transid inner join tblfirm on tblfirm.firmid=tbl_GstChallan.firmid   left join tbl_DeliveredTo on tbl_DeliveredTo.id=tbl_GstChallan.DeliveredTo where tbl_GstChallanDetails.chalanno=" + txtchalanno.Text + " and tbl_GstChallanDetails.firmid=" + Data.id + " and tbl_GstChallan.sessionid=" + Data.sessionid + " and tbl_GstChallanDetails.sessionid=" + Data.sessionid + " and tblitem.itemname!='Freight'";
                Data.query = query2;
                ChallanReport rep11 = new ChallanReport();
                rep11.Show();

                string query1 = "SELECT tbl_GstChallanDetails.EFlag,tbl_GstChallanDetails.TaxableValue, tbl_GstChallanDetails.CGSTAmount,tbl_GstChallanDetails.SGSTAmount,tbl_GstChallanDetails.IGSTAmount,tblfirm.AcNo,tblfirm.ifscCode,tblfirm.tin,tblfirm.BankName,tblfirm.BranchName,tblfirm.state,tblfirm.country,tblfirm.Phone,tblfirm.Mob as m1,tblfirm.GstNo as firmgstno,tblfirm.Address,upper(tblfirm.compname) as compname,tblclient.compname as Name, tbl_GstChallan.mobileno as Mob,tbl_GstChallan.DeliveryAddress, tblitem.itemname, tbl_GstChallanDetails.ravanano,tbl_GstChallanDetails.CGST,tbl_GstChallanDetails.SGST,tbl_GstChallanDetails.IGST, tbl_GstChallanDetails.price, ";
                query1 += "  tbl_GstChallanDetails.qty, tbl_GstChallanDetails.amount, Convert(char(11),tbl_GstChallanDetails.chalandate,103) as chalandate,tbl_GstChallanDetails.chalanno, tbl_GstChallanDetails.itemid,tbl_GstChallan.chalantime,tbl_GstChallan.totalamt,tblfirm.mail as CursorAddress    ,tbl_GstChallan.AddIGSTAmt,tbl_GstChallan.AddCGSTAmt,tbl_GstChallan.AddSGSTAmt,tbl_GstChallan.TotGSTAmt,tbl_GstChallan.TotalTaxAmt,tbl_GstChallan.ReverseCharge,tbl_GstChallan.VehicleNo,tbl_GstChallanDetails.Unit  ,tbl_Transport.TransportName,tbl_DeliveredTo.GstNo as DGstNo,tbl_DeliveredTo.compname as labourname  ,tblclient.GSTRegistration,tblclient.GSTFlag,tblclient.GstNo ";
                query1 += " ,tblitem.itemcode,tbl_GstChallanDetails.Discount,tbl_GstChallanDetails.GrossTotal FROM (((tblclient INNER JOIN tbl_GstChallanDetails ON tblclient.id = tbl_GstChallanDetails.clientid)  INNER JOIN tblitem ON tbl_GstChallanDetails.itemid = tblitem.itemid) INNER JOIN tbl_GstChallan ON   (tbl_GstChallanDetails.chalanno = tbl_GstChallan.chalanno) AND (tblclient.firmid = tbl_GstChallan.firmid)) inner join tbl_Transport on tbl_Transport.lbrid=tbl_GstChallan.Transid inner join tblfirm on  tblfirm.firmid=tbl_GstChallan.firmid   left join tbl_DeliveredTo on tbl_DeliveredTo.id=tbl_GstChallan.DeliveredTo ";
                query1 += " where tbl_GstChallanDetails.chalanno=" + txtchalanno.Text + " and tbl_GstChallanDetails.firmid=" + Data.id + " and tbl_GstChallan.sessionid=" + Data.sessionid + " and tbl_GstChallanDetails.sessionid=" + Data.sessionid + "";
                Data.query = query1;
                TaxInvoiceRepor rep = new TaxInvoiceRepor();
                rep.Show();

            }
            clear();
        }
        private void lst_Click(object sender, EventArgs e)
        {
            fillclk();
        }
        public void fillclk()
        {
            if (lst.SelectedIndex >= 0)
            {
                string query1;
                txttotal.Text = "0";
                DataSet ds1 = new DataSet();
                query1 = "SELECT tblclient.compname as name,tbllabour.labourname as LName,tbl_GstChallanDetails.TaxableValue,tbl_GstChallan.mobileno,tbl_GstChallan.ReverseCharge,tbl_GstChallanDetails.CGSTAmount,  tbl_GstChallanDetails.SGSTAmount,  tbl_GstChallanDetails.IGSTAmount,  tbl_GstChallanDetails.Discount,  tbl_GstChallanDetails.GrossTotal,tbl_GstChallanDetails.CGST,tbl_GstChallanDetails.SGST,tbl_GstChallanDetails.IGST, tbl_GstChallan.DeliveryAddress, tblitem.itemname, tbl_GstChallanDetails.ravanano, tbl_GstChallanDetails.price, tbl_GstChallanDetails.qty, tbl_GstChallanDetails.amount, tbl_GstChallanDetails.chalandate, tbl_GstChallanDetails.chalanno, tbl_GstChallanDetails.itemid,tbl_GstChallan.chalantime,tbl_GstChallan.totalamt ";
                query1 += " ,tbl_GstChallan.TotGSTAmt,tbl_GstChallan.TotalTaxAmt,tbl_GstChallan.AddIGSTAmt,tbl_GstChallan.AddCGSTAmt ,tbl_GstChallan.AddSGSTAmt,tbl_GstChallan.VehicleNo,tbl_GstChallanDetails.Unit,tbl_GstChallanDetails.chalandate ,tbl_Transport.TransportName,tbl_DeliveredTo.compname as labourname  FROM (((tblclient INNER JOIN tbl_GstChallanDetails ON tblclient.id = tbl_GstChallanDetails.clientid) INNER JOIN tblitem ON tbl_GstChallanDetails.itemid = tblitem.itemid) INNER JOIN tbl_GstChallan ON (tbl_GstChallanDetails.chalanno = tbl_GstChallan.chalanno) AND (tblclient.firmid = tbl_GstChallan.firmid)) ";
                query1 += " inner join tbl_Transport on tbl_Transport.lbrid=tbl_GstChallan.Transid left join tbl_DeliveredTo on tbl_DeliveredTo.id=tbl_GstChallan.DeliveredTo inner join tbllabour on tbl_GstChallan.lbrid=tbllabour.lbrid where tbl_GstChallanDetails.chalanno=" + lst.SelectedValue + " and tbl_GstChallanDetails.firmid=" + Data.id + " and tbl_GstChallan.sessionid=" + Data.sessionid + " and tbl_GstChallanDetails.sessionid=" + Data.sessionid + "";
                ds1 = data.getDataSet(query1);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    grdtest1.Rows.Clear();
                    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    {
                        dtpDeliveredTo.Text = ds1.Tables[0].Rows[i]["labourname"].ToString();
                        drplbr.Text = ds1.Tables[0].Rows[i]["TransportName"].ToString();
                        txtDeliveryAddress.Text = ds1.Tables[0].Rows[i]["DeliveryAddress"].ToString();
                        txtchalanno.Text = ds1.Tables[0].Rows[i]["chalanno"].ToString();
                        drpname.Text = ds1.Tables[0].Rows[i]["name"].ToString();
                        drpReverse.Text = ds1.Tables[0].Rows[i]["ReverseCharge"].ToString();
                        txtMoblieNo.Text = ds1.Tables[0].Rows[i]["mobileno"].ToString();
                        dateTimePicker1.Text = ds1.Tables[0].Rows[0]["chalandate"].ToString();
                        dateTimePicker2.Text = ds1.Tables[0].Rows[0]["chalantime"].ToString();
                        txttotal.Text = ds1.Tables[0].Rows[0]["totalamt"].ToString();
                        txtAddIGSTAmt.Text = ds1.Tables[0].Rows[0]["AddIGSTAmt"].ToString();
                        txtAddCGSTAmt.Text = ds1.Tables[0].Rows[0]["AddCGSTAmt"].ToString();
                        txtAddSGSTAmt.Text = ds1.Tables[0].Rows[0]["AddSGSTAmt"].ToString();
                        txtTotGSTAmt.Text = ds1.Tables[0].Rows[0]["TotGSTAmt"].ToString();
                        txtTotalTaxAmt.Text = ds1.Tables[0].Rows[0]["TotalTaxAmt"].ToString();
                        drpLabour.Text = ds1.Tables[0].Rows[0]["LName"].ToString();
                        dtpVehicleNo.Text = ds1.Tables[0].Rows[0]["VehicleNo"].ToString();
                        grdtest1.Rows.Add();
                        grdtest1.Rows[i].Cells["sno"].Value = grdtest1.Rows.Count;
                        grdtest1.Rows[i].Cells["itemid"].Value = ds1.Tables[0].Rows[i]["itemid"].ToString();
                        grdtest1.Rows[i].Cells["Item"].Value = ds1.Tables[0].Rows[i]["itemname"].ToString();
                        grdtest1.Rows[i].Cells["rate"].Value = ds1.Tables[0].Rows[i]["price"].ToString();
                        grdtest1.Rows[i].Cells["ravanno"].Value = ds1.Tables[0].Rows[i]["ravanano"].ToString();
                        grdtest1.Rows[i].Cells["qty"].Value = ds1.Tables[0].Rows[i]["qty"].ToString();
                        grdtest1.Rows[i].Cells["amount"].Value = ds1.Tables[0].Rows[i]["amount"].ToString();
                        grdtest1.Rows[i].Cells["Date"].Value = ds1.Tables[0].Rows[i]["chalandate"].ToString();
                        grdtest1.Rows[i].Cells["Unit"].Value = ds1.Tables[0].Rows[i]["Unit"].ToString();
                        grdtest1.Rows[i].Cells["CGST"].Value = ds1.Tables[0].Rows[i]["CGST"].ToString();
                        grdtest1.Rows[i].Cells["SGST"].Value = ds1.Tables[0].Rows[i]["SGST"].ToString();
                        grdtest1.Rows[i].Cells["IGST"].Value = ds1.Tables[0].Rows[i]["IGST"].ToString();
                        grdtest1.Rows[i].Cells["Discount"].Value = ds1.Tables[0].Rows[i]["Discount"].ToString();
                        grdtest1.Rows[i].Cells["CGSTAmt"].Value = ds1.Tables[0].Rows[i]["CGSTAmount"].ToString();
                        grdtest1.Rows[i].Cells["SGSTAmt"].Value = ds1.Tables[0].Rows[i]["SGSTAmount"].ToString();
                        grdtest1.Rows[i].Cells["IGSTAmt"].Value = ds1.Tables[0].Rows[i]["IGSTAmount"].ToString();
                        grdtest1.Rows[i].Cells["TotalAmt"].Value = ds1.Tables[0].Rows[i]["GrossTotal"].ToString();
                        grdtest1.Rows[i].Cells["TaxableValue"].Value = ds1.Tables[0].Rows[i]["TaxableValue"].ToString();
                        grdtest1.Rows[i].Cells["Edit1"].Value = "Edit";
                        grdtest1.Rows[i].Cells["del"].Value = "Delete";
                    }
                    btnsave.Text = "Update";
                    btndel.Enabled = true;
                }
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
            drpitem.SelectedIndex = 0;
            txtCGST.Text = "0";
            txtCGSTAmount.Text = "0";
            txtSGST.Text = "0";
            txtSGSTAmount.Text = "0";
            txtIGST.Text = "0";
            txtIGSTAmount.Text = "0";
            txtDiscount.Text = "0";
            txtGstTotalAmount.Text = "0";
            txtravanno.Text = "";
            btnadd.Text = "Add";
            drpitem.Focus();
            dtpUnit.SelectedIndex = 0;
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
                cal();
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
                query = " delete from tbl_GstChallanDetails where firmid=" + Data.id + " and chalanno =" + lst.SelectedValue + " and sessionid=" + Data.sessionid + " ";
                data.executeCommand(query);
                query = " delete from tbl_GstChallan where firmid=" + Data.id + " and chalanno=" + lst.SelectedValue + " and sessionid=" + Data.sessionid + " ";
                data.executeCommand(query);
                clear();
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
        private void lst_SelectedIndexChanged(object sender, EventArgs e)
        {
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
        DataSet ds1 = new DataSet();
        private void btnReprint_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Do You want RePrint Record Press 'Yes' otherwise Press 'No'", "Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    string query1 = "SELECT tbl_GstChallanDetails.TaxableValue, tbl_GstChallanDetails.CGSTAmount,tbl_GstChallanDetails.SGSTAmount,tbl_GstChallanDetails.IGSTAmount,tblfirm.AcNo,tblfirm.ifscCode,tblfirm.tin,tblfirm.BankName,tblfirm.BranchName,tblfirm.state,tblfirm.country,tblfirm.Phone,tblfirm.Mob as m1,tblfirm.GstNo as firmgstno,tblfirm.Address,upper(tblfirm.compname) as compname,tblclient.compname as Name, tbl_GstChallan.mobileno as Mob,tbl_GstChallan.DeliveryAddress, tblitem.itemname, tbl_GstChallanDetails.ravanano,tbl_GstChallanDetails.CGST,tbl_GstChallanDetails.SGST,tbl_GstChallanDetails.IGST, tbl_GstChallanDetails.price,tbllabour.labourname as Lname, ";
            //    query1 += "  tbl_GstChallanDetails.qty, tbl_GstChallanDetails.amount, Convert(char(11),tbl_GstChallanDetails.chalandate,103) as chalandate,tbl_GstChallanDetails.chalanno, tbl_GstChallanDetails.itemid,tbl_GstChallan.chalantime,tbl_GstChallan.totalamt,tblfirm.mail as CursorAddress    ,tbl_GstChallan.AddIGSTAmt,tbl_GstChallan.AddCGSTAmt,tbl_GstChallan.AddSGSTAmt,tbl_GstChallan.TotGSTAmt,tbl_GstChallan.TotalTaxAmt,tbl_GstChallan.ReverseCharge,tbl_GstChallan.VehicleNo,tbl_GstChallanDetails.Unit  ,tbl_Transport.TransportName ,tbl_DeliveredTo.GstNo as DGstNo,tbl_DeliveredTo.compname as labourname  ,tblclient.GSTRegistration,tblclient.GSTFlag,tblclient.GstNo ";
            //    query1 += " ,tblitem.itemcode,tbl_DeliveredTo.StateCode as dStateCode,tblclient.StateCode as cStateCode,tbl_GstChallanDetails.Discount,tbl_GstChallanDetails.GrossTotal FROM (((tblclient INNER JOIN tbl_GstChallanDetails ON tblclient.id = tbl_GstChallanDetails.clientid)  INNER JOIN tblitem ON tbl_GstChallanDetails.itemid = tblitem.itemid) INNER JOIN tbl_GstChallan ON   (tbl_GstChallanDetails.chalanno = tbl_GstChallan.chalanno) AND (tblclient.firmid = tbl_GstChallan.firmid)) inner join tbl_Transport on tbl_Transport.lbrid=tbl_GstChallan.Transid inner join tblfirm on  tblfirm.firmid=tbl_GstChallan.firmid   left join tbl_DeliveredTo on tbl_DeliveredTo.id=tbl_GstChallan.DeliveredTo   inner join tbllabour on tbl_GstChallan.lbrid=tbllabour.lbrid";
            //    query1 += " where tbl_GstChallanDetails.chalanno=" + lst.SelectedValue + " and tbl_GstChallanDetails.firmid=" + Data.id + " and tbl_GstChallan.sessionid=" + Data.sessionid + " and tbl_GstChallanDetails.sessionid=" + Data.sessionid + "";
            //    Data.query = query1;
            //    TaxInvoiceRepor rep = new TaxInvoiceRepor();
            //    rep.Show();

            //    string query2 = "SELECT tblfirm.GstNo as tin,tblfirm.Address,upper(tblfirm.compname) as compname,tblclient.compname as Name,tbl_GstChallan.mobileno as Mob,tbl_GstChallan.ReverseCharge,tbl_GstChallan.DeliveryAddress, tblitem.itemname, tbl_GstChallanDetails.ravanano,tbl_GstChallanDetails.CGST,tbl_GstChallanDetails.SGST,tbl_GstChallanDetails.IGST, tbl_GstChallanDetails.price, tbl_GstChallanDetails.qty, tbl_GstChallanDetails.amount, Convert(char(11),tbl_GstChallanDetails.chalandate,103) as chalandate, tbl_GstChallanDetails.chalanno, tbl_GstChallanDetails.itemid,tbl_GstChallan.chalantime,tbl_GstChallan.totalamt,tblfirm.mail as CursorAddress  ";
            //    query2 += " ,tbl_GstChallan.AddIGSTAmt as NetAmount,tbl_GstChallan.AddCGSTAmt as Discount,tbl_GstChallan.AddSGSTAmt as Fright,tbl_GstChallan.VehicleNo,tbl_GstChallanDetails.Unit ,tbl_Transport.TransportName ,tbl_DeliveredTo.compname as labourname  FROM (((tblclient INNER JOIN tbl_GstChallanDetails ON tblclient.id = tbl_GstChallanDetails.clientid) INNER JOIN tblitem ON tbl_GstChallanDetails.itemid = tblitem.itemid) INNER JOIN tbl_GstChallan ON (tbl_GstChallanDetails.chalanno = tbl_GstChallan.chalanno) AND (tblclient.firmid = tbl_GstChallan.firmid)) ";
            //    query2 += " inner join tbl_Transport on tbl_Transport.lbrid=tbl_GstChallan.Transid inner join tblfirm on tblfirm.firmid=tbl_GstChallan.firmid   left join tbl_DeliveredTo on tbl_DeliveredTo.id=tbl_GstChallan.DeliveredTo where tbl_GstChallanDetails.chalanno=" + lst.SelectedValue + " and tbl_GstChallanDetails.firmid=" + Data.id + " and tbl_GstChallan.sessionid=" + Data.sessionid + " and tbl_GstChallanDetails.sessionid=" + Data.sessionid + " and tblitem.itemname!='Freight'";
            //    Data.query = query2;
            //    ChallanReport rep11 = new ChallanReport();
            //    rep11.Show();
            //}
            if (MessageBox.Show("Do You want RePrint Record Press 'Yes' otherwise Press 'No'", "Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string query2 = "SELECT  tblsession.session,tblfirm.ShortName,tblfirm.Mail,tbl_GstChallanDetails.MaxId,tblfirm.GstNo as tin,tblfirm.Address,upper(tblfirm.compname) as compname,tblclient.compname as Name,tbl_GstChallan.mobileno as Mob,tbl_GstChallan.ReverseCharge,tbl_GstChallan.DeliveryAddress, tblitem.itemname, tbl_GstChallanDetails.ravanano,tbl_GstChallanDetails.CGST,tbl_GstChallanDetails.SGST,tbl_GstChallanDetails.IGST, tbl_GstChallanDetails.price, tbl_GstChallanDetails.qty, tbl_GstChallanDetails.amount, Convert(char(11),tbl_GstChallanDetails.chalandate,103) as chalandate, tbl_GstChallanDetails.chalanno, tbl_GstChallanDetails.itemid,tbl_GstChallan.chalantime,tbl_GstChallan.totalamt,tblfirm.mail as CursorAddress  ";
                query2 += " ,tbl_GstChallan.AddIGSTAmt as NetAmount,tbl_GstChallan.AddCGSTAmt as Discount,tbl_GstChallan.AddSGSTAmt as Fright,tbl_GstChallan.VehicleNo,tbl_GstChallanDetails.Unit ,tbl_Transport.TransportName ,tbl_DeliveredTo.compname as labourname ,";
                if (Data.id == "1")
                {
                    query2 += "  Deliverychallan='MSC/DC/CG/17-18/000' ,";
                }
                if (Data.id == "2")
                {
                    query2 += " Deliverychallan='AMSC/DC/CG/17-18/000',";
                }
                if (Data.id == "1")
                {
                    query2 += "   Invoicechallan='MSC/TI/CG/17-18/000'";
                }
                if (Data.id == "2")
                {
                    query2 += " Invoicechallan='AMSC/TI/CG/17-18/000'";
                }
                query2 += " FROM (((tblclient INNER JOIN tbl_GstChallanDetails ON tblclient.id = tbl_GstChallanDetails.clientid) INNER JOIN tblitem ON tbl_GstChallanDetails.itemid = tblitem.itemid) INNER JOIN tbl_GstChallan ON (tbl_GstChallanDetails.chalanno = tbl_GstChallan.chalanno) AND (tblclient.firmid = tbl_GstChallan.firmid)) ";
                query2 += " inner join tbl_Transport on tbl_Transport.lbrid=tbl_GstChallan.Transid inner join tblfirm on tblfirm.firmid=tbl_GstChallan.firmid   left join tbl_DeliveredTo on tbl_DeliveredTo.id=tbl_GstChallan.DeliveredTo  inner join tblsession on tblsession.sessionid=tbl_GstChallan.sessionid where tbl_GstChallanDetails.MaxId=" + lst.SelectedValue + " and tbl_GstChallanDetails.firmid=" + Data.id + " and tbl_GstChallan.sessionid=" + Data.sessionid + " and tbl_GstChallanDetails.sessionid=" + Data.sessionid + " and tblitem.itemname!='Freight'";
                Data.query = query2;
                ChallanReport rep11 = new ChallanReport();
                rep11.Show();

                string query1 = "SELECT tblfirm.StateCode AS Fstatcode,tblclient.Address as add1,tblsession.session,tblfirm.ShortName,tblfirm.Mail,tbl_GstChallanDetails.MaxId,tbl_GstChallanDetails.TaxableValue, tbl_GstChallanDetails.CGSTAmount,tbl_GstChallanDetails.SGSTAmount,tbl_GstChallanDetails.IGSTAmount,tblfirm.AcNo,tblfirm.ifscCode,tblfirm.BankName,tblfirm.BranchName,tblfirm.state,tblfirm.country,tblfirm.Phone,tblfirm.Mob as m1,tblfirm.GstNo as firmgstno,tblfirm.Address,upper(tblfirm.compname) as compname,tblclient.compname as Name, tbl_GstChallan.mobileno as Mob,tbl_GstChallan.DeliveryAddress, tblitem.itemname, tbl_GstChallanDetails.ravanano,tbl_GstChallanDetails.CGST,tbl_GstChallanDetails.SGST,tbl_GstChallanDetails.IGST, tbl_GstChallanDetails.price, ";
                query1 += "  tbl_GstChallanDetails.qty, tbl_GstChallanDetails.amount, Convert(char(11),tbl_GstChallanDetails.chalandate,103) as chalandate,tbl_GstChallanDetails.chalanno, tbl_GstChallanDetails.itemid,tbl_GstChallan.chalantime,tbl_GstChallan.totalamt,tblfirm.mail as CursorAddress    ,tbl_GstChallan.AddIGSTAmt,tbl_GstChallan.AddCGSTAmt,tbl_GstChallan.AddSGSTAmt,tbl_GstChallan.TotGSTAmt,tbl_GstChallan.TotalTaxAmt,tbl_GstChallan.ReverseCharge,tbl_GstChallan.VehicleNo,tbl_GstChallanDetails.Unit  ,tbl_Transport.TransportName ,tbl_DeliveredTo.GstNo as DGstNo,tbl_DeliveredTo.compname as labourname  ,tblclient.GSTRegistration,tblclient.GSTFlag,tblclient.GstNo ";
                query1 += " ,tblitem.itemcode,tbl_GstChallanDetails.Discount,tbl_GstChallanDetails.GrossTotal ,";
                if (Data.id == "1")
                {
                    query1 += "  Deliverychallan='MSC/DC/CG/17-18/000' ,";
                }
                if (Data.id == "2")
                {
                    query1 += " Deliverychallan='AMSC/DC/CG/17-18/000',";
                }
                if (Data.id == "1")
                {
                    query1 += "   Invoicechallan='MSC/TI/CG/17-18/000'";
                }
                if (Data.id == "2")
                {
                    query1 += " Invoicechallan='AMSC/TI/CG/17-18/000'";
                }
                query1 += " FROM (((tblclient INNER JOIN tbl_GstChallanDetails ON tblclient.id = tbl_GstChallanDetails.clientid)  INNER JOIN tblitem ON tbl_GstChallanDetails.itemid = tblitem.itemid) INNER JOIN tbl_GstChallan ON   (tbl_GstChallanDetails.chalanno = tbl_GstChallan.chalanno) AND (tblclient.firmid = tbl_GstChallan.firmid)) inner join tbl_Transport on tbl_Transport.lbrid=tbl_GstChallan.Transid inner join tblfirm on  tblfirm.firmid=tbl_GstChallan.firmid   left join tbl_DeliveredTo on tbl_DeliveredTo.id=tbl_GstChallan.DeliveredTo ";

                query1 += "  inner join tblsession on tblsession.sessionid=tbl_GstChallan.sessionid where tbl_GstChallanDetails.MaxId=" + lst.SelectedValue + " and tbl_GstChallanDetails.firmid=" + Data.id + " and tbl_GstChallan.sessionid=" + Data.sessionid + " and tbl_GstChallanDetails.sessionid=" + Data.sessionid + "";
                Data.query = query1;
                TaxInvoiceRepor rep = new TaxInvoiceRepor();
                rep.Show();


            }
            //  this.Close();
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
                 + dtpFrom.Value + "','" + dtpTo.Value + "','" + _search + "'";
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
            query = " select * from tbl_DeliveredTo where firmid=" + Data.id + " and compname='" + dtpDeliveredTo.Text + "' order by compname";
            DataSet dss = data.getDataSet(query);
            if (dss.Tables[0].Rows.Count > 0)
            {
                txtDeliveryAddress.Text = dss.Tables[0].Rows[0]["Address"].ToString();
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            //    string Ammount;
            //    try
            //    {
            //        Ammount = Convert.ToDouble(txttotal.Text).ToString();
            //        txtAddIGSTAmt.Text = (Convert.ToDouble(txtAddSGSTAmt.Text) + Convert.ToDouble(Ammount)).ToString();
            //    }
            //    catch
            //    {
            //        txtAddSGSTAmt.Text = "0";
            //    }
            cal();

        }
    }
}

