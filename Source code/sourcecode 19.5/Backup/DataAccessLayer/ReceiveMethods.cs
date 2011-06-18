using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Logger;
using BusinessObjects;
using Utilities;
namespace DataAccessLayer
{
    public class ReceiveMethods
    {
        private static ReceiveMethodsInfo createObj(SqlDataReader dr)
        {
            try
            {
                ReceiveMethodsInfo intro = new ReceiveMethodsInfo();
                intro.MethodID = SqlObject.getInt32(dr, 0);
                intro.MethodName = SqlObject.getString(dr, 1);
                intro.ReceiveTime = SqlObject.getString(dr, 2);
                intro.Fee = SqlObject.getInt64(dr, 3);

                return intro;
            }
            catch (Exception ex)
            {
                Log.error("ReceiveMethodsInfo createObj err: " + ex.Message);
                return null;
            }
        }
        private static string conn = SqlHelper.ConnectionStringLocalTransaction;
        private CommandType cmd = CommandType.Text;
        public ReceiveMethodsInfo GetByID(string MethodID)
        {
            try
            {
                SqlParameter param = new SqlParameter("@MethodID", SqlDbType.Int);
                param.Value = MethodID;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from ReceiveMethods where MethodID=@MethodID", param);
                while (dr.Read())
                {
                    return createObj(dr);
                }
                return null;
            }
            catch (Exception ex)
            {
                Log.error("IList<ReceiveMethodsInfo> getByID err: " + ex.Message);
                return null;
            }
        }
        public List<ReceiveMethodsInfo> GetList()
        {
            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from ReceiveMethods", null);
                List<ReceiveMethodsInfo> list = new List<ReceiveMethodsInfo>();
                while (dr.Read())
                {
                    list.Add(createObj(dr));
                }
                return list;
            }
            catch (Exception ex)
            {
                Log.error("IList<ReceiveMethodsInfo> getList err: " + ex.Message);
                return null;
            }
        }
        public bool Insert(ReceiveMethodsInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@MethodName", SqlDbType.NVarChar);
                param[0].Value = info.MethodName;
                param[1] = new SqlParameter("@ReceiveTime", SqlDbType.NVarChar);
                param[1].Value = info.ReceiveTime;
                param[2] = new SqlParameter("@Fee", SqlDbType.BigInt);
                param[2].Value = info.Fee;

                SqlHelper.ExecuteNonQuery(conn, cmd, "insert into ReceiveMethods(MethodName,ReceiveTime,Fee) values(@MethodName,@ReceiveTime,@Fee)", param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("ReceiveMethodsInfo insert err: " + ex.Message);
                return false;
            }
        }
        public bool Update(ReceiveMethodsInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@MethodName", SqlDbType.NVarChar);
                param[0].Value = info.MethodName;
                param[1] = new SqlParameter("@ReceiveTime", SqlDbType.NVarChar);
                param[1].Value = info.ReceiveTime;
                param[2] = new SqlParameter("@Fee", SqlDbType.BigInt);
                param[2].Value = info.Fee;
                param[3] = new SqlParameter("@MethodID", SqlDbType.Int);
                param[3].Value = info.MethodID;
                SqlHelper.ExecuteNonQuery(conn, cmd, "update ReceiveMethods set MethodName=@MethodName,ReceiveTime=@ReceiveTime,Fee=@Fee where MethodID=@MethodID", param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("ReceiveMethodsInfo insert err: " + ex.Message);
                return false;
            }
        }
        public bool Delete(string MethodID)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(conn, cmd, string.Format("delete from ReceiveMethods where MethodID in ({0})", MethodID), null);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("ReceiveMethodsInfo delete err: " + ex.Message);
                return false;
            }
        }
    }
}
