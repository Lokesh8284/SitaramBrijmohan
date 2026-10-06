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
    public partial class PartyMaster : Form
    {
        Data data = new Data();
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        string query;
        string query1;
        int Client_id = 0;
        string CrDr;
        string amt, amt1;
        string amout;

        double calamt = 0;
        double calamt1 = 0;

        public PartyMaster()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtClient_Id.Enabled = false;
            filllst();
            btnDelete.Enabled = false;
            drpCrDr.Text = "Dr";
            fillNewClientId();
            dtppartyType.SelectedIndex = 2;
            drpIfRegistred.SelectedIndex = 0;
            this.ActiveControl = txtcompany;
            chkCGST.Checked = true;
        }
        public void fillNewClientId()
        {
            query = "select Max(MaxId) as maxid from tblClient Where firmid =" + Data.id + "";
            dr = data.getDataReader(query);
            if (dr.Read())
            {
                string id = dr["maxid"].ToString();
                if (id == "")
                {
                    Client_id = 1;
                    txtClient_Id.Text = Convert.ToString(Client_id);
                }
                else
                {
                    int maxid = Convert.ToInt32(dr["maxid"].ToString());
                    Client_id = maxid + 1;
                    txtClient_Id.Text = Convert.ToString(Client_id);
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
            query = " select MaxId,id,Name,Address,PinCode,Phone,Mob,Mail,country,state,city,fax,email,website,remark,dateofjoin,officephone,compname,opening,CrDr,firmid,PartyType,PanNo,GstNo,AcNo,BankName,IfscCode,BranchName from tblclient where  firmid=" + Data.id + " and delid=0 order by compname  ";
            ds = data.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lst.DataSource = ds.Tables[0];
                lst.DisplayMember = "compname";
                lst.ValueMember = "id";
            }
            else
            {
                lst.DataSource = null;
            }
        }
        public void clear()
        {
            textBox1.Text = "";
            drpCrDr.SelectedIndex = 1;
            txtName.Text = "";
            txtAddress.Text = "";
            txtpin.Text = "";
            txtPhone.Text = "";
            txtMob.Text = "";
            txtMail.Text = "";
            txtcountry.Text = "";
            txtstate.Text = "";
            txtcity.Text = "";
            txtfax.Text = "";
            txtMail.Text = "";
            txtwebsite.Text = "";
            txtremark.Text = "";
            dateTimePicker1.Text = "";
            txtphoneoffice.Text = "";
            txtcompany.Text = "";
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
            txtBalance.Text = "0.00";
            drpCrDr.Text = "Dr";
            dtppartyType.SelectedIndex = 2;
            drpIfRegistred.SelectedIndex = 0;
            txtGSTNo.Text = "";
            txtPanNo.Text = "";
            txtAcNo.Text = "";
            txtBankName.Text = "";
            txtBarnchName.Text = "";
            txtIfscCode.Text = "";
            filllst();
            fillNewClientId();
            txtcompany.Focus();
            txtStateCode.Text = "";
        }

        private void lst_Click(object sender, EventArgs e)
        {
            click();
        }
        public void click()
        {
            query = " SELECT * from tblclient where  firmid=" + Data.id + " and  tblclient.id=" + lst.SelectedValue + "";
            dr = data.getDataReader(query);
            if (dr.Read())
            {
                txtName.Text = dr["Name"].ToString();
                txtAddress.Text = dr["Address"].ToString();
                txtpin.Text = dr["PinCode"].ToString();
                txtPhone.Text = dr["Phone"].ToString();
                txtMob.Text = dr["Mob"].ToString();
                txtMail.Text = dr["Mail"].ToString();
                txtcountry.Text = dr["country"].ToString();
                txtstate.Text = dr["state"].ToString();
                txtcity.Text = dr["city"].ToString();
                txtfax.Text = dr["fax"].ToString();
                txtMail.Text = dr["email"].ToString();
                txtwebsite.Text = dr["website"].ToString();
                txtremark.Text = dr["remark"].ToString();
                dateTimePicker1.Text = dr["dateofjoin"].ToString();
                txtphoneoffice.Text = dr["officephone"].ToString();
                txtcompany.Text = dr["compname"].ToString();
                txtBalance.Text = dr["opening"].ToString();
                drpCrDr.Text = dr["CrDr"].ToString();
                dtppartyType.Text = dr["PartyType"].ToString();
                txtPanNo.Text = dr["PanNo"].ToString();
                drpIfRegistred.Text = dr["GSTRegistration"].ToString();
                if (dr["GSTRegistration"].ToString() == "REGISTERED")
                {
                    txtGSTNo.Visible = true;
                    txtGSTNo.Text = dr["GstNo"].ToString();
                }
                if (dr["GSTRegistration"].ToString() == "COMPOSITION")
                {
                    txtGSTNo.Visible = true;
                    txtGSTNo.Text = dr["GstNo"].ToString();
                }
                if (dr["GSTFlag"].ToString() == "CGST")
                {
                    chkCGST.Checked = true;
                }
                if (dr["GSTFlag"].ToString() == "SGST")
                {
                    chkSGST.Checked = true;
                }
                if (dr["GSTFlag"].ToString() == "IGST")
                {
                    chkIGST.Checked = true;
                }
                txtClient_Id.Text = dr["MaxId"].ToString();
                txtAcNo.Text = dr["AcNo"].ToString();
                txtBankName.Text = dr["BankName"].ToString();
                txtIfscCode.Text = dr["IfscCode"].ToString();
                txtBarnchName.Text = dr["BranchName"].ToString();
                txtStateCode.Text = dr["StateCode"].ToString();
                btnSave.Text = "Update";
                btnDelete.Enabled = true;
            }
            dr.Close();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                //else if (e.KeyCode == Keys.C)
                //{
                //    // clearAll();
                //}
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }
        public void save()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Name must be entered");
                txtName.Focus();
                return;
            }
            if (drpIfRegistred.SelectedIndex == 0)
            {
                MessageBox.Show("Registred Type must be Select ");
                drpIfRegistred.Focus();
                return;
            }
            if (txtMob.Text == "")
            {
                MessageBox.Show("Mobile No Must Be Entered");
                txtMob.Focus();
                return;
            }
            if (drpIfRegistred.Text == "REGISTERED" && txtGSTNo.Text == "")
            {
                MessageBox.Show("Please Enter Party GST No");
                txtGSTNo.Focus();
                return;
            }
            if (drpIfRegistred.Text == "COMPOSITION" && txtGSTNo.Text == "")
            {
                MessageBox.Show("Please Enter Party GST No");
                txtGSTNo.Focus();
                return;
            }
            if (dtppartyType.SelectedIndex == 0)
            {
                MessageBox.Show("Please select Client Party Type");
                dtppartyType.Focus();
                return;
            }

            if (btnSave.Text == "Save")
            {
                query = " insert into tblclient([Name],[Address],PinCode,[Phone],Mob,Mail,country,state,city,fax,email,website,remark,dateofjoin,officephone,compname,opening,CrDr,firmid,PartyType,PanNo,GstNo,AcNo,BankName,IfscCode,BranchName,MaxId,GSTFlag,GSTRegistration,StateCode) values(@Name,@Address,@PinCode,@Phone,@Mob,@Mail,@country,@state,@city,@fax,@email,@website,@remark,@dateofjoin,@officephone,@compname,@opening,@CrDr,@firmid,@PartyType,@PanNo,@GstNo,@AcNo,@BankName,@IfscCode,@BranchName,@MaxId,@GSTFlag,@GSTRegistration,@StateCode)";

                if (txtBalance.Text != "0.00")
                {
                    if (drpCrDr.Text == "Cr")
                    {
                        CrDr = "Cr";
                        query1 = "insert into tblLdg(Client_Id,CrDr,VocType,BillAmt,Dat,firmid) values(" + txtClient_Id.Text + ",'" + CrDr + "','Opening Balance'," + txtBalance.Text + ",'" + dateTimePicker1.Text + "'," + Data.id + ")";
                        data.executeCommand(query1);

                        query1 = "insert into tblPending (Client_Id,Amount,DrCr,Dat,voctype,firmid)";
                        query1 += " VALUES(" + txtClient_Id.Text + "," + txtBalance.Text + ",'" + CrDr + "','" + dateTimePicker1.Text + "','Opening Balance'," + Data.id + ")";
                        data.executeCommand(query1);
                    }
                    else
                    {
                        CrDr = "Dr";
                        query1 = "insert into tblLdg(Client_Id,CrDr,VocType,BillAmt,Dat,firmid) values(" + txtClient_Id.Text + ",'" + CrDr + "','Opening Balance'," + txtBalance.Text + ",'" + dateTimePicker1.Text + "'," + Data.id + ")";
                        data.executeCommand(query1);

                        query1 = "";
                        query1 = "insert into tblPending (Client_Id,Amount,DrCr,Dat,voctype,firmid)";
                        query1 += " VALUES(" + txtClient_Id.Text + "," + txtBalance.Text + ",'" + CrDr + "','" + dateTimePicker1.Text + "','Opening Balance'," + Data.id + ")";
                        data.executeCommand(query1);
                    }
                }
            }
            else
            {
                query = " update tblclient set [Name]=@Name,[Address]=@Address,PinCode=@PinCode,[Phone]=@Phone,Mob=@Mob,Mail=@Mail,country=@country,state=@state,city=@city,fax=@fax,email=@email,website=@website,remark=@remark,dateofjoin=@dateofjoin,officephone=@officephone,compname=@compname,opening=@opening,CrDr=@CrDr,firmid=@firmid,PartyType=@PartyType,PanNo=@PanNo,GstNo=@GstNo,AcNo=@AcNo,BankName=@BankName,IfscCode=@IfscCode,BranchName=@BranchName,MaxId=@MaxId,GSTFlag=@GSTFlag,GSTRegistration=@GSTRegistration,StateCode=@StateCode ,IsSync=0 where  firmid=" + Data.id + "  and  Id=" + lst.SelectedValue + " ";

                if (txtBalance.Text != "0.00")
                {
                    if (drpCrDr.Text == "Cr")
                    {
                        query1 = "delete from tblLdg where  VocType='Opening Balance' and Client_Id= " + txtClient_Id.Text + " and firmid=" + Data.id + "";
                        data.executeCommand(query1);
                        CrDr = "Cr";
                        query1 = "insert into tblLdg(Client_Id,CrDr,VocType,BillAmt,Dat,firmid) values(" + txtClient_Id.Text + ",'" + CrDr + "','Opening Balance'," + txtBalance.Text + ",'" + dateTimePicker1.Text + "'," + Data.id + ")";
                        data.executeCommand(query1);

                        if (data.Exist("select Client_Id from tblpending where Client_Id=" + lst.SelectedValue + ""))
                        {
                            query1 = "select sum (BillAmt) as billamt1 from tblLdg where Client_Id=" + lst.SelectedValue + " and VocType <>'Opening Balance' and firmid=" + Data.id + "";
                            dr = data.getDataReader(query1);
                            if (dr.Read())
                            {
                                amt = dr["billamt1"].ToString();
                                if (amt == "")
                                {
                                    amt = "0";
                                }
                            }
                            dr.Close();

                            query1 = "select  BillAmt from tblLdg where Client_Id=" + lst.SelectedValue + " and VocType ='Opening Balance' and firmid=" + Data.id + "";
                            dr = data.getDataReader(query1);
                            if (dr.Read())
                            {
                                amt1 = dr["BillAmt"].ToString();
                            }
                            dr.Close();
                            double dd = Convert.ToDouble(amt);
                            double dd1 = Convert.ToDouble(amt1);

                            if (dd1 > dd)
                            {
                                calamt1 = Convert.ToDouble(amt1);
                                CrDr = "Cr";
                            }
                            else
                            {
                                calamt = Convert.ToDouble(amt) - Convert.ToDouble(amt1);
                                CrDr = "Dr";
                            }
                            //double calamt1 = Convert.ToDouble(txtBalance.Text) + calamt;

                            query1 = "delete from tblpending where  voctype='Opening Balance' and Client_Id= " + lst.SelectedValue + ", firmid=" + Data.id + "";
                            data.executeCommand(query1);


                            query1 = "";
                            query1 = "insert into tblPending (Client_Id,Amount,DrCr,Dat,voctype,firmid)";
                            query1 += " VALUES(" + txtClient_Id.Text + "," + calamt + ",'" + CrDr + "','" + dateTimePicker1.Text + "','Opening Balance'," + Data.id + ")";
                            data.executeCommand(query1);
                        }
                        else
                        {
                            CrDr = "Cr";
                            query1 = "";
                            query1 = "insert into tblPending (Client_Id,Amount,DrCr,Dat,voctype,firmid)";
                            query1 += " VALUES(" + txtClient_Id.Text + "," + txtBalance.Text + ",'" + CrDr + "','" + dateTimePicker1.Text + "','Opening Balance'," + Data.id + ")";
                            data.executeCommand(query1);
                        }


                    }
                    else
                    {

                        query1 = "delete from tblLdg where  VocType='Opening Balance' and Client_Id= " + txtClient_Id.Text + ",firmid=" + Data.id + "";
                        data.executeCommand(query1);
                        CrDr = "Dr";
                        query1 = "insert into tblLdg(Client_Id,CrDr,VocType,BillAmt,Dat,firmid) values(" + txtClient_Id.Text + ",'" + CrDr + "','Opening Balance'," + txtBalance.Text + ",'" + dateTimePicker1.Text + "'," + Data.id + ")";
                        data.executeCommand(query1);

                        try
                        {
                            if (data.Exist("select Client_Id from tblpending where Client_Id=" + lst.SelectedValue + " and firmid=" + Data.id + ""))
                            {
                                query1 = "select opening from tblclient where id=" + lst.SelectedValue + " and firmid=" + Data.id + "";
                                dr = data.getDataReader(query1);
                                if (dr.Read())
                                {
                                    amt = dr["opening"].ToString();
                                }
                                dr.Close();
                            }
                        }
                        catch
                        { }
                        try
                        {
                            if (data.Exist("select Client_Id from tblpending where Client_Id=" + lst.SelectedValue + " and firmid=" + Data.id + ""))
                            {
                                query1 = "select Amount from tblpending where Client_Id=" + lst.SelectedValue + " and firmid=" + Data.id + "";
                                dr = data.getDataReader(query1);
                                if (dr.Read())
                                {
                                    amt1 = dr["Amount"].ToString();
                                }
                                dr.Close();

                                calamt = Convert.ToDouble(amt1) - Convert.ToDouble(amt);
                                calamt1 = Convert.ToDouble(txtBalance.Text) + calamt;
                                query1 = "delete from tblpending where  voctype='Opening Balance' and Client_Id= " + txtClient_Id.Text + " and firmid=" + Data.id + "";
                                data.executeCommand(query1);
                                CrDr = "Dr";
                                query1 = "";
                                query1 = "insert into tblPending (Client_Id,Amount,DrCr,Dat,voctype,firmid)";
                                query1 += " VALUES(" + txtClient_Id.Text + "," + calamt1 + ",'" + CrDr + "','" + dateTimePicker1.Text + "','Opening Balance'," + Data.id + ")";
                                data.executeCommand(query1);
                            }
                            else
                            {
                                CrDr = "Dr";
                                query1 = "";
                                query1 = "insert into tblPending (Client_Id,Amount,DrCr,Dat,voctype,firmid)";
                                query1 += " VALUES(" + txtClient_Id.Text + "," + txtBalance.Text + ",'" + CrDr + "','" + dateTimePicker1.Text + "','Opening Balance'," + Data.id + ")";
                                data.executeCommand(query1);
                            }
                        }
                        catch
                        { }
                    }
                }
            }
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
            cmd.Parameters.AddWithValue("@PinCode", txtpin.Text);
            cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
            cmd.Parameters.AddWithValue("@Mob", txtMob.Text);
            cmd.Parameters.AddWithValue("@Mail", txtMail.Text);
            cmd.Parameters.AddWithValue("@country", txtcountry.Text);
            cmd.Parameters.AddWithValue("@state", txtstate.Text);
            cmd.Parameters.AddWithValue("@city", txtcity.Text);
            cmd.Parameters.AddWithValue("@fax", txtfax.Text);
            cmd.Parameters.AddWithValue("@email", txtMail.Text);
            cmd.Parameters.AddWithValue("@website", txtwebsite.Text);
            cmd.Parameters.AddWithValue("@remark", txtremark.Text);
            cmd.Parameters.AddWithValue("@dateofjoin", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@officephone", txtphoneoffice.Text);
            cmd.Parameters.AddWithValue("@compname", txtName.Text);
            cmd.Parameters.AddWithValue("@opening", txtBalance.Text);
            cmd.Parameters.AddWithValue("@CrDr", drpCrDr.Text);
            cmd.Parameters.AddWithValue("@firmid", Data.id);
            cmd.Parameters.AddWithValue("@PartyType", dtppartyType.Text);
            cmd.Parameters.AddWithValue("@PanNo", txtPanNo.Text.ToUpper());
            if (drpIfRegistred.Text == "REGISTERED")
            {
                cmd.Parameters.AddWithValue("@GstNo", txtGSTNo.Text.ToUpper());
            }
            if (drpIfRegistred.Text == "UN-REGISTERED")
            {
                cmd.Parameters.AddWithValue("@GstNo", "0");
            }
            if (drpIfRegistred.Text == "COMPOSITION")
            {
                cmd.Parameters.AddWithValue("@GstNo", txtGSTNo.Text.ToUpper());
            }
            if (chkCGST.Checked)
            {
                cmd.Parameters.AddWithValue("@GSTFlag", "CGST");
            }
            if (chkSGST.Checked)
            {
                cmd.Parameters.AddWithValue("@GSTFlag", "SGST");
            }
            if (chkIGST.Checked)
            {
                cmd.Parameters.AddWithValue("@GSTFlag", "IGST");
            }
            // cmd.Parameters.AddWithValue("@GstNo", txtGSTNo.Text);
            cmd.Parameters.AddWithValue("@AcNo", txtAcNo.Text);
            cmd.Parameters.AddWithValue("@BankName", txtBankName.Text);
            cmd.Parameters.AddWithValue("@IfscCode", txtIfscCode.Text);
            cmd.Parameters.AddWithValue("@BranchName", txtBarnchName.Text);
            cmd.Parameters.AddWithValue("@MaxId", txtClient_Id.Text);
            cmd.Parameters.AddWithValue("@GSTRegistration", drpIfRegistred.Text);
            cmd.Parameters.AddWithValue("@StateCode", txtStateCode.Text);
            data.executeCommand(cmd);
            cmd.Parameters.Clear();
            MessageBox.Show("Record Save Sussessfully");
            filllst();
            clear();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
        }
        public void delete()
        {
            if (btnDelete.Enabled == true)
            {
                if (MessageBox.Show("Do you want Delete Recored Press 'Yes' otherwise Press 'No'", "Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //query = " delete from  tblclient where id=" + lst.SelectedValue + " and firmid=" + Data.id + "";
                    query = "  update tblclient set delid=1,IsSync=0 where id=" + lst.SelectedValue + " and firmid=" + Data.id + "";
                    data.executeCommand(query);
                    //query = " delete from  tblpending where Client_Id=" + lst.SelectedValue + " and firmid=" + Data.id + "";
                    //data.executeCommand(query);
                    //query = " delete from  tblldg where Client_Id=" + lst.SelectedValue + " and firmid=" + Data.id + "";
                    //data.executeCommand(query);
                    //query = " delete from chalandetail where firmid=" + lst.SelectedValue + " and firmid=" + Data.id + "";
                    //data.executeCommand(query);

                    //query = " delete from clientprice where firmid=" + lst.SelectedValue + " and firmid=" + Data.id + "";
                    //data.executeCommand(query);

                    //query = " delete from tblchalan  where firmid=" + lst.SelectedValue + " and firmid=" + Data.id + "";
                    //data.executeCommand(query);

                    filllst();
                    clear();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            delete();
        }

        private void txtMob_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = (char)e.KeyChar;
            string bb = "0123456789+-\b\r ";

            string pp = ch.ToString();

            if (!bb.Contains(pp))
            {
                MessageBox.Show(" invalid characters");
                e.KeyChar = '\0';
                return;
            }
        }

        private void lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lst.SelectedIndex > 0)
            {
                click();
            }
        }

        private void txtBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ch = (int)e.KeyChar;
            if ((ch < 48 || ch > 58) && (ch != 8) && (ch != 46))
                e.KeyChar = '\0';
        }

        private void txtBalance_TextChanged(object sender, EventArgs e)
        {
            if (txtBalance.Text == "")
            {
                txtBalance.Text = "0.00";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //query = "select (cast(id as Nvarchar(50)) + '-' + compname) as IdName,id,Name,Address,PinCode,Phone,Mob,Mail,country,state,city,fax,email,website,remark,dateofjoin,officephone,compname,opening,CrDr,firmid,PartyType,PanNo,GstNo,AcNo,BankName,IfscCode,BranchName from tblclient where compname Like '%" + textBox1.Text.Trim() + "%'  and firmid=" + Data.id + " order by compname";
            query = "select MaxId,id,Name,Address,PinCode,Phone,Mob,Mail,country,state,city,fax,email,website,remark,dateofjoin,officephone,compname,opening,CrDr,firmid,PartyType,PanNo,GstNo,AcNo,BankName,IfscCode,BranchName from tblclient where delid=0 and compname Like '%" + textBox1.Text.Trim() + "%'  and firmid=" + Data.id + " order by compname";
            ds = data.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lst.DataSource = ds.Tables[0];
                lst.DisplayMember = "compname";
                lst.ValueMember = "Id";
            }
        }

        private void drpIfRegistred_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpIfRegistred.SelectedIndex == 0)
            {
                label29.Visible = false;
                txtGSTNo.Visible = false;
            }
            else
            {
                if (drpIfRegistred.Text == "REGISTERED")
                {
                    label29.Visible = true;
                    txtGSTNo.Visible = true;
                }
                if (drpIfRegistred.Text == "UN-REGISTERED")
                {
                    label29.Visible = false;
                    txtGSTNo.Visible = false;
                }
                if (drpIfRegistred.Text == "COMPOSITION")
                {
                    label29.Visible = true;
                    txtGSTNo.Visible = true;
                }
            }
        }

        private void chkCGST_CheckedChanged(object sender, EventArgs e)
        {
            chkSGST.Checked = false;
            chkIGST.Checked = false;
        }

        private void chkSGST_CheckedChanged(object sender, EventArgs e)
        {
            chkCGST.Checked = false;
            chkIGST.Checked = false;
        }

        private void chkIGST_CheckedChanged(object sender, EventArgs e)
        {
            chkSGST.Checked = false;
            chkCGST.Checked = false;
        }
    }
}