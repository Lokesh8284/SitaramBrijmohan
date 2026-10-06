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
    public partial class ItemReport : Form
    {
        Data data = new Data();
        DataSet ds1 = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DataSet ds = new DataSet();
        string query;
        double totAmt1 = 0;

        public ItemReport()
        {
            InitializeComponent();
        }

        private void ChallanDetailReport_Load(object sender, EventArgs e)
        {
            label19.Text = Data.Area;
            itemname1(); 
        }
        
        public void itemname1()
        {
            query = " select * from tblitem where  firmid=" + Data.id + " order by itemname";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["itemid"] = "0";
            newrow["itemname"] = "---Select Item Name----";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                drpitem1.DataSource = ds.Tables[0];
                drpitem1.ValueMember = "itemid";
                drpitem1.DisplayMember = "itemname";
            }
        }
        private void grdTest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btnClose_Click(object sender, EventArgs e)
        {

        }
        private void drpPatientId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                this.ProcessTabKey(true);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //query = " select convert(nvarchar(15), R.Billdate  , 105) as bDate,f.Name,RD.ItemId,RD.StaffId,RD.StaffName,RD.Unit,RD.Item,RD.Quantity,RD.InvoiceNo,RD.date, ";
            //query += " RD.InvoiceNo as InvoNo,R.totalunit ,R.firmid,R.sessionid,RD.firmid,RD.sessionid from tbl_RowMaterialNew   R inner join tbl_RowMatarialDetailsNew  RD on R.InvoiceNo=RD.InvoiceNo ";
            //query += " inner join  tblfirm f on f.firmid=R.firmid where R.firmid=" + Data.id + " and R.sessionid=" + Data.sessionid + " ";
            grdTest.DataSource = null;
            query = "SELECT (ROW_NUMBER() OVER(ORDER BY GCD.itemid ASC))SNo, GCD.itemid, I.itemname,convert(nvarchar(11),GCD.chalandate ,103) as Date,   SUM(GCD.qty) AS qty,GCD.price, SUM(GCD.TaxableValue) AS TaxableValue, SUM(GCD.CGSTAmount) AS CGSTAmount, SUM(GCD.SGSTAmount) AS SGSTAmount, SUM(GCD.IGSTAmount) AS IGSTAmount, SUM(GCD.GrossTotal) AS GrossTotal ";
            query += " FROM tbl_GstChallanDetails AS GCD INNER JOIN tblitem AS I ON GCD.itemid = I.itemid where EFLAG='S' ";

            if (drpitem1.SelectedIndex > 0)
            {
                query += " and GCD.itemid ='" + drpitem1.SelectedValue + "'";
            }
            if (dateTimePicker1.Checked == true && dateTimePicker2.Checked == true)
            {
                if (dateTimePicker1.Text == dateTimePicker2.Text)
                {
                    query += " and cast(GCD.chalandate as date) = '" + data.getDateMMDDYYYY(dateTimePicker1.Text) + "'";
                }
                else
                {
                    query += " and and cast(GCD.chalandate as date) between '" + Convert.ToDateTime(dateTimePicker1.Text) + "' and '" + data.getDateMMDDYYYY(dateTimePicker2.Text) + "'";
                }
            }
            query += "  group by GCD.chalandate, GCD.price,GCD.itemid ,I.itemname order by GCD.itemid ";
            ds1 = data.getDataSet(query);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                //grdTest.Rows.Clear();
                //totAmt1 = 0;

                //for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                //{
                //    grdTest.Rows.Add();
                //    grdTest.Rows[i].Cells["sno"].Value = grdTest.Rows.Count;
                //    grdTest.Rows[i].Cells["Date"].Value = ds1.Tables[0].Rows[i]["bdate"].ToString();
                //    grdTest.Rows[i].Cells["Item"].Value = ds1.Tables[0].Rows[i]["Item"].ToString();
                //    grdTest.Rows[i].Cells["Staff"].Value = ds1.Tables[0].Rows[i]["StaffName"].ToString();
                //    grdTest.Rows[i].Cells["qty"].Value = ds1.Tables[0].Rows[i]["Quantity"].ToString();
                //}
                //ds = data.getDataSet(query);
                grdTest.AutoGenerateColumns = false;
                grdTest.DataSource = ds1.Tables[0];
            }
            else
            {
              //  grdTest.Rows.Clear();
                grdTest.DataSource = null;
                MessageBox.Show("Record Not Found");
            }
            getsum();
        }

        private void getsum()
        {
            double totAmt = 0;
            double totCGST = 0;
            double totSGST = 0;
            double totIGST = 0;
            double netTotal = 0;
            double qty = 0;

            for (int i = 0; i < grdTest.Rows.Count; i++)
            {
                totAmt += Convert.ToDouble(grdTest.Rows[i].Cells["TaxableValue"].Value.ToString());
                totCGST += Convert.ToDouble(grdTest.Rows[i].Cells["CGST"].Value.ToString());
                totSGST += Convert.ToDouble(grdTest.Rows[i].Cells["SGST"].Value.ToString());
                totIGST += Convert.ToDouble(grdTest.Rows[i].Cells["IGST"].Value.ToString());
                netTotal += Convert.ToDouble(grdTest.Rows[i].Cells["netTotal"].Value.ToString());
                qty += Convert.ToDouble(grdTest.Rows[i].Cells["qty"].Value.ToString());
            }
            txtTotalQty.Text = qty.ToString();
            txtTaxable.Text = totAmt.ToString("0.00");
            txtCGST.Text = totCGST.ToString("0.00");
            txtSGST.Text = totSGST.ToString("0.00");
            txtIGST.Text = totIGST.ToString("0.00");
            txtNetTotal.Text = netTotal.ToString("0.00");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Data.query = query;
            Rowrep rep = new Rowrep();
            rep.ShowDialog();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}