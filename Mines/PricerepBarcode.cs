using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Data.SqlClient;
using WelcomeFabric;
namespace WelcomeFabric
{
    public partial class PricerepBarcode : Form
    {
        Data data = new Data();
        string query = "";
        public PricerepBarcode()
        {
            InitializeComponent();
        }
        private void pricerep_Load(object sender, EventArgs e)
        {
            dgv.Rows.Clear();
            query = "select * from tblitem ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgv.Rows.Clear();
            // string query = "select * from tblitem where firmid='" + Data.id + "'";
            DataSet ds = data.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dgv.Rows.Add();
                    int currow = dgv.Rows.Count - 1;
                    dgv.Rows[currow].Cells["SNo"].Value = currow + 1;
                    dgv.Rows[currow].Cells["ItemName"].Value = dr["ItemName"].ToString();
                    dgv.Rows[currow].Cells["Barcode"].Value = dr["Barcode"].ToString();
                    dgv.Rows[currow].Cells["Unit"].Value = dr["Unit"].ToString();
                    dgv.Rows[currow].Cells["Price"].Value = dr["Price"].ToString();
                }
            }
            else
            {
                dgv.Rows.Clear();
                MessageBox.Show("Record Not Found");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Data.query = query;
            PrintPreview frm = new PrintPreview();
            WelcomeFabric.Report.BarcodePrint reps = new WelcomeFabric.Report.BarcodePrint();
            SqlDataAdapter adp = new SqlDataAdapter(Data.query, data.conString);
            WelcomeFabric.Report.DataSet2 ds = new WelcomeFabric.Report.DataSet2();
            adp.Fill(ds, "Barcode");
            reps.SetDataSource(ds);
            frm.crystalReportViewer1.ReportSource = reps;
            frm.crystalReportViewer1.Dock = DockStyle.Fill;
            frm.ShowDialog();
        }
    }
}