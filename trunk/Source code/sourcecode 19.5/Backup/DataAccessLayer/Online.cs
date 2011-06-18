using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using Mode;
using Utilities;

namespace Control
{
    public class Online
    {
        private string SQL_GETALL = "select ID, Online, Total from Online";
        private string SQL_UPDATE = "update Online set Total=Total+1 where ID=1";

        private static OnlineInfo createObject(SqlDataReader rdr)
        {
            try
            {
                int id = SqlObject.getInt32(rdr, 0);
                int online = SqlObject.getInt32(rdr, 1);
                int total = SqlObject.getInt32(rdr, 2);
                return new OnlineInfo(id, online, total);
            }
            catch(Exception ex)
            {
                Logger.Log.info("createObject err: "+ex.Message);
                return null;
            }
        }
        public IList<OnlineInfo> getAll()
        {
            SqlDataReader rdr =
                SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_GETALL, null);
            IList<OnlineInfo> list = new List<OnlineInfo>();
            while(rdr.Read())
            {
                OnlineInfo uol = createObject(rdr);
                list.Add(uol);
            }
            return list;
        }
        public int update()
        {
            return
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_UPDATE, null);
        }
    }
}
