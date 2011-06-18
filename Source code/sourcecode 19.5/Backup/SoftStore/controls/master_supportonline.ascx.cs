using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BusinessObjects;
using DataAccessLayer;

namespace SoftStore.controls
{
    public partial class master_supportonline : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadSupportOnline();
        }
        private void loadSupportOnline()
        {
            SupportOnline sup = new SupportOnline();
            IList<SupportOnlineInfo> list = sup.getByStatus(true);
            if (list != null && list.Count != 0)
            {
                string str = null;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].TypeID == 1)//yahoo
                    {
                        if (i == list.Count - 1)
                        {
                            str += "<div style=\"text-align: center; color:red; padding:2px;\"><b>" + list[i].Name + "</b></div>";
                            str += "<div style=\"text-align: center; padding:3px;\"><a href =\"ymsgr:sendim?" + list[i].Nick + "\"><img title=\"" + list[i].Name + "\" src=\"http://opi.yahoo.com/online?u=" + list[i].Nick + "&m=g&t=2\" border=\"0\"/></a></div>";
                        }
                        else
                        {
                            str += "<div style=\"text-align: center; color:red; padding:2px;\"><b>" + list[i].Name + "</b></div>";
                            str += "<div style=\"text-align: center; padding:3px;\"><a href =\"ymsgr:sendim?" + list[i].Nick + "\"><img title=\"" + list[i].Name + "\" src=\"http://opi.yahoo.com/online?u=" + list[i].Nick + "&m=g&t=2\" border=\"0\"/></a></div>\n<div style=\"height: 3px\"></div>";

                        }
                    }
                    else//skype
                    {
                        if (i == list.Count - 1)
                        {
                            str += "<div style=\"text-align: center; color:red; padding:2px;\"><b>" + list[i].Name + "</b></div>";
                            str += "<div style=\"text-align: center; padding:3px;\"><script type=\"text/javascript\" src=\"http://download.skype.com/share/skypebuttons/js/skypeCheck.js\"></script><a href =\"skype:" + list[i].Nick + "?chat\"><img title=\"" + list[i].Name + "\" src=\"http://mystatus.skype.com/smallclassic/" + list[i].Nick + "\" border=\"0\"/></a></div>";
                        }
                        else
                        {
                            str += "<div style=\"text-align: center; color:red; padding:2px;\"><b>" + list[i].Name + "</b></div>";
                            str += "<div style=\"text-align: center; padding:3px;\"><script type=\"text/javascript\" src=\"http://download.skype.com/share/skypebuttons/js/skypeCheck.js\"></script><a href =\"skype:" + list[i].Nick + "?chat\"><img title=\"" + list[i].Name + "\" src=\"http://mystatus.skype.com/smallclassic/" + list[i].Nick + "\" border=\"0\"/></a></div>\n<div style=\"height: 3px\"></div>";
                        }
                    }

                }
                ltStr.Text = str;
            }
        }
    }
}