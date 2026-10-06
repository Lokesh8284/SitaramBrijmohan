using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace WelcomeFabric
{
    public partial class Vechicle : Form
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
        string sno2;
        public Vechicle()
        {
            InitializeComponent();
        }
        private void PriceLst_Load(object sender, EventArgs e)
        {
            partyname();
            filllst();
            maxsno();
            if (maskedTextBox1.MaskFull)
            {
            }

        }
        public void maxsno()
        {
            query = " select max(priceno) as sno from clientprice";
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
                txtsno.Text = Convert.ToString(max1);
            }
            dr.Close();
        }
        public void filllst()
        {
            //  query = " SELECT DISTINCT  tbl_Vehicle.clientname,tblclient.Name,tblclient.Id ";
            //query += "  FROM (tbl_Vehicle INNER JOIN tblclient ON tbl_Vehicle.clientid = tblclient.id)  where tblclient.firmid=" + Data.id + "";
            // query = " select * from tbl_Transport where firmid=" + Data.id + " order by TransportName";
            query = " SELECT DISTINCT clientname,clientid from tbl_Vehicle where firmid=" + Data.id + "";
            ds = data.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lst.DataSource = ds.Tables[0];
                lst.DisplayMember = "clientname";
                lst.ValueMember = "clientid";
            }
            else
            {
                lst.DataSource = null;
            }
        }
        public void partyname()
        {
            query = " select * from tbl_Transport where rowstatus=0 and firmid=" + Data.id + " order by TransportName";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["lbrid"] = "0";
            newrow["TransportName"] = "---Select Transporter ----";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            drpparty.DataSource = ds.Tables[0];
            drpparty.DisplayMember = "TransportName";
            drpparty.ValueMember = "lbrid";
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

            if (btnadd.Text == "Add")
            {
                grdtest1.Rows.Add();
                curr = grdtest1.Rows.Count - 1;
                int dd = curr + 1;
                grdtest1.Rows[curr].Cells["sn"].Value = dd;
                grdtest1.Rows[curr].Cells["id"].Value = drpparty.SelectedValue;
                grdtest1.Rows[curr].Cells["name"].Value = drpparty.Text;
                grdtest1.Rows[curr].Cells["VehicleNo"].Value = txtVehicleNo.Text;
                grdtest1.Rows[curr].Cells["Edit1"].Value = "Edit";
                grdtest1.Rows[curr].Cells["del"].Value = "Delete";
                txtVehicleNo.Text = "";
                txtVehicleNo.Focus();
            }
            else
            {
                int dd = currow + 1;
                grdtest1.Rows[currow].Cells["sn"].Value = dd;
                grdtest1.Rows[currow].Cells["id"].Value = drpparty.SelectedValue;
                grdtest1.Rows[currow].Cells["name"].Value = drpparty.Text;
                grdtest1.Rows[currow].Cells["VehicleNo"].Value = txtVehicleNo.Text;
                grdtest1.Rows[currow].Cells["Edit1"].Value = "Edit";
                grdtest1.Rows[currow].Cells["del"].Value = "Delete";
                txtVehicleNo.Text = "";
                txtVehicleNo.Focus();
            }

        }
        private void grdtest1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            currow = e.RowIndex;
            try
            {
                if (grdtest1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Edit")
                {
                    currow = e.RowIndex;
                    drpparty.Text = grdtest1.Rows[e.RowIndex].Cells["name"].Value.ToString();
                    txtVehicleNo.Text = grdtest1.Rows[e.RowIndex].Cells["VehicleNo"].Value.ToString();
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
            txtVehicleNo.Text = "";
            btnadd.Text = "Add";
            drpparty.SelectedIndex = 0;
            btnsave.Text = "Save";
            drpparty.Focus();
            filllst();
            maxsno();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            save();
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
                    query = " insert into tbl_Vehicle (clientid,clientName,firmid,sessionid,VehicleNo) values(@clientid,@clientName,@firmid,@sessionid,@VehicleNo)";
                    cmd.CommandText = query;
                    for (int i = 0; i < grdtest1.Rows.Count; i++)
                    {
                        cmd.Parameters.AddWithValue("@clientid", grdtest1.Rows[i].Cells["id"].Value.ToString());
                        cmd.Parameters.AddWithValue("@clientName", grdtest1.Rows[i].Cells["name"].Value.ToString());
                        cmd.Parameters.AddWithValue("@VehicleNo", grdtest1.Rows[i].Cells["VehicleNo"].Value.ToString());
                        cmd.Parameters.AddWithValue("@firmid", Data.id);
                        cmd.Parameters.AddWithValue("@sessionid", Data.sessionid);
                        data.executeCommand(cmd);
                        cmd.Parameters.Clear();
                    }
                }
                else
                {
                    query = " delete from tbl_Vehicle where  firmid=" + Data.id + " and clientid=" + lst.SelectedValue + " ";
                    data.executeCommand(query);
                    query = " insert into tbl_Vehicle (clientid,clientName,firmid,sessionid,VehicleNo) values(@clientid,@clientName,@firmid,@sessionid,@VehicleNo)";
                    cmd.CommandText = query;
                    for (int i = 0; i < grdtest1.Rows.Count; i++)
                    {
                        cmd.Parameters.AddWithValue("@clientid", grdtest1.Rows[i].Cells["id"].Value.ToString());
                        cmd.Parameters.AddWithValue("@clientName", grdtest1.Rows[i].Cells["name"].Value.ToString());
                        cmd.Parameters.AddWithValue("@VehicleNo", grdtest1.Rows[i].Cells["VehicleNo"].Value.ToString());
                        cmd.Parameters.AddWithValue("@firmid", Data.id);
                        cmd.Parameters.AddWithValue("@sessionid", Data.sessionid);
                        data.executeCommand(cmd);
                        cmd.Parameters.Clear();
                    }
                    #region Comment Update
                    //query = "update tbl_Vehicle set clientid=@clientid,clientName=@clientName,firmid=@firmid,sessionid=@sessionid,VehicleNo=@VehicleNo where clientid=" + lst.SelectedValue + " ";
                    //cmd.CommandText = query;
                    //for (int i = 0; i < grdtest1.Rows.Count; i++)
                    //{
                    //    cmd.Parameters.AddWithValue("@clientid", grdtest1.Rows[i].Cells["id"].Value.ToString());
                    //    cmd.Parameters.AddWithValue("@clientName", grdtest1.Rows[i].Cells["name"].Value.ToString());
                    //    cmd.Parameters.AddWithValue("@VehicleNo", grdtest1.Rows[i].Cells["VehicleNo"].Value.ToString());
                    //    cmd.Parameters.AddWithValue("@firmid", Data.id);
                    //    cmd.Parameters.AddWithValue("@sessionid", Data.sessionid);
                    //    data.executeCommand(cmd);
                    //    cmd.Parameters.Clear();
                    //}
                    #endregion
                }
            }
            MessageBox.Show("Record Save Sussessfully");
            clear();
        }
        private void lst_Click(object sender, EventArgs e)
        {
            if (lst.SelectedValue != null)
            {
                query = " SELECT DISTINCT tbl_Vehicle.VehicleNo, tbl_Transport.lbrid,tbl_Transport.TransportName ";
                query += "  FROM (tbl_Vehicle INNER JOIN tbl_Transport ON tbl_Vehicle.clientid = tbl_Transport.lbrid) ";
                query += "  where tbl_Transport.lbrid=" + lst.SelectedValue + "";
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
                        grdtest1.Rows[i].Cells["id"].Value = ds.Tables[0].Rows[i]["lbrid"].ToString();
                        grdtest1.Rows[i].Cells["name"].Value = ds.Tables[0].Rows[i]["TransportName"].ToString();
                        grdtest1.Rows[i].Cells["VehicleNo"].Value = ds.Tables[0].Rows[i]["VehicleNo"].ToString();
                        grdtest1.Rows[i].Cells["Edit1"].Value = "Edit";
                        grdtest1.Rows[i].Cells["del"].Value = "Delete";
                    }
                    btnsave.Text = "Update";
                }
            }
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

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Regex.IsMatch(maskedTextBox1.Text, @"\d{2}/\d{2}/\d{4}"))
            {
                MessageBox.Show("Please enter letters only");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string _search = "%";
            if (txtSearch.Text.Trim() != "")
            {
                _search = txtSearch.Text.Trim();
            }
            query = " SELECT DISTINCT clientname,clientid from tbl_Vehicle where firmid=" + Data.id
                + " and ClientName like '" + _search + "%'";
            ds = data.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lst.DataSource = ds.Tables[0];
                lst.DisplayMember = "clientname";
                lst.ValueMember = "clientid";
            }
            else
            {
                lst.DataSource = null;
            }
        }

    }
}