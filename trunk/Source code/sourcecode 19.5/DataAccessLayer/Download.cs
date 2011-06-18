using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Logger;
using BusinessObjects;
using Utilities;

namespace DataAccessLayer
{
    public class Download
    {
        private static DownloadInfo createObj(SqlDataReader dr, int stt)
        {
            try
            {
                DownloadInfo info = new DownloadInfo();
                info.STT = stt;
                info.ID = SqlObject.getInt32(dr, 0);
                info.Title = SqlObject.getString(dr, 1);
                info.Description = SqlObject.getString(dr, 2);
                info.FileName = SqlObject.getString(dr, 3);
                info.CreatedDate = SqlObject.getDateTime(dr, 4);
                info.IsPublish = SqlObject.getBool(dr, 5);
                return info;
            }
            catch (Exception ex)
            {
                Log.error("Download createObj err: " + ex.Message);
                return null;
            }
        }
        private static string conn = SqlHelper.ConnectionStringLocalTransaction;
        private CommandType cmd = CommandType.Text;
        public DownloadInfo GetByID(int ID)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ID", SqlDbType.Int);
                param[0].Value = ID;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from Download where ID=@ID", param);
                List<DownloadInfo> list = new List<DownloadInfo>();
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
                Log.error("Download GetByID err: " + ex.Message);
                return null;
            }
        }
        public List<DownloadInfo> GetListDownLoad()
        {
            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from Download order by CreatedDate DESC", null);
                List<DownloadInfo> list=new List<DownloadInfo>();
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
                Log.error("Download GetListDownLoad err: " + ex.Message);
                return null;
            }
        }
        public List<DownloadInfo> GetListDownLoadPublished()
        {
            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from Download where IsPublish=1 order by CreatedDate DESC", null);
                List<DownloadInfo> list = new List<DownloadInfo>();
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
                Log.error("Download GetListDownLoadPublished err: " + ex.Message);
                return null;
            }
        }
        public bool Insert(DownloadInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@Title", SqlDbType.NVarChar);
                param[0].Value = info.Title;
                param[1] = new SqlParameter("@Description", SqlDbType.NVarChar);
                param[1].Value = info.Description;
                param[2] = new SqlParameter("@FileName", SqlDbType.NVarChar);
                param[2].Value = info.FileName;
                param[3] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                param[3].Value = info.CreatedDate;
                param[4] = new SqlParameter("@IsPublish", SqlDbType.Bit);
                param[4].Value = info.IsPublish;
                
                SqlHelper.ExecuteNonQuery(conn
                                          , cmd
                                          , @"insert into Download(Title,Description,FileName,CreatedDate,IsPublish)
                                            values(@Title,@Description,@FileName,@CreatedDate,@IsPublish)"
                                          , param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("DownloadInfo Insert err: " + ex.Message);
                return false;
            }
        }
        public bool Update(DownloadInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@Title", SqlDbType.NVarChar);
                param[0].Value = info.Title;
                param[1] = new SqlParameter("@Description", SqlDbType.NVarChar);
                param[1].Value = info.Description;
                param[2] = new SqlParameter("@FileName", SqlDbType.NVarChar);
                param[2].Value = info.FileName;
                param[3] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                param[3].Value = info.CreatedDate;
                param[4] = new SqlParameter("@IsPublish", SqlDbType.Bit);
                param[4].Value = info.IsPublish;
                param[5] = new SqlParameter("@ID", SqlDbType.Int);
                param[5].Value = info.ID;
                SqlHelper.ExecuteNonQuery(conn
                                          , cmd
                                          , @"update Download set Title=@Title,Description=@Description,FileName=@FileName,
                                            IsPublish=@IsPublish where ID=@ID"
                                          , param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("DownloadInfo update err: " + ex.Message);
                return false;
            }
        }
        public bool Delete(string id)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(conn, cmd, string.Format("delete from Download where ID in ({0})", id), null);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("DownloadInfo delete err: " + ex.Message);
                return false;
            }
        }
    }
}
