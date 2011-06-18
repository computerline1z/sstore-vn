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
    public class Notice
    {
        public static string Success(string strNotice)
        {
            return
                "<table class=\"tb_success\"><tr><td width=\"32\" style=\"vertical-align:middle\"><img src=\"themes/default/images/success.png\" /></td><td style=\"padding-top:10px;\">" + strNotice + "</td></tr></table>";
        }
        public static string Error(string strNotice)
        {
            return
                "<table class=\"tb_error\"><tr><td width=\"32\" style=\"vertical-align:middle\"><img src=\"themes/default/images/icon_error.gif\" /></td><td style=\"padding-top:10px;\">" + strNotice + "</td></tr></table>";
        }
    }
}
