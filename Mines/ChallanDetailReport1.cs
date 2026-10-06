using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq;
using WelcomeFabric;
using System.Web.UI.WebControls;
namespace WelcomeFabric
{
    public partial class ChallanDetailReport1 : Form
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
        public ChallanDetailReport1()
        {
            InitializeComponent();
        }
        #endregion

        #region Control and Events
        private void ChallanDetailReport_Load(object sender, EventArgs e)
        {
            label19.Text = Data.Area;
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
                    drpDelivered.DataSource = ds.Tables[0];
                    drpDelivered.DisplayMember = "compname";
                    drpDelivered.ValueMember = "id";
                    //drpDelivered.Enabled = true;
                }
                //else
                //{
                //    drpDelivered.Text = "";
                //    drpDelivered.Enabled = false;

                //}
            }
        }

        private void drplbr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drplbr.SelectedIndex > 0)
            {
                query = "  SELECT  tbl_Vehicle.clientid,tbl_Vehicle.VehicleNo,tbl_Transport.lbrid FROM (tbl_Vehicle INNER JOIN tbl_Transport ON tbl_Vehicle.clientid = tbl_Transport.lbrid)";
                query += " where tbl_Transport.lbrid=" + drplbr.SelectedValue;
                ds = data.getDataSet(query);

                DataRow newrow = ds.Tables[0].NewRow();
                newrow["lbrid"] = "0";
                newrow["VehicleNo"] = "---Select VehicleNo ---";
                ds.Tables[0].Rows.InsertAt(newrow, 0);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    drpVehicle.DataSource = ds.Tables[0];
                    drpVehicle.DisplayMember = "VehicleNo";
                    drpVehicle.ValueMember = "lbrid";
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
            drpDelivered.DataSource = ds.Tables[0];
            drpDelivered.DisplayMember = "compname";
            drpDelivered.ValueMember = "id";

            // summary
            //cmbDeliveredTo.DataSource = ds.Tables[0];
            //cmbDeliveredTo.DisplayMember = "compname";
            //cmbDeliveredTo.ValueMember = "id";
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
            DataTable dt = new DataTable();

            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    drpbrand.Items.Add(ds.Tables[0].Rows[i]["itemname"].ToString());

            //}
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
                drpbrand1.SelectedIndex = 0;
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
            query = "SELECT tbl_Transport.TransportName, tblfirm.compname as FirmName, tblclient.compname as PartyName, tblchalan.DeliveryAddress as Address, tblchalan.VehicleNo,chalandetail.qty as quantity,tblchalan.chalanno as ChallanNo,";
            query += " tbl_DeliveredTo.compname as DDeliveredTo ,tblchalan.Fright, Convert(char(11),tblchalan.chalandate,103) AS ChallanDate,  convert(char(6),chalandetail.qty)+chalandetail.Unit as Qty,chalandetail.ravanano as RawannaNo, tblitem.itemname, ";
            query += "  tblchalan.transid , tbl_user.name as UserName FROM ((((tblchalan Inner JOIN tblfirm ON tblchalan.firmid = tblfirm.firmid) inner JOIN tblclient ON tblchalan.clientid = tblclient.id)  Inner JOIN chalandetail ON (tblchalan.chalanno = chalandetail.chalanno)AND (tblclient.firmid = chalandetail.firmid))  ";
            query += "  Inner JOIN tblitem ON chalandetail.itemid = tblitem.itemid) inner join tbl_Transport  on tbl_Transport.lbrid = tblchalan.Transid Inner join tbl_DeliveredTo on tbl_DeliveredTo.id=tblchalan.DeliveredTo Inner join tbl_user on tbl_user.id=tblchalan.uid  ";
            query += " Where  tblchalan.firmid=" + Data.id + " and tblchalan.sessionid=" + Data.sessionid;
            query += " and chalandetail.firmid=" + Data.id + " and chalandetail.sessionid=" + Data.sessionid;
            if (drpPatientId.SelectedIndex > 0)
            {
                query += " and  tblchalan.clientid =" + drpPatientId.SelectedValue;
            }
            int d = 0;
            foreach (var item in drpDelivered.CheckedItems)
            {
                DataRowView datas = (DataRowView)item;

                var checkstate = datas.Row[0].ToString();
                //MessageBox.Show(checkstate.ToString()); 
                if (d == 0)
                {
                    query += " and tblchalan.DeliveredTo =" + checkstate + "";
                    d = 1;
                }
                else
                {
                    query += " or tblchalan.DeliveredTo =" + checkstate + "";
                }
            }
            //if (drpDelivertedTo.SelectedIndex > 0)
            //{
            //    query += " and tblchalan.DeliveredTo =" + drpDelivertedTo.SelectedValue;
            //}
            int c = 0;
            foreach (var item in drpbrand.CheckedItems)
            {
                DataRowView datas = (DataRowView)item;

                var checkstate = datas.Row[0].ToString();
                //MessageBox.Show(checkstate.ToString()); 
                if (c == 0)
                {
                    query += " and chalandetail.itemid =" + checkstate + "";
                    c = 1;
                }
                else
                {
                    query += " or chalandetail.itemid =" + checkstate + "";
                }
            }

            if (drplbr.SelectedIndex > 0)
            {
                query += " and  tblchalan.Transid =" + drplbr.SelectedValue;
            }
            int v = 0;
            foreach (var item in drpVehicle.CheckedItems)
            {
                DataRowView datas = (DataRowView)item;

                var checkstate = datas.Row[1].ToString();
                //MessageBox.Show(checkstate.ToString()); 
                if (v == 0)
                {
                    query += " and tblchalan.VehicleNo ='" + checkstate + "'";
                    v = 1;
                }
                else
                {
                    query += " or tblchalan.VehicleNo ='" + checkstate + "'";
                }
            }
            //if (dtpVehicleNo.SelectedIndex > 0)
            //{
            //    query += " and tblchalan.VehicleNo =" + dtpVehicleNo.SelectedValue;
            //}
            if (cmbUser.SelectedIndex > 0)
            {
                query += " and  tblchalan.UID =" + cmbUser.SelectedValue;
            }

            if (dateTimePicker1.Checked == true && dateTimePicker2.Checked == false)
            {
                if (dateTimePicker1.Checked == true)
                {
                    query += " and  tblchalan.chalandate >= '" + data.getDateMMDDYYYY(dateTimePicker1.Text) + "' ";
                }
                if (dateTimePicker2.Checked == false)
                {
                    query += " and tblchalan.chalandate  <= '" + Convert.ToDateTime(data.getDateMMDDYYYY(dateTimePicker2.Text)).AddDays(1).ToString("MM/dd/yyyy") + "' ";
                }
            }
            if (dateTimePicker1.Checked == true && dateTimePicker2.Checked == true)
            {
                if (dateTimePicker1.Checked == true)
                {
                    query += " and  tblchalan.chalandate >= '" + data.getDateMMDDYYYY(dateTimePicker1.Text) + "' ";
                    //query += " and Convert(varchar(11),tblchalan.chalandate,103) >='" + dateTimePicker1.Text + "'";
                }
                if (dateTimePicker2.Checked == true)
                {
                    query += " and tblchalan.chalandate  <= '" + Convert.ToDateTime(data.getDateMMDDYYYY(dateTimePicker2.Text)).AddDays(1).ToString("MM/dd/yyyy") + "' ";
                    //query += " and Convert(varchar(11),tblchalan.chalandate,103)  <='" + dateTimePicker2.Text + "'";
                }
            }
            query += " Order BY tblchalan.chalanno ";
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
                    grdTest.Rows[currow].Cells["ChallanNo"].Value = dr["ChallanNo"].ToString();
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
                }
                calcTotal();
            }

            else
            {
                grdTest.Rows.Clear();
                MessageBox.Show("Record Not Found");
            }
        }

        public void GetChallanSummaryReport()
        {
            query = "GetChallanSummaryReport " + Data.id + "," + Data.sessionid + "";

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
                    grdTest1.Rows[currow].Cells["ChallanNo1"].Value = dr["ChallanNo"].ToString();
                    grdTest1.Rows[currow].Cells["ChallanDate1"].Value = dr["ChallanDate"].ToString();
                    grdTest1.Rows[currow].Cells["PartyName1"].Value = dr["PartyName"].ToString();
                    grdTest1.Rows[currow].Cells["DeliveredTo1"].Value = dr["DDeliveredTo"].ToString();
                    grdTest1.Rows[currow].Cells["Address1"].Value = dr["Address"].ToString();
                    grdTest1.Rows[currow].Cells["vehicleno1"].Value = dr["VehicleNo"].ToString();
                    grdTest1.Rows[currow].Cells["TransporterName1"].Value = dr["TransportName"].ToString();
                    grdTest1.Rows[currow].Cells["Fright"].Value = dr["Fright"].ToString();
                    grdTest1.Rows[currow].Cells["UserName1"].Value = dr["UserName"].ToString();
                }
                calcTotal();
            }

            else
            {
                grdTest.Rows.Clear();
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

        private void drpbrand_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}