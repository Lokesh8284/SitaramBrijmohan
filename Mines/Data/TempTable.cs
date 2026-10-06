using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

public sealed class TempTable
{
    public static DataTable table1 = new DataTable();
    public static DataTable table2 = new DataTable();
    public void EmptyDataTable()
    {
        table1.Reset();
        table1.Columns.Add("InvoiceNo");
        table1.Columns.Add("InvoiceDate");
        table1.Columns.Add("ClientID");
        table1.Columns.Add("TotalAmount");
        table1.Columns.Add("Discount");
        table1.Columns.Add("Vat");
        table1.Columns.Add("Fright");
        table1.Columns.Add("NetAmount");
        table1.Columns.Add("FirmID");
        table1.Columns.Add("SessionID");


        table2.Reset();
        table1.Columns.Add("InvoiceID");
        table1.Columns.Add("ItemID");
        table1.Columns.Add("Quantity");
        table1.Columns.Add("Price");
        table1.Columns.Add("Amount");

        //TempTable temp = new TempTable();
        //temp.EmptyDataTable();
        //DataRow dr = TempTable.table1.NewRow();
        //dr["InvoiceNo"] = txtbillno.Text;
        //dr["InvoiceDate"] = dateTimePicker1.Value;
        //dr["ClientID"] = drpname.SelectedValue;
        //dr["TotalAmount"] = txtTotal.Text;
        //dr["Discount"] = txtDiscount.Text;
        //dr["Vat"] = txtvat.Text;
        //dr["Fright"] = txtfright.Text;
        //dr["NetAmount"] = txtNetAmt.Text;
        //dr["FirmID"] = Data.id;
        //dr["SessionID"] = Data.sessionid;
    }
}