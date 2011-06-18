using System;

namespace BusinessObjects
{
    public class OrderInfo
    {
        #region ***** Fields & Properties ***** 
		private string _ID;
		public string ID
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
        private int _MemberID;
        public int MemberID
        {
            get
            {
                return _MemberID;
            }
            set
            {
                _MemberID = value;
            }
        }
		private string _CustomerName;
		public string CustomerName
		{ 
			get 
			{ 
				return _CustomerName;
			}
			set 
			{ 
				_CustomerName = value;
			}
		}
		private string _CustomerAddress;
		public string CustomerAddress
		{ 
			get 
			{ 
				return _CustomerAddress;
			}
			set 
			{ 
				_CustomerAddress = value;
			}
		}
		private string _CustomerPhone;
		public string CustomerPhone
		{ 
			get 
			{ 
				return _CustomerPhone;
			}
			set 
			{ 
				_CustomerPhone = value;
			}
		}
		private string _CustomerEmail;
		public string CustomerEmail
		{ 
			get 
			{ 
				return _CustomerEmail;
			}
			set 
			{ 
				_CustomerEmail = value;
			}
		}
		private string _ReceiveAddress;
		public string ReceiveAddress
		{ 
			get 
			{ 
				return _ReceiveAddress;
			}
			set 
			{ 
				_ReceiveAddress = value;
			}
		}
		private int _PaymentMethod;
		public int PaymentMethod
		{ 
			get 
			{ 
				return _PaymentMethod;
			}
			set 
			{ 
				_PaymentMethod = value;
			}
		}
		private int _ReceiveMethod;
		public int ReceiveMethod
		{ 
			get 
			{ 
				return _ReceiveMethod;
			}
			set 
			{ 
				_ReceiveMethod = value;
			}
		}
		private string _Description;
		public string Description
		{ 
			get 
			{ 
				return _Description;
			}
			set 
			{ 
				_Description = value;
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
		private Int64 _TotalPrice;
		public Int64 TotalPrice
		{ 
			get 
			{ 
				return _TotalPrice;
			}
			set 
			{ 
				_TotalPrice = value;
			}
		}
		private DateTime _OrderDate;
		public DateTime OrderDate
		{ 
			get 
			{ 
				return _OrderDate;
			}
			set 
			{ 
				_OrderDate = value;
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
		public OrderInfo()
		{
		}
		public OrderInfo(string id)
		{
			this.ID = id;
		}
        public OrderInfo(int stt, string id, string customername, string customeraddress
            , string customerphone, string customeremail, string receiveaddress, int paymentmethod
            , int receivemethod, string description, bool status, Int64 totalprice, DateTime orderdate, int memberid)
		{
            this.STT = stt;
			this.ID = id;
			this.CustomerName = customername;
			this.CustomerAddress = customeraddress;
			this.CustomerPhone = customerphone;
			this.CustomerEmail = customeremail;
			this.ReceiveAddress = receiveaddress;
			this.PaymentMethod = paymentmethod;
			this.ReceiveMethod = receivemethod;
			this.Description = description;
			this.Status = status;
			this.TotalPrice = totalprice;
			this.OrderDate = orderdate;
            this.MemberID = memberid;
		}
		#endregion
    }
}
