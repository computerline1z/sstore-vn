using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using BusinessObjects;
using SoftStore.App_Code;
using Utilities;

namespace SoftStore.controls
{
    public partial class shoppingcart : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.Title = "Giỏ hàng của bạn - " + PageTitle.GetPageTitle();
                string productid = Request["productid"];
                if (productid == null)//vao menu gio hang
                {
                    object yourcart = Session["YOURCART"];
                    if (yourcart != null)
                    {
                        List<CartInfo> list = (List<CartInfo>)yourcart;
                        rptBasket.DataSource = list;
                        rptBasket.DataBind();
                        lblTotal.Text = getTotalPrice(list).ToString("#,##0");
                    }
                }
                else
                {
                    string sPrice = Request["price"];
                    string sAmount = Request["sl"];
                    string sPackageID = Request["pk"];
                    int Amount;
                    long Price;
                    int PackageID;
                    try
                    {
                        Amount = int.Parse(sAmount);
                        Price = long.Parse(sPrice);
                        PackageID = int.Parse(sPackageID);
                        
                    }
                    catch
                    {
                        //default if error
                        Amount = 1;
                        Price = 0;
                        PackageID = 1;
                    }
                    AddItemToCart(productid, Amount, Price, PackageID);

                    //rptBasket.DataSource = list;
                    //rptBasket.DataBind();
                    //lblTotal.Text = getTotalPrice(list).ToString("#,##0");
                    Response.Redirect("/gio-hang.html");
                }
            }
        }
        private static long getTotalPrice(List<CartInfo> list)
        {
            long result = 0;
            for (int i = 0; i < list.Count; i++)
            {
                CartInfo cartinfo = list[i];
                result += cartinfo.Amount * cartinfo.Price;
            }
            return result;
        }

        private static CartInfo addItem(ProductsInfo product, long price, int amount, int packageID)
        {
            CartInfo cartinfo = new CartInfo();
            cartinfo.ProductID = product.ProductID;
            cartinfo.ProductName = product.ProductName;
            cartinfo.Amount = amount;
            cartinfo.Price = price;
            cartinfo.PackageID = packageID;
            return cartinfo;
        }
        public List<CartInfo> AddItemToCart(string productID, int amount, long price, int packageID)
        {
            Cart cart = null;
            Products pr = new Products();
            ProductsInfo info = pr.GetByID(productID);
            object yourcart = Session["YOURCART"];
            if (yourcart == null) //lan dau tien session chua co
            {
                if (info != null)
                {
                    CartInfo cartInfo = addItem(info, price, amount, packageID);
                    cart = new Cart();
                    cart.AddItemToCart(cartInfo);
                    Session["YOURCART"] = cart.ListCart;
                }
            }
            else //gio hang da ton tai
            {
                //neu san pham voi productID nay da co trong gio hang---->cap nhat sl san pham nay
                //neu san pham voi productID nay chua co trong gio hang-----> them moi vao gio hang
                cart = new Cart();
                cart.ListCart = (List<CartInfo>)yourcart;
                CartInfo cartInfo = cart.FindRecordInCart(cart.ListCart, productID);
                if (cartInfo == null) //san pham nay chua co trong gio hang--->them moi
                {
                    CartInfo cartAdd = addItem(info, price, amount, packageID);
                    cart.AddItemToCart(cartAdd);
                    Session["YOURCART"] = cart.ListCart;
                }
                else //san pham nay da co trong gio hang--->cap nhat soluong
                {
                    cartInfo.Amount = cartInfo.Amount + amount;
                    cart.UpdateCart(cart.Index, cartInfo);
                    Session["YOURCART"] = cart.ListCart;
                }
            }
            //return cart
            if (cart == null)
                return null;
            else return cart.ListCart;
        }
        protected void rptBasket_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            ImageButton control = (ImageButton)e.Item.FindControl("imgDelete");
            if (control != null)
            {
                ImageButton imgDelete = control;
                string productID = imgDelete.ToolTip;
                object yourCart = Session["YOURCART"];
                if (yourCart != null)
                {
                    Cart cart = new Cart();
                    cart.ListCart = (List<CartInfo>)yourCart;
                    List<CartInfo> list = (List<CartInfo>)yourCart;
                    CartInfo cartinfo = cart.FindRecordInCart(list, productID);
                    if (cartinfo != null)
                    {
                        list.RemoveAt(cart.Index);
                        Session["YOURCART"] = list;
                    }
                }
            }
            Response.Redirect("/gio-hang.html");
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            object yourCart = Session["YOURCART"];
            if (yourCart != null)
            {
                List<CartInfo> list = (List<CartInfo>)yourCart;
                Cart cart = new Cart();
                foreach (RepeaterItem item in rptBasket.Items)
                {

                    Label p_id = (Label)item.FindControl("p_id");
                    if (p_id != null)
                    {
                        string productID = p_id.Text;
                        TextBox amount = (TextBox)item.FindControl("txtAmount");

                        CartInfo cartInfo = cart.FindRecordInCart(list, productID);
                        if (cartInfo != null)
                        {
                            int _amount;
                            try
                            {
                                _amount = int.Parse(amount.Text);
                            }
                            catch
                            {
                                _amount = cartInfo.Amount;
                            }
                            cartInfo.Amount = _amount;
                            list[cart.Index] = cartInfo;
                        }
                    }
                }
                Response.Redirect("/gio-hang.html");

            }
        }
        protected void btnContinue_Click(object sender, EventArgs e)
        {
            Response.Redirect("/trang-chu.html");
        }
        protected void btnPayment_Click(object sender, EventArgs e)
        {
            Response.Redirect("/thanh-toan.html");
        }
    }
}