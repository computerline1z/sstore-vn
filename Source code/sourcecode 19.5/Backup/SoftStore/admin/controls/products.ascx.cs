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
    public partial class products : System.Web.UI.UserControl
    {
        Products pr = new Products();
        ProductCategory cat=new ProductCategory();
        List<ProductCategoryInfo> list_ds = new List<ProductCategoryInfo>();
        ProductSupplier sup=new ProductSupplier();
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
                if (user.GroupID==3)
                {
                    //an quyen publish+delete
                    btnPublished.Visible = false;
                    btnDel.Visible = false;
                    rdbIsPublishN.Checked = true;
                    rdbPublishY.Enabled = false;
                }
                Display = "none";
                txtUpdateDate.Value = DateTime.Now.ToString("dd/MM/yyyy");
                txtReleaseDate.Value = DateTime.Now.ToString("dd/MM/yyyy");
                string id = Request["id"];
                if (id == null)
                {
                    loadListProducts();
                }
                else
                {
                    list_ds.Add(new ProductCategoryInfo(0, 0, "[Root Category]", 0, true, DateTime.Now, 0));
                    loadPackage();
                    loadCategory(0, 0);
                    loadSupplier();
                    LoadInfo(id);
                }
            }
        }
        private void loadCategory(int parentID, int level)
        {
            List<ProductCategoryInfo> list = cat.GetList(parentID);
            if (list != null && list.Count != 0)
            {
                string preStr = "";
                for (int j = 0; j < level; j++)
                {
                    preStr += "----";
                }
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].CategoryName = preStr + list[i].CategoryName;
                    list_ds.Add(list[i]);
                    int new_level = level + 1;
                    loadCategory(list[i].CategoryID, new_level);
                }
            }
            drlCategory.DataSource = list_ds;
            drlCategory.DataTextField = "CategoryName";
            drlCategory.DataValueField = "CategoryID";
            drlCategory.DataBind();
        }
        private void loadSupplier()
        {
            List<ProductSupplierInfo> list = sup.GetList(true);
            if(list!=null)
            {
                drlSupplierID.DataSource = list;
                drlSupplierID.DataTextField = "SupplierName";
                drlSupplierID.DataValueField = "SupplierID";
                drlSupplierID.DataBind();
            }
        }
        private void loadPackage()
        {
            Package p=new Package();
            List<PackageInfo> list = p.GetList(true);
            if (list != null)
            {
                drlProdcuctPack.DataSource = list;
                drlProdcuctPack.DataTextField = "PackageName";
                drlProdcuctPack.DataValueField = "PackageID";
                drlProdcuctPack.DataBind();

                drlProdcuctPack.SelectedIndex = 0;
            }
        }
        private void setPackage(string ProductID)
        {
            ProductPackages p = new ProductPackages();
            List<ProductPackagesInfo> list = p.GetByProductID(ProductID);
            if (list != null)
            {
                foreach (ListItem item in drlProdcuctPack.Items)
                {
                    for(int i=0; i<list.Count; i++)
                    {
                        if (list[i].PackageID.ToString() == item.Value)
                            item.Selected = true;
                    }
                } 
            }
        }
        private void loadListProducts()
        {
            IList<ProductsInfo> list = pr.GetListProducts();
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
        private void LoadInfo(string id)
        {
            paList.Visible = false;
            paEdit.Visible = true;
            ProductsInfo info = pr.GetByID(id);
            if (info != null)
            {
                drlCategory.SelectedValue = info.CategoryID.ToString();
                drlSupplierID.SelectedValue = info.SupplierID.ToString();
                //drlPackage.SelectedValue = info.PackageID.ToString();
                txtPromotionRate.Text = info.PromotionRate.ToString();

                txtProductID.Text = info.ProductID;
                txtProductName.Text = info.ProductName;
                txtVersion.Text = info.Version;
                txtPrice.Text = info.Price.ToString();
                txtLinkDownload.Text = info.LinkDownload;
                txtTags.Text = info.Tags;
                txtDetailDescription.Text = info.DetailDescription;
                txtTechDescription.Text = info.TechDescription;
                txtKeywordsContent.Text = info.ShortDescription;

                txtReleaseDate.Value = info.ReleaseDate.ToString("dd/MM/yyyy");
                txtUpdateDate.Value = info.UpdateDate.ToString("dd/MM/yyyy");

                if (info.IsPublish)
                {
                    rdbPublishY.Checked = true;
                    rdbIsPublishN.Checked = false;
                }

                if (info.Status)
                {
                    rdbStatusYes.Checked = true;
                    rdbStatusNo.Checked = false;
                }

                if (info.IsBestSale)
                    cbkIsBestSale.Checked = true;

                if (info.IsHot)//phan mem tot nhat
                    cbkIsBest.Checked = true;

                if (info.IsNew)//dung lam khuyen mai
                    cbkKM.Checked = true;

                lblPic.Text = info.Picture;
                if (info.Picture == null || info.Picture.Length == 0)
                    Display = "none";
                else
                {
                    Display = "inline";
                    imgpic.Src = "../../resources/products/" + info.ProductID + "/" + info.Picture;
                }

                setPackage(info.ProductID);
            }
        }
        protected void btnNew_Click(object sender, ImageClickEventArgs e)
        {
            paEdit.Visible = true;
            paList.Visible = false;
            list_ds.Add(new ProductCategoryInfo(0, 0, "[Root Category]", 0, true, DateTime.Now, 0));
            loadCategory(0, 0);
            loadSupplier();
            loadPackage();
        }
        protected void btnDel_Click(object sender, ImageClickEventArgs e)
        {
            string[] str = Request.Params.GetValues("select");
            if (str == null || str.Length == 0)
            {
                WebMsgBox.Show("Chọn sản phẩm cần xóa...");
            }
            else
            {
                int size = str.Length;
                string result = null;
                for (int i = 0; i < size; i++)
                {
                    if (i == size - 1)
                        result += "'" + str[i] + "'";
                    else result += "'" + str[i] + "',";
                }

                if (result != null)
                {
                    bool ii = pr.Delete(result);
                    if (ii)
                        Response.Redirect(Request.RawUrl);
                    else
                        WebMsgBox.Show("Xóa sản phẩm không thành công. Vui lòng thử lại sau");
                }
            }
        }
        protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid)
            {
                ProductsInfo info=new ProductsInfo();
                info.ProductID = txtProductID.Text;
                info.CategoryID = int.Parse(drlCategory.SelectedValue);
                info.SupplierID = int.Parse(drlSupplierID.SelectedValue);
                info.PackageID = 0;// int.Parse(drlPackage.SelectedValue);
                info.PromotionRate = int.Parse(txtPromotionRate.Text.Trim());

                info.ProductName = txtProductName.Text;
                info.DetailDescription = txtDetailDescription.Text;
                info.TechDescription = txtTechDescription.Text;
                info.ShortDescription = txtKeywordsContent.Text;

                bool ispublish = false;
                if (rdbPublishY.Checked)
                    ispublish = true;
                info.IsPublish = ispublish;

                info.Version = txtVersion.Text;
                info.Tags = txtTags.Text;
                info.LinkDownload = txtLinkDownload.Text;
                if (txtReleaseDate.Value.Length != 0)
                    info.ReleaseDate = DateTime.Parse(Util.FormatDayTime(txtReleaseDate.Value, "mm/dd/yyyy"));
                else info.ReleaseDate = DateTime.Now;
                if (txtUpdateDate.Value.Length != 0)
                    info.UpdateDate = DateTime.Parse(Util.FormatDayTime(txtUpdateDate.Value, "mm/dd/yyyy"));// txtUpdateDate.SelectedValue;
                else info.UpdateDate = DateTime.Now;

                info.Price = long.Parse(txtPrice.Text.Trim().Replace(".","").Replace(",",""));

                string savePath = "/resources/products/" + info.ProductID + "/";
                FileUtility.CreateFolder(savePath);
                string pic;

                bool IsHot = false;
                if (cbkIsBest.Checked)
                    IsHot = true;
                info.IsHot = IsHot;

                bool IsBestSale = false;
                if (cbkIsBestSale.Checked)
                    IsBestSale = true;
                info.IsBestSale = IsBestSale;

                bool IsKM = false;
                if (cbkKM.Checked)
                    IsKM = true;
                info.IsNew = IsKM;

                bool Status = true;
                if (rdbStatusNo.Checked)
                    Status = false;
                info.Status = Status;

                if (imgAdv.PostedFile.FileName == null || imgAdv.PostedFile.FileName.Length == 0)
                    pic = lblPic.Text;
                else pic = Util.GetFileUpload(savePath, imgAdv);
                info.Picture = pic;

                info.CreatedDate = DateTime.Now;
                
                info.PublishedDate = DateTime.Now;
                
                if(user!=null)
                {
                    info.CreatedBy = user.ID;
                    info.PublishedBy = user.ID;
                }
                else
                {
                    info.CreatedBy = info.PublishedBy = 1;
                }


                string id = Request["id"];
                if (id == null)
                {
                    if (pr.CheckExistsProductID(info.ProductID))
                    {
                        WebMsgBox.Show("Mã sản phẩm này đã tồn tại");
                    }
                    else
                    {
                        //get packages
                        List<ProductPackagesInfo> listpackages=new List<ProductPackagesInfo>();
                        foreach (ListItem item in drlProdcuctPack.Items)
                        {
                            if(item.Selected)
                            {
                                ProductPackagesInfo itemInfo = new ProductPackagesInfo();
                                itemInfo.ProductID = info.ProductID;
                                itemInfo.PackageID = int.Parse(item.Value);
                                listpackages.Add(itemInfo);
                            }
                        } 
                        bool kq;
                        if (user.GroupID == 3)
                        {
                            kq = pr.Insert(info, listpackages);
                        }
                        else
                        {
                            kq = pr.InsertAdmin(info, listpackages);
                        }
                        //them moi

                        if (kq)
                            Response.Redirect("default.aspx?n=products");
                        else
                            WebMsgBox.Show("Thêm mới sản phẩm không thành công. Vui lòng thử lại sau");
                    }
                }
                else
                {
                    info.ProductID = id;

                    //get packages
                    List<ProductPackagesInfo> listpackages = new List<ProductPackagesInfo>();
                    foreach (ListItem item in drlProdcuctPack.Items)
                    {
                        if (item.Selected)
                        {
                            ProductPackagesInfo itemInfo = new ProductPackagesInfo();
                            itemInfo.ProductID = info.ProductID;
                            itemInfo.PackageID = int.Parse(item.Value);
                            listpackages.Add(itemInfo);
                        }
                    } 

                    //cap nhat
                    bool kq;
                    if (user.GroupID == 3)
                    {
                        kq = pr.Update(info, listpackages);
                    }
                    else
                    {
                        kq = pr.UpdateAdmin(info, listpackages);
                    }
                    if (kq)
                        Response.Redirect("default.aspx?n=products");
                    else
                        WebMsgBox.Show("Cập nhật sản phẩm không thành công. Vui lòng thử lại sau");
                }
            }
        }
        protected void btnCancel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("default.aspx?n=products");
        }
        
        protected void btnPublished_Click(object sender, ImageClickEventArgs e)
        {
            string publish = null;
            string unpublish = null;
            foreach( RepeaterItem item in rptList.Items)
            {
                Label lblProductID = (Label)item.FindControl("lblProductID");
                CheckBox cbkIsPublished = (CheckBox) item.FindControl("cbkIsPublished");
                if(cbkIsPublished.Checked)
                {
                    publish += "'" + lblProductID.Text + "',";
                }
                else unpublish += "'" + lblProductID.Text + "',";
            }
            bool ii=false;
            if(publish!=null)
            {
                publish = publish.Substring(0, publish.Length - 1);
                ii = pr.UpdateStatus(publish, "IsPublish", true);
            }
            if (unpublish != null)
            {
                unpublish = unpublish.Substring(0, unpublish.Length - 1);
                ii = pr.UpdateStatus(unpublish, "IsPublish", false);
            }
            if (ii)
                Response.Redirect(Request.RawUrl);
            else
                WebMsgBox.Show("Publish sản phẩm không thành công. Vui lòng thử lại sau");
        }

        protected void btnSetNew_Click(object sender, ImageClickEventArgs e)
        {
            string publish = null;
            string unpublish = null;
            foreach (RepeaterItem item in rptList.Items)
            {
                Label lblProductID = (Label)item.FindControl("lblProductID");
                CheckBox cbkIsSetNew = (CheckBox)item.FindControl("cbkIsSetNew");
                if (cbkIsSetNew.Checked)
                {
                    publish += "'" + lblProductID.Text + "',";
                }
                else unpublish += "'" + lblProductID.Text + "',";
            }
            bool ii = false;
            if (publish != null)
            {
                publish = publish.Substring(0, publish.Length - 1);
                ii = pr.UpdateStatus(publish, "IsNew", true);
            }
            if (unpublish != null)
            {
                unpublish = unpublish.Substring(0, unpublish.Length - 1);
                ii = pr.UpdateStatus(unpublish, "IsNew", false);
            }
            if (ii)
                Response.Redirect(Request.RawUrl);
            else
                WebMsgBox.Show("Chuyển sản phẩm mới không thành công. Vui lòng thử lại sau");
        }

        protected void btnSetHot_Click(object sender, ImageClickEventArgs e)
        {
            string publish = null;
            string unpublish = null;
            foreach (RepeaterItem item in rptList.Items)
            {
                Label lblProductID = (Label)item.FindControl("lblProductID");
                CheckBox cbkIsSetHot = (CheckBox)item.FindControl("cbkIsSetHot");
                if (cbkIsSetHot.Checked)
                {
                    publish += "'" + lblProductID.Text + "',";
                }
                else unpublish += "'" + lblProductID.Text + "',";
            }
            bool ii = false;
            if (publish != null)
            {
                publish = publish.Substring(0, publish.Length - 1);
                ii = pr.UpdateStatus(publish, "IsHot", true);
            }
            if (unpublish != null)
            {
                unpublish = unpublish.Substring(0, unpublish.Length - 1);
                ii = pr.UpdateStatus(unpublish, "IsHot", false);
            }
            if (ii)
                Response.Redirect(Request.RawUrl);
            else
                WebMsgBox.Show("Chuyển sản phẩm hot không thành công. Vui lòng thử lại sau");
        }

        protected void btnSetBig_Click(object sender, ImageClickEventArgs e)
        {
            string publish = null;
            string unpublish = null;
            foreach (RepeaterItem item in rptList.Items)
            {
                Label lblProductID = (Label)item.FindControl("lblProductID");
                CheckBox cbkIsSetBigSale = (CheckBox)item.FindControl("cbkIsSetBigSale");
                if (cbkIsSetBigSale.Checked)
                {
                    publish += "'" + lblProductID.Text + "',";
                }
                else unpublish += "'" + lblProductID.Text + "',";
            }
            bool ii = false;
            if (publish != null)
            {
                publish = publish.Substring(0, publish.Length - 1);
                ii = pr.UpdateStatus(publish, "IsBigSale", true);
            }
            if (unpublish != null)
            {
                unpublish = unpublish.Substring(0, unpublish.Length - 1);
                ii = pr.UpdateStatus(unpublish, "IsBigSale", false);
            }
            if (ii)
                Response.Redirect(Request.RawUrl);
            else
                WebMsgBox.Show("Chuyển sản phẩm khuyến mãi không thành công. Vui lòng thử lại sau");
        }

        public string GetSupplier(object SupplierID)
        {
            ProductSupplierInfo info = sup.GetByID(int.Parse(SupplierID.ToString()));
            if (info != null)
                return info.SupplierName;
            return null;
        }
        public string GetStatus(object StatusID)
        {
            if (bool.Parse(StatusID.ToString()))
                return "Còn hàng";
            return "Hết hàng";
        }
    }
}