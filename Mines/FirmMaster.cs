using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace WelcomeFabric
{
    public partial class FirmMaster : Form
    {
        Data data = new Data();
        DataSet ds = new DataSet();
        string query;
        string query1;
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        SqlDataReader dr1;
        int Client_id = 0;
        OpenFileDialog open = new OpenFileDialog();
        String filename = null;
        String path = null;
        byte[] image = null;
        bool NewImage = false, NewImage2 = false;
        string firmid;
        public FirmMaster()
        {
            InitializeComponent();
        }

        private void FirmMaster_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.NoImage;
            txtClient_Id.Enabled = false;
            filllst();
            fillNewClientId();
            btnDelete.Enabled = false;
            this.ActiveControl = txtcomp;
        }
        public void filllst()
        {
            query = " select (cast(firmid as Nvarchar(50)) + '-' + compname) as FirmIdName,firmid, [Name],[Address],PinCode,[Phone],Mob,Mail,country,state,city, email,website,officephone,compname,username,passrd,PanNo,GstNo,RpcbUserId,StateCode from tblfirm where firmid='" + Data.id + "' ";
            ds = data.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lst.DataSource = ds.Tables[0];
                lst.DisplayMember = "FirmIdName";
                lst.ValueMember = "firmid";
            }
            else
            {
                lst.DataSource = null;
            }
        }
        public void fillNewClientId()
        {
            query = "select Max(firmid) as maxid from tblfirm";
            dr1 = data.getDataReader(query);
            if (dr1.Read())
            {
                string id = dr1["maxid"].ToString();
                if (id == "")
                {
                    Client_id = 1;
                    txtClient_Id.Text = Convert.ToString(Client_id);
                }
                else
                {
                    int maxid = Convert.ToInt32(dr1["maxid"].ToString());
                    Client_id = maxid + 1;
                    txtClient_Id.Text = Convert.ToString(Client_id);
                }
                dr1.Close();
            }
        }

        public void clear()
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtpin.Text = "";
            txtPhone.Text = "";
            txtMob.Text = "";
            txtMail.Text = "";
            txtcountry.Text = "";
            txtstate.Text = "";
            txtcity.Text = "";
            txtRPCB.Text = "";
            txtMail.Text = "";
            txtwebsite.Text = "";
            txtphoneoffice.Text = "";
            txtcomp.Text = "";
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
            txtcomp.Focus();
            filllst();
            txtuser.Text = "";
            txtpass.Text = "";
            txtRPCB.Text = "";
            txtpass.Text = "";
            txtPanNo.Text = "";
            txtGstNo.Text = "";
            txtAcNo.Text = "";
            txtBankName.Text = "";
            txtBarnchName.Text = "";
            txtIfscCode.Text = "";
            txtStateCode.Text = "";
            fillNewClientId();

            pictureBox1.Image = Properties.Resources.NoImage;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }
        public void save()
        { 
            byte[] Logo = null; 
            Logo = data.ResizeImageToByteActual(pictureBox1.Image);

            byte[] Other = null;
            Other = data.ResizeImageToByteActual(pictureBox2.Image);

            if (txtName.Text == "")
            {
                MessageBox.Show("Name must be entered");
                txtName.Focus();
                return;
            }
            if (txtuser.Text == "")
            {
                MessageBox.Show("User Name must be entered");
                txtuser.Focus();
                return;
            }
            if (txtpass.Text == "")
            {
                MessageBox.Show("Password must be entered");
                txtpass.Focus();
                return;
            }
            if (btnSave.Text == "Save")
            {
                if (data.Exist("select username from tblfirm where username='" + txtuser.Text + "' and firmid=" + Data.id + ""))
                {
                    MessageBox.Show("User Name Already Exist");
                    txtuser.Focus();
                    return;
                }
                query = " insert into tblfirm([Name],[Address],PinCode,[Phone],Mob,Mail,country,state,city,email,website,officephone,compname,username,passrd,PanNo,GstNo,AcNo,BankName,IfscCode,BranchName,ShortName,StateCode,RpcbUserId,RemoteId,Logo,Other) values(@Name,@Address,@PinCode,@Phone,@Mob,@Mail,@country,@state,@city,@email,@website,@officephone,@compname,@username,@passrd,@PanNo,@GstNo,@AcNo,@BankName,@IfscCode,@BranchName,@ShortName,@StateCode,@RpcbUserId,@RemoteId,@Logo,@Other)";

            }
            else
            {
                if (lst.SelectedValue.ToString() != Data.id)
                {
                    MessageBox.Show("Plz login from'" + lst.Text + "' ");
                    return;
                }
                query = " update tblfirm set [Name]=@Name,[Address]=@Address,PinCode=@PinCode,[Phone]=@Phone,Mob=@Mob,Mail=@Mail,country=@country,state=@state,city=@city,email=@email,website=@website,officephone=@officephone,compname=@compname,username=@username,passrd=@passrd,PanNo=@PanNo,GstNo=@GstNo,AcNo=@AcNo,BankName=@BankName,IfscCode=@IfscCode,BranchName=@BranchName,ShortName=@ShortName,StateCode=@StateCode,RpcbUserId=@RpcbUserId,RemoteId=@RemoteId, Logo=@Logo,Other=@Other where firmid=" + lst.SelectedValue + " ";
            }
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
            cmd.Parameters.AddWithValue("@PinCode", txtpin.Text);
            cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
            cmd.Parameters.AddWithValue("@Mob", txtMob.Text);
            cmd.Parameters.AddWithValue("@Mail", txtCursoraddress.Text);
            cmd.Parameters.AddWithValue("@country", txtcountry.Text);
            cmd.Parameters.AddWithValue("@state", txtstate.Text);
            cmd.Parameters.AddWithValue("@city", txtcity.Text);
            //cmd.Parameters.AddWithValue("@fax", txtfax.Text);
            cmd.Parameters.AddWithValue("@email", txtMail.Text);
            cmd.Parameters.AddWithValue("@website", txtwebsite.Text);
            cmd.Parameters.AddWithValue("@officephone", txtphoneoffice.Text);
            cmd.Parameters.AddWithValue("@compname", txtcomp.Text);
            cmd.Parameters.AddWithValue("@username", txtuser.Text);
            cmd.Parameters.AddWithValue("@passrd", txtpass.Text);
            cmd.Parameters.AddWithValue("@tin", txtRPCB.Text);
            cmd.Parameters.AddWithValue("@RpcbUserId", txtRPCB.Text);
            cmd.Parameters.AddWithValue("@PanNo", txtPanNo.Text.ToUpper());
            cmd.Parameters.AddWithValue("@GstNo", txtGstNo.Text.ToUpper());
            cmd.Parameters.AddWithValue("@AcNo", txtAcNo.Text);
            cmd.Parameters.AddWithValue("@BankName", txtBankName.Text);
            cmd.Parameters.AddWithValue("@IfscCode", txtIfscCode.Text);
            cmd.Parameters.AddWithValue("@BranchName", txtBarnchName.Text);
            cmd.Parameters.AddWithValue("@ShortName", txtShortName.Text);
            cmd.Parameters.AddWithValue("@StateCode", txtStateCode.Text);
            cmd.Parameters.AddWithValue("@RemoteId", txtRemoteId.Text);
            cmd.Parameters.AddWithValue("@Logo", Logo);
            cmd.Parameters.AddWithValue("@Other", Other);
            data.executeCommand(cmd);
            cmd.Parameters.Clear();

            if (btnSave.Text == "Save")
            {
                query = " select max(firmid) as firmid from tblfirm";
                ds = data.getDataSet(query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    firmid = ds.Tables[0].Rows[0]["firmid"].ToString();
                }
                query1 = " insert into login(username,[password],firmid)values('" + txtuser.Text + "','" + txtpass.Text + "'," + firmid + ")";
                data.executeCommand(query1);
            }
            else
            {
                query1 = " delete from login where firmid=" + txtClient_Id.Text + "";
                data.executeCommand(query1);
                query1 = " insert into login(username,[password],firmid)values('" + txtuser.Text + "','" + txtpass.Text + "'," + txtClient_Id.Text + ")";
                data.executeCommand(query1);
            }
            MessageBox.Show("Record Save Sussessfully");
            filllst();
            clear();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
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

        private void lst_Click(object sender, EventArgs e)
        {
            if (lst.SelectedValue != null)
            {

                query = " SELECT * from tblfirm where firmid=" + lst.SelectedValue + "";
                dr = data.getDataReader(query);
                if (dr.Read())
                {
                    txtName.Text = dr["Name"].ToString();
                    txtAddress.Text = dr["Address"].ToString();
                    txtpin.Text = dr["PinCode"].ToString();
                    txtPhone.Text = dr["Phone"].ToString();
                    txtMob.Text = dr["Mob"].ToString();
                    txtCursoraddress.Text = dr["Mail"].ToString();
                    txtcountry.Text = dr["country"].ToString();
                    txtstate.Text = dr["state"].ToString();
                    txtcity.Text = dr["city"].ToString();
                    //txtfax.Text = dr["fax"].ToString();
                    txtMail.Text = dr["email"].ToString();
                    txtwebsite.Text = dr["website"].ToString();
                    txtphoneoffice.Text = dr["officephone"].ToString();
                    txtcomp.Text = dr["compname"].ToString();
                    txtClient_Id.Text = dr["firmid"].ToString();
                    txtuser.Text = dr["username"].ToString();
                    txtpass.Text = dr["passrd"].ToString();
                    txtRPCB.Text = dr["RpcbUserId"].ToString();
                    txtPanNo.Text = dr["PanNo"].ToString();
                    txtGstNo.Text = dr["GstNo"].ToString();
                    txtShortName.Text = dr["ShortName"].ToString();
                    txtStateCode.Text = dr["StateCode"].ToString();
                    txtAcNo.Text = dr["AcNo"].ToString();
                    txtBankName.Text = dr["BankName"].ToString();
                    txtBarnchName.Text = dr["BranchName"].ToString();
                    txtIfscCode.Text = dr["IfscCode"].ToString();
                    txtRemoteId.Text = dr["RemoteId"].ToString();

                    if (dr["Logo"].ToString() != "")
                    {
                        Byte[] byteBLOBData = new Byte[0];
                        byteBLOBData = (Byte[])(dr["Logo"]);
                        MemoryStream stmBLOBDATA = new MemoryStream(byteBLOBData);
                        pictureBox1.Image = Image.FromStream(stmBLOBDATA);
                        pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                    }
                    else
                    {
                        pictureBox1.Image = Properties.Resources.NoImage;
                    }

                    if (dr["Other"].ToString() != "")
                    {
                        Byte[] byteBLOBData = new Byte[0];
                        byteBLOBData = (Byte[])(dr["Other"]);
                        MemoryStream stmBLOBDATA = new MemoryStream(byteBLOBData);
                        pictureBox2.Image = Image.FromStream(stmBLOBDATA);
                        pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                    }
                    else
                    {
                        pictureBox2.Image = Properties.Resources.NoImage;
                    }


                    btnSave.Text = "Update";
                    btnDelete.Enabled = true;
                }
                dr.Close();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lst.SelectedValue.ToString() != Data.id)
            {
                MessageBox.Show("Plz login from '" + lst.Text + "' ");
                return;
            }
            else
            {
                //delete();
            }
        }
        public void delete()
        {
            if (btnDelete.Enabled == true)
            {
                if (MessageBox.Show("Do you want Delete Recored Press 'Yes' otherwise Press 'No'", "Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    query = " delete from tblfirm where firmid=" + lst.SelectedValue + "";
                    data.executeCommand(query);

                    query = " delete from chalandetail where firmid=" + lst.SelectedValue + "";
                    data.executeCommand(query);

                    query = " delete from clientprice where firmid=" + lst.SelectedValue + "";
                    data.executeCommand(query);

                    query = " delete from login where firmid =" + lst.SelectedValue + "";
                    data.executeCommand(query);

                    query = " delete from tblbill where firmid=" + lst.SelectedValue + "";
                    data.executeCommand(query);

                    query = " delete from tblbilldetail where firmid=" + lst.SelectedValue + "";
                    data.executeCommand(query);

                    query = " delete from tblchalan  where firmid=" + lst.SelectedValue + "";
                    data.executeCommand(query);

                    query = " delete from tblclient where firmid=" + lst.SelectedValue + "";
                    data.executeCommand(query);

                    query = " delete from tblitem where firmid=" + lst.SelectedValue + "";
                    data.executeCommand(query);

                    query = " delete from tblpending where firmid=" + lst.SelectedValue + "";
                    data.executeCommand(query);

                    query = " delete from tblprice where firmid=" + lst.SelectedValue + "";
                    data.executeCommand(query);
                }
            }
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
                //}c
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            query = "select (cast(firmid as Nvarchar(50)) + '-' + Name) as FirmIdName,firmid, [Name],[Address],PinCode,[Phone],Mob,Mail,country,state,city, email,website,officephone,compname,username,passrd,PanNo,GstNo,RpcbUserId,StateCode from tblfirm where Name Like '" + textBox1.Text.Trim() + "%'";
            ds = data.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lst.DataSource = ds.Tables[0];
                lst.DisplayMember = "FirmIdName";
                lst.ValueMember = "firmid";
            }
        }

        private void btnIMage1_Click(object sender, EventArgs e)
        {
            NewImage = false;
            string FilePath = "";
            open.Filter = "Image file (*.jpg)|*.jpg|Image file (*.gif)|*.gif|Image file (*.JPEG)|*.jpeg";
            if (open.ShowDialog() == DialogResult.OK)
            {
                filename = System.IO.Path.GetFileName(open.FileName);
                path = System.IO.Path.GetDirectoryName(open.FileName);
                pictureBox1.ImageLocation = path + "/" + filename;
                FilePath = path + "/" + filename;
                NewImage = true;
            }
        } 

        private void btnImage1Clear_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.NoImage;
            pictureBox1.ImageLocation = null;
            NewImage = false;
        }

        private void btnImage2Add_Click(object sender, EventArgs e)
        {
            NewImage2 = false;
            string FilePath = "";
            open.Filter = "Image file (*.jpg)|*.jpg|Image file (*.gif)|*.gif|Image file (*.JPEG)|*.jpeg";
            if (open.ShowDialog() == DialogResult.OK)
            {
                filename = System.IO.Path.GetFileName(open.FileName);
                path = System.IO.Path.GetDirectoryName(open.FileName);
                pictureBox2.ImageLocation = path + "/" + filename;
                FilePath = path + "/" + filename;
                NewImage2 = true;
            }
        }

        private void btnImage2Clear_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.NoImage;
            pictureBox2.ImageLocation = null;
            NewImage2 = false;
        }

        //public void delete()
        //{
        //    if (btnDelete.Enabled == true)
        //    {
        //        if (MessageBox.Show("Do you want Delete Recored Press 'Yes' otherwise Press 'No'", "Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //        {
        //            query = " delete from  tblclient where id=" + lst.SelectedValue + "";
        //            data.executeCommand(query);
        //            query = " delete from  tblpending where Client_Id=" + lst.SelectedValue + "";
        //            data.executeCommand(query);
        //            query = " delete from  tblldg where Client_Id=" + lst.SelectedValue + "";
        //            data.executeCommand(query);
        //            filllst();
        //            clear();
        //        }
        //    }
        //}

    }
}