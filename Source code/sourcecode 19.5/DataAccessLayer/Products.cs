using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Logger;
using BusinessObjects;
using Utilities;

namespace DataAccessLayer
{
    public class Products
    {
        private static ProductsInfo createObj(SqlDataReader dr, int stt)
        {
            try
            {
                ProductsInfo info = new ProductsInfo();
                info.STT = stt;
                info.ProductID = SqlObject.getString(dr, 0);
                info.ProductName = SqlObject.getString(dr, 1);
                info.CategoryID = SqlObject.getInt32(dr, 2);
                info.ProviderID = SqlObject.getInt32(dr, 3);
                info.Icon = SqlObject.getString(dr, 4);
                info.Picture = SqlObject.getString(dr, 5);
                info.Price = SqlObject.getInt64(dr, 6);
                info.MarketPrice = SqlObject.getInt64(dr, 7);
                info.OriginalPrice = SqlObject.getInt64(dr, 8);
                info.Tax = SqlObject.getInt32(dr, 9);
                info.Ship = SqlObject.getString(dr, 10);
                info.Status = SqlObject.getByte(dr, 11);
                info.GuaranteeTime = SqlObject.getString(dr, 12);
                info.UpdateDate = SqlObject.getDateTime(dr, 13);
                info.ViewCount = SqlObject.getInt32(dr, 14);
                info.BuyCount = SqlObject.getInt32(dr, 15);
                info.ShortDescription = SqlObject.getString(dr, 16);
                info.DetailDescription = SqlObject.getString(dr, 17);
                info.TechDescription = SqlObject.getString(dr, 18);
                info.BonusPoint = SqlObject.getInt32(dr, 19);
                info.Tags = SqlObject.getString(dr, 20);
                info.IsReviewing = SqlObject.getBool(dr, 21);
                info.IsNew = SqlObject.getBool(dr, 22);
                info.IsHot = SqlObject.getBool(dr, 23);
                info.IsPublish = SqlObject.getBool(dr, 24);
                info.CreatedBy = SqlObject.getInt32(dr, 25);
                info.CreatedDate = SqlObject.getDateTime(dr, 26);
                info.IsSale = SqlObject.getBool(dr, 27);
                info.PublishedBy = SqlObject.getInt32(dr, 28);
                info.PublishedDate = SqlObject.getDateTime(dr, 29);
                
                //info.PromotionRate = SqlObject.getFloat(dr, 7);
                
                //info.PackageID = SqlObject.getInt32(dr, 9);
                //info.ReleaseDate = SqlObject.getDateTime(dr, 10);
               
                //info.LinkDownload = SqlObject.getString(dr, 12);
                
                
              
                /*Start get category list*/
                ProductCategory pc = new ProductCategory();
                info.CategoryList = pc.GetAllList(info.CategoryID);
                //Bind all path to category path end with / ex: PM-may-tinh/abc/
                info.CategoryPath = pc.GetCategoryPathWithUrlFriendly(info.CategoryID);
                /*End get category list*/
                //info.SubCategoryID = SqlObject.getInt32(dr, 19);
               
                
                return info;
            }
            catch (Exception ex)
            {
                Log.error("Products createObj err: " + ex.Message);
                return null;
            }
        }
        private static string conn = SqlHelper.ConnectionStringLocalTransaction;
        private CommandType cmd = CommandType.Text;
        public List<ProductsInfo> GetListProducts()
        {
            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from Products order by CreatedDate DESC", null);
                List<ProductsInfo> list = new List<ProductsInfo>();
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
                Log.error("Products GetListProducts err: " + ex.Message);
                return null;
            }
        }
        public List<ProductsInfo> GetListProductsByCatID(int CategoryID)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@CategoryID", SqlDbType.Int);
                param[0].Value = CategoryID;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select p.* from Products p, ProductCategory pc where p.CategoryID=pc.CategoryID and (p.CategoryID=@CategoryID or pc.ParentID=@CategoryID) order by p.CreatedDate DESC", param);
                List<ProductsInfo> list = new List<ProductsInfo>();
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
                Log.error("Products GetListProductsByCatID err: " + ex.Message);
                return null;
            }
        }
        public List<ProductsInfo> GetListProductsByCatID(int CategoryID, string OrderBy)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@CategoryID", SqlDbType.Int);
                param[0].Value = CategoryID;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select p.* from Products p, ProductCategory pc where p.CategoryID=pc.CategoryID and (p.CategoryID=@CategoryID or pc.ParentID=@CategoryID) order by " + OrderBy, param);
                List<ProductsInfo> list = new List<ProductsInfo>();
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
                Log.error("Products GetListProductsByCatID err: " + ex.Message);
                return null;
            }
        }
        public List<ProductsInfo> GetTopProductsByCatID(int CategoryID, string ProductIDNo)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@CategoryID", SqlDbType.Int);
                param[0].Value = CategoryID;
                param[1] = new SqlParameter("@ProductID", SqlDbType.VarChar);
                param[1].Value = ProductIDNo;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select top 6 * from Products where CategoryID=@CategoryID and ProductID!=@ProductID order by CreatedDate DESC", param);
                List<ProductsInfo> list = new List<ProductsInfo>();
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
                Log.error("Products GetListProductsByCatID err: " + ex.Message);
                return null;
            }
        }
        public List<ProductsInfo> GetListProducts(int BrandID)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@BrandID", SqlDbType.Int);
                param[0].Value = BrandID;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from Products where BrandID=@BrandID order by CreatedDate DESC", param);
                List<ProductsInfo> list = new List<ProductsInfo>();
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
                Log.error("Products GetListProducts err: " + ex.Message);
                return null;
            }
        }
        public List<ProductsInfo> GetListProductsPublished()
        {
            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from Products where IsPublish=1 order by PublishedDate DESC", null);
                List<ProductsInfo> list = new List<ProductsInfo>();
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
                Log.error("Products GetListProductsPublished err: " + ex.Message);
                return null;
            }
        }
        /// <summary>
        /// If top =-1, without top value
        /// </summary>
        /// <param name="column"></param>
        /// <param name="status"></param>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<ProductsInfo> GetListProductsPublished(string column, bool status, int top)
        {
            try
            {
                string sql = string.Format("select * from Products where IsPublish=1 and {0}='{1}' order by PublishedDate DESC", column, status);
                if(top!=-1)
                    sql = string.Format("select top {2} * from Products where IsPublish=1 and {0}='{1}' order by PublishedDate DESC", column, status, top);
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, sql, null);
                List<ProductsInfo> list = new List<ProductsInfo>();
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
                Log.error("Products GetListProductsPublished err: " + ex.Message);
                return null;
            }
        }
        public List<ProductsInfo> GetListProductsPublished(int ParentID)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ParentID", SqlDbType.Int);
                param[0].Value = ParentID;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select p.* from Products p, ProductCategory pc where p.CategoryID=pc.CategoryID and pc.ParentID=@ParentID and p.IsPublish=1 order by p.PublishedDate DESC", param);
                List<ProductsInfo> list = new List<ProductsInfo>();
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
                Log.error("Products GetListProductsPublished err: " + ex.Message);
                return null;
            }
        }
        public List<ProductsInfo> GetListProductsPublished(int ParentID, int top)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ParentID", SqlDbType.Int);
                param[0].Value = ParentID;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select top " + top + " p.* from Products p, ProductCategory pc where p.CategoryID=pc.CategoryID and pc.ParentID=@ParentID and p.IsPublish=1 order by p.PublishedDate DESC", param);
                List<ProductsInfo> list = new List<ProductsInfo>();
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
                Log.error("Products GetListProductsPublished err: " + ex.Message);
                return null;
            }
        }
        public List<ProductsInfo> GetListSearch(string dk)
        {
            try
            {
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, String.Format("select * from Products where IsPublish=1 {0} order by PublishedDate DESC",dk), null);
                List<ProductsInfo> list = new List<ProductsInfo>();
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
                Log.error("Products GetListSearch err: " + ex.Message);
                return null;
            }
        }
        public ProductsInfo GetByID(string ProductID)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ProductID", SqlDbType.VarChar);
                param[0].Value = ProductID;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from Products where ProductID=@ProductID", param);
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
                Log.error("Products GetByID err: " + ex.Message);
                return null;
            }
        }
        /// <summary>
        /// Insert and Published
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool InsertAdmin(ProductsInfo info, List<ProductPackagesInfo> listpackages)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[29];
                param[0] = new SqlParameter("@ID", SqlDbType.VarChar);
                param[0].Value = info.ProductID;
                param[1] = new SqlParameter("@Name", SqlDbType.NVarChar);
                param[1].Value = info.ProductName;
                param[2] = new SqlParameter("@Version", SqlDbType.NVarChar);
                param[2].Value = info.Version;
                param[3] = new SqlParameter("@ProviderID", SqlDbType.Int);
                param[3].Value = info.ProviderID;
                param[4] = new SqlParameter("@Icon", SqlDbType.NVarChar);
                param[4].Value = info.Icon;
                param[5] = new SqlParameter("@Picture", SqlDbType.NVarChar);
                param[5].Value = info.Picture;
                param[6] = new SqlParameter("@Price", SqlDbType.BigInt);
                param[6].Value = info.Price;
                param[7] = new SqlParameter("@PromotionRate", SqlDbType.Float);
                param[7].Value = info.PromotionRate;
                param[8] = new SqlParameter("@Status", SqlDbType.Bit);
                param[8].Value = info.Status;
                param[9] = new SqlParameter("@PackageID", SqlDbType.Int);
                param[9].Value = info.PackageID;
                param[10] = new SqlParameter("@ReleaseDate", SqlDbType.DateTime);
                param[10].Value = info.ReleaseDate;
                param[11] = new SqlParameter("@UpdateDate", SqlDbType.DateTime);
                param[11].Value = info.UpdateDate;
                param[12] = new SqlParameter("@LinkDownload", SqlDbType.NVarChar);
                param[12].Value = info.LinkDownload;
                param[13] = new SqlParameter("@ViewCount", SqlDbType.Int);
                param[13].Value = info.ViewCount;
                param[14] = new SqlParameter("@DetailDescription", SqlDbType.NVarChar);
                param[14].Value = info.DetailDescription;
                param[15] = new SqlParameter("@TechDescription", SqlDbType.NVarChar);
                param[15].Value = info.TechDescription;
                param[16] = new SqlParameter("@Tags", SqlDbType.NVarChar);
                param[16].Value = info.Tags;
                //param[17] = new SqlParameter("@GroupID", SqlDbType.Int);
                //param[17].Value = info.GroupID;
                param[18] = new SqlParameter("@CategoryID", SqlDbType.Int);
                param[18].Value = info.CategoryID;
                //param[19] = new SqlParameter("@SubCategoryID", SqlDbType.Int);
                //param[19].Value = info.SubCategoryID;
                param[20] = new SqlParameter("@IsBestSale", SqlDbType.Bit);
                //param[20].Value = info.IsBestSale;
                param[21] = new SqlParameter("@IsNew", SqlDbType.Bit);
                param[21].Value = info.IsNew;
                param[22] = new SqlParameter("@IsHot", SqlDbType.Bit);
                param[22].Value = info.IsHot;
                param[23] = new SqlParameter("@IsPublish", SqlDbType.Bit);
                param[23].Value = info.IsPublish;
                param[24] = new SqlParameter("@CreatedBy", SqlDbType.Int);
                param[24].Value = info.CreatedBy;
                param[25] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                param[25].Value = info.CreatedDate;
                param[26] = new SqlParameter("@PublishedBy", SqlDbType.Int);
                param[26].Value = info.PublishedBy;
                param[27] = new SqlParameter("@PublishedDate", SqlDbType.DateTime);
                param[27].Value = info.PublishedDate;
                param[28] = new SqlParameter("@ShortDescription", SqlDbType.NVarChar);
                param[28].Value = info.ShortDescription;

                #region query
                string sql =
                    @"insert into Products([ProductID],
		                                    [ProductName],
		                                    [Version],
		                                    [ProviderID],
		                                    [Icon],
		                                    [Picture],
		                                    [Price],
		                                    [PromotionRate],
		                                    [Status],
		                                    [PackageID],
		                                    [ReleaseDate],
		                                    [UpdateDate],
		                                    [LinkDownload],
		                                    [ViewCount],
		                                    [DetailDescription],
		                                    [TechDescription],
		                                    [Tags],
		                                    --[GroupID],
		                                    [CategoryID],
		                                    --[SubCategoryID],
		                                    [IsBestSale],
		                                    [IsNew],
		                                    [IsHot],
		                                    --[IsPublish],
		                                    [CreatedBy],
		                                    [CreatedDate]
		                                    --[PublishedBy],
		                                    --[PublishedDate]
                                            ,ShortDescription
                                            )
                                            values(@ProductID,
		                                    @ProductName,
		                                    @Version,
		                                    @ProviderID,
		                                    @Icon,
		                                    @Picture,
		                                    @Price,
		                                    @PromotionRate,
		                                    @Status,
		                                    @PackageID,
		                                    @ReleaseDate,
		                                    @UpdateDate,
		                                    @LinkDownload,
		                                    @ViewCount,
		                                    @DetailDescription,
		                                    @TechDescription,
		                                    @Tags,
		                                    --@GroupID,
		                                    @CategoryID,
		                                    --@SubCategoryID,
		                                    @IsBestSale,
		                                    @IsNew,
		                                    @IsHot,
		                                    --@IsPublish,
		                                    @CreatedBy,
		                                    @CreatedDate
		                                    --@PublishedBy,
		                                    --@PublishedDate
                                            ,@ShortDescription
                                            )";
                if (info.IsPublish)
                    sql =
                    @"insert into Products([ProductID],
		                                    [ProductName],
		                                    [Version],
		                                    [ProviderID],
		                                    [Icon],
		                                    [Picture],
		                                    [Price],
		                                    [PromotionRate],
		                                    [Status],
		                                    [PackageID],
		                                    [ReleaseDate],
		                                    [UpdateDate],
		                                    [LinkDownload],
		                                    [ViewCount],
		                                    [DetailDescription],
		                                    [TechDescription],
		                                    [Tags],
		                                    --[GroupID],
		                                    [CategoryID],
		                                    --[SubCategoryID],
		                                    [IsBestSale],
		                                    [IsNew],
		                                    [IsHot],
		                                    [IsPublish],
		                                    [CreatedBy],
		                                    [CreatedDate],
		                                    [PublishedBy],
		                                    [PublishedDate],
                                            ShortDescription
                                            )
                                            values(@ProductID,
		                                    @ProductName,
		                                    @Version,
		                                    @ProviderID,
		                                    @Icon,
		                                    @Picture,
		                                    @Price,
		                                    @PromotionRate,
		                                    @Status,
		                                    @PackageID,
		                                    @ReleaseDate,
		                                    @UpdateDate,
		                                    @LinkDownload,
		                                    @ViewCount,
		                                    @DetailDescription,
		                                    @TechDescription,
		                                    @Tags,
		                                    --@GroupID,
		                                    @CategoryID,
		                                    --@SubCategoryID,
		                                    @IsBestSale,
		                                    @IsNew,
		                                    @IsHot,
		                                    @IsPublish,
		                                    @CreatedBy,
		                                    @CreatedDate,
		                                    @PublishedBy,
		                                    @PublishedDate,
                                            @ShortDescription
                                            )";
                #endregion

                SqlHelper.ExecuteNonQuery(conn
                                          , cmd
                                          , sql
                                          , param);

                //insert product packages
                if (listpackages.Count!=0)
                {
                    ProductPackages pk=new ProductPackages();
                    for(int i=0; i<listpackages.Count; i++)
                    {
                        pk.Insert(listpackages[i]);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Log.error("ProductsInfo Insert err: " + ex.Message);
                return false;
            }
        }
        public bool Insert(ProductsInfo info, List<ProductPackagesInfo> listpackages)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[29];
                param[0] = new SqlParameter("@ProductID", SqlDbType.VarChar);
                param[0].Value = info.ProductID;
                param[1] = new SqlParameter("@ProductName", SqlDbType.NVarChar);
                param[1].Value = info.ProductName;
                param[2] = new SqlParameter("@Version", SqlDbType.NVarChar);
                param[2].Value = info.Version;
                param[3] = new SqlParameter("@ProviderID", SqlDbType.Int);
                param[3].Value = info.ProviderID;
                param[4] = new SqlParameter("@Icon", SqlDbType.NVarChar);
                param[4].Value = info.Icon;
                param[5] = new SqlParameter("@Picture", SqlDbType.NVarChar);
                param[5].Value = info.Picture;
                param[6] = new SqlParameter("@Price", SqlDbType.BigInt);
                param[6].Value = info.Price;
                param[7] = new SqlParameter("@PromotionRate", SqlDbType.Float);
                param[7].Value = info.PromotionRate;
                param[8] = new SqlParameter("@Status", SqlDbType.Bit);
                param[8].Value = info.Status;
                param[9] = new SqlParameter("@PackageID", SqlDbType.Int);
                param[9].Value = info.PackageID;
                param[10] = new SqlParameter("@ReleaseDate", SqlDbType.DateTime);
                param[10].Value = info.ReleaseDate;
                param[11] = new SqlParameter("@UpdateDate", SqlDbType.DateTime);
                param[11].Value = info.UpdateDate;
                param[12] = new SqlParameter("@LinkDownload", SqlDbType.NVarChar);
                param[12].Value = info.LinkDownload;
                param[13] = new SqlParameter("@ViewCount", SqlDbType.Int);
                param[13].Value = info.ViewCount;
                param[14] = new SqlParameter("@DetailDescription", SqlDbType.NVarChar);
                param[14].Value = info.DetailDescription;
                param[15] = new SqlParameter("@TechDescription", SqlDbType.NVarChar);
                param[15].Value = info.TechDescription;
                param[16] = new SqlParameter("@Tags", SqlDbType.NVarChar);
                param[16].Value = info.Tags;
                //param[17] = new SqlParameter("@GroupID", SqlDbType.Int);
                //param[17].Value = info.GroupID;
                param[18] = new SqlParameter("@CategoryID", SqlDbType.Int);
                param[18].Value = info.CategoryID;
                //param[19] = new SqlParameter("@SubCategoryID", SqlDbType.Int);
                //param[19].Value = info.SubCategoryID;
                param[20] = new SqlParameter("@IsBestSale", SqlDbType.Bit);
                //param[20].Value = info.IsBestSale;
                param[21] = new SqlParameter("@IsNew", SqlDbType.Bit);
                param[21].Value = info.IsNew;
                param[22] = new SqlParameter("@IsHot", SqlDbType.Bit);
                param[22].Value = info.IsHot;
                param[23] = new SqlParameter("@IsPublish", SqlDbType.Bit);
                param[23].Value = info.IsPublish;
                param[24] = new SqlParameter("@CreatedBy", SqlDbType.Int);
                param[24].Value = info.CreatedBy;
                param[25] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                param[25].Value = info.CreatedDate;
                param[26] = new SqlParameter("@PublishedBy", SqlDbType.Int);
                param[26].Value = info.PublishedBy;
                param[27] = new SqlParameter("@PublishedDate", SqlDbType.DateTime);
                param[27].Value = info.PublishedDate;
                param[28] = new SqlParameter("@ShortDescription", SqlDbType.NVarChar);
                param[28].Value = info.ShortDescription;
                SqlHelper.ExecuteNonQuery(conn
                                          , cmd
                                          , @"insert into Products([ProductID],
		                                    [ProductName],
		                                    [Version],
		                                    [ProviderID],
		                                    [Icon],
		                                    [Picture],
		                                    [Price],
		                                    [PromotionRate],
		                                    [Status],
		                                    [PackageID],
		                                    [ReleaseDate],
		                                    [UpdateDate],
		                                    [LinkDownload],
		                                    [ViewCount],
		                                    [DetailDescription],
		                                    [TechDescription],
		                                    [Tags],
		                                    --[GroupID],
		                                    [CategoryID],
		                                    --[SubCategoryID],
		                                    [IsBestSale],
		                                    [IsNew],
		                                    [IsHot],
		                                    [IsPublish],
		                                    [CreatedBy],
		                                    [CreatedDate],
		                                    --[PublishedBy],
		                                    --[PublishedDate]
                                            ShortDescription
                                            )
                                            values(@ProductID,
		                                    @ProductName,
		                                    @Version,
		                                    @ProviderID,
		                                    @Icon,
		                                    @Picture,
		                                    @Price,
		                                    @PromotionRate,
		                                    @Status,
		                                    @PackageID,
		                                    @ReleaseDate,
		                                    @UpdateDate,
		                                    @LinkDownload,
		                                    @ViewCount,
		                                    @DetailDescription,
		                                    @TechDescription,
		                                    @Tags,
		                                    --@GroupID,
		                                    @CategoryID,
		                                    --@SubCategoryID,
		                                    @IsBestSale,
		                                    @IsNew,
		                                    @IsHot,
		                                    @IsPublish,
		                                    @CreatedBy,
		                                    @CreatedDate,
		                                    --@PublishedBy,
		                                    --@PublishedDate
                                            @ShortDescription
                                            )"
                                          , param);

                //insert product packages
                if (listpackages.Count != 0)
                {
                    ProductPackages pk = new ProductPackages();
                    for (int i = 0; i < listpackages.Count; i++)
                    {
                        pk.Insert(listpackages[i]);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.error("ProductsInfo Insert err: " + ex.Message);
                return false;
            }
        }
        public bool UpdateAdmin(ProductsInfo info, List<ProductPackagesInfo> listpackages)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[29];
                param[0] = new SqlParameter("@ProductID", SqlDbType.VarChar);
                param[0].Value = info.ProductID;
                param[1] = new SqlParameter("@ProductName", SqlDbType.NVarChar);
                param[1].Value = info.ProductName;
                param[2] = new SqlParameter("@Version", SqlDbType.NVarChar);
                param[2].Value = info.Version;
                param[3] = new SqlParameter("@ProviderID", SqlDbType.Int);
                param[3].Value = info.ProviderID;
                param[4] = new SqlParameter("@Icon", SqlDbType.NVarChar);
                param[4].Value = info.Icon;
                param[5] = new SqlParameter("@Picture", SqlDbType.NVarChar);
                param[5].Value = info.Picture;
                param[6] = new SqlParameter("@Price", SqlDbType.BigInt);
                param[6].Value = info.Price;
                param[7] = new SqlParameter("@PromotionRate", SqlDbType.Float);
                param[7].Value = info.PromotionRate;
                param[8] = new SqlParameter("@Status", SqlDbType.Bit);
                param[8].Value = info.Status;
                param[9] = new SqlParameter("@PackageID", SqlDbType.Int);
                param[9].Value = info.PackageID;
                param[10] = new SqlParameter("@ReleaseDate", SqlDbType.DateTime);
                param[10].Value = info.ReleaseDate;
                param[11] = new SqlParameter("@UpdateDate", SqlDbType.DateTime);
                param[11].Value = info.UpdateDate;
                param[12] = new SqlParameter("@LinkDownload", SqlDbType.NVarChar);
                param[12].Value = info.LinkDownload;
                param[13] = new SqlParameter("@ViewCount", SqlDbType.Int);
                param[13].Value = info.ViewCount;
                param[14] = new SqlParameter("@DetailDescription", SqlDbType.NVarChar);
                param[14].Value = info.DetailDescription;
                param[15] = new SqlParameter("@TechDescription", SqlDbType.NVarChar);
                param[15].Value = info.TechDescription;
                param[16] = new SqlParameter("@Tags", SqlDbType.NVarChar);
                param[16].Value = info.Tags;
                //param[17] = new SqlParameter("@GroupID", SqlDbType.Int);
                //param[17].Value = info.GroupID;
                param[18] = new SqlParameter("@CategoryID", SqlDbType.Int);
                param[18].Value = info.CategoryID;
                //param[19] = new SqlParameter("@SubCategoryID", SqlDbType.Int);
                //param[19].Value = info.SubCategoryID;
                param[20] = new SqlParameter("@IsBestSale", SqlDbType.Bit);
                //param[20].Value = info.IsBestSale;
                param[21] = new SqlParameter("@IsNew", SqlDbType.Bit);
                param[21].Value = info.IsNew;
                param[22] = new SqlParameter("@IsHot", SqlDbType.Bit);
                param[22].Value = info.IsHot;
                param[23] = new SqlParameter("@IsPublish", SqlDbType.Bit);
                param[23].Value = info.IsPublish;
                //param[24] = new SqlParameter("@CreatedBy", SqlDbType.Int);
                //param[24].Value = info.CreatedBy;
                //param[25] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                //param[25].Value = info.CreatedDate;
                param[26] = new SqlParameter("@PublishedBy", SqlDbType.Int);
                param[26].Value = info.PublishedBy;
                param[27] = new SqlParameter("@PublishedDate", SqlDbType.DateTime);
                param[27].Value = info.PublishedDate;
                param[28] = new SqlParameter("@ShortDescription", SqlDbType.NVarChar);
                param[28].Value = info.ShortDescription;
                string sql =
                    @"UPDATE [Products]
                                    SET
	                                    [ProductName] = @ProductName,
	                                    [Version] = @Version,
	                                    [ProviderID] = @ProviderID,
	                                    [Icon] = @Icon,
	                                    [Picture] = @Picture,
	                                    [Price] = @Price,
	                                    [PromotionRate] = @PromotionRate,
	                                    [Status] = @Status,
	                                    [PackageID] = @PackageID,
	                                    [ReleaseDate] = @ReleaseDate,
	                                    [UpdateDate] = @UpdateDate,
	                                    [LinkDownload] = @LinkDownload,
	                                    [ViewCount] = @ViewCount,
	                                    [DetailDescription] = @DetailDescription,
	                                    [TechDescription] = @TechDescription,
	                                    [Tags] = @Tags,
	                                    --[GroupID] = @GroupID,
	                                    [CategoryID] = @CategoryID,
	                                    --[SubCategoryID] = @SubCategoryID,
	                                    [IsBestSale] = @IsBestSale,
	                                    [IsNew] = @IsNew,
	                                    [IsHot] = @IsHot
	                                    --[IsPublish] = @IsPublish,
	                                    --[CreatedBy] = @CreatedBy,
	                                    --[CreatedDate] = @CreatedDate,
	                                    --[PublishedBy] = @PublishedBy,
	                                    --[PublishedDate] = @PublishedDate
                                        ,ShortDescription=@ShortDescription
                                    WHERE
	                                    [ProductID] = @ProductID
                                    ";
                if (info.IsPublish)
                    sql =
                        @"UPDATE [Products]
                                        SET
	                                        [ProductName] = @ProductName,
	                                        [Version] = @Version,
	                                        [ProviderID] = @ProviderID,
	                                        [Icon] = @Icon,
	                                        [Picture] = @Picture,
	                                        [Price] = @Price,
	                                        [PromotionRate] = @PromotionRate,
	                                        [Status] = @Status,
	                                        [PackageID] = @PackageID,
	                                        [ReleaseDate] = @ReleaseDate,
	                                        [UpdateDate] = @UpdateDate,
	                                        [LinkDownload] = @LinkDownload,
	                                        [ViewCount] = @ViewCount,
	                                        [DetailDescription] = @DetailDescription,
	                                        [TechDescription] = @TechDescription,
	                                        [Tags] = @Tags,
	                                        --[GroupID] = @GroupID,
	                                        [CategoryID] = @CategoryID,
	                                        --[SubCategoryID] = @SubCategoryID,
	                                        [IsBestSale] = @IsBestSale,
	                                        [IsNew] = @IsNew,
	                                        [IsHot] = @IsHot,
	                                        [IsPublish] = @IsPublish,
	                                        --[CreatedBy] = @CreatedBy,
	                                        --[CreatedDate] = @CreatedDate,
	                                        [PublishedBy] = @PublishedBy,
	                                        [PublishedDate] = @PublishedDate,
                                            ShortDescription=@ShortDescription
                                        WHERE
	                                        [ProductID] = @ProductID
                                        ";
                SqlHelper.ExecuteNonQuery(conn
                                          , cmd
                                          , sql
                                          , param);

                if (listpackages.Count != 0)
                {
                    ProductPackages pk = new ProductPackages();
                    bool del = pk.Delete(info.ProductID);//delete before
                    if (del)
                    {
                        for (int i = 0; i < listpackages.Count; i++)
                        {
                            pk.Insert(listpackages[i]);
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Log.error("ProductsInfo UpdateAdmin err: " + ex.Message);
                return false;
            }
        }
        public bool Update(ProductsInfo info, List<ProductPackagesInfo> listpackages)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[29];
                param[0] = new SqlParameter("@ProductID", SqlDbType.VarChar);
                param[0].Value = info.ProductID;
                param[1] = new SqlParameter("@ProductName", SqlDbType.NVarChar);
                param[1].Value = info.ProductName;
                param[2] = new SqlParameter("@Version", SqlDbType.NVarChar);
                param[2].Value = info.Version;
                param[3] = new SqlParameter("@ProviderID", SqlDbType.Int);
                param[3].Value = info.ProviderID;
                param[4] = new SqlParameter("@Icon", SqlDbType.NVarChar);
                param[4].Value = info.Icon;
                param[5] = new SqlParameter("@Picture", SqlDbType.NVarChar);
                param[5].Value = info.Picture;
                param[6] = new SqlParameter("@Price", SqlDbType.BigInt);
                param[6].Value = info.Price;
                param[7] = new SqlParameter("@PromotionRate", SqlDbType.Float);
                param[7].Value = info.PromotionRate;
                param[8] = new SqlParameter("@Status", SqlDbType.Bit);
                param[8].Value = info.Status;
                param[9] = new SqlParameter("@PackageID", SqlDbType.Int);
                param[9].Value = info.PackageID;
                param[10] = new SqlParameter("@ReleaseDate", SqlDbType.DateTime);
                param[10].Value = info.ReleaseDate;
                param[11] = new SqlParameter("@UpdateDate", SqlDbType.DateTime);
                param[11].Value = info.UpdateDate;
                param[12] = new SqlParameter("@LinkDownload", SqlDbType.NVarChar);
                param[12].Value = info.LinkDownload;
                param[13] = new SqlParameter("@ViewCount", SqlDbType.Int);
                param[13].Value = info.ViewCount;
                param[14] = new SqlParameter("@DetailDescription", SqlDbType.NVarChar);
                param[14].Value = info.DetailDescription;
                param[15] = new SqlParameter("@TechDescription", SqlDbType.NVarChar);
                param[15].Value = info.TechDescription;
                param[16] = new SqlParameter("@Tags", SqlDbType.NVarChar);
                param[16].Value = info.Tags;
                //param[17] = new SqlParameter("@GroupID", SqlDbType.Int);
                //param[17].Value = info.GroupID;
                param[18] = new SqlParameter("@CategoryID", SqlDbType.Int);
                param[18].Value = info.CategoryID;
                //param[19] = new SqlParameter("@SubCategoryID", SqlDbType.Int);
                //param[19].Value = info.SubCategoryID;
                param[20] = new SqlParameter("@IsBestSale", SqlDbType.Bit);
                //param[20].Value = info.IsBestSale;
                param[21] = new SqlParameter("@IsNew", SqlDbType.Bit);
                param[21].Value = info.IsNew;
                param[22] = new SqlParameter("@IsHot", SqlDbType.Bit);
                param[22].Value = info.IsHot;
                param[23] = new SqlParameter("@IsPublish", SqlDbType.Bit);
                param[23].Value = info.IsPublish;
                //param[24] = new SqlParameter("@CreatedBy", SqlDbType.Int);
                //param[24].Value = info.CreatedBy;
                //param[25] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                //param[25].Value = info.CreatedDate;
                //param[26] = new SqlParameter("@PublishedBy", SqlDbType.Int);
                //param[26].Value = info.PublishedBy;
                //param[27] = new SqlParameter("@PublishedDate", SqlDbType.DateTime);
                //param[27].Value = info.PublishedDate;
                param[28] = new SqlParameter("@ShortDescription", SqlDbType.NVarChar);
                param[28].Value = info.ShortDescription;
                SqlHelper.ExecuteNonQuery(conn
                                          , cmd
                                          , @"UPDATE [Products]
                                                SET
	                                                [ProductName] = @ProductName,
	                                                [Version] = @Version,
	                                                [ProviderID] = @ProviderID,
	                                                [Icon] = @Icon,
	                                                [Picture] = @Picture,
	                                                [Price] = @Price,
	                                                [PromotionRate] = @PromotionRate,
	                                                [Status] = @Status,
	                                                [PackageID] = @PackageID,
	                                                [ReleaseDate] = @ReleaseDate,
	                                                [UpdateDate] = @UpdateDate,
	                                                [LinkDownload] = @LinkDownload,
	                                                [ViewCount] = @ViewCount,
	                                                [DetailDescription] = @DetailDescription,
	                                                [TechDescription] = @TechDescription,
	                                                [Tags] = @Tags,
	                                                --[GroupID] = @GroupID,
	                                                [CategoryID] = @CategoryID,
	                                                --[SubCategoryID] = @SubCategoryID,
	                                                [IsBestSale] = @IsBestSale,
	                                                [IsNew] = @IsNew,
	                                                [IsHot] = @IsHot,
	                                                --[IsPublish] = @IsPublish,
	                                                --[CreatedBy] = @CreatedBy,
	                                                --[CreatedDate] = @CreatedDate,
	                                                --[PublishedBy] = @PublishedBy,
	                                                --[PublishedDate] = @PublishedDate
                                                    ShortDescription=@ShortDescription
                                                WHERE
	                                                [ProductID] = @ProductID"
                                          , param);
                if (listpackages.Count != 0)
                {
                    ProductPackages pk = new ProductPackages();
                    bool del = pk.Delete(info.ProductID);//delete before
                    if (del)
                    {
                        for (int i = 0; i < listpackages.Count; i++)
                        {
                            pk.Insert(listpackages[i]);
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.error("ProductsInfo Update err: " + ex.Message);
                return false;
            }
        }
        public bool Delete(string ProductID)
        {
            try
            {
                int kq =  SqlHelper.ExecuteNonQuery(conn, cmd, string.Format("delete from Products where ProductID in ({0})", ProductID), null);
                if (kq > 0)
                {
                    string[] id = ProductID.Split(',');
                    for (int i = 0; i < id.Length; i++)
                        FileUtility.DeleteFolder("resources/products/" + id[i]);
                    return true;
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.error("ProductsInfo delete err: " + ex.Message);
                return false;
            }
        }
        public bool UpdateStatus(string ProductID, string ColumnUpdate, bool Status)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(conn
                                          , cmd
                                          , @"update Products set " + ColumnUpdate + "='" + Status + "' where ProductID in (" + ProductID + ")"
                                          , null);
                return true;
            }
            catch (Exception ex)
            {
                Log.error("ProductsInfo UpdateStatus err: " + ex.Message);
                return false;
            }
        }
        public bool CheckExistsProductID(string ProductID)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@ProductID", SqlDbType.VarChar);
                param[0].Value = ProductID;
                SqlDataReader dr = SqlHelper.ExecuteReader(conn, cmd, "select * from Products where ProductID=@ProductID", param);
                while (dr.Read())
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Log.error("CheckProductIDExists err: " + ex.Message);
                return false;
            }
        }
    }
}
