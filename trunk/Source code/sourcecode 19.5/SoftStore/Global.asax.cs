using System;
using System.Collections.Generic;
using System.Web;
using Control;
using Logger;
using Mode;
using SoftStore.App_Code;
using Utilities;

namespace SoftStore
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            string strRootFolder = HttpContext.Current.Request.PhysicalApplicationPath;
            string logFile = strRootFolder + "/log/log.txt";
            Log.LogFileName = logFile;
            Application["FCKeditor:UserFilesPath"] = "../../../../../resources/";
            Application["ONLINE"] = 0;
        }

        protected void Application_End(object sender, EventArgs e)
        {
            Application.Lock();
            Application["ONLINE"] = Convert.ToInt32(Application["ONLINE"]) - 1;
            Application.UnLock();
            
        }
        protected void Session_OnEnd(object sender, EventArgs e)
        {
            Application.Lock();
            Application["ONLINE"] = Convert.ToInt32(Application["ONLINE"]) - 1;
            Application.UnLock();
            
        }
        protected void Session_OnStart(object sender, EventArgs e)
        {
            Application.Lock();

            Application["ONLINE"] = Convert.ToInt32(Application["ONLINE"]) + 1;
            OnlineNow.Online = Application["ONLINE"].ToString();

            Online uo = new Online();
            uo.update();
            Application.UnLock();
            IList<OnlineInfo> list = uo.getAll();
            if (list != null && list.Count != 0)
            {
                //sOnlineNow.TotalOnline = list[0].Total.ToString();
            }
        }
    }
}