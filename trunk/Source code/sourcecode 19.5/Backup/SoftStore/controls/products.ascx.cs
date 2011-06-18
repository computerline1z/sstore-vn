using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using DataAccessLayer;
using BusinessObjects;
using SoftStore.App_Code;
using Utilities;

namespace SoftStore.controls
{
    public partial class products : System.Web.UI.UserControl
    {
        ProductCategory cat = new ProductCategory();
        Products pr=new Products();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string ProductCategoryID = Request["ProductCategoryID"];
                if (ProductCategoryID != null)
                {
                    LoadProduct(ProductCategoryID, "p.Price ASC");
                }
            }
        }
        private void LoadProduct(string ProductCategoryID, string orderby)
        {
            List<ProductsInfo> list = pr.GetListProductsByCatID(int.Parse(ProductCategoryID), orderby);
            if (list != null && list.Count != 0)
            {
                rptList.DataSource = list;
                rptList.DataBind();

                ProductCategoryInfo item = cat.GetByID(int.Parse(ProductCategoryID));
                if (item != null)
                {
                    ltCategoryName.Text = item.CategoryName;
                }
            }
        }
        protected void drlOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ProductCategoryID = Request["ProductCategoryID"];
            if (ProductCategoryID != null)
            {
                if (drlOrder.SelectedValue == "0" )
                    LoadProduct(ProductCategoryID, "p.Price ASC");
                if (drlOrder.SelectedValue == "1")
                    LoadProduct(ProductCategoryID, "p.Price DESC");
                if (drlOrder.SelectedValue == "2")
                    LoadProduct(ProductCategoryID, "p.ProductName ASC");
                if (drlOrder.SelectedValue == "3")
                    LoadProduct(ProductCategoryID, "p.Price ASC");
            }
        }
        public string getPromotion(object _price, object _rate)
        {
            try
            {
                float rate = long.Parse(_rate.ToString());
                if (rate!=0)
                {
                    long price = long.Parse(_price.ToString());
                    return "Bạn được tặng: &nbsp;<span class=\"price\">" + ((price * rate) / 100).ToString("#,##0") + "(" + rate + "%)</span>";
                } 
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}