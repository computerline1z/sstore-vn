using System;
using System.Collections.Generic;
using System.Web.UI;
using DataAccessLayer;
using BusinessObjects;
using SoftStore.App_Code;
using Utilities;

namespace SoftStore.controls
{
    public partial class request : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            RequestSoft rq = new RequestSoft();
            RequestSoftInfo item = new RequestSoftInfo();
            item.FullName = txtFullName.Text;
            item.Company = txtCompany.Text;
            item.Phone = txtPhone.Text;
            item.Email = txtEmail.Text;
            item.Content = txtCN.Text;
            item.StatusID = false;
            item.RequestDate = DateTime.Now;
            item.SoftTitle = txtSoft.Text;
            bool ii = rq.Insert(item);
            if (ii)
            {
                SMTPMail sm = new SMTPMail();
                SMTPMailInfo smtp = sm.GetInfo();
                if (smtp != null)
                {
                    string content = "Họ tên: " + item.FullName + "<br/>";
                    content += "Company: " + item.Company + "<br/>";
                    content += "Điện thoại: " + item.Phone + "<br/>";

                    content += "Email: " + item.Email + "<br/>";
                    content += "Ngày gửi: " + item.RequestDate + "<br/>";
                    content += "Soft Title: " + item.SoftTitle + "<br/>";
                    content += "Description: " + item.Content + "<br/>";

                    Email.SendEmail(smtp.SMTP, smtp.MailAddress, smtp.UserName, smtp.Password, smtp.MailAddress
                                    , "Email request soft"
                                    , content);
                }
                ClientScriptManager csm = Page.ClientScript;
                string js = "<script language=\"javascript\">alert('Chúng tôi đã nhận được thông tin của quý khách. Xin cảm ơn');window.location.href=\"/trang-chu.html\";</script>";
                csm.RegisterStartupScript(Page.GetType(), "Found", js);
            }
            else
            {
                WebMsgBox.Show("Có lỗi xảy ra trong quá trình gửi yêu cầu. Quý khách vui lòng thử lại sau");
            }
        }
    }
}