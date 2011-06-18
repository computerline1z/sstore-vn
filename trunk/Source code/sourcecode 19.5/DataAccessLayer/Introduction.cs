using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Logger;
using BusinessObjects;
using Utilities;
namespace DataAccessLayer
{
    public class Introduction
    {
        private static IntroductionInfo createObj(SqlDataReader dr, int stt)
        {
            try
            {
                IntroductionInfo info = new IntroductionInfo();
                info.STT = stt;
                info.ID = SqlObject.getInt32(dr, 0);
                info.Title = SqlObject.getString(dr, 1);
                info.Content = SqlObject.getString(dr, 2);
                info.Status = SqlObject.getBool(dr, 3);
                info.CreatedDate = SqlObject.getDateTime(dr, 4);
                return info;
            }
            catch (Exception ex)
            {
                Log.error("Introduction createObj err: " + ex.Message);
                return null;
            }
        }
        private static string conn = SqlHelper.ConnectionStringLocalTransaction;
        private CommandType cmd = CommandType.Text;
        public List<IntroductionInfo> GetListIntroduction()
        {
            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from Introduction order by CreatedDate DESC", null);
                List<IntroductionInfo> list = new List<IntroductionInfo>();
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
                Log.error("Introduction GetListIntroduction err: " + ex.Message);
                return null;
            }
        }
        public List<IntroductionInfo> GetListIntroductionPublished()
        {
            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from Introduction where Status=1 order by CreatedDate DESC", null);
                List<IntroductionInfo> list = new List<IntroductionInfo>();
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
                Log.error("Introduction GetListIntroductionPublished err: " + ex.Message);
                return null;
            }
        }
        public IntroductionInfo GetByID(int ID)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ID", SqlDbType.Int);
                param[0].Value = ID;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from Introduction where ID=@ID", param);
                List<IntroductionInfo> list = new List<IntroductionInfo>();
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
                Log.error("Introduction GetByID err: " + ex.Message);
                return null;
            }
        }
        public bool Insert(IntroductionInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@Title", SqlDbType.NVarChar);
                param[0].Value = info.Title;
                param[1] = new SqlParameter("@Content", SqlDbType.NVarChar);
                param[1].Value = info.Content;
                param[2] = new SqlParameter("@Status", SqlDbType.Bit);
                param[2].Value = info.Status;
                param[3] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                param[3].Value = info.CreatedDate;

                SqlHelper.ExecuteNonQuery(conn
                                          , cmd
                                          , @"insert into Introduction(Title,Content,Status,CreatedDate)
                                            values(@Title,@Content,@Status,@CreatedDate)"
                                          , param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("IntroductionInfo Insert err: " + ex.Message);
                return false;
            }
        }
        public bool Update(IntroductionInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@Title", SqlDbType.NVarChar);
                param[0].Value = info.Title;
                param[1] = new SqlParameter("@Content", SqlDbType.NVarChar);
                param[1].Value = info.Content;
                param[2] = new SqlParameter("@Status", SqlDbType.Bit);
                param[2].Value = info.Status;
                param[4] = new SqlParameter("@ID", SqlDbType.Int);
                param[4].Value = info.ID;
                SqlHelper.ExecuteNonQuery(conn
                                          , cmd
                                          , @"update Introduction set Title=@Title,Content=@Content,Status=@Status where ID=@ID"
                                          , param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("IntroductionInfo update err: " + ex.Message);
                return false;
            }
        }
        public bool Delete(string id)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(conn, cmd, string.Format("delete from Introduction where ID in ({0})", id), null);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("IntroductionInfo delete err: " + ex.Message);
                return false;
            }
        }
    }
}
