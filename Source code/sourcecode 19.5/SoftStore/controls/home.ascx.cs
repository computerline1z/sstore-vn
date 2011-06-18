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
    public partial class home : System.Web.UI.UserControl
    {
        Products pr = new Products();
        ProductCategory cat=new ProductCategory();
        private int recPerPage = 4;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string act = Request["act"];
                if (act != null && act.Equals("logout"))
                {
                    Session.Remove("MEMBERLOGIN");
                    Response.Redirect("trang-chu.html");
                }
                LoadKM();
                LoadBestSaleProducts();
                LoadByCategory();
                LoadHot();
            }
        }
        private void LoadHot()
        {
            List<ProductsInfo> list = pr.GetListProductsPublished("IsHot", true, 4);
            if (list != null && list.Count != 0)
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("<table class=\"grid\" cellpadding=\"0\" cellspacing=\"0\">\n");
                builder.Append("<tr>\n");
                for (int i = 0; i < list.Count; i++)
                {

                    builder.Append("<td id=\"item\">\n");
                    builder.Append("        <div class=\"title\">\n");
                    //Add full path with category to products
                    builder.Append("            <a href=\"");
                    builder.Append(BuildCategoryString(list[i]));
                    builder.Append("/san-pham/" + list[i].ProductID + "/" +
                                   FriendlyURL.ConvertUrlFriendlyNoExt(list[i].ProductName) + ".html\" title='" + list[i].ProductName + "'>" + Util.SplitString(list[i].ProductName, 25) + "</a>");
                    builder.Append("        </div>\n");
                    builder.Append("        <div class=\"img\">\n");
                    //Add full path with category to products
                    builder.Append("            <a href=\"");
                    builder.Append(BuildCategoryString(list[i]));
                    builder.Append("/san-pham/" + list[i].ProductID + "/" +
                                   FriendlyURL.ConvertUrlFriendlyNoExt(list[i].ProductName) + ".html\" title='" + list[i].ProductName + "'><img src=\"/resources/products/" + list[i].ProductID +
                                   "/" + list[i].Picture + "\" width=\"80px\" /></a></div>\n");
                    builder.Append("        <div class=\"bold\">\n");
                    builder.Append("            Giá &nbsp;&nbsp;&nbsp;: <span class=\"low-price\">" +
                                   list[i].Price.ToString("#,##0") + " VNĐ</span>\n");
                    builder.Append("        </div>\n");

                    //Add rating instead of Promotion rate
                    //builder.Append("<div class=\"bold\"><img src=\"/images/star.jpg\" class=\"small-icon\"/><img src=\"/images/star.jpg\" class=\"small-icon\" /><img src=\"/images/star.jpg\" class=\"small-icon\" /></div>");
                    //builder.Append("<ajaxToolkit:Rating ID=\"Rating1\" CurrentRating=\"2\" MaxRating=\"5\" CssClass=\"ratingStar\"");
                    //builder.Append("StarCssClass=\"ratingItem\" WaitingStarCssClass=\"Saved\" FilledStarCssClass=\"Filled\" EmptyStarCssClass=\"Empty\"");
                    //builder.Append("runat=\"server\"> </ajaxToolkit:Rating>");
                    //if (list[i].PromotionRate != 0)
                    //{
                    //    builder.Append("        <div class=\"bold\">\n");
                    //    builder.Append("            Tặng : <span class=\"low-price\">" +
                    //                   (list[i].Price*list[i].PromotionRate/100).ToString("#,##0") +
                    //                   " VNĐ</span>");
                    //    builder.Append("        </div>\n");
                    //}
                    //else builder.Append("        <div class=\"bold\">&nbsp;</div>");
                    builder.Append("</td>\n");
                    if (i != 3)
                        builder.Append("<td id=\"v-line\"/>\n");

                }
                builder.Append("</tr>\n");
                builder.Append("</table>\n");
                //ltKM.Text = builder.ToString();
            }
        }
        private void LoadKM()
        {
            List<ProductsInfo> list = pr.GetListProductsPublished("IsNew", true, 4);
            if (list != null && list.Count != 0)
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("<table class=\"grid\" cellpadding=\"0\" cellspacing=\"0\">\n");
                builder.Append("<tr>\n");
                for (int i = 0; i < list.Count; i++)
                {
                   
                    builder.Append("<td id=\"item\">\n");
                    builder.Append("        <div class=\"title\">\n");
                    //Add full path with category to products
                    builder.Append("            <a href=\"");
                    builder.Append(BuildCategoryString(list[i]));
                    builder.Append("/san-pham/" + list[i].ProductID + "/" +
                                   FriendlyURL.ConvertUrlFriendlyNoExt(list[i].ProductName) + ".html\" title='" + list[i].ProductName + "'>" + Util.SplitString(list[i].ProductName, 25) + "</a>");
                    builder.Append("        </div>\n");
                    builder.Append("        <div class=\"img\">\n");
                    //Add full path with category to products
                    builder.Append("            <a href=\"");
                    builder.Append(BuildCategoryString(list[i]));
                    builder.Append("/san-pham/" + list[i].ProductID + "/" +
                                   FriendlyURL.ConvertUrlFriendlyNoExt(list[i].ProductName) + ".html\" title='" + list[i].ProductName + "'><img src=\"/resources/products/" + list[i].ProductID +
                                   "/" + list[i].Picture + "\" width=\"80px\" /></a></div>\n");
                    builder.Append("        <div class=\"bold\">\n");
                    builder.Append("            Giá &nbsp;&nbsp;&nbsp;: <span class=\"low-price\">" +
                                   list[i].Price.ToString("#,##0") + " VNĐ</span>\n");
                    builder.Append("        </div>\n");

                    //Add rating instead of Promotion rate
                    //builder.Append("<div class=\"bold\"><img src=\"/images/star.jpg\" class=\"small-icon\"/><img src=\"/images/star.jpg\" class=\"small-icon\" /><img src=\"/images/star.jpg\" class=\"small-icon\" /></div>");
                    //builder.Append("<ajaxToolkit:Rating ID=\"Rating1\" CurrentRating=\"2\" MaxRating=\"5\" CssClass=\"ratingStar\"");
                    //builder.Append("StarCssClass=\"ratingItem\" WaitingStarCssClass=\"Saved\" FilledStarCssClass=\"Filled\" EmptyStarCssClass=\"Empty\"");
                    //builder.Append("runat=\"server\"> </ajaxToolkit:Rating>");
                    //if (list[i].PromotionRate != 0)
                    //{
                    //    builder.Append("        <div class=\"bold\">\n");
                    //    builder.Append("            Tặng : <span class=\"low-price\">" +
                    //                   (list[i].Price*list[i].PromotionRate/100).ToString("#,##0") +
                    //                   " VNĐ</span>");
                    //    builder.Append("        </div>\n");
                    //}
                    //else builder.Append("        <div class=\"bold\">&nbsp;</div>");
                    builder.Append("</td>\n");
                    if (i != 3)
                        builder.Append("<td id=\"v-line\"/>\n");

                }
                builder.Append("</tr>\n");
                builder.Append("</table>\n");
                //ltKM.Text = builder.ToString();
            }
        }
        private String BuildCategoryString(ProductsInfo pi)
        {
            ProductCategory pc = new ProductCategory();
            return pc.GetCategoryPathWithUrlFriendly(pi.CategoryID);  
        }
        private void LoadBestSaleProducts()
        {
            List<ProductsInfo> list = pr.GetListProductsPublished("IsBestSale", true, 16);
            if (list != null && list.Count != 0)
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("<table id=\"tblListBestSale\" class=\"grid\" cellpadding=\"0\" cellspacing=\"0\">\n");
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
                            //Add full path with category to products
                            builder.Append("            <a href=\"");
                            builder.Append(BuildCategoryString(list[i]));
                            builder.Append("/san-pham/" + list[index].ProductID + "/" +
                                           FriendlyURL.ConvertUrlFriendlyNoExt(list[index].ProductName) + ".html\" title='" + list[index].ProductName + "'>" + Util.SplitString(list[index].ProductName, 25) + "</a>");
                            builder.Append("        </div>\n");
                            builder.Append("        <div class=\"img\">\n");
                            //Add full path with category to products
                            builder.Append("            <a href=\"");
                            builder.Append(BuildCategoryString(list[i]));
                            builder.Append("/san-pham/" + list[index].ProductID + "/" +
                                           FriendlyURL.ConvertUrlFriendlyNoExt(list[index].ProductName) + ".html\" title='" + list[index].ProductName + "'><img src=\"/resources/products/" + list[index].ProductID +
                                           "/" + list[index].Picture + "\" width=\"80px\" /></a></div>\n");
                            builder.Append("        <div class=\"bold\">\n");
                            builder.Append("            Giá &nbsp;&nbsp;&nbsp;: <span class=\"low-price\">" +
                                           list[index].Price.ToString("#,##0") + " VNĐ</span>\n");
                            builder.Append("        </div>\n");
                            builder.Append("</td>\n");
                            if (i != 3)
                                builder.Append("<td id=\"v-line\"/>\n");

                            index++;
                        }
                        builder.Append("</tr>\n");
                    }

                    //more row
                    int more_count = count%4;
                    int more_index = 0;
                    if (more_count != 0)
                    {
                        builder.Append("<tr class=\"h-line\">\n");
                        for (int i = 0; i < more_count; i++)
                        {
                            builder.Append("<td id=\"item\">");
                            builder.Append("        <div class=\"title\">");
                            //Add full path with category to products
                            builder.Append("            <a href=\"");
                            builder.Append(BuildCategoryString(list[i]));
                            builder.Append("/san-pham/" + list[index].ProductID + "/" +
                                               FriendlyURL.ConvertUrlFriendlyNoExt(list[index].ProductName) + ".html\" title='" + list[index].ProductName + "'>" + Util.SplitString(list[index].ProductName, 25) + "</a>");
                            builder.Append("        </div>");
                            builder.Append("        <div class=\"img\">");
                            //Add full path with category to products
                            builder.Append("            <a href=\"");
                            builder.Append(BuildCategoryString(list[i]));
                            builder.Append("/san-pham/" + list[index].ProductID + "/" +
                                               FriendlyURL.ConvertUrlFriendlyNoExt(list[index].ProductName) + ".html\" title='" + list[index].ProductName + "'><img src=\"/resources/products/" + list[index].ProductID + "/" + list[index].Picture + "\" width=\"80px\" /></a></div>");
                            builder.Append("        <div class=\"bold\">");
                            builder.Append("            Giá &nbsp;&nbsp;&nbsp;: <span class=\"low-price\">" + list[index].Price.ToString("#,##0") + " VNĐ</span>");
                            builder.Append("        </div>");

                            builder.Append("</td>");
                            if (i != 3)
                                builder.Append("<td id=\"v-line\" />");

                            index++;
                            more_index++;
                        }
                        if (more_index!=3)
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
                        //Add full path with category to products
                        builder.Append("            <a href=\"");
                        builder.Append(BuildCategoryString(list[i]));
                        builder.Append("/san-pham/" + list[i].ProductID + "/" +
                                           FriendlyURL.ConvertUrlFriendlyNoExt(list[i].ProductName) + ".html\" title='" + list[i].ProductName + "'>" + Util.SplitString(list[i].ProductName, 25) + "</a>");
                        builder.Append("        </div>");
                        builder.Append("        <div class=\"img\">");
                        //Add full path with category to products
                        builder.Append("            <a href=\"");
                        builder.Append(BuildCategoryString(list[i]));
                        builder.Append("/san-pham/" + list[i].ProductID + "/" +
                                           FriendlyURL.ConvertUrlFriendlyNoExt(list[i].ProductName) + ".html\" title='" + list[i].ProductName + "'><img src=\"/resources/products/" + list[i].ProductID + "/" + list[i].Picture + "\" width=\"80px\" /></a></div>");
                        builder.Append("        <div class=\"bold\">");
                        builder.Append("            Giá &nbsp;&nbsp;&nbsp;: <span class=\"low-price\">" + list[i].Price.ToString("#,##0") + " VNĐ</span>");
                        builder.Append("        </div>");
                        builder.Append("</td>");
                        if (i != count - 1)
                            builder.Append("<td id=\"v-line\" />");
                    }
                    builder.Append("</tr>\n");
                }
                builder.Append("</table>\n");

                //render paging
                //builder.Append("<div style='width:100%; margin:10px'>\n");
                //builder.Append("<div id=\"pagerListBestSale\" class=\"paginator2\"></div>\n");
                //builder.Append("<script type=\"text/javascript\">\n");
                //builder.Append("var pager = new Pager('tblListBestSale', 3); \n");
                //builder.Append("pager.init(); \n");
                //builder.Append("pager.showPageNav('pager', 'pagerListBestSale');\n ");
                //builder.Append("pager.showPage(1);\n");
                //builder.Append("</script>\n");
                //builder.Append("</div>\n");
                //ltBestSaleProducts.Text = builder.ToString();

            }
        }
        private void LoadByCategory()
        {
            List<ProductCategoryInfo> list_cat = cat.GetList(0);
            if (list_cat != null && list_cat.Count != 0)
            {
                StringBuilder tab=new StringBuilder();
                StringBuilder builder = new StringBuilder();
                for (int x = 0; x < list_cat.Count; x++)
                {
                    tab.Append("<li><a href=\"#tab_" + x + "\">Top " + list_cat[x].CategoryName + "</a></li>");
                    builder.Append("<div id=\"tab_" + x + "\" class=\"tab_content\">");
                    #region Build Tab Content

                    List<ProductsInfo> list = pr.GetListProductsPublished(list_cat[x].CategoryID, 16);
                    if (list != null && list.Count != 0)
                    {
                        builder.Append("<table id=\"tbl" + x + "\" class=\"grid\" cellpadding=\"0\" cellspacing=\"0\">\n");
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
                                    //Add full path with category to products
                                    builder.Append("            <a href=\"");
                                    builder.Append(BuildCategoryString(list[i]));
                                    builder.Append("/san-pham/" + list[index].ProductID + "/" +
                                                   FriendlyURL.ConvertUrlFriendlyNoExt(list[index].ProductName) + ".html\" title='" + list[index].ProductName + "'>" + Util.SplitString(list[index].ProductName, 25) + "</a>");
                                    builder.Append("        </div>\n");
                                    builder.Append("        <div class=\"img\">\n");
                                    //Add full path with category to products
                                    builder.Append("            <a href=\"");
                                    builder.Append(BuildCategoryString(list[i]));
                                    builder.Append("/san-pham/" + list[index].ProductID + "/" +
                                                   FriendlyURL.ConvertUrlFriendlyNoExt(list[index].ProductName) + ".html\" title='" + list[index].ProductName + "'><img src=\"/resources/products/" + list[index].ProductID +
                                                   "/" + list[index].Picture + "\" width=\"80px\" /></a></div>\n");
                                    builder.Append("        <div class=\"bold\">\n");
                                    builder.Append("            Giá &nbsp;&nbsp;&nbsp;: <span class=\"low-price\">" +
                                                   list[index].Price.ToString("#,##0") + " VNĐ</span>\n");
                                    builder.Append("        </div>\n");
                                    builder.Append("<div class=\"ratingStar\"><span class=\"ratingItem\"><span class=\"Filled\"/></span></div>");
                                    //if (list[index].PromotionRate != 0)
                                    //{
                                    //    builder.Append("        <div class=\"bold\">\n");
                                    //    builder.Append("            Tặng : <span class=\"low-price\">" +
                                    //                   (list[index].Price*list[index].PromotionRate/100).ToString(
                                    //                       "#,##0") +
                                    //                   " VNĐ</span>");
                                    //    builder.Append("        </div>\n");
                                    //}
                                    //else builder.Append("        <div class=\"bold\">&nbsp;</div>");
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
                                    //Add full path with category to products
                                    builder.Append("            <a href=\"");
                                    builder.Append(BuildCategoryString(list[i]));
                                    builder.Append("/san-pham/" + list[index].ProductID + "/" +
                                                       FriendlyURL.ConvertUrlFriendlyNoExt(list[index].ProductName) + ".html\" title='" + list[index].ProductName + "'>" + Util.SplitString(list[index].ProductName, 25) + "</a>");
                                    builder.Append("        </div>");
                                    builder.Append("        <div class=\"img\">");
                                    builder.Append("            <img src=\"/resources/products/" + list[index].ProductID + "/" + list[index].Picture + "\" width=\"80px\" /></div>");
                                    builder.Append("        <div class=\"bold\">");
                                    builder.Append("            Giá &nbsp;&nbsp;&nbsp;: <span class=\"low-price\">" + list[index].Price.ToString("#,##0") + " VNĐ</span>");
                                    builder.Append("        </div>");
                                    //builder.Append("<div class=\"bold\"><img src=\"/images/rating/ratingStarFilled.png\" class=\"small-icon\"/><img src=\"/images/rating/ratingStarFilled.png\" class=\"small-icon\" /><img src=\"/images/rating/ratingStarFilled.png\" class=\"small-icon\"/><img src=\"/images/rating/ratingStarEmpty.png\" class=\"small-icon\"/> <img src=\"/images/rating/ratingStarEmpty.png\" class=\"small-icon\"/></div>");
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
                            builder.Append("<tr>\n");
                            for (int i = 0; i < count; i++)
                            {
                                builder.Append("<td id=\"item\">");
                                builder.Append("        <div class=\"title\">");
                                //Add full path with category to products
                                builder.Append("            <a href=\"");
                                builder.Append(BuildCategoryString(list[i]));
                                builder.Append("/san-pham/" + list[i].ProductID + "/" +
                                                   FriendlyURL.ConvertUrlFriendlyNoExt(list[i].ProductName) + ".html\" title='" + list[i].ProductName + "'>" + Util.SplitString(list[i].ProductName, 25) + "</a>");
                                builder.Append("        </div>");
                                builder.Append("        <div class=\"img\">");
                                //Add full path with category to products
                                builder.Append("            <a href=\"");
                                builder.Append(BuildCategoryString(list[i]));
                                builder.Append("/san-pham/" + list[i].ProductID + "/" +
                                                   FriendlyURL.ConvertUrlFriendlyNoExt(list[i].ProductName) + ".html\" title='" + list[i].ProductName + "'><img src=\"/resources/products/" + list[i].ProductID + "/" + list[i].Picture + "\" width=\"80px\" /></a></div>");
                                builder.Append("        <div class=\"bold\">");
                                builder.Append("            Giá &nbsp;&nbsp;&nbsp;: <span class=\"low-price\">" + list[i].Price.ToString("#,##0") + " VNĐ</span>");
                                builder.Append("        </div>");

                                //builder.Append("<div class=\"bold\"><img src=\"/images/star.jpg\" class=\"small-icon\"/><img src=\"/images/star.jpg\" class=\"small-icon\" /><img src=\"/images/star.jpg\" class=\"small-icon\" /></div>");
                                //if (list[i].PromotionRate != 0)
                                //{
                                //    builder.Append("        <div class=\"bold\">");
                                //    builder.Append("            Tặng : <span class=\"low-price\">" +
                                //                   (list[i].Price*list[i].PromotionRate/100).ToString("#,##0") +
                                //                   " VNĐ</span>");
                                //    builder.Append("        </div>");
                                //}
                                //else builder.Append("        <div class=\"bold\">&nbsp;</div>");
                                builder.Append("</td>");
                                if (i != count - 1)
                                    builder.Append("<td id=\"v-line\" />");
                            }
                            builder.Append("</tr>\n");
                        }
                        builder.Append("</table>\n");

                        //render paging
                        //builder.Append("<div style='width:100%; margin:10px'>\n");
                        //builder.Append("<div id=\"pager_" + x + "\" class=\"paginator2\"></div>\n");
                        //builder.Append("<script type=\"text/javascript\">\n");
                        //builder.Append("var pager = new Pager('tbl" + x + "', 3); \n");
                        //builder.Append("pager.init(); \n");
                        //builder.Append("pager.showPageNav('pager', 'pager_" + x + "'); \n");
                        //builder.Append("pager.showPage(1);\n");
                        //builder.Append("</script>\n");
                        //builder.Append("</div>\n");
                    }
                    #endregion
                    builder.Append("</div>");
                }

                ltTab.Text = tab.ToString();
                ltTabContent.Text = builder.ToString();

            }
        }
        private void RenderPaging(int totalRec)
        {
            StringBuilder paging = new StringBuilder();
            if (totalRec < recPerPage)
                return;
            int totalPage = totalRec / recPerPage;
            if (totalRec % recPerPage > 0)
                totalPage = totalPage + 1;

            string page = Request["page"];
            if (page == null)//page 1(default)
            {
                for (int i = 1; i <= totalPage; i++)
                {
                    if (i == 1)
                        paging.Append("<a class=\"selected\" href=\"/" + i + "/trang-chu.html\">" + i + "</a>");
                    else paging.Append("<a href=\"/" + i + "/trang-chu.html\">" + i + "</a>");
                }
                paging.Append("<a title=\"Next Page\" href=\"/2/trang-chu.html\">›</a>");
                paging.Append("<a title=\"Last Page\" href=\"/" + totalPage + "/trang-chu.html\">››</a>");
            }
            else
            {
                int currentPage = int.Parse(page);
                if (currentPage != 1)//ko phai trang dau
                {
                    paging.Append("<a title=\"First Page\" href=\"/1/trang-chu.html\">‹‹</a>");
                    paging.Append("<a title=\"Prev Page\" href=\"/" + (currentPage-1) + "/trang-chu.html\">‹</a>");
                }
                for (int i = 1; i <= totalPage; i++)
                {
                    if (i == currentPage)
                        paging.Append("<a class=\"selected\" href=\"/" + i + "/trang-chu.html\">" + i + "</a>");
                    else paging.Append("<a href=\"/" + i + "/trang-chu.html\">" + i + "</a>");
                }

                if (currentPage != totalPage)//ko phai trang cuoi
                {
                    paging.Append("<a title=\"Next Page\" href=\"/" + (currentPage + 1) + "/trang-chu.html\">›</a>");
                    paging.Append("<a title=\"Last Page\" href=\"/" + totalPage + "/trang-chu.html\">››</a>");
                }
            }

            //ltPaging.Text = paging.ToString();
        }
    }
}