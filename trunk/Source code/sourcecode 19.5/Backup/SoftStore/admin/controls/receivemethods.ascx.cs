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
    public partial class receivemethods : System.Web.UI.UserControl
    {
        ReceiveMethods rm=new ReceiveMethods();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UsersInfo user = UserLogin.GetUserLoging();
                if (user.GroupID != 0 && user.GroupID != 1)
                {
                    Response.Redirect("denied.aspx");
                }
                btnDel.Attributes.Add("OnClick", "return confirm('Bạn chắc chắn muốn xóa mục đã chọn?')");
                string id = Request["id"];
                if (id == null)
                    loadList();
                else loadInfo(id);
            }
        }

        private void loadList()
        {
            IList<ReceiveMethodsInfo> list = rm.GetList();
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
            ReceiveMethodsInfo info = rm.GetByID(id);
            if (info != null)
            {
                txtMethodName.Text = info.MethodName;
                txtReceiveTime.Text = info.ReceiveTime;
                txtFee.Text = info.Fee.ToString();
            }
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
                WebMsgBox.Show("Chọn mục cần xóa...");
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
                    bool ii = rm.Delete(result);
                    if (ii)
                        Response.Redirect(Request.RawUrl);
                    else
                        WebMsgBox.Show("Xóa không thành công. Vui lòng thử lại sau");
                }
            }
        }

        protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid)
            {
                string MethodName = txtMethodName.Text;
                
                string ReceiveTime = txtReceiveTime.Text;

                long fee = long.Parse(txtFee.Text);
                ReceiveMethodsInfo info =
                        new ReceiveMethodsInfo(1, MethodName, ReceiveTime,fee);
                string id = Request["id"];
                if (id == null)
                {
                    //them moi
                    bool kq = rm.Insert(info);
                    if (kq)
                        Response.Redirect("default.aspx?n=receivemethods");
                    else
                        WebMsgBox.Show("Thêm mới không thành công. Vui lòng thử lại sau");
                }
                else
                {
                    info.MethodID = int.Parse(id);
                    //cap nhat
                    bool kq = rm.Update(info);
                    if (kq)
                        Response.Redirect("default.aspx?n=receivemethods");
                    else
                        WebMsgBox.Show("Cập nhật không thành công. Vui lòng thử lại sau");
                }
            }
        }

        protected void btnCancel_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("default.aspx?n=receivemethods");
        }
    }
}