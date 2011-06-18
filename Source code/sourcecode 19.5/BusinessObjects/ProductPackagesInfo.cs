using System;

namespace BusinessObjects
{
    public class ProductPackagesInfo
    {
        private string productID;
        private int packageID;
        private string packageName;

        public ProductPackagesInfo()
        {
            
        }

        public string ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

        public int PackageID
        {
            get { return packageID; }
            set { packageID = value; }
        }

        public string PackageName
        {
            get { return packageName; }
            set { packageName = value; }
        }
    }
}
