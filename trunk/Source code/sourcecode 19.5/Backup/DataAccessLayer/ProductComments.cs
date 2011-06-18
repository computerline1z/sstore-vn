using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Logger;
using BusinessObjects;
using Utilities;

namespace DataAccessLayer
{
    public class ProductComments
    {
        private static ProductCommentsInfo createObj(SqlDataReader dr, int stt)
        {
            try
            {
                ProductCommentsInfo info = new ProductCommentsInfo();
                //info.STT = stt;
                info.CommentID = SqlObject.getInt32(dr, 0);
                info.ProductID = SqlObject.getString(dr, 1);
                info.MemberID = SqlObject.getInt32(dr, 2);
                info.CommentContent = SqlObject.getString(dr, 3);
                info.CommentDate = SqlObject.getDateTime(dr, 4);
                info.IsPublish = SqlObject.getBool(dr, 5);
                info.PublishBy = SqlObject.getInt32(dr, 6);
                info.PublishDate = SqlObject.getDateTime(dr, 7);
                return info;
            }
            catch (Exception ex)
            {
                Log.error("ProductComments createObj err: " + ex.Message);
                return null;
            }
        }
        private static string conn = SqlHelper.ConnectionStringLocalTransaction;
        private CommandType cmd = CommandType.Text;
        public ProductCommentsInfo GetByCommentID(int CommentID)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@CommentID", SqlDbType.Int);
                param[0].Value = CommentID;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from ProductComments where CommentID=@CommentID", param);
                List<ProductCommentsInfo> list = new List<ProductCommentsInfo>();
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
                Log.error("ProductComments GetByCommentID err: " + ex.Message);
                return null;
            }
        }
        public List<ProductCommentsInfo> GetListProductComments()
        {
            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from ProductComments order by CommentDate DESC", null);
                List<ProductCommentsInfo> list = new List<ProductCommentsInfo>();
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
                Log.error("ProductComments GetListProductComments err: " + ex.Message);
                return null;
            }
        }
        public List<ProductCommentsInfo> GetListProductCommentsPublished(string ProductID)
        {
            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from ProductComments where IsPublish=1 and ProductID='" + ProductID + "' order by CommentDate DESC", null);
                List<ProductCommentsInfo> list = new List<ProductCommentsInfo>();
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
                Log.error("ProductComments GetListProductCommentsPublished err: " + ex.Message);
                return null;
            }
        }
        public bool Insert(ProductCommentsInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = new SqlParameter("@ProductID", SqlDbType.NVarChar);
                param[0].Value = info.ProductID;
                param[1] = new SqlParameter("@MemberID", SqlDbType.NVarChar);
                param[1].Value = info.MemberID;
                param[2] = new SqlParameter("@CommentContent", SqlDbType.NVarChar);
                param[2].Value = info.CommentContent;
                param[3] = new SqlParameter("@CommentDate", SqlDbType.DateTime);
                param[3].Value = info.CommentDate;
                param[4] = new SqlParameter("@IsPublish", SqlDbType.Bit);
                param[4].Value = info.IsPublish;

                SqlHelper.ExecuteNonQuery(conn
                                          , cmd
                                          , @"insert into ProductComments(ProductID,MemberID,CommentContent,CommentDate,IsPublish)
                                            values(@ProductID,@MemberID,@CommentContent,@CommentDate,@IsPublish)"
                                          , param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("ProductCommentsInfo Insert err: " + ex.Message);
                return false;
            }
        }
        public bool Update(ProductCommentsInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@ProductID", SqlDbType.NVarChar);
                param[0].Value = info.ProductID;
                param[1] = new SqlParameter("@MemberID", SqlDbType.NVarChar);
                param[1].Value = info.MemberID;
                param[2] = new SqlParameter("@CommentContent", SqlDbType.NVarChar);
                param[2].Value = info.CommentContent;
                param[3] = new SqlParameter("@CommentDate", SqlDbType.DateTime);
                param[3].Value = info.CommentDate;
                param[4] = new SqlParameter("@IsPublish", SqlDbType.Bit);
                param[4].Value = info.IsPublish;
                param[5] = new SqlParameter("@CommentID", SqlDbType.Int);
                param[5].Value = info.CommentID;
                SqlHelper.ExecuteNonQuery(conn
                                          , cmd
                                          , @"update ProductComments set ProductID=@ProductID,MemberID=@MemberID,CommentContent=@CommentContent,
                                            IsPublish=@IsPublish where CommentID=@CommentID"
                                          , param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("ProductCommentsInfo update err: " + ex.Message);
                return false;
            }
        }
        public bool Delete(string CommentID)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(conn, cmd, string.Format("delete from ProductComments where CommentID in ({0})", CommentID), null);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("ProductCommentsInfo delete err: " + ex.Message);
                return false;
            }
        }
    }
}
