using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Data;
using System.Web;


public sealed class SMS
{
    Data data = new Data();

    public void SendWhatsapp(string mobile, string msg)
    {
        try
        {
            mobile = "7742870061";
            // Get Firm Data
            DataSet dsFirm = data.getDataSet("SELECT * FROM tblFirm WHERE Firmid=" + Data.id);
            string instanceId = dsFirm.Tables[0].Rows[0]["instance_id"].ToString();
            string accessToken = dsFirm.Tables[0].Rows[0]["access_token"].ToString();

            // Encode message to avoid special character issue
            string encodedMsg = HttpUtility.UrlEncode(msg);

            // Build URL
            string url = "https://botmasterapi.in/api/send?number=91" + mobile +
                         "&type=text&message=" + encodedMsg +
                         "&instance_id=" + instanceId +
                         "&access_token=" + accessToken;

            // Force TLS 1.2 (works in .NET 3.5 SP1+ if registry enabled, otherwise comment this)
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; // TLS 1.2

            // Create request
            WebRequest request = WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;

            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            string responseFromServer = reader.ReadToEnd();

            reader.Close();
            response.Close();

        }
        catch (Exception ex)
        {
            //"Error: " + ex.Message;
        }
    }
    public void SendWhatsapp1(string Mobile, string Msg)
    {
        try
        {
            Mobile = "7742870061";
            //https://wapush.in/api/send?number=84933313xxx&type=text&message=test+message&instance_id=609ACF283XXXX&access_token=649018c703361
            DataSet dsFirm = data.getDataSet("select * from tblFirm where Firmid=" + Data.id);
            //string mess = "https://wapush.in/api/send.php?number=91" + Mobile + "&type=text&message=" + Msg + "&instance_id=" + dsFirm.Tables[0].Rows[0]["instance_id"] + "&access_token=" + dsFirm.Tables[0].Rows[0]["access_token"] + "";

            //string mess = "https://wapush.in/api/send?number=91" + Mobile + "&type=text&message=" + Msg + "&instance_id=" + dsFirm.Tables[0].Rows[0]["instance_id"] + "&access_token=" + dsFirm.Tables[0].Rows[0]["access_token"] + "";
            string mess = "https://botmasterapi.in/api/send?number=91" + Mobile + "&type=text&message=" + Msg + "&instance_id=" + dsFirm.Tables[0].Rows[0]["instance_id"] + "&access_token=" + dsFirm.Tables[0].Rows[0]["access_token"] + "";
            // Create a request for the URL. 
            WebRequest request = WebRequest.Create(mess);
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)768 | (SecurityProtocolType)3072;
            // Get the response.
            WebResponse response = request.GetResponse();

            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);
            // Clean up the streams and the response.
            reader.Close();
            response.Close();
        }
        catch { }
    }



    public void SendWhatsappPDF(string Mobile, string Msg, string _FIlPath)
    {
        try
        {
            Mobile = "7742870061";
            DataSet dsFirm = data.getDataSet("select * from tblFirm where Firmid=" + Data.id);
            DataSet dsFtpPath = data.getDataSet("select FtpPath from tbl_FTP where Delid=0");

            string _Path = dsFtpPath.Tables[0].Rows[0]["FtpPath"].ToString() + "/PDF/" + _FIlPath;
            //string mess = "https://wapush.in/api/send?number=91" + Mobile + "&type=media&message==" + Msg + "&media_url=" + _Path + "&instance_id=" + dsFirm.Tables[0].Rows[0]["instance_id"] + "&access_token=" + dsFirm.Tables[0].Rows[0]["access_token"] + "";

            string mess = "https://botmasterapi.in/api/send?number=91" + Mobile + "&type=media&message=" + Msg + "&media_url=" + _Path + "&filename=" + _FIlPath + "&instance_id=" + dsFirm.Tables[0].Rows[0]["instance_id"] + "&access_token=" + dsFirm.Tables[0].Rows[0]["access_token"] + "";

            //string mess = "https://botmasterapi.in/api/send?number=918209470846&type=media&message=test+message&media_url=https%3A%2F%2Fi.pravatar.cc&filename=file_test.jpg&instance_id=650004A3AAC6F&access_token=6500043bb462f";
            // Create a request for the URL. 
            WebRequest request = WebRequest.Create(mess);

            ServicePointManager.SecurityProtocol = (SecurityProtocolType)768 | (SecurityProtocolType)3072;
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);
            // Clean up the streams and the response.
            reader.Close();
            response.Close();
        }
        catch { }
    }
}