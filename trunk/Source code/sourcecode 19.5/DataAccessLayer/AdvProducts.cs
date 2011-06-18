using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Logger;
using BusinessObjects;
using Utilities;
namespace DataAccessLayer
{
    public class AdvProducts
    {
        private static AdvProductsInfo createObj(SqlDataReader dr)
        {
            try
            {
                AdvProductsInfo intro = new AdvProductsInfo();
                intro.ID = SqlObject.getInt32(dr, 0);
                intro.CategoryID = SqlObject.getInt32(dr, 1);
                intro.AdvName = SqlObject.getString(dr, 2);
                intro.FileName = SqlObject.getString(dr, 3);
                intro.Width = SqlObject.getInt32(dr, 4);
                intro.Height = SqlObject.getInt32(dr, 5);

                return intro;
            }
            catch (Exception ex)
            {
                Log.error("AdvProductsInfo createObj err: " + ex.Message);
                return null;
            }
        }
        private static string conn = SqlHelper.ConnectionStringLocalTransaction;
        private CommandType cmd = CommandType.Text;
        public AdvProductsInfo getByID(int id)
        {
            try
            {
                SqlParameter param = new SqlParameter("@ID", SqlDbType.Int);
                param.Value = id;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from AdvProducts where ID=@ID", param);
                while (dr.Read())
                {
                    return createObj(dr);
                }
                return null;
            }
            catch (Exception ex)
            {
                Log.error("IList<AdvProductsInfo> getByID err: " + ex.Message);
                return null;
            }
        }
        public List<AdvProductsInfo> getList()
        {
            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from AdvProducts", null);
                List<AdvProductsInfo> list = new List<AdvProductsInfo>();
                while (dr.Read())
                {
                    list.Add(createObj(dr));
                }
                return list;
            }
            catch (Exception ex)
            {
                Log.error("IList<AdvProductsInfo> getList err: " + ex.Message);
                return null;
            }
        }
        public AdvProductsInfo getByCategoryID(int CategoryID)
        {
            try
            {
                SqlParameter param = new SqlParameter("@CategoryID", SqlDbType.Int);
                param.Value = CategoryID;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select top 1 * from AdvProducts where CategoryID=@CategoryID", param);
                while (dr.Read())
                {
                    return createObj(dr);
                }
                return null;
            }
            catch (Exception ex)
            {
                Log.error("AdvProductsInfo getByCategoryID err: " + ex.Message);
                return null;
            }
        }
        public bool insert(AdvProductsInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@AdvName", SqlDbType.NVarChar);
                param[0].Value = info.AdvName;
                param[1] = new SqlParameter("@FileName", SqlDbType.NVarChar);
                param[1].Value = info.FileName;
                param[2] = new SqlParameter("@CategoryID", SqlDbType.Int);
                param[2].Value = info.CategoryID;
                param[3] = new SqlParameter("@Width", SqlDbType.Int);
                param[3].Value = info.Width;
                param[4] = new SqlParameter("@Height", SqlDbType.Int);
                param[4].Value = info.Height;

                SqlHelper.ExecuteNonQuery(conn, cmd, "insert into AdvProducts(AdvName,FileName,CategoryID,Width,Height) values(@AdvName,@FileName,@CategoryID,@Width,@Height)", param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("AdvProductsInfo insert err: " + ex.Message);
                return false;
            }
        }
        public bool update(AdvProductsInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@AdvName", SqlDbType.NVarChar);
                param[0].Value = info.AdvName;
                param[1] = new SqlParameter("@FileName", SqlDbType.NVarChar);
                param[1].Value = info.FileName;
                param[2] = new SqlParameter("@CategoryID", SqlDbType.Int);
                param[2].Value = info.CategoryID;
                param[3] = new SqlParameter("@Width", SqlDbType.Int);
                param[3].Value = info.Width;
                param[4] = new SqlParameter("@Height", SqlDbType.Int);
                param[4].Value = info.Height;
                param[4] = new SqlParameter("@ID", SqlDbType.Int);
                param[4].Value = info.ID;

                SqlHelper.ExecuteNonQuery(conn, cmd, "update AdvProducts set AdvName=@AdvName,FileName=@FileName,CategoryID=@CategoryID,Width=@Width,Height=@Height where ID=@ID", param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("AdvProductsInfo insert err: " + ex.Message);
                return false;
            }
        }
        public bool delete(string id)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(conn, cmd, string.Format("delete from AdvProducts where ID in ({0})", id), null);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("AdvProductsInfo delete err: " + ex.Message);
                return false;
            }
        }
    }
}
