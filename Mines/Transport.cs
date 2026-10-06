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
    public partial class Transport : Form
    {
        Data data = new Data();
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        string query;
        public Transport()
        {
            InitializeComponent();
        }
        private void LabourMaster_Load(object sender, EventArgs e)
        {
            clear();
            filllst();
            //dtpTDS.SelectedIndex = 0;
        }
        public void filllst()
        {
            //query = " select * from tbl_Transport where rowstatus=0 and firmid=" + Data.id + "";
            query = " select * from tbl_Transport where rowstatus=0 ";
            ds = data.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lst.DataSource = ds.Tables[0];
                lst.DisplayMember = "TransportName";
                lst.ValueMember = "lbrid";
            }
            else
            {
                lst.DataSource = null;
            }
        }
        public void delete()
        {
            if (btnDelete.Enabled == true)
            {
                if (MessageBox.Show("Do you want Delete Record Press 'Yes' otherwise 'No", "Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    query = "update tbl_Transport set Rowstatus=1 where  lbrid =" + lst.SelectedValue + " and firmid=" + Data.id + "";
                    data.executeCommand(query);
                    filllst();
                    clear();
                }
            }
        }
        public void clear()
        {
            txtName.Text = "";
            txtContactPerson.Text = "";
            chkIsRowMaterial.Checked = false;
            txtPhoneNo.Text = "";
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
            txtName.Focus();
        }
        public void save()
        {
            cmd.Parameters.Clear();
            if (txtName.Text == "")
            {
                MessageBox.Show("Name must be entered");
                txtName.Focus();
                return;
            }
            if (btnSave.Text == "Save")
            {
                query = " insert into tbl_Transport(TransportName,ContactPerson,PhoneNo,firmid,IsRowMaterial) values(@TransportName,@ContactPerson,@PhoneNo,@firmid,@IsRowMaterial)";
            }
            else
            {
                query = " update tbl_Transport set TransportName=@TransportName,ContactPerson=@ContactPerson,PhoneNo=@PhoneNo,firmid=@firmid,IsRowMaterial=@IsRowMaterial where lbrid=" + lst.SelectedValue + " and firmid=" + Data.id + "";
            }
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@TransportName", txtName.Text);
            cmd.Parameters.AddWithValue("@ContactPerson", txtContactPerson.Text);
            cmd.Parameters.AddWithValue("@PhoneNo", txtPhoneNo.Text);
            cmd.Parameters.AddWithValue("@firmid", Data.id);
            if (chkIsRowMaterial.Checked == true)
            {
                cmd.Parameters.AddWithValue("@IsRowMaterial", "1");
            }
            else
            {
                cmd.Parameters.AddWithValue("@IsRowMaterial", "0");
            }
            data.executeCommand(cmd);
            cmd.Parameters.Clear();
            MessageBox.Show(btnSave.Text + " Record SuccessFully !!!");
            filllst();
            clear();


        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            delete();
        }
        private void lst_Click(object sender, EventArgs e)
        {
            click();
        }
        public void click()
        {
            try
            {
                if (lst.SelectedValue != null)
                {
                    query = " select * from tbl_Transport where lbrid =" + lst.SelectedValue + "";
                    dr = data.getDataReader(query);
                    if (dr.Read())
                    {
                        btnDelete.Enabled = true;
                        txtName.Text = dr["TransportName"].ToString();
                        txtContactPerson.Text = dr["ContactPerson"].ToString();
                        txtPhoneNo.Text = dr["PhoneNo"].ToString();

                        if (dr["IsRowMaterial"].ToString() == "True")
                        {
                            chkIsRowMaterial.Checked = true;
                        }
                        else
                        {
                            chkIsRowMaterial.Checked = false;
                        }
                        btnSave.Text = "Update";
                        btnDelete.Enabled = true;
                    }
                    dr.Close();
                }
            }
            catch
            { }
        }
        private void txtName_KeyDown(object sender, KeyEventArgs e)
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
                else if (e.KeyCode == Keys.C)
                {
                    // clearAll();
                }
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
    }
}