using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Logger;
using BusinessObjects;
using Utilities;

namespace DataAccessLayer
{
    public class Feedback
    {
        private static FeedbackInfo createObj(SqlDataReader dr, int stt)
        {
            try
            {
                FeedbackInfo fbi = new FeedbackInfo();
                fbi.STT = stt;
                fbi.ID = SqlObject.getInt32(dr, 0);
                fbi.FullName = SqlObject.getString(dr, 1);
                fbi.Address = SqlObject.getString(dr, 2);
                fbi.Phone = SqlObject.getString(dr, 3);
                fbi.Mobile = SqlObject.getString(dr, 4);
                fbi.Fax = SqlObject.getString(dr, 5);
                fbi.Email = SqlObject.getString(dr, 6);
                fbi.Content = SqlObject.getString(dr, 7);
                fbi.StatusID = SqlObject.getBool(dr, 8);
                fbi.CreatedDate = SqlObject.getDateTime(dr, 9);
                return fbi;
            }
            catch (Exception ex)
            {
                Log.error("Feedback createObj err: " + ex.Message);
                return null;
            }
        }
        private static string conn = SqlHelper.ConnectionStringLocalTransaction;
        private CommandType cmd = CommandType.Text;
        public FeedbackInfo GetByID(int ID)
        {
            try
            {
                SqlParameter param = new SqlParameter("@ID", SqlDbType.Int);
                param.Value = ID;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from Feedback where ID=@ID", param);
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
                Log.error("FeedbackInfo getByID err: " + ex.Message);
                return null;
            }
        }
        public List<FeedbackInfo> GetList()
        {
            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from Feedback order by CreatedDate DESC", null);
                List<FeedbackInfo> list = new List<FeedbackInfo>();
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
                Log.error("IList<FeedbackInfo> getList err: " + ex.Message);
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
                                              "update Feedback set StatusID=1 where ID=@ID", param);
                return true;
            }
            catch (Exception e)
            {
                Log.info("feaedback updateStatus err: " + e.Message);
                return false;

            }
        }
        public bool Insert(FeedbackInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[9];
                param[0] = new SqlParameter("@FullName", SqlDbType.NVarChar);
                param[0].Value = info.FullName;
                param[1] = new SqlParameter("@Address", SqlDbType.NVarChar);
                param[1].Value = info.Address;
                param[2] = new SqlParameter("@Phone", SqlDbType.NVarChar);
                param[2].Value = info.Phone;
                param[3] = new SqlParameter("@Mobile", SqlDbType.NVarChar);
                param[3].Value = info.Mobile;
                param[4] = new SqlParameter("@Fax", SqlDbType.NVarChar);
                param[4].Value = info.Fax;
                param[5] = new SqlParameter("@Email", SqlDbType.NVarChar);
                param[5].Value = info.Email;
                param[6] = new SqlParameter("@Content", SqlDbType.NVarChar);
                param[6].Value = info.Content;
                param[7] = new SqlParameter("@StatusID", SqlDbType.Bit);
                param[7].Value = info.StatusID;
                param[8] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                param[8].Value = info.CreatedDate;
                SqlHelper.ExecuteNonQuery(conn, cmd, "insert into Feedback(FullName,Address,Phone,Mobile,Fax,Email,Content,StatusID,CreatedDate)"
            + " values(@FullName,@Address,@Phone,@Mobile,@Fax,@Email,@Content,@StatusID,@CreatedDate)", param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("Feedback insert err: " + ex.Message);
                return false;
            }
        }
        public bool Delete(string id)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(conn, cmd, string.Format("delete from Feedback where ID in ({0})", id), null);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("Feedback delete err: " + ex.Message);
                return false;
            }
        }
    }
}
