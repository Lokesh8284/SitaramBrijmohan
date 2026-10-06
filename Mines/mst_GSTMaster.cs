using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WelcomeFabric
{
    public partial class mst_GSTMaster : Form
    {
        Data data = new Data();
        DataSet ds = new DataSet();
        //clsDefaultMode valid = new clsDefaultMode();
        public mst_GSTMaster()
        {
            InitializeComponent();
        }

        private void mst_YaanType_Load(object sender, EventArgs e)
        {
            ClearData();
        }

        private void mst_YaanType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                this.ProcessTabKey(true);
            }
            if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }
            if (e.Control == true)
            {
                if (e.KeyCode == Keys.S)
                {
                    Save_Data();
                }
                else if (e.KeyCode == Keys.R)
                {
                    ClearData();
                }
                else if (e.KeyCode == Keys.D)
                {
                    Delete_Data();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save_Data();
        }

        public void Save_Data()
        {
            string query = "";
            if (txtGSTName.Text == "")
            {
                MessageBox.Show("GST Name Must Be Entered");
                txtGSTName.Focus();
                return;
            }
            if (txtGSTValue.Text == "")
            {
                MessageBox.Show("GST Value Must Be Entered");
                txtGSTValue.Focus();
                return;
            }
            if (btnSave.Text == "Save")
            {
                query = "sp_InsertGST";
            }
            else
            {
                query = "sp_UpdateGST";
            }
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@GSTName", txtGSTName.Text);
            cmd.Parameters.AddWithValue("@GSTValue", txtGSTValue.Text);
            cmd.Parameters.AddWithValue("@Remarks", txtDescription.Text); 
            if (btnSave.Text == "Update")
            {
                cmd.Parameters.AddWithValue("@id", lst.SelectedValue);
            }
            if (data.executeCommand(cmd) == 0)
            {
                MessageBox.Show(btnSave.Text + " Data Successfully");
                ClearData();
            }
        }

        public void ClearData()
        {
            FillList();
            txtGSTName.Text = txtGSTValue.Text = "";
            txtDescription.Text = "";
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
            lst.SelectedIndex = -1;
            this.ActiveControl = txtGSTName;
        }

        public void FillList()
        {
            ds = data.getDataSet("sp_ViewGST 0");
            lst.DataSource = ds.Tables[0];
            lst.ValueMember = "GST_Id";
            lst.DisplayMember = "GSTName";
        }

        public void Delete_Data()
        {
            if (btnDelete.Enabled)
            {
                string query = "";
                if (MessageBox.Show("Do you really want to Delete Data ?", "Ask", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    query = "sp_DeleteGST " + lst.SelectedValue + " ";
                    if (data.executeCommand(query) == 0)
                    {
                        MessageBox.Show("Data Delete successfully");
                        ClearData();
                    }
                    else
                    {
                        MessageBox.Show("Data Not Delete successfully");
                        return;
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete_Data();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lst_Click(object sender, EventArgs e)
        {
            if (lst.SelectedIndex >= 0)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    ds = data.getDataSet("sp_ViewGST " + lst.SelectedValue);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtGSTName.Text = ds.Tables[0].Rows[0]["GSTName"].ToString();
                        txtGSTValue.Text = ds.Tables[0].Rows[0]["GSTValue"].ToString();
                        txtDescription.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                    }
                    btnSave.Text = "Update";
                    btnDelete.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("Error in Load Data..", "!!Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void txtGSTValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ch = (int)e.KeyChar;
            if ((ch < 48 || ch > 58) && (ch != 8) && (ch != 46))
                e.KeyChar = '\0';
        }
    }
}
