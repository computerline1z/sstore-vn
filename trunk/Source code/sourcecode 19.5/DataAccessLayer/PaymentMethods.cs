using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Logger;
using BusinessObjects;
using Utilities;
namespace DataAccessLayer
{
    public class PaymentMethods
    {
        private static PaymentMethodsInfo createObj(SqlDataReader dr)
        {
            try
            {
                PaymentMethodsInfo intro = new PaymentMethodsInfo();
                intro.MethodID = SqlObject.getInt32(dr, 0);
                intro.MethodName = SqlObject.getString(dr, 1);
                intro.Guide = SqlObject.getString(dr, 2);
                intro.Fee = SqlObject.getInt64(dr, 3);

                return intro;
            }
            catch (Exception ex)
            {
                Log.error("PaymentMethodsInfo createObj err: " + ex.Message);
                return null;
            }
        }
        private static string conn = SqlHelper.ConnectionStringLocalTransaction;
        private CommandType cmd = CommandType.Text;
        public PaymentMethodsInfo GetByID(string MethodID)
        {
            try
            {
                SqlParameter param = new SqlParameter("@MethodID", SqlDbType.Int);
                param.Value = MethodID;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from PaymentMethods where MethodID=@MethodID", param);
                while (dr.Read())
                {
                    return createObj(dr);
                }
                return null;
            }
            catch (Exception ex)
            {
                Log.error("IList<PaymentMethodsInfo> getByID err: " + ex.Message);
                return null;
            }
        }
        public List<PaymentMethodsInfo> GetList()
        {
            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from PaymentMethods", null);
                List<PaymentMethodsInfo> list = new List<PaymentMethodsInfo>();
                while (dr.Read())
                {
                    list.Add(createObj(dr));
                }
                return list;
            }
            catch (Exception ex)
            {
                Log.error("IList<PaymentMethodsInfo> getList err: " + ex.Message);
                return null;
            }
        }
        public bool Insert(PaymentMethodsInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@MethodName", SqlDbType.NVarChar);
                param[0].Value = info.MethodName;
                param[1] = new SqlParameter("@Guide", SqlDbType.NVarChar);
                param[1].Value = info.Guide;
                param[2] = new SqlParameter("@Fee", SqlDbType.BigInt);
                param[2].Value = info.Fee;

                SqlHelper.ExecuteNonQuery(conn, cmd, "insert into PaymentMethods(MethodName,Guide,Fee) values(@MethodName,@Guide,@Fee)", param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("PaymentMethodsInfo insert err: " + ex.Message);
                return false;
            }
        }
        public bool Update(PaymentMethodsInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@MethodName", SqlDbType.NVarChar);
                param[0].Value = info.MethodName;
                param[1] = new SqlParameter("@Guide", SqlDbType.NVarChar);
                param[1].Value = info.Guide;
                param[2] = new SqlParameter("@Fee", SqlDbType.BigInt);
                param[2].Value = info.Fee;
                param[3] = new SqlParameter("@MethodID", SqlDbType.Int);
                param[3].Value = info.MethodID;
                SqlHelper.ExecuteNonQuery(conn, cmd, "update PaymentMethods set MethodName=@MethodName,Guide=@Guide,Fee=@Fee where MethodID=@MethodID", param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("PaymentMethodsInfo insert err: " + ex.Message);
                return false;
            }
        }
        public bool Delete(string MethodID)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(conn, cmd, string.Format("delete from PaymentMethods where MethodID in ({0})", MethodID), null);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("PaymentMethodsInfo delete err: " + ex.Message);
                return false;
            }
        }
    }
}
