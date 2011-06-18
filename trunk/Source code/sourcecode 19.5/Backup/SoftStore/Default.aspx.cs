using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SoftStore.App_Code;

namespace SoftStore
{
    public partial class _default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string act = Request["act"];
            if (act != null)
            {
                Session["MEMBERLOGIN"] = null;
                //Response.Redirect("/trang-chu/default.aspx");
            }
            loadControls();
        }
        private void loadControls()
        {
            PageControls.Page page;
            string m_baseDir = "controls";

            try
            {
                page = (PageControls.Page)Enum.Parse(typeof(PageControls.Page), Request.QueryString["n"], true);
            }
            catch (Exception)
            {
                page = PageControls.Page.home;
            }

            string src = string.Format("{0}/{1}.ascx", m_baseDir, page);
            try
            {
                divhome.Controls.Add(LoadControl(src));
                
            }
            catch (FileNotFoundException)
            {
                throw new ApplicationException("Failed to load " + src + ".");
            }
        }
    }
}
