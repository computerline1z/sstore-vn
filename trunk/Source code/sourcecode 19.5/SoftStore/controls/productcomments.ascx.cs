using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using DataAccessLayer;
using BusinessObjects;
using SoftStore.App_Code;
using Utilities;

namespace SoftStore.controls
{
    public partial class productcomments : System.Web.UI.UserControl
    {
        ProductComments pc = new ProductComments();
        Members mem=new Members();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                MembersInfo member = MemberLogin.GetMemberLogin();
                if(member!=null)
                {
                    txtContent.Text = null;
                    txtContent.Enabled = true;
                    btnSubmit.Enabled = true;
                }
                else
                {
                    txtContent.Text = "Vui lòng đăng nhập để viết bình luận. Cảm ơn";
                    txtContent.Enabled = false;
                    btnSubmit.Enabled = false;
                }
                object obj = Session["ProductComments"];
                if(obj!=null)
                {
                    List<ProductCommentsInfo> listcomment = (List<ProductCommentsInfo>) obj;
                    rptListComment.DataSource = listcomment;
                    rptListComment.DataBind();
                }
                Session["Url"] = Request.RawUrl;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            MembersInfo info = MemberLogin.GetMemberLogin();
            ProductCommentsInfo item=new ProductCommentsInfo();
            item.CommentContent = txtContent.Text;
            item.ProductID = Request["id"];
            item.MemberID = info.MemberID;
            item.CommentDate = DateTime.Now;
            item.IsPublish = true;
            bool kq = pc.Insert(item);
            if(kq)
            {
                ClientScriptManager csm = Page.ClientScript;
                string js = "<script language=\"javascript\">alert('Cảm ơn bạn đã bình luận cho sản phẩm');window.location.href=\"" + Session["Url"] + "\";</script>";
                csm.RegisterStartupScript(Page.GetType(), "Found", js);
            }
            else
            {
                ClientScriptManager csm = Page.ClientScript;
                string js = "<script language=\"javascript\">alert('Có lỗi phát sinh. Bình luận của bạn chưa được chấp nhận');window.location.href=\"/" + Session["Url"] + "\";</script>";
                csm.RegisterStartupScript(Page.GetType(), "Found", js);
            }
        }
        public string[] GetMember(object MemberID)
        {
            string[] result=new string[2];
            MembersInfo info = mem.GetByMemberID(int.Parse(MemberID.ToString()));
            if (info != null)
            {
                result[0] = info.FullName;
                result[1] = info.Avatar;
            }
            return result;
        }

    }
}