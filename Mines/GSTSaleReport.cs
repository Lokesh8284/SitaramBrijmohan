using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WelcomeFabric;

namespace WelcomeFabric
{
    public partial class GSTSaleReport : Form
    {
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        Data data = new Data();
        string query;
        string _type = "";
        string query1;
        public GSTSaleReport()
        {
            InitializeComponent();
        }
        public GSTSaleReport(string type)
        {
            InitializeComponent();
            this._type = type;
            if (type.ToUpper() == "P")
            {
                lblSummary.Text = "GST Purchase Report";
                lblDetails.Text = "GST Purchase Detail Report";
            }
            else
            {
                lblSummary.Text = "GST Sale Report";
                lblDetails.Text = "GST Sale Detail Report";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            query = "select tbl_GstChallan.* from  tbl_GstChallan where Delid=0 and EFlag='" + _type + "' and  firmid=" + Data.id + " and sessionid=" + Data.sessionid + "";
            if (dateTimePicker1.Checked == true && dateTimePicker2.Checked == true)
            {
                query += " and CONVERT(date,chalandate) >= cast ('" + data.getDateMMDDYYYY(dateTimePicker1.Text) + "' as datetime) and CONVERT(date,chalandate)  <= cast ('" + data.getDateMMDDYYYY(dateTimePicker2.Text) + "'as datetime)";
            }
            else
                query += "  and CONVERT(date,chalandate) <= cast ('" + data.getDateMMDDYYYY(dateTimePicker2.Text) + "' as datetime)";

            query += " order by chalandate ";
            ds = data.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdTest.Rows.Clear();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    grdTest.Rows.Add();
                    grdTest.Rows[i].Cells["srno"].Value = grdTest.Rows.Count;
                    grdTest.Rows[i].Cells["InvoiceNo"].Value = ds.Tables[0].Rows[i]["chalanno"].ToString();
                    grdTest.Rows[i].Cells["InvoiceDate"].Value = Convert.ToDateTime(ds.Tables[0].Rows[i]["chalandate"].ToString()).ToString("dd/MM/yyyy");
                    grdTest.Rows[i].Cells["Amount"].Value = ds.Tables[0].Rows[i]["totalamt"].ToString();
                    grdTest.Rows[i].Cells["CGST"].Value = ds.Tables[0].Rows[i]["AddCGSTAmt"].ToString();
                    grdTest.Rows[i].Cells["SGST"].Value = ds.Tables[0].Rows[i]["AddSGSTAmt"].ToString();
                    grdTest.Rows[i].Cells["IGST"].Value = ds.Tables[0].Rows[i]["AddIGSTAmt"].ToString();
                    grdTest.Rows[i].Cells["TaxableValue"].Value = ds.Tables[0].Rows[i]["TotalTaxAmt"].ToString();
                }
                amt();
            }
            else
            {
                grdTest.Rows.Clear();
                MessageBox.Show("Record Not Found");
            }
        }

        private void amt()
        {
            txtSGST.Text = grdTest.Rows.Cast<DataGridViewRow>().Sum(d => Convert.ToDouble(d.Cells["SGST"].Value)).ToString("0.00");
            txtCGST.Text = grdTest.Rows.Cast<DataGridViewRow>().Sum(d => Convert.ToDouble(d.Cells["CGST"].Value)).ToString("0.00");
            txtIGST.Text = grdTest.Rows.Cast<DataGridViewRow>().Sum(d => Convert.ToDouble(d.Cells["IGST"].Value)).ToString("0.00");
            txtAmt.Text = grdTest.Rows.Cast<DataGridViewRow>().Sum(d => Convert.ToDouble(d.Cells["Amount"].Value)).ToString("0.00");
            txtTotal.Text = grdTest.Rows.Cast<DataGridViewRow>().Sum(d => Convert.ToDouble(d.Cells["TaxableValue"].Value)).ToString("0.00");
            txtSGST1.Text = grdTest1.Rows.Cast<DataGridViewRow>().Sum(d => Convert.ToDouble(d.Cells["SGST1"].Value)).ToString("0.00");
            txtCGST1.Text = grdTest1.Rows.Cast<DataGridViewRow>().Sum(d => Convert.ToDouble(d.Cells["CGST1"].Value)).ToString("0.00");
            txtIGST1.Text = grdTest1.Rows.Cast<DataGridViewRow>().Sum(d => Convert.ToDouble(d.Cells["IGST1"].Value)).ToString("0.00");
            txtAmt1.Text = grdTest1.Rows.Cast<DataGridViewRow>().Sum(d => Convert.ToDouble(d.Cells["Amount1"].Value)).ToString("0.00");
            txtTotal1.Text = grdTest1.Rows.Cast<DataGridViewRow>().Sum(d => Convert.ToDouble(d.Cells["TaxableValue1"].Value)).ToString("0.00");
        }

        private void GSTSaleReport_Load(object sender, EventArgs e)
        {
            label19.Text = label6.Text = Data.Area;
            drpGST.SelectedIndex = 0;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Data.query = query;
            GstReportSale rep = new GstReportSale();
            rep.ShowDialog();
        }

        private void btnSearch1_Click(object sender, EventArgs e)
        {
            query1 = "select tbl_GstChallanDetails.* from tbl_GstChallanDetails where Delid=0 and EFlag='" + _type + "' and  firmid=" + Data.id + " and sessionid=" + Data.sessionid + "";
            if (drpGST.SelectedIndex > 0)
            {
                double a, b;
                a = Convert.ToDouble(drpGST.Text);
                b = a / 2;
                query1 += " and CGST='" + b + "'";
            }
            if (dateTimePicker4.Checked == true && dateTimePicker3.Checked == true)
            {
                query1 += " and CONVERT(date,chalandate) between '" + data.getDateMMDDYYYY(dateTimePicker4.Text) + "' and   '" + data.getDateMMDDYYYY(dateTimePicker3.Text) + "'";
            }
            query1 += " order by chalandate ";
            ds1 = data.getDataSet(query1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                grdTest1.Rows.Clear();
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    grdTest1.Rows.Add();
                    grdTest1.Rows[i].Cells["srno1"].Value = grdTest1.Rows.Count;
                    grdTest1.Rows[i].Cells["InvoiceNo1"].Value = ds1.Tables[0].Rows[i]["chalanno"].ToString();
                    grdTest1.Rows[i].Cells["InvoiceDate1"].Value = Convert.ToDateTime(ds1.Tables[0].Rows[i]["chalandate"].ToString()).ToString("dd/MM/yyyy");
                    grdTest1.Rows[i].Cells["Amount1"].Value = ds1.Tables[0].Rows[i]["TaxableValue"].ToString();
                    grdTest1.Rows[i].Cells["CGST1"].Value = ds1.Tables[0].Rows[i]["CGSTAmount"].ToString();
                    grdTest1.Rows[i].Cells["SGST1"].Value = ds1.Tables[0].Rows[i]["SGSTAmount"].ToString();
                    grdTest1.Rows[i].Cells["IGST1"].Value = ds1.Tables[0].Rows[i]["IGSTAmount"].ToString();
                    grdTest1.Rows[i].Cells["TaxableValue1"].Value = ds1.Tables[0].Rows[i]["GrossTotal"].ToString();
                    grdTest1.Rows[i].Cells["GST"].Value = drpGST.Text;
                }
                amt();
            }
            else
            {
                grdTest1.Rows.Clear();
                MessageBox.Show("Record Not Found");
            }
        }

        private void btnPrint1_Click(object sender, EventArgs e)
        {
            Data.query = query1;
            GstReportSale1 rep = new GstReportSale1();
            rep.ShowDialog();
        }
    }
}
