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
    public partial class TransporterReport : Form
    {
        Data data = new Data();
        DataSet ds1 = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DataSet ds = new DataSet();
        string query;
        double totAmt1 = 0;
        public TransporterReport()
        {
            InitializeComponent();
        }

        private void ChallanDetailReport_Load(object sender, EventArgs e)
        {
            label19.Text = Data.Area;
            filltransporter();
        }
        public void filltransporter()
        {
            query = " select * from tbl_Transport where  firmid=" + Data.id + " order by TransportName";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["lbrid"] = "0";
            newrow["TransportName"] = "---Select Transporter ----";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            drplbr.DataSource = ds.Tables[0];
            drplbr.DisplayMember = "TransportName";
            drplbr.ValueMember = "lbrid";
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
                dtpVehicleNo.DataSource = ds.Tables[0];
                dtpVehicleNo.ValueMember = "priceid";
                dtpVehicleNo.DisplayMember = "VehicleNo";
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

        string query1 = "";
        private void button2_Click(object sender, EventArgs e)
        {
            query1 = " select convert(nvarchar(15), T.BillDate,103) as bdate ,T.BillDate ,T.InvoiceNo,TD.ItemName,TD.Transporter,TD.unit,TD.VehicleNo,TD.Quantity as qty   ";
            query1 += " ,TD.transid from tbl_Transpoter T inner join tbl_TransporterDetails TD on T.InvoiceNo = TD.InvoiceNo ";
            query1 += " where T.firmid=" + Data.id + " and T.sessionid=" + Data.sessionid + " ";

            if (drplbr.SelectedIndex > 0)
            {
                query1 += " and TD.transid='" + drplbr.SelectedValue + "'";
            }
            if (dtpVehicleNo.SelectedIndex > 0)
            {
                query1 += " and TD.VehicleNo='" + dtpVehicleNo.Text + "'";
            }
            if (dateTimePicker3.Checked == true && dateTimePicker4.Checked == true)
            {
                if (dateTimePicker3.Text == dateTimePicker4.Text)
                {
                    query1 += " and  T.BillDate='" + data.getDateMMDDYYYY(dateTimePicker4.Text) + "'";
                }
                else
                {
                    query1 += " and   T.BillDate>='" + Convert.ToDateTime(dateTimePicker3.Text) + "' and   T.BillDate<='" + data.getDateMMDDYYYY(dateTimePicker4.Text) + "'";
                }
            }
            query1 += " order by T.BillDate ";
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
                    dataGridView1.Rows[i].Cells["Quantity1"].Value = ds1.Tables[0].Rows[i]["qty"].ToString();
                    dataGridView1.Rows[i].Cells["Transporter"].Value = ds1.Tables[0].Rows[i]["Transporter"].ToString();
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
            TransporterRep rep = new TransporterRep();
            rep.ShowDialog();
        }

        private void drplbr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drplbr.SelectedIndex > 0)
            {
                query = "  SELECT tbl_Vehicle.VehicleNo,tbl_Transport.lbrid FROM (tbl_Vehicle INNER JOIN tbl_Transport ON tbl_Vehicle.clientid = tbl_Transport.lbrid)";
                query += " where tbl_Transport.lbrid=" + drplbr.SelectedValue;
                ds = data.getDataSet(query);

                DataRow newrow = ds.Tables[0].NewRow();
                newrow["lbrid"] = "0";
                newrow["VehicleNo"] = "---Select VehicleNo ---";
                ds.Tables[0].Rows.InsertAt(newrow, 0);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dtpVehicleNo.DataSource = ds.Tables[0];
                    dtpVehicleNo.DisplayMember = "VehicleNo";
                }
            }
        }
    }


}