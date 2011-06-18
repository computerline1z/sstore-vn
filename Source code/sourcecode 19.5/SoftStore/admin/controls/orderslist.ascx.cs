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
    public partial class orderslist : System.Web.UI.UserControl
    {
        Orders od=new Orders();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                UsersInfo user = UserLogin.GetUserLoging();
                if (user.GroupID != 0 && user.GroupID != 1)
                {
                    Response.Redirect("denied.aspx");
                }
                string id = Request["id"];
                if(id==null)
                {
                    loadList();
                }
                else
                {
                    paList.Visible = false;
                    paEdit.Visible = true;
                    OrderInfo info = od.GetByOrderID(id);
                    if(info!=null)
                    {
                        lblName.Text = info.CustomerName;
                        lblAddress.Text = info.CustomerAddress;
                        lblEmail.Text = info.CustomerEmail;
                        lblPhone.Text = info.CustomerPhone;
                        lblReceiveAddress.Text = info.ReceiveAddress;
                        lblDes.Text = info.Description;
                        lblTotal.Text = info.TotalPrice.ToString("#,##0");

                        ReceiveMethods r = new ReceiveMethods();
                        ReceiveMethodsInfo receivemethod = r.GetByID(info.ReceiveMethod.ToString());
                        if (receivemethod != null)
                        {
                            lblReceiveMethods.Text = receivemethod.MethodName;
                        }
                        PaymentMethods p = new PaymentMethods();
                        PaymentMethodsInfo paymethod = p.GetByID(info.PaymentMethod.ToString());
                        if (paymethod != null)
                        {
                            lblPaymentMethods.Text = paymethod.MethodName;
                        }

                        OrderDetail ode = new OrderDetail();
                        IList<OrderDetailInfo> ilist = ode.GetList(id);
                        if (ilist != null && ilist.Count != 0)
                        {
                            rptBasket.DataSource = ilist;
                            rptBasket.DataBind();
                        }
                    }
                }
            }
        }
        private void loadList()
        {
            List<OrderInfo> list = od.GetList();
            if (list != null && list.Count != 0)
            {
                rptList.DataSource = list;
                rptList.DataBind();
            }
        }

        protected void btnDone_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("default.aspx?n=orderslist");
        }

        private Products pr = new Products();

        public string getProduct(object id)
        {
            ProductsInfo info = pr.GetByID(id.ToString());
            if (info != null)
                return info.ProductName;
            return null;
        }

        protected void btnDel_Click(object sender, ImageClickEventArgs e)
        {
            string[] str = Request.Params.GetValues("select");
            if (str == null || str.Length == 0)
            {
                WebMsgBox.Show("Chọn đơn hàng cần xóa...");
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
                    bool ii = od.Delete(result);
                    if (ii)
                        Response.Redirect(Request.RawUrl);
                    else
                        WebMsgBox.Show("Xóa đơn hàng không thành công. Vui lòng thử lại sau");
                }
            }
        }
    }
}