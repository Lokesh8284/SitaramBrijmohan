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
    public partial class RowMaterialRegistrationReport : Form
    {
        Data data = new Data();
        DataSet ds1 = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DataSet ds = new DataSet();
        string query;
        double totAmt1 = 0;
        public RowMaterialRegistrationReport()
        {
            InitializeComponent();
        }

        private void ChallanDetailReport_Load(object sender, EventArgs e)
        {
            label19.Text = Data.Area;
            FillStaff();
            itemname1();
            itemname();
            VehicleFill();
        }
        public void VehicleFill()
        {
            query = "  select *  FROM  tbl_Vehicle ";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["priceid"] = "0";
            newrow["VehicleNo"] = "---Select VehicleNo ---";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                drpVechile.DataSource = ds.Tables[0];
                drpVechile.ValueMember = "priceid";
                drpVechile.DisplayMember = "VehicleNo";
            }
        }
        public void itemname()
        {
            query = " select * from tblitem where firmid=" + Data.id + " order by itemname";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["itemid"] = "0";
            newrow["itemname"] = "---Select Item Name----";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                drpItem.DataSource = ds.Tables[0];
                drpItem.ValueMember = "itemid";
                drpItem.DisplayMember = "itemname";
            }
        }
        public void FillStaff()
        {
            query = " select * from tbllabour where firmid=" + Data.id + " order by labourname";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["lbrid"] = "0";
            newrow["labourname"] = "---Select Labour Name----";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            drpStaff.DataSource = ds.Tables[0];
            drpStaff.DisplayMember = "labourname";
            drpStaff.ValueMember = "lbrid";
        }
        public void itemname1()
        {
            query = " select * from tblitem where firmid=" + Data.id + " order by itemname";
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
        private void btnSearch_Click(object sender, EventArgs e)
        {
            query = " select convert(nvarchar(15), R.Billdate  , 105) as bDate,f.Name,RD.ItemId,RD.StaffId,RD.StaffName,RD.Unit,RD.Item,RD.Quantity,RD.InvoiceNo,RD.date, ";
            query += " RD.InvoiceNo as InvoNo,R.totalunit ,R.firmid,R.sessionid,RD.firmid,RD.sessionid from tbl_RowMaterialNew   R inner join tbl_RowMatarialDetailsNew  RD on R.InvoiceNo=RD.InvoiceNo ";
            query += " inner join  tblfirm f on f.firmid=R.firmid where R.firmid=" + Data.id + " and R.sessionid=" + Data.sessionid + " ";

            if (drpStaff.SelectedIndex > 0)
            {
                query += " and RD.StaffId='" + drpStaff.SelectedValue + "'";
            }
            if (drpitem1.SelectedIndex > 0)
            {
                query += " and RD.ItemId='" + drpitem1.SelectedValue + "'";
            }
            if (dateTimePicker1.Checked == true && dateTimePicker2.Checked == true)
            {
                if (dateTimePicker1.Text == dateTimePicker2.Text)
                {
                    query += " and RD.date='" + data.getDateMMDDYYYY(dateTimePicker1.Text) + "'";
                }
                else
                {
                    query += " and RD.date>='" + Convert.ToDateTime(dateTimePicker1.Text) + "' and RD.date<='" + data.getDateMMDDYYYY(dateTimePicker2.Text) + "'";
                }
            }
            query += " order by RD.date ";
            ds1 = data.getDataSet(query);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                grdTest.Rows.Clear();
                totAmt1 = 0;

                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    grdTest.Rows.Add();
                    grdTest.Rows[i].Cells["sno"].Value = grdTest.Rows.Count;
                    grdTest.Rows[i].Cells["Date"].Value = ds1.Tables[0].Rows[i]["bdate"].ToString();
                    grdTest.Rows[i].Cells["Item"].Value = ds1.Tables[0].Rows[i]["Item"].ToString();
                    grdTest.Rows[i].Cells["Staff"].Value = ds1.Tables[0].Rows[i]["StaffName"].ToString();
                    grdTest.Rows[i].Cells["qty"].Value = ds1.Tables[0].Rows[i]["Quantity"].ToString();
                }
                ds = data.getDataSet(query);
            }
            else
            {
                grdTest.Rows.Clear();
                MessageBox.Show("Record Not Found");
            }
        }

        private void grdTest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Data.query = query;
            Rowrep rep = new Rowrep();
            rep.ShowDialog();
        }

        private void drpPatientId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                this.ProcessTabKey(true);
            }
        }

        private void txttotwt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtTotAmt_TextChanged(object sender, EventArgs e)
        {

        }
        string query1 = "";
        private void button2_Click(object sender, EventArgs e)
        {
            query1 = "  select convert(nvarchar(15), T.Billdate  , 105) as bDate,Td.ItemId as TItemId ,f.Name ,TD.transid ";
            query1 += " ,TD.InvoiceNo as InvoNo,TD.Quantity as Qty,TD.ItemName,TD.unit as Unt,T.totalunit as Totamt,TD.VehicleNo ,T.firmid,T.sessionid,TD.firmid,TD.sessionid from tbl_Transpoter  T  ";
            query1 += " inner Join tbl_TransporterDetails TD on TD.InvoiceNo=T.InvoiceNo  inner join  tblfirm f on f.firmid=T.firmid ";
            query1 += " where T.firmid=" + Data.id + " and T.sessionid=" + Data.sessionid + " ";

            if (drpVechile.SelectedIndex > 0)
            {
                query1 += " and TD.VehicleNo='" + drpVechile.Text + "'";
            }
            if (drpItem.SelectedIndex > 0)
            {
                query1 += " and Td.ItemId='" + drpItem.SelectedValue + "'";
            }

            if (dateTimePicker1.Checked == true && dateTimePicker2.Checked == true)
            {
                if (dateTimePicker1.Text == dateTimePicker2.Text)
                {
                    query1 += " and TD.date='" + data.getDateMMDDYYYY(dateTimePicker1.Text) + "'";
                }
                else
                {
                    query1 += " and TD.date>='" + Convert.ToDateTime(dateTimePicker1.Text) + "' and TD.date<='" + data.getDateMMDDYYYY(dateTimePicker2.Text) + "'";
                }
            }
            query1 += " order by TD.date ";
            ds1 = data.getDataSet(query1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                totAmt1 = 0;

                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["Sno1"].Value = dataGridView1.Rows.Count;
                    dataGridView1.Rows[i].Cells["Date1"].Value = ds1.Tables[0].Rows[i]["bdate"].ToString();
                    dataGridView1.Rows[i].Cells["Item1"].Value = ds1.Tables[0].Rows[i]["ItemName"].ToString();
                    dataGridView1.Rows[i].Cells["Vechicel"].Value = ds1.Tables[0].Rows[i]["VehicleNo"].ToString();
                    dataGridView1.Rows[i].Cells["Quantity1"].Value = ds1.Tables[0].Rows[i]["Qty"].ToString();
                }
                ds = data.getDataSet(query1);
            }
            else
            {
                dataGridView1.Rows.Clear();
                MessageBox.Show("Record Not Found");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Data.query = query1;
            Rowrep1 rep = new Rowrep1();
            rep.ShowDialog();
        }
    }


}