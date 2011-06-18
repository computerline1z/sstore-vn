using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using BusinessObjects;
using SoftStore.App_Code;
using Utilities;

namespace SoftStore.controls
{
    public partial class master_footer : System.Web.UI.UserControl
    {
        News ne=new News();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                NewsCategory cat=new NewsCategory();
                List<NewsCategoryInfo> list = cat.GetList(true);
                if (list != null && list.Count != 0)
                {
                    rptNewsCategory.DataSource = list;
                    rptNewsCategory.DataBind();
                }
            }
        }
        protected void rptNewsCategoryOnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            NewsCategoryInfo item = (NewsCategoryInfo) e.Item.DataItem;
            Repeater rptListNews = (Repeater) e.Item.FindControl("rptListNews");
            if(rptListNews!=null)
            {
                List<NewsInfo> list = ne.GetTopListPublished(item.CategoryID);
                if (list != null && list.Count != 0)
                {
                    rptListNews.DataSource = list;
                    rptListNews.DataBind();
                }
            }
        }
    }
}