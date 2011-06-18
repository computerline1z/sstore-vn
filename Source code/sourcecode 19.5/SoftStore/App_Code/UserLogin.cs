using System.Collections.Generic;
using System.Web;
using DataAccessLayer;
using BusinessObjects;
using Utilities;

namespace SoftStore.App_Code
{
    public class UserLogin
    {
        private static Users us = new Users();

        /// <summary>
        /// Người dùng đang đăng nhập, nếu ko có session, redirect đến default.aspx?n=login
        /// </summary>
        /// <returns></returns>
        public static UsersInfo GetUserLoging()
        {
            object obj = HttpContext.Current.Session["LOGINADMIN"];
            if (obj == null)
            {
                HttpContext.Current.Response.Redirect("default.aspx?n=login");
                return null;
            }
            else
            {
                HttpContext.Current.Session["LOGINADMIN"] = obj;
                return (UsersInfo)obj;
            }
        }
    }
    public class OnlineNow
    {
        private static string online;
        public static string Online
        {
            get { return online; }
            set { online = value; }
        }
        private static string totalonline;
        public static string TotalOnline
        {
            get { return totalonline; }
            set { totalonline = value; }
        }
    }

}
