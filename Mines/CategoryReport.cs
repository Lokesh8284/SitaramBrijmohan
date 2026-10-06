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
    public partial class CategoryReport : Form
    {
        string Query = "";
        Data data = new Data();
        DataSet ds1 = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DataSet ds = new DataSet();

        public CategoryReport()
        {
            InitializeComponent();
        }

        private void CategoryReport_Load(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            fillsupllier();
            BindCategory();
            dgv.DataSource = null;
        }

        private void FillList()
        {
            Query = "SELECT ti.itemname, tc.CategoryName, c.compname as supplier, ti.MRP, ti.Unit, ti.DisplayOrder, ti.MaxQuantity,ti.ImageName1, 'View' as 'View' FROM tblitem AS ti INNER JOIN tblCategory AS tc ON ti.CategoryId = tc.CategoryId LEFT join tblclient c on c.id=tc.supplier where ti.delId=0 and ti.firmid=" + Data.id + "";
            if (drpCategory.SelectedIndex > 0)
            {
                Query += " and ti.CategoryId=" + drpCategory.SelectedValue + "";
            }
            if (drpSupplier.SelectedIndex > 0)
            {
                Query += " and tc.Supplier=" + drpSupplier.SelectedValue + "";
            }
            Query += " order by tc.CategoryName,ti.ItemName";
            ds1 = data.getDataSet(Query);

            dgv.AutoGenerateColumns = false;
            dgv.DataSource = ds1.Tables[0];

        }

        private void BindCategory()
        {
            Query = " select * from tblCategory where delid=0 ";
            if (drpSupplier.SelectedIndex > 0)
            {
                Query += " and Supplier=" + drpSupplier.SelectedValue;
            }
            Query += " order by CategoryName";
            ds = data.getDataSet(Query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["CategoryId"] = "0";
            newrow["CategoryName"] = "Select Category";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            drpCategory.DataSource = ds.Tables[0];
            drpCategory.DisplayMember = "CategoryName";
            drpCategory.ValueMember = "CategoryId";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FillList();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int currow = e.RowIndex;
                if (dgv.Rows[currow].Cells[e.ColumnIndex].OwningColumn.Name == "View")
                {
                    string FolderName = "Item_Image";
                    string _ImageName = dgv.Rows[currow].Cells["ImageName1"].Value.ToString();
                    string _DesignName = dgv.Rows[currow].Cells["itemname"].Value.ToString();

                    Show_Image frm = new Show_Image(FolderName, _ImageName, _DesignName);
                    frm.Show();
                }
            }
        }

        private void drpSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCategory();
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
    }
}
