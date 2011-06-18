using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using DataAccessLayer;
using BusinessObjects;
using SoftStore.App_Code;
using Utilities;

namespace SoftStore.controls
{
    public partial class login : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.Title = "Đăng nhập hệ thống - " + PageTitle.GetPageTitle();
                if (Request.Cookies["LoginCookie"] != null)
                {
                    HttpCookie cookie = Request.Cookies.Get("LoginCookie");
                    txtUserName.Text = cookie.Values["UserName"].ToString();
                    txtPassword.Attributes.Add("value", cookie.Values["Password"].ToString());
                    cbkRemember.Checked = true;
                } 
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Members mem = new Members();
            MembersInfo meminfo = mem.CheckLogin(txtUserName.Text.Trim(), Util.CreatePasswordHash(txtPassword.Text));
            if(meminfo!=null)
            {
                if (cbkRemember.Checked)
                {
                    setCookie(meminfo.UserName, txtPassword.Text);
                }
                else
                {
                    Response.Cookies.Remove("LoginCookie");
                }

                Session["MEMBERLOGIN"] = meminfo;
                Response.Redirect("/trang-chu.html");
            }
            else
            {
                ClientScriptManager csm = Page.ClientScript;
                string js =
                    "<script language=\"javascript\">alert('Tên đăng nhập hay mật khẩu không đúng. Vui lòng thử lại');window.location.href=\"/dang-nhap.html\";</script>";
                csm.RegisterStartupScript(Page.GetType(), "Found", js);
            }
        }
        private void setCookie(string username, string pass)
        {
            HttpCookie myCookie = new HttpCookie("LoginCookie");
            Response.Cookies.Remove("LoginCookie");
            Response.Cookies.Add(myCookie);
            myCookie.Values.Add("UserName", username);
            myCookie.Values.Add("Password", pass);
            DateTime dtExpiry = DateTime.Now.AddDays(30);
            Response.Cookies["LoginCookie"].Expires = dtExpiry;
        }

    }
}