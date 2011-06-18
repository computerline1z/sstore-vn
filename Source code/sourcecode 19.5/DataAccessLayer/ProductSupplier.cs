using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Logger;
using BusinessObjects;
using Utilities;

namespace DataAccessLayer
{
    public class ProductSupplier
    {
        private string SQL_GETLIST = "select * from ProductSupplier order by SupplierName ASC";
        private string SQL_GETLIST_BYSTATUS = "select * from ProductSupplier where Status=@Status order by SupplierName ASC";
        private string SQL_GETBYID = "select * from ProductSupplier where SupplierID=@SupplierID";
        private string SQL_INSERT = "insert into ProductSupplier(SupplierName, Description, Status, CreatedDate) values(@SupplierName, @Description, @Status,@CreatedDate)";
        private string SQL_UPDATE = "update ProductSupplier set SupplierName=@SupplierName,Description=@Description where SupplierID=@SupplierID";
        private string SQL_DEL = "delete from ProductSupplier where SupplierID in ({0})";

        private static ProductSupplierInfo createObj(SqlDataReader dr, int stt)
        {
            try
            {
                ProductSupplierInfo intro = new ProductSupplierInfo();
                intro.STT = stt;
                intro.SupplierID = SqlObject.getInt32(dr, 0);
                intro.SupplierName = SqlObject.getString(dr, 1);
                intro.Description = SqlObject.getString(dr, 2);
                intro.Status = SqlObject.getBool(dr, 3);
                intro.CreatedDate = SqlObject.getDateTime(dr, 4);
                return intro;
            }
            catch (Exception ex)
            {
                Log.error("ProductSupplierInfo createObj err: " + ex.Message);
                return null;
            }
        }
        private static string conn = SqlHelper.ConnectionStringLocalTransaction;
        private CommandType cmd = CommandType.Text;
        public ProductSupplierInfo GetByID(int SupplierID)
        {
            try
            {
                SqlParameter param = new SqlParameter("@SupplierID", SqlDbType.Int);
                param.Value = SupplierID;
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
                Log.error("ProductSupplierInfo getByID err: " + ex.Message);
                return null;
            }
        }
        public List<ProductSupplierInfo> GetList()
        {
            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, SQL_GETLIST, null);
                List<ProductSupplierInfo> list = new List<ProductSupplierInfo>();
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
                Log.error("List<ProductSupplierInfo> getList err: " + ex.Message);
                return null;
            }
        }
        public List<ProductSupplierInfo> GetList(bool Status)
        {
            try
            {
                SqlParameter param = new SqlParameter("@Status", SqlDbType.Int);
                param.Value = Status;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, SQL_GETLIST_BYSTATUS, param);
                List<ProductSupplierInfo> list = new List<ProductSupplierInfo>();
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
                Log.error("List<ProductSupplierInfo> getList err: " + ex.Message);
                return null;
            }
        }
        public bool Insert(ProductSupplierInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@SupplierName", SqlDbType.NVarChar);
                param[0].Value = info.SupplierName;
                param[1] = new SqlParameter("@Status", SqlDbType.Bit);
                param[1].Value = info.Status;
                param[2] = new SqlParameter("@Description", SqlDbType.NVarChar);
                param[2].Value = info.Description;
                param[3] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                param[3].Value = info.CreatedDate;
                SqlHelper.ExecuteNonQuery(conn, cmd, SQL_INSERT, param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("ProductSupplierInfo insert err: " + ex.Message);
                return false;
            }
        }
        public bool Update(ProductSupplierInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@SupplierName", SqlDbType.NVarChar);
                param[0].Value = info.SupplierName;
                param[1] = new SqlParameter("@Status", SqlDbType.Bit);
                param[1].Value = info.Status;
                param[2] = new SqlParameter("@Description", SqlDbType.NVarChar);
                param[2].Value = info.Description;
                param[3] = new SqlParameter("@SupplierID", SqlDbType.Int);
                param[3].Value = info.SupplierID;
                SqlHelper.ExecuteNonQuery(conn, cmd, SQL_UPDATE, param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("ProductSupplierInfo update err: " + ex.Message);
                return false;
            }
        }
        public bool Delete(string SupplierID)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(conn, cmd, string.Format(SQL_DEL, SupplierID), null);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("ProductSupplierInfo delete err: " + ex.Message);
                return false;
            }
        }
    }
}

