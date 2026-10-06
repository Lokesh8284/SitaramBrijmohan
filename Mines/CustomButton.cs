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
    public partial class CustomButton : Form
    { 
        SupplierTaxInvoiceReport rep = new SupplierTaxInvoiceReport();

        public CustomButton()
        {
            InitializeComponent();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            rep.PrintSupplier();
            rep.PrintCustmer();
            rep.PrintOwner();
        }

        private void BtnWithoutPrice_Click(object sender, EventArgs e)
        {
            rep.PrintSupplier();
        }

        private void BtnWithQty_Click(object sender, EventArgs e)
        {
            rep.PrintCustmer();
        }

        private void btnGST_Click(object sender, EventArgs e)
        {
            rep.PrintOwner();
        }
    }
}
