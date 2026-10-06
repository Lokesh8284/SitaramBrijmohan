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
    public partial class ReceiveReport : Form
    {
        Data data = new Data();
        DataSet ds1 = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        DataSet ds = new DataSet();
        string query;
        double totAmt1 = 0;
        public ReceiveReport()
        {
            InitializeComponent();
        }

        private void ChallanDetailReport_Load(object sender, EventArgs e)
        {
            label19.Text = Data.Area;
             
        }
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
          
            query=" SELECT tblfirm.Address AS firmaddress, tblfirm.compname, tblclient.Name, tblclient.Address, tblchalan.chalanno, tblchalan.totalamt, Convert(char(11),tblchalan.chalandate,103) AS chalandate, chalandetail.price, chalandetail.qty, chalandetail.amount, chalandetail.ravanano, tblitem.itemname, tbllabour.labourname, tblchalan.lbrid ";
            query += " FROM ((((tblchalan INNER JOIN tblfirm ON tblchalan.firmid = tblfirm.firmid) INNER JOIN tblclient ON tblchalan.clientid = tblclient.id) INNER JOIN chalandetail ON (tblchalan.chalanno = chalandetail.chalanno) AND (tblclient.firmid = chalandetail.firmid)) INNER JOIN tblitem ON chalandetail.itemid = tblitem.itemid) INNER JOIN tbllabour ON tblchalan.lbrid = tbllabour.lbrid ";
            query += " where tblchalan.firmid=" + Data.id + " and tblchalan.sessionid=" + Data.sessionid + " and chalandetail.sessionid=" + Data.sessionid + "";
           
            if (dateTimePicker1.Checked == true && dateTimePicker2.Checked == true)
            {
                if (dateTimePicker1.Text == dateTimePicker2.Text)
                {
                    query += " and tblchalan.chalandate='" +data.getDateMMDDYYYY(dateTimePicker1.Text) + "'";
                }
                else
                {
                    query += " and tblchalan.chalandate>='" + Convert.ToDateTime(dateTimePicker1.Text) + "' and tblchalan.chalandate<='" +data.getDateMMDDYYYY(dateTimePicker2.Text) + "'";
                }
            }
            query += " order by  tblchalan.chalandate,tblchalan.chalanno";
            ds1 = data.getDataSet(query);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                grdTest.Rows.Clear();
                totAmt1 = 0;
               
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    grdTest.Rows.Add();
                    grdTest.Rows[i].Cells["sno"].Value = grdTest.Rows.Count;
                    grdTest.Rows[i].Cells["Date"].Value = ds1.Tables[0].Rows[i]["chalandate"].ToString();
                    grdTest.Rows[i].Cells["Billnumber"].Value = ds1.Tables[0].Rows[i]["chalanno"].ToString();
                    grdTest.Rows[i].Cells["clientname"].Value = ds1.Tables[0].Rows[i]["name"].ToString();
                    grdTest.Rows[i].Cells["TotAmount"].Value = ds1.Tables[0].Rows[i]["totalamt"].ToString();
                    grdTest.Rows[i].Cells["address"].Value = ds1.Tables[0].Rows[i]["address"].ToString();
                    grdTest.Rows[i].Cells["itemname"].Value = ds1.Tables[0].Rows[i]["itemname"].ToString();
                    grdTest.Rows[i].Cells["TotAmount"].Value = ds1.Tables[0].Rows[i]["totalamt"].ToString();
                    grdTest.Rows[i].Cells["price"].Value = ds1.Tables[0].Rows[i]["price"].ToString();
                    grdTest.Rows[i].Cells["qty"].Value = ds1.Tables[0].Rows[i]["qty"].ToString();
                    grdTest.Rows[i].Cells["amount"].Value = ds1.Tables[0].Rows[i]["amount"].ToString();
                    grdTest.Rows[i].Cells["ravanano"].Value = ds1.Tables[0].Rows[i]["ravanano"].ToString();
                    grdTest.Rows[i].Cells["Labour"].Value = ds1.Tables[0].Rows[i]["labourname"].ToString();
                }
                string query1;
                query1 = " select sum(totalamt) as totalamt from tblchalan  where firmid=" + Data.id + " and sessionid="+Data.sessionid+"";
                 
                if (dateTimePicker1.Checked == true && dateTimePicker2.Checked == true)
                {
                    if (dateTimePicker1.Text == dateTimePicker2.Text)
                    {
                        query1 += " and  tblchalan.chalandate='" +data.getDateMMDDYYYY(dateTimePicker1.Text) + "'";
                    }
                    else
                    {
                        query1 += " and tblchalan.chalandate>='" +data.getDateMMDDYYYY(dateTimePicker1.Text) + "' and  tblchalan.chalandate<='" +data.getDateMMDDYYYY(dateTimePicker2.Text) + "'";
                    }

                }
                
                ds = data.getDataSet(query1);
                 
                query1 = " select sum(qty) as qty from chalandetail  where firmid=" + Data.id + " and sessionid="+Data.sessionid+"";
                
                if (dateTimePicker1.Checked == true && dateTimePicker2.Checked == true)
                {
                    if (dateTimePicker1.Text == dateTimePicker2.Text)
                    {
                        query1 += " and chalandetail.chalandate='" +data.getDateMMDDYYYY(dateTimePicker1.Text) + "'";
                    }
                    else
                    {
                        query1 += " and chalandetail.chalandate>='" +data.getDateMMDDYYYY(dateTimePicker1.Text) + "' and chalandetail.chalandate<='" +data.getDateMMDDYYYY(dateTimePicker2.Text) + "'";
                    }
                }
                
                ds = data.getDataSet(query1);
                 
                calcNetAmount1();
                calcNetAmount2();
            }

            else
            {
            
                grdTest.Rows.Clear();
                MessageBox.Show("Record Not Found");
            }

        }
        void calcNetAmount1()
        {
            int rowG = grdTest.Rows.Count;
            double amt = 0;
            for (int i = 0; i < rowG; i++)
            {
                if (grdTest.Rows[i].Cells["qty"].Value != null)
                {
                    amt += double.Parse(grdTest.Rows[i].Cells["qty"].Value.ToString());
                }
            }

           
        }
        void calcNetAmount2()
        {
            int rowG = grdTest.Rows.Count;
            double amt = 0;
            for (int i = 0; i < rowG; i++)
            {
                if (grdTest.Rows[i].Cells["TotAmount"].Value != null)
                {
                    amt += double.Parse(grdTest.Rows[i].Cells["TotAmount"].Value.ToString());
                }
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

        private void txttotwt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtTotAmt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}