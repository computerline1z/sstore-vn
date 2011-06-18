using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Logger;
using BusinessObjects;
using Utilities;

namespace DataAccessLayer
{
  public  class UserGroup
    {
      private string sql_getALL = "select ID, Name from UserGroup where ID!=1 and ID!=0";//ADMIN VA SUPER ADMIN KO DOC LEN
      private string sql_getALL_super = "select ID, Name from UserGroup where ID!=0";
      private string sql_getinfo = "select ID, Name from UserGroup where ID=@ID";
      private string sql_insert = "insert into UserGroup(Name) values (@Name) ";
      private string sql_delete = "delete from UserGroup where ID in ({0})";
      private string sql_update = " update UserGroup set Name=@Name where ID=@ID ";
      string sql_getMax = "select max(id) from UserGroup";

      private static UserGroupInfo createObject(SqlDataReader rdr, int stt)
        {
            try
            {
                int ID = SqlObject.getInt32(rdr, 0);
                string Name = SqlObject.getString(rdr, 1);

                UserGroupInfo ag = new UserGroupInfo(stt, ID, Name);
                return ag;
            }
            catch (Exception e)
            {
                Log.info("create object error: " + e.Message);
                return null;
            }
        }

        /// <summary>
        /// Them moi nhom nguoi dung
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public int insert(string Name)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Name", SqlDbType.NVarChar);
                param[0].Value = Name;

                return
                    SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_insert,
                                              param);

            }
            catch (Exception ex)
            {


                Log.info("them bi loi" + ex.Message);
                return -1;

            }
        }
        /// <summary>
        /// cap nhat nhom nguoi dugn
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public int update(string ID, string Name)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@ID", SqlDbType.Int);
                param[0].Value = ID;
                param[1] = new SqlParameter("@Name", SqlDbType.NVarChar);
                param[1].Value = Name;
                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_update, param);



            }
            catch (Exception ex)
            {

                Log.info("sua khong thanh cong" + ex.Message);
                return -1;
            }
        }
        /// <summary>
        /// xoa bang cac loai phan tich
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int delete(string ID)
        {
            try
            {
                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, String.Format(sql_delete, ID), null);
            }
            catch (Exception ex)
            {
                Log.info("xoa loi: " + ex.Message);
                return -1;
            }
        }
        /// <summary>
        /// lay toan bo danh sach nhom nguoi dung
        /// </summary>
        /// <returns></returns>
        public IList<UserGroupInfo> getAll()
        {
            IList<UserGroupInfo> ilist = new List<UserGroupInfo>();
            SqlDataReader rdr =
                SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_getALL, null);
            int stt = 0;
            while (rdr.Read())
            {
                stt++;
                UserGroupInfo ag = createObject(rdr, stt);
                ilist.Add(ag);
            }
            return ilist;
        }
      public IList<UserGroupInfo> getAllBySuper()
      {
          IList<UserGroupInfo> ilist = new List<UserGroupInfo>();
          SqlDataReader rdr =
              SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_getALL_super, null);
          int stt = 0;
          while (rdr.Read())
          {
              stt++;
              UserGroupInfo ag = createObject(rdr, stt);
              ilist.Add(ag);
          }
          return ilist;
      }
          /// <summary>
          /// chi tiet nhom nguoi dung
          /// </summary>
          /// <param name="id"></param>
          /// <returns></returns>
        public IList<UserGroupInfo> getInfo(string id)
        {
            SqlParameter param = new SqlParameter("@ID", SqlDbType.Int);
            param.Value = id;
            IList<UserGroupInfo> ilist = new List<UserGroupInfo>();
            SqlDataReader rdr =
                SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, sql_getinfo, param);

            while (rdr.Read())
            {

                UserGroupInfo ag = createObject(rdr,1);
                ilist.Add(ag);
            }
            return ilist;
        }
    }
}
