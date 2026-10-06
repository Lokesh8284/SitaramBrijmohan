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
    public partial class CustomMsg : Form
    {
        TaxInvoiceRepor rep = new TaxInvoiceRepor();
        public CustomMsg()
        {
            InitializeComponent();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            rep.Print("ALL");
            rep.Show();
            this.Close();
        }

        private void BtnWithoutPrice_Click(object sender, EventArgs e)
        {
            rep.Print("WithOutPrice");
            rep.Show();
            this.Close();
        }

        private void BtnWithQty_Click(object sender, EventArgs e)
        {
            rep.Print("OnlyQty");
            rep.Show();
            this.Close();
        }

        private void btnGST_Click(object sender, EventArgs e)
        {
            string query = Data.query;
            query = query.Replace("InvoicePrint_View", "GSTInvoicePrint_View");
            Data.query = query;
            rep.Print("GST");
            rep.Show();
            this.Close();
        }

        private void btnLabel_Click(object sender, EventArgs e)
        {
            rep.Print("Label");
            rep.Show();
            this.Close();
        }
    }
}
