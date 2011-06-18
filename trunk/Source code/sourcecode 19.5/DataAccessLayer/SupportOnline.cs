using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Logger;
using BusinessObjects;
using Utilities;

namespace DataAccessLayer
{
    public class SupportOnline
    {
        private string SQL_GETALL = "select ID, Name, Nick, TypeID,StatusID,CreatedDate,IndexNumber from SupportOnline order by IndexNumber ASC";
        private string SQL_GET_BYID = "select ID, Name, Nick, TypeID,StatusID,CreatedDate,IndexNumber from SupportOnline where ID=@ID";
        private string SQL_GET_BYSTATUS = "select ID, Name, Nick, TypeID, StatusID,CreatedDate,IndexNumber from SupportOnline where StatusID=@StatusID order by IndexNumber ASC";
        private string SQL_INSERT = "insert into SupportOnline(Name, Nick, TypeID, StatusID,CreatedDate,IndexNumber)"
            + " values(@Name, @Nick,@TypeID,@StatusID,@CreatedDate,@IndexNumber)";
        private string SQL_UPDATE = "update SupportOnline set Name=@Name, Nick=@Nick,TypeID=@TypeID,StatusID=@StatusID,CreatedDate=@CreatedDate,IndexNumber=@IndexNumber where ID=@ID";
        private string SQL_DEL = "delete from SupportOnline where ID in ({0})";

        private static SupportOnlineInfo createObj(SqlDataReader dr, int stt)
        {
            try
            {
                SupportOnlineInfo intro = new SupportOnlineInfo();
                intro.Stt = stt;
                intro.ID = SqlObject.getInt32(dr, 0);
                intro.Name = SqlObject.getString(dr, 1);
                intro.Nick = SqlObject.getString(dr, 2);
                intro.TypeID = SqlObject.getInt32(dr, 3);
                intro.StatusID = SqlObject.getBool(dr, 4);
                intro.CreatedDate = SqlObject.getDateTime(dr, 5);
                intro.IndexNumber = SqlObject.getInt32(dr, 6);
                return intro;
            }
            catch (Exception ex)
            {
                Log.error("SupportOnline createObj err: " + ex.Message);
                return null;
            }
        }
        private static string conn = SqlHelper.ConnectionStringLocalTransaction;
        private CommandType cmd = CommandType.Text;

        public IList<SupportOnlineInfo> getByID(string id)
        {
            try
            {
                SqlParameter param = new SqlParameter("@ID", SqlDbType.Int);
                param.Value = id;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, SQL_GET_BYID, param);
                IList<SupportOnlineInfo> list = new List<SupportOnlineInfo>();
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
                Log.error("IList<SupportOnline> getByID err: " + ex.Message);
                return null;
            }
        }
        public IList<SupportOnlineInfo> getList()
        {
            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, SQL_GETALL, null);
                IList<SupportOnlineInfo> list = new List<SupportOnlineInfo>();
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
                Log.error("IList<SupportOnline> getList err: " + ex.Message);
                return null;
            }
        }
        public IList<SupportOnlineInfo> getByStatus(bool statusid)
        {
            try
            {
                SqlParameter param = new SqlParameter("@StatusID", SqlDbType.Int);
                param.Value = statusid;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, SQL_GET_BYSTATUS, param);
                IList<SupportOnlineInfo> list = new List<SupportOnlineInfo>();
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
                Log.error("IList<SupportOnline> getByStatus err: " + ex.Message);
                return null;
            }
        }

        public bool insert(SupportOnlineInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@Name", SqlDbType.NVarChar);
                param[0].Value = info.Name;
                param[1] = new SqlParameter("@TypeID", SqlDbType.Int);
                param[1].Value = info.TypeID;
                param[2] = new SqlParameter("@StatusID", SqlDbType.Bit);
                param[2].Value = info.StatusID;
                param[3] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                param[3].Value = info.CreatedDate;
                param[4] = new SqlParameter("@IndexNumber", SqlDbType.Int);
                param[4].Value = info.IndexNumber;
                param[5] = new SqlParameter("@Nick", SqlDbType.VarChar);
                param[5].Value = info.Nick;
                SqlHelper.ExecuteNonQuery(conn, cmd, SQL_INSERT, param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("SupportOnline insert err: " + ex.Message);
                return false;
            }
        }
        public bool update(SupportOnlineInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@Name", SqlDbType.NVarChar);
                param[0].Value = info.Name;
                param[1] = new SqlParameter("@TypeID", SqlDbType.Int);
                param[1].Value = info.TypeID;
                param[2] = new SqlParameter("@StatusID", SqlDbType.Bit);
                param[2].Value = info.StatusID;
                param[3] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                param[3].Value = info.CreatedDate;
                param[4] = new SqlParameter("@IndexNumber", SqlDbType.Int);
                param[4].Value = info.IndexNumber;
                param[5] = new SqlParameter("@ID", SqlDbType.Int);
                param[5].Value = info.ID;
                param[6] = new SqlParameter("@Nick", SqlDbType.VarChar);
                param[6].Value = info.Nick;
                SqlHelper.ExecuteNonQuery(conn, cmd, SQL_UPDATE, param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("SupportOnline update err: " + ex.Message);
                return false;
            }
        }
        public bool delete(string id)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(conn, cmd, string.Format(SQL_DEL, id), null);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("SupportOnline delete err: " + ex.Message);
                return false;
            }
        }

    }
}
