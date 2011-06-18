using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Logger;
using BusinessObjects;
using Utilities;
namespace DataAccessLayer
{
    public class Members
    {
        private static MembersInfo createObj(SqlDataReader dr, int stt)
        {
            try
            {
                MembersInfo fbi = new MembersInfo();
                fbi.STT = stt;
                fbi.MemberID = SqlObject.getInt32(dr, 0);
                fbi.FullName = SqlObject.getString(dr, 1);
                fbi.UserName = SqlObject.getString(dr, 2);
                fbi.Password = SqlObject.getString(dr, 3);
                fbi.Address = SqlObject.getString(dr, 4);
                fbi.Phone = SqlObject.getString(dr, 5);
                fbi.Mobile = SqlObject.getString(dr, 6);
                fbi.Email = SqlObject.getString(dr, 7);
                fbi.RegisteredDate = SqlObject.getDateTime(dr, 8);
                fbi.LastLogin = SqlObject.getDateTime(dr, 9);
                fbi.Status = SqlObject.getBool(dr, 10);
                fbi.Avatar = SqlObject.getString(dr, 11);
                return fbi;
            }
            catch (Exception ex)
            {
                Log.error("Members createObj err: " + ex.Message);
                return null;
            }
        }
        private static string conn = SqlHelper.ConnectionStringLocalTransaction;
        private CommandType cmd = CommandType.Text;
        public MembersInfo GetByMemberID(int MemberID)
        {
            try
            {
                SqlParameter param = new SqlParameter("@MemberID", SqlDbType.Int);
                param.Value = MemberID;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from Members where MemberID=@MemberID", param);
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
                Log.error("MembersInfo getByMemberID err: " + ex.Message);
                return null;
            }
        }
        public MembersInfo CheckLogin(string UserName, string Password)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@UserName", SqlDbType.VarChar);
                param[0].Value = UserName;
                param[1] = new SqlParameter("@Password", SqlDbType.VarChar);
                param[1].Value = Password;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from Members where UserName=@UserName and Password=@Password and Status=1", param);
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
                Log.error("MembersInfo CheckLogin err: " + ex.Message);
                return null;
            }
        }
        public List<MembersInfo> GetList()
        {
            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from Members order by RegisteredDate DESC", null);
                List<MembersInfo> list = new List<MembersInfo>();
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
                Log.error("IList<MembersInfo> getList err: " + ex.Message);
                return null;
            }
        }
        public bool MemberUpdate(MembersInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@FullName", SqlDbType.NVarChar);
                param[0].Value = info.FullName;
                param[1] = new SqlParameter("@Address", SqlDbType.NVarChar);
                param[1].Value = info.Address;
                param[2] = new SqlParameter("@Phone", SqlDbType.NVarChar);
                param[2].Value = info.Phone;
                param[3] = new SqlParameter("@Email", SqlDbType.NVarChar);
                param[3].Value = info.Email;
                param[4] = new SqlParameter("@MemberID", SqlDbType.Int);
                param[4].Value = info.MemberID;
                param[5] = new SqlParameter("@Avatar", SqlDbType.NVarChar);
                param[5].Value = info.Avatar;
                param[6] = new SqlParameter("@Mobile", SqlDbType.NVarChar);
                param[6].Value = info.Mobile;
                SqlHelper.ExecuteNonQuery(conn, cmd, "update Members set Mobile=@Mobile,Avatar=@Avatar,FullName=@FullName,Address=@Address,Phone=@Phone,Email=@Email where MemberID=@MemberID", param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("Members insert err: " + ex.Message);
                return false;
            }
        }
        public bool Update(MembersInfo info)
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
                param[4] = new SqlParameter("@Email", SqlDbType.NVarChar);
                param[4].Value = info.Email;
                param[5] = new SqlParameter("@UserName", SqlDbType.VarChar);
                param[5].Value = info.UserName;
                param[6] = new SqlParameter("@Avatar", SqlDbType.NVarChar);
                param[6].Value = info.Avatar;
                param[7] = new SqlParameter("@Status", SqlDbType.Bit);
                param[7].Value = info.Status;
                param[8] = new SqlParameter("@MemberID", SqlDbType.Int);
                param[8].Value = info.MemberID;
                SqlHelper.ExecuteNonQuery(conn, cmd, "update Members set Avatar=@Avatar,FullName=@FullName,Address=@Address,Phone=@Phone,Mobile=@Mobile,Email=@Email,UserName=@UserName,Status=@Status where MemberID=@MemberID", param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("Members insert err: " + ex.Message);
                return false;
            }
        }
        public bool Insert(MembersInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[10];
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
                param[5] = new SqlParameter("@UserName", SqlDbType.VarChar);
                param[5].Value = info.UserName;
                param[6] = new SqlParameter("@Password", SqlDbType.VarChar);
                param[6].Value = info.Password;
                param[7] = new SqlParameter("@Status", SqlDbType.Bit);
                param[7].Value = info.Status;
                param[8] = new SqlParameter("@RegisteredDate", SqlDbType.DateTime);
                param[8].Value = info.RegisteredDate;
                param[9] = new SqlParameter("@Avatar", SqlDbType.NVarChar);
                param[9].Value = info.Avatar;
                SqlHelper.ExecuteNonQuery(conn, cmd, "insert into Members(Avatar,FullName,Address,Phone,Mobile,Email,UserName,Password,Status,RegisteredDate)"
            + " values(@Avatar,@FullName,@Address,@Phone,@Mobile,@Email,@UserName,@Password,@Status,@RegisteredDate)", param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("Members insert err: " + ex.Message);
                return false;
            }
        }
        public bool Delete(string MemberID)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(conn, cmd, string.Format("delete from Members where MemberID in ({0})", MemberID), null);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("Members delete err: " + ex.Message);
                return false;
            }
        }
        public int ChangePass(string id, string newpass)
        {

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@newpass", SqlDbType.DateTime);
            param[0].Value = newpass;
            param[1] = new SqlParameter("@MemberID", SqlDbType.Int);
            param[1].Value = id;
            return
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text,
                                          "update Members set Password=@newpass where MemberID=@MemberID", param);
        }
    }
}
