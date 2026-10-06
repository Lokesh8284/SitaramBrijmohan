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
    public partial class StockReport : Form
    {
        SMS sms = new SMS();
        string query = "";
        Data data = new Data();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        int curpos = 0;

        public StockReport()
        {
            InitializeComponent();
            createTable();
        }

        private void StockReport_Load(object sender, EventArgs e)
        {
            Reset();
            this.BtnPrint.Click += new EventHandler(BtnPrint_Click);
            this.BtnSearch.Click += new EventHandler(BtnSearch_Click);
            this.BtnReset.Click += new EventHandler(BtnReset_Click);
        }

        void BtnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        void BtnSearch_Click(object sender, EventArgs e)
        {
            FillList();
        }

        void BtnPrint_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void Print()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                BtnPrint.Enabled = false;
                PrintPreview rep = new PrintPreview();
                WelcomeFabric.Report.StockReport reps = new WelcomeFabric.Report.StockReport();
                WelcomeFabric.Report.DataSet2 ds = new WelcomeFabric.Report.DataSet2();
                ds.Tables["StockReport"].Merge(dt);
                reps.SetDataSource(ds);
                rep.crystalReportViewer1.ReportSource = reps;
                rep.crystalReportViewer1.Dock = DockStyle.Fill;
                rep.ShowDialog();
            }
            catch { }
            finally
            {
                this.Cursor = Cursors.Default;
                BtnPrint.Enabled = true;
            }
        }

        private void createTable()
        {
            DataColumn cl1 = new DataColumn("SNO", typeof(int));
            DataColumn cl23 = new DataColumn("Supplier", typeof(string));
            DataColumn cl2 = new DataColumn("ItemName", typeof(string));
            DataColumn cl3 = new DataColumn("Unit", typeof(string));
            DataColumn cl4 = new DataColumn("Barcode", typeof(string));
            DataColumn cl9 = new DataColumn("Opening", typeof(double));
            DataColumn cl5 = new DataColumn("Purchase", typeof(double));
            DataColumn cl6 = new DataColumn("Sale", typeof(double));
            DataColumn cl7 = new DataColumn("stock", typeof(double));
            DataColumn cl10 = new DataColumn("PR", typeof(double));
            DataColumn cl11 = new DataColumn("SR", typeof(double));
            DataColumn cl8 = new DataColumn("Date", typeof(string));
            DataColumn cl89 = new DataColumn("SupplierMobName", typeof(string));
            dt.Columns.Add(cl1);
            dt.Columns.Add(cl23);
            dt.Columns.Add(cl2);
            dt.Columns.Add(cl3);
            dt.Columns.Add(cl4);
            dt.Columns.Add(cl9);
            dt.Columns.Add(cl5);
            dt.Columns.Add(cl6);
            dt.Columns.Add(cl7);
            dt.Columns.Add(cl8);
            dt.Columns.Add(cl10);
            dt.Columns.Add(cl11);
            dt.Columns.Add(cl89);
        }

        private void fillsupllier()
        {
            DataSet dss = data.getDataSet("select * from tblclient where delid=0 and firmid=" + Data.id + " and partyType='Supplier'");
            DataRow newrow = dss.Tables[0].NewRow();
            newrow["id"] = "0";
            newrow["compname"] = "---Select Supplier----";
            dss.Tables[0].Rows.InsertAt(newrow, 0);
            drpSupplier.DataSource = dss.Tables[0];
            drpSupplier.DisplayMember = "compname";
            drpSupplier.ValueMember = "id";
        }

        private void Reset()
        {
            fillsupllier();
            BindItem();
            dtpFrom.Value = DateTime.Now;
            dtpFrom.Checked = true;
            FillList();
        }

        private void FillList()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                dt.Clear();
                query = "SELECT  UPPER(I.itemname) AS itemname, I.ItemCode, S.ItemId, S.type, S.Qty, I.Unit, C.Mob as SupplierMobName,  C.compname  as Supplier FROM dbo.Tbl_Stock AS S INNER JOIN dbo.tblitem AS I ON S.ItemId = I.itemid INNER JOIN dbo.tblCategory Ct ON I.CategoryId = Ct.CategoryId LEFT JOIN dbo.tblclient C ON Ct.Supplier = C.id WHERE (S.Delid = 0) and (I.Delid = 0)and S.firmid=" + Data.id;
                if (drpitem.SelectedIndex > 0) 
                    query += " and S.ItemId= " + drpitem.SelectedValue;
                if (drpSupplier.SelectedIndex > 0)
                    query += " and Ct.Supplier= " + drpSupplier.SelectedValue; 
                if (dtpFrom.Checked == true)
                    query += " and cast ([Date] as DAte)<= cast(('" + dtpFrom.Value.ToString("MM/dd/yyyy") + "') as date)";
                query += " order by I.ItemCode";

                ds = data.getDataSet(query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataView view = new DataView(ds.Tables[0]);
                    DataTable distinctValues = view.ToTable(true,"Supplier","SupplierMobName", "ItemId", "itemname", "unit", "ItemCode");
                    foreach (DataRow dr in distinctValues.Rows)
                    {
                        double op = 0;
                        double pur = 0;
                        double S = 0;
                        double SR = 0;
                        double PR = 0;
                        double Stock = 0;

                        op = ds.Tables[0].AsEnumerable()
                             .Where(x => x.Field<Int32>("ItemId") == Convert.ToInt32(dr["ItemId"]))
                             .Where(x => x.Field<string>("type") == "OP")
                             .Sum(r => r.Field<double>("qty"));

                        pur = ds.Tables[0].AsEnumerable()
                               .Where(x => x.Field<Int32>("ItemId") == Convert.ToInt32(dr["ItemId"]))
                               .Where(x => x.Field<string>("type") == "P")
                               .Sum(r => r.Field<double>("qty"));

                        S = ds.Tables[0].AsEnumerable()
                               .Where(x => x.Field<Int32>("ItemId") == Convert.ToInt32(dr["ItemId"]))
                               .Where(x => x.Field<string>("type") == "S")
                               .Sum(r => r.Field<double>("qty"));

                        SR = ds.Tables[0].AsEnumerable()
                              .Where(x => x.Field<Int32>("ItemId") == Convert.ToInt32(dr["ItemId"]))
                              .Where(x => x.Field<string>("type") == "SR")
                              .Sum(r => r.Field<double>("qty"));
                        PR = ds.Tables[0].AsEnumerable()
                              .Where(x => x.Field<Int32>("ItemId") == Convert.ToInt32(dr["ItemId"]))
                              .Where(x => x.Field<string>("type") == "PR")
                              .Sum(r => r.Field<double>("qty"));

                        Stock = op + pur - S;
                        //if (Stock > 0)
                        //{
                        dt.Rows.Add();
                        curpos = dt.Rows.Count - 1;
                        dt.Rows[curpos]["SNO"] = curpos + 1;
                        dt.Rows[curpos]["Supplier"] = dr["Supplier"].ToString();
                        dt.Rows[curpos]["ItemName"] = dr["itemname"].ToString();
                        dt.Rows[curpos]["Unit"] = dr["unit"].ToString();
                        dt.Rows[curpos]["Barcode"] = dr["ItemCode"].ToString();
                        dt.Rows[curpos]["Opening"] = op.ToString();
                        dt.Rows[curpos]["Purchase"] = pur.ToString();
                        dt.Rows[curpos]["Sale"] = S.ToString();
                        dt.Rows[curpos]["SR"] = SR.ToString();
                        dt.Rows[curpos]["PR"] = PR.ToString();
                        dt.Rows[curpos]["stock"] = Stock.ToString();
                        dt.Rows[curpos]["Date"] = dtpFrom.Text;
                        dt.Rows[curpos]["SupplierMobName"] = dr["SupplierMobName"].ToString();

                        
                        //}
                    }
                    dgv.AutoGenerateColumns = false;
                    dgv.DataSource = dt;
                    Data.dt = dt;
                }
                totalstock();
            }
            catch { }
            finally { this.Cursor = Cursors.Default; }
        }

        private void totalstock()
        {
            double stkamt = 0;
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    stkamt += Convert.ToDouble(dt.Rows[i]["stock"].ToString());
                }
                txtTotal.Text = stkamt.ToString("0.00");
            }
        }

        private void BindItem()
        {
            query = " select itemid, (cast(ItemCode as nvarchar(50))+' - '+upper(itemname)) itemname from tblitem where delid=0 and firmid=" + Data.id + "  order by ItemCode";
            ds = data.getDataSet(query);
            DataRow newrow = ds.Tables[0].NewRow();
            newrow["itemid"] = "0";
            newrow["itemname"] = "---Select Item Name----";
            ds.Tables[0].Rows.InsertAt(newrow, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                drpitem.DataSource = ds.Tables[0];
                drpitem.ValueMember = "itemid";
                drpitem.DisplayMember = "itemname";
            }
        }

        private void btnWhatsapp_Click(object sender, EventArgs e)
        {
            SendMsg();
        }

        public void SendMsg()
        { 
            DataView view = dt.DefaultView;
            DataTable distinctValues = view.ToTable(true, "Supplier");

            foreach (DataRow drr in distinctValues.Rows)
            {
                view.RowFilter = " Supplier= '" + drr["Supplier"] + "'";
                DataTable dttt = view.ToTable();
                
                string Item = "";
                for (int i = 0; i < dttt.Rows.Count; i++)
                {
                    int SNo = i + 1;
                    Item += " %0a *" + SNo + ".* " + dttt.Rows[i]["itemName"].ToString() + " (*" + dttt.Rows[i]["stock"].ToString() + "/" + dttt.Rows[i]["Unit"].ToString() + "*)";
                }

                string message = "Dear  " + drr["Supplier"] + " %0a Stock Details As On Date *" + dttt.Rows[0]["Date"].ToString().Trim() + "* %0a";
                message += "%0a " + Item + " %0a Confirmed. SB";


                sms.SendWhatsapp(dttt.Rows[0]["SupplierMobName"].ToString(), message);
            }
        }
    }
}
