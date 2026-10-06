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
    public partial class DirectChallan : Form
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
        public DirectChallan()
        {
            InitializeComponent();
        }
        private void ChalanForm_Load(object sender, EventArgs e)
        {
            label13.Text = Data.Area;
            partyname();
            itemname();
            maxchalan();
            //filllst();
            drpname.Focus();
            filllabour();
            labourate();
            drpname.Focus();
            btndel.Enabled = false;
            dtpUnit.SelectedIndex = 0;
        }
        public void cleardata()
        {
            dateTimePicker1.Text = DateTime.Now.ToString();
        }
        public void partyname()
        {
            query = " select * from tblclient where firmid=" + Data.id + " order by name";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["id"] = "0";
            newrow["name"] = "---Select Party Name----";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            drpname.DataSource = ds.Tables[0];
            drpname.DisplayMember = "name";
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
                    string dd = drpitem.SelectedValue.ToString();
                    query = " SELECT tblitem.itemname, clientprice.rate, tblclient.Name, clientprice.priceno";
                    query += " FROM tblitem INNER JOIN (tblclient INNER JOIN clientprice ON tblclient.id = clientprice.clientid) ON tblitem.itemid = clientprice.itemid";
                    query += " where clientprice.itemid=" + drpitem.SelectedValue + "";
                    query += " and tblclient.id=" + drpname.SelectedValue + "";
                    ds = data.getDataSet(query);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtrate.Text = ds.Tables[0].Rows[0]["rate"].ToString();
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
            drpname.Focus();
            drpitem.SelectedIndex = 0;
            dateTimePicker1.Text = DateTime.Now.ToString();
            btndel.Enabled = false;
        }
        public void filllst()
        {
            //query = "SELECT tblclient.Name & '- '& tblchalan.chalanno as name,tblchalan.chalanno as chano FROM tblchalan INNER JOIN tblclient ON tblchalan.clientid = tblclient.id  where BillConf=0 and tblclient.firmid=" + Data.id + " and tblchalan.sessionid=" + Data.sessionid + "";
            //query += " order by tblchalan.chalanno ";
            query = "SELECT tblclient.Name + '- '+ convert(char(7),tblchalan.chalanno) as name,tblchalan.chalanno as chano FROM tblchalan INNER JOIN tblclient ON tblchalan.clientid = tblclient.id  where tblclient.firmid=" + Data.id + " and BillConf=0 and tblchalan.sessionid=" + Data.sessionid + "";
            query += " order by tblchalan.chalanno ";
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
            if (rat == 0)
            {
                MessageBox.Show("Rate Must be Entered");
                txtrate.Focus();
                return;
            }
            if (drplbr.SelectedIndex == 0)
            {
                MessageBox.Show("Labour Must be Entered");
                drplbr.Focus();
                return;
            }
            if (drpitem.SelectedIndex == 0)
            {
                MessageBox.Show("Item Name Must be Select");
                drpitem.Focus();
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
                grdtest1.Rows[curr].Cells["Unit"].Value = dtpUnit.Text;
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
                grdtest1.Rows[curr].Cells["Unit"].Value = dtpUnit.Text;
                grdtest1.Rows[currow].Cells["Edit1"].Value = "Edit";
                grdtest1.Rows[currow].Cells["del"].Value = "Delete";
            }
            drpitem.Focus();
            txttotal.Text = getTotalAmt().ToString();
            clear1();
        }
        public void maxchalan()
        {
            query = " select max(chalanno) as sno from tblchalan where firmid=" + Data.id + " and sessionid=" + Data.sessionid + "";
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
            if (btnsave.Text == "Save")
            {
                if (data.Exist("select chalanno from tblchalan where chalanno=" + txtchalanno.Text + " and firmid=" + Data.id + " and sessionid=" + Data.sessionid + " "))
                {
                    MessageBox.Show("Chalanno. already Exist");
                    txtchalanno.Focus();
                    return;
                }
                query = " insert into tblchalan(chalanno,totalamt,clientid,chalandate,firmid,lbrid,lbrrate,sessionid)values(@chalanno,@totalamt,@clientid,@chalandate,@firmid,@lbrid,@lbrrate,@sessionid)";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@chalanno", txtchalanno.Text);
                cmd.Parameters.AddWithValue("@totalamt", txttotal.Text);
                cmd.Parameters.AddWithValue("@clientid", drpname.SelectedValue);
                cmd.Parameters.AddWithValue("@chalandate", data.getDateMMDDYYYY(dateTimePicker1.Text));
                cmd.Parameters.AddWithValue("@firmid", Data.id);
                cmd.Parameters.AddWithValue("@lbrid", drplbr.SelectedValue);
                cmd.Parameters.AddWithValue("@lbrrate", txtlbrrate.Text);
                cmd.Parameters.AddWithValue("@sessionid", Data.sessionid);
                data.executeCommand(cmd);
                cmd.Parameters.Clear();
                query = "";
                query = " insert into chalandetail(chalanno,clientid,itemid,price,chalandate,qty,amount,firmid,ravanano,sessionid)values(@chalanno,@clientid,@itemid,@price,@chalandate,@qty,@amount,@firmid,@ravanano,@sessionid)";
                cmd.CommandText = query;
                for (int i = 0; i < grdtest1.Rows.Count; i++)
                {
                    cmd.Parameters.AddWithValue("@chalanno", txtchalanno.Text);
                    cmd.Parameters.AddWithValue("@clientid", drpname.SelectedValue);
                    cmd.Parameters.AddWithValue("@itemid", grdtest1.Rows[i].Cells["itemid"].Value.ToString());
                    cmd.Parameters.AddWithValue("@price", grdtest1.Rows[i].Cells["rate"].Value.ToString());
                    cmd.Parameters.AddWithValue("@chalandate", data.getDateMMDDYYYY(dateTimePicker1.Text));
                    cmd.Parameters.AddWithValue("@qty", grdtest1.Rows[i].Cells["qty"].Value.ToString());
                    cmd.Parameters.AddWithValue("@amount", grdtest1.Rows[i].Cells["amount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@firmid", Data.id);
                    cmd.Parameters.AddWithValue("@ravanano", grdtest1.Rows[i].Cells["ravanno"].Value.ToString());
                    cmd.Parameters.AddWithValue("@sessionid", Data.sessionid);
                    data.executeCommand(cmd);
                    cmd.Parameters.Clear();
                }
            }
            else
            {
                query = "delete from tblchalan where chalanno=" + txtchalanno.Text + " and firmid=" + Data.id + " and sessionid=" + Data.sessionid + "";
                data.executeCommand(query);
                query = "delete from chalandetail where chalanno=" + txtchalanno.Text + " and firmid=" + Data.id + " and sessionid=" + Data.sessionid + "";
                data.executeCommand(query);
                if (data.Exist("select chalanno from tblchalan where chalanno=" + txtchalanno.Text + " and firmid=" + Data.id + "and sessionid=" + Data.sessionid + ""))
                {
                    MessageBox.Show("Chalanno. already Exist");
                    txtchalanno.Focus();
                    return;
                }
                query = " insert into tblchalan(chalanno,totalamt,clientid,chalandate,firmid,lbrid,lbrrate,sessionid)values(@chalanno,@totalamt,@clientid,@chalandate,@firmid,@lbrid,@lbrrate,@sessionid)";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@chalanno", txtchalanno.Text);
                cmd.Parameters.AddWithValue("@totalamt", getTotalAmt().ToString());
                cmd.Parameters.AddWithValue("@clientid", drpname.SelectedValue);
                cmd.Parameters.AddWithValue("@chalandate", data.getDateMMDDYYYY(dateTimePicker1.Text));
                cmd.Parameters.AddWithValue("@firmid", Data.id);
                cmd.Parameters.AddWithValue("@lbrid", drplbr.SelectedValue);
                cmd.Parameters.AddWithValue("@lbrrate", txtlbrrate.Text);
                cmd.Parameters.AddWithValue("@sessionid", Data.sessionid);
                data.executeCommand(cmd);
                cmd.Parameters.Clear();
                query = "";
                query = " insert into chalandetail(chalanno,clientid,itemid,price,chalandate,qty,amount,firmid,ravanano,sessionid)values(@chalanno,@clientid,@itemid,@price,@chalandate,@qty,@amount,@firmid,@ravanano,@sessionid)";
                cmd.CommandText = query;
                for (int i = 0; i < grdtest1.Rows.Count; i++)
                {
                    cmd.Parameters.AddWithValue("@chalanno", txtchalanno.Text);
                    cmd.Parameters.AddWithValue("@clientid", drpname.SelectedValue);
                    cmd.Parameters.AddWithValue("@itemid", grdtest1.Rows[i].Cells["itemid"].Value.ToString());
                    cmd.Parameters.AddWithValue("@price", grdtest1.Rows[i].Cells["rate"].Value.ToString());
                    cmd.Parameters.AddWithValue("@chalandate", data.getDateMMDDYYYY(dateTimePicker1.Text));
                    cmd.Parameters.AddWithValue("@qty", grdtest1.Rows[i].Cells["qty"].Value.ToString());
                    cmd.Parameters.AddWithValue("@amount", grdtest1.Rows[i].Cells["amount"].Value.ToString());
                    cmd.Parameters.AddWithValue("@firmid", Data.id);
                    cmd.Parameters.AddWithValue("@ravanano", grdtest1.Rows[i].Cells["ravanno"].Value.ToString());
                    cmd.Parameters.AddWithValue("@sessionid", Data.sessionid);
                    data.executeCommand(cmd);
                    cmd.Parameters.Clear();
                }
            }
            clear();
        }
        private void lst_Click(object sender, EventArgs e)
        {
            fillclk();
        }
        public void fillclk()
        {
            string query1;
            txttotal.Text = "0";
            DataSet ds1 = new DataSet();
            query1 = "SELECT tblclient.Name, tblitem.itemname, chalandetail.ravanano, chalandetail.price, chalandetail.qty, chalandetail.amount, chalandetail.chalandate, chalandetail.chalanno, chalandetail.itemid, tblchalan.totalamt, tbllabour.labourname";
            query1 += " FROM (((tblclient INNER JOIN chalandetail ON tblclient.id = chalandetail.clientid) INNER JOIN tblitem ON chalandetail.itemid = tblitem.itemid) INNER JOIN tblchalan ON (chalandetail.chalanno = tblchalan.chalanno) AND (tblclient.firmid = tblchalan.firmid)) INNER JOIN tbllabour ON tblchalan.lbrid = tbllabour.lbrid";
            query1 += " where chalandetail.chalanno=" + lst.SelectedValue + " and chalandetail.firmid=" + Data.id + " and tblchalan.sessionid=" + Data.sessionid + " and chalandetail.sessionid=" + Data.sessionid + "";
            ds1 = data.getDataSet(query1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                grdtest1.Rows.Clear();
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    drplbr.Text = ds1.Tables[0].Rows[i]["labourname"].ToString();
                    txtchalanno.Text = ds1.Tables[0].Rows[i]["chalanno"].ToString();
                    drpname.Text = ds1.Tables[0].Rows[i]["name"].ToString();
                    dateTimePicker1.Text = ds1.Tables[0].Rows[0]["chalandate"].ToString();
                    txttotal.Text = ds1.Tables[0].Rows[0]["totalamt"].ToString();
                    grdtest1.Rows.Add();
                    grdtest1.Rows[i].Cells["sno"].Value = grdtest1.Rows.Count;
                    grdtest1.Rows[i].Cells["itemid"].Value = ds1.Tables[0].Rows[i]["itemid"].ToString();
                    grdtest1.Rows[i].Cells["Item"].Value = ds1.Tables[0].Rows[i]["itemname"].ToString();
                    grdtest1.Rows[i].Cells["rate"].Value = ds1.Tables[0].Rows[i]["price"].ToString();
                    grdtest1.Rows[i].Cells["ravanno"].Value = ds1.Tables[0].Rows[i]["ravanano"].ToString();
                    grdtest1.Rows[i].Cells["qty"].Value = ds1.Tables[0].Rows[i]["qty"].ToString();
                    grdtest1.Rows[i].Cells["amount"].Value = ds1.Tables[0].Rows[i]["amount"].ToString();
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
            drpitem.SelectedIndex = 0;
            txtravanno.Text = "";
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
                query = " delete from chalandetail where firmid=" + Data.id + " and chalanno =" + lst.SelectedValue + " and sessionid=" + Data.sessionid + " ";
                data.executeCommand(query);
                query = " delete from tblchalan where firmid=" + Data.id + " and chalanno=" + lst.SelectedValue + " and sessionid=" + Data.sessionid + " ";
                data.executeCommand(query);
                clear();
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                query = "SELECT tblclient.Name + '- '+ Convert(char(7),tblchalan.chalanno) as name,tblchalan.chalanno as chano FROM tblchalan INNER JOIN tblclient ON tblchalan.clientid = tblclient.id  where tblclient.firmid=" + Data.id + "";
                query += " and tblchalan.chalanno Like '" + textBox1.Text.Trim() + "%' and tblchalan.sessionid=" + Data.sessionid + " and BillConf=0";
                query += " order by tblchalan.chalanno ";
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
    }
}
