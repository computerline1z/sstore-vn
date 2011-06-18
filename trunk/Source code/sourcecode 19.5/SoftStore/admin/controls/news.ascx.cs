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
    public partial class news : UserControl
    {
        News ne = new News();
        NewsCategory cat=new NewsCategory();
        private static string display;
        public static string Display
        {
            get { return display; }
            set { display = value; }
        }
        UsersInfo user = UserLogin.GetUserLoging();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (user.GroupID == 3)
                {
                    //an quyen publish+del
                    btnPublished.Visible = false;
                    btnDel.Visible = false;
                    rdbIsPublishN.Checked = true;
                    rdbPublishY.Enabled = false;
                }

                btnDel.Attributes.Add("OnClick", "return confirm('Bạn chắc chắn muốn xóa tin tức đã chọn?')");
                Display = "none";
                loadCategory();
                string catid = Request["catid"];
                if (catid != null)
                {
                    drlCategory.SelectedValue = catid;
                    string id = Request["id"];
                    if (id == null)
                    {
                        loadListByCategory(int.Parse(catid));
                    }
                    else
                    {
                        LoadInfo(int.Parse(id));
                    }
                }
                else
                {
                    Response.Redirect("default.aspx?n=news&catid=" + drlCategory.SelectedValue);
                }
            }
        }
        private void loadCategory()
        {
            IList<NewsCategoryInfo> list = cat.GetList(true);
            if (list != null && list.Count != 0)
            {
                drlCategory.DataSource = list;
                drlCategory.DataTextField = "CategoryName";
                drlCategory.DataValueField = "CategoryID";
                drlCategory.DataBind();

                drlCategoryNew.DataSource = list;
                drlCategoryNew.DataTextField = "CategoryName";
                drlCategoryNew.DataValueField = "CategoryID";
                drlCategoryNew.DataBind();
            }
        }
        private void loadListByCategory(int CategoryID)
        {
            IList<NewsInfo> list = ne.GetList(CategoryID);
            if (list != null && list.Count != 0)
            {
                pagerList.DataSource = list;
                pagerList.BindToControl = rptList;
                rptList.DataSource = pagerList.DataSourcePaged;
            }
            else
            {
                rptList.DataSource = null;
                rptList.DataBind();
            }
        }
        private void LoadInfo(int id)
        {
            paList.Visible = false;
            paEdit.Visible = true;
            NewsInfo info = ne.GetByID(id);
            if (info != null)
            {
                txtTitle.Text = info.Title;
                txtContent.Text = info.Content;
                txtIntro.Text = info.Intro;

                txtPicNote.Text = info.PicNote;

                if (info.IsPublish)
                {
                    rdbPublishY.Checked = true;
                    rdbIsPublishN.Checked = false;
                }
                lblPic.Text = info.Picture;
                if (info.Picture == null || info.Picture.Length == 0)
                    Display = "none";
                else
                {
                    Display = "inline";
                    imgpic.Src = "../../resources/news/" + info.Picture;
                }
                if (info.IsHot)
                    cbkIsHot.Checked = true;
            }
        }
        protected void btnNew_Click(object sender, ImageClickEventArgs e)
        {
            paEdit.Visible = true;
            paList.Visible = false;
            drlCategoryNew.SelectedValue = Request["catid"];
        }

        protected void btnDel_Click(object sender, ImageClickEventArgs e)
        {
            string[] str = Request.Params.GetValues("select");
            if (str == null || str.Length == 0)
            {
                WebMsgBox.Show("Chọn tin tức cần xóa...");
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
                    bool ii = ne.Delete(result);
                    if (ii)
                        Response.Redirect(Request.RawUrl);
                    else
                        WebMsgBox.Show("Xóa tin tức không thành công. Vui lòng thử lại sau");
                }
            }
        }

        protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid)
            {
                int catID = int.Parse(drlCategoryNew.SelectedValue);
                string title = txtTitle.Text;
                string intro = txtIntro.Text;
                
                string content = txtContent.Text;
                bool ispublish = false;
                if (rdbPublishY.Checked)
                    ispublish = true;
                string savePath = "/resources/news/";
                string pic;
                string picnote = txtPicNote.Text;
                
                
                bool ishot = false;
                if (cbkIsHot.Checked)
                    ishot = true;
                if (imgAdv.PostedFile.FileName == null || imgAdv.PostedFile.FileName.Length == 0)
                    pic = lblPic.Text;
                else pic = Util.GetFileUpload(savePath, imgAdv);

                NewsInfo info =
                    new NewsInfo(1, 1, catID, title, intro, content, pic, picnote, ishot, user.ID, DateTime.Now, ispublish,
                                 0, DateTime.Now);

                string id = Request["id"];
                if (id == null)
                {
                    //them moi
                    bool kq;
                    if (user.GroupID == 3)
                    {
                        kq = ne.Insert(info);
                    }
                    else
                    {
                        kq = ne.InsertAdmin(info);
                    }
                    if (kq)
                        Response.Redirect("default.aspx?n=news&catid=" + Request["catid"]);
                    else
                        WebMsgBox.Show("Thêm mới tin tức không thành công. Vui lòng thử lại sau");
                }
                else
                {
                    info.ID = int.Parse(id);
                    //cap nhat
                    bool kq;
                    if (user.GroupID == 3)
                    {
                        kq = ne.Update(info);
                    }
                    else
                    {
                        kq = ne.UpdateAdmin(info);
                    }
                    if (kq)
                        Response.Redirect("default.aspx?n=news&catid="+Request["catid"]);
                    else
                        WebMsgBox.Show("Cập nhật tin tức không thành công. Vui lòng thử lại sau");
                }
            }
        }

        protected void btnCancel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("default.aspx?n=news&catid=" + Request["catid"]);
        }

        protected void cbk_delImg_Checked(object sender, EventArgs e)
        {
            if (cbkDelImg.Checked)
            {
                string id = Request["id"];
                bool ii = ne.DeleteImg(id);
                if (ii)
                    Display = "none";
                lblPic.Text = null;
            }
        }

        protected void drlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx?n=news&catid=" + drlCategory.SelectedValue);
        }

        protected void btnPublished_Click(object sender, ImageClickEventArgs e)
        {
            string publish = null;
            string unpublish = null;
            foreach (RepeaterItem item in rptList.Items)
            {
                Label lblID = (Label)item.FindControl("lblID");
                CheckBox cbkIsPublished = (CheckBox)item.FindControl("cbkIsPublished");
                if (cbkIsPublished.Checked)
                {
                    publish += lblID.Text + ",";
                }
                else unpublish += lblID.Text + ",";
            }
            bool ii = false;
            if (publish != null)
            {
                publish = publish.Substring(0, publish.Length - 1);
                ii = ne.Published(publish, true);
            }
            if (unpublish != null)
            {
                unpublish = unpublish.Substring(0, unpublish.Length - 1);
                ii = ne.Published(unpublish, false);
            }
            if (ii)
                Response.Redirect(Request.RawUrl);
            else
                WebMsgBox.Show("Publish tin tức không thành công. Vui lòng thử lại sau");
        }
    }
}