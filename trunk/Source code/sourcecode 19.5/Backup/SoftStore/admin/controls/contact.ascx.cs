using System;
using System.Collections.Generic;
using System.Web.UI;
using DataAccessLayer;
using BusinessObjects;
using SoftStore.App_Code;

namespace SoftStore.admin.controls
{
    public partial class contact : System.Web.UI.UserControl
    {
        Feedback fb=new Feedback();
        protected void Page_Load(object sender, EventArgs e)
        {
            btnDel.Attributes.Add("OnClick", "return confirm('Bạn chắc chắn muốn xóa mục đã chọn?')");
            if (!IsPostBack)
            {
                UsersInfo user = UserLogin.GetUserLoging();
                if (user.GroupID == 3)
                {
                    Response.Redirect("denied.aspx");
                }
                string id = Request["id"];
                if (id == null)
                    loadList();
                else loadInfo(int.Parse(id));
            }
        }
        private void loadList()
        {
            List<FeedbackInfo> list = fb.GetList();
            if (list != null && list.Count != 0)
            {
                pagerList.DataSource = list;
                pagerList.BindToControl = rptList;
                rptList.DataSource = pagerList.DataSourcePaged;
            }
        }
        private void loadInfo(int id)
        {
            paList.Visible = false;
            paEdit.Visible = true;
            FeedbackInfo list = fb.GetByID(id);
            if (list != null)
            {
                lblFullName.Text = list.FullName;
                lblAddress.Text = list.Address;
                //lblCompany.Text = list.Company;
                lblTel.Text = list.Phone;
                lblMobile.Text = list.Fax;
                lblEmail.Text = list.Email;
                lblContent.Text = list.Content;
                lblEdate.Text = list.CreatedDate.ToString("dd/MM/yyyy HH:mm:ss");

                //set status
                fb.UpdateStatus(id.ToString());
            }
        }
        protected void btnBack_Click(object sender, ImageClickEventArgs e)
        {
            string id = Request["id"];
            if (id != null)
                fb.UpdateStatus(id);
            Response.Redirect("default.aspx?n=contact");
        }
        public static string getStatus(object statusid)
        {
            bool status = bool.Parse(statusid.ToString());
            if (status)
                return "Đã đọc";
            return "Chưa đọc";
        }
        protected void btnDel_Click(object sender, ImageClickEventArgs e)
        {
            string[] str = Request.Params.GetValues("select");
            if (str == null || str.Length == 0)
            {
                alert("Chọn mục cần xóa...");
            }
            else
            {
                int size = str.Length;
                string result = null;
                for (int i = 0; i < size; i++)
                {
                    if (i == size - 1)
                        result += str[i];
                    else result += str[i] + ",";
                }

                if (result != null)
                {
                    bool ii = fb.Delete(result);
                    if (ii)
                        Response.Redirect(Request.RawUrl);
                    else
                        alert("Xóa không thành công. Vui lòng thử lại sau");
                }
            }
        }
        private void alert(string str)
        {
            ClientScriptManager csm = Page.ClientScript;
            string js = "<script language=\"javascript\">alert('" + str + "');</script>";
            csm.RegisterStartupScript(Page.GetType(), "alert_js", js);
        }
    }
}