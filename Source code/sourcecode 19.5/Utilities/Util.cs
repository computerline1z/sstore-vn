using System;
using System.Collections;
using System.Data;
using System.Configuration;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Logger;

namespace Utilities
{
    public class Util
    {
        public static string SplitString(string str, int number_char)
        {
            int x = str.Length;
            if (x <= number_char)
                return str;
            else
            {
                string temp;
                temp = str.Substring(0, number_char);
                string last_indexof = temp.Substring(temp.Length - 1, 1);
                while (last_indexof != " ")
                {
                    temp = temp.Substring(0, temp.Length - 1);
                    last_indexof = temp.Substring(temp.Length - 1, 1);
                }
                return temp;
            }
        }
        public static void SendEmail(string from, string to, string subject, string body, string smtphost)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress(from);
                message.To.Add(new MailAddress(to));
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;
                message.BodyEncoding = Encoding.UTF8;
                SmtpClient client = new SmtpClient();
                client.Host = smtphost;
                client.Send(message);
            }
            catch (Exception ex)
            {
                Log.info("SendEmail err: " + ex.Message);
            }
        }
        public static string RemoveHTMLTag(string starttag, string endtag, string content)
        {
            if (content == null || content == "")
            {
                return null;
            }
            else
            {
                try
                {
                    if (content.Substring(0, starttag.Length).ToLower().Equals(starttag))
                        content = content.Substring(3);
                    if (content.Substring(content.Length - endtag.Length, endtag.Length).ToLower().Equals(endtag))
                        content = content.Substring(0, content.Length - endtag.Length);
                    return content;
                }
                catch
                {
                    return content;
                }
            }
        }
        public static string FormatDayTime(string strDate, string strFormat)
        {
            ArrayList arr = new ArrayList();
            StringTokenizer strTok = new StringTokenizer(strDate, "/");
            while (strTok.hasMoreTokens())
            {
                string s = strTok.nextToken();
                arr.Add(s);
            }
            //arr[0]: dd
            //arr[1]: mm
            //arr[2]: yyyy

            string strTemp = null;
            switch (strFormat)
            {

                case "mm/dd/yyyy":
                    strTemp = right("0" + arr[1], 2) + "/";
                    strTemp += right("0" + arr[0], 2) + "/";
                    strTemp += right("0" + arr[2], 4);
                    return strTemp;
                case "dd/mm/yyyy":
                    strTemp = right("0" + arr[0], 2) + "/";
                    strTemp += right("0" + arr[1], 2) + "/";
                    strTemp += right("0" + arr[2], 4);
                    return strTemp;

                case "yyyy/mm/dd":
                    strTemp = right("0" + arr[2], 4) + "/";
                    strTemp += right("0" + arr[1], 2) + "/";
                    strTemp += right("0" + arr[0], 2);
                    return strTemp;
            }
            return strTemp;
        }
        private static string right(string source, int pos)
        {
            string temp = "";
            for (int i = 0; i < pos; i++)
            {
                temp += source[source.Length - pos + i];
            }
            return temp;
        }
        public static string CreatePasswordHash(string pwd)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, "MD5");
        }
        public static bool CreateFolder(string path)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                if (dir.Exists)
                    return true;
                else
                    dir.Create();
                return true;
            }
            catch (Exception ex)
            {
                Log.info("CreateFolder err: " + ex.Message);
                return false;
            }
        }
        private static string twoChar(int valueCheck)
        {
            if (valueCheck > 9)
            {
                return valueCheck.ToString();
            }
            return ("0" + valueCheck);
        }
        public static string GetTimeSpan(DateTime time)
        {
            DateTime d = DateTime.Now;
            TimeSpan ts = d.Subtract(time);
            if (ts.TotalHours > 10)//qua 10 tieng
            {
                //return day string normal
                string date = Util.FormatDayTime(time.ToShortDateString(), "mm/dd/yyyy");
                string str = time.ToString();
                int hour = time.Hour;
                if (str.Substring(str.IndexOf(" ") + 1, 2) == "PM")
                {
                    hour += 12;
                }
                return date + " - " + (twoChar(hour) + ":" + twoChar(time.Minute));
            }
            else
            {
                //return my format
                double s = ts.TotalSeconds;
                double h;
                double m;
                if (s > 3600)//> 1h
                {
                    h = s / 3600;
                    if (s % 3600 >= 60)//> 1'
                        m = (s % 3600) / 60;
                    else
                        m = 1;//< 1'~1'
                }
                else
                {
                    h = 0;
                    if (s > 60)
                    {
                        m = s / 60;//so phut chan
                        if (s % 60 >= 60)//con > 1'
                            m += (s % 60) / 60;
                    }
                    else m = 0;
                }
                int ah = (int)h;
                int am = (int)m;

                return "Cách đây " + ah + " giờ " + am + " phút";
            }
        }
        public static string GetFileAttach(string SavePath, FileUpload flUpload)
        {
            try
            {
                string RootPath = HttpContext.Current.Request.PhysicalApplicationPath + SavePath;
                string StrFileName = flUpload.PostedFile.FileName.Substring(flUpload.PostedFile.FileName.LastIndexOf("\\") + 1);
                //string StrFileType = imgAdv.PostedFile.ContentType;

                int FileSize = flUpload.PostedFile.ContentLength;//max 2MB~2048000Bytes
                if (FileSize > 2048000)
                {
                    return null;
                }
                else
                {
                    flUpload.PostedFile.SaveAs(RootPath + "\\" + StrFileName);
                    return StrFileName;
                }
            }
            catch (Exception ex)
            {
                Log.info("GetFileAttach err: " + ex.Message);
                return null;
            }
        }
        public static string GetFileUpload(string SavePath, HtmlInputFile imgAdv)
        {
            string StrFileName = "";
            try
            {
                Thumbnail th = new Thumbnail();
                string RootPath = HttpContext.Current.Request.PhysicalApplicationPath + SavePath;
                if (imgAdv.PostedFile != null && imgAdv.PostedFile.FileName.Length != 0) //Checking for valid file
                {
                    // Since the PostedFile.FileNameFileName gives the entire path we use Substring function to rip of the filename alone.
                    string StrFileNameType = imgAdv.PostedFile.FileName.Substring(imgAdv.PostedFile.FileName.LastIndexOf(".") + 1);
                    //                    StrFileName = DateTime.Now.Ticks + "." + StrFileNameType;
                    StrFileName = imgAdv.PostedFile.FileName.Substring(imgAdv.PostedFile.FileName.LastIndexOf("\\") + 1);
                    //string StrFileType = imgAdv.PostedFile.ContentType;
                    int IntFileSize = imgAdv.PostedFile.ContentLength;
                    if (IntFileSize <= 0 || IntFileSize > 3145728)
                    {
                        return StrFileName;
                    } //error.Text = "upload failed";
                    else
                    {
                        imgAdv.PostedFile.SaveAs(RootPath + "\\" + StrFileName);
                        //th.GenerateThumbnail(StrFileName, "~" + SavePath, "175px_" + StrFileName, 175);

                        return StrFileName;
                    }
                }
                else
                {
                    return StrFileName;
                }

            }
            catch (Exception ex)
            {
                Log.info("getImage err " + ex.Message);
                return StrFileName;
            }
        }
        public static int GetInt(string str)
        {
            try
            {
                return int.Parse(str);
            }catch
            {
                return 0;
            }
        }
        public static void MoveAllValue(ListBox lbScr, ListBox lbDest)
        {
            foreach (ListItem listItem in lbScr.Items)
            {
                listItem.Selected = false;
                lbDest.Items.Add(listItem);
            }
            lbScr.Items.Clear();
        }
        public static void MoveSelectedValue(ListBox lbScr, ListBox lbDest)
        {
            foreach (ListItem listItem1 in lbScr.Items)
            {
                if (listItem1.Selected)
                    lbDest.Items.Add(listItem1);
            }
            for (int i = lbScr.Items.Count - 1; i >= 0; i--)
            {
                if (lbScr.Items[i].Selected)
                    lbScr.Items.RemoveAt(i);
            }
            foreach (ListItem listItem2 in lbDest.Items)
            {
                if (listItem2.Selected)
                    listItem2.Selected = false;
            }
        }
        public static void MoveSelectedValue(ListBox lbScr, ListBox lbDest, DropDownList drlDest)
        {
            foreach (ListItem listItem1 in lbScr.Items)
            {
                if (listItem1.Selected)
                {
                    lbDest.Items.Add(listItem1);
                    drlDest.Items.Add(listItem1);
                }
            }
            for (int i = lbScr.Items.Count - 1; i >= 0; i--)
            {
                if (lbScr.Items[i].Selected)
                    lbScr.Items.RemoveAt(i);
            }
            foreach (ListItem listItem2 in lbDest.Items)
            {
                if (listItem2.Selected)
                {
                    listItem2.Selected = false;
                }
            }
        }
        public static void MoveSelectedValue2to1(ListBox lbScr, ListBox lbDest, DropDownList drl)
        {
            foreach (ListItem listItem1 in lbScr.Items)
            {
                if (listItem1.Selected)
                {
                    lbDest.Items.Add(listItem1);
                    drl.Items.Remove(listItem1);
                }
            }
            for (int i = lbScr.Items.Count - 1; i >= 0; i--)
            {
                if (lbScr.Items[i].Selected)
                {
                    lbScr.Items.RemoveAt(i);
                    
                }
            }
            foreach (ListItem listItem2 in lbDest.Items)
            {
                if (listItem2.Selected)
                {
                    listItem2.Selected = false;
                }
            }
        }
        public static string GetFileIcon(string filename)
        {
            string ext = filename.Substring(filename.LastIndexOf("."));
            if (ext.ToLower().Equals(".doc"))
                return "<span class=\"icon\"><img src=\"themes/default/mime-icons/doc.gif\" /></span>";
            if (ext.ToLower().Equals(".docx"))
                return "<span class=\"icon\"><img src=\"themes/default/mime-icons/doc.gif\" /></span>";
            if (ext.ToLower().Equals(".xls"))
                return "<span class=\"icon\"><img src=\"themes/default/mime-icons/xls.gif\" /></span>";
            if (ext.ToLower().Equals(".xlsx"))
                return "<span class=\"icon\"><img src=\"themes/default/mime-icons/xls.gif\" /></span>";
            if (ext.ToLower().Equals(".rar"))
                return "<span class=\"icon\"><img src=\"themes/default/mime-icons/rar.gif\" /></span>";
            if (ext.ToLower().Equals(".zip"))
                return "<span class=\"icon\"><img src=\"themes/default/mime-icons/zip.gif\" /></span>";
            if (ext.ToLower().Equals(".mp3"))
                return "<span class=\"icon\"><img src=\"themes/default/mime-icons/mp3.gif\" /></span>";
            if (ext.ToLower().Equals(".exe"))
                return "<span class=\"icon\"><img src=\"themes/default/mime-icons/exe.gif\" /></span>";
            if (ext.ToLower().Equals(".txt"))
                return "<span class=\"icon\"><img src=\"themes/default/mime-icons/txt.gif\" /></span>";
            if (ext.ToLower().Equals(".pdf"))
                return "<span class=\"icon\"><img src=\"themes/default/mime-icons/pdf.gif\" /></span>";

            return "<img src=\"themes/default/mime-icons/file.gif\" /></span>";
        }
    }
    public class MaxString
    {
        /// <summary>
        /// Noi dung max 1000 ky tu
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetContent(string str)
        {
            try
            {
                if (str.Length > 1000)
                    return str.Substring(0, 1000);
                else return str;
            }
            catch
            {
                return str;
            }
        }
        public static string GetString(string str, int lenght)
        {
            try
            {
                if (str.Length > lenght)
                    return str.Substring(0, lenght);
                else return str;
            }
            catch
            {
                return str;
            }
        }
    }
    public class EmailConfig
    {
        public static string SMTP
        {
            get
            {
                return ConfigurationManager.AppSettings["SMTP"].ToString();
            }
        }
        public static string MailFrom
        {
            get
            {
                return ConfigurationManager.AppSettings["MAIL_FROM"].ToString();
            }
        }
        public static string UserName
        {
            get
            {
                return ConfigurationManager.AppSettings["USERNAME"].ToString();
            }
        }
        public static string Password
        {
            get
            {
                return ConfigurationManager.AppSettings["PASSWORD"].ToString();
            }
        }
        public static string MailTo
        {
            get
            {
                return ConfigurationManager.AppSettings["MAIL_TO"].ToString();
            }
        }
    }
}
