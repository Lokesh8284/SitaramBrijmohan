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
    public partial class ItemReport_New : Form
    {
        Data data = new Data();
        DataSet ds = new DataSet();
        public ItemReport_New()
        {
            InitializeComponent();
        }

        private void ItemReport_New_Load(object sender, EventArgs e)
        {
            FillReport();
        }

        private void FillReport()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = data.GetDataTable(" select itemname,cast(ItemCode as nvarchar(50))ItemCode,Unit,MRP, SalePrice2, GM.GSTValue from tblitem I INNER JOIN tbl_GSTMaster GM ON GM.GST_Id=I.GST_Id where I.Delid=0 and I.Firmid=" + Data.id + " order by trim(itemname) ");
                WelcomeFabric.Report.ItemReport reps = new WelcomeFabric.Report.ItemReport();
                WelcomeFabric.Report.DataSet2 ds = new WelcomeFabric.Report.DataSet2();
                ds.Tables["ItemReport"].Merge(dt);
                reps.SetDataSource(ds);
                crystalReportViewer1.ReportSource = reps;
                crystalReportViewer1.Dock = DockStyle.Fill;
                ShowDialog();
            }
            catch { }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
