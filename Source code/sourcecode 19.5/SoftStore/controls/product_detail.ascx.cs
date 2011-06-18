using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using DataAccessLayer;
using BusinessObjects;
using SoftStore.App_Code;
using Utilities;
namespace SoftStore.controls
{
    public partial class product_detail : System.Web.UI.UserControl
    {
        Products pr = new Products();
        public string productName;
        public long price;
        public string str_linkdownload = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            string url = Request.RawUrl;
            string id = Request["id"];
            //Redirect to new URL type
            if (url.Contains("chi-tiet-sp") && id != null)
            {
                StringBuilder builder = new StringBuilder();
                ProductCategory pc = new ProductCategory();
                ProductsInfo item = pr.GetByID(id);
                builder.Append(pc.GetCategoryPathWithUrlFriendly(item.CategoryID));
                builder.Append("/san-pham/" + id + "/" + FriendlyURL.ConvertUrlFriendlyNoExt(item.ProductName) + ".html");
                Response.Redirect(builder.ToString());
            }
            if (!IsPostBack)
            {
                if (id != null)
                {
                    ProductsInfo item = pr.GetByID(id);
                    if(item!=null)
                    {
                        productName = FriendlyURL.ConvertUrlFriendlyNoExt(item.ProductName);
                        price = item.Price;
                        Page.Title = item.ProductName + " - " + PageTitle.GetPageTitle();
                        PageTitle.AddKeywords(this.Page, item.Tags + " - " + Page.Title);
                        PageTitle.AddDecriptions(this.Page, item.ShortDescription);

                        //package
                        loadPackage(id);
                        
                        ltProductName.Text = item.ProductName;
                        ltPrice.Text = item.Price.ToString("#,##0");
                        ltDetailDes.Text = item.DetailDescription;
                        ltTechDes.Text = item.TechDescription;
                        //if(item.PromotionRate!=0)
                        //{
                        //    ltSaleOff.Text = " <span class=\"bold\">Bạn được tặng: <span class=\"promotion\">" + (item.Price * item.PromotionRate / 100).ToString("#,##0")
                        //                     + "(" + item.PromotionRate + "%)</span>VNĐ</span> vào tài khoản để sử dụng"
                        //                     + "trong lần tiếp theo khi mua hàng tại SStore (Chỉ áp dụng cho <a href=\"/dang-ky.html\""
                        //                     + "class=\"link\">thành viên</a> của SStore).";
                        //}
                        if (item.LinkDownload != null && item.LinkDownload!="")
                        {
                            ltLinkDownload.Text = "<li><input type=\"button\" id=\"download-btn\" onclick=\"javascript:window.open('" + item.LinkDownload + "','_blank')\" class=\"gray-button\" value=\"DOWNLOAD\" /></li>";
                        }
                        ltPic.Text = "<img src=\"/resources/products/" + item.ProductID + "/" + item.Picture + "\" class=\"detail-img\"/>";
                        
                        string[] tag = item.Tags.Split(',');
                        string tags = null;
                        for (int i = 0; i < tag.Length; i++ )
                        {
                            tags += "<a href=\"/tag/" + tag[i].Trim().Replace(" ","+") + ".html\" class=\"italic\" style=\"font-style: italic\">" + tag[i] + "</a>";
                        }
                        ltTags.Text = tags;

                        //load comments
                        ProductComments pc=new ProductComments();
                        List<ProductCommentsInfo> listcomment = pc.GetListProductCommentsPublished(id);
                        if(listcomment!=null&&listcomment.Count!=0)
                        {
                            ltCountComments.Text = listcomment.Count.ToString();
                            Session["ProductComments"] = listcomment;
                        }
                        else
                        {
                            Session.Remove("ProductComments");
                            ltCountComments.Text = "0";
                        }
                    }
                }
            }
        }
        private void loadPackage(string id)
        {
            ProductPackages p = new ProductPackages();
            List<ProductPackagesInfo> list = p.GetPackageByProductID(id);
            if (list != null)
            {
                drlPackages.DataSource = list;
                drlPackages.DataTextField = "PackageName";
                drlPackages.DataValueField = "PackageID";
                drlPackages.DataBind();
            }
        }
    }
}