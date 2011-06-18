using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace SoftStore.App_Code
{
    public class Configuration
    {

        public static string LinkSXL
        {
            get
            {
                return null;//lay link nay theo portal
            }
        }

        public static string PathOfWorkAttachFile
        {
            get
            {
                return ConfigurationManager.AppSettings["PathOfWorkAttachFile"];
            }
        }

        public static string PathOfAnnouncementAttachFile
        {
            get
            {
                return ConfigurationManager.AppSettings["PathOfAnnouncementAttachFile"];
            }
        }

        
    }
    public class LogType
    {
        public static int Note
        {
            get { return 0; }
        }

        public static int Report
        {
            get { return 1; }
        }

        public static int Transfer
        {
            get { return 2; }
        }

        public static int AddViewableUser
        {
            get { return 3; }
        }
    }
    public class LogStatus
    {
        public static int Begin
        {
            get { return 3; }
        }
        public static int InProgress
        {
            get { return 1; }
        }
        public static int FinishAndNoKeepRight
        {
            get { return 2; }
        }
        public static int FinishAndKeepRight
        {
            get { return 0; }
        }
        public static int RequestFinish
        {
            get { return 4; }
        }
    }
}
