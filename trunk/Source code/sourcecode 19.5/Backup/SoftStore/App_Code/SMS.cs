//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data;
//using System.Data.SqlClient;
//using BusinessObjects;
//using DataAccessLayer;
//using Logger;
//using Utilities;
//namespace SoftStore.App_Code
//{
//    public class SMS
//    {
//        private string SQL_INSERT = "insert into Outgoings(Sender,Receiver,Message,SentDate,Status,Response) values(@Sender,@Receiver,@Message,@SentDate,@Status,@Response)";
//        public int SentToPlatform(string Sender, string Receiver, string MessageContent, int Status, string Response)
//        {
//            try
//            {
//                SqlParameter[] param = new SqlParameter[6];
//                param[0] = new SqlParameter("@Sender", SqlDbType.VarChar);
//                param[0].Value = Sender;
//                param[1] = new SqlParameter("@Receiver", SqlDbType.VarChar);
//                param[1].Value = Receiver;
//                param[2] = new SqlParameter("@Message", SqlDbType.VarChar);
//                param[2].Value = MessageContent;
//                param[3] = new SqlParameter("@Response", SqlDbType.VarChar);
//                param[3].Value = Response;
//                param[4] = new SqlParameter("@SentDate", SqlDbType.DateTime);
//                param[4].Value = DateTime.Now;
//                param[5] = new SqlParameter("@Status", SqlDbType.Int);
//                param[5].Value = Status;
//                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionSMSGateway, CommandType.Text, SQL_INSERT, param);
//            }
//            catch (Exception ex)
//            {
//                Log.error("SMS sentToPlatform err: " + ex.Message);
//                return 0;
//            }
//        }
//        private string SQL_INSERT_SMSAPP_MTS = "insert into MTS(Sender,Receiver,MessageContent,SentDate,Status,MOPID,MTIDInPlatform,Comment,UserID)"
//           + " values(@Sender,@Receiver,@MessageContent,@SentDate,@Status,@MOPID,@MTIDInPlatform,@Comment,@UserID)";

//        public int InsertMTs(string Sender, string Receiver, string MessageContent, string Comment, int MOPID, int MTIDInPlatform, int Status, int userID)
//        {
//            try
//            {
//                SqlParameter[] param = new SqlParameter[10];
//                param[0] = new SqlParameter("@Sender", SqlDbType.VarChar);
//                param[0].Value = Sender;
//                param[1] = new SqlParameter("@Receiver", SqlDbType.VarChar);
//                param[1].Value = Receiver;
//                param[3] = new SqlParameter("@MessageContent", SqlDbType.VarChar);
//                param[3].Value = MessageContent;
//                param[4] = new SqlParameter("@Comment", SqlDbType.VarChar);
//                param[4].Value = Comment;
//                param[5] = new SqlParameter("@MOPID", SqlDbType.Int);
//                param[5].Value = MOPID;
//                param[6] = new SqlParameter("@MTIDInPlatform", SqlDbType.Int);
//                param[6].Value = MTIDInPlatform;
//                param[7] = new SqlParameter("@SentDate", SqlDbType.DateTime);
//                param[7].Value = DateTime.Now;
//                param[8] = new SqlParameter("@Status", SqlDbType.Int);
//                param[8].Value = Status;
//                param[9] = new SqlParameter("@UserID", SqlDbType.Int);
//                param[9].Value = userID;
//                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionSMSApp, CommandType.Text, SQL_INSERT_SMSAPP_MTS, param);
//            }
//            catch (Exception ex)
//            {
//                Log.error("SMS InsertMTs err: " + ex.Message);
//                return 0;
//            }
//        }

//        public int InsertViettel1900(string Sender, string Receiver, string Message, int Status, int CustomerID, int ServiceID)
//        {
//            try
//            {
//                string sql = "insert into SMSOutgoings(Sender,Receiver,Message,SentDateTime,Status,Response,CustomerId,ServiceId,AdvertisementContentId)"
//                + " values(@Sender,@Receiver,@Message,@SentDateTime,@Status,@Response,@CustomerId,@ServiceId,@AdvertisementContentId)";
//                SqlParameter[] param = new SqlParameter[9];
//                param[0] = new SqlParameter("@Sender", SqlDbType.VarChar);
//                param[0].Value = Sender;
//                param[1] = new SqlParameter("@Receiver", SqlDbType.VarChar);
//                param[1].Value = Receiver;
//                param[2] = new SqlParameter("@Message", SqlDbType.VarChar);
//                param[2].Value = Message;
//                param[3] = new SqlParameter("@SentDateTime", SqlDbType.DateTime);
//                param[3].Value = DateTime.Now;
//                param[4] = new SqlParameter("@Status", SqlDbType.Int);
//                param[4].Value = Status;
//                param[5] = new SqlParameter("@CustomerID", SqlDbType.Int);
//                param[5].Value = CustomerID;
//                param[6] = new SqlParameter("@ServiceID", SqlDbType.Int);
//                param[6].Value = ServiceID;
//                param[7] = new SqlParameter("@AdvertisementContentId", SqlDbType.Int);
//                param[7].Value = 0;
//                param[8] = new SqlParameter("@Response", SqlDbType.VarChar);
//                param[8].Value = ConfigSMS.RandomResponseViettel();
//                return SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionSMSSystemViettel, CommandType.Text, sql, param);
//            }
//            catch (Exception ex)
//            {
//                Log.error("SMS InsertViettel1900 err: " + ex.Message);
//                return 0;
//            }
//        }
//    }
//    public class ConfigSMS
//    {
//        public static string RandomResponse()
//        {

//            Random Rand = new Random();
//            // Create a new random number between the specified range    
//            int RandNum = Rand.Next(10000000, 99999999);
//            return RandNum.ToString();
//        }
//        public static string RandomResponseViettel()
//        {

//            Random Rand = new Random();
//            // Create a new random number between the specified range    
//            int RandNum = Rand.Next(100000000, 999999999);
//            return RandNum.ToString();
//        }
//        public static string SMSContent
//        {
//            get
//            {
//                return ConfigurationManager.AppSettings["SmsContent"].ToString();
//            }
//        }

//        public static string Password
//        {
//            get
//            {
//                return ConfigurationManager.AppSettings["PASSWORD_SMS"].ToString();
//            }
//        }
//        public static string UserName
//        {
//            get
//            {
//                return ConfigurationManager.AppSettings["USERNAME_SMS"].ToString();
//            }
//        }
//        public static string ConnectionActiveCode
//        {
//            get
//            {
//                return ConfigurationManager.ConnectionStrings["ConnectionActiveCode"].ToString();
//            }
//        }
//    }
//    public class CheckActiveCode
//    {
//        public static bool Check(string activecode)
//        {
//            SqlConnection conn = new SqlConnection(ConfigSMS.ConnectionActiveCode);
//            try
//            {
//                string update = "Select ActiveCode from IMSActiveCode where ActiveCode='" + activecode + "' and IsUsed=0";
//                conn.Open();
//                SqlDataAdapter ad = new SqlDataAdapter(update, conn);
//                DataTable dt=new DataTable();
//                ad.Fill(dt);
//                conn.Close();
//                if (dt.Rows.Count > 0)
//                    return true;
//                return false;
//            }
//            catch (Exception ex)
//            {
//                conn.Close();
//                Log.error("CheckActiveCode Check err:" + ex.Message);
//                return false;
//            }
            
//        }
//        public static bool UpdateStatus(string activecode)
//        {
//            SqlConnection conn = new SqlConnection(ConfigSMS.ConnectionActiveCode);
//            try
//            {
//                string update = "Update IMSActiveCode set IsUsed=1 where ActiveCode='" + activecode + "'";
//                conn.Open();
//                SqlCommand cmd = new SqlCommand(update, conn);
//                int i = cmd.ExecuteNonQuery();
//                conn.Close();
//                if(i>0)
//                    return true;
//                return false;
//            }
//            catch (Exception ex)
//            {
//                conn.Close();
//                Log.error("CheckActiveCode UpdateStatus err:"+ex.Message);
//                return false;
//            }
            
//        }
        
//    }
//}
