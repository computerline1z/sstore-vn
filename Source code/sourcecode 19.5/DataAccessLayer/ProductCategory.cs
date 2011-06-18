using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Logger;
using BusinessObjects;
using Utilities;
using System.Text;

namespace DataAccessLayer
{
    public class ProductCategory
    {
        private static ProductCategoryInfo createObj(SqlDataReader dr, int stt)
        {
            try
            {
                ProductCategoryInfo intro = new ProductCategoryInfo();
                intro.STT = stt;
                intro.CategoryID = SqlObject.getInt32(dr, 0);
                intro.CategoryName = SqlObject.getString(dr, 1);
                intro.Description = SqlObject.getString(dr, 2);
                intro.Status = SqlObject.getBool(dr, 3);
                intro.SortOrder = SqlObject.getInt32(dr, 4);
                intro.ParentID = SqlObject.getInt32(dr, 5);
                intro.Level = SqlObject.getInt32(dr, 6);
                intro.Icon = SqlObject.getString(dr, 7);
                intro.CreatedDate = SqlObject.getDateTime(dr, 8);
                return intro;
            }
            catch (Exception ex)
            {
                Log.error("ProductCategoryInfo createObj err: " + ex.Message);
                return null;
            }
        }
        private static string conn = SqlHelper.ConnectionStringLocalTransaction;
        private CommandType cmd = CommandType.Text;
        public int GetMaxParentID()
        {
            try
            {
                object obj = SqlHelper.ExecuteScalar(conn, cmd, "select max(ParentID) from Category", null);
                if (obj!=null)
                    return int.Parse(obj.ToString());
                return 0;

            }
            catch (Exception ex)
            {
                Log.error("GetMaxParentID err: " + ex.Message);
                return 0;
            }
        }
        public ProductCategoryInfo GetByID(int CategoryID)
        {
            try
            {
                SqlParameter param = new SqlParameter("@CategoryID", SqlDbType.Int);
                param.Value = CategoryID;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from Category where CategoryID=@CategoryID", param);
                int stt = 0;
                while (dr.Read())
                {
                    stt++;
                    return createObj(dr, stt);
                }
                return null;
            }
            catch (Exception ex)
            {
                Log.error("ProductCategoryInfo getByID err: " + ex.Message);
                return null;
            }
        }
        public List<ProductCategoryInfo> GetList()
        {
            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from Category order by SortOrder ASC", null);
                List<ProductCategoryInfo> list = new List<ProductCategoryInfo>();
                int stt = 0;
                while (dr.Read())
                {
                    stt++;
                    list.Add(createObj(dr, stt));
                }
                return list;
            }
            catch (Exception ex)
            {
                Log.error("List<ProductCategoryInfo> getList err: " + ex.Message);
                return null;
            }
        }
        public List<ProductCategoryInfo> GetList(int ParentID)
        {
            try
            {
                SqlParameter param = new SqlParameter("@ParentID", SqlDbType.Int);
                param.Value = ParentID;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from Category where ParentID=@ParentID order by SortOrder ASC", param);
                List<ProductCategoryInfo> list = new List<ProductCategoryInfo>();
                int stt = 0;
                while (dr.Read())
                {
                    stt++;
                    list.Add(createObj(dr, stt));
                }
                return list;
            }
            catch (Exception ex)
            {
                Log.error("List<ProductCategoryInfo> getList err: " + ex.Message);
                return null;
            }
        }
        public List<ProductCategoryInfo> GetList(int ParentID, bool Status)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@ParentID", SqlDbType.Int);
                param[0].Value = ParentID;
                param[1] = new SqlParameter("@Status", SqlDbType.Bit);
                param[1].Value = Status;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from Category where ParentID=@ParentID and Status=@Status order by SortOrder ASC", param);
                List<ProductCategoryInfo> list = new List<ProductCategoryInfo>();
                int stt = 0;
                while (dr.Read())
                {
                    stt++;
                    list.Add(createObj(dr, stt));
                }
                return list;
            }
            catch (Exception ex)
            {
                Log.error("List<ProductCategoryInfo> getList err: " + ex.Message);
                return null;
            }
        }
        /// <summary>
        /// Get all category of category id include parent
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public List<ProductCategoryInfo> GetAllList(int categoryId)
        {
            if(categoryId>0)
            {
                try
                {
                    List<ProductCategoryInfo> pcList = new List<ProductCategoryInfo>();
                    ProductCategoryInfo pc = new ProductCategoryInfo();
                    pc = GetByID(categoryId);
                    if (pc != null)
                    {
                        pcList.Add(pc);
                        while (pc.ParentID != 0)
                        {
                            pc = GetByID(pc.ParentID);
                            if (pc != null)
                            {
                                pcList.Add(pc);
                            }
                        }
                    }
                    return pcList;
                }
                catch (Exception ex)
                {
                    Log.error("List<ProductCategoryInfo> getAllList err: " + ex.Message);
                    return null;
                }
            }
            return null;
        }
        /// <summary>
        /// Get category by product id
        /// </summary>
        /// <param name="ProductID"></param>
        /// <returns></returns>
        public int GetCategoryByProductId(String ProductID)
        {
            try
            {
                SqlParameter param = new SqlParameter("@ProductID", SqlDbType.Char);
                param.Value = ProductID;
                object obj = SqlHelper.ExecuteScalar(conn, cmd, "select CategoryID from Products where ProductID=@ProductID", param);
                if (obj != null)
                    return int.Parse(obj.ToString());
                else
                    return -1;
            }
            catch (Exception ex)
            {
                Log.error("GetCategoryByProductId getList err: " + ex.Message);
                return -1;
            }
        }
       
        /// <summary>
        /// Get full category path
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public String GetCategoryPath(int categoryId)
        {
            String categoryString = "";
            if (categoryId > 0)
            {
                try
                {

                    //Get all category list
                    List<ProductCategoryInfo> pcList = new List<ProductCategoryInfo>();
                    pcList = GetAllList(categoryId);

                    if (pcList != null && pcList.Count > 0)
                    {
                        for (int i = pcList.Count - 1; i > 0; i--)
                        {
                            categoryString += "/" + pcList[i].CategoryName;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.error("List<ProductCategoryInfo> getAllList err: " + ex.Message);
                }
            }
            return categoryString;
        }
        /// <summary>
        /// Get full category path with friendly URL
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public String GetCategoryPathWithUrlFriendly(int categoryId)
        {
            String categoryString = "";
            if (categoryId > 0)
            {
                try
                {

                    //Get all category list
                    List<ProductCategoryInfo> pcList = new List<ProductCategoryInfo>();
                    pcList = GetAllList(categoryId);

                    if (pcList != null && pcList.Count >= 0)
                    {
                        for (int i = pcList.Count - 1; i >=0; i--)
                        {
                            categoryString += "/" + FriendlyURL.ConvertUrlFriendlyNoExt(pcList[i].CategoryName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.error("List<ProductCategoryInfo> getAllList err: " + ex.Message);
                }
            }
            return categoryString;
        }

        public bool Insert(ProductCategoryInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@CategoryName", SqlDbType.NVarChar);
                param[0].Value = info.CategoryName;
                param[1] = new SqlParameter("@Status", SqlDbType.Bit);
                param[1].Value = info.Status;
                param[2] = new SqlParameter("@SortOrder", SqlDbType.Int);
                param[2].Value = info.SortOrder;
                param[3] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                param[3].Value = info.CreatedDate;
                param[4] = new SqlParameter("@ParentID", SqlDbType.Int);
                param[4].Value = info.ParentID;
                SqlHelper.ExecuteNonQuery(conn, cmd, "insert into ProductCategory(CategoryName, SortOrder, Status, CreatedDate,ParentID) values(@CategoryName, @SortOrder, @Status,@CreatedDate,@ParentID)", param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("ProductCategoryInfo insert err: " + ex.Message);
                return false;
            }
        }
        public bool Update(ProductCategoryInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@CategoryName", SqlDbType.NVarChar);
                param[0].Value = info.CategoryName;
                param[1] = new SqlParameter("@Status", SqlDbType.Bit);
                param[1].Value = info.Status;
                param[2] = new SqlParameter("@SortOrder", SqlDbType.Int);
                param[2].Value = info.SortOrder;
                param[3] = new SqlParameter("@ParentID", SqlDbType.Int);
                param[3].Value = info.ParentID;
                param[4] = new SqlParameter("@CategoryID", SqlDbType.Int);
                param[4].Value = info.CategoryID;
                SqlHelper.ExecuteNonQuery(conn, cmd, "update ProductCategory set CategoryName=@CategoryName,SortOrder=@SortOrder,ParentID=@ParentID where CategoryID=@CategoryID", param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("ProductCategoryInfo update err: " + ex.Message);
                return false;
            }
        }
        public bool Delete(int ParentID)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(conn, cmd, "delete from Category where ParentID=" + ParentID, null);
                SqlHelper.ExecuteNonQuery(conn, cmd, "delete from Category where CategoryID=" + ParentID, null);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("ProductCategoryInfo delete err: " + ex.Message);
                return false;
            }
        }
    }
}
