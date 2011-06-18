using System;
using System.Collections.Generic;
using System.Web.UI;
using DataAccessLayer;
using BusinessObjects;
using SoftStore.App_Code;

namespace SoftStore.admin.controls
{
    public partial class productsupplier : UserControl
    {
        ProductSupplier cat = new ProductSupplier();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UsersInfo user = UserLogin.GetUserLoging();
                if (user.GroupID != 0 && user.GroupID != 1)
                {
                    Response.Redirect("denied.aspx");
                }
                
                string id = Request["id"];
                if (id != null)
                {
                    loadInfo(int.Parse(id));
                }
                else loadList();
            }
        }
        private void loadList()
        {
            IList<ProductSupplierInfo> list = cat.GetList();
            if (list != null && list.Count != 0)
            {
                rptList.DataSource = list;
                rptList.DataBind();
            }
        }
        private void loadInfo(int id)
        {
            paList.Visible = false;
            paEdit.Visible = true;
            ProductSupplierInfo info = cat.GetByID(id);
            if (info != null)
            {
                txtName.Text = info.SupplierName;
                txtDescription.Text = info.Description.ToString();
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
                string SupplierName = txtName.Text;
                string Des = txtDescription.Text;
                bool published = false;
                if (rdbYes.Checked)
                    published = true;

                string id = Request["id"];
                if (id == null)
                {
                    ProductSupplierInfo info = new ProductSupplierInfo(1, 1, SupplierName, Des, published, DateTime.Now);
                    bool kq = cat.Insert(info);
                    if (kq)
                        Response.Redirect("default.aspx?n=productsupplier");
                    else
                    {
                        alert("Thêm mới không thành công, vui lòng thử lại sau");
                    }
                }
                else
                {
                    ProductSupplierInfo info = new ProductSupplierInfo(1, int.Parse(id), SupplierName, Des, published, DateTime.Now);
                    bool kq = cat.Update(info);
                    if (kq)
                        Response.Redirect("default.aspx?n=productsupplier");
                    else
                    {
                        alert("Cập nhật không thành công, vui lòng thử lại sau");
                    }
                }
            }
        }

        protected void btnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("default.aspx?n=productsupplier");
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