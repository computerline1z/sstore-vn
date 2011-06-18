using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Logger;
using BusinessObjects;
using Utilities;

namespace DataAccessLayer
{
    public class Package
    {
        private string SQL_GETLIST = "select * from Package order by PackageName ASC";
        private string SQL_GETLIST_BYSTATUS = "select * from Package where Status=@Status order by PackageName ASC";
        private string SQL_GETBYID = "select * from Package where PackageID=@PackageID";
        private string SQL_INSERT = "insert into Package(PackageName, Description, Status, CreatedDate) values(@PackageName, @Description, @Status,@CreatedDate)";
        private string SQL_UPDATE = "update Package set PackageName=@PackageName,Description=@Description where PackageID=@PackageID";
        private string SQL_DEL = "delete from Package where PackageID in ({0})";

        private static PackageInfo createObj(SqlDataReader dr, int stt)
        {
            try
            {
                PackageInfo intro = new PackageInfo();
                intro.STT = stt;
                intro.PackageID = SqlObject.getInt32(dr, 0);
                intro.PackageName = SqlObject.getString(dr, 1);
                intro.Description = SqlObject.getString(dr, 2);
                intro.Status = SqlObject.getBool(dr, 3);
                intro.CreatedDate = SqlObject.getDateTime(dr, 4);
                return intro;
            }
            catch (Exception ex)
            {
                Log.error("PackageInfo createObj err: " + ex.Message);
                return null;
            }
        }
        private static string conn = SqlHelper.ConnectionStringLocalTransaction;
        private CommandType cmd = CommandType.Text;
        public PackageInfo GetByID(int PackageID)
        {
            try
            {
                SqlParameter param = new SqlParameter("@PackageID", SqlDbType.Int);
                param.Value = PackageID;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, SQL_GETBYID, param);
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
                Log.error("PackageInfo getByID err: " + ex.Message);
                return null;
            }
        }
        public List<PackageInfo> GetList()
        {
            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, SQL_GETLIST, null);
                List<PackageInfo> list = new List<PackageInfo>();
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
                Log.error("List<PackageInfo> getList err: " + ex.Message);
                return null;
            }
        }
        public List<PackageInfo> GetList(bool Status)
        {
            try
            {
                SqlParameter param = new SqlParameter("@Status", SqlDbType.Int);
                param.Value = Status;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, SQL_GETLIST_BYSTATUS, param);
                List<PackageInfo> list = new List<PackageInfo>();
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
                Log.error("List<PackageInfo> getList err: " + ex.Message);
                return null;
            }
        }
        public bool Insert(PackageInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@PackageName", SqlDbType.NVarChar);
                param[0].Value = info.PackageName;
                param[1] = new SqlParameter("@Status", SqlDbType.Bit);
                param[1].Value = info.Status;
                param[2] = new SqlParameter("@Description", SqlDbType.NVarChar);
                param[2].Value = info.Description;
                param[3] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                param[3].Value = info.CreatedDate;
                SqlHelper.ExecuteNonQuery(conn, cmd, SQL_INSERT, param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("PackageInfo insert err: " + ex.Message);
                return false;
            }
        }
        public bool Update(PackageInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@PackageName", SqlDbType.NVarChar);
                param[0].Value = info.PackageName;
                param[1] = new SqlParameter("@Status", SqlDbType.Bit);
                param[1].Value = info.Status;
                param[2] = new SqlParameter("@Description", SqlDbType.NVarChar);
                param[2].Value = info.Description;
                param[3] = new SqlParameter("@PackageID", SqlDbType.Int);
                param[3].Value = info.PackageID;
                SqlHelper.ExecuteNonQuery(conn, cmd, SQL_UPDATE, param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("PackageInfo update err: " + ex.Message);
                return false;
            }
        }
        public bool Delete(string PackageID)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(conn, cmd, string.Format(SQL_DEL, PackageID), null);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("PackageInfo delete err: " + ex.Message);
                return false;
            }
        }
    }
}

