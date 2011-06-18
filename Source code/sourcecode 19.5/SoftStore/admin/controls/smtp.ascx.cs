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
    public partial class smtp : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                SMTPMail sm = new SMTPMail();
                SMTPMailInfo info = sm.GetInfo();
                if (info != null)
                {
                    txtSMTP.Text = info.SMTP;
                    txtMail.Text = info.MailAddress;
                    txtPassword.Attributes.Add("value", info.Password);
                }
            }
        }
        protected void btnOK_Click(object sender, ImageClickEventArgs e)
        {
            SMTPMail sm = new SMTPMail();
            SMTPMailInfo info =new SMTPMailInfo();
            info.SMTP = txtSMTP.Text;
            info.MailAddress = txtMail.Text;
            info.UserName = txtMail.Text;
            info.Password = txtPassword.Text;
            bool kq = sm.Update(info);
            if (kq)
                Response.Redirect("default.aspx?n=smtp");
            else
                WebMsgBox.Show("Cập nhật thông tin smtp không thành công. Vui lòng thử lại sau");

        }
    }
}