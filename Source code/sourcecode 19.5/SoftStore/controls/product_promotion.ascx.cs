using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BusinessObjects;
using DataAccessLayer;
using Utilities;

namespace SoftStore.controls
{
    public partial class product_promotion : System.Web.UI.UserControl
    {
        Products pr = new Products();
        ProductCategory cat = new ProductCategory();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadKMProducts();
            }
        }
        private void LoadKMProducts()
        {
            List<ProductsInfo> list = pr.GetListProductsPublished("IsNew", true, -1);
            if (list != null && list.Count != 0)
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("<table id=\"tblListKM\" class=\"grid\" cellpadding=\"0\" cellspacing=\"0\">\n");
                builder.Append("<tr><td colspan=\"7\"></td></tr>\n");
                int count = list.Count;
                if (count >= 4)
                {
                    int row = count / 4;
                    int index = 0;
                    for (int r = 0; r < row; r++)
                    {
                        builder.Append("<tr class=\"h-line\">\n");
                        for (int i = 0; i < 4; i++)
                        {
                            builder.Append("<td id=\"item\">\n");
                            builder.Append("        <div class=\"title\">\n");
                            builder.Append("            <a href=\"/chi-tiet-sp/" + list[index].ProductID + "/" +
                                           FriendlyURL.ConvertUrlFriendlyNoExt(list[index].ProductName) + ".html\" title='" + list[index].ProductName + "'>" + Util.SplitString(list[index].ProductName, 25) + "</a>");
                            builder.Append("        </div>\n");
                            builder.Append("        <div class=\"img\">\n");
                            builder.Append("            <img src=\"/resources/products/" + list[index].ProductID +
                                           "/" + list[index].Picture + "\" width=\"80px\" /></div>\n");
                            builder.Append("        <div class=\"bold\">\n");
                            builder.Append("            Giá &nbsp;&nbsp;&nbsp;: <span class=\"low-price\">" +
                                           list[index].Price.ToString("#,##0") + " VNĐ</span>\n");
                            builder.Append("        </div>\n");
                            builder.Append("        <div class=\"bold\">\n");
                            builder.Append("            Tặng : <span class=\"low-price\">" +
                                           (list[index].Price * list[index].PromotionRate / 100).ToString("#,##0") +
                                           " VNĐ</span>");
                            builder.Append("        </div>\n");
                            builder.Append("</td>\n");
                            if (i != 3)
                                builder.Append("<td id=\"v-line\"/>\n");

                            index++;
                        }
                        builder.Append("</tr>\n");
                        //if (r != row - 1 || count % 4 != 0)
                        //    builder.Append("<tr><td colspan=\"7\" id=\"h-line\" /></tr>\n");
                    }

                    //more row
                    int more_count = count % 4;
                    int more_index = 0;
                    if (more_count != 0)
                    {
                        builder.Append("<tr class=\"h-line\">\n");
                        for (int i = 0; i < more_count; i++)
                        {
                            builder.Append("<td id=\"item\">");
                            builder.Append("        <div class=\"title\">");
                            builder.Append("            <a href=\"/chi-tiet-sp/" + list[index].ProductID + "/" +
                                               FriendlyURL.ConvertUrlFriendlyNoExt(list[index].ProductName) + ".html\" title='" + list[index].ProductName + "'>" + Util.SplitString(list[index].ProductName, 25) + "</a>");
                            builder.Append("        </div>");
                            builder.Append("        <div class=\"img\">");
                            builder.Append("            <img src=\"/resources/products/" + list[index].ProductID + "/" + list[index].Picture + "\" width=\"80px\" /></div>");
                            builder.Append("        <div class=\"bold\">");
                            builder.Append("            Giá &nbsp;&nbsp;&nbsp;: <span class=\"low-price\">" + list[index].Price.ToString("#,##0") + " VNĐ</span>");
                            builder.Append("        </div>");
                            builder.Append("        <div class=\"bold\">");
                            builder.Append("            Tặng : <span class=\"low-price\">" + (list[index].Price * list[index].PromotionRate / 100).ToString("#,##0") + " VNĐ</span>");
                            builder.Append("        </div>");
                            builder.Append("</td>");
                            if (i != 3)
                                builder.Append("<td id=\"v-line\" />");

                            index++;
                            more_index++;
                        }
                        if (more_index != 3)
                        {
                            builder.Append("<td id=\"item\" colspan=\"" + (((4 - more_count) * 2) - 1) + "\">");
                            builder.Append("</td>");
                        }
                        builder.Append("</tr>\n");
                    }

                }
                else
                {
                    builder.Append("<tr class=\"h-line\">\n");
                    for (int i = 0; i < count; i++)
                    {
                        builder.Append("<td id=\"item\">");
                        builder.Append("        <div class=\"title\">");
                        builder.Append("            <a href=\"/chi-tiet-sp/" + list[i].ProductID + "/" +
                                           FriendlyURL.ConvertUrlFriendlyNoExt(list[i].ProductName) + ".html\" title='" + list[i].ProductName + "'>" + Util.SplitString(list[i].ProductName, 25) + "</a>");
                        builder.Append("        </div>");
                        builder.Append("        <div class=\"img\">");
                        builder.Append("            <img src=\"/resources/products/" + list[i].ProductID + "/" + list[i].Picture + "\" width=\"80px\" /></div>");
                        builder.Append("        <div class=\"bold\">");
                        builder.Append("            Giá &nbsp;&nbsp;&nbsp;: <span class=\"low-price\">" + list[i].Price.ToString("#,##0") + " VNĐ</span>");
                        builder.Append("        </div>");
                        builder.Append("        <div class=\"bold\">");
                        builder.Append("            Tặng : <span class=\"low-price\">" + (list[i].Price * list[i].PromotionRate / 100).ToString("#,##0") + " VNĐ</span>");
                        builder.Append("        </div>");
                        builder.Append("</td>");
                        if (i != count - 1)
                            builder.Append("<td id=\"v-line\" />");
                    }
                    builder.Append("</tr>\n");
                }
                builder.Append("</table>\n");
                ltKM.Text = builder.ToString();
            }
        }
    }
}