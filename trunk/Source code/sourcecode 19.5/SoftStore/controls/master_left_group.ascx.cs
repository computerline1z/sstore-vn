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
    public partial class master_left_group : System.Web.UI.UserControl
    {
        Products pr = new Products();
        ProductCategory cat = new ProductCategory();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Request.RawUrl.IndexOf("san-pham") > 0)
                {
                    ProductsInfo item = pr.GetByID(Request["id"]);
                    if (item != null)
                    {
                        LoadProductByCategory(item.CategoryID, Request["id"]);
                    }
                }
                else
                {
                    string ProductCategoryID = Request["id"];
                    if (ProductCategoryID != null)
                    {
                          try{
                              int categoryID = int.Parse(ProductCategoryID);
                              loadCategory(categoryID);
                          }catch(Exception em){
                              Logger.Log.error("get category error:" + em.Message);
                              loadCategory();
                          }
                    }
                    else
                    {
                        loadCategory();
                    }
                }
                     
            }
        }
        private void loadCategory()
        {
            List<ProductCategoryInfo> list = cat.GetList(0);
            if (list != null && list.Count != 0)
            {
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < list.Count; i++)
                {
                    builder.Append("<li>\n");
                    builder.Append("    <h2>" + list[i].CategoryName + "</h2>\n");
                    builder.Append("    <ul>\n");
                    List<ProductCategoryInfo> sub_list = cat.GetList(list[i].CategoryID);
                    ProductCategory pc = new ProductCategory();
                    String categoryPath = "";
                    categoryPath = pc.GetCategoryPathWithUrlFriendly(list[i].CategoryID);
                    if (sub_list != null && sub_list.Count != 0)
                    {
                        for (int j = 0; j < sub_list.Count; j++)
                        {
                           
                            builder.Append("        <li><a href=\"");
                            builder.Append(categoryPath);
                            builder.Append("/" + sub_list[j].CategoryID + "/" +
                                               FriendlyURL.ConvertUrlFriendlyNoExt(sub_list[j].CategoryName) + ".html\">" +
                                               sub_list[j].CategoryName + "</a></li>\n");
                        }
                    }
                    builder.Append("    </ul>\n");
                    builder.Append("</li>\n");
                }
                ltMenuLeft.Text = builder.ToString();
            }
            
        }
        private void loadCategory(int CategoryID)
        {
            ProductCategoryInfo item = cat.GetByID(CategoryID);
            if (item != null)
            {
                
                List<ProductCategoryInfo> sub_list = cat.GetList(item.CategoryID);
                if (sub_list != null && sub_list.Count != 0)
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append("<li>\n");
                    builder.Append("    <h2>" + item.CategoryName + "</h2>\n");
                    builder.Append("    <ul>\n");
                    ProductCategory pc = new ProductCategory();
                    String categoryPath = "";
                    categoryPath = pc.GetCategoryPathWithUrlFriendly(CategoryID);
                    for (int j = 0; j < sub_list.Count; j++)
                    {
                        builder.Append("        <li><a href=\"");
                        builder.Append(categoryPath);
                        builder.Append("/" + sub_list[j].CategoryID + "/" +
                                           FriendlyURL.ConvertUrlFriendlyNoExt(sub_list[j].CategoryName) + ".html\">" +
                                           sub_list[j].CategoryName + "</a></li>\n");
                    }
                    builder.Append("    </ul>\n");
                    builder.Append("</li>\n");
                    ltMenuLeft.Text = builder.ToString();
                }
                else
                {
                    //goi lai menu default
                    loadCategory();
                }
                
            }

        }
        /// <summary>
        /// Phan mem cung loai
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <param name="ProductID"></param>
        private void LoadProductByCategory(int CategoryID,string ProductID)
        {
            List<ProductsInfo> list = pr.GetTopProductsByCatID(CategoryID, ProductID);
            if (list != null && list.Count != 0)
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("<li>");
                builder.Append("<h2>SẢN PHẨM CÙNG LOẠI</h2>");
                builder.Append("<ul>");
                String categoryPath = "";
                ProductCategory pc = new ProductCategory();
                foreach(ProductsInfo item in list)
                {
                    categoryPath = pc.GetCategoryPathWithUrlFriendly(CategoryID);
                    builder.Append("<li>");
                    builder.Append("	<div class=\"same-product-item\">");
                    builder.Append("<a title=\"" + item.ProductName + "\" href=\"");
                    builder.Append(categoryPath);
                    builder.Append("/san-pham/"  + item.ProductID + "/" +
                                                   FriendlyURL.ConvertUrlFriendlyNoExt(item.ProductName) + ".html\"><img src=\"/resources/products/" + item.ProductID +
                                                   "/" + item.Picture + "\" width='80px'/></a>");

                    builder.Append("    <div class=\"title\"><a href=\"");
                    builder.Append(categoryPath);
                     builder.Append("/san-pham/" + item.ProductID + "/" +
                                                   FriendlyURL.ConvertUrlFriendlyNoExt(item.ProductName) + ".html\">" + Util.SplitString(item.ProductName, 25) + "</a></div>");
                    builder.Append("    <div><b>Giá: </b><span class=\"price\">"+item.Price.ToString("#,##0")+"</span></div>");
                    if (item.PromotionRate != 0)
                    {
                        builder.Append("    <div><b>Off: </b><span class=\"price\">" +
                                       (item.Price*item.PromotionRate/100).ToString("#,##0") + "</span></div>");
                    }
                    builder.Append("    <div class=\"link\"><a href=\"");
                    builder.Append(categoryPath);
                    builder.Append("/san-pham/" + item.ProductID + "/" +
                                                   FriendlyURL.ConvertUrlFriendlyNoExt(item.ProductName) + ".html\">chi tiết</a></div>");
                    builder.Append("    </div>");
                    builder.Append("</li>");
                }

                builder.Append("<li>");
                builder.Append("    <div class=\"link\"><a href=\"/" + CategoryID + "/viewall.html\">Xem tất cả</a></div>");
                builder.Append("</li>");
                builder.Append("</ul>");
                builder.Append("</li>");
                ltMenuLeft.Text = builder.ToString();
            }           
        }

    }
}