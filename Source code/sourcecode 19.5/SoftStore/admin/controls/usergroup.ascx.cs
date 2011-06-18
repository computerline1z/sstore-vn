using System;
using System.Collections.Generic;
using System.Web.UI;
using DataAccessLayer;
using BusinessObjects;

namespace SoftStore.admin.controls
{
    public partial class usergroup : UserControl
    {
        UserGroup ug=new UserGroup();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                btnDel.Attributes.Add("OnClick", "return confirm('Bạn chắc chắn muốn xóa nhóm đã chọn?')");
                loadList();
                string id = Request["id"];
                if(id!=null)
                {
                    btnUpdate.Visible = true;
                    btnNew.Visible = false;
                    IList<UserGroupInfo> list = ug.getInfo(id);
                    if (list != null && list.Count != 0)
                    {
                        txtName.Text = list[0].Name;
                    }
                }
            }
        }
        private void loadList()
        {
            IList<UserGroupInfo> list = ug.getAll();
            if (list != null && list.Count != 0)
            {
                rptList.DataSource = list;
                rptList.DataBind();
            }
        }
        protected void btnNew_Click(object sender, ImageClickEventArgs e)
        {
            if(Page.IsValid)
            {
                int i = ug.insert(txtName.Text);
                if (i > 0)
                    Response.Redirect(Request.RawUrl);
                else
                    alert("Thêm mới nhóm không thành công. Vui lòng thử lại sau");
            }
        }

        protected void btnDel_Click(object sender, ImageClickEventArgs e)
        {
            string[] str = Request.Params.GetValues("select");
            if (str == null || str.Length == 0)
            {
                alert("Chọn mục cần xóa...");
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
                    int ii = ug.delete(result);
                    if (ii>0)
                        Response.Redirect(Request.RawUrl);
                    else
                        alert("Xóa không thành công. Vui lòng thử lại sau");
                }
            }
        }
        private void alert(string str)
        {
            ClientScriptManager csm = Page.ClientScript;
            string js = "<script language=\"javascript\">alert('" + str + "');</script>";
            csm.RegisterStartupScript(Page.GetType(), "alert_js", js);
        }

        protected void btnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("default.aspx?n=usergroup");
        }

        protected void btnUpdate_Click(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid)
            {
                string id = Request["id"];
                if (id != null)
                {
                    int i = ug.update(id, txtName.Text);
                    if (i > 0)
                        Response.Redirect("default.aspx?n=usergroup");
                    else
                        alert("Cập nhật nhóm không thành công. Vui lòng thử lại sau");
                }
            }
        }
    }
}