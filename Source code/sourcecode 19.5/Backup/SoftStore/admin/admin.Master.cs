using System;
using System.Web.UI;
using BusinessObjects;

namespace SoftStore.admin
{
    public partial class admin : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                object obj = Session["LOGINADMIN"];
                if (obj != null)
                {
                    UsersInfo usi = (UsersInfo)obj;
                    ltName.Text = usi.FullName;
                    Session["LOGINADMIN"] = usi;
                }
            }
        }
    }
}
