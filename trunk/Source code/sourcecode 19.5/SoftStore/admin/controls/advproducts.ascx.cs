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
    public partial class advproducts : UserControl
    {
        AdvProducts ne = new AdvProducts();
        private static string display;
        public static string Display
        {
            get { return display; }
            set { display = value; }
        }
        ProductSupplier cat = new ProductSupplier();
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
                else
                {
                    loadCategory();
                    loadInfo(int.Parse(id));
                }
            }
        }
        private void loadCategory()
        {
            //IList<ProductCategoryInfo> list = cat.GetList(true);
            //if (list != null && list.Count != 0)
            //{
            //    drlCategory.DataSource = list;
            //    drlCategory.DataTextField = "CategoryName";
            //    drlCategory.DataValueField = "CategoryID";
            //    drlCategory.DataBind();
            //}
        }
        public string GetCategoryname(object id)
        {
            //ProductCategoryInfo info = cat.GetByID(id.ToString());
            //if (info != null)
            //    return info.CategoryName;
            return null;
        }
        private void loadList()
        {
            List<AdvProductsInfo> list = ne.getList();
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
            AdvProductsInfo info = ne.getByID(id);
            if (info != null)
            {
                txtName.Text = info.AdvName;
                drlCategory.SelectedValue = info.CategoryID.ToString();
                lblPic.Text = info.FileName;
                txtWidth.Text = info.Width.ToString();
                txtHeight.Text = info.Height.ToString();

                if (info.FileName.IndexOf(".swf") > 0)
                {
                    Display = "none";
                    StringBuilder str = new StringBuilder();
                    str.Append("      <object classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\" codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\" width=\"" + info.Width + "\" height=\"" + info.Height + "\">");
                    str.Append("      <param name=\"movie\" value=\"../../resources/advproducts/" + info.FileName + "\" />");
                    str.Append("      <param name=\"quality\" value=\"high\" />");
                    str.Append("      <embed src=\"../../resources/advproducts/" + info.FileName + "\" quality=\"high\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\" width=\"" + info.Width + "\" height=\"" + info.Height + "\"></embed>");
                    str.Append("      </object>");

                    ltImgFlash.Text = str.ToString();
                }
                else
                {
                    Display = "inline";
                    imgpic.Src = "../../resources/advproducts/" + info.FileName;
                }
            }
        }
        protected void btnNew_Click(object sender, ImageClickEventArgs e)
        {
            paEdit.Visible = true;
            paList.Visible = false;
            loadCategory();
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
                int width = int.Parse(txtWidth.Text);
                int height = int.Parse(txtHeight.Text);
                string savePath = "/resources/advproducts/";
                string pic;
                int catid = int.Parse(drlCategory.SelectedValue);

                if (imgAdv.PostedFile.FileName == null || imgAdv.PostedFile.FileName.Length == 0)
                    pic = lblPic.Text;
                else pic = Util.GetFileUpload(savePath, imgAdv);

                AdvProductsInfo advinfo =
                        new AdvProductsInfo(1, catid, name, pic, width, height);
                string id = Request["id"];
                if (id == null)
                {
                    //them moi
                    bool kq = ne.insert(advinfo);
                    if (kq)
                        Response.Redirect("default.aspx?n=advproducts");
                    else
                        WebMsgBox.Show("Thêm mới không thành công. Vui lòng thử lại sau");
                }
                else
                {
                    advinfo.ID = int.Parse(id);
                    //cap nhat
                    bool kq = ne.update(advinfo);
                    if (kq)
                        Response.Redirect("default.aspx?n=advproducts");
                    else
                        WebMsgBox.Show("Cập nhật không thành công. Vui lòng thử lại sau");
                }
            }
        }

        protected void btnCancel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("default.aspx?n=advproducts");
        }
       

    }
}