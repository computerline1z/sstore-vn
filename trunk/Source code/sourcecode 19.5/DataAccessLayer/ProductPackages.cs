using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Logger;
using BusinessObjects;
using Utilities;


namespace DataAccessLayer
{
    public class ProductPackages
    {
        private static ProductPackagesInfo createObj(SqlDataReader dr)
        {
            try
            {
                ProductPackagesInfo intro = new ProductPackagesInfo();
                intro.ProductID = SqlObject.getString(dr, 0);
                intro.PackageID = SqlObject.getInt32(dr, 1);
                return intro;
            }
            catch (Exception ex)
            {
                Log.error("ProductPackagesInfo createObj err: " + ex.Message);
                return null;
            }
        }
        private static ProductPackagesInfo createObj2(SqlDataReader dr)
        {
            try
            {
                ProductPackagesInfo intro = new ProductPackagesInfo();
                intro.ProductID = SqlObject.getString(dr, 0);
                intro.PackageID = SqlObject.getInt32(dr, 1);
                intro.PackageName = SqlObject.getString(dr, 2);
                return intro;
            }
            catch (Exception ex)
            {
                Log.error("ProductPackagesInfo createObj err: " + ex.Message);
                return null;
            }
        }
        private static string conn = SqlHelper.ConnectionStringLocalTransaction;
        private CommandType cmd = CommandType.Text;
        public List<ProductPackagesInfo> GetByProductID(string ProductID)
        {
            try
            {
                List<ProductPackagesInfo> list=new List<ProductPackagesInfo>();
                SqlParameter param = new SqlParameter("@ProductID", SqlDbType.VarChar);
                param.Value = ProductID;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from ProductPackages where ProductID=@ProductID", param);
                int stt = 0;
                while (dr.Read())
                {
                    stt++;
                    list.Add(createObj(dr));
                }
                return list;
            }
            catch (Exception ex)
            {
                Log.error("ProductPackagesInfo GetByProductID err: " + ex.Message);
                return null;
            }
        }
        public List<ProductPackagesInfo> GetPackageByProductID(string ProductID)
        {
            try
            {
                List<ProductPackagesInfo> list = new List<ProductPackagesInfo>();
                SqlParameter param = new SqlParameter("@ProductID", SqlDbType.VarChar);
                param.Value = ProductID;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select pk.*, p.PackageName from ProductPackages pk, Package p where p.PackageID=pk.PackageID and pk.ProductID=@ProductID", param);
                int stt = 0;
                while (dr.Read())
                {
                    stt++;
                    list.Add(createObj2(dr));
                }
                return list;
            }
            catch (Exception ex)
            {
                Log.error("ProductPackagesInfo GetPackageByProductID err: " + ex.Message);
                return null;
            }
        }
        public bool Insert(ProductPackagesInfo info)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@ProductID", SqlDbType.VarChar);
                param[0].Value = info.ProductID;
                param[1] = new SqlParameter("@PackageID", SqlDbType.Int);
                param[1].Value = info.PackageID;

                SqlHelper.ExecuteNonQuery(conn, cmd, "insert into ProductPackages values(@ProductID,@PackageID)", param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("ProductPackagesInfo insert err: " + ex.Message);
                return false;
            }
        }
        public bool Delete(string ProducID)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@ProductID", SqlDbType.VarChar);
                param[0].Value = ProducID;

                SqlHelper.ExecuteNonQuery(conn, cmd, "delete from ProductPackages where ProductID=@ProductID", param);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("ProductPackagesInfo Delete err: " + ex.Message);
                return false;
            }
        }
    }
}
