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
    public partial class PriceLst : Form
    {
        Data data = new Data();
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        string query;
        int Client_id = 0;
        int curr = 0;
        int currow = 0;
        int max = 0;
        int max1 = 0;
        string sno2;
        public PriceLst()
        {
            InitializeComponent();
        }
        private void PriceLst_Load(object sender, EventArgs e)
        {
            partyname();
            itemname();
            filllst();
            maxsno();
            drpUnit();
            dtpUnit.SelectedIndex = 0;
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
        public void maxsno()
        {
            query = " select max(priceno) as sno from clientprice Where firmid =" + Data.id + "";
            dr = data.getDataReader(query);
            if (dr.Read())
            {
                string id = dr["sno"].ToString();
                if (id == "")
                {
                    Client_id = 1;
                    txtsno.Text = Convert.ToString(Client_id);
                }
                else
                {
                    int maxid = Convert.ToInt32(dr["sno"].ToString());
                    Client_id = maxid + 1;
                    txtsno.Text = Convert.ToString(Client_id);
                }
                dr.Close();
            }
            else
            {
                dr.Close();
            }
        }
        public void filllst()
        {
            query = " SELECT DISTINCT clientprice.priceno, tblclient.Name";
            query += "   FROM (clientprice INNER JOIN tblclient ON clientprice.clientid = tblclient.id) INNER JOIN tblprice ON (clientprice.priceno = tblprice.sno) AND (tblclient.id = tblprice.clientid) where tblclient.firmid=" + Data.id + "";
            ds = data.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lst.DataSource = ds.Tables[0];
                lst.DisplayMember = "Name";
                lst.ValueMember = "priceno";
            }
            else
            {
                lst.DataSource = null;
            }
        }
        public void partyname()
        {
            query = " select * from tblclient where firmid=" + Data.id + " order by name";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["id"] = "0";
            newrow["compname"] = "---Select Party Name----";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            drpparty.DataSource = ds.Tables[0];
            drpparty.DisplayMember = "compname";
            drpparty.ValueMember = "id";
        }
        public void itemname()
        {
            query = " select * from tblitem  where firmid=" + Data.id + " order by itemname";

            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["itemid"] = "0";
            newrow["itemname"] = "Select Item Name";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            drpitem.DataSource = ds.Tables[0];
            drpitem.DisplayMember = "itemname";
            drpitem.ValueMember = "itemid"; 
            
            
            //ds = data.getDataSet(query);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    drpitem.DataSource = ds.Tables[0];
            //    drpitem.DisplayMember = "itemname";
            //    drpitem.ValueMember = "itemid";
            //}
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Add();
        }
        public void Add()
        {
            if (drpparty.SelectedIndex == 0)
            {
                MessageBox.Show("Party Name Must be selected");
                drpparty.Focus();
                return;
            }
            double rat = Convert.ToDouble(txtrate.Text);
            if (rat == 0)
            {
                MessageBox.Show("Rate Must be Entered");
                txtrate.Focus();
                return;
            }
            if (btnadd.Text == "Add")
            {
                grdtest1.Rows.Add();
                curr = grdtest1.Rows.Count - 1;
                int dd = curr + 1;
                grdtest1.Rows[curr].Cells["sn"].Value = dd;
                grdtest1.Rows[curr].Cells["id"].Value = drpparty.SelectedValue;
                grdtest1.Rows[curr].Cells["name"].Value = drpparty.Text;
                grdtest1.Rows[curr].Cells["itemid"].Value = drpitem.SelectedValue;
                grdtest1.Rows[curr].Cells["Item"].Value = drpitem.Text;
                grdtest1.Rows[curr].Cells["rate"].Value = txtrate.Text;
                grdtest1.Rows[curr].Cells["Unit"].Value = dtpUnit.Text;
                grdtest1.Rows[curr].Cells["Edit1"].Value = "Edit";
                grdtest1.Rows[curr].Cells["del"].Value = "Delete";
            }
            else
            {
                int dd = currow + 1;
                grdtest1.Rows[currow].Cells["sn"].Value = dd;
                grdtest1.Rows[currow].Cells["id"].Value = drpparty.SelectedValue;
                grdtest1.Rows[currow].Cells["name"].Value = drpparty.Text;
                grdtest1.Rows[currow].Cells["itemid"].Value = drpitem.SelectedValue;
                grdtest1.Rows[currow].Cells["Item"].Value = drpitem.Text;
                grdtest1.Rows[curr].Cells["Unit"].Value = dtpUnit.Text;
                grdtest1.Rows[currow].Cells["rate"].Value = txtrate.Text;
                grdtest1.Rows[currow].Cells["Edit1"].Value = "Edit";
                grdtest1.Rows[currow].Cells["del"].Value = "Delete";
            }
            drpitem.Focus();
           // clear();
            txtrate.Text = "0";
        }
        private void grdtest1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            currow = e.RowIndex;
            try
            {
                if (grdtest1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Edit")
                {
                    drpparty.Text = grdtest1.Rows[e.RowIndex].Cells["name"].Value.ToString();
                    drpitem.Text = grdtest1.Rows[e.RowIndex].Cells["Item"].Value.ToString();
                    txtrate.Text = grdtest1.Rows[e.RowIndex].Cells["rate"].Value.ToString();
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
        private void txtrate_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ch = (int)e.KeyChar;
            if ((ch < 48 || ch > 58) && (ch != 8) && (ch != 46))
                e.KeyChar = '\0';
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            clear();
        }
        public void clear()
        {
            grdtest1.Rows.Clear();
            drpitem.SelectedIndex = 0;
            drpparty.SelectedIndex = 0;
            dtpUnit.SelectedIndex = 0;
            txtrate.Text = "0.00";
            btnsave.Text = "Save";
            drpparty.Focus();
            filllst();
            maxsno();
        }

        public void save()
        {
            if (grdtest1.Rows.Count == 0)
            {
                MessageBox.Show("Entry Must be enterd");
            }
            else
            {
                if (btnsave.Text == "Save")
                {
                    query = " insert into clientprice (clientid,itemid,rate,priceno,firmid,sessionid,Unit,maxid) values(@clientid,@itemid,@rate,@priceno,@firmid,@sessionid,@Unit,@maxid)";
                    cmd.CommandText = query;
                    for (int i = 0; i < grdtest1.Rows.Count; i++)
                    {
                        cmd.Parameters.AddWithValue("@clientid", grdtest1.Rows[i].Cells["id"].Value.ToString());
                        cmd.Parameters.AddWithValue("@itemid", grdtest1.Rows[i].Cells["itemid"].Value.ToString());
                        cmd.Parameters.AddWithValue("@rate", grdtest1.Rows[i].Cells["rate"].Value.ToString());
                        cmd.Parameters.AddWithValue("@Unit", grdtest1.Rows[i].Cells["Unit"].Value.ToString());
                        cmd.Parameters.AddWithValue("@maxid", txtsno.Text);
                        //cmd.Parameters.AddWithValue("@CGST", grdtest1.Rows[i].Cells["CGST"].Value.ToString());
                        //cmd.Parameters.AddWithValue("@SGST", grdtest1.Rows[i].Cells["SGST"].Value.ToString());
                        //cmd.Parameters.AddWithValue("@IGST", grdtest1.Rows[i].Cells["IGST"].Value.ToString());
                        cmd.Parameters.AddWithValue("@priceno", txtsno.Text);
                        cmd.Parameters.AddWithValue("@firmid", Data.id);
                        cmd.Parameters.AddWithValue("@sessionid", Data.sessionid);
                        data.executeCommand(cmd);
                        cmd.Parameters.Clear();
                    }
                }
                else
                {
                    query = " delete from clientprice where firmid=" + Data.id + " and  priceno=" + txtsno.Text + "";
                    data.executeCommand(query);
                    query = " delete from tblprice where sno=" + txtsno.Text + "";
                    data.executeCommand(query);
                    query = " insert into clientprice (clientid,itemid,rate,priceno,firmid,sessionid,Unit,maxid) values(@clientid,@itemid,@rate,@priceno,@firmid,@sessionid,@Unit,@maxid)";
                    cmd.CommandText = query;
                    for (int i = 0; i < grdtest1.Rows.Count; i++)
                    {
                        cmd.Parameters.AddWithValue("@clientid", grdtest1.Rows[i].Cells["id"].Value.ToString());
                        cmd.Parameters.AddWithValue("@itemid", grdtest1.Rows[i].Cells["itemid"].Value.ToString());
                        cmd.Parameters.AddWithValue("@rate", grdtest1.Rows[i].Cells["rate"].Value.ToString());
                        cmd.Parameters.AddWithValue("@Unit", grdtest1.Rows[i].Cells["Unit"].Value.ToString());
                        cmd.Parameters.AddWithValue("@maxid", txtsno.Text);
                        cmd.Parameters.AddWithValue("@priceno", txtsno.Text);
                        cmd.Parameters.AddWithValue("@firmid", Data.id);
                        cmd.Parameters.AddWithValue("@sessionid", Data.sessionid);
                        data.executeCommand(cmd);
                        cmd.Parameters.Clear();
                    }
                }
            }
            query = " select max(priceid)as id from clientprice where sessionid=" + Data.sessionid + "";
            dr = data.getDataReader(query);
            if (dr.Read())
            {
                sno2 = dr["id"].ToString();
            }
            dr.Close();
            query = " insert into tblprice(priceid,clientid,sno,firmid,sessionid,maxid)values(@priceid,@clientid,@sno,@firmid,@sessionid,@maxid) ";
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@priceid", sno2);
            cmd.Parameters.AddWithValue("@clientid", drpparty.SelectedValue);
            cmd.Parameters.AddWithValue("@sno", txtsno.Text);
            cmd.Parameters.AddWithValue("@firmid", Data.id);
            cmd.Parameters.AddWithValue("@sessionid", Data.sessionid);
            cmd.Parameters.AddWithValue("@maxid", txtsno.Text);
            data.executeCommand(cmd);
            MessageBox.Show("Record Save Sussessfully");
            clear();
        }
        private void lst_Click(object sender, EventArgs e)
        {
            if (lst.SelectedValue != null)
            {
                query = " SELECT tblclient.Name,tblclient.id, tblitem.itemname,tblitem.itemid,clientprice.maxid,clientprice.Unit,clientprice.priceno, clientprice.rate,clientprice.priceid";
                query += " FROM tblitem INNER JOIN (tblclient INNER JOIN clientprice ON tblclient.id = clientprice.clientid) ON tblitem.itemid = clientprice.itemid";
                query += " where clientprice.priceno=" + lst.SelectedValue + " and clientprice.firmid=" + Data.id + "";
                //query += "";
                ds = data.getDataSet(query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdtest1.Rows.Clear();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        grdtest1.Rows.Add();
                        curr = grdtest1.Rows.Count - 1;
                        int dd = curr + 1;
                        grdtest1.Rows[curr].Cells["sn"].Value = dd;
                        grdtest1.Rows[i].Cells["id"].Value = ds.Tables[0].Rows[i]["id"].ToString();
                        grdtest1.Rows[i].Cells["name"].Value = ds.Tables[0].Rows[i]["Name"].ToString();
                        grdtest1.Rows[i].Cells["Itemid"].Value = ds.Tables[0].Rows[i]["itemid"].ToString();
                        grdtest1.Rows[i].Cells["Item"].Value = ds.Tables[0].Rows[i]["itemname"].ToString();
                        grdtest1.Rows[i].Cells["rate"].Value = ds.Tables[0].Rows[i]["rate"].ToString();
                        grdtest1.Rows[i].Cells["Unit"].Value = ds.Tables[0].Rows[i]["Unit"].ToString();
                        grdtest1.Rows[i].Cells["Edit1"].Value = "Edit";
                        grdtest1.Rows[i].Cells["del"].Value = "Delete";
                        txtsno.Text = ds.Tables[0].Rows[0]["priceno"].ToString();
                    }
                    btnsave.Text = "Update";
                }
            }
        }
        private void drpitem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                query = " select price from tblitem where itemid=" + drpitem.SelectedValue + "";
                ds = data.getDataSet(query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtrate.Text = ds.Tables[0].Rows[0]["price"].ToString();
                }
                else
                {
                    txtrate.Text = "0";
                }
            }
            catch
            { }
        }
        private void drpparty_KeyDown(object sender, KeyEventArgs e)
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
        private void PriceLst_InputLanguageChanging(object sender, InputLanguageChangingEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            drpitem.SelectedIndex = 0;
            drpparty.SelectedIndex = 0;
            dtpUnit.SelectedIndex = 0;
            txtrate.Text = "0.00";
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            save();
        }
    }
}