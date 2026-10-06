using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WelcomeFabric
{
    public partial class UnitMaster : Form
    {
        SqlCommand cmd = new SqlCommand();
        Data data = new Data();
        DataSet ds = new DataSet();
        string query;
        public UnitMaster()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }

        private void save()
        {
            if (txtUnitName.Text == "")
            {
                MessageBox.Show("Enter Unit Name");
                txtUnitName.Focus();
                return;
            }

            if (btnSave.Text == "Save")
            {
                query = "insert into tblUnit(UnitName,Description,wages,IsActive) values (@UnitName,@Description,@wages, @IsActive)";
            }
            else
            {
                query = "update tblUnit set UnitName=@UnitName,Description=@Description, wages=@wages, IsActive=@IsActive where UnitId=" + lst.SelectedValue;
            }
            cmd.CommandText = query;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@UnitName", txtUnitName.Text);
            cmd.Parameters.AddWithValue("@wages", txtWages.Text);
            cmd.Parameters.AddWithValue("@Description", txtUnitDescription.Text);
            cmd.Parameters.AddWithValue("@IsActive", checkBox1.Checked);
            data.executeCommand(cmd);
            filllst();
            clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void clear()
        {
            txtWages.Text = "0";
            txtUnitDescription.Text = "";
            txtUnitName.Text = "";
            btnSave.Text = "Save";
            checkBox1.Checked = false;
            filllst();
            btnDelete.Enabled = false;
        }

        private void UnitMaster_Load(object sender, EventArgs e)
        {
            clear();
        }

        public void filllst()
        {
            query = " select * from tblUnit where delid=0 order by UnitName asc";
            ds = data.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lst.DataSource = ds.Tables[0];
                lst.DisplayMember = "UnitName";
                lst.ValueMember = "UnitId";
            }
            else
            {
                lst.DataSource = null;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lst_Click(object sender, EventArgs e)
        {
            query = "select * from tblUnit where UnitId=" + lst.SelectedValue;
            ds = data.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtUnitName.Text = ds.Tables[0].Rows[0]["UnitName"].ToString();
                txtWages.Text = ds.Tables[0].Rows[0]["Wages"].ToString();
                txtUnitDescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();
                checkBox1.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsActive"]);
                btnSave.Text = "Update";
                btnDelete.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            query = "update tblUnit set delid=1 where UnitId=" + lst.SelectedValue;
            data.executeCommand(query);
            filllst();
            clear();
        }

        private void txtWages_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ch = (int)e.KeyChar;
            if ((ch < 48 || ch > 58) && (ch != 8) && (ch != 46))
                e.KeyChar = '\0';
        }
    }
}
