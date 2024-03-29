using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using DataAccessLayer;
using BusinessObjects;
using SoftStore.App_Code;
using Utilities;

namespace SoftStore.admin.controls
{
    public partial class members : UserControl
    {
        Members mem = new Members();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UsersInfo user = UserLogin.GetUserLoging();
                if (user.GroupID == 3)
                {
                    Response.Redirect("denied.aspx");
                }
                btnDel.Attributes.Add("OnClick", "return confirm('Bạn chắc chắn muốn xóa thành viên đã chọn?')");
                string id = Request["id"];
                if (id == null)
                    loadList();
                else loadInfo(id);
            }
        }
        private void loadList()
        {
            List<MembersInfo> list = mem.GetList();
            if (list != null && list.Count != 0)
            {
                rptList.DataSource = list;
                rptList.DataBind();
            }
        }
        private void loadInfo(string id)
        {
            paList.Visible = false;
            paEdit.Visible = true;
            MembersInfo info = mem.GetByMemberID(int.Parse(id));
            if (info != null)
            {
                txtFullName.Text = info.FullName;
                txtUserName.Text = info.UserName;
                txtAddress.Text = info.Address;
                txtPhone.Text = info.Phone;
                txtMobile.Text = info.Mobile;
                txtEmail.Text = info.Email;
                if (!info.Status)
                    rdbActivateN.Checked = true;
                
                lblAvatar.Text = info.Avatar;
                imgAvatar.Src = "/resources/avatars/" + info.Avatar;

                rowReset.Visible = true;
                rowPass.Visible = false;
            }
        }
        protected void btnNew_Click(object sender, ImageClickEventArgs e)
        {
            paEdit.Visible = true;
            paList.Visible = false;
            rowReset.Visible = false;
            rowPass.Visible = true;
            lblAvatar.Text = "avatar.jpg";
        }

        protected void btnDel_Click(object sender, ImageClickEventArgs e)
        {
            string[] str = Request.Params.GetValues("select");
            if (str == null || str.Length == 0)
            {
                WebMsgBox.Show("Chọn thành viên cần xóa...");
            }
            else
            {
                int size = str.Length;
                string result = null;
                for (int i = 0; i < size; i++)
                {
                    if (i == size - 1)
                        result += str[i];
                    else result += str[i] + ",";
                }

                if (result != null)
                {
                    bool ii = mem.Delete(result);
                    if (ii)
                        Response.Redirect(Request.RawUrl);
                    else
                        WebMsgBox.Show("Xóa không thành công. Vui lòng thử lại sau");
                }
            }
        }

        protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid)
            {
                MembersInfo _item = new MembersInfo();
                _item.FullName = txtFullName.Text;
                _item.UserName = txtUserName.Text;
                _item.Address = txtAddress.Text;
                _item.Phone = txtPhone.Text;
                _item.Email = txtEmail.Text;
                _item.Mobile = txtMobile.Text;
                string Avatar = lblAvatar.Text;
                string savePath = "/resources/avatars/";
                if (flAvatar.PostedFile.FileName != null && flAvatar.PostedFile.FileName.Length != 0)
                    Avatar = Util.GetFileUpload(savePath, flAvatar);
                _item.Avatar = Avatar;
                bool Status = true;
                if (rdbActivateN.Checked)
                    Status = false;
                _item.Status = Status;
                _item.RegisteredDate = DateTime.Now;
                
                string id = Request["id"];
                if (id == null)
                {
                    _item.Password = Util.CreatePasswordHash(txtPassword.Text);
                    //them moi
                    bool kq = mem.Insert(_item);
                    if (kq)
                        Response.Redirect("default.aspx?n=members");
                    else
                        WebMsgBox.Show("Thêm mới không thành công. Vui lòng thử lại sau");
                }
                else
                {
                    _item.MemberID = int.Parse(id);
                    //cap nhat
                    bool kq = mem.Update(_item);
                    if (kq)
                        Response.Redirect("default.aspx?n=members");
                    else
                        WebMsgBox.Show("Cập nhật không thành công. Vui lòng thử lại sau");
                }
            }
        }

        protected void btnCancel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("default.aspx?n=members");
        }


    }
}