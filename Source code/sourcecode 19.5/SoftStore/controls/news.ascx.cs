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
    public partial class news : System.Web.UI.UserControl
    {
        News ne = new News();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string id = Request["id"];
                if (id == null)
                {
                    Page.Title = "Tin tức - " + PageTitle.GetPageTitle();
                    loadByCategory(1);
                    paDetail.Visible = false;
                    paList.Visible = true;

                }
                else
                {
                    //detail
                    paDetail.Visible = true;
                    paList.Visible = false;

                    NewsInfo info = ne.GetByID(int.Parse(id));
                    if (info != null)
                    {
                        Page.Title = "Tin tức - " + info.Title + " - " + PageTitle.GetPageTitle();
                        List<NewsInfo> detail=new List<NewsInfo>();
                        detail.Add(info);

                        lblTitle.Text = info.Title;

                        rptDetail.DataSource = detail;
                        rptDetail.DataBind();

                        //load other
                        List<NewsInfo> list = ne.GeListOtherPublished(1, int.Parse(id));
                        if (list != null && list.Count != 0)
                        {
                            //rptOther.DataSource = list;
                            //rptOther.DataBind();
                        }
                    }

                }
            }
        }
        private void loadByCategory(int catid)
        {
            List<NewsInfo> list = ne.GetListPublished(catid);
            if (list != null && list.Count != 0)
            {
                rptListNews.DataSource = list;
                rptListNews.DataBind();
            }
        }
        public string DisplayImg(object pic)
        {
            if (pic.ToString() == "" || pic.ToString().Length == 0)
                return "none";
            return "inline";
        }
    }
}