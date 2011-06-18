using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using DataAccessLayer;
using BusinessObjects;
using Utilities;

namespace SoftStore.admin
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string act = Request["act"];
                if (act == null || act.Length == 0)
                {
                    txtUserName.Focus();
                }
                else
                {
                    if (act.Equals("logout"))
                    {
                        txtUserName.Focus();
                        Session.Remove("LOGINADMIN");
                        Response.Redirect("login.aspx");
                    }
                }
            }
        }

        protected void btnLogIn_Click(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid)
            {
                string userName = txtUserName.Text.Trim();
                string pass = Util.CreatePasswordHash(txtPassword.Text.Trim());
                Users us = new Users();
                UsersInfo info = us.CheckLogin(userName, pass);
                if (info == null)
                {
                    lblErr.Text = "Tên đăng nhập hay mật khẩu không đúng";
                }
                else
                {
                    Session["LOGINADMIN"] = info;
                    Response.Redirect("default.aspx");
                }
            }
        }
    }
}
