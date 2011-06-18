using System;
using System.Web.UI;

namespace SoftStore.admin
{
    public partial class checkLogin : Page
    {
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            Object obj = Session["LOGINADMIN"];
            if (obj == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                Session["LOGINADMIN"] = obj;
            }
        }
    }
}
