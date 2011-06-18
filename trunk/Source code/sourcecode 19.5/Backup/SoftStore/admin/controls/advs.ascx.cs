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
    public partial class advs : UserControl
    {
        Advs ne = new Advs();
        private static string display;
        public static string Display
        {
            get { return display; }
            set { display = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnDel.Attributes.Add("OnClick", "return confirm('Bạn chắc chắn muốn xóa logo đã chọn?')");
                Display = "none";
                UsersInfo user = UserLogin.GetUserLoging();
                if (user.GroupID != 0 && user.GroupID != 1)
                {
                    Response.Redirect("denied.aspx");
                }
                string id = Request["id"];
                if (id == null)
                    loadList();
                else loadInfo(id);
            }
        }
        private void loadList()
        {
            IList<AdvsInfo> list = ne.getList();
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
            AdvsInfo info = ne.getByID(id);
            if (info != null)
            {
                txtName.Text = info.AdvName;
                txtDescription.Text = info.Description;
                txtIndex.Text = info.SortOrder.ToString();
                lblPic.Text = info.Picture;
                txtExpireDate.SelectedValue = info.ExpireDate;
                if (info.Picture == null || info.Picture.Length == 0)
                    Display = "none";
                else
                {
                    if (info.Picture.IndexOf(".swf")>0)
                    {
                        Display = "none";
                        StringBuilder str = new StringBuilder();
                        str.Append("      <object classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\" codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\" width=\"" + info.Width + "\" height=\"" + info.Height + "\">");
                        str.Append("      <param name=\"movie\" value=\"../../resources/logoadvs/" + info.Picture + "\" />");
                        str.Append("      <param name=\"quality\" value=\"high\" />");
                        str.Append("      <embed src=\"../../resources/logoadvs/" + info.Picture + "\" quality=\"high\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\" width=\"" + info.Width + "\" height=\"" + info.Height + "\"></embed>");
                        str.Append("      </object>");

                        ltImgFlash.Text = str.ToString();
                    }
                    else
                    {
                        Display = "inline";
                        imgpic.Src = "../../resources/logoadvs/" + info.Picture;
                    }
                }
                txtUrl.Text = info.Url;
                txtWidth.Text = info.Width.ToString();
                txtHeight.Text = info.Height.ToString();
            }
        }
        protected void btnNew_Click(object sender, ImageClickEventArgs e)
        {
            paEdit.Visible = true;
            paList.Visible = false;
            txtExpireDate.SelectedValue = DateTime.Now.AddDays(60);
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
                    bool ii = ne.delete(result);
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
                string name = txtName.Text;
                int index = int.Parse(txtIndex.Text.Trim());
                string description = txtDescription.Text;

                string savePath = "/resources/logoadvs/";
                string pic;
                string url = txtUrl.Text;
                int width = int.Parse(txtWidth.Text);
                int height = int.Parse(txtHeight.Text);

                if (imgAdv.PostedFile.FileName == null || imgAdv.PostedFile.FileName.Length == 0)
                    pic = lblPic.Text;
                else pic = Util.GetFileUpload(savePath, imgAdv);

                AdvsInfo advinfo =
                        new AdvsInfo(1, 1, name, pic, url, description, index, width, height, DateTime.Now,
                                     txtExpireDate.SelectedValue);
                string id = Request["id"];
                if (id == null)
                {
                    
                    
                    //them moi
                    bool kq = ne.insert(advinfo);
                    if (kq)
                        Response.Redirect("default.aspx?n=advs");
                    else
                        WebMsgBox.Show("Thêm mới không thành công. Vui lòng thử lại sau");
                }
                else
                {
                    advinfo.ID = int.Parse(id);
                    //cap nhat
                    bool kq = ne.update(advinfo);
                    if (kq)
                        Response.Redirect("default.aspx?n=advs");
                    else
                        WebMsgBox.Show("Cập nhật không thành công. Vui lòng thử lại sau");
                }
            }
        }

        protected void btnCancel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("default.aspx?n=advs");
        }
       

    }
}