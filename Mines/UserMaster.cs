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
    public partial class UserMaster : Form
    {
        Data data = new Data();
        string Query = "";
        SqlCommand cmd = new SqlCommand();
        public UserMaster()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void reset()
        {
            txtAddress.Text = txtMobile.Text = txtPartyName.Text = "";
            lblUserId.Text = "0";
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
            checkBox1.Checked = false;
            label5.Visible = false;
            checkedListBox1.Visible = false;
            FillList();
            fillunit();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
            txtPartyName.Focus();
        }

        private void fillunit()
        {
            Query = " select * from tblUnit where delid=0 order by UnitName asc";
            DataSet ds = data.getDataSet(Query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                checkedListBox1.DataSource = ds.Tables[0];
                checkedListBox1.DisplayMember = "UnitName";
                checkedListBox1.ValueMember = "UnitId";
            }
        }

        private void FillList()
        {
            DataSet dss = data.getDataSet("select * from tblclient where Delid=0 and IsUser=1 and firmid=" + Data.id);
            lst.DataSource = dss.Tables[0];
            lst.DisplayMember = "Name";
            lst.ValueMember = "Id";
        }

        private void UserMaster_Load(object sender, EventArgs e)
        {
            reset();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPartyName.Text.Trim() == "")
                {
                    MessageBox.Show("Name Must Be Enter");
                    txtPartyName.Focus();
                    return;
                }
                if (txtMobile.Text.Trim() == "")
                {
                    MessageBox.Show("MObile No Must Be Enter");
                    txtMobile.Focus();
                    return;
                }
                //if (txtAddress.Text.Trim() == "")
                //{
                //    MessageBox.Show("Address Must Be Enter");
                //    txtAddress.Focus();
                //    return;
                //}
                List<int> selectedIds = new List<int>();

                foreach (DataRowView item in checkedListBox1.CheckedItems)
                {
                    int id = Convert.ToInt32(item["UnitId"]);
                    selectedIds.Add(id);
                }

                string ids = string.Join(",", selectedIds.Select(x => x.ToString()).ToArray());
                if (data.Exist("Select * from tblclient where Delid=0 and FIrmId='" + Data.id + "' and Mob='" + txtMobile.Text.Trim() + "' and Id!=" + lblUserId.Text))
                {
                    MessageBox.Show("Party Already Exist");
                    txtMobile.Focus();
                    return;
                }
                if (ids == "")
                {
                    MessageBox.Show("must be select Unit");
                    txtMobile.Focus();
                    return;
                }
                
                if (btnSave.Text == "Save")
                {
                    Query = "INSERT INTO [tblclient]([Name],[compname],[Mob],[Address],[firmid],[IsUser],[UnitID],[IsStaff])";
                    Query += " Values ('" + txtPartyName.Text.Trim() + "','" + txtPartyName.Text.Trim() + "','" + txtMobile.Text.Trim() + "','" + txtAddress.Text.Trim() + "','" + Data.id + "','1','" + ids + "','" + checkBox1.Checked + "')";
                }
                else
                {
                    Query = "Update [tblclient] set [Mob]='" + txtMobile.Text.Trim() + "',[Address]='" + txtAddress.Text.Trim() + "',[Name]='" + txtPartyName.Text.Trim() + "',[compname]='" + txtPartyName.Text.Trim() + "',[firmid]='" + Data.id + "',[UnitID]='" + ids + "',[IsStaff]='" + checkBox1.Checked + "' where Id='" + lblUserId.Text.Trim() + "'";
                }
                cmd.CommandText = Query;
                data.executeCommand(cmd);
                MessageBox.Show("Record '" + btnSave.Text + "' Successfully");
                reset();
            }
            catch
            {
                MessageBox.Show("Error in '" + btnSave.Text + "' Data..");
                return;
            }
        }

        private void SetSelectedValues(string selectedIds)
        {
            string[] ids = selectedIds.Split(',');

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                DataRowView row = checkedListBox1.Items[i] as DataRowView;

                if (row != null)
                {
                    string id = row["UnitID"].ToString();

                    if (ids.Contains(id))
                    {
                        checkedListBox1.SetItemChecked(i, true);
                    }
                    else
                    {
                        checkedListBox1.SetItemChecked(i, false);
                    }
                }
            }
        }
        private void lst_Click(object sender, EventArgs e)
        {
            try
            {
                if (lst.SelectedIndex >= 0)
                {
                    DataTable dt = data.GetDataTable("Select * from tblclient where Delid=0 and Id=" + lst.SelectedValue);
                    txtPartyName.Text = dt.Rows[0]["Name"].ToString();
                    txtMobile.Text = dt.Rows[0]["Mob"].ToString();
                    txtAddress.Text = dt.Rows[0]["Address"].ToString();
                    lblUserId.Text = dt.Rows[0]["Id"].ToString();
                    SetSelectedValues(dt.Rows[0]["UnitID"].ToString());
                    checkBox1.Checked = Convert.ToBoolean(dt.Rows[0]["IsStaff"]);
                    btnSave.Text = "Update";
                    btnDelete.Enabled = true;
                }
            }
            catch
            {
                MessageBox.Show("Error in fetch Data..");
                return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Enabled)
            {
                if (MessageBox.Show("Do You want to delete this record", "Delete_Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    data.executeCommand("delete from tblclient where Id=" + lblUserId.Text);
                    MessageBox.Show("Record delete successfully");
                    reset();
                }
            }
        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ch = (int)e.KeyChar;
            if ((ch < 48 || ch > 58) && (ch != 8) && (ch != 46))
                e.KeyChar = '\0';
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                label5.Visible = true;
                checkedListBox1.Visible = true;
            }
            else
            {
                label5.Visible = false;
                checkedListBox1.Visible = false;
            }
        }
    }
}
