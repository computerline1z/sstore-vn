using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Logger;
using BusinessObjects;
using Utilities;

namespace DataAccessLayer
{
    public class Advs
    {
        private string SQL_GETLIST = "select * from Advs order by SortOrder ASC";
        private string SQL_GETBYID = "select * from Advs where ID=@ID";
        private string SQL_INSERT = "insert into Advs(AdvName,Picture,Url,Description,SortOrder,Width,Height,StartedDate,ExpireDate)"
            + " values(@AdvName,@Picture,@Url,@Description,@SortOrder,@Width,@Height,@StartedDate,@ExpireDate)";
        private string SQL_UPDATE = "update Advs set AdvName=@AdvName,Picture=@Picture,Url=@Url,Description=@Description,SortOrder=@SortOrder,Width=@Width,Height=@Height,ExpireDate=@ExpireDate where ID=@ID";
        private string SQL_DELETE = "delete from Advs where ID in ({0})";

        private static AdvsInfo createObj(SqlDataReader dr, int stt)
        {
            try
            {
                AdvsInfo intro = new AdvsInfo();
                intro.STT = stt;
                intro.ID = SqlObject.getInt32(dr, 0);
                intro.AdvName = SqlObject.getString(dr, 1);
                intro.Picture = SqlObject.getString(dr, 2);
                intro.Url = SqlObject.getString(dr, 3);
                intro.Description = SqlObject.getString(dr, 4);
                intro.SortOrder = SqlObject.getInt32(dr, 5);
                intro.Width = SqlObject.getInt32(dr, 6);
                intro.Height = SqlObject.getInt32(dr, 7);
                intro.StartedDate = SqlObject.getDateTime(dr, 8);
                intro.ExpireDate = SqlObject.getDateTime(dr, 9);

                return intro;
            }
            catch (Exception ex)
            {
                Log.error("AdvsInfo createObj err: " + ex.Message);
                return null;
            }
        }
        private static string conn = SqlHelper.ConnectionStringLocalTransaction;
        private CommandType cmd = CommandType.Text;
        public AdvsInfo getByID(string id)
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
                Log.error("IList<AdvsInfo> getByID err: " + ex.Message);
                return null;
            }
        }
        public List<AdvsInfo> getList()
        {
            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, SQL_GETLIST, null);
                List<AdvsInfo> list = new List<AdvsInfo>();
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
                Log.error("IList<AdvsInfo> getList err: " + ex.Message);
                return null;
            }
        }
        public List<AdvsInfo> getListActived()
        {
            try
            {
                DateTime now = DateTime.Now;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from Advs where ExpireDate>='" + now + "' order by SortOrder ASC", null);
                List<AdvsInfo> list = new List<AdvsInfo>();
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
                Log.error("IList<AdvsInfo> getList err: " + ex.Message);
                return null;
            }
        }
        public bool insert(AdvsInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[9];
                param[0] = new SqlParameter("@AdvName", SqlDbType.NVarChar);
                param[0].Value = info.AdvName;
                param[1] = new SqlParameter("@Picture", SqlDbType.NVarChar);
                param[1].Value = info.Picture;
                param[2] = new SqlParameter("@Url", SqlDbType.NVarChar);
                param[2].Value = info.Url;
                param[3] = new SqlParameter("@Description", SqlDbType.NVarChar);
                param[3].Value = info.Description;
                param[4] = new SqlParameter("@SortOrder", SqlDbType.Int);
                param[4].Value = info.SortOrder;
                param[5] = new SqlParameter("@Width", SqlDbType.Int);
                param[5].Value = info.Width;
                param[6] = new SqlParameter("@Height", SqlDbType.Int);
                param[6].Value = info.Height;
                param[7] = new SqlParameter("@StartedDate", SqlDbType.DateTime);
                param[7].Value = info.StartedDate;
                param[8] = new SqlParameter("@ExpireDate", SqlDbType.DateTime);
                param[8].Value = info.ExpireDate;
                SqlHelper.ExecuteNonQuery(conn, cmd, SQL_INSERT, param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("AdvsInfo insert err: " + ex.Message);
                return false;
            }
        }
        public bool update(AdvsInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[9];
                param[0] = new SqlParameter("@AdvName", SqlDbType.NVarChar);
                param[0].Value = info.AdvName;
                param[1] = new SqlParameter("@Picture", SqlDbType.NVarChar);
                param[1].Value = info.Picture;
                param[2] = new SqlParameter("@Url", SqlDbType.NVarChar);
                param[2].Value = info.Url;
                param[3] = new SqlParameter("@Description", SqlDbType.NVarChar);
                param[3].Value = info.Description;
                param[4] = new SqlParameter("@SortOrder", SqlDbType.Int);
                param[4].Value = info.SortOrder;
                param[5] = new SqlParameter("@Width", SqlDbType.Int);
                param[5].Value = info.Width;
                param[6] = new SqlParameter("@Height", SqlDbType.Int);
                param[6].Value = info.Height;
                param[7] = new SqlParameter("@ID", SqlDbType.Int);
                param[7].Value = info.ID;
                param[8] = new SqlParameter("@ExpireDate", SqlDbType.DateTime);
                param[8].Value = info.ExpireDate;

                SqlHelper.ExecuteNonQuery(conn, cmd, SQL_UPDATE, param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("AdvsInfo insert err: " + ex.Message);
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
                Log.error("AdvsInfo delete err: " + ex.Message);
                return false;
            }
        }
    }
}
