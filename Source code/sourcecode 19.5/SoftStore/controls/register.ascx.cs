using System;
using System.Collections.Generic;
using System.Web.UI;
using DataAccessLayer;
using BusinessObjects;
using SoftStore.App_Code;
using Utilities;

namespace SoftStore.controls
{
    public partial class register : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Đăng ký thành viên - " + PageTitle.GetPageTitle();
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (captchaCode.IsValid)
            {
                Members mem = new Members();
                MembersInfo item = new MembersInfo();
                item.FullName = txtFullName.Text;
                item.UserName = txtUserName.Text;
                item.Address = txtAddress.Text;
                item.Phone = txtPhone.Text;
                item.Password = Utilities.Util.CreatePasswordHash(txtPassword.Text);
                item.Email = txtEmail.Text;
                item.Mobile = txtMobile.Text;
                item.Status = false;
                item.RegisteredDate = DateTime.Now;
                string Avatar="avatar.jpg";//default
                string savePath = "/resources/avatars/";
                if (flAvatar.PostedFile.FileName != null && flAvatar.PostedFile.FileName.Length != 0)
                    Avatar = Util.GetFileUpload(savePath, flAvatar);
                item.Avatar = Avatar;
                bool ii = mem.Insert(item);
                if (ii)
                {
                    ClientScriptManager csm = Page.ClientScript;
                    string js =
                        "<script language=\"javascript\">alert('Chúc mừng bạn đã đăng ký thành viên thành công. Vui lòng đăng nhập để được hưởng các chính sách khuyến mãi. Cảm ơn');window.location.href=\"/trang-chu.html\";</script>";
                    csm.RegisterStartupScript(Page.GetType(), "Found", js);
                }
                else
                {
                    WebMsgBox.Show("Đăng ký không thành công. Vui lòng thử lại sau");
                }
            }
            else
            {
                WebMsgBox.Show("Mã an toàn không đúng. Vui lòng nhập lại");
            }
        }
    }
}