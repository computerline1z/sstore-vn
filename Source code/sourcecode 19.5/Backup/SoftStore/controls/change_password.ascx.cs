using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SoftStore.App_Code;

namespace SoftStore.controls
{
    public partial class change_password : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Thay đổi mật khẩu - " + PageTitle.GetPageTitle();
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {

        }
    }
}