using System;
using System.Collections.Generic;
using System.Web.UI;
using DataAccessLayer;
using BusinessObjects;
using SoftStore.App_Code;
using Utilities;

namespace SoftStore.controls
{
    public partial class edit_profile : System.Web.UI.UserControl
    {
        Members mem = new Members();
        MembersInfo item = MemberLogin.GetMemberLogin();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Cập nhật thông tin cá nhân thành viên - " + PageTitle.GetPageTitle();
            if(!IsPostBack)
            {
                if(item!=null)
                {
                    txtFullName.Text = item.FullName;
                    txtUserName.Text = item.UserName;
                    txtAddress.Text = item.Address;
                    txtPhone.Text = item.Phone;
                    txtEmail.Text = item.Email;
                    txtMobile.Text = item.Mobile;
                    lblAvatar.Text = item.Avatar;
                    imgAvatar.Src = "/resources/avatars/" + item.Avatar;
                }
                else
                {
                    Response.Redirect("/trang-chu.html");
                }
            }
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (captchaCode.IsValid)
            {
                MembersInfo _item = new MembersInfo();
                _item.MemberID = item.MemberID;
                _item.FullName = txtFullName.Text;
                _item.Address = txtAddress.Text;
                _item.Phone = txtPhone.Text;
                _item.Email = txtEmail.Text;
                _item.Mobile = txtMobile.Text;
                string Avatar = lblAvatar.Text;
                string savePath = "/resources/avatars/";
                if (flAvatar.PostedFile.FileName != null && flAvatar.PostedFile.FileName.Length != 0)
                    Avatar = Util.GetFileUpload(savePath, flAvatar);
                _item.Avatar = Avatar;
                bool ii = mem.MemberUpdate(_item);
                if (ii)
                {
                    ClientScriptManager csm = Page.ClientScript;
                    string js =
                        "<script language=\"javascript\">alert('Bạn đã cập nhật thông tin thành công. Vui lòng đăng nhập trở lại');window.location.href=\"/trang-chu.html?act=logout\";</script>";
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