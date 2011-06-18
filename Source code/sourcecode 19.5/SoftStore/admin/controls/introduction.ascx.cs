using System;
using System.Collections.Generic;
using System.Web.UI;
using DataAccessLayer;
using BusinessObjects;
using SoftStore.App_Code;
using Utilities;

namespace SoftStore.admin.controls
{
    public partial class introduction : System.Web.UI.UserControl
    {
        Introduction sl=new Introduction();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                UsersInfo user = UserLogin.GetUserLoging();
                if (user.GroupID == 3)
                {
                    Response.Redirect("denied.aspx");
                }
                string id = Request["id"];
                if(id!=null)
                {
                    loadInfo(int.Parse(id));
                }
                else
                {
                    loadList();
                }
            }
        }
        private void loadList()
        {
            IList<IntroductionInfo> list = sl.GetListIntroduction();
            if (list != null && list.Count != 0)
            {
                pagerList.DataSource = list;
                pagerList.BindToControl = rptList;
                rptList.DataSource = pagerList.DataSourcePaged;
            }
        }
        private void loadInfo(int id)
        {
            paList.Visible = false;
            paEdit.Visible = true;
            IntroductionInfo info = sl.GetByID(id);
            if (info != null)
            {
                txtTitle.Text = info.Title;
                txtContent.Text = info.Content;
                if (info.Status)
                {
                    rdbYes.Checked = true;
                    rdbNo.Checked = false;
                }
            }
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
                WebMsgBox.Show("Chọn tin cần xóa...");
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
                    bool ii = sl.Delete(result);
                    if (ii)
                        Response.Redirect(Request.RawUrl);
                    else
                        WebMsgBox.Show("Xóa tin không thành công. Vui lòng thử lại sau");
                }
            }
        }

        protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid)
            {
                string title = txtTitle.Text;
                string content = txtContent.Text;
                bool statusid = false;
                if (rdbYes.Checked)
                    statusid = true;
                
                IntroductionInfo info=new IntroductionInfo(1,1,title,content,statusid,DateTime.Now);
                string id = Request["id"];
                if (id == null)
                {

                    bool kq = sl.Insert(info);
                    if (kq)
                        Response.Redirect("default.aspx?n=introduction");
                    else
                        WebMsgBox.Show("Thêm mới tin không thành công. Vui lòng thử lại sau");
                }
                else
                {
                    info.ID = int.Parse(id);
                    bool kq = sl.Update(info);
                    if (kq)
                        Response.Redirect("default.aspx?n=introduction");
                    else
                        WebMsgBox.Show("Cập nhật tin không thành công. Vui lòng thử lại sau");
                }
            }
        }

        protected void btnCancel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("default.aspx?n=introduction");
        }
    }
}