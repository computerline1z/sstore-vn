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
    public partial class onl_statistics : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //online
            lblNow.Text = OnlineNow.Online;
            //lblTotal.Text = OnlineNow.TotalOnline;
        }
    }
}