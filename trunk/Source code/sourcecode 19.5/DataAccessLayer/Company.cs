using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Logger;
using BusinessObjects;
using Utilities;

namespace DataAccessLayer
{
    public class Company
    {
        private static CompanyInfo createObj(SqlDataReader dr)
        {
            try
            {
                CompanyInfo info=new CompanyInfo();
                info.CompanyName = SqlObject.getString(dr, 0);
                info.CompanyNameEn = SqlObject.getString(dr, 1);
                info.Address = SqlObject.getString(dr, 2);
                info.Phone = SqlObject.getString(dr, 3);
                info.Fax = SqlObject.getString(dr, 4);
                info.HotLine = SqlObject.getString(dr, 5);
                info.Email = SqlObject.getString(dr, 6);
                info.Website = SqlObject.getString(dr, 7);
                info.Map = SqlObject.getString(dr, 8);
                info.MoreContent = SqlObject.getString(dr, 9);
                return info;
            }
            catch (Exception ex)
            {
                Log.error("Company createObj err: " + ex.Message);
                return null;
            }
        }
        private static string conn = SqlHelper.ConnectionStringLocalTransaction;
        private CommandType cmd = CommandType.Text;
        public CompanyInfo GetCompanyInfo()
        {
            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from Company", null);
                while (dr.Read())
                    return createObj(dr);
                return null;
            }
            catch (Exception ex)
            {
                Log.error("Company getCompanyInfo err: " + ex.Message);
                return null;
            }
        }
        public bool Update(CompanyInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[10];
                param[0] = new SqlParameter("@CompanyName", SqlDbType.NVarChar);
                param[0].Value = info.CompanyName;
                param[1] = new SqlParameter("@CompanyNameEn", SqlDbType.NVarChar);
                param[1].Value = info.CompanyNameEn;
                param[2] = new SqlParameter("@Address", SqlDbType.NVarChar);
                param[2].Value = info.Address;
                param[3] = new SqlParameter("@Map", SqlDbType.NVarChar);
                param[3].Value = info.Map;
                param[4] = new SqlParameter("@Fax", SqlDbType.NVarChar);
                param[4].Value = info.Fax;
                param[5] = new SqlParameter("@Email", SqlDbType.NVarChar);
                param[5].Value = info.Email;
                param[6] = new SqlParameter("@Website", SqlDbType.NVarChar);
                param[6].Value = info.Website;
                param[7] = new SqlParameter("@Phone", SqlDbType.NVarChar);
                param[7].Value = info.Phone;
                param[8] = new SqlParameter("@MoreContent", SqlDbType.NText);
                param[8].Value = info.MoreContent;
                param[9] = new SqlParameter("@HotLine", SqlDbType.NVarChar);
                param[9].Value = info.HotLine;
                SqlHelper.ExecuteNonQuery(conn
                                          , cmd
                                          , @"update Company set CompanyName=@CompanyName,CompanyNameEn=@CompanyNameEn,HotLine=@HotLine,
                                            Address=@Address,Map=@Map,Fax=@Fax,Email=@Email,Website=@Website,Phone=@Phone,MoreContent=@MoreContent"
                                          , param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("CompanyInfo update err: " + ex.Message);
                return false;
            }
        }
    }
}
