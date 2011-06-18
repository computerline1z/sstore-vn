using System;
using System.Collections.Generic;
using System.Web.UI;
using DataAccessLayer;
using BusinessObjects;
using SoftStore.App_Code;

namespace SoftStore.admin.controls
{
    public partial class supportonline : UserControl
    {
        SupportOnline sup = new SupportOnline();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UsersInfo user = UserLogin.GetUserLoging();
                if (user.GroupID ==3)
                {
                    Response.Redirect("denied.aspx");
                }
                btnDel.Attributes.Add("OnClick", "return confirm('Bạn chắc chắn muốn xóa mục đã chọn?')");
                string id = Request["id"];
                if (id != null)
                {
                    loadInfo(id);
                }
                else loadList();
            }
        }
        private void loadList()
        {
            IList<SupportOnlineInfo> list = sup.getList();
            if (list != null && list.Count != 0)
            {
                rptList.DataSource = list;
                rptList.DataBind();
            }
        }
        private void loadInfo(string id)
        {
            paList.Visible = false;
            paEdit.Visible = true;
            IList<SupportOnlineInfo> list = sup.getByID(id);
            if (list != null && list.Count != 0)
            {
                txtName.Text = list[0].Name;
                txtNick.Text = list[0].Nick;
                drlType.SelectedValue = list[0].TypeID.ToString();
                if (list[0].StatusID == false)
                    drlStatus.SelectedValue = "0";
                txtIndex.Text = list[0].IndexNumber.ToString();
            }
        }

        protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid)
            {
                string name = txtName.Text;
                string type = drlType.SelectedValue;
                string nick = txtNick.Text;
                int index;
                try
                {
                    index = int.Parse(txtIndex.Text.Trim());
                }
                catch
                {
                    index = 1;
                }
                bool statusid = true;
                if (drlStatus.SelectedValue == "0")
                    statusid = false;
                string id = Request["id"];
                if (id == null)
                {
                    SupportOnlineInfo rei = new SupportOnlineInfo(1, 1, name, nick, int.Parse(type), statusid, DateTime.Now, index);
                    bool kq = sup.insert(rei);
                    if (kq)
                        Response.Redirect("default.aspx?n=supportonline");
                    else
                    {
                        alert("Thêm mới không thành công, vui lòng thử lại sau");
                    }
                }
                else
                {
                    SupportOnlineInfo rei = new SupportOnlineInfo(1, int.Parse(id), name, nick, int.Parse(type), statusid, DateTime.Now, index);
                    bool kq = sup.update(rei);
                    if (kq)
                        Response.Redirect("default.aspx?n=supportonline");
                    else
                    {
                        alert("Cập nhật không thành công, vui lòng thử lại sau");
                    }
                }
            }
        }

        protected void btnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("default.aspx?n=supportonline");
        }

        protected void btnNew_Click(object sender, ImageClickEventArgs e)
        {
            paEdit.Visible = true;
            paList.Visible = false;
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
                    bool ii = sup.delete(result);
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
        public static string getType(object type)
        {
            if(type.ToString().Equals("1"))
                return "Yahoo";
            return "Skype";
        }
        public static string getStatus(object status)
        {
            if (bool.Parse(status.ToString()))
                return "Kích hoạt";
            return "Không kích hoạt";
        }
    }
}