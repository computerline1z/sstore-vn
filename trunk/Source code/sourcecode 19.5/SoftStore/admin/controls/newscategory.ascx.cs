using System;
using System.Collections.Generic;
using System.Web.UI;
using DataAccessLayer;
using BusinessObjects;
using SoftStore.App_Code;

namespace SoftStore.admin.controls
{
    public partial class newscategory : UserControl
    {
        NewsCategory cat = new NewsCategory();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UsersInfo user = UserLogin.GetUserLoging();
                if (user.GroupID != 0 && user.GroupID != 1)
                {
                    Response.Redirect("denied.aspx");
                }
                btnDel.Attributes.Add("OnClick", "return confirm('Bạn chắc chắn muốn xóa mục đã chọn?')");
                string id = Request["id"];
                if (id != null)
                {
                    loadInfo(id);
                }
                else loadList();
            }
        }
        private void loadList()
        {
            IList<NewsCategoryInfo> list = cat.GetList();
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
            NewsCategoryInfo info = cat.GetByID(id);
            if (info != null)
            {
                txtName.Text = info.CategoryName;
                txtIndex.Text = info.SortOrder.ToString();
                if (info.Status)
                {
                    rdbYes.Checked = true;
                    rdbNo.Checked = false;
                }
            }
        }

        protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid)
            {
                string CategoryName = txtName.Text;
                int index;
                try
                {
                    index = int.Parse(txtIndex.Text.Trim());
                }
                catch
                {
                    index = 1;
                }
                bool published = false;
                if (rdbYes.Checked)
                    published = true;

                string id = Request["id"];
                if (id == null)
                {
                    NewsCategoryInfo info = new NewsCategoryInfo(1,1, CategoryName, index, published, DateTime.Now);
                    bool kq = cat.Insert(info);
                    if (kq)
                        Response.Redirect("default.aspx?n=newscategory");
                    else
                    {
                        alert("Thêm mới không thành công, vui lòng thử lại sau");
                    }
                }
                else
                {
                    NewsCategoryInfo info = new NewsCategoryInfo(1, int.Parse(id), CategoryName, index, published, DateTime.Now);
                    bool kq = cat.Update(info);
                    if (kq)
                        Response.Redirect("default.aspx?n=newscategory");
                    else
                    {
                        alert("Cập nhật không thành công, vui lòng thử lại sau");
                    }
                }
            }
        }

        protected void btnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("default.aspx?n=newscategory");
        }

        protected void btnNew_Click(object sender, ImageClickEventArgs e)
        {
            paEdit.Visible = true;
            paList.Visible = false;
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
                    bool ii = cat.Delete(result);
                    if (ii)
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

    }
}