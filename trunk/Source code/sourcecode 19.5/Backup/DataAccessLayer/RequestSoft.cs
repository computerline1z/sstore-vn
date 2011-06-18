using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Logger;
using BusinessObjects;
using Utilities;

namespace DataAccessLayer
{
    public class RequestSoft
    {
        private static RequestSoftInfo createObj(SqlDataReader dr, int stt)
        {
            try
            {
                RequestSoftInfo fbi = new RequestSoftInfo();
                fbi.STT = stt;
                fbi.ID = SqlObject.getInt32(dr, 0);
                fbi.FullName = SqlObject.getString(dr, 1);
                fbi.Company = SqlObject.getString(dr, 2);
                fbi.Phone = SqlObject.getString(dr, 3);
                fbi.Email = SqlObject.getString(dr, 4);
                fbi.SoftTitle = SqlObject.getString(dr, 5);
                fbi.Content = SqlObject.getString(dr, 6);
                fbi.StatusID = SqlObject.getBool(dr, 7);
                fbi.RequestDate = SqlObject.getDateTime(dr, 8);
                return fbi;
            }
            catch (Exception ex)
            {
                Log.error("RequestSoft createObj err: " + ex.Message);
                return null;
            }
        }
        private static string conn = SqlHelper.ConnectionStringLocalTransaction;
        private CommandType cmd = CommandType.Text;
        public RequestSoftInfo GetByID(int ID)
        {
            try
            {
                SqlParameter param = new SqlParameter("@ID", SqlDbType.Int);
                param.Value = ID;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from RequestSoft where ID=@ID", param);
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
                Log.error("RequestSoftInfo getByID err: " + ex.Message);
                return null;
            }
        }
        public List<RequestSoftInfo> GetList()
        {
            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from RequestSoft order by RequestDate DESC", null);
                List<RequestSoftInfo> list = new List<RequestSoftInfo>();
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
                Log.error("IList<RequestSoftInfo> getList err: " + ex.Message);
                return null;
            }
        }
        public bool UpdateStatus(string id)
        {
            try
            {
                SqlParameter param = new SqlParameter("@ID", SqlDbType.Int);
                param.Value = id;
                SqlHelper.ExecuteNonQuery(conn, cmd,
                                              "update RequestSoft set StatusID=1 where ID=@ID", param);
                return true;
            }
            catch (Exception e)
            {
                Log.info("feaedback updateStatus err: " + e.Message);
                return false;

            }
        }
        public bool Insert(RequestSoftInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[9];
                param[0] = new SqlParameter("@FullName", SqlDbType.NVarChar);
                param[0].Value = info.FullName;
                param[1] = new SqlParameter("@Company", SqlDbType.NVarChar);
                param[1].Value = info.Company;
                param[2] = new SqlParameter("@Phone", SqlDbType.NVarChar);
                param[2].Value = info.Phone;
                param[3] = new SqlParameter("@SoftTitle", SqlDbType.NVarChar);
                param[3].Value = info.SoftTitle;
                param[5] = new SqlParameter("@Email", SqlDbType.NVarChar);
                param[5].Value = info.Email;
                param[6] = new SqlParameter("@Content", SqlDbType.NVarChar);
                param[6].Value = info.Content;
                param[7] = new SqlParameter("@StatusID", SqlDbType.Bit);
                param[7].Value = info.StatusID;
                param[8] = new SqlParameter("@RequestDate", SqlDbType.DateTime);
                param[8].Value = info.RequestDate;
                SqlHelper.ExecuteNonQuery(conn, cmd, "insert into RequestSoft(FullName,Company,Phone,SoftTitle,Email,Content,StatusID,RequestDate)"
            + " values(@FullName,@Company,@Phone,@SoftTitle,@Email,@Content,@StatusID,@RequestDate)", param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("RequestSoft insert err: " + ex.Message);
                return false;
            }
        }
        public bool Delete(string id)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(conn, cmd, string.Format("delete from RequestSoft where ID in ({0})", id), null);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("RequestSoft delete err: " + ex.Message);
                return false;
            }
        }
    }
}
