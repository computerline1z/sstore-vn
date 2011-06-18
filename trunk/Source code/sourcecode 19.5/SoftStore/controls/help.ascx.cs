using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using BusinessObjects;
using SoftStore.App_Code;
using Utilities;
namespace SoftStore.controls
{
    public partial class help : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Help h=new Help();
                IList<HelpInfo> list = h.GetListHelp();
                if (list != null && list.Count != 0)
                {
                    ltTitle.Text = list[0].Title;
                    ltContent.Text = list[0].Content;
                }
            }
        }
    }
}