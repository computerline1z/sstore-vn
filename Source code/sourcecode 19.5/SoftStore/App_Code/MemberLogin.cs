using System.Collections.Generic;
using System.Web;
using DataAccessLayer;
using BusinessObjects;
using Utilities;

namespace SoftStore.App_Code
{
    public class MemberLogin
    {
        public static MembersInfo GetMemberLogin()
        {
            object obj = HttpContext.Current.Session["MEMBERLOGIN"];
            if (obj == null)
            {
                //HttpContext.Current.Response.Redirect("/trang-chu.html");
                return null;
            }
            else
            {
                HttpContext.Current.Session["MEMBERLOGIN"] = obj;
                return (MembersInfo)obj;
            }
        }
    }
}
