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
    public partial class tags : System.Web.UI.UserControl
    {
        Products pr = new Products();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string tag = Request["tag"];
                if (tag != null)
                {
                    tag = tag.Replace("+", " ");
                    List<ProductsInfo> list =
                        pr.GetListSearch("and ProductName like N'%" + tag + "%' or ProductName like '%" + tag + "%'");
                    if (list != null && list.Count != 0)
                    {
                        rptList.DataSource = list;
                        rptList.DataBind();
                    }
                    else
                    {
                        lblKQ.Text = "Không tìm thấy sản phẩm nào với từ khóa <b>" + tag + "</b>";
                    }
                }
            }
        }
        public string getPromotion(object _price, object _rate)
        {
            try
            {
                float rate = long.Parse(_rate.ToString());
                if (rate != 0)
                {
                    long price = long.Parse(_price.ToString());
                    return "Bạn được tặng: &nbsp;<span class=\"price\">" + ((price * rate)/100).ToString("#,##0") + "(" + rate + "%)</span>";
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}