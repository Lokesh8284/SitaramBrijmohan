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
    public partial class RawMaterialNew : Form
    {
        Data data = new Data();
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        string query;
        int curr = 0;
        int currow = 0;
        int max2 = 0;
        int max1 = 0;
        public RawMaterialNew()
        {
            InitializeComponent();
        }
        private void ChalanForm_Load(object sender, EventArgs e)
        {
            label13.Text = Data.Area;
            itemname1();
            itemname();
            //VehicleFill();
            itemname();
            filllabour();
            FillStaff();
            maxchalan();
            filllst();
            btndel.Enabled = false;
            dtpUnit.SelectedIndex = 1;
            dtpUnit1.SelectedIndex = 1;
        }
        public void filllabour()
        {
            query = " select * from tbl_Transport where IsRowMaterial=1 and firmid=" + Data.id + " order by TransportName";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["lbrid"] = "0";
            newrow["TransportName"] = "---Select Transporter ----";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            drplbr.DataSource = ds.Tables[0];
            drplbr.DisplayMember = "TransportName";
            drplbr.ValueMember = "lbrid";
        }
        public void VehicleFill()
        {
            query = "  select *  FROM  tbl_Vehicle ";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["priceid"] = "0";
            newrow["VehicleNo"] = "---Select VehicleNo ---";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dtpVehicleNo.DataSource = ds.Tables[0];
                dtpVehicleNo.ValueMember = "priceid";
                dtpVehicleNo.DisplayMember = "VehicleNo";
            }
        }
        public void itemname1()
        {
            query = " select * from tblitem where IsRowMaterial=1 and firmid=" + Data.id + " order by itemname";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["itemid"] = "0";
            newrow["itemname"] = "---Select Item Name----";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                drpitem1.DataSource = ds.Tables[0];
                drpitem1.ValueMember = "itemid";
                drpitem1.DisplayMember = "itemname";
            }
        }
        public void itemname()
        {
            query = " select * from tblitem where IsRowMaterial=1 and firmid=" + Data.id + " order by itemname";
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
        public void FillStaff()
        {
            query = " select * from tbllabour where firmid=" + Data.id + " order by labourname";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["lbrid"] = "0";
            newrow["labourname"] = "---Select Staff Name----";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            drpStaff.DataSource = ds.Tables[0];
            drpStaff.DisplayMember = "labourname";
            drpStaff.ValueMember = "lbrid";
        }

        public void cleardata()
        {
            dateTimePicker1.Text = DateTime.Now.ToString();
        }
        private void drpitem_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (drpitem.SelectedIndex > 0)
            //{
            //    try
            //    {
            //        string dd = drpitem.SelectedValue.ToString();
            //        query = " SELECT tblitem.itemname, clientprice.rate, tblclient.Name, clientprice.priceno";
            //        query += " FROM tblitem INNER JOIN (tblclient INNER JOIN clientprice ON tblclient.id = clientprice.clientid) ON tblitem.itemid = clientprice.itemid";
            //        query += " where clientprice.itemid=" + drpitem.SelectedValue + "";
            //        query += " and tblclient.id=" + drpname.SelectedValue + "";
            //        ds = data.getDataSet(query);
            //        if (ds.Tables[0].Rows.Count > 0)
            //        {
            //            txtrate.Text = ds.Tables[0].Rows[0]["rate"].ToString();
            //        }
            //        else
            //        {
            //            txtrate.Text = "0";
            //        }
            //    }
            //    catch
            //    { }
            //}
            //else
            //{
            //    // itemname();
            //}
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
            maxchalan();
            //filllst();
            btnsave.Text = "Save";
            dateTimePicker1.Text = DateTime.Now.ToString();
            dateTimePicker2.Text = DateTime.Now.ToString();
            btndel.Enabled = false;
        }
        public void filllst()
        {
            string query1 = "select distinct convert(nvarchar(15), R.Billdate, 105) + '- '+ convert(nvarchar(15), R.InvoiceNo) as bDate ";
            query1 += " ,RD.InvoiceNo ,T.firmid,T.sessionid,TD.firmid,TD.sessionid,R.firmid,R.sessionid,RD.firmid,RD.sessionid from tbl_RowMaterialNew R inner join tbl_RowMatarialDetailsNew  RD ";
            query1 += " on R.InvoiceNo=RD.InvoiceNo inner join tbl_Transpoter T on T.InvoiceNo=R.InvoiceNo inner Join tbl_TransporterDetails TD on TD.InvoiceNo=T.InvoiceNo ";
            query1 += " where  R.firmid=" + Data.id + "  and R.sessionid=" + Data.sessionid + " ";
            query1 += " and R.Billdate >='" + dtpFrom.Value + "' ";
            query1 += " and R.Billdate <= '" + dtpTo.Value + "' ";
            query1 += "  order by RD.InvoiceNo desc ";
            ds = data.getDataSet(query1);
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
        private void btnitemadd_Click(object sender, EventArgs e)
        {
            Add();
        }
        public void Add()
        {

            if (drpStaff.SelectedIndex == 0)
            {
                MessageBox.Show(" Staff Name Must be Select");
                drpStaff.Focus();
                return;
            }
            if (drpitem1.SelectedIndex == 0)
            {
                MessageBox.Show(" Item Name Must be Select");
                drpitem1.Focus();
                return;
            }
            if (btnadd.Text == "Add")
            {
                grdtest1.Rows.Add();
                curr = grdtest1.Rows.Count - 1;
                int dd = curr + 1;
                grdtest1.Rows[curr].Cells["sno"].Value = dd;
                grdtest1.Rows[curr].Cells["itemid"].Value = drpitem1.SelectedValue;
                grdtest1.Rows[curr].Cells["Item"].Value = drpitem1.Text;
                grdtest1.Rows[curr].Cells["Staff"].Value = drpStaff.Text;
                grdtest1.Rows[curr].Cells["id"].Value = drpStaff.SelectedValue;
                grdtest1.Rows[curr].Cells["Quantity"].Value = txtqty.Text;
                grdtest1.Rows[curr].Cells["Unit"].Value = dtpUnit.Text;
                grdtest1.Rows[curr].Cells["Edit1"].Value = "Edit";
                grdtest1.Rows[curr].Cells["del"].Value = "Delete";
                FillCalc();
            }
            else
            {
                int dd = currow + 1;
                grdtest1.Rows[currow].Cells["sno"].Value = dd;
                grdtest1.Rows[currow].Cells["itemid"].Value = drpitem1.SelectedValue;
                grdtest1.Rows[currow].Cells["Item"].Value = drpitem1.Text;
                grdtest1.Rows[currow].Cells["Staff"].Value = drpStaff.Text;
                grdtest1.Rows[currow].Cells["id"].Value = drpStaff.SelectedValue;
                grdtest1.Rows[currow].Cells["Quantity"].Value = txtqty.Text;
                grdtest1.Rows[currow].Cells["Unit"].Value = dtpUnit.Text;
                grdtest1.Rows[currow].Cells["Edit1"].Value = "Edit";
                grdtest1.Rows[currow].Cells["del"].Value = "Delete";
                FillCalc();
            }
            Reset();

        }
        public void FillCalc()
        {
            int totAmt = 0;
            for (int i = 0; i < grdtest1.Rows.Count; i++)
            {
                totAmt += Convert.ToInt16(grdtest1.Rows[i].Cells["Quantity"].Value.ToString());
            }
            txtTotal1.Text = totAmt.ToString();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Add1();
        }
        public void Add1()
        {

            if (drpitem.SelectedIndex == 0)
            {
                MessageBox.Show(" Item Name Must be Select");
                drpStaff.Focus();
                return;
            }
            if (dtpVehicleNo.SelectedIndex == 0)
            {
                MessageBox.Show("Vehicle No Must be Select");
                dtpVehicleNo.Focus();
                return;
            }
            if (button5.Text == "Add1")
            {
                grdTransport.Rows.Add();
                curr = grdTransport.Rows.Count - 1;
                int dd = curr + 1;
                grdTransport.Rows[curr].Cells["Sno1"].Value = dd;
                grdTransport.Rows[curr].Cells["itemid1"].Value = drpitem.SelectedValue;
                grdTransport.Rows[curr].Cells["Item1"].Value = drpitem.Text;
                grdTransport.Rows[curr].Cells["transid"].Value = drplbr.SelectedValue;
                grdTransport.Rows[curr].Cells["Transporter"].Value = drplbr.Text;
                grdTransport.Rows[curr].Cells["VehicleNo"].Value = dtpVehicleNo.Text;
                grdTransport.Rows[curr].Cells["Quantity1"].Value = txtQuantity.Text;
                grdTransport.Rows[curr].Cells["unit1"].Value = dtpUnit1.Text;
                grdTransport.Rows[curr].Cells["Edit2"].Value = "Edit";
                grdTransport.Rows[curr].Cells["del2"].Value = "Delete";
                FillCalc1();
            }
            else
            {
                int dd = currow + 1;
                grdTransport.Rows[currow].Cells["Sno1"].Value = dd;
                grdTransport.Rows[currow].Cells["itemid1"].Value = drpitem.SelectedValue;
                grdTransport.Rows[currow].Cells["Item1"].Value = drpitem.Text;
                grdTransport.Rows[currow].Cells["transid"].Value = drplbr.SelectedValue;
                grdTransport.Rows[currow].Cells["Transporter"].Value = drplbr.Text;
                grdTransport.Rows[currow].Cells["VehicleNo"].Value = dtpVehicleNo.Text;
                grdTransport.Rows[currow].Cells["Quantity1"].Value = txtQuantity.Text;
                grdTransport.Rows[currow].Cells["unit1"].Value = dtpUnit1.Text;
                grdTransport.Rows[currow].Cells["Edit2"].Value = "Edit";
                grdTransport.Rows[currow].Cells["del2"].Value = "Delete";
                FillCalc1();
            }
            clear1();

        }
        public void FillCalc1()
        {
            int totAmt = 0;
            for (int i = 0; i < grdTransport.Rows.Count; i++)
            {
                totAmt += Convert.ToInt16(grdTransport.Rows[i].Cells["Quantity1"].Value.ToString());
            }
            txtTotal2.Text = totAmt.ToString();
        }
        public void maxchalan()
        {
            query = " select max(InvoiceNo) as sno,max(InvoiceNo) as Inno from tbl_RowMaterialNew where firmid=" + Data.id + " and sessionid=" + Data.sessionid + "";
            dr = data.getDataReader(query);
            if (dr.Read())
            {
                string sno = dr["sno"].ToString();
                string Inno = dr["Inno"].ToString();
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

                if (Inno == "")
                {
                    max2 = Convert.ToInt32(Inno + 1);
                }
                else
                {
                    int dd = Convert.ToInt32(Inno);
                    max2 = Convert.ToInt32(dd + 1);
                }
                txtInvoiceNo.Text = Convert.ToString(max2);
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
                    drpitem1.Text = grdtest1.Rows[e.RowIndex].Cells["Item"].Value.ToString();
                    txtqty.Text = grdtest1.Rows[e.RowIndex].Cells["Quantity"].Value.ToString();
                    drpStaff.Text = grdtest1.Rows[e.RowIndex].Cells["Staff"].Value.ToString();
                    dtpUnit.Text = grdtest1.Rows[e.RowIndex].Cells["Unit"].Value.ToString();

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
            //if (drpTransporter.SelectedIndex == 0)
            //{
            //    MessageBox.Show("Transporter Must be Entered");
            //    drpTransporter.Focus();
            //    return;
            //}

            if (grdtest1.Rows.Count == 0)
            {
                MessageBox.Show("Record's not fount");
                return;
            }
            if (grdTransport.Rows.Count == 0)
            {
                MessageBox.Show("Record's not fount");
                return;
            }
            int itemid12 = 0, itemid123 = 0;
            for (int i = 0; i < grdtest1.Rows.Count; i++)
            {
                itemid12 = Convert.ToInt16(grdtest1.Rows[i].Cells["itemid"].Value);
            }
            for (int i = 0; i < grdTransport.Rows.Count; i++)
            {
                itemid123 = Convert.ToInt16(grdTransport.Rows[i].Cells["itemid1"].Value);
            }
            if (txtTotal1.Text == txtTotal2.Text && itemid12 == itemid123)
            {
                if (btnsave.Text == "Save")
                {
                    if (data.Exist("select InvoiceNo from tbl_RowMaterialNew where InvoiceNo=" + txtInvoiceNo.Text + " and firmid=" + Data.id + " and sessionid=" + Data.sessionid + " "))
                    {
                        MessageBox.Show("InvoiceNo already Exist");
                        txtInvoiceNo.Focus();
                        return;
                    }
                    query = " insert into tbl_RowMaterialNew(InvoiceNo,BillDate,InvoiceDate,firmid,sessionid,totalUnit)values(@InvoiceNo,@BillDate,@InvoiceDate,@firmid,@sessionid,@totalUnit)";
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@InvoiceNo", txtInvoiceNo.Text);
                    cmd.Parameters.AddWithValue("@BillDate", data.getDateMMDDYYYY(dateTimePicker1.Text));
                    cmd.Parameters.AddWithValue("@InvoiceDate", DateTime.Now.ToString("MM/dd/yyyy"));
                    cmd.Parameters.AddWithValue("@firmid", Data.id);
                    cmd.Parameters.AddWithValue("@sessionid", Data.sessionid);
                    cmd.Parameters.AddWithValue("@totalUnit", txtTotal1.Text);
                    data.executeCommand(cmd);
                    cmd.Parameters.Clear();

                    query = " insert into tbl_RowMatarialDetailsNew(StaffId,Item,Quantity,ItemId,StaffName,Unit,firmid,sessionid,date,InvoiceNo)values(@StaffId,@Item,@Quantity,@ItemId,@StaffName,@Unit,@firmid,@sessionid,@date,@InvoiceNo)";
                    cmd.CommandText = query;
                    for (int i = 0; i < grdtest1.Rows.Count; i++)
                    {
                        cmd.Parameters.AddWithValue("@StaffId", grdtest1.Rows[i].Cells["id"].Value.ToString());
                        cmd.Parameters.AddWithValue("@ItemId", grdtest1.Rows[i].Cells["itemid"].Value.ToString());
                        cmd.Parameters.AddWithValue("@Item", grdtest1.Rows[i].Cells["Item"].Value.ToString());
                        cmd.Parameters.AddWithValue("@date", data.getDateMMDDYYYY(dateTimePicker1.Text));
                        cmd.Parameters.AddWithValue("@Quantity", grdtest1.Rows[i].Cells["Quantity"].Value.ToString());
                        cmd.Parameters.AddWithValue("@StaffName", grdtest1.Rows[i].Cells["Staff"].Value.ToString());
                        cmd.Parameters.AddWithValue("@firmid", Data.id);
                        cmd.Parameters.AddWithValue("@Unit", grdtest1.Rows[i].Cells["Unit"].Value.ToString());
                        cmd.Parameters.AddWithValue("@sessionid", Data.sessionid);
                        cmd.Parameters.AddWithValue("@InvoiceNo", txtInvoiceNo.Text);
                        data.executeCommand(cmd);
                        cmd.Parameters.Clear();
                    }
                    if (data.Exist("select InvoiceNo from tbl_Transpoter where InvoiceNo=" + txtInvoiceNo.Text + " and firmid=" + Data.id + " and sessionid=" + Data.sessionid + " "))
                    {
                        MessageBox.Show("InvoiceNo already Exist");
                        txtchalanno.Focus();
                        return;
                    }
                    query = " insert into tbl_Transpoter(InvoiceNo,BillDate,InvoiceDate,firmid,sessionid,totalUnit)values(@InvoiceNo,@BillDate,@InvoiceDate,@firmid,@sessionid,@totalUnit)";
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@InvoiceNo", txtInvoiceNo.Text);
                    cmd.Parameters.AddWithValue("@BillDate", data.getDateMMDDYYYY(dateTimePicker1.Text));
                    cmd.Parameters.AddWithValue("@InvoiceDate", DateTime.Now.ToString("MM/dd/yyyy"));
                    cmd.Parameters.AddWithValue("@firmid", Data.id);
                    cmd.Parameters.AddWithValue("@sessionid", Data.sessionid);
                    cmd.Parameters.AddWithValue("@totalUnit", txtTotal2.Text);
                    data.executeCommand(cmd);
                    cmd.Parameters.Clear();

                    query = " insert into tbl_TransporterDetails(VehicleNo,Quantity,ItemId,ItemName,firmid,sessionid,date,unit,InvoiceNo,transid,Transporter)values(@VehicleNo,@Quantity,@ItemId,@ItemName,@firmid,@sessionid,@date,@unit,@InvoiceNo,@transid,@Transporter)";
                    cmd.CommandText = query;
                    for (int i = 0; i < grdTransport.Rows.Count; i++)
                    {
                        cmd.Parameters.AddWithValue("@VehicleNo", grdTransport.Rows[i].Cells["VehicleNo"].Value.ToString());
                        cmd.Parameters.AddWithValue("@ItemId", grdTransport.Rows[i].Cells["itemid1"].Value.ToString());
                        cmd.Parameters.AddWithValue("@date", data.getDateMMDDYYYY(dateTimePicker1.Text));
                        cmd.Parameters.AddWithValue("@Quantity", grdTransport.Rows[i].Cells["Quantity1"].Value.ToString());
                        cmd.Parameters.AddWithValue("@ItemName", grdTransport.Rows[i].Cells["Item1"].Value.ToString());
                        cmd.Parameters.AddWithValue("@firmid", Data.id);
                        cmd.Parameters.AddWithValue("@sessionid", Data.sessionid);
                        cmd.Parameters.AddWithValue("@unit", grdTransport.Rows[i].Cells["unit1"].Value.ToString());
                        cmd.Parameters.AddWithValue("@InvoiceNo", txtInvoiceNo.Text);
                        cmd.Parameters.AddWithValue("@transid", grdTransport.Rows[i].Cells["transid"].Value.ToString());
                        cmd.Parameters.AddWithValue("@Transporter", grdTransport.Rows[i].Cells["Transporter"].Value.ToString());
                        data.executeCommand(cmd);
                        cmd.Parameters.Clear();
                    }
                }

                else
                {
                    //{
                    //    query = "delete from tbl_RowMaterial where chalanno=" + txtchalanno.Text + " and firmid=" + Data.id + " and sessionid=" + Data.sessionid + "";
                    //    data.executeCommand(query);
                    //    query = "delete from tbl_RowMaterialDetails where chalanno=" + txtchalanno.Text + " and firmid=" + Data.id + " and sessionid=" + Data.sessionid + "";
                    //    data.executeCommand(query);
                    //    if (data.Exist("select chalanno from tbl_RowMaterial where chalanno=" + txtchalanno.Text + " and firmid=" + Data.id + "and sessionid=" + Data.sessionid + ""))
                    //    {
                    //        MessageBox.Show("Chalanno. already Exist");
                    //        txtchalanno.Focus();
                    //        return;
                    //    }
                    //    query = " insert into tbl_RowMaterial(chalanno,totalamt,clientid,chalandate,firmid,lbrid,sessionid,InvoiceNo,InvoiceDate,Discount,NetAmount,Transid,VehicleNo,Fright)values(@chalanno,@totalamt,@clientid,@chalandate,@firmid,@lbrid,@sessionid,@InvoiceNo,@InvoiceDate,@Discount,@NetAmount,@Transid,@VehicleNo,@Fright)";
                    //    cmd.CommandText = query;
                    //    cmd.Parameters.AddWithValue("@chalanno", txtchalanno.Text);

                    //    cmd.Parameters.AddWithValue("@chalandate", data.getDateMMDDYYYY(dateTimePicker1.Text));
                    //    cmd.Parameters.AddWithValue("@firmid", Data.id);

                    //    cmd.Parameters.AddWithValue("@Transid", 0);
                    //    cmd.Parameters.AddWithValue("@VehicleNo", 0);
                    //    cmd.Parameters.AddWithValue("@sessionid", Data.sessionid);
                    //    cmd.Parameters.AddWithValue("@InvoiceNo", txtInvoiceNo.Text);
                    //    cmd.Parameters.AddWithValue("@InvoiceDate", data.getDateMMDDYYYY(dateTimePicker2.Text));

                    //    data.executeCommand(cmd);
                    //    cmd.Parameters.Clear();

                    //    query = " insert into tbl_RowMaterialDetails(chalanno,clientid,itemid,price,chalandate,qty,amount,firmid,sessionid,Unit)values(@chalanno,@clientid,@itemid,@price,@chalandate,@qty,@amount,@firmid,@sessionid,@Unit)";
                    //    cmd.CommandText = query;
                    //    for (int i = 0; i < grdtest1.Rows.Count; i++)
                    //    {
                    //        cmd.Parameters.AddWithValue("@chalanno", txtchalanno.Text);
                    //        ;
                    //        cmd.Parameters.AddWithValue("@itemid", grdtest1.Rows[i].Cells["itemid"].Value.ToString());
                    //        cmd.Parameters.AddWithValue("@price", grdtest1.Rows[i].Cells["rate"].Value.ToString());
                    //        cmd.Parameters.AddWithValue("@chalandate", data.getDateMMDDYYYY(dateTimePicker1.Text));
                    //        cmd.Parameters.AddWithValue("@qty", grdtest1.Rows[i].Cells["qty"].Value.ToString());
                    //        cmd.Parameters.AddWithValue("@amount", grdtest1.Rows[i].Cells["amount"].Value.ToString());
                    //        cmd.Parameters.AddWithValue("@firmid", Data.id);
                    //        cmd.Parameters.AddWithValue("@Unit", grdtest1.Rows[i].Cells["Unit"].Value.ToString());
                    //        cmd.Parameters.AddWithValue("@sessionid", Data.sessionid);
                    //        data.executeCommand(cmd);
                    //        cmd.Parameters.Clear();
                    //    }
                }
                MessageBox.Show(btnsave.Text + "Record Successfully !!!");
                grdtest1.Rows.Clear();
                grdTransport.Rows.Clear();
                txtTotal1.Text = "";
                txtTotal2.Text = "";
                filllst();
            }
            else
            {
                MessageBox.Show("Quantity For The Both Are Not Equal !!! And Item Name Will Be Same");
            }

        }
        private void lst_Click(object sender, EventArgs e)
        {
            fillclk();
        }
        public void fillclk()
        {
            string query1;
            string query2;

            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();
            query1 = "select   convert(nvarchar(15), R.Billdate  , 105) as bDate, ";
            query1 += " RD.StaffId,R.InvoiceDate,RD.Itemid as Iid,R.RId,RD.StaffName,RD.Unit,RD.Item,RD.Quantity,RD.InvoiceNo, ";
            query1 += " RD.date,RD.InvoiceNo as InvoNo,R.totalunit  ,R.firmid,R.sessionid,RD.firmid,RD.sessionid ";
            query1 += " from tbl_RowMaterialNew   R inner join tbl_RowMatarialDetailsNew  RD  on R.InvoiceNo=RD.InvoiceNo ";
            query1 += " where RD.InvoiceNo=" + lst.SelectedValue + " and R.firmid=" + Data.id + "  and R.sessionid=" + Data.sessionid + " ";

            query2 = "select   convert(nvarchar(15), T.Billdate  , 105) as bDate, ";
            query2 += " Td.ItemId as TItemId,  TD.InvoiceNo as InvoNo,TD.Quantity as Qty,TD.ItemName,TD.unit as Unt, ";
            query2 += " T.totalunit as Totamt,TD.VehicleNo  ,T.firmid,T.sessionid,TD.firmid,TD.sessionid, TD.transid,TD.Transporter ";
            query2 += " from   tbl_Transpoter T   inner Join tbl_TransporterDetails TD on TD.InvoiceNo=T.InvoiceNo  ";
            query2 += " where TD.InvoiceNo=" + lst.SelectedValue + " and T.firmid=" + Data.id + "  and T.sessionid=" + Data.sessionid + " ";

            ds1 = data.getDataSet(query1);
            ds2 = data.getDataSet(query2);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                grdtest1.Rows.Clear();
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    txtchalanno.Text = ds1.Tables[0].Rows[i]["InvoiceNo"].ToString();
                    txtInvoiceNo.Text = ds1.Tables[0].Rows[i]["InvoiceNo"].ToString();
                    dateTimePicker1.Text = ds1.Tables[0].Rows[0]["date"].ToString();
                    dateTimePicker2.Text = ds1.Tables[0].Rows[0]["InvoiceDate"].ToString();
                    txtTotal1.Text = ds1.Tables[0].Rows[i]["totalunit"].ToString();

                    grdtest1.Rows.Add();
                    grdtest1.Rows[i].Cells["sno"].Value = grdtest1.Rows.Count;
                    grdtest1.Rows[i].Cells["itemid"].Value = ds1.Tables[0].Rows[i]["Iid"].ToString();
                    grdtest1.Rows[i].Cells["Item"].Value = ds1.Tables[0].Rows[i]["item"].ToString();
                    grdtest1.Rows[i].Cells["Staff"].Value = ds1.Tables[0].Rows[i]["StaffName"].ToString();
                    grdtest1.Rows[i].Cells["id"].Value = ds1.Tables[0].Rows[i]["StaffId"].ToString();
                    grdtest1.Rows[i].Cells["Unit"].Value = ds1.Tables[0].Rows[i]["Unit"].ToString();
                    grdtest1.Rows[i].Cells["Quantity"].Value = ds1.Tables[0].Rows[i]["Quantity"].ToString();
                    grdtest1.Rows[i].Cells["Edit1"].Value = "Edit";
                    grdtest1.Rows[i].Cells["del"].Value = "Delete";
                }
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    grdTransport.Rows.Clear();
                    for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                    {
                        txtTotal2.Text = ds2.Tables[0].Rows[i]["Totamt"].ToString();

                        grdTransport.Rows.Add();
                        grdTransport.Rows[i].Cells["Sno1"].Value = grdTransport.Rows.Count;
                        grdTransport.Rows[i].Cells["itemid1"].Value = ds2.Tables[0].Rows[i]["TItemId"].ToString();
                        grdTransport.Rows[i].Cells["Item1"].Value = ds2.Tables[0].Rows[i]["ItemName"].ToString();
                        grdTransport.Rows[i].Cells["transid"].Value = ds2.Tables[0].Rows[i]["transid"].ToString();
                        grdTransport.Rows[i].Cells["Transporter"].Value = ds2.Tables[0].Rows[i]["Transporter"].ToString();
                        grdTransport.Rows[i].Cells["VehicleNo"].Value = ds2.Tables[0].Rows[i]["VehicleNo"].ToString();
                        grdTransport.Rows[i].Cells["unit1"].Value = ds2.Tables[0].Rows[i]["Unt"].ToString();
                        grdTransport.Rows[i].Cells["Quantity1"].Value = ds2.Tables[0].Rows[i]["Qty"].ToString();
                        grdTransport.Rows[i].Cells["Edit2"].Value = "Edit";
                        grdTransport.Rows[i].Cells["del2"].Value = "Delete";
                    }
                }
                btnsave.Text = "Update";
                btndel.Enabled = true;
            }
            else
            {
                MessageBox.Show("Data Not Found ");
            }
        }
        private void txtqty_TextChanged(object sender, EventArgs e)
        {
            //if (txtqty.Text == "")
            //{
            //    // txtqty.Text = "0";
            //}
            //try
            //{
            //    double rate = Convert.ToDouble(txtrate.Text);
            //    double qty = Convert.ToDouble(txtqty.Text);
            //    double amt = rate * qty;
            //    txtamout.Text = Convert.ToString(amt);
            //}
            //catch
            //{
            //}
        }
        private void button3_Click(object sender, EventArgs e)
        {
            clear1();
        }
        public void Reset()
        {
            txtqty.Text = "0";
            drpStaff.SelectedIndex = 0;
            drpitem1.SelectedIndex = 0;
            btnadd.Text = "Add";
        }
        public void clear1()
        {
            txtQuantity.Text = "0";
            dtpVehicleNo.SelectedIndex = 0;
            drplbr.SelectedIndex = 0;
            drpitem.SelectedIndex = 0;
            button5.Text = "Add";
        }
        public void clear2()
        {
            txtqty.Text = "0";
            dtpVehicleNo.Text = "";
            button5.Text = "Add";
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
            //if (txtqty.Text == "")
            //{
            //    txtqty.Text = "0";
            //}
            //try
            //{
            //    double rate = Convert.ToDouble(txtrate.Text);
            //    double qty = Convert.ToDouble(txtqty.Text);
            //    double amt = rate * qty;
            //    txtamout.Text = Convert.ToString(amt);
            //}
            //catch
            //{
            //}
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
                query = " delete from tbl_RowMatarialDetailsNew where firmid=" + Data.id + " and InvoiceNo =" + lst.SelectedValue + " and sessionid=" + Data.sessionid + " ";
                data.executeCommand(query);
                query = " delete from tbl_RowMaterialNew where firmid=" + Data.id + " and InvoiceNo=" + lst.SelectedValue + " and sessionid=" + Data.sessionid + " ";
                data.executeCommand(query);
                query = " delete from tbl_Transpoter where firmid=" + Data.id + " and InvoiceNo=" + lst.SelectedValue + " and sessionid=" + Data.sessionid + " ";
                data.executeCommand(query);
                query = " delete from tbl_TransporterDetails where firmid=" + Data.id + " and InvoiceNo=" + lst.SelectedValue + " and sessionid=" + Data.sessionid + " ";
                data.executeCommand(query);
                clear();
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                query = "SELECT tblclient.Name + '- '+ Convert(char(7),tbl_RowMaterial.chalanno) as name,tbl_RowMaterial.chalanno as chano FROM tbl_RowMaterial INNER JOIN tblclient ON tbl_RowMaterial.clientid = tblclient.id  where tblclient.firmid=" + Data.id + "";
                query += " and tbl_RowMaterial.chalanno Like '" + textBox1.Text.Trim() + "%' and tbl_RowMaterial.sessionid=" + Data.sessionid + " and BillConf=0";
                query += " order by tbl_RowMaterial.chalanno ";
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

        private void grdTransport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            currow = e.RowIndex;
            try
            {
                if (grdTransport.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Edit")
                {
                    drpitem.Text = grdTransport.Rows[e.RowIndex].Cells["Item1"].Value.ToString();
                    drplbr.Text = grdTransport.Rows[e.RowIndex].Cells["Transporter"].Value.ToString();
                    txtQuantity.Text = grdTransport.Rows[e.RowIndex].Cells["Quantity1"].Value.ToString();
                    dtpVehicleNo.Text = grdTransport.Rows[e.RowIndex].Cells["VehicleNo"].Value.ToString();
                    dtpUnit1.Text = grdTransport.Rows[e.RowIndex].Cells["Unit1"].Value.ToString();

                    button5.Text = "Update";
                }
                if (grdTransport.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Delete")
                {
                    grdTransport.Rows.RemoveAt(e.RowIndex);
                }
            }
            catch
            { }
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

        private void button6_Click(object sender, EventArgs e)
        {
            string query1 = "select distinct convert(nvarchar(15), R.Billdate  , 105) + '- '+ convert(nvarchar(15), R.InvoiceNo) as bDate ";
            query1 += " ,RD.InvoiceNo,T.firmid,T.sessionid,TD.firmid,TD.sessionid,R.firmid,R.sessionid,RD.firmid,RD.sessionid from tbl_RowMaterialNew   R inner join tbl_RowMatarialDetailsNew  RD ";
            query1 += " on R.InvoiceNo=RD.InvoiceNo inner join tbl_Transpoter T on T.InvoiceNo=R.InvoiceNo inner Join tbl_TransporterDetails TD on TD.InvoiceNo=T.InvoiceNo ";
            query1 += " where  R.firmid=" + Data.id + "  and R.sessionid=" + Data.sessionid + " ";
            query1 += " and  R.Billdate >='" + dtpFrom.Value.ToString("MM/dd/yyyy") + "' ";
            query1 += " and R.Billdate <= '" + dtpTo.Value.ToString("MM/dd/yyyy") + "' ";
            query1 += "  order by RD.InvoiceNo desc ";
            ds = data.getDataSet(query1);
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
            string query1 = "select distinct convert(nvarchar(15), R.Billdate  , 105) + '- '+ convert(nvarchar(15), R.InvoiceNo) as bDate ";
            query1 += " ,RD.InvoiceNo,T.firmid,T.sessionid,TD.firmid,TD.sessionid,R.firmid,R.sessionid,RD.firmid,RD.sessionid from tbl_RowMaterialNew   R inner join tbl_RowMatarialDetailsNew  RD ";
            query1 += " on R.InvoiceNo=RD.InvoiceNo inner join tbl_Transpoter T on T.InvoiceNo=R.InvoiceNo inner Join tbl_TransporterDetails TD on TD.InvoiceNo=T.InvoiceNo ";
            query1 += " where  R.firmid=" + Data.id + "  and R.sessionid=" + Data.sessionid + " ";
            query1 += " and  R.Billdate >='" + dtpFrom.Value.ToString("MM/dd/yyyy") + "' ";
            query1 += " and R.Billdate <= '" + dtpTo.Value.ToString("MM/dd/yyyy") + "' and RD.InvoiceNo like " + _search + " ";
            query1 += "  order by RD.InvoiceNo desc ";
            ds = data.getDataSet(query1);
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

        private void label24_Click(object sender, EventArgs e)
        {
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }
    }
}
