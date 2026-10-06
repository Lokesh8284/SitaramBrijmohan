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
    public partial class LabourMaster1 : Form
    {
        Data data = new Data();
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        string query;
        public LabourMaster1()
        {
            InitializeComponent();
        } 

        private void LabourMaster_Load(object sender, EventArgs e)
        {
            filllst();
            dtpTDS.SelectedIndex = 0;
        }

        public void filllst()
        {
            query = " select * from tbl_labour1 where firmid=" + Data.id + "";
            ds = data.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lst.DataSource = ds.Tables[0];
                lst.DisplayMember = "labourname";
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
                    query = " delete from tbl_labour1 where  lbrid =" + lst.SelectedValue + " and firmid=" + Data.id + "";
                    data.executeCommand(query);
                    filllst();
                    clear();
                }
            }
        }

        public void clear()
        {
            txtdes.Text = "";
            txtName.Text = "";
            txtprice.Text = "";
            txtAcName.Text = "";
            txtAcNo.Text = "";
            txtBankNAme.Text = "";
            txtBranchName.Text = "";
            txtIfscCode.Text = "";
            txtPanNo.Text = "";
            dtpTDS.SelectedIndex = 0;
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
                query = " insert into tbl_labour1(labourname,address,phone,firmid,AcName,AcNo,BankName,Branch,Ifsc,TDS,PAN) values(@labourname,@address,@phone,@firmid,@AcName,@AcNo,@BankName,@Branch,@Ifsc,@TDS,@PAN)";
            }
            else
            {
                query = " update tbl_labour1 set labourname=@labourname,address=@address,phone=@phone,firmid=@firmid,AcName=@AcName,AcNo=@AcNo,BankName=@BankName,Branch=@Branch,Ifsc=@Ifsc,TDS=@TDS,PAN=@PAN where lbrid=" + lst.SelectedValue + " and firmid=" + Data.id + "";
            }
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@labourname", txtName.Text);
            cmd.Parameters.AddWithValue("@address", txtdes.Text);
            cmd.Parameters.AddWithValue("@phone", txtprice.Text);
            cmd.Parameters.AddWithValue("@firmid", Data.id);
            cmd.Parameters.AddWithValue("@AcName", txtAcName.Text);
            cmd.Parameters.AddWithValue("@AcNo", txtAcNo.Text);
            cmd.Parameters.AddWithValue("@BankName", txtBankNAme.Text);
            cmd.Parameters.AddWithValue("@Branch", txtBranchName.Text);
            cmd.Parameters.AddWithValue("@Ifsc", txtIfscCode.Text);
            cmd.Parameters.AddWithValue("@TDS", dtpTDS.Text);
            if (dtpTDS.Text == "Yes")
            {
                cmd.Parameters.AddWithValue("@PAN", txtPanNo.Text);
            }
            if (dtpTDS.Text == "No")
            {
                cmd.Parameters.AddWithValue("@PAN", "0"); 
            }
            
            data.executeCommand(cmd);
            cmd.Parameters.Clear();
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
                    query = " select * from tbl_labour1 where lbrid =" + lst.SelectedValue + "";
                    dr = data.getDataReader(query);
                    if (dr.Read())
                    {
                        txtName.Text = dr["labourname"].ToString();
                        txtprice.Text = dr["phone"].ToString();
                        txtdes.Text = dr["address"].ToString();
                        txtAcName.Text = dr["AcName"].ToString();
                        txtAcNo.Text = dr["AcNo"].ToString();
                        txtBankNAme.Text = dr["BankName"].ToString();
                        txtBranchName.Text = dr["Branch"].ToString();
                        txtIfscCode.Text = dr["Ifsc"].ToString();
                        dtpTDS.Text = dr["TDS"].ToString();
                        txtPanNo.Text = dr["PAN"].ToString();
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

        private void dtpTDS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dtpTDS.SelectedIndex == 0)
            {
                label10.Visible = false;
                txtPanNo.Visible = false;
            }
            else
            {
                if (dtpTDS.Text == "Yes")
                {
                    label10.Visible = true;
                    txtPanNo.Visible = true;
                }
                else
                {
                    label10.Visible = false;
                    txtPanNo.Visible = false;
                }
            }
        }
    }
}