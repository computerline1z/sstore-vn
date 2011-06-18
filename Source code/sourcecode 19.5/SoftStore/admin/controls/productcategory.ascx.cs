using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using BusinessObjects;
using SoftStore.App_Code;

namespace SoftStore.admin.controls
{
    public partial class productcategory : System.Web.UI.UserControl
    {
        TreeNode parent = new TreeNode("Root Category","");
       
        List<ProductCategoryInfo> list_ds = new List<ProductCategoryInfo>();
        
        ProductCategory cat = new ProductCategory();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UsersInfo user = UserLogin.GetUserLoging();
                if (user.GroupID != 0 && user.GroupID != 1)
                {
                    Response.Redirect("denied.aspx");
                }
                
                
                string id = Request["id"];
                if (id != null)
                {
                    list_ds.Add(new ProductCategoryInfo(0,0,"[Root Category]",0,true,DateTime.Now,0));
                    loadParrentNode(0, 0);
                    loadInfo(int.Parse(id));
                    btnDel.Enabled = true;
                }
                else
                {
                    loadList(0, 0, parent);
                    TreeView1.Nodes.Add(parent);
                }   
            }
        }
        

        private void loadParrentNode(int parentID, int level)
        {           
            List<ProductCategoryInfo> list = cat.GetList(parentID);
            if (list != null && list.Count != 0)
            {
                string preStr = "";
                for (int j = 0; j < level; j++)
                {
                    preStr += "----";
                }   
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].CategoryName = preStr + list[i].CategoryName;
                    list_ds.Add(list[i]);
                    int new_level = level + 1;
                    loadParrentNode(list[i].CategoryID, new_level);
                }
            }
            drlParrentNode.DataSource = list_ds;
            drlParrentNode.DataTextField = "CategoryName";
            drlParrentNode.DataValueField = "CategoryID";
            drlParrentNode.DataBind();
        }
        private void loadList(int parentID, int level, TreeNode node)
        {
            List<ProductCategoryInfo> list = cat.GetList(parentID);
            if (list != null && list.Count != 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    TreeNode cnode=new TreeNode();
                    cnode.Text = list[i].CategoryName;
                    cnode.NavigateUrl = "../default.aspx?n=productcategory&id=" + list[i].CategoryID;

                    node.ChildNodes.Add(cnode);

                    int new_level = level + 1;
                    int CategoryID = list[i].CategoryID;
                    loadList(CategoryID, new_level, cnode);
                }
            }
        }
        private void loadInfo(int id)
        {
            paList.Visible = false;
            paEdit.Visible = true;
            ProductCategoryInfo info = cat.GetByID(id);
            if (info != null)
            {
                drlParrentNode.SelectedValue = info.ParentID.ToString();
                txtName.Text = info.CategoryName;
                txtIndex.Text = info.SortOrder.ToString();
                if (info.Status)
                {
                    rdbYes.Checked = true;
                    rdbNo.Checked = false;
                }
            }
        }

        protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid)
            {
                string CatName = txtName.Text;
                int index;
                try
                {
                    index = int.Parse(txtIndex.Text.Trim());
                }
                catch
                {
                    index = 1;
                }
                bool published = false;
                if (rdbYes.Checked)
                    published = true;
                int parrentid = int.Parse(drlParrentNode.SelectedValue);
                ProductCategoryInfo info = new ProductCategoryInfo(1, 1, CatName, index, published, DateTime.Now, parrentid);
                string id = Request["id"];
                if (id == null)
                {
                   
                    bool kq = cat.Insert(info);
                    if (kq)
                        Response.Redirect("default.aspx?n=productcategory");//&catid=" + Request["catid"]);
                    else
                    {
                        alert("Thêm mới không thành công, vui lòng thử lại sau");
                    }
                }
                else
                {
                    info.CategoryID = int.Parse(id);
                    bool kq = cat.Update(info);
                    if (kq)
                        Response.Redirect("default.aspx?n=productcategory");//&catid=" + Request["catid"]);
                    else
                    {
                        alert("Cập nhật không thành công, vui lòng thử lại sau");
                    }
                }
            }
        }

        protected void btnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("default.aspx?n=productcategory");
        }

        protected void btnNew_Click(object sender, ImageClickEventArgs e)
        {
            paEdit.Visible = true;
            paList.Visible = false;
            list_ds.Add(new ProductCategoryInfo(0, 0, "[Root Category]", 0, true, DateTime.Now, 0));
            loadParrentNode(0, 0);
            btnDel.Enabled = false;
        }

        protected void btnDel_Click(object sender, ImageClickEventArgs e)
        {
            bool ii = cat.Delete(int.Parse(Request["id"]));
            if (ii)
                Response.Redirect(Request.RawUrl);
            else
                alert("Xóa danh mục không thành công. Vui lòng thử lại sau");
        }
        private void alert(string str)
        {
            ClientScriptManager csm = Page.ClientScript;
            string js = "<script language=\"javascript\">alert('" + str + "');</script>";
            csm.RegisterStartupScript(Page.GetType(), "alert_js", js);
        }

    }
}