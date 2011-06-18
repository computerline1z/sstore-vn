using System;
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
using SoftStore.App_Code;

namespace SoftStore.admin.controls
{
    public partial class menu : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                StringBuilder builder=new StringBuilder();
                UsersInfo user = UserLogin.GetUserLoging();
                if(user.GroupID==0 || user.GroupID==1)
                {
                    #region admin
                    builder.Append("<li><a href=\"default.aspx\">TRANG CHỦ</a></li>");
                    builder.Append("<li><a href=\"#\">SẢN PHẨM</a>");
                    builder.Append("    <ul>");//productsupplier
                    builder.Append("        <li><a href=\"default.aspx?n=productsupplier\">Danh mục nhà cung cấp</a></li>");
                    builder.Append("        <li><a href=\"default.aspx?n=package\">Hình thức đóng gói</a></li>");
                    builder.Append("        <li><a href=\"default.aspx?n=productcategory\">Danh mục sản phẩm</a></li>");
                    builder.Append("        <li><a href=\"default.aspx?n=products\">Danh sách sản phẩm</a></li>");
                    builder.Append("    </ul>");
                    builder.Append("</li>");
                    builder.Append("<li><a href=\"default.aspx?n=orderslist\">QUẢN LÝ ĐẶT HÀNG</a>");
                    builder.Append("    <ul>");
                    builder.Append("        <li><a href=\"default.aspx?n=orderslist\">Danh sách đơn hàng</a></li>");
                    builder.Append("        <li><a href=\"default.aspx?n=paymentmethods\">Phương thức thanh toán</a></li>");
                    builder.Append("        <li><a href=\"default.aspx?n=receivemethods\">Phương thức giao hàng</a></li>");
                    builder.Append("    </ul>");
                    builder.Append("</li>");
                    builder.Append("<li><a href=\"default.aspx?n=news\">TIN TỨC - SỰ KIỆN</a>");
                    builder.Append("    <ul>");
                    builder.Append("        <li><a href=\"default.aspx?n=newscategory\">Danh mục tin tức</a></li>");
                    builder.Append("        <li><a href=\"default.aspx?n=news\">Danh sách tin tức</a></li>");
                    builder.Append("        <li><a href=\"default.aspx?n=salespolicy\">Chính sách bán hàng</a></li>");
                    builder.Append("        <li><a href=\"default.aspx?n=help\">Giúp đỡ</a></li>");
                    builder.Append("    </ul>");
                    builder.Append("</li>");
                    //builder.Append("<li><a href=\"default.aspx?n=advs\">QUẢNG CÁO - LOGO</a>");
                    //builder.Append("    <ul>");
                    //builder.Append("        <li><a href=\"default.aspx?n=advs\">Logo quảng cáo</a></li>");
                    //builder.Append("        <li><a href=\"default.aspx?n=brands\">Logo đối tác</a></li>");
                    //builder.Append("        <li><a href=\"default.aspx?n=advproducts\">Quảng cáo theo chuyên mục</a></li>");
                    //builder.Append("    </ul>");
                    //builder.Append("</li>");
                    builder.Append("<li><a href=\"default.aspx?n=members\">THÀNH VIÊN</a></li>");
                    builder.Append("<li><a href=\"#\">THÔNG TIN CHUNG</a>");
                    builder.Append("    <ul>");
                    builder.Append("        <li><a href=\"default.aspx?n=company\">Thông tin công ty</a></li>");
                    builder.Append("        <li><a href=\"default.aspx?n=introduction\">Giới thiệu công ty</a></li>");
                    builder.Append("        <li><a href=\"default.aspx?n=contact\">Khách hàng liên hệ</a></li>");
                    builder.Append("        <li><a href=\"default.aspx?n=download\">Download bảng giá</a></li>");
                    builder.Append("        <li><a href=\"default.aspx?n=supportonline\">Hỗ trợ trực tuyến</a></li>");
                    builder.Append("    </ul>");
                    builder.Append("</li>");
                    builder.Append("<li><a href=\"#\">HỆ THỐNG</a>");
                    builder.Append("    <ul>");
                    builder.Append("        <li><a href=\"default.aspx?n=smtp\">SMTP Mail Server</a></li>");
                    builder.Append("        <li><a href=\"default.aspx?n=userlist\">Danh sách người dùng</a></li>");
                    builder.Append("    </ul>");
                    builder.Append("</li>");
                    #endregion
                }
                else if(user.GroupID==2)
                {
                    #region moderator
                    builder.Append("<li><a href=\"default.aspx\">TRANG CHỦ</a></li>");
                    builder.Append("<li><a href=\"default.aspx?n=products\">SẢN PHẨM</a></li>");
                    //builder.Append("<li><a href=\"default.aspx?n=orderslist\">QUẢN LÝ ĐẶT HÀNG</a>");
                    //builder.Append("    <ul>");
                    //builder.Append("        <li><a href=\"default.aspx?n=orderslist\">Danh sách đơn hàng</a></li>");
                    //builder.Append("        <li><a href=\"default.aspx?n=paymentmethods\">Phương thức thanh toán</a></li>");
                    //builder.Append("        <li><a href=\"default.aspx?n=receivemethods\">Phương thức giao hàng</a></li>");
                    //builder.Append("    </ul>");
                    //builder.Append("</li>");
                    builder.Append("<li><a href=\"default.aspx?n=news\">TIN TỨC - SỰ KIỆN</a>");
                    builder.Append("    <ul>");
                    //builder.Append("        <li><a href=\"default.aspx?n=newscategory\">Danh mục tin tức</a></li>");
                    builder.Append("        <li><a href=\"default.aspx?n=news\">Danh sách tin tức</a></li>");
                    builder.Append("        <li><a href=\"default.aspx?n=salespolicy\">Chính sách bán hàng</a></li>");
                    builder.Append("        <li><a href=\"default.aspx?n=help\">Giúp đỡ</a></li>");
                    builder.Append("    </ul>");
                    builder.Append("</li>");
                    //builder.Append("<li><a href=\"default.aspx?n=advs\">QUẢNG CÁO - LOGO</a>");
                    //builder.Append("    <ul>");
                    //builder.Append("        <li><a href=\"default.aspx?n=advs\">Logo quảng cáo</a></li>");
                    //builder.Append("        <li><a href=\"default.aspx?n=brands\">Logo đối tác</a></li>");
                    //builder.Append("    </ul>");
                    //builder.Append("</li>");
                    builder.Append("<li><a href=\"default.aspx?n=members\">THÀNH VIÊN</a></li>");
                    builder.Append("<li><a href=\"#\">THÔNG TIN CHUNG</a>");
                    builder.Append("    <ul>");
                    builder.Append("        <li><a href=\"default.aspx?n=company\">Thông tin công ty</a></li>");
                    builder.Append("        <li><a href=\"default.aspx?n=introduction\">Giới thiệu công ty</a></li>");
                    builder.Append("        <li><a href=\"default.aspx?n=contact\">Khách hàng liên hệ</a></li>");
                    builder.Append("        <li><a href=\"default.aspx?n=download\">Download bảng giá</a></li>");
                    builder.Append("        <li><a href=\"default.aspx?n=supportonline\">Hỗ trợ trực tuyến</a></li>");
                    builder.Append("    </ul>");
                    builder.Append("</li>");
                    //builder.Append("<li><a href=\"#\">HỆ THỐNG</a>");
                    //builder.Append("    <ul>");
                    //builder.Append("        <li><a href=\"default.aspx?n=smtp\">SMTP Mail Server</a></li>");
                    //builder.Append("        <li><a href=\"default.aspx?n=userlist\">Danh sách người dùng</a></li>");
                    //builder.Append("    </ul>");
                    //builder.Append("</li>");
                    #endregion
                }
                else
                {
                    #region editor
                    builder.Append("<li><a href=\"default.aspx\">TRANG CHỦ</a></li>");
                    builder.Append("<li><a href=\"default.aspx?n=products\">SẢN PHẨM</a></li>");
                    //builder.Append("<li><a href=\"default.aspx?n=orderslist\">QUẢN LÝ ĐẶT HÀNG</a>");
                    //builder.Append("    <ul>");
                    //builder.Append("        <li><a href=\"default.aspx?n=orderslist\">Danh sách đơn hàng</a></li>");
                    //builder.Append("        <li><a href=\"default.aspx?n=paymentmethods\">Phương thức thanh toán</a></li>");
                    //builder.Append("        <li><a href=\"default.aspx?n=receivemethods\">Phương thức giao hàng</a></li>");
                    //builder.Append("    </ul>");
                    //builder.Append("</li>");
                    builder.Append("<li><a href=\"default.aspx?n=news\">TIN TỨC - SỰ KIỆN</a>");
                    builder.Append("    <ul>");
                    //builder.Append("        <li><a href=\"default.aspx?n=newscategory\">Danh mục tin tức</a></li>");
                    builder.Append("        <li><a href=\"default.aspx?n=news\">Danh sách tin tức</a></li>");
                    builder.Append("        <li><a href=\"default.aspx?n=salespolicy\">Chính sách bán hàng</a></li>");
                    builder.Append("        <li><a href=\"default.aspx?n=help\">Giúp đỡ</a></li>");
                    builder.Append("    </ul>");
                    builder.Append("</li>");
                    //builder.Append("<li><a href=\"default.aspx?n=advs\">QUẢNG CÁO - LOGO</a>");
                    //builder.Append("    <ul>");
                    //builder.Append("        <li><a href=\"default.aspx?n=advs\">Logo quảng cáo</a></li>");
                    //builder.Append("        <li><a href=\"default.aspx?n=brands\">Logo đối tác</a></li>");
                    //builder.Append("    </ul>");
                    //builder.Append("</li>");
                    //builder.Append("<li><a href=\"default.aspx?n=members\">THÀNH VIÊN</a></li>");
                    //builder.Append("<li><a href=\"#\">THÔNG TIN CHUNG</a>");
                    //builder.Append("    <ul>");
                    //builder.Append("        <li><a href=\"default.aspx?n=company\">Thông tin công ty</a></li>");
                    //builder.Append("        <li><a href=\"default.aspx?n=introduction\">Giới thiệu công ty</a></li>");
                    //builder.Append("        <li><a href=\"default.aspx?n=contact\">Khách hàng liên hệ</a></li>");
                    //builder.Append("        <li><a href=\"default.aspx?n=download\">Download bảng giá</a></li>");
                    //builder.Append("        <li><a href=\"default.aspx?n=supportonline\">Hỗ trợ trực tuyến</a></li>");
                    //builder.Append("    </ul>");
                    //builder.Append("</li>");
                    //builder.Append("<li><a href=\"#\">HỆ THỐNG</a>");
                    //builder.Append("    <ul>");
                    //builder.Append("        <li><a href=\"default.aspx?n=smtp\">SMTP Mail Server</a></li>");
                    //builder.Append("        <li><a href=\"default.aspx?n=userlist\">Danh sách người dùng</a></li>");
                    //builder.Append("    </ul>");
                    //builder.Append("</li>");
                    #endregion
                }

                ltMenu.Text = builder.ToString();
            }
        }
    }
}