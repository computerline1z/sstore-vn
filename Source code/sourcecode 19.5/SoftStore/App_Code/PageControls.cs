
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace SoftStore.App_Code
{
    public class PageControls
    {
        public enum Page
        {
            home,
            contact,
            news,
            products,
            introduction,
            salespolicy,
            search_results,
            cart,
            warranty,
            download,
            product_detail, request, bussiness_package, product_promotion, register, forgot_password, edit_profile, change_password,
            shoppingcart,
            paymentcart,
            login, help,tags
        }
    }
    public class AdminControls
    {
        public enum Page
        {
            home,
            contact,
            company,
            introduction,
            editprofile,
            supportonline,
            news,newscategory,
            usergroup,
            userlist, advs,
            products,
            orderguide,
            shoppingcart,
            help,
            salespolicy,
            productcategory,
            productsupplier,
            download,
            members,
            brands,
            orderslist,
            paymentmethods,
            receivemethods,
            resetpass,
            advproducts, smtp, package
        }
        
    }
    public class PageTitle
    {
        public static string GetPageTitle()
        {
            return "Win bản quyền, Office bản quyền, Diệt virus, Tải phần mềm diệt virus, Diệt virus Kaspersky";
        }
        public static void AddKeywords(Page page, string content)
         {
             HtmlMeta htmlMeta = new HtmlMeta();
             htmlMeta.Name = "keywords";
             htmlMeta.Content = content;
             page.Header.Controls.AddAt(0, htmlMeta);
         }
        public static void AddDecriptions(Page page, string content)
        {
            HtmlMeta htmlMeta = new HtmlMeta();
            htmlMeta.Name = "description";
            htmlMeta.Content = content;
            page.Header.Controls.AddAt(0, htmlMeta);
        }
    }
}
