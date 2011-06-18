using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using BusinessObjects;
using SoftStore.App_Code;
using Utilities;
namespace SoftStore.admin.controls
{
    public partial class userlist : System.Web.UI.UserControl
    {
        UserGroup group = new UserGroup();
        Users us = new Users();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UsersInfo user = UserLogin.GetUserLoging();
                if (user.GroupID != 0 && user.GroupID != 1)
                {
                    Response.Redirect("denied.aspx");
                }
                btnDel.Attributes.Add("OnClick", "return confirm('Bạn chắc chắn muốn xóa người dùng đã chọn')");
                loadListGroup();
                string id = Request["id"];
                if (id == null)
                {
                    loadListUser();
                    rowReset.Visible = false;
                }
                else
                {
                    paList.Visible = false;
                    paEdit.Visible = true;
                    UsersInfo info = us.GetByID(id);
                    if (info != null)
                    {
                        txtFullName.Text = info.FullName;
                        txtusename.Text = info.UserName;
                        txtusename.Enabled = false;
                        txtAddress.Text = info.Address;
                        txtPhone.Text = info.Phone;
                        txtMobile.Text = info.Mobile;
                        txtEmail.Text = info.Email;
                        txtDes.Text = info.Description;
                        drlGroup.SelectedValue = info.GroupID.ToString();
                        if (info.StatusID == false)
                            drlStatus.SelectedValue = "0";


                        rowMK.Visible = false;
                        rowConfirmMK.Visible = false;
                        rowReset.Visible = true;
                    }
                }
            }
        }
        private void loadListUser()
        {
            IList<UsersInfo> list = us.GetList();
            if (list != null && list.Count != 0)
            {
                rptListUser.DataSource = list;
                rptListUser.DataBind();
            }
        }
        private void loadListGroup()
        {
            IList<UserGroupInfo> list = group.getAllBySuper();
            if (list != null && list.Count != 0)
            {
                drlGroup.DataSource = list;
                drlGroup.DataTextField = "Name";
                drlGroup.DataValueField = "ID";
                drlGroup.DataBind();
            }
        }
        protected void btnNew_Click(object sender, ImageClickEventArgs e)
        {
            paList.Visible = false;
            paEdit.Visible = true;
        }

        protected void btnDel_Click(object sender, ImageClickEventArgs e)
        {
            string[] str = Request.Params.GetValues("select");
            if (str == null || str.Length == 0)
            {
                WebMsgBox.Show("Chọn người dùng cần xóa");
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
                    long ii = us.delete(result);
                    if (ii > 0)
                    {
                        Response.Redirect(Request.RawUrl);
                    }
                    else
                    {
                        WebMsgBox.Show("Xóa người dùng không thành công");
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid)
            {
                string fullname = txtFullName.Text;
                string address = txtAddress.Text;
                string mobile = txtMobile.Text;
                string phone = txtPhone.Text;
                string email = txtEmail.Text;
                string des = txtDes.Text;
                int groupid = int.Parse(drlGroup.SelectedValue);
                bool statusid = true;
                if (drlStatus.SelectedValue == "0")
                    statusid = false;
                string username = txtusename.Text.Trim();
                string pass = Util.CreatePasswordHash(txtpass.Text.Trim());
                UsersInfo info=new UsersInfo(1,1,fullname,address,phone,mobile,email,des,username,pass,groupid,statusid,DateTime.Now,DateTime.Now);
                string id = Request["id"];
                if (id == null)
                {
                    int ii =
                        us.insert(info);
                    if (ii > 0)
                        Response.Redirect(Request.RawUrl);
                    else
                        WebMsgBox.Show("Thêm mới người dùng không thành công");
                }
                else
                {
                    info.ID = int.Parse(id);
                    int ii =
                        us.update(info);
                    if (ii > 0)
                        Response.Redirect("default.aspx?n=userlist");
                    else
                        WebMsgBox.Show("Cập nhật thông tin người dùng không thành công");
                }
            }
        }

        protected void btnCancel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("default.aspx?n=userlist");
        }
        public string GetGroup(object groupid)
        {
            IList<UserGroupInfo> list = group.getInfo(groupid.ToString());
            if (list != null && list.Count != 0)
                return list[0].Name;
            else return null;
        }
    }
}