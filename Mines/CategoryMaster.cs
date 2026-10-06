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
    public partial class CategoryMaster : Form
    {
        OpenFileDialog open = new OpenFileDialog();
        String filename = null;
        String path = null;
        byte[] image = null;
        SqlCommand cmd = new SqlCommand();
        Data data = new Data();
        DataSet ds = new DataSet();
        string query;
        bool NewImage = false;

        public CategoryMaster()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }

        private void save()
        {
            if (drpSupplier.SelectedIndex == 0)
            {
                MessageBox.Show("Select Supplier");
                drpSupplier.Focus();
                return;
            }
            if (txtCategoryName.Text == "")
            {
                MessageBox.Show("Enter Category Name");
                txtCategoryName.Focus();
                return;
            }
            if (data.Exist("select CategoryName from tblCategory where delid=0 and CategoryName='" + txtCategoryName.Text + "' and  CategoryId!='" + lst.SelectedValue + "' "))
            {
                MessageBox.Show("Category Name Already Exists");
                txtCategoryName.Focus();
                return;
            }
            if (btnSave.Text == "Save")
            {
                query = "insert into tblCategory(CategoryName,Description,ImageName,DisplayOrder,firmid,IsApp, Supplier) values (@CategoryName,@Description,@ImageName,@DisplayOrder,@firmid,@IsApp,@Supplier)";
            }
            else
            {
                query = "update tblCategory set CategoryName=@CategoryName,Description=@Description,ImageName=@ImageName,IsSync=0,DisplayOrder=@DisplayOrder,IsApp=@IsApp,Supplier=@Supplier where CategoryId='" + lst.SelectedValue + "'  ";
            }
            cmd.CommandText = query;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Supplier", drpSupplier.SelectedValue);
            cmd.Parameters.AddWithValue("@CategoryName", txtCategoryName.Text);
            cmd.Parameters.AddWithValue("@DisplayOrder", txtDisplayOrder.Text);
            cmd.Parameters.AddWithValue("@Description", txtCategoryDescription.Text);
            cmd.Parameters.AddWithValue("@IsApp", chkApp.Checked);
            cmd.Parameters.AddWithValue("@firmid", Data.id);
            if (btnSave.Text == "Save")
            {
                cmd.Parameters.AddWithValue("@ImageName", (pictureBox1.ImageLocation != null) ? txtCategoryName.Text + ".jpg" : "NoImage.jpg");
            }
            else
            {
                cmd.Parameters.AddWithValue("@ImageName", (NewImage == true) ? ((pictureBox1.ImageLocation != null) ? txtCategoryName.Text + ".jpg" : "NoImage.jpg") : lblImage1Path.Text);
            }

            //  cmd.Parameters.AddWithValue("@ImageName", (pictureBox1.ImageLocation != null) ? txtCategoryName.Text + ".jpg" : "NoImage.jpg");
            if (data.executeCommand(cmd) == 0)
            {
                if (NewImage)
                {
                    if (Data.IsFTP == "False")
                        data.UploadImageOnLocal(pictureBox1, "Category_Image", txtCategoryName.Text + ".jpg");
                    else
                        data.UploadFileToFTP(pictureBox1, "Category_Image", txtCategoryName.Text + ".jpg");
                }
            }
            filllst();
            clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void clear()
        {
            txtCategoryDescription.Text = "";
            txtCategoryName.Text = "";
            txtDisplayOrder.Text = "0";
            pictureBox1.Image = Properties.Resources.NoImage;
            pictureBox1.ImageLocation = null;
            btnSave.Text = "Save";
            fillsupllier();
            filllst();
            drpSupplier.SelectedIndex = 0;
            chkApp.Checked = false;
            btnDelete.Enabled = false;
            lblImage1Path.Text = "";
            NewImage = false;
        }

        private void fillsupllier()
        {
            DataSet dss = data.getDataSet("select * from tblclient where delid=0 and firmid=" + Data.id + " and partyType='Supplier'");
            DataRow newrow = dss.Tables[0].NewRow();
            newrow["id"] = "0";
            newrow["compname"] = "---Select Supplier----";
            dss.Tables[0].Rows.InsertAt(newrow, 0);
            drpSupplier.DataSource = dss.Tables[0];
            drpSupplier.DisplayMember = "compname";
            drpSupplier.ValueMember = "id";
        }

        private void UnitMaster_Load(object sender, EventArgs e)
        {
            clear();
        }

        public void filllst()
        {
            query = " select * from tblCategory where delid=0 order by CategoryName asc";
            ds = data.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lst.DataSource = ds.Tables[0];
                lst.DisplayMember = "CategoryName";
                lst.ValueMember = "CategoryId";
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
            query = "select * from tblCategory where CategoryId='" + lst.SelectedValue + "'";
            ds = data.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                drpSupplier.SelectedValue = ds.Tables[0].Rows[0]["Supplier"].ToString();
                txtCategoryName.Text = ds.Tables[0].Rows[0]["CategoryName"].ToString();
                txtDisplayOrder.Text = ds.Tables[0].Rows[0]["DisplayOrder"].ToString();
                txtCategoryDescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();
                lblImage1Path.Text = ds.Tables[0].Rows[0]["ImageName"].ToString();
                chkApp.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsApp"]);
                if (Data.IsFTP == "False")
                    data.GetImageOnLocal("Category_Image", ds.Tables[0].Rows[0]["ImageName"].ToString(), pictureBox1);
                else
                    data.GetImageOnServer("Category_Image", ds.Tables[0].Rows[0]["ImageName"].ToString(), pictureBox1);
                btnSave.Text = "Update";
                btnDelete.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            query = "update tblCategory set delid=1,IsSync=0 where CategoryId='" + lst.SelectedValue + "' ";
            data.executeCommand(query);
            filllst();
            clear();
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
            pictureBox1.Image = null;
            NewImage = false;
        }
    }
}
