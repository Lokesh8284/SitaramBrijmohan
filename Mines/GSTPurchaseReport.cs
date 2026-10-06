using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WelcomeFabric
{
    public partial class GSTPurchaseReport : Form
    {
        DataSet ds = new DataSet();
        Data data = new Data();
        string query;
        public GSTPurchaseReport()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            query = "select * from  tbl_PurchaseGST where  firmid=" + Data.id + " and sessionid=" + Data.sessionid + "";
            if (dateTimePicker1.Checked == true && dateTimePicker2.Checked == true)
            {
                query += " and chalandate >= cast ('" + data.getDateMMDDYYYY(dateTimePicker1.Text) + "' as datetime) and chalandate <= cast ('" + data.getDateMMDDYYYY(dateTimePicker2.Text) + "'as datetime)";
                //query += " and chalandate='" + dateTimePicker1.Value + "'and chalandate='" + dateTimePicker2.Value + "'";
            }
            else
                query += "  and chalandate <= cast ('" + data.getDateMMDDYYYY(dateTimePicker2.Text) + "' as datetime)";
            //query += " and chalandate='" + dateTimePicker2.Value + "'";

            query += " order by chalandate ";
            ds = data.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdTest.Rows.Clear();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    grdTest.Rows.Add();
                    grdTest.Rows[i].Cells["srno"].Value = grdTest.Rows.Count;
                    grdTest.Rows[i].Cells["InvoiceNo"].Value = ds.Tables[0].Rows[i]["InvoiceNo"].ToString();
                    grdTest.Rows[i].Cells["InvoiceDate"].Value = Convert.ToDateTime(ds.Tables[0].Rows[i]["chalandate"].ToString()).ToString("MM/dd/yyyy");
                    grdTest.Rows[i].Cells["Amount"].Value = ds.Tables[0].Rows[i]["totalamt"].ToString();
                    grdTest.Rows[i].Cells["CGST"].Value = ds.Tables[0].Rows[i]["AddCGST"].ToString();
                    grdTest.Rows[i].Cells["SGST"].Value = ds.Tables[0].Rows[i]["AddSGST"].ToString();
                    grdTest.Rows[i].Cells["IGST"].Value = ds.Tables[0].Rows[i]["AddIGST"].ToString();
                    grdTest.Rows[i].Cells["TaxableValue"].Value = ds.Tables[0].Rows[i]["TotalAfterTax"].ToString();
                }
            }
            else
            {
                grdTest.Rows.Clear();
                MessageBox.Show("Record Not Found");
            }  
        }

        private void GSTPurchaseReport_Load(object sender, EventArgs e)
        {
            label19.Text = Data.Area;
        }
    }
}
