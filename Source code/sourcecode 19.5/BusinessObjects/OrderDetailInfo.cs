using System;

namespace BusinessObjects
{
    public class OrderDetailInfo
    {
        #region ***** Fields & Properties ***** 
		private int _ID;
		public int ID
		{ 
			get 
			{ 
				return _ID;
			}
			set 
			{ 
				_ID = value;
			}
		}
		private string _OrderID;
		public string OrderID
		{ 
			get 
			{ 
				return _OrderID;
			}
			set 
			{ 
				_OrderID = value;
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
		private int _Amount;
		public int Amount
		{ 
			get 
			{ 
				return _Amount;
			}
			set 
			{ 
				_Amount = value;
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
        
		#endregion

		#region ***** Init Methods ***** 
		public OrderDetailInfo()
		{
		}
		public OrderDetailInfo(int id)
		{
			this.ID = id;
		}
        public OrderDetailInfo(int stt, int id, string orderid, string productid, int amount, Int64 price, int packageid)
		{
            this.STT = stt;
			this.ID = id;
			this.OrderID = orderid;
			this.ProductID = productid;
			this.Amount = amount;
			this.Price = price;
            this.PackageID = packageid;
		}
		#endregion

    }
}
