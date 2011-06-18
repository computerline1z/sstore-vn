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
    public class Jquery
    {
        public static string Notification(string strTitle, string strNotice)
        {
            string str = "<script type=\"text/javascript\">"
                         + "$(function() {"
                         + "$(\"#dialog\").dialog(\"destroy\");"
                         + "$(\"#modal-message\").dialog({"
                         + "autoOpen: true,"
                         + "draggable: true,"
                         + "height:130,"
                         + "modal: true,"
                         + "buttons: {"
                         + "'OK': function() {"
                         + "$(this).dialog('close');"
                         + "}"
                         + "}"
                         + "});"
                         + "});"
                         + "</script>";
            str += "<div id=\"modal-message\" title=\"" + strTitle + "\"><p>" + strNotice + "</p></div>";
//            HttpContext.Current.Response.Write(str);
            return str;
        }
        public static string ConfirmDialog(string strTitle, string strNotice, Button btn)
        {
            string str = "<script type=\"text/javascript\">"
                         + "$(function() {"
                         + "$(\"#dialog\").dialog(\"destroy\");"
                         + "$(\"#dialog-confirm\").dialog({"
                         + "autoOpen: true,"
                         + "draggable: true,"
                         + "height:130,"
                         + "modal: true,"
                         + "buttons: {"
                         + "'Đồng ý': function() {"
                         + "__doPostBack('" + btn.ClientID + "','');"
                         + "$(this).dialog('close');"
                         + "},"
                         + "'Đóng': function() {"
                         + "$(this).dialog('close');"
                         + "}"
                         + "});"
                         + "});"
                         + "</script>";
            str += "<div id=\"dialog-confirm\" title=\"" + strTitle + "\"><p>" + strNotice + "</p></div>";
            return str;
        }
        public static string ShowReminder(string strNotice, string DoPostBack)
        {
            string str = "<script type=\"text/javascript\">"
                         + "$(function() {"
                         + "$(\"#dialog\").dialog(\"destroy\");"
                         + "$(\"#dialog-confirm\").dialog({"
                         + "autoOpen: true,"
                         + "draggable: true,"
                         + "height:200,"
                         + "width:500,"
                         + "modal: true,"
                         + "buttons: {"
                         + "'Xong': function() {"
                         + DoPostBack + ";"
                         + "$(this).dialog('close');"
                         + "},"
                         + "'Nhắc lại sau': function() {"
                         + "$(this).dialog('close');"
                         + "}"
                         + "}"
                         + "});"
                         + "});"
                         + "</script>";
            str += "<div id=\"dialog-confirm\" title=\"Lịch nhắc việc cá nhân\"><p>" + strNotice + "</p></div>";
            return str;
        }
    }
}
