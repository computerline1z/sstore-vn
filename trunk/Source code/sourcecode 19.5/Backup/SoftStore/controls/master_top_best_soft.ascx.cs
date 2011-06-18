using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using DataAccessLayer;
using BusinessObjects;
using SoftStore.App_Code;
using Utilities;

namespace SoftStore.controls
{
    public partial class master_top_best_soft : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Products pr=new Products();
                List<ProductsInfo> list = pr.GetListProductsPublished("IsHot", true, 15);
                if (list != null && list.Count != 0)
                {
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < list.Count; i++)
                    {
                        builder.Append("<li><a title=\"" + list[i].ProductName + "\" href=\"/chi-tiet-sp/" + list[i].ProductID + "/" +
                                               FriendlyURL.ConvertUrlFriendlyNoExt(list[i].ProductName) + ".html\">");
                        builder.Append("        <img src=\"/resources/products/" + list[i].ProductID + "/" + list[i].Picture + "\" width=\"60px\" />");
                        builder.Append("        <div>" + Util.SplitString(list[i].ProductName, 25) + "</div>");
                        builder.Append("</a></li>\n");
                    }
                    ltBuild.Text = builder.ToString();
                }
            }
        }
    }
}