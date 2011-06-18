using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Logger;
using BusinessObjects;
using Utilities;


namespace DataAccessLayer
{
    public class News
    {
        private static NewsInfo createObj(SqlDataReader dr, int stt)
        {
            try
            {
                NewsInfo info = new NewsInfo();
                info.STT = stt;
                info.ID = SqlObject.getInt32(dr, 0);
                info.CategoryID = SqlObject.getInt32(dr, 1);
                info.Title = SqlObject.getString(dr, 2);
                info.Intro = SqlObject.getString(dr, 3);
                info.Content = SqlObject.getString(dr, 4);
                info.Picture = SqlObject.getString(dr, 5);
                info.PicNote = SqlObject.getString(dr, 6);
                info.IsHot = SqlObject.getBool(dr, 7);
                info.CreatedBy = SqlObject.getInt32(dr, 8);
                info.CreatedDate = SqlObject.getDateTime(dr, 9);
                info.IsPublish = SqlObject.getBool(dr, 10);
                info.PublishedBy = SqlObject.getInt32(dr, 11);
                info.PublishedDate = SqlObject.getDateTime(dr, 12);
                return info;
            }
            catch (Exception ex)
            {
                Log.error("News createObj err: " + ex.Message);
                return null;
            }
        }
        private static string conn = SqlHelper.ConnectionStringLocalTransaction;
        private CommandType cmd = CommandType.Text;
        public List<NewsInfo> GetList(int CategoryID)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@CategoryID", SqlDbType.Int);
                param[0].Value = CategoryID;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from News where CategoryID=@CategoryID order by CreatedDate DESC", param);
                List<NewsInfo> list = new List<NewsInfo>();
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
                Log.error("News GetListNews err: " + ex.Message);
                return null;
            }
        }
        public List<NewsInfo> GetListPublished(int CategoryID)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@CategoryID", SqlDbType.Int);
                param[0].Value = CategoryID;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from News where CategoryID=@CategoryID and IsPublish=1 order by PublishedDate DESC", param);
                List<NewsInfo> list = new List<NewsInfo>();
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
                Log.error("News GetListPublished err: " + ex.Message);
                return null;
            }
        }
        public List<NewsInfo> GetTopListPublished(int CategoryID)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@CategoryID", SqlDbType.Int);
                param[0].Value = CategoryID;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select top 5 * from News where CategoryID=@CategoryID and IsPublish=1 order by PublishedDate DESC", param);
                List<NewsInfo> list = new List<NewsInfo>();
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
                Log.error("News GetListPublished err: " + ex.Message);
                return null;
            }
        }
        public List<NewsInfo> GeListOtherPublished(int CategoryID, int NotID)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@CategoryID", SqlDbType.Int);
                param[0].Value = CategoryID;
                param[1] = new SqlParameter("@ID", SqlDbType.Int);
                param[1].Value = NotID;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from News where CategoryID=@CategoryID and IsPublish=1 and ID!=@ID order by PublishedDate DESC", param);
                List<NewsInfo> list = new List<NewsInfo>();
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
                Log.error("News GeListOtherPublished err: " + ex.Message);
                return null;
            }
        }
        public NewsInfo GetByID(int ID)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ID", SqlDbType.Int);
                param[0].Value = ID;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from News where ID=@ID", param);
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
                Log.error("News GetByID err: " + ex.Message);
                return null;
            }
        }
        public bool Insert(NewsInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[10];
                param[0] = new SqlParameter("@CategoryID", SqlDbType.Int);
                param[0].Value = info.CategoryID;
                param[1] = new SqlParameter("@Title", SqlDbType.NVarChar);
                param[1].Value = info.Title;
                param[2] = new SqlParameter("@Intro", SqlDbType.NText);
                param[2].Value = info.Intro;
                param[3] = new SqlParameter("@Content", SqlDbType.NText);
                param[3].Value = info.Content;
                param[4] = new SqlParameter("@Picture", SqlDbType.NVarChar);
                param[4].Value = info.Picture;
                param[5] = new SqlParameter("@PicNote", SqlDbType.NVarChar);
                param[5].Value = info.PicNote;
                param[6] = new SqlParameter("@IsHot", SqlDbType.Bit);
                param[6].Value = info.IsHot;
                param[7] = new SqlParameter("@CreatedBy", SqlDbType.Int);
                param[7].Value = info.CreatedBy;
                param[8] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                param[8].Value = info.CreatedDate;
                param[9] = new SqlParameter("@IsPublish", SqlDbType.Bit);
                param[9].Value = info.IsPublish;

                SqlHelper.ExecuteNonQuery(conn
                                          , cmd
                                          , @"insert into News(CategoryID,Title,Intro,Content,Picture,PicNote,IsHot,CreatedBy,CreatedDate,IsPublish)
                                            values(@CategoryID,@Title,@Intro,@Content,@Picture,@PicNote,@IsHot,@CreatedBy,@CreatedDate,@IsPublish)"
                                          , param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("NewsInfo Insert err: " + ex.Message);
                return false;
            }
        }
        public bool InsertAdmin(NewsInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[12];
                param[0] = new SqlParameter("@CategoryID", SqlDbType.Int);
                param[0].Value = info.CategoryID;
                param[1] = new SqlParameter("@Title", SqlDbType.NVarChar);
                param[1].Value = info.Title;
                param[2] = new SqlParameter("@Intro", SqlDbType.NText);
                param[2].Value = info.Intro;
                param[3] = new SqlParameter("@Content", SqlDbType.NText);
                param[3].Value = info.Content;
                param[4] = new SqlParameter("@Picture", SqlDbType.NVarChar);
                param[4].Value = info.Picture;
                param[5] = new SqlParameter("@PicNote", SqlDbType.NVarChar);
                param[5].Value = info.PicNote;
                param[6] = new SqlParameter("@IsHot", SqlDbType.Bit);
                param[6].Value = info.IsHot;
                param[7] = new SqlParameter("@CreatedBy", SqlDbType.Int);
                param[7].Value = info.CreatedBy;
                param[8] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                param[8].Value = info.CreatedDate;
                param[9] = new SqlParameter("@IsPublish", SqlDbType.Bit);
                param[9].Value = info.IsPublish;
                param[10] = new SqlParameter("@PublishedBy", SqlDbType.Int);
                param[10].Value = info.PublishedBy;
                param[11] = new SqlParameter("@PublishedDate", SqlDbType.DateTime);
                param[11].Value = info.PublishedDate;

                string sql =
                    @"insert into News(CategoryID,Title,Intro,Content,Picture,PicNote,IsHot,CreatedBy,CreatedDate,IsPublish)
                                            values(@CategoryID,@Title,@Intro,@Content,@Picture,@PicNote,@IsHot,@CreatedBy,@CreatedDate,@IsPublish)";
                if (info.IsPublish)
                {
                    sql =
                    @"insert into News(CategoryID,Title,Intro,Content,Picture,PicNote,IsHot,CreatedBy,CreatedDate,IsPublish,PublishedBy,PublishedDate)
                                            values(@CategoryID,@Title,@Intro,@Content,@Picture,@PicNote,@IsHot,@CreatedBy,@CreatedDate,@IsPublish,@PublishedBy,@PublishedDate)";
                }
                SqlHelper.ExecuteNonQuery(conn
                                          , cmd
                                          , sql
                                          , param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("NewsInfo Insert err: " + ex.Message);
                return false;
            }
        }
        public bool Update(NewsInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[8];
                param[0] = new SqlParameter("@CategoryID", SqlDbType.Int);
                param[0].Value = info.CategoryID;
                param[1] = new SqlParameter("@Title", SqlDbType.NVarChar);
                param[1].Value = info.Title;
                param[2] = new SqlParameter("@Intro", SqlDbType.NText);
                param[2].Value = info.Intro;
                param[3] = new SqlParameter("@Content", SqlDbType.NText);
                param[3].Value = info.Content;
                param[4] = new SqlParameter("@Picture", SqlDbType.NVarChar);
                param[4].Value = info.Picture;
                param[5] = new SqlParameter("@PicNote", SqlDbType.NVarChar);
                param[5].Value = info.PicNote;
                param[6] = new SqlParameter("@IsHot", SqlDbType.Bit);
                param[6].Value = info.IsHot;
                param[7] = new SqlParameter("@ID", SqlDbType.Int);
                param[7].Value = info.ID;
                SqlHelper.ExecuteNonQuery(conn
                                          , cmd
                                          , @"update News set CategoryID=@CategoryID,Title=@Title,Intro=@Intro,Content=@Content,
                                            Picture=@Picture,PicNote=@PicNote,IsHot=@IsHot where ID=@ID"
                                          , param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("NewsInfo Update err: " + ex.Message);
                return false;
            }
        }
        public bool UpdateAdmin(NewsInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[11];
                param[0] = new SqlParameter("@CategoryID", SqlDbType.Int);
                param[0].Value = info.CategoryID;
                param[1] = new SqlParameter("@Title", SqlDbType.NVarChar);
                param[1].Value = info.Title;
                param[2] = new SqlParameter("@Intro", SqlDbType.NText);
                param[2].Value = info.Intro;
                param[3] = new SqlParameter("@Content", SqlDbType.NText);
                param[3].Value = info.Content;
                param[4] = new SqlParameter("@Picture", SqlDbType.NVarChar);
                param[4].Value = info.Picture;
                param[5] = new SqlParameter("@PicNote", SqlDbType.NVarChar);
                param[5].Value = info.PicNote;
                param[6] = new SqlParameter("@IsHot", SqlDbType.Bit);
                param[6].Value = info.IsHot;
                param[7] = new SqlParameter("@ID", SqlDbType.Int);
                param[7].Value = info.ID;
                param[8] = new SqlParameter("@IsPublish", SqlDbType.Bit);
                param[8].Value = info.IsPublish;
                param[9] = new SqlParameter("@PublishedBy", SqlDbType.Int);
                param[9].Value = info.PublishedBy;
                param[10] = new SqlParameter("@PublishedDate", SqlDbType.DateTime);
                param[10].Value = info.PublishedDate;
                string sql =
                    @"update News set CategoryID=@CategoryID,Title=@Title,Intro=@Intro,Content=@Content,
                                            Picture=@Picture,PicNote=@PicNote,IsHot=@IsHot where ID=@ID";
                if(info.IsPublish)
                {
                    sql =
                    @"update News set CategoryID=@CategoryID,Title=@Title,Intro=@Intro,Content=@Content,
                                            Picture=@Picture,PicNote=@PicNote,IsHot=@IsHot,IsPublish=@IsPublish,PublishedBy=@PublishedBy,PublishedDate=@PublishedDate where ID=@ID";
                }
                SqlHelper.ExecuteNonQuery(conn
                                          , cmd
                                          , sql
                                          , param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("NewsInfo Update err: " + ex.Message);
                return false;
            }
        }
        public bool Published(NewsInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[11];
                param[0] = new SqlParameter("@CategoryID", SqlDbType.Int);
                param[0].Value = info.CategoryID;
                param[1] = new SqlParameter("@Title", SqlDbType.NVarChar);
                param[1].Value = info.Title;
                param[2] = new SqlParameter("@Intro", SqlDbType.NText);
                param[2].Value = info.Intro;
                param[3] = new SqlParameter("@Content", SqlDbType.NText);
                param[3].Value = info.Content;
                param[4] = new SqlParameter("@Picture", SqlDbType.NVarChar);
                param[4].Value = info.Picture;
                param[5] = new SqlParameter("@PicNote", SqlDbType.NVarChar);
                param[5].Value = info.PicNote;
                param[6] = new SqlParameter("@IsHot", SqlDbType.Bit);
                param[6].Value = info.IsHot;
                param[7] = new SqlParameter("@PublishedBy", SqlDbType.Int);
                param[7].Value = info.PublishedBy;
                param[8] = new SqlParameter("@PublishedDate", SqlDbType.DateTime);
                param[8].Value = info.PublishedDate;
                param[9] = new SqlParameter("@IsPublish", SqlDbType.Bit);
                param[9].Value = true;
                param[10] = new SqlParameter("@ID", SqlDbType.Int);
                param[10].Value = info.ID;
                SqlHelper.ExecuteNonQuery(conn
                                          , cmd
                                          , @"update News set CategoryID=@CategoryID,Title=@Title,Intro=@Intro,Content=@Content,Picture=@Picture,PicNote=@PicNote,
                                            IsHot=@IsHot,PublishedBy=@PublishedBy,PublishedDate=@PublishedDate,IsPublish=@IsPublish where ID=@ID"
                                          , param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("NewsInfo update err: " + ex.Message);
                return false;
            }
        }
        public bool Delete(string id)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(conn, cmd, string.Format("delete from News where ID in ({0})", id), null);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("NewsInfo delete err: " + ex.Message);
                return false;
            }
        }
        public bool DeleteImg(string id)
        {
            try
            {
                SqlParameter param = new SqlParameter("@ID", SqlDbType.Int);
                param.Value = id;
                SqlHelper.ExecuteNonQuery(conn, cmd, "update News set Picture='',PicNote='' where ID=@ID", param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("NewsInfo delImg err: " + ex.Message);
                return false;
            }
        }
        /// <summary>
        /// Publish multi news
        /// </summary>
        /// <param name="NewsID"></param>
        /// <param name="IsPublish"></param>
        /// <returns></returns>
        public bool Published(string NewsID, bool IsPublish)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@IsPublish", SqlDbType.Bit);
                param[0].Value = IsPublish;
                SqlHelper.ExecuteNonQuery(conn
                                          , cmd
                                          , @"update News set IsPublish=@IsPublish where ID in (" + NewsID + ")"
                                          , param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("News Published err: " + ex.Message);
                return false;
            }
        }
    }
}
