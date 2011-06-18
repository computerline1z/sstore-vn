using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BusinessObjects;
using DataAccessLayer;
using SoftStore.App_Code;

namespace SoftStore.controls
{
    public partial class paymentcart : System.Web.UI.UserControl
    {
        private MembersInfo member = MemberLogin.GetMemberLogin();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.Title = "Xác nhận đơn hàng - " + PageTitle.GetPageTitle();
                object yourcart = Session["YOURCART"];
                if (yourcart != null)
                {
                    Session["YOURCART"] = yourcart;
                    string step = Request["step"];
                    if (step != null)
                    {
                        ltCartNull.Text = null;
                        if (step == "1")
                        {
                            paStep1.Visible = true;
                            paStep2.Visible = false;
                            paStep3.Visible = false;
                            paStep4.Visible = false;

                            if (Session["OrderInfo"] != null)
                            {
                                OrderInfo info = (OrderInfo)Session["OrderInfo"];
                                txtCustomerName.Text = info.CustomerName;
                                txtAddress.Text = info.CustomerAddress;
                                txtEmail.Text = info.CustomerEmail;
                                txtPhone.Text = info.CustomerPhone;
                                txtReceiveAddress.Text = info.ReceiveAddress;
                                txtDescription.Text = info.Description;
                            }
                        }
                        else if (step == "2")
                        {
                            paStep1.Visible = false;
                            paStep2.Visible = true;
                            paStep3.Visible = false;
                            paStep4.Visible = false;

                            ReceiveMethods r = new ReceiveMethods();
                            List<ReceiveMethodsInfo> list = r.GetList();
                            if (list != null && list.Count != 0)
                            {
                                rptReceiveMethod.DataSource = list;
                                rptReceiveMethod.DataBind();
                            }
                        }
                        else if (step == "3")
                        {
                            paStep1.Visible = false;
                            paStep2.Visible = false;
                            paStep3.Visible = true;
                            paStep4.Visible = false;

                            PaymentMethods r = new PaymentMethods();
                            List<PaymentMethodsInfo> list = r.GetList();
                            if (list != null && list.Count != 0)
                            {
                                rptPaymentMethod.DataSource = list;
                                rptPaymentMethod.DataBind();
                            }
                        }
                        else if (step == "4")
                        {
                            paStep1.Visible = false;
                            paStep2.Visible = false;
                            paStep3.Visible = false;
                            paStep4.Visible = true;

                            //load Product
                            List<CartInfo> list = (List<CartInfo>)yourcart;
                            rptBasket.DataSource = list;
                            rptBasket.DataBind();
                            lblTotal.Text = getTotalPrice(list).ToString("#,##0");

                            //load customer info
                            if (Session["OrderInfo"] != null)
                            {
                                OrderInfo info = (OrderInfo)Session["OrderInfo"];
                                lblCustomerName.Text = info.CustomerName;
                                lblAddress.Text = info.CustomerAddress;
                                lblEmail.Text = info.CustomerEmail;
                                lblPhone.Text = info.CustomerPhone;
                                lblReceiveAddress.Text = info.ReceiveAddress;
                                lblDescription.Text = info.Description;
                                ReceiveMethods r = new ReceiveMethods();
                                ReceiveMethodsInfo receivemethod = r.GetByID(info.ReceiveMethod.ToString());
                                if (receivemethod != null)
                                {
                                    lblReceiveMethod.Text = receivemethod.MethodName;
                                }
                                PaymentMethods p = new PaymentMethods();
                                PaymentMethodsInfo paymethod = p.GetByID(info.PaymentMethod.ToString());
                                if (paymethod != null)
                                {
                                    lblPaymentMethod.Text = paymethod.MethodName;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (member != null)
                        {
                            txtCustomerName.Text = member.FullName;
                            txtAddress.Text = member.Address;
                            txtEmail.Text = member.Email;
                            txtPhone.Text = member.Phone;
                            txtReceiveAddress.Text = member.Address;
                        }
                    }
                }
                else
                {
                    paStep1.Visible = false;
                    paStep2.Visible = false;
                    paStep3.Visible = false;
                    paStep4.Visible = false;
                    ltCartNull.Text = "<div style=\"width:100%; padding:10px; text-align:center\">Giỏ hàng của bạn chưa có. Bạn hãy <a class=\"link1\" href=\"trang-chu.html\"><b>chọn mua</b></a> một sản phẩm trước</div>";
                }
            }
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            OrderInfo order = new OrderInfo();
            order.CustomerName = txtCustomerName.Text;
            order.CustomerAddress = txtAddress.Text;
            order.CustomerEmail = txtEmail.Text;
            order.CustomerPhone = txtPhone.Text;
            order.ReceiveAddress = txtReceiveAddress.Text;
            order.Description = txtDescription.Text;
            order.OrderDate = DateTime.Now;
            order.Status = false;
            order.ID = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss").Replace(" ", "-");
            Session["OrderInfo"] = order;
            Response.Redirect("/thanh-toan/step-2.html");
        }

        protected void btnBackToStep1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/thanh-toan/step-1.html");
        }

        protected void btnStep2Continue_Click(object sender, EventArgs e)
        {
            string[] str = Request.Params.GetValues("cbkReceiveMethod");
            if (str == null || str.Length == 0 || str.Length > 1)
            {
                WebMsgBox.Show("Vui lòng chọn một hình thức giao hàng");
            }
            else
            {
                if (Session["OrderInfo"] != null)
                {
                    OrderInfo info = (OrderInfo)Session["OrderInfo"];
                    info.ReceiveMethod = int.Parse(str[0]);
                    Session["OrderInfo"] = info;
                }
            }
            Response.Redirect("/thanh-toan/step-3.html");
        }

        protected void btnBacktoStep2_Click(object sender, EventArgs e)
        {
            Response.Redirect("/thanh-toan/step-2.html");
        }

        protected void btnStep3Continue_Click(object sender, EventArgs e)
        {
            string[] str = Request.Params.GetValues("cbkPaymentMethod");
            if (str == null || str.Length == 0 || str.Length > 1)
            {
                WebMsgBox.Show("Vui lòng chọn một hình thức thanh toán");
            }
            else
            {
                if (Session["OrderInfo"] != null)
                {
                    OrderInfo info = (OrderInfo)Session["OrderInfo"];
                    info.PaymentMethod = int.Parse(str[0]);
                    Session["OrderInfo"] = info;
                }
            }
            Response.Redirect("/thanh-toan/step-4.html");
        }

        protected void btnBackToStep3_Click(object sender, EventArgs e)
        {
            Response.Redirect("/thanh-toan/step-3.html");
        }

        protected void btnFinish_Click(object sender, EventArgs e)
        {
            if (Session["OrderInfo"] != null)
            {
                object yourcart = Session["YOURCART"];
                if (yourcart != null)
                {
                    OrderInfo info = (OrderInfo)Session["OrderInfo"];
                    List<CartInfo> list = (List<CartInfo>)yourcart;
                    List<OrderDetailInfo> listdetail = new List<OrderDetailInfo>();
                    long totalPrice = 0;
                    for (int i = 0; i < list.Count; i++)
                    {
                        totalPrice += list[i].Amount * list[i].Price;
                        listdetail.Add(new OrderDetailInfo(1, i, info.ID, list[i].ProductID, list[i].Amount, list[i].Price, list[i].PackageID));
                    }
                    info.TotalPrice = totalPrice;
                    Orders o = new Orders();
                    bool kq = o.Insert(info, listdetail);
                    if (kq)
                    {
                        Session["YOURCART"] = null;
                        Session["OrderInfo"] = null;
                        ClientScriptManager csm = Page.ClientScript;
                        string js = "<script language=\"javascript\">alert('Bạn đã đặt hàng thành công. Chúng tôi sẽ liên lạc với bạn để xác nhận trong thời gian sớm nhất. Xin cảm ơn');window.location.href=\"/trang-chu.html\";</script>";
                        csm.RegisterStartupScript(Page.GetType(), "Found", js);
                    }
                    else
                    {
                        WebMsgBox.Show("Có lỗi xảy ra trong quá trình đặt hàng. Quý khách vui lòng thử lại sau");
                    }
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

        protected void btnEditCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("/gio-hang.html");
        }
    }
}