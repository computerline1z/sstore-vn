
namespace BusinessObjects
{
    public class CartInfo
    {
        private int iD;
        private string productID;
        private string productName;
        private int amount;
        private long price;
        private long totalPrice;
        private int sTT;
        private int packageID;
        private int license;

        public CartInfo()
        {
            
        }
        public CartInfo(int id, string productid, string productname, int amount, long price, long totalPrice, int stt, int packageid, int license)
        {
            this.ID = id;
            this.ProductID = productid;
            this.ProductName = productname;
            this.Amount = amount;
            this.Price = price;
            this.TotalPrice = totalPrice;
            this.PackageID = packageid;
            this.License = license;
            this.STT = stt;
        }
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        public string ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public long Price
        {
            get { return price; }
            set { price = value; }
        }

        public long TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }

        public int STT
        {
            get { return sTT; }
            set { sTT = value; }
        }

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        public int PackageID
        {
            get { return packageID; }
            set { packageID = value; }
        }

        public int License
        {
            get { return license; }
            set { license = value; }
        }
    }
}
