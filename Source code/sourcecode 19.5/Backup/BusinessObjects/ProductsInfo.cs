using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjects
{
    public class ProductsInfo
    {
        #region ***** Fields & Properties *****
        //
        private string _ShortDescription;
        public string ShortDescription
        {
            get
            {
                return _ShortDescription;
            }
            set
            {
                _ShortDescription = value;
            }
        }
        private string _ProductID;
        public string ProductID
        {
            get
            {
                return _ProductID;
            }
            set
            {
                _ProductID = value;
            }
        }
        private string _ProductName;
        public string ProductName
        {
            get
            {
                return _ProductName;
            }
            set
            {
                _ProductName = value;
            }
        }
        private string _Version;
        public string Version
        {
            get
            {
                return _Version;
            }
            set
            {
                _Version = value;
            }
        }
        private int _SupplierID;
        public int SupplierID
        {
            get
            {
                return _SupplierID;
            }
            set
            {
                _SupplierID = value;
            }
        }
        private string _Icon;
        public string Icon
        {
            get
            {
                return _Icon;
            }
            set
            {
                _Icon = value;
            }
        }
        private string _Picture;
        public string Picture
        {
            get
            {
                return _Picture;
            }
            set
            {
                _Picture = value;
            }
        }
        private Int64 _Price;
        public Int64 Price
        {
            get
            {
                return _Price;
            }
            set
            {
                _Price = value;
            }
        }
        private double _PromotionRate;
        public double PromotionRate
        {
            get
            {
                return _PromotionRate;
            }
            set
            {
                _PromotionRate = value;
            }
        }
        private bool _Status;
        public bool Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
            }
        }
        private int _PackageID;
        public int PackageID
        {
            get
            {
                return _PackageID;
            }
            set
            {
                _PackageID = value;
            }
        }
        private DateTime _ReleaseDate;
        public DateTime ReleaseDate
        {
            get
            {
                return _ReleaseDate;
            }
            set
            {
                _ReleaseDate = value;
            }
        }
        private DateTime _UpdateDate;
        public DateTime UpdateDate
        {
            get
            {
                return _UpdateDate;
            }
            set
            {
                _UpdateDate = value;
            }
        }
        private string _LinkDownload;
        public string LinkDownload
        {
            get
            {
                return _LinkDownload;
            }
            set
            {
                _LinkDownload = value;
            }
        }
        private int _ViewCount;
        public int ViewCount
        {
            get
            {
                return _ViewCount;
            }
            set
            {
                _ViewCount = value;
            }
        }
        private string _DetailDescription;
        public string DetailDescription
        {
            get
            {
                return _DetailDescription;
            }
            set
            {
                _DetailDescription = value;
            }
        }
        private string _TechDescription;
        public string TechDescription
        {
            get
            {
                return _TechDescription;
            }
            set
            {
                _TechDescription = value;
            }
        }
        private string _Tags;
        public string Tags
        {
            get
            {
                return _Tags;
            }
            set
            {
                _Tags = value;
            }
        }
        //private int _GroupID;
        //public int GroupID
        //{
        //    get
        //    {
        //        return _GroupID;
        //    }
        //    set
        //    {
        //        _GroupID = value;
        //    }
        //}
        private int _CategoryID;
        public int CategoryID
        {
            get
            {
                return _CategoryID;
            }
            set
            {
                _CategoryID = value;
            }
        }
        //private int _SubCategoryID;
        //public int SubCategoryID
        //{
        //    get
        //    {
        //        return _SubCategoryID;
        //    }
        //    set
        //    {
        //        _SubCategoryID = value;
        //    }
        //}
        private bool _IsBestSale;
        public bool IsBestSale
        {
            get
            {
                return _IsBestSale;
            }
            set
            {
                _IsBestSale = value;
            }
        }
        private bool _IsNew;
        public bool IsNew
        {
            get
            {
                return _IsNew;
            }
            set
            {
                _IsNew = value;
            }
        }
        private bool _IsHot;
        public bool IsHot
        {
            get
            {
                return _IsHot;
            }
            set
            {
                _IsHot = value;
            }
        }
        private bool _IsPublish;
        public bool IsPublish
        {
            get
            {
                return _IsPublish;
            }
            set
            {
                _IsPublish = value;
            }
        }
        private int _CreatedBy;
        public int CreatedBy
        {
            get
            {
                return _CreatedBy;
            }
            set
            {
                _CreatedBy = value;
            }
        }
        private DateTime _CreatedDate;
        public DateTime CreatedDate
        {
            get
            {
                return _CreatedDate;
            }
            set
            {
                _CreatedDate = value;
            }
        }
        private int _PublishedBy;
        public int PublishedBy
        {
            get
            {
                return _PublishedBy;
            }
            set
            {
                _PublishedBy = value;
            }
        }
        private DateTime _PublishedDate;
        public DateTime PublishedDate
        {
            get
            {
                return _PublishedDate;
            }
            set
            {
                _PublishedDate = value;
            }
        }
        private int _STT;
        public int STT
        {
            get
            {
                return _STT;
            }
            set
            {
                _STT = value;
            }
        }
        #endregion

        #region ***** Init Methods *****
        public ProductsInfo()
        {
        }
        public ProductsInfo(string productid)
        {
            this.ProductID = productid;
        }
        public ProductsInfo(int stt, string productid, string productname, string version, int SupplierID, string icon, string picture, Int64 price, double promotionrate, bool status, int packageid, DateTime releasedate, DateTime updatedate, string linkdownload, int viewcount, string detaildescription, string techdescription, string tags, int categoryid, bool isbestsale, bool isnew, bool ishot, bool ispublish, int createdby, DateTime createddate, int publishedby, DateTime publisheddate, string shortdes)
        {
            this.STT = stt;
            this.ProductID = productid;
            this.ProductName = productname;
            this.Version = version;
            this.SupplierID = SupplierID;
            this.Icon = icon;
            this.Picture = picture;
            this.Price = price;
            this.PromotionRate = promotionrate;
            this.Status = status;
            this.PackageID = packageid;
            this.ReleaseDate = releasedate;
            this.UpdateDate = updatedate;
            this.LinkDownload = linkdownload;
            this.ViewCount = viewcount;
            this.DetailDescription = detaildescription;
            this.TechDescription = techdescription;
            this.Tags = tags;
            //this.GroupID = groupid;
            this.CategoryID = categoryid;
            //this.SubCategoryID = subcategoryid;
            this.IsBestSale = isbestsale;
            this.IsNew = isnew;
            this.IsHot = ishot;
            this.IsPublish = ispublish;
            this.CreatedBy = createdby;
            this.CreatedDate = createddate;
            this.PublishedBy = publishedby;
            this.PublishedDate = publisheddate;
            this.ShortDescription = shortdes;
        }
        #endregion
    }
}
