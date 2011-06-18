using System;
using System.Collections.Generic;
using System.Web.UI;
using DataAccessLayer;
using BusinessObjects;
using SoftStore.App_Code;
using Utilities;

namespace SoftStore.admin.controls
{
    public partial class company : UserControl
    {
        Company com=new Company();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                UsersInfo user = UserLogin.GetUserLoging();
                if (user.GroupID == 3)
                {
                    Response.Redirect("denied.aspx");
                }
                getInfo();
            }
        }
        private bool getInfo()
        {
            CompanyInfo info = com.GetCompanyInfo();
            if (info != null)
            {
                txtName.Text = info.CompanyName;
                txtNameEn.Text = info.CompanyNameEn;
                txtAddress.Text = info.Address;
                txtPhone.Text = info.Phone;
                txtHotLine.Text = info.HotLine;
                txtFax.Text = info.Fax;
                txtEmail.Text = info.Email;
                txtWebsite.Text = info.Website;
                txtContent.Text = info.MoreContent;
                lblMap.Text = info.Map;
                imgpic.Src = "/resources/map/"+info.Map;
                return true;
            }
            else
                return false;
        }
        protected void btnOK_Click(object sender, ImageClickEventArgs e)
        {
            if(Page.IsValid)
            {
                CompanyInfo info=new CompanyInfo();
                info.CompanyName = txtName.Text;
                info.CompanyNameEn = txtNameEn.Text;
                info.Address = txtAddress.Text;
                info.Phone = txtPhone.Text;
                info.Fax = txtFax.Text;
                info.Email = txtEmail.Text;
                info.Website = txtWebsite.Text;
                info.HotLine = txtHotLine.Text;
                info.MoreContent = txtContent.Text;
                string savePath = "/resources/map/";
                string map;
                if (imgAdv.PostedFile.FileName == null || imgAdv.PostedFile.FileName.Length == 0)
                    map = lblMap.Text;
                else map = Util.GetFileUpload(savePath, imgAdv);
                info.Map = map;
                bool kq = com.Update(info);
                if (kq)
                    alertSuccess("Cập nhật thành công");
                else alert("Cập nhật thông tin không thành công. Vui lòng thử lại sau");
            }
        }

        private void alert(string str)
        {
            ClientScriptManager csm = Page.ClientScript;
            string js = "<script language=\"javascript\">alert('" + str + "');</script>";
            csm.RegisterStartupScript(Page.GetType(), "alert_js", js);
        }
        private void alertSuccess(string str)
        {
            ClientScriptManager csm = Page.ClientScript;
            string js = "<script language=\"javascript\">alert('" + str + "');location.replace('default.aspx?n=company');</script>";
            csm.RegisterStartupScript(Page.GetType(), "alert_js", js);
        }
    }
}