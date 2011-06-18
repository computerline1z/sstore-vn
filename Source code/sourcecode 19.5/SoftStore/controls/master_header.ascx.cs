using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BusinessObjects;
using DataAccessLayer;
using SoftStore.App_Code;
using Utilities;
using System.Collections.Specialized;

namespace SoftStore.controls
{
    public partial class master_header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //render menu
                renderMenu();

                //check login
                MembersInfo info = MemberLogin.GetMemberLogin();
                if(info!=null)
                {
                    ltLoginPanel.Text = "<a href=\"/thong-tin-ca-nhan.html\"><b>[" + info.FullName + "]</b></a><a onclick=\"return confirm('Bạn muốn thoát khỏi hệ thống?');\" href=\"/trang-chu.html?act=logout\"><b>[Thoát]</b></a>";
                }
                else
                {
                    //ltLoginPanel.Text = "<a onclick='showDiv()' onblur='hide()' href=\"#\"><b>[HIHIEHEHE]</b></a><a onclick=\"return confirm('Bạn muốn thoát khỏi hệ thống?');\" href=\"/trang-chu.html?act=logout\"><b>[Thoát]</b></a>";
                    ltLoginPanel.Text = "<li class=\"text\"><a href=\"/dang-ky.html\">Đăng ký</a></li><li class=\"text\"> <a href=\"/dang-nhap.html\">Đăng nhập</a></li>";
                }

                //check shopping cart
                /*object yourcart = Session["YOURCART"];
                if (yourcart != null)
                {
                    List<CartInfo> list = (List<CartInfo>)yourcart;
                    ltCart.Text = "Giỏ hàng&nbsp;(" + list.Count + ")";
                }
                else
                {
                    ltCart.Text = "Giỏ hàng&nbsp;(0)";
                }*/

                string tag = Request["tag"];
                if (tag != null)
                {
                    tag = tag.Replace("+", " ");
                    txtKey.Text = tag;
                }
            }
        }
        ProductCategory cat=new ProductCategory();
        private void renderMenu()
        {
            List<ProductCategoryInfo> list = cat.GetList(0);
            if (list != null && list.Count != 0)
            {
                string url = Request.RawUrl;
                StringBuilder builder = new StringBuilder();
                if (url.IndexOf("trang-chu") > 0 || url.ToLower().IndexOf("/default.aspx") == 0)
                    builder.Append("<li id=\"active\"><a href=\"/trang-chu.html\" title=\"Trang chủ sstore\">Trang chủ</a></li>");
                else builder.Append("<li><a href=\"/trang-chu.html\" title=\"Trang chủ sstore\">Trang chủ</a></li>");
                string selectedCategory = null;
                string[] urlArray = url.Split('/');
                if(urlArray.Length>0){
                    selectedCategory = urlArray[1];
                }
                #region category
                for (int i = 0; i < list.Count; i++)
                {
                    if(selectedCategory !=null && FriendlyURL.ConvertUrlFriendlyNoExt(list[i].CategoryName) == selectedCategory)
                        builder.Append("<li id=\"active\">\n");
                    else
                        builder.Append("<li>\n");
                    //Khanh added
                    ProductCategory pc = new ProductCategory();
                    String categoryPath = pc.GetCategoryPathWithUrlFriendly(list[i].CategoryID);
                    builder.Append("<a href=\"" /*+ categoryPath + "/" + list[i].CategoryID*/ + "/" +  FriendlyURL.ConvertUrlFriendlyNoExt(list[i].CategoryName) + ".html\" title=\"" + list[i].CategoryName + "\">" + list[i].CategoryName + "\n");
                    /*builder.Append("<ul class=\"drop-down-menu\" style=\"visibility: hidden;\">\n");
                    List<ProductCategoryInfo> sub_list = cat.GetList(list[i].CategoryID);
                    if (sub_list != null && sub_list.Count != 0)
                    {
                        for (int j = 0; j < sub_list.Count; j++)
                        {
                            categoryPath = pc.GetCategoryPathWithUrlFriendly(sub_list[j].CategoryID);
                            builder.Append("        <li><a href=\"");
                            builder.Append(categoryPath);
                            builder.Append("/" + sub_list[j].CategoryID + "/" +
                                               FriendlyURL.ConvertUrlFriendlyNoExt(sub_list[j].CategoryName) + ".html\">" +
                                               sub_list[j].CategoryName + "</a></li>\n");
                        }
                    }
                    builder.Append("    </ul>\n");*/
                    builder.Append(" </a></li>\n");
                }
                #endregion
                
                if (url.IndexOf("khuyen-mai") > 0)
                    builder.Append("<li id=\"active\"><a href=\"/khuyen-mai.html\" title=\"Khuyến mãi\">Khuyến mãi</a></li>");
                else builder.Append("<li><a href=\"/khuyen-mai.html\" title=\"Khuyến mãi\">Khuyến mãi</a></li>");
                /*if (url.IndexOf("goi-doanh-nghiep") > 0)
                    builder.Append("<li class=\"menu-c-active\"><a class=\"main-nav\" href=\"/goi-doanh-nghiep.html\" title=\"Gói doanh nghiệp\">Gói doanh nghiệp</a></li>");
                else builder.Append("<li class=\"menu-c\"><a class=\"main-nav\" href=\"/goi-doanh-nghiep.html\" title=\"Gói doanh nghiệp\">Gói doanh nghiệp</a></li>");
                if (url.IndexOf("yeu-cau-phan-mem") > 0)
                    builder.Append("<li class=\"menu-r-active\"><a class=\"main-nav\" href=\"/yeu-cau-phan-mem.html\" title=\"Yêu cầu PM\">Yêu cầu PM</a></li>");
                else builder.Append("<li class=\"menu-r\"><a class=\"main-nav\" href=\"/yeu-cau-phan-mem.html\" title=\"Yêu cầu PM\">Yêu cầu PM</a></li>");*/
                //if (url.IndexOf("lien-he") > 0)
                //    builder.Append("<li class=\"menu-r-active\"><a class=\"main-nav\" href=\"/lien-he.html\" title=\"Liên hệ\">Liên hệ</a></li>");
                //else builder.Append("<li class=\"menu-r\"><a class=\"main-nav\" href=\"/lien-he.html\" title=\"Liên hệ\">Liên hệ</a></li>");
                ltMenu.Text = builder.ToString();
            }

        }
    }
}