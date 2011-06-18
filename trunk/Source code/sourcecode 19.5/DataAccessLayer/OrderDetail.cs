using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Logger;
using BusinessObjects;
using Utilities;

namespace DataAccessLayer
{
    public class OrderDetail
    {
        private static OrderDetailInfo createObj(SqlDataReader dr, int stt)
        {
            try
            {
                OrderDetailInfo info = new OrderDetailInfo();
                info.STT = stt;
                info.ID = SqlObject.getInt32(dr, 0);
                info.OrderID = SqlObject.getString(dr, 1);
                info.ProductID = SqlObject.getString(dr, 2);
                info.Amount = SqlObject.getInt32(dr, 3);
                info.Price = SqlObject.getInt64(dr, 4);
                info.PackageID = SqlObject.getInt32(dr, 5);
                return info;
            }
            catch (Exception ex)
            {
                Log.error("OrderDetailInfo createObj err: " + ex.Message);
                return null;
            }
        }
        private static string conn = SqlHelper.ConnectionStringLocalTransaction;
        private CommandType cmd = CommandType.Text;
        public OrderDetailInfo GetByID(int ID)
        {
            try
            {
                SqlParameter param = new SqlParameter("@ID", SqlDbType.Int);
                param.Value = ID;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from OrderDetail where ID=@ID", param);
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
                Log.error("OrderDetailInfo getByID err: " + ex.Message);
                return null;
            }
        }
        public List<OrderDetailInfo> GetList(string OrderID)
        {
            try
            {
                SqlParameter param = new SqlParameter("@OrderID", SqlDbType.VarChar);
                param.Value = OrderID;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from OrderDetail where OrderID=@OrderID", param);
                List<OrderDetailInfo> list = new List<OrderDetailInfo>();
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
                Log.error("List<OrderDetailInfo> getList err: " + ex.Message);
                return null;
            }
        }
    }
}
