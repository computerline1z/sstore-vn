using System;
using System.Collections.Generic;
using System.Web.UI;
using DataAccessLayer;
using BusinessObjects;
using SoftStore.App_Code;
using Utilities;

namespace SoftStore.controls
{
    public partial class contact : System.Web.UI.UserControl
    {
        public string email = null;
        public string website = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.Title = "Liên hệ - " + PageTitle.GetPageTitle();
                Company co = new Company();
                CompanyInfo info = co.GetCompanyInfo();
                if (info != null)
                {
                    ltCompany.Text = info.CompanyName;
                    ltAddress.Text = info.Address;
                    ltPhone.Text = info.Phone;
                    ltHotMail.Text = info.HotLine;
                    ltFax.Text = info.Fax;
                    generateEmail(info.Email);
                    generateWebsite(info.Website);
                    email = info.Email;
                    website = info.Website;
                    //ltMoreContent.Text = info.MoreContent;
                    //ltMap.Text = "<img src=\"/resources/map/" + info.Map + "\" />";
                }
            }
        }
        private void generateEmail(string emailaddress)
        {
            string result = null;
            string[] str = emailaddress.Trim().Split(new char[] { ';' });
            for (int i = 0; i < str.Length; i++)
            {
                if (i == str.Length - 1)
                    result += "<a href=\"mailto:" + str[i] + "\">" + str[i] + "</a>";
                else result += "<a href=\"mailto:" + str[i] + "\">" + str[i] + "</a> - ";
            }
            ltEmail.Text = result;
        }
        private void generateWebsite(string web)
        {
            string result = null;
            string[] str = web.Trim().Split(new char[] { ';' });
            for (int i = 0; i < str.Length; i++)
            {
                if (i == str.Length - 1)
                    result += "<a href=\"http://" + str[i] + "\">" + str[i] + "</a>";
                else result += "<a href=\"http://" + str[i] + "\">" + str[i] + "</a> - ";
            }
            ltWebsite.Text = result;
        }
        protected void btnSend_Click(object sender, EventArgs e)
        {
            Feedback fb = new Feedback();
            FeedbackInfo fi = new FeedbackInfo();
            fi.FullName = txtFullName.Text;
            //fi.Company = txtCompanyName.Text;
            fi.Address = txtAddress.Text;
            fi.Phone = txtPhone.Text;
            fi.Fax = txtFax.Text;
            fi.Email = txtEmail.Text;
            fi.Content = txtContent.Text;
            fi.StatusID = false;
            fi.CreatedDate = DateTime.Now;
            fi.Mobile = null;
            bool ii = fb.Insert(fi);
            if (ii)
            {
                SMTPMail sm = new SMTPMail();
                SMTPMailInfo smtp = sm.GetInfo();
                if (smtp != null)
                {
                    string content = "Họ tên: " + fi.FullName + "<br/>";
                    content += "Địa chỉ: " + fi.Address + "<br/>";
                    content += "Điện thoại: " + fi.Phone + "<br/>";
                    content += "Fax: " + fi.Fax + "<br/>";
                    content += "Email: " + fi.Email + "<br/>";
                    content += "Ngày gửi: " + fi.CreatedDate + "<br/>";
                    content += "Nội dung liên hệ: " + fi.Content + "<br/>";

                    Email.SendEmail(smtp.SMTP, smtp.MailAddress, smtp.UserName, smtp.Password, smtp.MailAddress
                                    , "Email khách hàng liên hệ từ softstore"
                                    , content);
                }
                ClientScriptManager csm = Page.ClientScript;
                string js = "<script language=\"javascript\">alert('Chúng tôi đã nhận được thông tin của quý khách. Xin cảm ơn');window.location.href=\"/trang-chu.html\";</script>";
                csm.RegisterStartupScript(Page.GetType(), "Found", js);
            }
            else
            {
                WebMsgBox.Show("Có lỗi xảy ra trong quá trình gửi liên hệ. Quý khách vui lòng thử lại sau");
            }
        }
    }
}