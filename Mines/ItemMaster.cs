using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using OnBarcode.Barcode;
using System.IO;
using System.Drawing.Imaging;

namespace WelcomeFabric
{
    public partial class ItemMaster : Form
    {
        Data data = new Data();
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        OpenFileDialog open = new OpenFileDialog();
        String filename = null;
        String path = null;
        byte[] image = null;
        bool NewImage = false, NewImage2 = false, NewImage3 = false;
        string query;
        enum Size1 { Small = 1, Medium = 2, Large = 3 };

        public ItemMaster()
        {
            InitializeComponent();
        }

        private void ItemMaster_Load(object sender, EventArgs e)
        {
            //txtBarcode.Enabled = false;
            clear();
            filllst();
        }

        private void fillbarcode()
        {
            int max1 = 100000;
            query = "select max(ItemCode) as ItemCode from tblitem where firmid=" + Data.id;
            dr = data.getDataReader(query);
            if (dr.Read())
            {
                string sno = dr["ItemCode"].ToString();
                if (sno == "")
                {
                    max1 = Convert.ToInt32(sno + 1);
                }
                else
                {
                    int dd = Convert.ToInt32(sno);
                    max1 = Convert.ToInt32(dd + 1);
                }
                txtItemcode.Text = Convert.ToString(max1);
            }
            dr.Close();
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

        private void BindCategory()
        {
            query = " select * from tblCategory where delid=0 order by CategoryName";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["CategoryId"] = "0";
            newrow["CategoryName"] = "Select Category";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            drpCategory.DataSource = ds.Tables[0];
            drpCategory.DisplayMember = "CategoryName";
            drpCategory.ValueMember = "CategoryId";
        }

        public void fillId()
        {
            string query = "select ";
        }
        public void filllst()
        {
            //string query1 = " select * from tblitem where delid=0 and  firmid=" + Data.id + " order by itemname";
            string query1 = " select itemid, (cast(ItemCode as nvarchar(50))+' - '+upper(itemname)) itemname from tblitem where delid=0 and firmid=" + Data.id + "  order by Barcode";
            DataSet ds1 = data.getDataSet(query1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                lst.DataSource = ds1.Tables[0];
                lst.DisplayMember = "itemname";
                lst.ValueMember = "itemid";
            }
            else
            {
                lst.DataSource = null;
            }

        }
        private void txtprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ch = (int)e.KeyChar;
            if ((ch < 48 || ch > 58) && (ch != 8) && (ch != 46))
                e.KeyChar = '\0';
        }
        public void delete()
        {
            if (btnDelete.Enabled == true)
            {
                if (MessageBox.Show("Do you want Delete Record Press 'Yes' otherwise 'No", "Sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    query = " update tblitem set delid=1,IsUpdate=0,IsSync=0  where  itemid =" + lst.SelectedValue + " and firmid=" + Data.id + "";
                    if (data.executeCommand(query) == 0)
                    {
                        MessageBox.Show("Record Delete");
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Record Not Delete");
                        return;
                    }
                }
            }
        }
        public void clear()
        {
            // filllst();
            fillGST();
            BindCategory();
            drpUnit();
            fillbarcode();
            txtdes.Text = "";
            txtName.Text = "";
            dtpUnit.SelectedIndex = 0;
            txtSalePrice1.Text = "0.00";
            txtCGST.Text = "0.00";
            txtSGST.Text = "0.00";
            txtIGST.Text = "0.00";
            btnSave.Text = "Save";
            txtDisplayOrder.Text = "0";
            btnDelete.Enabled = false;
            txtName.Focus();
            pictureBox1.Image = pictureBox2.Image = pictureBox3.Image = Properties.Resources.NoImage;
            pictureBox1.ImageLocation = pictureBox2.ImageLocation = pictureBox3.ImageLocation = null;
            lblImage1Path.Text = lblImage2Path.Text = lblImage3Path.Text = "";
            NewImage = NewImage2 = NewImage3 = false;
            chkApp.Checked = false;
        }

        private void fillGST()
        {
            ds = data.getDataSet("sp_ViewGST 0");
            DataRow drr = ds.Tables[0].NewRow();
            drr["GST_Id"] = "0";
            drr["GSTName"] = "Select";
            ds.Tables[0].Rows.InsertAt(drr, 0);
            drpGST.DataSource = ds.Tables[0];
            drpGST.ValueMember = "GST_Id";
            drpGST.DisplayMember = "GSTName";
        }

        public void save()
        {
            try
            {
                cmd.Parameters.Clear();
                if (txtName.Text == "")
                {
                    MessageBox.Show("Name must be entered");
                    txtName.Focus();
                    return;
                }
                if (txtItemcode.Text == "")
                {
                    MessageBox.Show("Item Code must be entered");
                    txtItemcode.Focus();
                    return;
                }
                if (drpCategory.SelectedIndex == 0)
                {
                    MessageBox.Show("Category Must Be Select");
                    drpCategory.Focus();
                    return;
                }
                if (drpGST.SelectedIndex == 0)
                {
                    MessageBox.Show("GST Must Be Select");
                    drpGST.Focus();
                    return;
                }

                if (btnSave.Text == "Save")
                {
                    if (data.Exist("Select ItemCode from tblitem where ItemCode='" + txtItemcode.Text + "' and firmid=" + Data.id + ""))
                    {
                        MessageBox.Show("ItemCode Already Exist");
                        txtItemcode.Focus();
                        return;
                    }
                    if (data.Exist("Select itemname from tblitem where itemname='" + txtName.Text + "' and firmid=" + Data.id + ""))
                    {
                        MessageBox.Show("itemname Already Exist");
                        txtName.Focus();
                        return;
                    }
                    else
                    {
                        query = " insert into tblitem(itemname,SalePrice1,SalePrice2 ,MRP,description,firmid,Unit,CGST,SGST,IGST,ItemCode,IsUpdate,ImageName1,ImageName2,CategoryId,DisplayOrder,MaxQuantity,ImageName3,GST_Id,IsApp) values(@itemname,@SalePrice1,@SalePrice2,@MRP,@description,@firmid,@Unit,@CGST,@SGST,@IGST,@ItemCode,1,@ImageName1,@ImageName2,@CategoryId,@DisplayOrder,@MaxQuantity,@ImageName3,@GST_Id,@IsApp)";
                    }
                }
                else
                {
                    query = " update tblitem set itemname=@itemname,SalePrice1=@SalePrice1,SalePrice2=@SalePrice2,MRP=@MRP,description=@description,firmid=@firmid,Unit=@Unit,CGST=@CGST,SGST=@SGST,IGST=@IGST,ItemCode=@ItemCode,IsUpdate=0,IsSync=0 ,ImageName1=@ImageName1,ImageName2=@ImageName2,CategoryId=@CategoryId,DisplayOrder=@DisplayOrder,MaxQuantity=@MaxQuantity,ImageName3=@ImageName3,GST_Id=@GST_Id,IsApp=@IsApp where itemid=" + lst.SelectedValue + " and firmid=" + Data.id + "";
                }
                cmd.CommandText = query;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@itemname", txtName.Text);
                cmd.Parameters.AddWithValue("@MRP", txtSalePrice1.Text);
                cmd.Parameters.AddWithValue("@SalePrice1", txtSalePrice1.Text);
                cmd.Parameters.AddWithValue("@SalePrice2", txtSalePrice2.Text);
                cmd.Parameters.AddWithValue("@description", txtdes.Text);
                cmd.Parameters.AddWithValue("@firmid", Data.id);
                cmd.Parameters.AddWithValue("@Unit", dtpUnit.Text);
                cmd.Parameters.AddWithValue("@CategoryId", drpCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@CGST", txtCGST.Text);
                cmd.Parameters.AddWithValue("@SGST", txtSGST.Text);
                cmd.Parameters.AddWithValue("@IGST", txtIGST.Text);
                cmd.Parameters.AddWithValue("@ItemCode", txtItemcode.Text);
                cmd.Parameters.AddWithValue("@DisplayOrder", txtDisplayOrder.Text);
                cmd.Parameters.AddWithValue("@MaxQuantity", txtMaxQuantity.Text);
                cmd.Parameters.AddWithValue("@GST_Id", drpGST.SelectedValue);
                cmd.Parameters.AddWithValue("@IsApp", chkApp.Checked);
                if (btnSave.Text == "Save")
                {
                    cmd.Parameters.AddWithValue("@ImageName1", (pictureBox1.ImageLocation != null) ? txtItemcode.Text + "-1-" + Data.id + ".jpg" : "NoImage.jpg");
                    cmd.Parameters.AddWithValue("@ImageName2", (pictureBox2.ImageLocation != null) ? txtItemcode.Text + "-2-" + Data.id + ".jpg" : "NoImage.jpg");
                    cmd.Parameters.AddWithValue("@ImageName3", (pictureBox3.ImageLocation != null) ? txtItemcode.Text + "-3-" + Data.id + ".jpg" : "NoImage.jpg");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ImageName1", (NewImage == true) ? ((pictureBox1.ImageLocation != null) ? txtItemcode.Text + "-1-" + Data.id + ".jpg" : "NoImage.jpg") : lblImage1Path.Text);
                    cmd.Parameters.AddWithValue("@ImageName2", (NewImage2 == true) ? ((pictureBox2.ImageLocation != null) ? txtItemcode.Text + "-2-" + Data.id + ".jpg" : "NoImage.jpg") : lblImage2Path.Text);
                    cmd.Parameters.AddWithValue("@ImageName3", (NewImage3 == true) ? ((pictureBox3.ImageLocation != null) ? txtItemcode.Text + "-3-" + Data.id + ".jpg" : "NoImage.jpg") : lblImage3Path.Text);
                }

                if (data.executeCommand(cmd) == 0)
                {
                    // if (pictureBox1.ImageLocation != null)
                    if (NewImage)
                    {
                        if (Data.IsFTP == "False")
                        {
                            data.UploadImageOnLocal(pictureBox1, "Item_Image", txtItemcode.Text + "-1-" + Data.id + ".jpg");
                            foreach (string i in Enum.GetNames(typeof(Size1)))
                            {
                                data.UploadImageOnLocal(pictureBox1, "Item_Image", txtItemcode.Text + "-1-" + Data.id + ".jpg", i);
                            }
                        }
                        else
                        {
                            data.UploadFileToFTP(pictureBox1, "Item_Image", txtItemcode.Text + "-1-" + Data.id + ".jpg");
                            foreach (string i in Enum.GetNames(typeof(Size1)))
                            {
                                data.UploadFileToFTP(pictureBox1, "Item_Image", txtItemcode.Text + "-1-" + Data.id + ".jpg", i);
                            }
                        }
                        //if (Data.IsFTP == "False")
                        //{
                        //    data.UploadImageOnLocal(pictureBox1, "Item_Image", txtItemcode.Text + "-1-" + Data.id + ".jpg");
                        //    data.UploadImageOnLocal(pictureBox1, "Item_Image", txtItemcode.Text + "-1-" + Data.id + ".jpg", "Small");
                        //    data.UploadImageOnLocal(pictureBox1, "Item_Image", txtItemcode.Text + "-1-" + Data.id + ".jpg", "Medium");
                        //    data.UploadImageOnLocal(pictureBox1, "Item_Image", txtItemcode.Text + "-1-" + Data.id + ".jpg", "Large");
                        //}
                        //else
                        //{
                        //    data.UploadFileToFTP(pictureBox1, "Item_Image", txtItemcode.Text + "-1-" + Data.id + ".jpg");
                        //    data.UploadFileToFTP(pictureBox1, "Item_Image", txtItemcode.Text + "-1-" + Data.id + ".jpg", "Small");
                        //    data.UploadFileToFTP(pictureBox1, "Item_Image", txtItemcode.Text + "-1-" + Data.id + ".jpg", "Medium");
                        //    data.UploadFileToFTP(pictureBox1, "Item_Image", txtItemcode.Text + "-1-" + Data.id + ".jpg", "Large");
                        //}
                    }


                    //if (pictureBox2.ImageLocation != null)
                    if (NewImage2)
                    {
                        if (Data.IsFTP == "False")
                        {
                            data.UploadImageOnLocal(pictureBox2, "Item_Image", txtItemcode.Text + "-2-" + Data.id + ".jpg");
                            foreach (string i in Enum.GetNames(typeof(Size1)))
                            {
                                data.UploadImageOnLocal(pictureBox2, "Item_Image", txtItemcode.Text + "-2-" + Data.id + ".jpg", i);
                            }
                        }
                        else
                        {
                            data.UploadFileToFTP(pictureBox2, "Item_Image", txtItemcode.Text + "-2-" + Data.id + ".jpg");
                            foreach (string i in Enum.GetNames(typeof(Size1)))
                            {
                                data.UploadFileToFTP(pictureBox2, "Item_Image", txtItemcode.Text + "-2-" + Data.id + ".jpg", i);
                            }
                        }
                    }

                    // if (pictureBox3.ImageLocation != null)
                    if (NewImage3)
                    {
                        if (Data.IsFTP == "False")
                        {
                            data.UploadImageOnLocal(pictureBox3, "Item_Image", txtItemcode.Text + "-3-" + Data.id + ".jpg");
                            foreach (string i in Enum.GetNames(typeof(Size1)))
                            {
                                data.UploadImageOnLocal(pictureBox3, "Item_Image", txtItemcode.Text + "-3-" + Data.id + ".jpg", i);
                            }
                        }
                        else
                        {
                            data.UploadFileToFTP(pictureBox3, "Item_Image", txtItemcode.Text + "-3-" + Data.id + ".jpg");
                            foreach (string i in Enum.GetNames(typeof(Size1)))
                            {
                                data.UploadFileToFTP(pictureBox3, "Item_Image", txtItemcode.Text + "-3-" + Data.id + ".jpg", i);
                            }
                        }
                    }

                    MessageBox.Show("Record " + btnSave.Text + " Sussessfully");
                    clear();
                }

                else
                {
                    MessageBox.Show("Record Not " + btnSave.Text + " Sussessfully");
                    return;
                }
            }
            catch (Exception exx)
            {
                MessageBox.Show("Error");
                filewrite(exx.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
            filllst();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                query = " select * from tblitem where itemid =" + lst.SelectedValue + "";
                DataSet ds12 = data.getDataSet(query);
                if (ds12.Tables[0].Rows.Count > 0)
                {
                    txtName.Text = ds12.Tables[0].Rows[0]["itemname"].ToString();
                    txtSalePrice1.Text = ds12.Tables[0].Rows[0]["SalePrice1"].ToString();
                    txtSalePrice2.Text = ds12.Tables[0].Rows[0]["SalePrice2"].ToString();
                    txtdes.Text = ds12.Tables[0].Rows[0]["description"].ToString();
                    dtpUnit.Text = ds12.Tables[0].Rows[0]["Unit"].ToString();//CategoryId
                    drpCategory.SelectedValue = ds12.Tables[0].Rows[0]["CategoryId"].ToString();//
                    txtCGST.Text = ds12.Tables[0].Rows[0]["CGST"].ToString();
                    txtSGST.Text = ds12.Tables[0].Rows[0]["SGST"].ToString();
                    txtIGST.Text = ds12.Tables[0].Rows[0]["IGST"].ToString();
                    txtDisplayOrder.Text = ds12.Tables[0].Rows[0]["DisplayOrder"].ToString();
                    drpGST.SelectedValue = ds12.Tables[0].Rows[0]["Gst_Id"];
                    txtItemcode.Text = ds12.Tables[0].Rows[0]["ItemCode"].ToString();
                    txtMaxQuantity.Text = ds12.Tables[0].Rows[0]["MaxQuantity"].ToString();
                    lblImage1Path.Text = ds12.Tables[0].Rows[0]["ImageName1"].ToString();
                    lblImage2Path.Text = ds12.Tables[0].Rows[0]["ImageName2"].ToString();
                    lblImage3Path.Text = ds12.Tables[0].Rows[0]["ImageName3"].ToString();
                    chkApp.Checked = Convert.ToBoolean(ds12.Tables[0].Rows[0]["IsApp"]);
                    if (Data.IsFTP == "False")
                        data.GetImageOnLocal("Item_Image", ds12.Tables[0].Rows[0]["ImageName1"].ToString(), pictureBox1);
                    else
                        data.GetImageOnServer("Item_Image", ds12.Tables[0].Rows[0]["ImageName1"].ToString(), pictureBox1);

                    if (Data.IsFTP == "False")
                        data.GetImageOnLocal("Item_Image", ds12.Tables[0].Rows[0]["ImageName2"].ToString(), pictureBox2);
                    else
                        data.GetImageOnServer("Item_Image", ds12.Tables[0].Rows[0]["ImageName2"].ToString(), pictureBox2);

                    if (Data.IsFTP == "False")
                        data.GetImageOnLocal("Item_Image", ds12.Tables[0].Rows[0]["ImageName3"].ToString(), pictureBox3);
                    else
                        data.GetImageOnServer("Item_Image", ds12.Tables[0].Rows[0]["ImageName3"].ToString(), pictureBox3);

                    btnSave.Text = "Update";
                    btnDelete.Enabled = true;
                    txtItemcode.ReadOnly = true;
                }
            }
            catch (Exception exx)
            {
                MessageBox.Show("Error");
                filewrite(exx.ToString());
            }
        }

        public static void filewrite(string Whattowrite)
        {
            string path = "";
            try
            {
                string dir = Directory.GetCurrentDirectory() + "/Loger";

                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                path = dir + @"\LogFile" + DateTime.Now.ToString("-yyy-MM-dd") + ".txt";
                using (var sw = File.AppendText(path))
                {
                    sw.WriteLine(Whattowrite + " : " + DateTime.Now.ToShortTimeString());
                }
            }
            catch
            {
                string dir = Directory.GetCurrentDirectory() + "/Loger";

                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                path = dir + @"\LogFile" + DateTime.Now.ToString("-yyy-MM-dd") + ".txt";
                using (var sw = File.AppendText(path))
                {
                    sw.WriteLine(Whattowrite + " : " + DateTime.Now.ToShortTimeString());
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
                else if (e.KeyCode == Keys.A)
                {
                    //   Add();
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

        private void txSearch_TextChanged(object sender, EventArgs e)
        {
            string query1 = " select itemid, (cast(ItemCode as nvarchar(50))+' - '+upper(itemname)) itemname from tblitem where delid=0 and firmid=" + Data.id + "";
            if (txSearch.Text.Trim() != "")
            {
                query1 += " and itemname like '%" + txSearch.Text.Trim() + "%'";
            }
            query1 += " order by Barcode";
            DataSet ds1 = data.getDataSet(query1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                lst.DataSource = ds1.Tables[0];
                lst.DisplayMember = "itemname";
                lst.ValueMember = "itemid";
            }
            else
            {
                lst.DataSource = null;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            NewImage = false;
            string FilePath = "";
            open.Filter = "Image file (*.jpg)|*.jpg|Image file (*.gif)|*.gif|Image file (*.JPEG)|*.jpeg";
            if (open.ShowDialog() == DialogResult.OK)
            {
                filename = System.IO.Path.GetFileName(open.FileName);
                path = System.IO.Path.GetDirectoryName(open.FileName);
                //System.Drawing.Image imageToBeResized = System.Drawing.Image.FromStream(open.InputStream);
                //data.ResizeThumbImages(filename, imageToBeResized, "small", "Item_Image");
                pictureBox1.ImageLocation = path + "/" + filename;
                FilePath = path + "/" + filename;
                NewImage = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.NoImage;
            pictureBox1.ImageLocation = null;
            NewImage = false;
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.NoImage;
            pictureBox2.ImageLocation = null;
            NewImage2 = false;
        }

        private void txtMaxQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            int ch = (int)e.KeyChar;
            if ((ch < 48 || ch > 58) && (ch != 8) && (ch != 46))
                e.KeyChar = '\0';
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            NewImage3 = false;
            string FilePath = "";
            open.Filter = "Image file (*.jpg)|*.jpg|Image file (*.gif)|*.gif|Image file (*.JPEG)|*.jpeg";
            if (open.ShowDialog() == DialogResult.OK)
            {
                filename = System.IO.Path.GetFileName(open.FileName);
                path = System.IO.Path.GetDirectoryName(open.FileName);
                pictureBox3.ImageLocation = path + "/" + filename;
                FilePath = path + "/" + filename;
                NewImage3 = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.NoImage;
            pictureBox3.ImageLocation = null;
            NewImage3 = false;
        }

        private void drpGST_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpGST.SelectedIndex > 0)
            {
                DataSet dsGTS = data.getDataSet("select * from tbl_GSTMaster where Delid=0 and GST_ID=" + drpGST.SelectedValue);
                double gstval = Convert.ToDouble(dsGTS.Tables[0].Rows[0]["GSTValue"]);
                txtCGST.Text = (gstval / 2).ToString("0.00");
                txtSGST.Text = (gstval / 2).ToString("0.00");
                txtIGST.Text = gstval.ToString("0.00");
            }
        }

    }
}