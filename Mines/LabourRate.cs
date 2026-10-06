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
    public partial class LabourRate : Form
    {
        Data data = new Data();
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        string query;
        public LabourRate()
        {
            InitializeComponent();
        }

        private void LabourRate_Load(object sender, EventArgs e)
        {
            filllst();
           
            fillStaff();
           clear();
            //dtpStaffName.SelectedIndex = 0;
            //btnDelete.Enabled = false;
            //dtpUnit.SelectedIndex = 0;
            //dtpRateType.SelectedIndex = 0;

        }
        public void fillStaff()
        {
            query = " select * from tbl_labour1 where firmid=" + Data.id + " order by labourname";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["lbrid"] = "0";
            newrow["labourname"] = "---Select Staff Name----";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            dtpStaffName.DataSource = ds.Tables[0];
            dtpStaffName.DisplayMember = "labourname";
            dtpStaffName.ValueMember = "lbrid";

        }
        public void filllst()
        {
            query = " select * from tbllabourrate where firmid=" + Data.id + "";
            ds = data.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lst.DataSource = ds.Tables[0];
                lst.DisplayMember = "StaffName";
                lst.ValueMember = "lblrid";
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
                    query = " delete from tbllabourrate where  lblrid =" + lst.SelectedValue + " and firmid=" + Data.id + "";
                    data.executeCommand(query);
                    filllst();
                    clear();
                }
            }
        }
        public void clear()
        {
            dtpStaffName.SelectedIndex = 0;            
            dtpUnit.SelectedIndex = 0;
            dtpRateType.SelectedIndex = 0;
            txtName.Text = "";
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


                query = " insert into tbllabourrate(labourrate,firmid,StaffId,StaffName,Unit,RateType) values(@labourrate,@firmid,@StaffId,@StaffName,@Unit,@RateType)";

            }
            else
            {
                query = " update tbllabourrate set labourrate=@labourrate,firmid=@firmid,StaffId=@StaffId,StaffName=@StaffName,Unit=@Unit,RateType=@RateType where lblrid=" + lst.SelectedValue + " and firmid=" + Data.id + "";
            }
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@labourrate", txtName.Text);
            cmd.Parameters.AddWithValue("@StaffId", dtpStaffName.SelectedValue);
            cmd.Parameters.AddWithValue("@StaffName", dtpStaffName.Text);
            cmd.Parameters.AddWithValue("@Unit", dtpRateType.Text);
            cmd.Parameters.AddWithValue("@RateType", dtpUnit.Text);

            cmd.Parameters.AddWithValue("@firmid", Data.id);
            data.executeCommand(cmd);
            cmd.Parameters.Clear();
            filllst();
            clear();

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
                    query = " select * from tbllabourrate where lblrid =" + lst.SelectedValue + "";
                    dr = data.getDataReader(query);
                    if (dr.Read())
                    {
                        txtName.Text = dr["labourrate"].ToString();
                        dtpStaffName.Text = dr["StaffName"].ToString();
                        dtpUnit.Text = dr["RateType"].ToString();
                        dtpRateType.Text = dr["Unit"].ToString();

                        btnSave.Text = "Update";
                        btnDelete.Enabled = true;
                    }
                    dr.Close();
                }
            }
            catch
            { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            delete();
        }
    }
}