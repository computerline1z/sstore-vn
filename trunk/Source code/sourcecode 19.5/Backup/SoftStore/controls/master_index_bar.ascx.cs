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
                if(url.IndexOf("lien-he")>0)
                {
                    builder.Append("<a href=\"/trang-chu.html\">Trang chủ</a> ");
                    builder.Append("<a href=\"/lien-he.html\" class=\"active\">Liên hệ</a>");
                }
                else if(url.IndexOf("tin-tuc")>0)
                {
                    builder.Append("<a href=\"/trang-chu.html\">Trang chủ</a> ");
                    builder.Append("<a href=\"/tin-tuc.html\" class=\"active\">Tin tức</a>");
                }
                else if (url.IndexOf("dang-ky") > 0)
                {
                    builder.Append("<a href=\"/trang-chu.html\">Trang chủ</a> ");
                    builder.Append("<a href=\"/dang-ky.html\" class=\"active\">Đăng ký thành viên</a>");
                }
                else if (url.IndexOf("gio-hang") > 0)
                {
                    builder.Append("<a href=\"/trang-chu.html\">Trang chủ</a> ");
                    builder.Append("<a href=\"/gio-hang.html\" class=\"active\">Giỏ hàng của bạn</a>");
                }
                else if (url.IndexOf("tag") > 0)
                {
                    builder.Append("<a href=\"/trang-chu.html\">Trang chủ</a> ");
                    builder.Append("<a href=\"#\" class=\"active\">Kết quả tìm kiếm</a>");
                }
                else if (url.IndexOf("phan-mem") > 0)
                {
                    ProductSupplier pgroup = new ProductSupplier();
                    ProductCategory pcat = new ProductCategory();

                    builder.Append("<a href=\"/trang-chu.html\">Trang chủ</a> ");


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
                else
                {
                    builder.Append("<a href=\"/trang-chu.html\">Trang chủ</a>");
                }

                ltSiteMap.Text = builder.ToString();
            }
        }
    }
}