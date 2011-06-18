using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace SoftStore.App_Code
{
    public class CheckMobile
    {
        private static string MOBIFONE
        {
            get { return ConfigurationManager.AppSettings["MOBIFONE"].ToString(); }
        }

        private static string VINAPHONE
        {
            get { return ConfigurationManager.AppSettings["VINAPHONE"].ToString(); }
        }

        private static string VIETTEL
        {
            get { return ConfigurationManager.AppSettings["VIETTEL"].ToString(); }
        }
        /// <summary>
        /// 1:mobi+vina - 2:viettel
        /// </summary>
        /// <param name="phonenumber"></param>
        /// <returns></returns>
        public static int GetMobileNetwork(string phonenumber)
        {
            try
            {
                string[] keymobi = MOBIFONE.Split(',');
                string[] keyvina = VINAPHONE.Split(',');
                string[] keyvtel = VIETTEL.Split(',');

                string mykey = null;
                if (phonenumber.Length == 10)
                    mykey = phonenumber.Substring(0, 3);
                else if (phonenumber.Length == 11)
                {
                    if (phonenumber.Substring(0, 3) == "016") //viettel 11 so
                        return 2;
                    else mykey = phonenumber.Substring(0, 4);
                }
                for (int i = 0; i < keymobi.Length; i++)
                    if (keymobi[i] == mykey)
                        return 1;
                for (int i = 0; i < keyvina.Length; i++)
                    if (keyvina[i] == mykey)
                        return 1;
                for (int i = 0; i < keyvtel.Length; i++)
                    if (keyvtel[i] == mykey)
                        return 2;
                return 0;
            }
            catch (Exception ex)
            {
                Logger.Log.error("GetMobileNetwork err: " + ex.Message);
                return 0;
            }
        }
    }
}