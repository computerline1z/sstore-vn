using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Logger;
using BusinessObjects;
using Utilities;

namespace DataAccessLayer
{
    public class Orders
    {
        public static OrderInfo createObj(SqlDataReader dr, int stt)
        {
            OrderInfo obj = new OrderInfo();
            obj.STT = stt;
            obj.ID = SqlObject.getString(dr, 0);
            obj.CustomerName = SqlObject.getString(dr, 1);
            obj.CustomerAddress = SqlObject.getString(dr, 2);
            obj.CustomerPhone = SqlObject.getString(dr, 3);
            obj.CustomerEmail = SqlObject.getString(dr, 4);
            obj.ReceiveAddress = SqlObject.getString(dr, 5);
            obj.PaymentMethod = SqlObject.getInt32(dr, 6);
            obj.ReceiveMethod = SqlObject.getInt32(dr, 7);
            obj.Description = SqlObject.getString(dr, 8);
            obj.Status = SqlObject.getBool(dr, 9);
            obj.TotalPrice = SqlObject.getInt64(dr, 10);
            obj.OrderDate = SqlObject.getDateTime(dr, 11);
            obj.MemberID = SqlObject.getInt32(dr, 12);
            return obj;
        }
        private static string conn = SqlHelper.ConnectionStringLocalTransaction;
        private CommandType cmd = CommandType.Text;
        public OrderInfo GetByOrderID(string ID)
        {
            try
            {
                SqlParameter param = new SqlParameter("@ID", SqlDbType.VarChar);
                param.Value = ID;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from Orders where ID=@ID", param);
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
                Log.error("OrderInfo GetByOrderID err: " + ex.Message);
                return null;
            }
        }
        public List<OrderInfo> GetList()
        {
            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from Orders order by OrderDate DESC", null);
                List<OrderInfo> list = new List<OrderInfo>();
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
                Log.error("List<OrderInfo> getList err: " + ex.Message);
                return null;
            }
        }
        /// <summary>
        /// If MemberID null, set MemberID=-1
        /// </summary>
        /// <param name="order"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool Insert(OrderInfo order, List<OrderDetailInfo> list)
        {
            SqlConnection sqlConn=new SqlConnection(conn);
            sqlConn.Open();
            SqlTransaction trans = sqlConn.BeginTransaction();
            using (trans)
            {
                try
                {
                    SqlParameter[] param = new SqlParameter[13];
                    param[0] = new SqlParameter("@ID", SqlDbType.VarChar);
                    param[0].Value = order.ID;
                    param[1] = new SqlParameter("@CustomerName", SqlDbType.NVarChar);
                    param[1].Value = order.CustomerName;
                    param[2] = new SqlParameter("@CustomerAddress", SqlDbType.NVarChar);
                    param[2].Value = order.CustomerAddress;
                    param[3] = new SqlParameter("@CustomerPhone", SqlDbType.NVarChar);
                    param[3].Value = order.CustomerPhone;
                    param[4] = new SqlParameter("@CustomerEmail", SqlDbType.NVarChar);
                    param[4].Value = order.CustomerEmail;
                    param[5] = new SqlParameter("@PaymentMethod", SqlDbType.Int);
                    param[5].Value = order.PaymentMethod;
                    param[6] = new SqlParameter("@ReceiveMethod", SqlDbType.Int);
                    param[6].Value = order.ReceiveMethod;
                    param[7] = new SqlParameter("@ReceiveAddress", SqlDbType.NVarChar);
                    param[7].Value = order.ReceiveAddress;
                    param[8] = new SqlParameter("@Description", SqlDbType.NVarChar);
                    param[8].Value = order.Description;
                    param[9] = new SqlParameter("@Status", SqlDbType.Bit);
                    param[9].Value = order.Status;
                    param[10] = new SqlParameter("@TotalPrice", SqlDbType.BigInt);
                    param[10].Value = order.TotalPrice;
                    param[11] = new SqlParameter("@OrderDate", SqlDbType.DateTime);
                    param[11].Value = order.OrderDate;
                    param[12] = new SqlParameter("@MemberID", SqlDbType.Int);
                    param[12].Value = order.MemberID;
                    string sql =
                        @"insert into Orders values(@ID,@CustomerName,@CustomerAddress,@CustomerPhone,@CustomerEmail,
                            @ReceiveAddress,@PaymentMethod,@ReceiveMethod,@Description,@Status,@TotalPrice,@OrderDate,@MemberID)";

                    int kq = SqlHelper.ExecuteNonQuery(sqlConn, trans, cmd, sql, param);
                    if (kq > 0)
                    {
                        //insert detail
                        for(int i=0; i<list.Count; i++)
                        {
                            SqlParameter[] paramdetail = new SqlParameter[7];
                            paramdetail[1] = new SqlParameter("@OrderID", SqlDbType.VarChar);
                            paramdetail[1].Value = list[i].OrderID;
                            paramdetail[2] = new SqlParameter("@ProductID", SqlDbType.VarChar);
                            paramdetail[2].Value = list[i].ProductID;
                            paramdetail[3] = new SqlParameter("@Amount", SqlDbType.Int);
                            paramdetail[3].Value = list[i].Amount;
                            paramdetail[4] = new SqlParameter("@Price", SqlDbType.BigInt);
                            paramdetail[4].Value = list[i].Price;
                            paramdetail[5] = new SqlParameter("@PackageID", SqlDbType.Int);
                            paramdetail[5].Value = list[i].PackageID;

                            string sqldetail = "insert into OrderDetail(OrderID,ProductID,Amount,Price,PackageID) values(@OrderID,@ProductID,@Amount,@Price,@PackageID)";
                            int kq2 = SqlHelper.ExecuteNonQuery(sqlConn, trans, cmd, sqldetail, paramdetail);
                            if (kq2 <= 0)
                            {
                                trans.Rollback();
                                return false;
                            }
                        }
                    }
                    else
                    {
                        trans.Rollback();
                        return false;
                    }
                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    Log.error("Insert err: " + ex.Message);
                    return false;
                }
            }
        }
        public bool Delete(string OrderID)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(conn, cmd, string.Format("delete from OrderDetail where OrderID in ({0})", OrderID), null);
                SqlHelper.ExecuteNonQuery(conn, cmd, string.Format("delete from Orders where ID in ({0})", OrderID), null);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("Orders delete err: " + ex.Message);
                return false;
            }
        }
    }
}
