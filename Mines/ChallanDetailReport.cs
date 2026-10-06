using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq;
 
namespace WelcomeFabric
{
    public partial class ChallanDetailReport : Form
    {
        #region Declaration
        Data data = new Data();
        DataSet ds1 = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DataSet ds = new DataSet();
        string query;
        double totAmt1 = 0;
        #endregion

        #region Initialization
        public ChallanDetailReport()
        {
            InitializeComponent();
        }
        public ChallanDetailReport(string type)
        {
            InitializeComponent();

        }
        #endregion

        #region Control and Events
        private void ChallanDetailReport_Load(object sender, EventArgs e)
        {
            label19.Text = Data.Area;
            label32.Text = Data.Area;
            fillpartyname();
            BindUsers();
            fillitemname();
            filllabour();
            drpcreate.SelectedIndex = 1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Data.query = query;
            Data.BillingAmt = txtTotAmt.Text;
            Data.Discount = txttotwt.Text;
            Challanrep rep = new Challanrep();
            rep.ShowDialog();
        }

        private void drpPatientId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                this.ProcessTabKey(true);
            }
        }

        private void drpPatientId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpPatientId.SelectedIndex > 0)
            {
                string aa = drpPatientId.Text.ToString();
                query = " SELECT * from tblclient";
                query += " where PartyType='PermanentSupplier' and firmid=" + Data.id + "";
                query += " and id=" + drpPatientId.SelectedValue + "";
                ds = data.getDataSet(query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    query = " select * from tbl_DeliveredTo where firmid=" + Data.id + " and PartyType='" + aa + "' order by compname";
                    ds = data.getDataSet(query);
                    DataRow newrow = ds.Tables[0].NewRow();
                    newrow["id"] = "0";
                    newrow["compname"] = "---Select Delivered ----";
                    ds.Tables[0].Rows.InsertAt(newrow, 0);
                    drpDelivertedTo.DataSource = ds.Tables[0];
                    drpDelivertedTo.DisplayMember = "compname";
                    drpDelivertedTo.ValueMember = "id";
                    drpDelivertedTo.Enabled = true;
                }
                else
                {
                    drpDelivertedTo.Text = "";
                    drpDelivertedTo.Enabled = false;

                }
            }
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

        private void cmbClientName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClientName.SelectedIndex > 0)
            {
                string aa = cmbClientName.Text.ToString();
                query = " SELECT * from tblclient";
                query += " where PartyType='PermanentSupplier' and firmid=" + Data.id + "";
                query += " and id=" + cmbClientName.SelectedValue + "";
                ds = data.getDataSet(query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    query = " select * from tbl_DeliveredTo where firmid=" + Data.id + " and PartyType='" + aa + "' order by compname";
                    ds = data.getDataSet(query);
                    DataRow newrow = ds.Tables[0].NewRow();
                    newrow["id"] = "0";
                    newrow["compname"] = "---Select Delivered ----";
                    ds.Tables[0].Rows.InsertAt(newrow, 0);
                    cmbDeliveredTo.DataSource = ds.Tables[0];
                    cmbDeliveredTo.DisplayMember = "compname";
                    cmbDeliveredTo.ValueMember = "id";
                    cmbDeliveredTo.Enabled = true;
                }
                else
                {
                    cmbDeliveredTo.Text = "";
                    cmbDeliveredTo.Enabled = false;

                }
            }
        }

        private void cmbTransporter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTransporter.SelectedIndex > 0)
            {
                query = "  SELECT tbl_Vehicle.VehicleNo,tbl_Transport.lbrid FROM (tbl_Vehicle INNER JOIN tbl_Transport ON tbl_Vehicle.clientid = tbl_Transport.lbrid)";
                query += " where tbl_Transport.lbrid=" + cmbTransporter.SelectedValue;
                ds = data.getDataSet(query);

                DataRow newrow = ds.Tables[0].NewRow();
                newrow["lbrid"] = "0";
                newrow["VehicleNo"] = "---Select VehicleNo ---";
                ds.Tables[0].Rows.InsertAt(newrow, 0);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbVehicleNo.DataSource = ds.Tables[0];
                    cmbVehicleNo.DisplayMember = "VehicleNo";
                }
            }
        }

        private void btnSearch2_Click(object sender, EventArgs e)
        {
            GetChallanSummaryReport();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetChallanReport();
        }
        #endregion

        #region Bind Functions
        public void fillDeliveredType()
        {
            query = " select * from tbl_DeliveredTo";
            query += " where  firmid=" + Data.id + " ORDER BY tbl_DeliveredTo.compname";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["id"] = "0";
            newrow["compname"] = "---Select Delivered To---";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            drpDelivertedTo.DataSource = ds.Tables[0];
            drpDelivertedTo.DisplayMember = "compname";
            drpDelivertedTo.ValueMember = "id";

            // summary
            cmbDeliveredTo.DataSource = ds.Tables[0];
            cmbDeliveredTo.DisplayMember = "compname";
            cmbDeliveredTo.ValueMember = "id";
        }
        public void filllabour()
        {
            query = " select * from tbl_Transport where firmid=" + Data.id + " order by TransportName";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["lbrid"] = "0";
            newrow["TransportName"] = "---Select Transporter ----";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            drplbr.DataSource = ds.Tables[0];
            drplbr.DisplayMember = "TransportName";
            drplbr.ValueMember = "lbrid";

            //summary
            cmbTransporter.DataSource = ds.Tables[0];
            cmbTransporter.DisplayMember = "TransportName";
            cmbTransporter.ValueMember = "lbrid";
        }


        public void fillitemname()
        {
            query = " select * from tblitem where firmid=" + Data.id + " order by itemname";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["itemid"] = "0";
            newrow["itemname"] = "---Select Item Name----";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                drpbrand.DataSource = ds.Tables[0];
                drpbrand.ValueMember = "itemid";
                drpbrand.DisplayMember = "itemname";
            }
            else
            {
                drpbrand.SelectedIndex = 0;
            }


        }
        public void fillpartyname()
        {
            query = " select * from tblclient";
            query += " where  firmid=" + Data.id + " ORDER BY compname";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["id"] = "0";
            newrow["compname"] = "---Select Party Name----";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            drpPatientId.DataSource = ds.Tables[0];
            drpPatientId.DisplayMember = "compname";
            drpPatientId.ValueMember = "id";

            //summary
            cmbClientName.DataSource = ds.Tables[0];
            cmbClientName.DisplayMember = "compname";
            cmbClientName.ValueMember = "id";
        }
        public void BindUsers()
        {
            query = " select * from tbl_User";
            query += " where  firmid=" + Data.id + " ORDER BY UserName";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["id"] = "0";
            newrow["UserName"] = "---Select User Name----";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            cmbUser.DataSource = ds.Tables[0];
            cmbUser.DisplayMember = "UserName";
            cmbUser.ValueMember = "id";

            //summary
            cmbUserName.DataSource = ds.Tables[0];
            cmbUserName.DisplayMember = "UserName";
            cmbUserName.ValueMember = "id";

        }

        #endregion


        #region User Functions
        public void GetChallanReport()
        {
            //query = "GetChallanReport " + Data.id + "," + Data.sessionid + "";
            query = "GetChallanReportGST " + Data.id + "," + Data.sessionid + "";


            #region Filters
            if (drpPatientId.SelectedIndex > 0)
                query += "," + drpPatientId.SelectedValue + "";
            else
                query += ",'%'";
            if (drpDelivertedTo.SelectedIndex > 0)
                query += "," + drpDelivertedTo.SelectedValue + "";
            else
                query += ",'%'";
            if (drpbrand.SelectedIndex > 0)
                query += "," + drpbrand.SelectedValue + "";
            else
                query += ",'%'";
            if (drplbr.SelectedIndex > 0)
                query += "," + drplbr.SelectedValue + "";
            else
                query += ",'%'";
            if (dtpVehicleNo.SelectedIndex > 0)
                query += ",'" + dtpVehicleNo.Text + "'";
            else
                query += ",'%'";
            if (cmbUser.SelectedIndex > 0)
                query += "," + cmbUser.SelectedValue + "";
            else
                query += ",'%'";
            if (dateTimePicker1.Checked == true && dateTimePicker2.Checked == true)
            {
                query += ",'" + dateTimePicker1.Value + "','" + dateTimePicker2.Value + "',1";
            }
            else
                query += ",'" + dateTimePicker1.Value + "','" + dateTimePicker2.Value + "',0";

            #endregion

            ds1 = data.getDataSet(query);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                grdTest.Rows.Clear();
                totAmt1 = 0;
                txttotwt.Text = "0";
                txtTotAmt.Text = "";
                foreach (DataRow dr in ds1.Tables[0].Rows)
                {
                    grdTest.Rows.Add();
                    int currow = grdTest.Rows.Count - 1;
                    grdTest.Rows[currow].Cells["sno"].Value = currow + 1;
                    grdTest.Rows[currow].Cells["invtime"].Value = dr["chalantime"].ToString();
                    grdTest.Rows[currow].Cells["ChallanDate"].Value = dr["ChallanDate"].ToString();
                    grdTest.Rows[currow].Cells["PartyName"].Value = dr["PartyName"].ToString();
                    grdTest.Rows[currow].Cells["DeliveredTo"].Value = dr["DDeliveredTo"].ToString();
                    grdTest.Rows[currow].Cells["Address"].Value = dr["Address"].ToString();
                    grdTest.Rows[currow].Cells["Item"].Value = dr["ItemName"].ToString();
                    grdTest.Rows[currow].Cells["Qty"].Value = dr["Qty"].ToString();
                    grdTest.Rows[currow].Cells["RawannaNo"].Value = dr["RawannaNo"].ToString();
                    grdTest.Rows[currow].Cells["VechileNo"].Value = dr["VehicleNo"].ToString();
                    grdTest.Rows[currow].Cells["TransporterName"].Value = dr["TransportName"].ToString();
                    grdTest.Rows[currow].Cells["quantity"].Value = dr["quantity"].ToString();
                    grdTest.Rows[currow].Cells["UserName"].Value = dr["UserName"].ToString();
                    grdTest.Rows[currow].Cells["InvoiceNo"].Value = dr["ChallanNo"].ToString();
                }
                calcTotal();
            }

            else
            {
                grdTest.Rows.Clear();
                txtTotalFright.Text = "";
                MessageBox.Show("Record Not Found");
            }
        }

        public void GetChallanSummaryReport()
        {
            
            query = "GetChallanSummaryReportGST " + Data.id + "," + Data.sessionid + "";

            #region Filters
            if (cmbClientName.SelectedIndex > 0)
                query += "," + cmbClientName.SelectedValue + "";
            else
                query += ",'%'";
            if (cmbDeliveredTo.SelectedIndex > 0)
                query += "," + cmbDeliveredTo.SelectedValue + "";
            else
                query += ",'%'";
            if (cmbTransporter.SelectedIndex > 0)
                query += "," + cmbTransporter.SelectedValue + "";
            else
                query += ",'%'";
            if (cmbVehicleNo.SelectedIndex > 0)
                query += ",'" + cmbVehicleNo.Text + "'";
            else
                query += ",'%'";
            if (cmbUserName.SelectedIndex > 0)
                query += "," + cmbUser.SelectedValue + "";
            else
                query += ",'%'";
            if (dtpFromDate.Checked == true && dtpToDate.Checked == true)
            {
                query += ",'" + dtpFromDate.Value + "','" + dtpToDate.Value + "',1";
            }
            else
                query += ",'" + dtpFromDate.Value + "','" + dtpToDate.Value + "',0";
            #endregion

            ds1 = data.getDataSet(query);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                grdTest1.Rows.Clear();
                totAmt1 = 0;
                txttotwt.Text = "0";
                txtTotAmt.Text = "";
                foreach (DataRow dr in ds1.Tables[0].Rows)
                {
                    grdTest1.Rows.Add();
                    int currow = grdTest1.Rows.Count - 1;
                    grdTest1.Rows[currow].Cells["sno1"].Value = currow + 1;
                    grdTest1.Rows[currow].Cells["InvoiceNo1"].Value = dr["ChallanNo"].ToString();
                    grdTest1.Rows[currow].Cells["ChallanDate1"].Value = dr["ChallanDate"].ToString();
                    grdTest1.Rows[currow].Cells["PartyName1"].Value = dr["PartyName"].ToString();
                    grdTest1.Rows[currow].Cells["DeliveredTo1"].Value = dr["DDeliveredTo"].ToString();
                    grdTest1.Rows[currow].Cells["Address1"].Value = dr["Address"].ToString();
                    grdTest1.Rows[currow].Cells["vehicleno1"].Value = dr["VehicleNo"].ToString();
                    grdTest1.Rows[currow].Cells["TransporterName1"].Value = dr["TransportName"].ToString();
                    //grdTest1.Rows[currow].Cells["Fright"].Value = dr["Fright"].ToString();
                    grdTest1.Rows[currow].Cells["UserName1"].Value = dr["UserName"].ToString();
                   //grdTest1.Rows[currow].Cells["InvoiceNo"].Value = dr["InvoiceNo"].ToString();
                    grdTest1.Rows[currow].Cells["Fright"].Value = dr["GrossTotal"].ToString();
                    
                }
                calcTotal();
            }

            else
            {
                grdTest1.Rows.Clear();
                txtTotalFright.Text = "";
                MessageBox.Show("Record Not Found");
            }
        }

        void calcTotal()
        {
            txttotwt.Text = grdTest.Rows.Cast<DataGridViewRow>().Sum(d => Convert.ToDouble(d.Cells["quantity"].Value)).ToString();
            txtTotalFright.Text = grdTest1.Rows.Cast<DataGridViewRow>().Sum(d => Convert.ToDouble(d.Cells["fright"].Value)).ToString();
        }
        #endregion

        private void btnPrint2_Click(object sender, EventArgs e)
        {
            Data.query = query;
            PrintPreview rep = new PrintPreview();
            WelcomeFabric.Report.ChallanSummaryReport reps = new WelcomeFabric.Report.ChallanSummaryReport();
            SqlDataAdapter adp = new SqlDataAdapter(Data.query, data.conString);
            WelcomeFabric.Report.DataSet2 ds = new WelcomeFabric.Report.DataSet2();
            adp.Fill(ds, "ChallanSummaryReport");
            reps.SetDataSource(ds);
            rep.crystalReportViewer1.ReportSource = reps;
            rep.crystalReportViewer1.Dock = DockStyle.Fill;
            rep.ShowDialog();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //drpPatientId.SelectedIndex = 0;
            //drpDelivertedTo.SelectedIndex = 0;
            //drpbrand.SelectedIndex = 0;
            //drplbr.SelectedIndex = 0;
            //dtpVehicleNo.SelectedIndex = 0;
            //cmbUser.SelectedIndex = 0;
            //dateTimePicker1.Text=dat
        }




    }
}