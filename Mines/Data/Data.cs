using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Win32;
using WelcomeFabric;
using System.Net;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Linq;

/// <summary>
/// Summary description for Data
/// </summary>
public sealed class Data
{
    public string conString;
    SqlConnection sqlCon;
    SqlDataAdapter sqlAdp;
    SqlDataReader dr;
    SqlCommand cmd = new SqlCommand();
    DataSet ds;
    DataTable DtFTP = new DataTable();
    public static DataTable dttbl = new DataTable();
    public static string query;
    public static string query1;
    public static string query2;
    public static string dt1;
    public static string Area;
    public static string Group;
    public static string Date;
    public static string totAmt;
    public static string Discount;
    public static string BillingAmt;
    public static string receiptAmt;
    public static string id;
    public static string sessionid;
    public static string totcase;
    public static string billno;
    public static string compid;
    public static string UserId;
    public static string UserId1;
    public static string calvat;
    public static string ComapnyName;
    public static string UID;
    public static string NameUser;
    public static string Pageno;
    public static string IsFTP;
    public static DataTable dt = new DataTable();
    public static string reportformat;
    public static string reportformatdataset;

    public Data(string conStr)
    {
        conString = conStr;
        this.sqlCon = new SqlConnection(conString);
    }

    public Data()
    {
        ////Demo    
        ////this.conString = ConfigurationSettings.AppSettings["BSSCon"].ToString();

        //this.conString = " Data Source=.; Integrated Security=SSPI;Initial Catalog=db_SKTraders;"; 
        //Krishna Fabrics
        this.conString = " Data Source=183.83.176.36;Initial Catalog=aa_sb_db; user id=sb_user; password=Jpr@#@1234";

        this.sqlCon = new SqlConnection(conString);

        //if (this.conString == null)
        //{
        //    try
        //    {
        //        RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\DryFruits");
        //        this.conString = key.GetValue("OnlineServer").ToString();
        //        if (this.conString == "")
        //        {
        //            Form AskOnServer = new ConString();
        //            AskOnServer.ShowDialog();
        //        }
        //        this.sqlCon = new SqlConnection(this.conString);
        //    }
        //    catch
        //    {
        //        Form AskOnServer = new ConString();
        //        AskOnServer.ShowDialog();
        //    }

        //}
    }

    public string GetConnectionString
    {
        get { return conString; }
    }

    public SqlDataReader getDataReader(string commandString)
    {
        cmd.CommandText = commandString;
        cmd.Connection = sqlCon;
        sqlCon.Open();
        dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        return dr;
    }

    public string getDateMMDDYYYY(string dat)
    {
        string dat1 = "";
        string[] aa = dat.Split('/');
        dat1 = aa[1] + "/" + aa[0] + "/" + aa[2];
        return dat1;
    }

    public bool Exist(string commandString)
    {
        bool flag;
        cmd.CommandText = commandString;
        cmd.Connection = sqlCon;
        sqlCon.Open();
        dr = cmd.ExecuteReader();
        dr.Read();

        if (dr.HasRows)
            flag = true;
        else
            flag = false;

        dr.Close();
        sqlCon.Close();
        return flag;
    }
    public bool Exist(string commandString, string proc)
    {
        bool flag;
        //cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = commandString;
        cmd.Connection = sqlCon;
        sqlCon.Open();
        dr = cmd.ExecuteReader();
        dr.Read();

        if (dr.HasRows)
            flag = true;
        else
            flag = false;

        dr.Close();
        sqlCon.Close();
        return flag;
    }

    public DataSet getDataSet(string commandString)
    {
        ds = new DataSet();
        sqlAdp = new SqlDataAdapter(commandString, sqlCon);
        sqlAdp.Fill(ds);
        return ds;
    }
    public DataSet getDataSet(string commandString, string TableName)
    {
        ds = new DataSet();
        sqlAdp = new SqlDataAdapter(commandString, sqlCon);
        sqlAdp.Fill(ds, TableName);
        return ds;
    }
    public int executeCommand(string commandString)
    {
        cmd.CommandText = commandString;
        cmd.Connection = sqlCon;
        int errStatus = 0;
        try
        {

            sqlCon.Open();
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            errStatus = 1;
        }
        finally
        {
            sqlCon.Close();
        }
        return errStatus;
    }

    public int executeCommand(string commandString, out string str)
    {
        cmd.CommandText = commandString;
        cmd.Connection = sqlCon;
        str = "";
        int errStatus = 0;

        try
        {
            sqlCon.Open();
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            errStatus = 1;
            str = ex.Message;
        }
        finally
        {
            sqlCon.Close();
        }
        return errStatus;
    }

    public int executeCommand(SqlCommand sqlCommand)
    {
        sqlCommand.Connection = sqlCon;
        int errStatus = 0;
        try
        {
            sqlCon.Open();
            sqlCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            errStatus = 1;
        }
        finally
        {
            sqlCon.Close();
        }
        return errStatus;
    }

    public DataSet ExecuteDataset(SqlCommand sqlCommand)
    {
        DataSet ds = new DataSet();
        sqlCommand.Connection = sqlCon;
        try
        {
            sqlCon.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCommand;
            da.Fill(ds);
        }
        catch (Exception ex)
        {

        }
        finally
        {
            sqlCon.Close();
        }
        return ds;
    }

    public int executeCommand(SqlCommand sqlCommand, out string str)
    {
        sqlCommand.Connection = sqlCon;
        int errStatus = 0;
        str = "";
        try
        {
            sqlCon.Open();
            sqlCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            errStatus = 1;
            str = ex.Message;
        }
        finally
        {
            sqlCon.Close();
        }
        return errStatus;
    }

    public String changeNumericToWords(double numb)
    {

        String num = numb.ToString();

        return changeToWords(num, false);

    }

    public String changeCurrencyToWords(String numb)
    {

        return changeToWords(numb, true);

    }

    public String changeNumericToWords(String numb)
    {

        return changeToWords(numb, false);

    }

    public String changeCurrencyToWords(double numb)
    {

        return changeToWords(numb.ToString(), true);

    }

    private String changeToWords(String numb, bool isCurrency)
    {

        String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";

        String endStr = (isCurrency) ? ("Only") : ("");

        try
        {

            int decimalPlace = numb.IndexOf(".");

            if (decimalPlace > 0)
            {

                wholeNo = numb.Substring(0, decimalPlace);

                points = numb.Substring(decimalPlace + 1);

                if (Convert.ToInt32(points) > 0)
                {

                    andStr = (isCurrency) ? ("and") : ("point");// just to separate whole numbers from points/cents

                    endStr = (isCurrency) ? ("Paise " + endStr) : ("");

                    pointStr = translateCents(points);

                }

            }

            val = String.Format("{0} {1}{2} {3}", translateWholeNumber(wholeNo).Trim(), andStr, pointStr, endStr);

        }

        catch { ;}

        return val;

    }

    private String translateWholeNumber(String number)
    {

        string word = "";

        try
        {

            bool beginsZero = false;//tests for 0XX

            bool isDone = false;//test if already translated

            double dblAmt = (Convert.ToDouble(number));

            //if ((dblAmt > 0) && number.StartsWith("0"))

            if (dblAmt > 0)
            {//test for zero or digit zero in a nuemric

                beginsZero = number.StartsWith("0");

                int numDigits = number.Length;

                int pos = 0;//store digit grouping

                String place = "";//digit grouping name:hundres,thousand,etc...

                switch (numDigits)
                {
                    case 1://ones' range

                        word = ones(number);

                        isDone = true;

                        break;

                    case 2://tens' range

                        word = tens(number);

                        isDone = true;

                        break;

                    case 3://hundreds' range

                        pos = (numDigits % 3) + 1;

                        if (number.Substring(0, 1) != "0")
                            place = " Hundred ";

                        break;

                    case 4://thousands' range
                        pos = (numDigits % 4) + 1;
                        if (number.Substring(0, 1) != "0")
                            place = " Thousand ";
                        break;
                    case 5:
                        pos = (numDigits % 4) + 1;
                        if (number.Substring(0, 2) != "00")
                            place = " Thousand ";

                        break;
                    case 6:
                        pos = (numDigits % 6) + 1;
                        if (number.Substring(0, 1) != "0")
                            place = " Lac ";
                        break;
                    case 7://Lac's range
                        pos = (numDigits % 6) + 1;
                        if (number.Substring(0, 1) != "000")
                            place = " Lac ";
                        break;
                    case 8:

                    case 9:

                        pos = (numDigits % 8) + 1;

                        place = " Crore ";

                        break;

                    case 10://Billions's range

                        pos = (numDigits % 10) + 1;

                        place = " Billion ";

                        break;

                    //add extra case options for anything above Billion...

                    default:

                        isDone = true;

                        break;

                }

                if (!isDone)
                {//if transalation is not done, continue...(Recursion comes in now!!)

                    word = translateWholeNumber(number.Substring(0, pos)) + place + translateWholeNumber(number.Substring(pos));

                    //check for trailing zeros

                    //if (beginsZero) word = " and " + word.Trim();

                }

                //ignore digit grouping names

                if (word.Trim().Equals(place.Trim())) word = "";

            }

        }

        catch { ;}

        return word.Trim();

    }

    private String tens(String digit)
    {

        int digt = Convert.ToInt32(digit);

        String name = null;

        switch (digt)
        {

            case 10:

                name = "Ten";

                break;

            case 11:

                name = "Eleven";

                break;

            case 12:

                name = "Twelve";

                break;

            case 13:

                name = "Thirteen";

                break;

            case 14:

                name = "Fourteen";

                break;

            case 15:

                name = "Fifteen";

                break;

            case 16:

                name = "Sixteen";

                break;

            case 17:

                name = "Seventeen";

                break;

            case 18:

                name = "Eighteen";

                break;

            case 19:

                name = "Nineteen";

                break;

            case 20:

                name = "Twenty";

                break;

            case 30:

                name = "Thirty";

                break;

            case 40:

                name = "Fourty";

                break;

            case 50:

                name = "Fifty";

                break;

            case 60:

                name = "Sixty";

                break;

            case 70:

                name = "Seventy";

                break;

            case 80:

                name = "Eighty";

                break;

            case 90:

                name = "Ninety";

                break;

            default:

                if (digt > 0)
                {

                    name = tens(digit.Substring(0, 1) + "0") + " " + ones(digit.Substring(1));

                }

                break;

        }

        return name;

    }

    private String ones(String digit)
    {

        int digt = Convert.ToInt32(digit);

        String name = "";

        switch (digt)
        {

            case 1:

                name = "One";

                break;

            case 2:

                name = "Two";

                break;

            case 3:

                name = "Three";

                break;

            case 4:

                name = "Four";

                break;

            case 5:

                name = "Five";

                break;

            case 6:

                name = "Six";

                break;

            case 7:

                name = "Seven";

                break;

            case 8:

                name = "Eight";

                break;

            case 9:

                name = "Nine";

                break;

        }

        return name;

    }

    private String translateCents(String cents)
    {

        String cts = "", digit = "", engOne = "";

        for (int i = 0; i < cents.Length; i++)
        {

            digit = cents[i].ToString();

            if (digit.Equals("0"))
            {

                engOne = "Zero";

            }

            else
            {

                engOne = ones(digit);

            }

            cts += " " + engOne;

        }

        return cts;

    }

    public string GetName(int Pid)
    {
        string GetName1 = "";
        string commandString = "select (f_name & ' ' & L_Name ) as Nam from tbl_patientInfo where Pid=" + Pid;
        cmd.CommandText = commandString;
        cmd.Connection = sqlCon;
        sqlCon.Open();
        dr = cmd.ExecuteReader();
        dr.Read();

        if (dr.HasRows)
            GetName1 = dr["Nam"].ToString();
        else
            GetName1 = "";

        dr.Close();
        sqlCon.Close();
        return GetName1;
    }

    public DataTable GetDataTable(string commandString)
    {
        DataTable dt = new DataTable();
        sqlAdp = new SqlDataAdapter(commandString, sqlCon);
        sqlAdp.Fill(dt);
        return dt;
    }


    #region Get/Upload Image on Local/Server

    public void UploadImageOnFTP(PictureBox DesignImg, string drive, string Name)
    {
        try
        {
            if (!DesignImg.ImageLocation.Contains("NoImage"))
            {
                DtFTP = GetDataTable("select * from tbl_FTP where Delid=0");
                string FIlePath = DtFTP.Rows[0]["FtpPath"].ToString();
                string UserName = DtFTP.Rows[0]["FtpUser"].ToString();
                string PWD = DtFTP.Rows[0]["FtpPWd"].ToString();
                string Ftp = DtFTP.Rows[0]["Ftp"].ToString();

                string _FIleName = Ftp + "/" + drive + "/" + Name + ".jpg";
                using (WebClient client = new WebClient())
                {
                    client.Credentials = new NetworkCredential(UserName, PWD);
                    client.UploadFile(_FIleName, DesignImg.ImageLocation);

                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void UploadFileToFTP(string source)
    {
        try
        {
            DtFTP = GetDataTable("select * from tbl_FTP where Delid=0");
            string FIlePath = DtFTP.Rows[0]["FtpPath"].ToString();
            string ftpusername = DtFTP.Rows[0]["FtpUser"].ToString();
            string ftppassword = DtFTP.Rows[0]["FtpPWd"].ToString();
            string ftpurl = DtFTP.Rows[0]["Ftp"].ToString();


            string filename = Path.GetFileName(source);
            //string ftpfullpath = ftpurl;
            FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(ftpurl);
            ftp.Credentials = new NetworkCredential(ftpusername, ftppassword);

            ftp.KeepAlive = true;
            ftp.UseBinary = true;
            ftp.Method = WebRequestMethods.Ftp.UploadFile;

            FileStream fs = File.OpenRead(source);
            byte[] buffer = new byte[fs.Length];
            fs.Read(buffer, 0, buffer.Length);
            fs.Close();

            Stream ftpstream = ftp.GetRequestStream();
            ftpstream.Write(buffer, 0, buffer.Length);
            ftpstream.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void UploadFileToFTP(PictureBox DesignImg, string drive, string Name)
    {
        try
        {
            PictureBox pp = new PictureBox();
            UploadImageOnLocal(DesignImg, drive, Name);

            pp.ImageLocation = Directory.GetCurrentDirectory() + "/" + drive + "/" + Name;
            DtFTP = GetDataTable("select * from tbl_FTP where Delid=0");
            string FIlePath = DtFTP.Rows[0]["FtpPath"].ToString();
            string ftpusername = DtFTP.Rows[0]["FtpUser"].ToString();
            string ftppassword = DtFTP.Rows[0]["FtpPWd"].ToString();
            string ftpurl = @"ftp://" + DtFTP.Rows[0]["Ftp"].ToString();

            string _FIleName = ftpurl + "/" + drive + "/" + Name;

            FtpWebRequest ftpClient = (FtpWebRequest)FtpWebRequest.Create(_FIleName);
            ftpClient.Credentials = new System.Net.NetworkCredential(ftpusername, ftppassword);
            ftpClient.Method = System.Net.WebRequestMethods.Ftp.UploadFile;
            ftpClient.UseBinary = true;
            ftpClient.KeepAlive = true;
            System.IO.FileInfo fi = new System.IO.FileInfo(@"" + pp.ImageLocation);
            ftpClient.ContentLength = fi.Length;

            int bytes = 0;

            byte[] buffer = ResizeImageToByteActual(DesignImg.Image);
            int total_bytes = (int)fi.Length;
            System.IO.FileStream fs = fi.OpenRead();
            System.IO.Stream rs = ftpClient.GetRequestStream();
            while (total_bytes > 0)
            {
                bytes = fs.Read(buffer, 0, buffer.Length);
                rs.Write(buffer, 0, bytes);
                total_bytes = total_bytes - bytes;
            }
            //fs.Flush();
            fs.Close();
            rs.Close();
            FtpWebResponse uploadResponse = (FtpWebResponse)ftpClient.GetResponse();
            //value = uploadResponse.StatusDescription;
            uploadResponse.Close();
            File.Delete(pp.ImageLocation);

        }
        catch
        { }
    }

    public void UploadFileToFTP(PictureBox DesignImg, string drive, string Name, String Size)
    {
        try
        {
            PictureBox pp = new PictureBox();
            UploadImageOnLocal(DesignImg, drive, Name, Size);
            if (Size == "Small")
            {
                pp.ImageLocation = Directory.GetCurrentDirectory() + "/" + drive + "/" + Size + "/" + Name;
            }
            if (Size == "Medium")
            {
                pp.ImageLocation = Directory.GetCurrentDirectory() + "/" + drive + "/" + Size + "/" + Name;
            }
            if (Size == "Large")
            {
                pp.ImageLocation = Directory.GetCurrentDirectory() + "/" + drive + "/" + Size + "/" + Name;
            }

            DtFTP = GetDataTable("select * from tbl_FTP where Delid=0");
            string FIlePath = DtFTP.Rows[0]["FtpPath"].ToString();
            string ftpusername = DtFTP.Rows[0]["FtpUser"].ToString();
            string ftppassword = DtFTP.Rows[0]["FtpPWd"].ToString();
            string ftpurl = @"ftp://" + DtFTP.Rows[0]["Ftp"].ToString();

            string _FIleName = ftpurl + "/" + drive + "/" + Size + "/" + Name;

            FtpWebRequest ftpClient = (FtpWebRequest)FtpWebRequest.Create(_FIleName);
            ftpClient.Credentials = new System.Net.NetworkCredential(ftpusername, ftppassword);
            ftpClient.Method = System.Net.WebRequestMethods.Ftp.UploadFile;
            ftpClient.UseBinary = true;
            ftpClient.KeepAlive = true;
            System.IO.FileInfo fi = new System.IO.FileInfo(@"" + pp.ImageLocation);
            ftpClient.ContentLength = fi.Length;

            int bytes = 0;

            byte[] buffer = ResizeImageToByteActual(DesignImg.Image);
            int total_bytes = (int)fi.Length;
            System.IO.FileStream fs = fi.OpenRead();
            System.IO.Stream rs = ftpClient.GetRequestStream();
            while (total_bytes > 0)
            {
                bytes = fs.Read(buffer, 0, buffer.Length);
                rs.Write(buffer, 0, bytes);
                total_bytes = total_bytes - bytes;
            }
            //fs.Flush();
            fs.Close();
            rs.Close();
            FtpWebResponse uploadResponse = (FtpWebResponse)ftpClient.GetResponse();
            uploadResponse.Close();
            File.Delete(pp.ImageLocation);

        }
        catch
        { }
    }

    public void UploadImageOnLocal(PictureBox DesignImg, string drive, string Name)
    {
        try
        {
            if (!DesignImg.ImageLocation.Contains("No_Image"))
            {
                string dir = Directory.GetCurrentDirectory() + "/" + drive;

                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                Bitmap bmp = (Bitmap)System.Drawing.Image.FromFile(DesignImg.ImageLocation);
                ImageSave(bmp, 150, 150, 90, dir + "/" + Name );
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

   /* public void UploadImageOnLocal(PictureBox DesignImg, string drive, string Name)
    {
        try
        {
            if (!DesignImg.ImageLocation.Contains("NoImage.jpg"))
            {

                //GetImageOnServerInGrid(drive, Name, DesignImg.ImageLocation);


                string dir = Directory.GetCurrentDirectory() + "\\" + drive;

                string aa = "\\";
                string bbb = "/";
                string _Path = dir.Replace(aa, bbb);

                if (!Directory.Exists(_Path))
                {
                    Directory.CreateDirectory(_Path);
                }

                string vv = _Path + "/" + Name;
                Bitmap bmp = (Bitmap)System.Drawing.Image.FromFile(vv);
                //Bitmap bmp = (Bitmap)System.Drawing.Image.FromFile(DesignImg.ImageLocation);
                ImageSave(bmp, 500, 500, 90, _Path + "/" + Name + "");

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }*/

    public void UploadImageOnLocal(PictureBox DesignImg, string drive, string Name, String Size)
    {
        try
        {
            if (!DesignImg.ImageLocation.Contains("NoImage.jpg"))
            {

                GetImageOnServerInGrid(drive, Name, DesignImg.ImageLocation);


                string dir = Directory.GetCurrentDirectory() + "/" + drive;

                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                // dir = dir + "/" + Name;

                string vv = dir + "/" + Name;
                Bitmap bmp = (Bitmap)System.Drawing.Image.FromFile(vv);
                if (Size == "Small")
                {
                    ImageSave(bmp, 100, 100, 90, dir + "/" + Size + "/" + Name + "");
                }
                if (Size == "Medium")
                {
                    ImageSave(bmp, 300, 300, 90, dir + "/" + Size + "/" + Name + "");
                }
                if (Size == "Large")
                {
                    ImageSave(bmp, 700, 700, 90, dir + "/" + Size + "/" + Name + "");
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void GetImageOnServer(string Drive, string FileName, PictureBox imm)
    {

        DtFTP = GetDataTable("select * from tbl_FTP where Delid=0");
        string FIlePath = DtFTP.Rows[0]["FtpPath"].ToString();
        string ftpusername = DtFTP.Rows[0]["FtpUser"].ToString();
        string ftppassword = DtFTP.Rows[0]["FtpPWd"].ToString();
        string ftpurl = @"ftp://" + DtFTP.Rows[0]["Ftp"].ToString();

        try
        {
            string _FIleName = ftpurl + "/" + Drive + "/" + FileName;
            FtpWebRequest ftpClient = (FtpWebRequest)FtpWebRequest.Create(_FIleName);
            ftpClient.Credentials = new System.Net.NetworkCredential(ftpusername, ftppassword);
            ftpClient.Method = WebRequestMethods.Ftp.GetFileSize;
            FtpWebResponse response = (FtpWebResponse)ftpClient.GetResponse();
            imm.ImageLocation = FIlePath + "/" + Drive + "/" + FileName;
        }
        catch (WebException ex)
        {
            try
            {
                string _FIleName = ftpurl + "/" + Drive + "/" + FileName;
                FtpWebRequest ftpClient = (FtpWebRequest)FtpWebRequest.Create(_FIleName);
                ftpClient.Credentials = new System.Net.NetworkCredential(ftpusername, ftppassword);
                ftpClient.Method = WebRequestMethods.Ftp.GetFileSize;
                FtpWebResponse response = (FtpWebResponse)ftpClient.GetResponse();
                imm.ImageLocation = FIlePath + "/" + Drive + "/" + FileName;
            }
            catch (WebException exx)
            {
                FtpWebResponse response = (FtpWebResponse)exx.Response;
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    imm.ImageLocation = FIlePath + "/" + Drive + "/NoImage.jpg";
                }
            }
        }
    }

    public void CheckIfFileExistsOnServer(string Drive, string fileName, PictureBox imm)
    {
        DtFTP = GetDataTable("select * from tbl_FTP where Delid=0");
        string FIlePath = DtFTP.Rows[0]["FtpPath"].ToString();
        string ftpusername = DtFTP.Rows[0]["FtpUser"].ToString();
        string ftppassword = DtFTP.Rows[0]["FtpPWd"].ToString();
        string ftpurl = @"ftp://" + DtFTP.Rows[0]["Ftp"].ToString();

        string _FIleName = ftpurl + "/" + Drive + "/" + fileName;

        FtpWebRequest ftpClient = (FtpWebRequest)FtpWebRequest.Create(_FIleName);
        ftpClient.Credentials = new System.Net.NetworkCredential(ftpusername, ftppassword);
        ftpClient.Method = WebRequestMethods.Ftp.GetFileSize;
        try
        {
            FtpWebResponse response = (FtpWebResponse)ftpClient.GetResponse();
            imm.ImageLocation = FIlePath + "/" + Drive + "/" + fileName;
        }
        catch (WebException ex)
        {
            FtpWebResponse response = (FtpWebResponse)ex.Response;
            if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
            {
                imm.ImageLocation = FIlePath + "/" + Drive + "/NoImage.jpg";
            }
        }
    }

    public void GetImageOnLocal(string Drive, string FileName, PictureBox imm)
    {
        string dir = Directory.GetCurrentDirectory();
        string FilePath = dir + "/" + Drive + "/" + FileName;
        if (File.Exists(FilePath))
        {
            imm.ImageLocation = dir + "/" + Drive + "/" + FileName;
        }
        else
        {
            imm.ImageLocation = dir + "/" + Drive + "/NoImage.jpg";
        }
    }

    public void GetImageOnLocalInGrid(string Drive, string FileName, DataGridView dgv, int row, string column, PictureBox imm)
    {
        string dir = Directory.GetCurrentDirectory();
        string FilePath = dir + "/" + Drive + "/" + FileName;
        if (File.Exists(FilePath))
        {
            imm.ImageLocation = dir + "/" + Drive + "/" + FileName;
        }
        else
        {
            imm.ImageLocation = dir + "/" + Drive + "/NoImage.jpg";
        }

        Bitmap img = new Bitmap(imm.ImageLocation);
        DataGridViewImageColumn cell = (DataGridViewImageColumn)dgv.Columns[column];
        cell.Image = img;
    }

    public Image GetImageOnLocalInGrid(string Drive, string FileName)
    {
        string dir = Directory.GetCurrentDirectory();
        string FilePath = dir + "/" + Drive + "/" + FileName;
        if (File.Exists(FilePath))
        {
            FilePath = dir + "/" + Drive + "/" + FileName;
        }
        else
        {
            FilePath = dir + "/" + Drive + "/NoImage.jpg";
        }

        Bitmap img = new Bitmap(FilePath);
        return img;
    }

    public void ImageSave(Bitmap image, int maxWidth, int maxHeight, int quality, string filePath)
    {

        // Get the image's original width and height
        int originalWidth = image.Width;
        int originalHeight = image.Height;

        // To preserve the aspect ratio
        float ratioX = (float)maxWidth / (float)originalWidth;
        float ratioY = (float)maxHeight / (float)originalHeight;
        float ratio = Math.Min(ratioX, ratioY);

        // New width and height based on aspect ratio
        int newWidth = (int)(originalWidth * ratio);
        int newHeight = (int)(originalHeight * ratio);

        // Convert other formats (including CMYK) to RGB.
        Bitmap newImage = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);

        // Draws the image in the specified size with quality mode set to HighQuality
        using (Graphics graphics = Graphics.FromImage(newImage))
        {
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.DrawImage(image, 0, 0, newWidth, newHeight);
        }

        // Get an ImageCodecInfo object that represents the JPEG codec.
        ImageCodecInfo imageCodecInfo = this.GetEncoderInfo(ImageFormat.Jpeg);

        // Create an Encoder object for the Quality parameter.
        System.Drawing.Imaging.Encoder encoder = System.Drawing.Imaging.Encoder.Quality;

        // Create an EncoderParameters object. 
        EncoderParameters encoderParameters = new EncoderParameters(1);

        // Save the image as a JPEG file with quality level.
        EncoderParameter encoderParameter = new EncoderParameter(encoder, quality);
        encoderParameters.Param[0] = encoderParameter;
        newImage.Save(filePath, imageCodecInfo, encoderParameters);


    }

    private ImageCodecInfo GetEncoderInfo(ImageFormat format)
    {
        return ImageCodecInfo.GetImageDecoders().SingleOrDefault(c => c.FormatID == format.Guid);
    }

    public void GetFTP()
    {
        DtFTP = GetDataTable("select * from tbl_FTP where Delid=0");
    }

    public static Bitmap Base64StringToBitmap(string base64String)
    {
        Bitmap bmpReturn = null;
        byte[] byteBuffer = Convert.FromBase64String(base64String);
        MemoryStream memoryStream = new MemoryStream(byteBuffer);
        memoryStream.Position = 0;
        bmpReturn = (Bitmap)Bitmap.FromStream(memoryStream);
        memoryStream.Close();
        memoryStream = null;
        byteBuffer = null;
        return bmpReturn;
    }

    public byte[] ResizeImageToByteActual(Image image)
    {
        byte[] arrImage;
        Bitmap thumbnailBitmap = new Bitmap(100, 100);
        Graphics thumbnailGraph = Graphics.FromImage(thumbnailBitmap);
        thumbnailGraph.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
        thumbnailGraph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        thumbnailGraph.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        Rectangle imageRectangle = new Rectangle(0, 0, 100, 100);
        thumbnailGraph.DrawImage(image, imageRectangle);
        MemoryStream ms = new MemoryStream();
        thumbnailBitmap.Save(ms, image.RawFormat);
        arrImage = ms.GetBuffer();
        thumbnailGraph.Dispose();
        thumbnailBitmap.Dispose();
        return arrImage;
    }

    public void ResizeThumbImages(string Filename, System.Drawing.Image imageToBeResized, string imagetype, string drive)
    {
        int maxHeight = 0;
        int maxWidth = 0;
        // Resize Image Before Uploading to DataBase
        // System.Drawing.Image imageToBeResized = System.Drawing.Image.FromStream(FlpDownload.PostedFile.InputStream);
        int imageHeight = imageToBeResized.Height;
        int imageWidth = imageToBeResized.Width;
        if (imagetype == "Small")
        {
            maxHeight = 500;
            maxWidth = 500;
        }
        string smallUpload_dir = Directory.GetCurrentDirectory() + "/" + drive;


        if (imageHeight > maxHeight)
        {
            imageWidth = (imageWidth * maxHeight) / imageHeight;
            imageHeight = maxHeight;
        }
        if (imageWidth > maxWidth)
        {
            imageHeight = (imageHeight * maxWidth) / imageWidth;
            imageWidth = maxWidth;
        }



        byte[] byteBuffer = (byte[])(new ImageConverter()).ConvertTo(imageToBeResized, typeof(byte[]));
        System.IO.MemoryStream stream = new System.IO.MemoryStream(byteBuffer);
        Bitmap source = new Bitmap(stream);

        Bitmap target = new Bitmap(imageWidth, imageHeight);
        Graphics g = Graphics.FromImage(target);

        EncoderParameters e;
        g.CompositingQuality = CompositingQuality.HighSpeed;
        g.InterpolationMode = InterpolationMode.Low;

        Rectangle recCompression = new Rectangle(0, 0, imageWidth, imageHeight);
        g.DrawImage(source, recCompression);

        e = new EncoderParameters(2);
        e.Param[0] = new EncoderParameter(Encoder.Quality, 70);
        e.Param[1] = new EncoderParameter(Encoder.Compression, (long)EncoderValue.CompressionLZW);

        target.Save(smallUpload_dir + "/" + Filename, ImageFormat.Jpeg);

        g.Dispose();
    }

    public Image GetImageOnServerInGrid(string Drive, string FileName, string OnlInePath)
    {
        string dir = Directory.GetCurrentDirectory();
        string _LocalPath = dir + "/" + Drive + "/" + FileName + "";
        Bitmap bitmap;
        try
        {
            DtFTP = GetDataTable("select * from tbl_FTP where Delid=0");
            string FIlePath = DtFTP.Rows[0]["FtpPath"].ToString();
            string ftpusername = DtFTP.Rows[0]["FtpUser"].ToString();
            string ftppassword = DtFTP.Rows[0]["FtpPWd"].ToString();

            //string _Path = @"" + FIlePath + "/" + Drive + "/" + FileName;
            string _Path = @"" + OnlInePath;
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(_Path);
            bitmap = new Bitmap(stream);

            if (bitmap != null)
                bitmap.Save(_LocalPath);

            stream.Flush();
            stream.Close();
            client.Dispose();

            if (File.Exists(_LocalPath))
            {
                Bitmap img = new Bitmap(_LocalPath);
                bitmap = img;
            }
            else
            {
                // bitmap = Garments.Properties.Resources.NoImage;
            }
            return bitmap;
        }
        catch
        {
            bitmap = WelcomeFabric.Properties.Resources.NoImage;
            return bitmap;
        }
    }

    #endregion

    public void LogError(string ErrorName, string ErrorLocation, string Form, string ErrorDetails, string LoginId)
    {
        string q = "INSERT INTO [_TblLogError]([ErrorName],[ErrorLocation],[CreateUser],[FormName],[ErrorDetails]) VALUES (@ErrorName,@ErrorLocation,@CreateUser,@FormName,@ErrorDetails)";
        cmd.CommandText = q;
        cmd.Parameters.Clear();
        cmd.Parameters.AddWithValue("@ErrorName", ErrorName);
        cmd.Parameters.AddWithValue("@ErrorLocation", ErrorLocation);
        cmd.Parameters.AddWithValue("@CreateUser", LoginId);
        cmd.Parameters.AddWithValue("@FormName", Form);
        cmd.Parameters.AddWithValue("@ErrorDetails", ErrorDetails);
        executeCommand(cmd);
    }


}