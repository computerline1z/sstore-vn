using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Logger;
using BusinessObjects;
using Utilities;

namespace DataAccessLayer
{
    public class Users
    {
        private string SQL_CHECK_LOGIN = "select * from Users where  UserName=@UserName and Password=@Password AND StatusID>0";
        private string SQL_GETINFO = "select * from Users where ID=@ID";
        private string SQL_GETLIST = "select * from Users where GroupID!=0 order by CreatedDate ASC";
        private string SQL_INSERT = "insert into Users(FullName, Address, Phone, Mobile, Email, Description, UserName, Password, GroupID, StatusID, CreatedDate, LastLogin)"
           + " values(@FullName, @Address, @Phone, @Mobile, @Email, @Description, @UserName, @Password, @GroupID, @StatusID, @CreatedDate, @LastLogin)";
        private string SQL_UPDATE = "update Users set FullName=@FullName, Address=@Address, Phone=@Phone, Mobile=@Mobile, Email=@Email, Description=@Description, "
           + " GroupID=@GroupID, StatusID=@StatusID where ID=@ID";
        private string SQL_UPDATE_USER = "update Users set FullName=@FullName, Address=@Address, Phone=@Phone, Mobile=@Mobile, Email=@Email where ID=@ID";
        private string SQL_DELETE = "delete from Users where ID in ({0})";
        private string SQL_UPDATE_LOGINTIME = "update Users set LastLogin=@time where ID=@ID";
        private string SQL_CHANGEPASS = "update Users set Password=@pass where ID=@ID ";
        private string SQL_CHECK_OLDPASS = "select ID from Users where ID=@ID and Password=@oldpass";



        private static UsersInfo createObjs(SqlDataReader rdr, int stt)
        {
            try
            {
                UsersInfo info=new UsersInfo();
                info.STT = stt;
                info.ID = SqlObject.getInt32(rdr, 0);
                info.FullName = SqlObject.getString(rdr, 1);
                info.Address = SqlObject.getString(rdr, 2);
                info.Phone = SqlObject.getString(rdr, 3);
                info.Mobile = SqlObject.getString(rdr, 4);
                info.Email = SqlObject.getString(rdr, 5);
                info.Description = SqlObject.getString(rdr, 6);
                info.UserName = SqlObject.getString(rdr, 7);
                info.Password = SqlObject.getString(rdr, 8);
                info.GroupID = SqlObject.getInt32(rdr, 9);
                info.StatusID = SqlObject.getBool(rdr, 10);
                info.CreatedDate = SqlObject.getDateTime(rdr, 11);
                info.LastLogin = SqlObject.getDateTime(rdr, 12);
                return info;
            }
            catch (Exception ex)
            {
                Log.info("Users createObjs error: " + ex.Message);
                return null;
            }
        }
        public UsersInfo CheckLogin(string username, string pass)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@UserName", SqlDbType.VarChar);
                param[0].Value = username;
                param[1] = new SqlParameter("@Password", SqlDbType.VarChar);
                param[1].Value = pass;
                SqlDataReader rdr =
                    SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text,
                                            SQL_CHECK_LOGIN, param);
                
                while (rdr.Read())
                {
                    return createObjs(rdr, 1);
                }
                return null;
            }
            catch (Exception ex)
            {
                Log.info("checkLogin error: " + ex.Message);
                return null;
            }
        }

        public string checkOldPass(string userid, string oldpass)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@ID", SqlDbType.Int);
                param[0].Value = userid;
                param[1] = new SqlParameter("@oldpass", SqlDbType.VarChar);
                param[1].Value = oldpass;
                DataTable dt =
                    SqlHelper.ExecuteDataset(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text,
                                             SQL_CHECK_OLDPASS, param).Tables[0];
                return dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                Log.info("checkOldPass error: " + ex.Message);
                return null;
            }
        }
        /// <summary>
        /// danh sach nguoi dung he thong
        /// </summary>
        /// <returns></returns>
        public List<UsersInfo> GetList()
        {
            try
            {
                List<UsersInfo> ilist = new List<UsersInfo>();
                SqlDataReader rdr =
                    SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_GETLIST,
                                            null);
                int stt = 0;
                while (rdr.Read())
                {
                    stt++;
                    UsersInfo user = createObjs(rdr, stt);
                    ilist.Add(user);
                }
                return ilist;
            }
            catch (Exception ex)
            {
                Log.info("GetList error: " + ex.Message);
                return null;
            }
        }
        /// <summary>
        /// thong tin 1 user
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public UsersInfo GetByID(string UserID)
        {
            try
            {
                IList<UsersInfo> ilist = new List<UsersInfo>();
                SqlParameter param = new SqlParameter("@ID", SqlDbType.Int);
                param.Value = UserID;
                SqlDataReader rdr =
                    SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_GETINFO,
                                            param);

                while (rdr.Read())
                {
                    return createObjs(rdr,1);
                }
                return null;
            }
            catch (Exception ex)
            {
                Log.info("getInfo error: " + ex.Message);
                return null;
            }
        }
        public int insert(UsersInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[12];
                param[0] = new SqlParameter("@FullName", SqlDbType.NVarChar);
                param[0].Value = info.FullName;
                param[1] = new SqlParameter("@Address", SqlDbType.NVarChar);
                param[1].Value = info.Address;
                param[2] = new SqlParameter("@Phone", SqlDbType.NVarChar);
                param[2].Value = info.Phone;
                param[3] = new SqlParameter("@Mobile", SqlDbType.NVarChar);
                param[3].Value = info.Mobile;
                param[4] = new SqlParameter("@Email", SqlDbType.NVarChar);
                param[4].Value = info.Email;
                param[5] = new SqlParameter("@Description", SqlDbType.NVarChar);
                param[5].Value = info.Description;
                param[6] = new SqlParameter("@UserName", SqlDbType.VarChar);
                param[6].Value = info.UserName;
                param[7] = new SqlParameter("@Password", SqlDbType.VarChar);
                param[7].Value = info.Password;
                param[8] = new SqlParameter("@GroupID", SqlDbType.Int);
                param[8].Value = info.GroupID;
                param[9] = new SqlParameter("@StatusID", SqlDbType.Bit);
                param[9].Value = info.StatusID;
                param[10] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                param[10].Value = DateTime.Now;
                param[11] = new SqlParameter("@LastLogin", SqlDbType.DateTime);
                param[11].Value = DateTime.Now;

                return
                    SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_INSERT,
                                              param);
            }
            catch (Exception ex)
            {
                Log.info("Users insert error: " + ex.Message);
                return -1;
            }
        }

        public int update(UsersInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[9];
                param[0] = new SqlParameter("@ID", SqlDbType.Int);
                param[0].Value = info.ID;
                param[1] = new SqlParameter("@FullName", SqlDbType.NVarChar);
                param[1].Value = info.FullName;
                param[2] = new SqlParameter("@Address", SqlDbType.NVarChar);
                param[2].Value = info.Address;
                param[3] = new SqlParameter("@Phone", SqlDbType.NVarChar);
                param[3].Value = info.Phone;
                param[4] = new SqlParameter("@Mobile", SqlDbType.NVarChar);
                param[4].Value = info.Mobile;
                param[5] = new SqlParameter("@Email", SqlDbType.NVarChar);
                param[5].Value = info.Email;
                param[6] = new SqlParameter("@Description", SqlDbType.NVarChar);
                param[6].Value = info.Description;
                param[7] = new SqlParameter("@GroupID", SqlDbType.Int);
                param[7].Value = info.GroupID;
                param[8] = new SqlParameter("@StatusID", SqlDbType.Bit);
                param[8].Value = info.StatusID;

                return
                    SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_UPDATE,
                                              param);
            }
            catch (Exception ex)
            {
                Log.info("update error: " + ex.Message);
                return -1;
            }
        }
        public int updateUser(UsersInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@ID", SqlDbType.Int);
                param[0].Value = info.ID;
                param[1] = new SqlParameter("@FullName", SqlDbType.NVarChar);
                param[1].Value = info.FullName;
                param[2] = new SqlParameter("@Address", SqlDbType.NVarChar);
                param[2].Value = info.Address;
                param[3] = new SqlParameter("@Phone", SqlDbType.NVarChar);
                param[3].Value = info.Phone;
                param[4] = new SqlParameter("@Mobile", SqlDbType.NVarChar);
                param[4].Value = info.Mobile;
                param[5] = new SqlParameter("@Email", SqlDbType.NVarChar);
                param[5].Value = info.Email;


                return
                    SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_UPDATE_USER,
                                              param);
            }
            catch (Exception ex)
            {
                Log.info("updateUser error: " + ex.Message);
                return -1;
            }
        }
        public int delete(string ids)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, String.Format(SQL_DELETE, ids), null);
                return 1;
            }
            catch (Exception ex)
            {
                Log.info("Users delete error: " + ex.Message);
                return -1;
            }
        }
        /// <summary>
        /// ghi nhan thoi gian use login cuoi cung
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public int updateLogin(string userid, string time)
        {

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@time", SqlDbType.DateTime);
            param[0].Value = time;
            param[1] = new SqlParameter("@ID", SqlDbType.Int);
            param[1].Value = userid;
            return
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text,
                                          SQL_UPDATE_LOGINTIME, param);
        }
        /// <summary>
        /// doi pass cua nguoi dung!!!!
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public int changePass(string userid, string pass)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@ID", SqlDbType.Int);
                param[0].Value = userid;
                param[1] = new SqlParameter("@pass", SqlDbType.VarChar);
                param[1].Value = pass;

                return
                    SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text,
                                              SQL_CHANGEPASS, param);
            }
            catch (Exception ex)
            {
                Log.info("Users changePass error: " + ex.Message);
                return 0;
            }
        }
        public static string GetFullName(object ID)
        {
            try
            {
                object obj =
                    SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text,
                                            "select FullName from Users where ID="+ID);
                return obj.ToString();
            }
            catch (Exception ex)
            {
                Log.info("Users GetFullName error: " + ex.Message);
                return null;
            }
        }
    }
}
