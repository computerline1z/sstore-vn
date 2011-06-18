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
    public partial class master_index_bar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                StringBuilder builder=new StringBuilder();
                string url = Request.RawUrl;
                string[] urlArray = url.Split('/');
                builder.Append("<a href=\"/trang-chu.html\">Trang chủ</a> ");
                if(url.IndexOf("lien-he")>0)
                {
                    builder.Append("<a href=\"/lien-he.html\" class=\"active\">Liên hệ</a>");
                }
                else if(url.IndexOf("tin-tuc")>0)
                {
                    builder.Append("<a href=\"/tin-tuc.html\" class=\"active\">Tin tức</a>");
                }
                else if (url.IndexOf("dang-ky") > 0)
                {
                    builder.Append("<a href=\"/dang-ky.html\" class=\"active\">Đăng ký thành viên</a>");
                }
                else if (url.IndexOf("gio-hang") > 0)
                {
                    builder.Append("<a href=\"/gio-hang.html\" class=\"active\">Giỏ hàng của bạn</a>");
                }
                else if (url.IndexOf("tag") > 0)
                {
                   builder.Append("<a href=\"#\" class=\"active\">Kết quả tìm kiếm</a>");
                }
                else if (urlArray.Length > 2 && !url.Contains("trang-chu"))
                {
                    try
                    {
                        ProductCategory pc = new ProductCategory();
                        String productID = Request["id"];
                        int categoryID = (productID == null || productID == "") ? int.Parse(urlArray[urlArray.Length - 2]):
                            pc.GetCategoryByProductId(urlArray[urlArray.Length - 2]);
                        List<ProductCategoryInfo> pcList = pc.GetAllList(categoryID);
                        if (pcList != null)
                        {
                            for (int i = pcList.Count - 1; i > 0; i--)
                            {
                                builder.Append("<a class=\"normal\" href=\"" + pc.GetCategoryPathWithUrlFriendly(pcList[i].CategoryID) + "/" + pcList[i].CategoryID +"/" +
                                    FriendlyURL.ConvertUrlFriendlyNoExt(pcList[i].CategoryName) +".html\">" +
                                    pcList[i].CategoryName + "</a>");
                            }
                            if (productID != null && productID != "")
                            {
                                builder.Append("<a class=\"normal\" href=\"" + pc.GetCategoryPathWithUrlFriendly(pcList[0].CategoryID) + "/" + pcList[0].CategoryID + "/" +
                                    FriendlyURL.ConvertUrlFriendlyNoExt(pcList[0].CategoryName) + ".html\">" +
                                    pcList[0].CategoryName + "</a>");
                                Products p = new Products();
                                ProductsInfo pi = p.GetByID(productID);
                                builder.Append("<span class=\"active\">" + pi.ProductName + "</span>");
                            }
                            else
                            {
                                builder.Append("<span class=\"active\">" + pcList[0].CategoryName + "</span>");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Log.error("Error when parse category: " + ex.Message);
                    }
                    //ProductSupplier pgroup = new ProductSupplier();
                    //ProductCategory pcat = new ProductCategory();

                    //builder.Append("<a href=\"/trang-chu.html\">Trang chủ</a> ");


                    //string catid = Request["catid"];
                    //if (catid != null)
                    //{
                    //    string groupid = Request["groupid"];
                    //    if (groupid != null)
                    //    {
                    //        ProductSupplierInfo groupinfo = pgroup.GetByID(groupid);
                    //        if (groupinfo != null)
                    //            builder.Append("<a href=\"/phan-mem/" + groupinfo.GroupID + "/" + FriendlyURL.ConvertUrlFriendlyNoExt(groupinfo.GroupName) + ".html\" class=\"arrow\">" + groupinfo.GroupName + "</a>");
                    //    }

                    //    //ProductCategoryInfo info = pcat.GetByID(int.Parse(catid));
                    //    //if (info != null)
                    //    //    builder.Append("<a href=\"/phan-mem/" + info.GroupID + "/" + info.CategoryID + "/" + FriendlyURL.ConvertUrlFriendlyNoExt(info.CategoryName) + ".html\" class=\"active\">" + info.CategoryName + "</a>");
                    //}
                    //else
                    //{
                    //    string groupid = Request["groupid"];
                    //    if (groupid != null)
                    //    {
                    //        ProductSupplierInfo groupinfo = pgroup.GetByID(groupid);
                    //        if (groupinfo != null)
                    //            builder.Append("<a href=\"/phan-mem/" + groupinfo.GroupID + "/" + FriendlyURL.ConvertUrlFriendlyNoExt(groupinfo.GroupName) + ".html\" class=\"arrow\">" + groupinfo.GroupName + "</a>");
                    //    }
                    //}
                }
                //else if(urlArray.Length> 0 && urlArray[1] == "san-pham")
                //{

                //    try
                //    {
                //        string productId = urlArray[2];
                //        Products p = new Products();
                //        ProductsInfo pi = p.GetByID(productId);
                //        ProductCategory pc = new ProductCategory();
                //        List<ProductCategoryInfo> pcList = pc.GetAllList(pi.CategoryID);
                //        for (int i = pcList.Count - 1; i >= 0; i--)
                //        {
                //            builder.Append("<a class=\"normal\" href=\"/" + FriendlyURL.ConvertUrlFriendlyNoExt(pcList[i].CategoryName) + ".html\">" +
                //                pcList[i].CategoryName + "</a>");
                //        }
                //        builder.Append("<span class=\"active\">" + urlArray[urlArray.Length - 1] + "</span>");
                //    }
                //    catch (Exception ex)
                //    {
                //        Logger.Log.error("Error when parse category: " + ex.Message);
                //    }
                //}
                /*else
                {
                    builder.Append("<a href=\"/trang-chu.html\">Trang chủ</a>");
                }*/

                ltSiteMap.Text = builder.ToString();
                //check shopping cart
                object yourcart = Session["YOURCART"];
                if (yourcart != null)
                {
                    List<CartInfo> list = (List<CartInfo>)yourcart;
                    ltCart.Text = "Giỏ hàng&nbsp;(" + list.Count + ")";
                }
                else
                {
                    ltCart.Text = "Giỏ hàng&nbsp;(0)";
                }
            }
        }
    }
}