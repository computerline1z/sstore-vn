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
    public partial class help : System.Web.UI.UserControl
    {
        Help sl = new Help();
        UsersInfo user = UserLogin.GetUserLoging();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                //string id = Request["id"];
                //if (id != null)
                //{
                //    loadInfo(int.Parse(id));
                //}
                //else
                //{
                    loadList();
                //}
            }
        }
        private void loadList()
        {
            IList<HelpInfo> list = sl.GetListHelp();
            if (list != null && list.Count != 0)
            {
                //pagerList.DataSource = list;
                //pagerList.BindToControl = rptList;
                //rptList.DataSource = pagerList.DataSourcePaged;
                txtTitle.Text = list[0].Title;
                txtContent.Text = list[0].Content;
                if (list[0].Status)
                {
                    rdbYes.Checked = true;
                    rdbNo.Checked = false;
                }
            }
        }
        //private void loadInfo(int id)
        //{
        //    paList.Visible = false;
        //    paEdit.Visible = true;
        //    HelpInfo info = sl.GetByID(id);
        //    if (info != null)
        //    {
        //        txtTitle.Text = info.Title;
        //        txtContent.Text = info.Content;
        //        if (info.Status)
        //        {
        //            rdbYes.Checked = true;
        //            rdbNo.Checked = false;
        //        }
        //    }
        //}
        //protected void btnNew_Click(object sender, ImageClickEventArgs e)
        //{
        //    paEdit.Visible = true;
        //    paList.Visible = false;
        //}

        //protected void btnDel_Click(object sender, ImageClickEventArgs e)
        //{
        //    string[] str = Request.Params.GetValues("select");
        //    if (str == null || str.Length == 0)
        //    {
        //        WebMsgBox.Show("Chọn tin cần xóa...");
        //    }
        //    else
        //    {
        //        int size = str.Length;
        //        string result = null;
        //        for (int i = 0; i < size; i++)
        //        {
        //            if (i == size - 1)
        //                result += str[i];
        //            else result += str[i] + ",";
        //        }

        //        if (result != null)
        //        {
        //            bool ii = sl.Delete(result);
        //            if (ii)
        //                Response.Redirect(Request.RawUrl);
        //            else
        //                WebMsgBox.Show("Xóa tin không thành công. Vui lòng thử lại sau");
        //        }
        //    }
        //}

        protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid)
            {
                string title = txtTitle.Text;
                string content = txtContent.Text;
                bool statusid = false;
                if (rdbYes.Checked)
                    statusid = true;

                HelpInfo info = new HelpInfo(1, 1, title, content, statusid, DateTime.Now);
                //string id = Request["id"];
                //if (id == null)
                //{

                //    bool kq = sl.Insert(info);
                //    if (kq)
                //        Response.Redirect("default.aspx?n=warranty");
                //    else
                //        WebMsgBox.Show("Thêm mới tin chính sách bảo hành không thành công. Vui lòng thử lại sau");
                //}
                //else
                //{
                    //info.ID = int.Parse(id);
                    bool kq = sl.Update(info);
                    if (kq)
                        Response.Redirect("default.aspx?n=help");
                    else
                        WebMsgBox.Show("Cập nhật thông tin giúp đỡ không thành công. Vui lòng thử lại sau");
                //}
            }
        }

        protected void btnCancel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("default.aspx?n=help");
        }
       
        //protected void btnPublished_Click(object sender, ImageClickEventArgs e)
        //{
        //    string publish = null;
        //    string unpublish = null;
        //    foreach (RepeaterItem item in rptList.Items)
        //    {
        //        Label lblID = (Label)item.FindControl("lblID");
        //        CheckBox cbkIsPublished = (CheckBox)item.FindControl("cbkIsPublished");
        //        if (cbkIsPublished.Checked)
        //        {
        //            publish += lblID.Text + ",";
        //        }
        //        else unpublish += lblID.Text + ",";
        //    }
        //    bool ii = false;
        //    if (publish != null)
        //    {
        //        publish = publish.Substring(0, publish.Length - 1);
        //        ii = sl.Published(publish, true);
        //    }
        //    if (unpublish != null)
        //    {
        //        unpublish = unpublish.Substring(0, unpublish.Length - 1);
        //        ii = sl.Published(unpublish, false);
        //    }
        //    if (ii)
        //        Response.Redirect(Request.RawUrl);
        //    else
        //        WebMsgBox.Show("Publish tin tức không thành công. Vui lòng thử lại sau");
        //}
    }
}