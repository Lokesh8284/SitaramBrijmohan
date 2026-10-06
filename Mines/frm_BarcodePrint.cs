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
    public partial class frm_BarcodePrint : Form
    {
        Data data = new Data();

        public frm_BarcodePrint()
        {
            InitializeComponent();
        }

        private void frm_BarcodePrint_Load(object sender, EventArgs e)
        {
            FillBarcode();
        }

        public void FillBarcode()
        {
            DataSet ds = data.getDataSet("select * from tblItem where delid=0");
            comboBox1.DataSource = ds.Tables[0];
            comboBox1.DisplayMember = "Barcode";
            comboBox1.ValueMember = "itemid";
        }
        int currow;

        private void button1_Click(object sender, EventArgs e)
        {
            dgv.Rows.Add();
            currow = dgv.Rows.Count - 1;
            dgv.Rows[currow].Cells["srno"].Value = currow + 1;
            dgv.Rows[currow].Cells["Barcode"].Value = comboBox1.Text;
            dgv.Rows[currow].Cells["ProductId"].Value = comboBox1.SelectedValue;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int idx = 0;
            string str = "Select * from tblitem where 1=1  ";
            foreach (DataGridViewRow dr11 in dgv.Rows)
            {
                if (idx == 0)
                {
                    str += "  and tblitem.Delid=0 and tblitem.itemid=" + dr11.Cells["ProductId"].Value + " ";
                }
                else
                {
                    str += "  OR tblitem.itemid=" + dr11.Cells["ProductId"].Value.ToString();
                }
                idx++;
            }
            SqlDataAdapter sda = new SqlDataAdapter(str, data.conString);
            Report.DataSet1 ds = new WelcomeFabric.Report.DataSet1();
            sda.Fill(ds, "tbl_Product");
            CrystalDecisions.CrystalReports.Engine.ReportDocument repdoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            repdoc = new Report.BarcodePrint2();
            repdoc.SetDataSource(ds);
            crystalReportViewer1.ReportSource = repdoc;

        }
        private void button3_Click(object sender, EventArgs e)
        {
            dgv.Rows.Clear();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
