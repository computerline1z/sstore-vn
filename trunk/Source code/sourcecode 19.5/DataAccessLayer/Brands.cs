using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Logger;
using BusinessObjects;
using Utilities;

namespace DataAccessLayer
{
    public class Brands
    {
        private string SQL_GETLIST = "select * from Brands order by SortOrder ASC";
        private string SQL_GETBYID = "select * from Brands where ID=@ID";
        private string SQL_INSERT = "insert into Brands(Name,Picture,Url,Description,SortOrder)"
            + " values(@Name,@Picture,@Url,@Description,@SortOrder)";
        private string SQL_UPDATE = "update Brands set Name=@Name,Picture=@Picture,Url=@Url,Description=@Description,SortOrder=@SortOrder where ID=@ID";
        private string SQL_DELETE = "delete from Brands where ID in ({0})";

        private static BrandsInfo createObj(SqlDataReader dr, int stt)
        {
            try
            {
                BrandsInfo intro = new BrandsInfo();
                intro.STT = stt;
                intro.ID = SqlObject.getInt32(dr, 0);
                intro.Name = SqlObject.getString(dr, 1);
                intro.Picture = SqlObject.getString(dr, 2);
                intro.Url = SqlObject.getString(dr, 3);
                intro.Description = SqlObject.getString(dr, 4);
                intro.SortOrder = SqlObject.getInt32(dr, 5);

                return intro;
            }
            catch (Exception ex)
            {
                Log.error("BrandsInfo createObj err: " + ex.Message);
                return null;
            }
        }
        private static string conn = SqlHelper.ConnectionStringLocalTransaction;
        private CommandType cmd = CommandType.Text;
        public BrandsInfo getByID(string id)
        {
            try
            {
                SqlParameter param = new SqlParameter("@ID", SqlDbType.Int);
                param.Value = id;
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
                Log.error("IList<BrandsInfo> getByID err: " + ex.Message);
                return null;
            }
        }
        public List<BrandsInfo> getList()
        {
            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, SQL_GETLIST, null);
                List<BrandsInfo> list = new List<BrandsInfo>();
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
                Log.error("IList<BrandsInfo> getList err: " + ex.Message);
                return null;
            }
        }

        public bool insert(BrandsInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@Name", SqlDbType.NVarChar);
                param[0].Value = info.Name;
                param[1] = new SqlParameter("@Picture", SqlDbType.NVarChar);
                param[1].Value = info.Picture;
                param[2] = new SqlParameter("@Url", SqlDbType.NVarChar);
                param[2].Value = info.Url;
                param[3] = new SqlParameter("@Description", SqlDbType.NVarChar);
                param[3].Value = info.Description;
                param[4] = new SqlParameter("@SortOrder", SqlDbType.Int);
                param[4].Value = info.SortOrder;

                SqlHelper.ExecuteNonQuery(conn, cmd, SQL_INSERT, param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("BrandsInfo insert err: " + ex.Message);
                return false;
            }
        }
        public bool update(BrandsInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@Name", SqlDbType.NVarChar);
                param[0].Value = info.Name;
                param[1] = new SqlParameter("@Picture", SqlDbType.NVarChar);
                param[1].Value = info.Picture;
                param[2] = new SqlParameter("@Url", SqlDbType.NVarChar);
                param[2].Value = info.Url;
                param[3] = new SqlParameter("@Description", SqlDbType.NVarChar);
                param[3].Value = info.Description;
                param[4] = new SqlParameter("@SortOrder", SqlDbType.Int);
                param[4].Value = info.SortOrder;
                param[5] = new SqlParameter("@ID", SqlDbType.Int);
                param[5].Value = info.ID;


                SqlHelper.ExecuteNonQuery(conn, cmd, SQL_UPDATE, param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("BrandsInfo insert err: " + ex.Message);
                return false;
            }
        }
        public bool delete(string id)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(conn, cmd, string.Format(SQL_DELETE, id), null);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("BrandsInfo delete err: " + ex.Message);
                return false;
            }
        }
    }
}
