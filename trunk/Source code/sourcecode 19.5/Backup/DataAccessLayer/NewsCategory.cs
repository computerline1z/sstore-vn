using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Logger;
using BusinessObjects;
using Utilities;

namespace DataAccessLayer
{
    public class NewsCategory
    {
        private string SQL_GETLIST = "select * from NewsCategory order by SortOrder ASC";
        private string SQL_GETLIST_BYSTATUS = "select * from NewsCategory where Status=@Status order by SortOrder ASC";
        private string SQL_GETBYID = "select * from NewsCategory where CategoryID=@CategoryID";
        private string SQL_INSERT = "insert into NewsCategory(CategoryName, SortOrder, Status, CreatedDate) values(@CategoryName, @SortOrder, @Status,@CreatedDate)";
        private string SQL_UPDATE = "update NewsCategory set CategoryName=@CategoryName,SortOrder=@SortOrder where CategoryID=@CategoryID";
        private string SQL_DEL = "delete from NewsCategory where CategoryID in ({0})";

        private static NewsCategoryInfo createObj(SqlDataReader dr, int stt)
        {
            try
            {
                NewsCategoryInfo intro = new NewsCategoryInfo();
                intro.STT = stt;
                intro.CategoryID = SqlObject.getInt32(dr, 0);
                intro.CategoryName = SqlObject.getString(dr, 1);
                intro.SortOrder = SqlObject.getInt32(dr, 2);
                intro.Status = SqlObject.getBool(dr, 3);
                intro.CreatedDate = SqlObject.getDateTime(dr, 4);
                return intro;
            }
            catch (Exception ex)
            {
                Log.error("NewsCategoryInfo createObj err: " + ex.Message);
                return null;
            }
        }
        private static string conn = SqlHelper.ConnectionStringLocalTransaction;
        private CommandType cmd = CommandType.Text;
        public NewsCategoryInfo GetByID(string CategoryID)
        {
            try
            {
                SqlParameter param = new SqlParameter("@CategoryID", SqlDbType.Int);
                param.Value = CategoryID;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, SQL_GETBYID, param);
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
                Log.error("NewsCategoryInfo getByID err: " + ex.Message);
                return null;
            }
        }
        public List<NewsCategoryInfo> GetList()
        {
            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, SQL_GETLIST, null);
                List<NewsCategoryInfo> list = new List<NewsCategoryInfo>();
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
                Log.error("List<NewsCategoryInfo> getList err: " + ex.Message);
                return null;
            }
        }
        public List<NewsCategoryInfo> GetList(bool Status)
        {
            try
            {
                SqlParameter param = new SqlParameter("@Status", SqlDbType.Int);
                param.Value = Status;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, SQL_GETLIST_BYSTATUS, param);
                List<NewsCategoryInfo> list = new List<NewsCategoryInfo>();
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
                Log.error("List<NewsCategoryInfo> getList err: " + ex.Message);
                return null;
            }
        }
        public bool Insert(NewsCategoryInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@CategoryName", SqlDbType.NVarChar);
                param[0].Value = info.CategoryName;
                param[1] = new SqlParameter("@Status", SqlDbType.Bit);
                param[1].Value = info.Status;
                param[2] = new SqlParameter("@SortOrder", SqlDbType.Int);
                param[2].Value = info.SortOrder;
                param[3] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                param[3].Value = info.CreatedDate;
                SqlHelper.ExecuteNonQuery(conn, cmd, SQL_INSERT, param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("NewsCategoryInfo insert err: " + ex.Message);
                return false;
            }
        }
        public bool Update(NewsCategoryInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@CategoryName", SqlDbType.NVarChar);
                param[0].Value = info.CategoryName;
                param[1] = new SqlParameter("@Status", SqlDbType.Bit);
                param[1].Value = info.Status;
                param[2] = new SqlParameter("@SortOrder", SqlDbType.Int);
                param[2].Value = info.SortOrder;
                param[3] = new SqlParameter("@CategoryID", SqlDbType.Int);
                param[3].Value = info.CategoryID;
                SqlHelper.ExecuteNonQuery(conn, cmd, SQL_UPDATE, param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("NewsCategoryInfo update err: " + ex.Message);
                return false;
            }
        }
        public bool Delete(string CategoryID)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(conn, cmd, string.Format(SQL_DEL, CategoryID), null);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("NewsCategoryInfo delete err: " + ex.Message);
                return false;
            }
        }
    }
}
