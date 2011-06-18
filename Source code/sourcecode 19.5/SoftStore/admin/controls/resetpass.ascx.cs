using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using DataAccessLayer;
using BusinessObjects;
using Utilities;

namespace SoftStore.admin.controls
{
    public partial class resetpass : System.Web.UI.UserControl
    {
        Members us = new Members();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOK_Click(object sender, ImageClickEventArgs e)
        {
            if(Page.IsValid)
            {
                string id = Request["id"];
                if (id != null)
                {
                    string newpass = Util.CreatePasswordHash(txtNewPass.Text.Trim());
                    int i = us.ChangePass(id, newpass);
                    if (i > 0)
                    {
                        lblNote.Style.Add("color", "blue");
                        lblNote.Text = "Thay đổi mật khẩu thành công";
                    }
                    else
                    {
                        lblNote.Style.Add("color", "red");
                        lblNote.Text =
                            "Có lỗi xảy ra, quá trình đổi mật khẩu không thành công, xin vui lòng thử lại sau";
                    }
                }
            }
        }
    }
}