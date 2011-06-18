using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Logger;
using BusinessObjects;
using Utilities;

namespace DataAccessLayer
{
    public class SMTPMail
    {
        public SMTPMailInfo GetInfo()
        {
            try
            {
                SqlDataReader dr =
                    SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text,
                                            "select * from SMTPMail", null);
                while(dr.Read())
                {
                    SMTPMailInfo info=new SMTPMailInfo();
                    info.SMTP = dr.GetString(0);
                    info.MailAddress = dr.GetString(1);
                    info.UserName = dr.GetString(2);
                    info.Password = dr.GetString(3);
                    return info;
                }
                return null;
            }
            catch(Exception ex)
            {
                Log.error("GetInfo err: " + ex.Message);
                return null;
            }
        }
        public bool Update(SMTPMailInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@SMTP", SqlDbType.NVarChar);
                param[0].Value = info.SMTP;
                param[1] = new SqlParameter("@MailAddress", SqlDbType.NVarChar);
                param[1].Value = info.MailAddress;
                param[2] = new SqlParameter("@UserName", SqlDbType.NVarChar);
                param[2].Value = info.UserName;
                param[3] = new SqlParameter("@Password", SqlDbType.NVarChar);
                param[3].Value = info.Password;

                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text
                    , "update SMTPMail set SMTP=@SMTP,MailAddress=@MailAddress,UserName=@UserName,Password=@Password", param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("SMTPMailInfo Update err: " + ex.Message);
                return false;
            }
        }
    }
}
