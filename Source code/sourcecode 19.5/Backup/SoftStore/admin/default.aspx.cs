using System;
using System.IO;
using System.Web.UI;
using SoftStore.App_Code;

namespace SoftStore.admin
{
    public partial class _default : checkLogin
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            loadControls();
        }
        private void loadControls()
        {
            AdminControls.Page page;
            string m_baseDir = "controls";

            try
            {
                page = (AdminControls.Page)Enum.Parse(typeof(AdminControls.Page), Request.QueryString["n"], true);
            }
            catch (Exception)
            {
                page = AdminControls.Page.home;
            }

            string src = string.Format("{0}/{1}.ascx", m_baseDir, page);
            try
            {
                divhome.Controls.Add(LoadControl(src));
                Page.Title = "SOFT STORE - HỆ THỐNG QUẢN TRỊ";
            }
            catch (FileNotFoundException)
            {
                throw new ApplicationException("Failed to load " + src + ".");
            }
        }
    }
}
