using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using DataAccessLayer;
using BusinessObjects;
using Utilities;

namespace SoftStore.admin.controls
{
    public partial class editprofile : System.Web.UI.UserControl
    {
        Users us = new Users();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOK_Click(object sender, ImageClickEventArgs e)
        {
            if(Page.IsValid)
            {
                object obj = Session["LOGINADMIN"];
                if (obj != null)
                {
                    UsersInfo usi = (UsersInfo) obj;
                    //check current pass
                    string currentpass = Util.CreatePasswordHash(txtCurrentPass.Text.Trim());
                    string check = us.checkOldPass(usi.ID.ToString(), currentpass);
                    if (check == null || check.Length == 0)
                    {
                        lblNote.Style.Add("color", "red");
                        lblNote.Text = "Mật khẩu hiện tại không đúng, xin vui lòng nhập lại";
                    }
                    else
                    {
                        string newpass = Util.CreatePasswordHash(txtNewPass.Text.Trim());
                        int i = us.changePass(usi.ID.ToString(), newpass);
                        if(i>0)
                        {
                            lblNote.Style.Add("color", "blue");
                            lblNote.Text = "Thay đổi mật khẩu thành công";
                        }
                        else
                        {
                            lblNote.Style.Add("color", "red");
                            lblNote.Text = "Có lỗi xảy ra, quá trình đổi mật khẩu không thành công, xin vui lòng thử lại sau";
                        }
                    }
                }
            }
        }
    }
}