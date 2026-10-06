using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Data.SqlClient;

namespace WelcomeFabric
{
    public partial class ExportXML : Form
    {
        Data data = new Data();
        DataSet ds12 = new DataSet();
        DataAccessLayer DAl = new DataAccessLayer();
        public ExportXML()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  WriteDyanmicallyCreatedXmlToFile();
            if (dataGridView1.Rows.Count > 0)
            {
                List<string> CNO = new List<string>();
                int count = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    int a = row.Index;
                    bool isSelected = Convert.ToBoolean(row.Cells["Check"].Value);
                    if (isSelected)
                    {
                        CNO.Add(row.Cells["VoucherNo"].Value.ToString());
                    }

                }
                CreateVoucher(CNO);
            }
            else
            {
                MessageBox.Show("Record Not Found");
            }
            //Application.ExitThread();
            //Application.Exit();
        }


        protected void CreateVoucher(List<string> VLIS)
        {
            string frmname = DAl.GetScalar("Select compname from tblfirm where firmid=" + Data.id + "").ToString();
            string RemoteID = DAl.GetScalar("Select RemoteID from tblfirm where firmid=" + Data.id + "").ToString();
            string ss = "";
            ss = "";
            ss += "<ENVELOPE>";
            ss += "<HEADER>";
            ss += "<TALLYREQUEST>Import Data</TALLYREQUEST>";
            ss += "</HEADER>";
            ss += "<BODY>";
            ss += " <IMPORTDATA>";
            ss += " <REQUESTDESC>";
            ss += "  <REPORTNAME>Vouchers</REPORTNAME>";
            ss += " <STATICVARIABLES>";
            ss += "   <SVCURRENTCOMPANY>" + frmname + "</SVCURRENTCOMPANY>";
            ss += " </STATICVARIABLES>";
            ss += "</REQUESTDESC>";
            ss += "<REQUESTDATA>";
            foreach (var item in VLIS)
            {
                List<SqlParameter> Para = new List<SqlParameter>();
                Para.Add(new SqlParameter("@firmid", Data.id));
                Para.Add(new SqlParameter("@ChalanNo", item.ToString()));

                DataSet Ds = DAl.GetDataSetSP(Para.ToArray(), "GetXMLVoucher_Arb");

                if (Ds.Tables.Count > 0)
                {
                    DataTable DetailTable = new DataTable();
                    DataTable Itemstable = new DataTable();
                   
                    DetailTable = Ds.Tables[0].Copy();
                    Itemstable = Ds.Tables[1].Copy();
                    foreach (DataRow Ddr in DetailTable.Rows)
                    {
                        ss += "<TALLYMESSAGE xmlns:UDF=\"TallyUDF\">";
                        //ss += "<VOUCHER REMOTEID=\"a7867cc4-5347-4f41-bc9e-366d8190467e-0000" + Ddr["chalanno"] + "\" VCHKEY=\"a7867cc4-5347-4f41-bc9e-366d8190467e-0000a7a4:00000008\" VCHTYPE=\"Sales\" ACTION=\"Create\" OBJVIEW=\"Invoice Voucher View\">";
                        ss += "<VOUCHER REMOTEID=\"" + Ddr["RemoteId"] + "-0000" + Ddr["chalanno"] + "\" VCHKEY=\"" + Ddr["RemoteId"] + " -0000a7a4:00000008\" VCHTYPE=\"Sales\" ACTION=\"Create\" OBJVIEW=\"Invoice Voucher View\">";
                        ss += "<ADDRESS.LIST TYPE=\"String\">";
                        ss += "<ADDRESS>" + Ddr["Address"] + "</ADDRESS>";
                        ss += "</ADDRESS.LIST>";
                        ss += "<BASICBUYERADDRESS.LIST TYPE=\"String\">";
                        ss += "<BASICBUYERADDRESS>" + Ddr["Address"] + "</BASICBUYERADDRESS>";
                        ss += "</BASICBUYERADDRESS.LIST>";
                        ss += "<OLDAUDITENTRYIDS.LIST TYPE=\"Number\">";
                        ss += "<OLDAUDITENTRYIDS>-1</OLDAUDITENTRYIDS>";
                        ss += "</OLDAUDITENTRYIDS.LIST>";
                        ss += "    <DATE>" + Convert.ToDateTime(Ddr["chalandate"]).ToString("yyyyMMdd") + "</DATE>";
                        //ss += "<GUID>a7867cc4-5347-4f41-bc9e-366d8190467e-00000001</GUID>";
                        ss += "<GUID>" + Ddr["RemoteId"] + "-00000001</GUID>";
                        ss += "<STATENAME>" + Ddr["state"] + "</STATENAME>";
                        ss += "<NARRATION> </NARRATION>";
                        ss += "<PARTYGSTIN>" + Ddr["Client_GST"] + "</PARTYGSTIN>";
                        ss += "<TAXUNITNAME>Default Tax Unit</TAXUNITNAME>";
                        ss += "<CLASSNAME>DefaultVoucherClass</CLASSNAME>";
                        ss += "<PARTYNAME>" + Ddr["Client_name"] + "</PARTYNAME>";
                        ss += "<VOUCHERTYPENAME>Sales</VOUCHERTYPENAME>";
                        ss += "<REFERENCE>" + Ddr["ReferenceNumber"] + "</REFERENCE>";
                        ss += "<VOUCHERNUMBER>" + Ddr["chalanno"] + "</VOUCHERNUMBER>";
                        ss += "<PARTYLEDGERNAME>" + Ddr["Client_name"] + "</PARTYLEDGERNAME>";
                        ss += "<BASICBASEPARTYNAME>" + Ddr["Client_name"] + "</BASICBASEPARTYNAME>";
                        ss += "<CSTFORMISSUETYPE/>";
                        ss += "<CSTFORMRECVTYPE/>";
                        ss += "<FBTPAYMENTTYPE>" + Ddr["state"] + "</FBTPAYMENTTYPE>";
                        ss += "<PERSISTEDVIEW>Invoice Voucher View</PERSISTEDVIEW>";
                        ss += "<PLACEOFSUPPLY>" + Ddr["state"] + "</PLACEOFSUPPLY>";
                        ss += "<CONSIGNEEGSTIN>" + Ddr["Client_GST"] + "</CONSIGNEEGSTIN>";
                        ss += "<BASICBUYERNAME>" + Ddr["Client_name"] + "</BASICBUYERNAME>";
                        ss += "<BASICDATETIMEOFINVOICE>" + Convert.ToDateTime(Ddr["chalandate"]).ToString("dd-MMM-yyyy") + " at " + Convert.ToDateTime(Ddr["chalandate"]).ToString("HH:mm") + "</BASICDATETIMEOFINVOICE>";
                        ss += "<BASICDATETIMEOFREMOVAL>" + Convert.ToDateTime(Ddr["chalandate"]).ToString("dd-MMM-yyyy") + " at " + Convert.ToDateTime(Ddr["chalandate"]).ToString("HH:mm") + "</BASICDATETIMEOFREMOVAL>";
                        ss += "<VCHGSTCLASS/>";
                        ss += "<CONSIGNEEPINNUMBER>" + Ddr["PanNo"] + "</CONSIGNEEPINNUMBER>";
                        ss += "<CONSIGNEESTATENAME>" + Ddr["state"] + "</CONSIGNEESTATENAME>";
                        ss += "<DIFFACTUALQTY>No</DIFFACTUALQTY>";
                        ss += "<ISMSTFROMSYNC>No</ISMSTFROMSYNC>";
                        ss += "<ASORIGINAL>No</ASORIGINAL>";
                        ss += "<AUDITED>No</AUDITED>";
                        ss += "<FORJOBCOSTING>No</FORJOBCOSTING>";
                        ss += "<ISOPTIONAL>No</ISOPTIONAL>";
                        ss += "<EFFECTIVEDATE>" + Convert.ToDateTime(Ddr["chalandate"]).ToString("yyyyMMdd") + "</EFFECTIVEDATE>";
                        ss += "<USEFOREXCISE>No</USEFOREXCISE>";
                        ss += "<ISFORJOBWORKIN>No</ISFORJOBWORKIN>";
                        ss += "<ALLOWCONSUMPTION>No</ALLOWCONSUMPTION>";
                        ss += "<USEFORINTEREST>No</USEFORINTEREST>";
                        ss += "<USEFORGAINLOSS>No</USEFORGAINLOSS>";
                        ss += "<USEFORGODOWNTRANSFER>No</USEFORGODOWNTRANSFER>";
                        ss += "<USEFORCOMPOUND>No</USEFORCOMPOUND>";
                        ss += "<USEFORSERVICETAX>No</USEFORSERVICETAX>";
                        ss += "<ISEXCISEVOUCHER>No</ISEXCISEVOUCHER>";
                        ss += "<EXCISETAXOVERRIDE>No</EXCISETAXOVERRIDE>";
                        ss += "<USEFORTAXUNITTRANSFER>No</USEFORTAXUNITTRANSFER>";
                        ss += "<EXCISEOPENING>No</EXCISEOPENING>";
                        ss += "<USEFORFINALPRODUCTION>No</USEFORFINALPRODUCTION>";
                        ss += "<ISTDSOVERRIDDEN>No</ISTDSOVERRIDDEN>";
                        ss += "<ISTCSOVERRIDDEN>No</ISTCSOVERRIDDEN>";
                        ss += "<ISTDSTCSCASHVCH>No</ISTDSTCSCASHVCH>";
                        ss += "<INCLUDEADVPYMTVCH>No</INCLUDEADVPYMTVCH>";
                        ss += "<ISSUBWORKSCONTRACT>No</ISSUBWORKSCONTRACT>";
                        ss += "<ISVATOVERRIDDEN>No</ISVATOVERRIDDEN>";
                        ss += "<IGNOREORIGVCHDATE>No</IGNOREORIGVCHDATE>";
                        ss += "<ISSERVICETAXOVERRIDDEN>No</ISSERVICETAXOVERRIDDEN>";
                        ss += "<ISISDVOUCHER>No</ISISDVOUCHER>";
                        ss += "<ISEXCISEOVERRIDDEN>No</ISEXCISEOVERRIDDEN>";
                        ss += "<ISEXCISESUPPLYVCH>No</ISEXCISESUPPLYVCH>";
                        ss += "<ISGSTOVERRIDDEN>No</ISGSTOVERRIDDEN>";
                        ss += "<GSTNOTEXPORTED>No</GSTNOTEXPORTED>";
                        ss += "<ISVATPRINCIPALACCOUNT>No</ISVATPRINCIPALACCOUNT>";
                        ss += "<ISSHIPPINGWITHINSTATE>No</ISSHIPPINGWITHINSTATE>";
                        ss += "<ISCANCELLED>No</ISCANCELLED>";
                        ss += "<HASCASHFLOW>No</HASCASHFLOW>";
                        ss += "<ISPOSTDATED>No</ISPOSTDATED>";
                        ss += "<USETRACKINGNUMBER>No</USETRACKINGNUMBER>";
                        ss += "<ISINVOICE>Yes</ISINVOICE>";
                        ss += "<MFGJOURNAL>No</MFGJOURNAL>";
                        ss += "<HASDISCOUNTS>No</HASDISCOUNTS>";
                        ss += "<ASPAYSLIP>No</ASPAYSLIP>";
                        ss += "<ISCOSTCENTRE>No</ISCOSTCENTRE>";
                        ss += "<ISSTXNONREALIZEDVCH>No</ISSTXNONREALIZEDVCH>";
                        ss += "<ISEXCISEMANUFACTURERON>No</ISEXCISEMANUFACTURERON>";
                        ss += "<ISBLANKCHEQUE>No</ISBLANKCHEQUE>";
                        ss += "<ISVOID>No</ISVOID>";
                        ss += "<ISONHOLD>No</ISONHOLD>";
                        ss += "<ORDERLINESTATUS>No</ORDERLINESTATUS>";
                        ss += "<VATISAGNSTCANCSALES>No</VATISAGNSTCANCSALES>";
                        ss += "<VATISPURCEXEMPTED>No</VATISPURCEXEMPTED>";
                        ss += "<ISVATRESTAXINVOICE>No</ISVATRESTAXINVOICE>";
                        ss += "<VATISASSESABLECALCVCH>No</VATISASSESABLECALCVCH>";
                        ss += "<ISVATDUTYPAID>Yes</ISVATDUTYPAID>";
                        ss += "<ISDELIVERYSAMEASCONSIGNEE>No</ISDELIVERYSAMEASCONSIGNEE>";
                        ss += "<ISDISPATCHSAMEASCONSIGNOR>No</ISDISPATCHSAMEASCONSIGNOR>";
                        ss += "<ISDELETED>No</ISDELETED>";
                        ss += "<CHANGEVCHMODE>No</CHANGEVCHMODE>";
                        ss += "<ALTERID>" + Ddr["chalanno"] + "</ALTERID>";
                        ss += "<MASTERID>" + Ddr["chalanno"] + "</MASTERID>";
                        ss += "<VOUCHERKEY>184322816475144</VOUCHERKEY>";
                        ss += "<EXCLUDEDTAXATIONS.LIST>      </EXCLUDEDTAXATIONS.LIST>";
                        ss += "<OLDAUDITENTRIES.LIST>      </OLDAUDITENTRIES.LIST>";
                        ss += "<ACCOUNTAUDITENTRIES.LIST>      </ACCOUNTAUDITENTRIES.LIST>";
                        ss += "<AUDITENTRIES.LIST>      </AUDITENTRIES.LIST>";
                        ss += "<DUTYHEADDETAILS.LIST>      </DUTYHEADDETAILS.LIST>";
                        ss += "<SUPPLEMENTARYDUTYHEADDETAILS.LIST>      </SUPPLEMENTARYDUTYHEADDETAILS.LIST>";
                        ss += "<INVOICEDELNOTES.LIST>      </INVOICEDELNOTES.LIST>";
                        ss += "<INVOICEORDERLIST.LIST>      </INVOICEORDERLIST.LIST>";
                        ss += "<INVOICEINDENTLIST.LIST>      </INVOICEINDENTLIST.LIST>";
                        ss += "<ATTENDANCEENTRIES.LIST>      </ATTENDANCEENTRIES.LIST>";
                        ss += "<ORIGINVOICEDETAILS.LIST>      </ORIGINVOICEDETAILS.LIST>";
                        ss += "<INVOICEEXPORTLIST.LIST>      </INVOICEEXPORTLIST.LIST>";

                        ss += "<LEDGERENTRIES.LIST>";
                        ss += "<OLDAUDITENTRYIDS.LIST TYPE=\"Number\">";
                        ss += "<OLDAUDITENTRYIDS>-1</OLDAUDITENTRYIDS>";
                        ss += "</OLDAUDITENTRYIDS.LIST>";
                        ss += "<LEDGERNAME>" + Ddr["Client_name"] + "</LEDGERNAME>";
                        ss += "<GSTCLASS/>";
                        ss += "<ISDEEMEDPOSITIVE>Yes</ISDEEMEDPOSITIVE>";
                        ss += "<LEDGERFROMITEM>No</LEDGERFROMITEM>";
                        ss += "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>";
                        ss += "<ISPARTYLEDGER>Yes</ISPARTYLEDGER>";
                        ss += "<ISLASTDEEMEDPOSITIVE>Yes</ISLASTDEEMEDPOSITIVE>";
                        ss += "<AMOUNT>-" + Ddr["TotalTaxAmt"] + "</AMOUNT>";
                        ss += "<SERVICETAXDETAILS.LIST>       </SERVICETAXDETAILS.LIST>";
                        ss += "<BANKALLOCATIONS.LIST>       </BANKALLOCATIONS.LIST>";
                        ss += "<BILLALLOCATIONS.LIST>";
                        ss += "<NAME>1</NAME>";
                        ss += "<BILLTYPE>New Ref</BILLTYPE>";
                        ss += "<TDSDEDUCTEEISSPECIALRATE>No</TDSDEDUCTEEISSPECIALRATE>";
                        ss += "<AMOUNT>-" + Ddr["TotalTaxAmt"] + "</AMOUNT>";
                        ss += "<INTERESTCOLLECTION.LIST>        </INTERESTCOLLECTION.LIST>";
                        ss += "<STBILLCATEGORIES.LIST>        </STBILLCATEGORIES.LIST>";
                        ss += "</BILLALLOCATIONS.LIST>";
                        ss += "<INTERESTCOLLECTION.LIST>       </INTERESTCOLLECTION.LIST>";
                        ss += "<OLDAUDITENTRIES.LIST>       </OLDAUDITENTRIES.LIST>";
                        ss += "<ACCOUNTAUDITENTRIES.LIST>       </ACCOUNTAUDITENTRIES.LIST>";
                        ss += "<AUDITENTRIES.LIST>       </AUDITENTRIES.LIST>";
                        ss += "<INPUTCRALLOCS.LIST>       </INPUTCRALLOCS.LIST>";
                        ss += "<DUTYHEADDETAILS.LIST>       </DUTYHEADDETAILS.LIST>";
                        ss += "<EXCISEDUTYHEADDETAILS.LIST>       </EXCISEDUTYHEADDETAILS.LIST>";
                        ss += "<RATEDETAILS.LIST>       </RATEDETAILS.LIST>";
                        ss += "<SUMMARYALLOCS.LIST>       </SUMMARYALLOCS.LIST>";
                        ss += "<STPYMTDETAILS.LIST>       </STPYMTDETAILS.LIST>";
                        ss += "<EXCISEPAYMENTALLOCATIONS.LIST>       </EXCISEPAYMENTALLOCATIONS.LIST>";
                        ss += "<TAXBILLALLOCATIONS.LIST>       </TAXBILLALLOCATIONS.LIST>";
                        ss += "<TAXOBJECTALLOCATIONS.LIST>       </TAXOBJECTALLOCATIONS.LIST>";
                        ss += "<TDSEXPENSEALLOCATIONS.LIST>       </TDSEXPENSEALLOCATIONS.LIST>";
                        ss += "<VATSTATUTORYDETAILS.LIST>       </VATSTATUTORYDETAILS.LIST>";
                        ss += "<COSTTRACKALLOCATIONS.LIST>       </COSTTRACKALLOCATIONS.LIST>";
                        ss += "<REFVOUCHERDETAILS.LIST>       </REFVOUCHERDETAILS.LIST>";
                        ss += "<INVOICEWISEDETAILS.LIST>       </INVOICEWISEDETAILS.LIST>";
                        ss += "<VATITCDETAILS.LIST>       </VATITCDETAILS.LIST>";
                        ss += "<ADVANCETAXDETAILS.LIST>       </ADVANCETAXDETAILS.LIST>";
                        ss += "</LEDGERENTRIES.LIST>";

                        //foreach (DataRow Idr in Itemstable.Select("chalanno='" + Ddr["chalanno"] + "' and firmid='" + Ddr["firmid"] + "'"))
                        //{
                        ss += "<LEDGERENTRIES.LIST>";
                        ss += "<OLDAUDITENTRYIDS.LIST TYPE=\"Number\">";
                        ss += "<OLDAUDITENTRYIDS>-1</OLDAUDITENTRYIDS>";
                        ss += "</OLDAUDITENTRYIDS.LIST>";
                        ss += "<ROUNDTYPE/>";
                        ss += "<LEDGERNAME>CGST</LEDGERNAME>";
                        ss += "<METHODTYPE>GST</METHODTYPE>";
                        ss += "<GSTCLASS/>";
                        ss += "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>";
                        ss += "<LEDGERFROMITEM>No</LEDGERFROMITEM>";
                        ss += "<REMOVEZEROENTRIES>Yes</REMOVEZEROENTRIES>";
                        ss += "<ISPARTYLEDGER>No</ISPARTYLEDGER>";
                        ss += "<ISLASTDEEMEDPOSITIVE>No</ISLASTDEEMEDPOSITIVE>";
                        //double Sgst = Convert.ToDouble(Idr["SGSTAmount"]);
                        //double CGst = Convert.ToDouble(Idr["CGSTAmount"]);
                        //double Ttlgst = Sgst + CGst;
                        ss += "<AMOUNT>" + Ddr["AddCGSTAmt"] + "</AMOUNT>";
                        ss += "<VATEXPAMOUNT>" + Ddr["AddCGSTAmt"] + "</VATEXPAMOUNT>";
                        ss += "<SERVICETAXDETAILS.LIST>       </SERVICETAXDETAILS.LIST>";
                        ss += "<BANKALLOCATIONS.LIST>       </BANKALLOCATIONS.LIST>";
                        ss += "<BILLALLOCATIONS.LIST>       </BILLALLOCATIONS.LIST>";
                        ss += "<INTERESTCOLLECTION.LIST>       </INTERESTCOLLECTION.LIST>";
                        ss += "<OLDAUDITENTRIES.LIST>       </OLDAUDITENTRIES.LIST>";
                        ss += "<ACCOUNTAUDITENTRIES.LIST>       </ACCOUNTAUDITENTRIES.LIST>";
                        ss += "<AUDITENTRIES.LIST>       </AUDITENTRIES.LIST>";
                        ss += "<INPUTCRALLOCS.LIST>       </INPUTCRALLOCS.LIST>";
                        ss += "<DUTYHEADDETAILS.LIST>       </DUTYHEADDETAILS.LIST>";
                        ss += "<EXCISEDUTYHEADDETAILS.LIST>       </EXCISEDUTYHEADDETAILS.LIST>";
                        ss += "<RATEDETAILS.LIST>       </RATEDETAILS.LIST>";
                        ss += "<SUMMARYALLOCS.LIST>       </SUMMARYALLOCS.LIST>";
                        ss += "<STPYMTDETAILS.LIST>       </STPYMTDETAILS.LIST>";
                        ss += "<EXCISEPAYMENTALLOCATIONS.LIST>       </EXCISEPAYMENTALLOCATIONS.LIST>";
                        ss += "<TAXBILLALLOCATIONS.LIST>       </TAXBILLALLOCATIONS.LIST>";
                        ss += "<TAXOBJECTALLOCATIONS.LIST>       </TAXOBJECTALLOCATIONS.LIST>";
                        ss += "<TDSEXPENSEALLOCATIONS.LIST>       </TDSEXPENSEALLOCATIONS.LIST>";
                        ss += "<VATSTATUTORYDETAILS.LIST>       </VATSTATUTORYDETAILS.LIST>";
                        ss += "<COSTTRACKALLOCATIONS.LIST>       </COSTTRACKALLOCATIONS.LIST>";
                        ss += "<REFVOUCHERDETAILS.LIST>       </REFVOUCHERDETAILS.LIST>";
                        ss += "<INVOICEWISEDETAILS.LIST>       </INVOICEWISEDETAILS.LIST>";
                        ss += "<VATITCDETAILS.LIST>       </VATITCDETAILS.LIST>";
                        ss += "<ADVANCETAXDETAILS.LIST>       </ADVANCETAXDETAILS.LIST>";
                        ss += "</LEDGERENTRIES.LIST>";

                        //}


                        //foreach (DataRow Idr in Itemstable.Select("chalanno='" + Ddr["chalanno"] + "' and firmid='" + Ddr["firmid"] + "'"))
                        //{
                        ss += "<LEDGERENTRIES.LIST>";
                        ss += "<OLDAUDITENTRYIDS.LIST TYPE=\"Number\">";
                        ss += "<OLDAUDITENTRYIDS>-1</OLDAUDITENTRYIDS>";
                        ss += "</OLDAUDITENTRYIDS.LIST>";
                        ss += "<ROUNDTYPE/>";
                        ss += "<LEDGERNAME>SGST</LEDGERNAME>";
                        ss += "<METHODTYPE>GST</METHODTYPE>";
                        ss += "<GSTCLASS/>";
                        ss += "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>";
                        ss += "<LEDGERFROMITEM>No</LEDGERFROMITEM>";
                        ss += "<REMOVEZEROENTRIES>Yes</REMOVEZEROENTRIES>";
                        ss += "<ISPARTYLEDGER>No</ISPARTYLEDGER>";
                        ss += "<ISLASTDEEMEDPOSITIVE>No</ISLASTDEEMEDPOSITIVE>";
                        //double Sgst = Convert.ToDouble(Idr["SGSTAmount"]);
                        //double CGst = Convert.ToDouble(Idr["CGSTAmount"]);
                        //double Ttlgst = Sgst + CGst;
                        ss += "<AMOUNT>" + Ddr["AddSGSTAmt"] + "</AMOUNT>";
                        ss += "<VATEXPAMOUNT>" + Ddr["AddSGSTAmt"] + "</VATEXPAMOUNT>";
                        ss += "<SERVICETAXDETAILS.LIST>       </SERVICETAXDETAILS.LIST>";
                        ss += "<BANKALLOCATIONS.LIST>       </BANKALLOCATIONS.LIST>";
                        ss += "<BILLALLOCATIONS.LIST>       </BILLALLOCATIONS.LIST>";
                        ss += "<INTERESTCOLLECTION.LIST>       </INTERESTCOLLECTION.LIST>";
                        ss += "<OLDAUDITENTRIES.LIST>       </OLDAUDITENTRIES.LIST>";
                        ss += "<ACCOUNTAUDITENTRIES.LIST>       </ACCOUNTAUDITENTRIES.LIST>";
                        ss += "<AUDITENTRIES.LIST>       </AUDITENTRIES.LIST>";
                        ss += "<INPUTCRALLOCS.LIST>       </INPUTCRALLOCS.LIST>";
                        ss += "<DUTYHEADDETAILS.LIST>       </DUTYHEADDETAILS.LIST>";
                        ss += "<EXCISEDUTYHEADDETAILS.LIST>       </EXCISEDUTYHEADDETAILS.LIST>";
                        ss += "<RATEDETAILS.LIST>       </RATEDETAILS.LIST>";
                        ss += "<SUMMARYALLOCS.LIST>       </SUMMARYALLOCS.LIST>";
                        ss += "<STPYMTDETAILS.LIST>       </STPYMTDETAILS.LIST>";
                        ss += "<EXCISEPAYMENTALLOCATIONS.LIST>       </EXCISEPAYMENTALLOCATIONS.LIST>";
                        ss += "<TAXBILLALLOCATIONS.LIST>       </TAXBILLALLOCATIONS.LIST>";
                        ss += "<TAXOBJECTALLOCATIONS.LIST>       </TAXOBJECTALLOCATIONS.LIST>";
                        ss += "<TDSEXPENSEALLOCATIONS.LIST>       </TDSEXPENSEALLOCATIONS.LIST>";
                        ss += "<VATSTATUTORYDETAILS.LIST>       </VATSTATUTORYDETAILS.LIST>";
                        ss += "<COSTTRACKALLOCATIONS.LIST>       </COSTTRACKALLOCATIONS.LIST>";
                        ss += "<REFVOUCHERDETAILS.LIST>       </REFVOUCHERDETAILS.LIST>";
                        ss += "<INVOICEWISEDETAILS.LIST>       </INVOICEWISEDETAILS.LIST>";
                        ss += "<VATITCDETAILS.LIST>       </VATITCDETAILS.LIST>";
                        ss += "<ADVANCETAXDETAILS.LIST>       </ADVANCETAXDETAILS.LIST>";
                        ss += "</LEDGERENTRIES.LIST>";

                        //}
                        foreach (DataRow Idr in Itemstable.Select("chalanno='" + Ddr["chalanno"] + "' and firmid='" + Ddr["firmid"] + "'"))
                        {
                            ss += "<ALLINVENTORYENTRIES.LIST>";
                            ss += "<STOCKITEMNAME>" + Idr["itemname"] + "</STOCKITEMNAME>";
                            ss += "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>";
                            ss += "<ISLASTDEEMEDPOSITIVE>No</ISLASTDEEMEDPOSITIVE>";
                            ss += "<ISAUTONEGATE>No</ISAUTONEGATE>";
                            ss += "<ISCUSTOMSCLEARANCE>No</ISCUSTOMSCLEARANCE>";
                            ss += "<ISTRACKCOMPONENT>No</ISTRACKCOMPONENT>";
                            ss += "<ISTRACKPRODUCTION>No</ISTRACKPRODUCTION>";
                            ss += "<ISPRIMARYITEM>No</ISPRIMARYITEM>";
                            ss += "<ISSCRAP>No</ISSCRAP>";
                            ss += "<RATE>" + Idr["price"] + "/PIC</RATE>";
                            ss += "<AMOUNT>" + Idr["amount"] + "</AMOUNT>";
                            ss += "<ACTUALQTY>" + Idr["qty"] + "</ACTUALQTY>";
                            ss += "<BILLEDQTY>" + Idr["qty"] + "</BILLEDQTY>";
                            ss += "<BATCHALLOCATIONS.LIST>";
                            ss += "<GODOWNNAME>Main Location</GODOWNNAME>";
                            ss += "<BATCHNAME>Primary Batch</BATCHNAME>";
                            ss += "<INDENTNO/>";
                            ss += "<ORDERNO/>";
                            ss += "<TRACKINGNUMBER/>";
                            ss += "<DYNAMICCSTISCLEARED>No</DYNAMICCSTISCLEARED>";
                            ss += "<AMOUNT>" + Idr["amount"] + "</AMOUNT>";
                            ss += "<ACTUALQTY>" + Idr["qty"] + "</ACTUALQTY>";
                            ss += "<BILLEDQTY>" + Idr["qty"] + "</BILLEDQTY>";
                            ss += "<ADDITIONALDETAILS.LIST>        </ADDITIONALDETAILS.LIST>";
                            ss += "<VOUCHERCOMPONENTLIST.LIST>        </VOUCHERCOMPONENTLIST.LIST>";
                            ss += "</BATCHALLOCATIONS.LIST>";
                            ss += "<ACCOUNTINGALLOCATIONS.LIST>";
                            ss += "<OLDAUDITENTRYIDS.LIST TYPE=\"Number\">";
                            ss += "<OLDAUDITENTRYIDS>-1</OLDAUDITENTRYIDS>";
                            ss += "</OLDAUDITENTRYIDS.LIST>";
                            ss += "<LEDGERNAME>GST Sale A/c</LEDGERNAME>";
                            ss += "<GSTCLASS/>";
                            ss += "<ISDEEMEDPOSITIVE>No</ISDEEMEDPOSITIVE>";
                            ss += "<LEDGERFROMITEM>No</LEDGERFROMITEM>";
                            ss += "<REMOVEZEROENTRIES>No</REMOVEZEROENTRIES>";
                            ss += "<ISPARTYLEDGER>No</ISPARTYLEDGER>";
                            ss += "<ISLASTDEEMEDPOSITIVE>No</ISLASTDEEMEDPOSITIVE>";
                            ss += "<AMOUNT>" + Idr["amount"] + "</AMOUNT>";
                            ss += "<SERVICETAXDETAILS.LIST>        </SERVICETAXDETAILS.LIST>";
                            ss += "<BANKALLOCATIONS.LIST>        </BANKALLOCATIONS.LIST>";
                            ss += "<BILLALLOCATIONS.LIST>        </BILLALLOCATIONS.LIST>";
                            ss += "<INTERESTCOLLECTION.LIST>        </INTERESTCOLLECTION.LIST>";
                            ss += "<OLDAUDITENTRIES.LIST>        </OLDAUDITENTRIES.LIST>";
                            ss += "<ACCOUNTAUDITENTRIES.LIST>        </ACCOUNTAUDITENTRIES.LIST>";
                            ss += "<AUDITENTRIES.LIST>        </AUDITENTRIES.LIST>";
                            ss += "<INPUTCRALLOCS.LIST>        </INPUTCRALLOCS.LIST>";
                            ss += "<DUTYHEADDETAILS.LIST>        </DUTYHEADDETAILS.LIST>";
                            ss += "<EXCISEDUTYHEADDETAILS.LIST>        </EXCISEDUTYHEADDETAILS.LIST>";
                            ss += "<RATEDETAILS.LIST>        </RATEDETAILS.LIST>";
                            ss += "<SUMMARYALLOCS.LIST>        </SUMMARYALLOCS.LIST>";
                            ss += "<STPYMTDETAILS.LIST>        </STPYMTDETAILS.LIST>";
                            ss += "<EXCISEPAYMENTALLOCATIONS.LIST>        </EXCISEPAYMENTALLOCATIONS.LIST>";
                            ss += "<TAXBILLALLOCATIONS.LIST>        </TAXBILLALLOCATIONS.LIST>";
                            ss += "<TAXOBJECTALLOCATIONS.LIST>        </TAXOBJECTALLOCATIONS.LIST>";
                            ss += "<TDSEXPENSEALLOCATIONS.LIST>        </TDSEXPENSEALLOCATIONS.LIST>";
                            ss += "<VATSTATUTORYDETAILS.LIST>        </VATSTATUTORYDETAILS.LIST>";
                            ss += "<COSTTRACKALLOCATIONS.LIST>        </COSTTRACKALLOCATIONS.LIST>";
                            ss += "<REFVOUCHERDETAILS.LIST>        </REFVOUCHERDETAILS.LIST>";
                            ss += "<INVOICEWISEDETAILS.LIST>        </INVOICEWISEDETAILS.LIST>";
                            ss += "<VATITCDETAILS.LIST>        </VATITCDETAILS.LIST>";
                            ss += "<ADVANCETAXDETAILS.LIST>        </ADVANCETAXDETAILS.LIST>";
                            ss += "</ACCOUNTINGALLOCATIONS.LIST>";
                            ss += "<DUTYHEADDETAILS.LIST>       </DUTYHEADDETAILS.LIST>";
                            ss += "<SUPPLEMENTARYDUTYHEADDETAILS.LIST>       </SUPPLEMENTARYDUTYHEADDETAILS.LIST>";
                            ss += "<TAXOBJECTALLOCATIONS.LIST>       </TAXOBJECTALLOCATIONS.LIST>";
                            ss += "<REFVOUCHERDETAILS.LIST>       </REFVOUCHERDETAILS.LIST>";
                            ss += "<EXCISEALLOCATIONS.LIST>       </EXCISEALLOCATIONS.LIST>";
                            ss += "<EXPENSEALLOCATIONS.LIST>       </EXPENSEALLOCATIONS.LIST>";
                            ss += "</ALLINVENTORYENTRIES.LIST>";
                        }
                        ss += "<PAYROLLMODEOFPAYMENT.LIST>      </PAYROLLMODEOFPAYMENT.LIST>";
                        ss += "<ATTDRECORDS.LIST>      </ATTDRECORDS.LIST>";
                        ss += "<TEMPGSTRATEDETAILS.LIST>      </TEMPGSTRATEDETAILS.LIST>";
                        ss += "</VOUCHER>";
                        ss += "</TALLYMESSAGE>";
                        //ss += "<TALLYMESSAGE xmlns:UDF=\"TallyUDF\">";
                        //ss += "<COMPANY>";
                        //ss += "<REMOTECMPINFO.LIST MERGE=\"Yes\">";
                        //ss += "<NAME>a7867cc4-5347-4f41-bc9e-366d8190467e</NAME>";
                        //ss += "<REMOTECMPNAME>Welcome Fabrics</REMOTECMPNAME>";
                        //ss += "<REMOTECMPSTATE>Rajasthan</REMOTECMPSTATE>";
                        //ss += "</REMOTECMPINFO.LIST>";
                        //ss += "</COMPANY>";
                        //ss += "</TALLYMESSAGE>";

                    }
                }
                else
                {
                    MessageBox.Show("No Data");
                }


            }
            ss += "<TALLYMESSAGE xmlns:UDF=\"TallyUDF\">";
            ss += "<COMPANY>";
            ss += "<REMOTECMPINFO.LIST MERGE=\"Yes\">";
            //ss += "<NAME>a7867cc4-5347-4f41-bc9e-366d8190467e</NAME>";
            ss += "<NAME>" + RemoteID + "</NAME>";
            ss += "<REMOTECMPNAME>" + frmname + "</REMOTECMPNAME>";
            ss += "<REMOTECMPSTATE>Rajasthan</REMOTECMPSTATE>";
            ss += "</REMOTECMPINFO.LIST>";
            ss += "</COMPANY>";
            ss += "</TALLYMESSAGE>";
            ss += "</REQUESTDATA>";
            ss += "</IMPORTDATA>";
            ss += "</BODY>";
            ss += "</ENVELOPE>";

            using (SaveFileDialog saver = new SaveFileDialog())
            {
                saver.InitialDirectory = @"E:\";
                saver.Title = "Save text Files";
                saver.DefaultExt = "XML";
                saver.Filter = "XML files (*.XML)|*.XML|All files (*.*)|*.*";
                saver.FilterIndex = 1;
                string path = "";
                if (saver.ShowDialog() == DialogResult.OK)
                {
                    path = saver.FileName.ToString();

                    if (!File.Exists(path))
                    {
                        File.Create(path).Dispose();
                        File.WriteAllText(path, String.Empty);

                        using (var tw = new StreamWriter(path, true))
                        {
                            tw.WriteLine(ss);
                            tw.Close();
                        }
                    }
                    else if (File.Exists(path))
                    {
                        File.WriteAllText(path, String.Empty);
                        using (var tw = new StreamWriter(path, true))
                        {
                            tw.WriteLine(ss);
                            tw.Close();
                        }
                    }
                    MessageBox.Show("File Exported");
                    //this.Close();
                }
            }
        }

        private void Get_List_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string query = "select chalanno ,totalamt ,tblclient.firmid,chalandate ,clientid,AddCGSTAmt  ,AddIGSTAmt  ,AddSGSTAmt , TotGSTAmt  , tblclient.CompName,TotalTaxAmt  , GstBeforeAmt  from tbl_GstChallan inner join tblclient on tblclient.Id=tbl_GstChallan.clientid ";
            query += " where tbl_GstChallan.firmid= " + Data.id + " and (cast(chalandate as Date) between cast( '" + dateTimePicker1.Text + "' as date) and cast('" + dateTimePicker2.Text + "' as date)) and tbl_GstChallan.Delid=0";
            query += " order  by chalanno";
            //DataTable ds = DAl.GetDataTable(query);

            ds12 = data.getDataSet(query);
            if (ds12.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i <= ds12.Tables[0].Rows.Count - 1; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["SNo"].Value = i + 1;
                    dataGridView1.Rows[i].Cells["VoucherNo"].Value = ds12.Tables[0].Rows[i]["chalanno"].ToString();
                    dataGridView1.Rows[i].Cells["Date"].Value = Convert.ToDateTime(ds12.Tables[0].Rows[i]["chalandate"]).ToString("dd/MM/yyyy");
                    dataGridView1.Rows[i].Cells["PartyName"].Value = ds12.Tables[0].Rows[i]["CompName"].ToString();
                    dataGridView1.Rows[i].Cells["CGST"].Value = ds12.Tables[0].Rows[i]["AddCGSTAmt"].ToString();
                    dataGridView1.Rows[i].Cells["IGST"].Value = ds12.Tables[0].Rows[i]["AddIGSTAmt"].ToString();
                    dataGridView1.Rows[i].Cells["SGST"].Value = ds12.Tables[0].Rows[i]["AddSGSTAmt"].ToString();
                    dataGridView1.Rows[i].Cells["Amount"].Value = ds12.Tables[0].Rows[i]["TotalTaxAmt"].ToString();
                    dataGridView1.Rows[i].Cells["TaxableValue"].Value = ds12.Tables[0].Rows[i]["GstBeforeAmt"].ToString();
                }
            }
            else
            {
                MessageBox.Show("Record Not Found");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 0)
                {
                    DataGridViewCheckBoxCell cbc = (dataGridView1.CurrentRow.Cells[e.ColumnIndex] as DataGridViewCheckBoxCell);
                    object checker = cbc.Value;
                    if (checker == null)
                    {
                        dataGridView1.CurrentCell.Value = true;
                    }
                    else
                    {

                        if ((bool)checker == true)
                        {
                            dataGridView1.CurrentCell.Value = false;
                        }
                        else
                        {
                            dataGridView1.CurrentCell.Value = true;
                        }
                    }
                }
            }
        }
    }
}