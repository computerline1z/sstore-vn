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
    public partial class brands : UserControl
    {
        Brands ne = new Brands();
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
            IList<BrandsInfo> list = ne.getList();
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
            BrandsInfo info = ne.getByID(id);
            if (info != null)
            {
                txtName.Text = info.Name;
                txtDescription.Text = info.Description;
                txtIndex.Text = info.SortOrder.ToString();
                lblPic.Text = info.Picture;
                
                if (info.Picture == null || info.Picture.Length == 0)
                    Display = "none";
                else
                {
                    Display = "inline";
                    imgpic.Src = "../../resources/logo/" + info.Picture;
                }
                txtUrl.Text = info.Url;
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

                string savePath = "/resources/logo/";
                string pic;
                string url = txtUrl.Text;


                if (imgAdv.PostedFile.FileName == null || imgAdv.PostedFile.FileName.Length == 0)
                    pic = lblPic.Text;
                else pic = Util.GetFileUpload(savePath, imgAdv);

                BrandsInfo advinfo =
                        new BrandsInfo(1, 1, name, pic, url, description, index);
                string id = Request["id"];
                if (id == null)
                {
                    
                    
                    //them moi
                    bool kq = ne.insert(advinfo);
                    if (kq)
                        Response.Redirect("default.aspx?n=brands");
                    else
                        WebMsgBox.Show("Thêm mới không thành công. Vui lòng thử lại sau");
                }
                else
                {
                    advinfo.ID = int.Parse(id);
                    //cap nhat
                    bool kq = ne.update(advinfo);
                    if (kq)
                        Response.Redirect("default.aspx?n=brands");
                    else
                        WebMsgBox.Show("Cập nhật không thành công. Vui lòng thử lại sau");
                }
            }
        }

        protected void btnCancel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("default.aspx?n=brands");
        }
       

    }
}