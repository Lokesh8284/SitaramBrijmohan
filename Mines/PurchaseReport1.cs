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
    public partial class PurchaseReport1 : Form
    {
        string query;
        DataSet ds = new DataSet();
        Data data = new Data();
        public PurchaseReport1()
        {
            InitializeComponent();
        }

        private void PurchaseReport1_Load(object sender, EventArgs e)
        {
            fillpartyname();
            label19.Text = Data.Area;
        }
        public void fillpartyname()
        {
            query = " select * from tblclient where firmid=" + Data.id + " and PartyType='Vendor' order by name";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["id"] = "0";
            newrow["compname"] = "---Select Party Name----";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            drpPatientId.DataSource = ds.Tables[0];
            drpPatientId.DisplayMember = "compname";
            drpPatientId.ValueMember = "id";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            query = "SELECT tblclient.compname,tbl_PurchaseDtailsGST.chalanno, tbl_PurchaseDtailsGST.price, tbl_PurchaseDtailsGST.chalandate, tbl_PurchaseDtailsGST.amount, tbl_PurchaseDtailsGST.qty, tbl_PurchaseDtailsGST.Unit, tbl_PurchaseDtailsGST.ItemName, tbl_PurchaseDtailsGST.TaxableUalue, tbl_PurchaseDtailsGST.CGST, tbl_PurchaseDtailsGST.SGST,  tbl_PurchaseDtailsGST.IGST, tbl_PurchaseDtailsGST.TotalTaxaValue";
            query += " FROM tbl_PurchaseDtailsGST INNER JOIN tblclient ON tbl_PurchaseDtailsGST.clientid = tblclient.id INNER JOIN tblfirm ON tbl_PurchaseDtailsGST.firmid = tblfirm.firmid INNER JOIN tblsession ON tbl_PurchaseDtailsGST.sessionid = tblsession.sessionid where  tbl_PurchaseDtailsGST.firmid=" + Data.id + " and tbl_PurchaseDtailsGST.sessionid=" + Data.sessionid + "";
            if (drpPatientId.SelectedIndex > 0)
                query += "and tbl_PurchaseDtailsGST.clientid =" + drpPatientId.SelectedValue + "";
            //else
            //    query += "tbl_PurchaseDtailsGST.clientid like'%'";
            if (dateTimePicker1.Checked == true && dateTimePicker2.Checked == true)
            {
                query += " and tbl_PurchaseDtailsGST.chalandate >= cast ('" + data.getDateMMDDYYYY(dateTimePicker1.Text) + "' as datetime) and tbl_PurchaseDtailsGST.chalandate <= cast ('" + data.getDateMMDDYYYY(dateTimePicker2.Text) + "'as datetime)";
                //query += " and chalandate='" + dateTimePicker1.Value + "'and chalandate='" + dateTimePicker2.Value + "'";
            }
            else
                query += "  and tbl_PurchaseDtailsGST.chalandate <= cast ('" + data.getDateMMDDYYYY(dateTimePicker2.Text) + "' as datetime)";
            //query += " and chalandate='" + dateTimePicker2.Value + "'";

            query += " order by tbl_PurchaseDtailsGST.chalandate ";
            ds = data.getDataSet(query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdTest.Rows.Clear();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    grdTest.Rows.Add();
                    grdTest.Rows[i].Cells["srno"].Value = grdTest.Rows.Count;
                    //grdTest.Rows[i].Cells["InvoiceNo"].Value = ds.Tables[0].Rows[i]["InvoiceNo"].ToString();
                    grdTest.Rows[i].Cells["Date"].Value = Convert.ToDateTime(ds.Tables[0].Rows[i]["chalandate"].ToString()).ToString("MM/dd/yyyy");
                    grdTest.Rows[i].Cells["Amount"].Value = ds.Tables[0].Rows[i]["TaxableUalue"].ToString();
                    grdTest.Rows[i].Cells["CGST"].Value = ds.Tables[0].Rows[i]["CGST"].ToString();
                    grdTest.Rows[i].Cells["SGST"].Value = ds.Tables[0].Rows[i]["SGST"].ToString();
                    grdTest.Rows[i].Cells["IGST"].Value = ds.Tables[0].Rows[i]["IGST"].ToString();
                    grdTest.Rows[i].Cells["Vendor"].Value = ds.Tables[0].Rows[i]["compname"].ToString();
                    grdTest.Rows[i].Cells["Item"].Value = ds.Tables[0].Rows[i]["ItemName"].ToString();
                    grdTest.Rows[i].Cells["Qty"].Value = ds.Tables[0].Rows[i]["qty"].ToString();
                    grdTest.Rows[i].Cells["Unit"].Value = ds.Tables[0].Rows[i]["Unit"].ToString();
                    grdTest.Rows[i].Cells["Rate"].Value = ds.Tables[0].Rows[i]["price"].ToString();
                    grdTest.Rows[i].Cells["TotalValue"].Value = ds.Tables[0].Rows[i]["TotalTaxaValue"].ToString();
                }
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
    }
}
