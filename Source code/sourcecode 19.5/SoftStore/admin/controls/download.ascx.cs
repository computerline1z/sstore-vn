using System;
using System.Collections.Generic;
using System.Web.UI;
using DataAccessLayer;
using BusinessObjects;
using SoftStore.App_Code;
using Utilities;

namespace SoftStore.admin.controls
{
    public partial class download : UserControl
    {
        Download cat = new Download();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnDel.Attributes.Add("OnClick", "return confirm('Bạn chắc chắn muốn xóa mục đã chọn?')");
                UsersInfo user = UserLogin.GetUserLoging();
                if (user.GroupID == 3)
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
            IList<DownloadInfo> list = cat.GetListDownLoad();
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
            DownloadInfo info = cat.GetByID(id);
            if (info != null)
            {
                txtName.Text = info.Title;
                txtDescription.Text = info.Description;
                if (info.IsPublish)
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
                string title = txtName.Text;
                string des = txtName.Text;
                bool published = false;
                if (rdbYes.Checked)
                    published = true;

                string filename;
                string savePath = "/resources/download/";
                if (imgAdv.PostedFile.FileName == null || imgAdv.PostedFile.FileName.Length == 0)
                    filename = lblFile.Text;
                else filename = Util.GetFileUpload(savePath, imgAdv);
                DownloadInfo info = new DownloadInfo(1, 1, title, des, filename, DateTime.Now, published);
                string id = Request["id"];
                if (id == null)
                {
                    
                    bool kq = cat.Insert(info);
                    if (kq)
                        Response.Redirect("default.aspx?n=download");
                    else
                    {
                        WebMsgBox.Show("Thêm mới không thành công, vui lòng thử lại sau");
                    }
                }
                else
                {
                    info.ID = int.Parse(id);
                    bool kq = cat.Update(info);
                    if (kq)
                        Response.Redirect("default.aspx?n=download");
                    else
                    {
                        WebMsgBox.Show("Cập nhật không thành công, vui lòng thử lại sau");
                    }
                }
            }
        }

        protected void btnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("default.aspx?n=download");
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
                WebMsgBox.Show("Chọn mục cần xóa...");
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
                        WebMsgBox.Show("Xóa không thành công. Vui lòng thử lại sau");
                }
            }
        }
        

    }
}