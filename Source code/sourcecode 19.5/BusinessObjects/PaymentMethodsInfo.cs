using System;

namespace BusinessObjects
{
    public class PaymentMethodsInfo
    {
        #region ***** Fields & Properties ***** 
		private int _MethodID;
		public int MethodID
		{ 
			get 
			{ 
				return _MethodID;
			}
			set 
			{ 
				_MethodID = value;
			}
		}
		private string _MethodName;
		public string MethodName
		{ 
			get 
			{ 
				return _MethodName;
			}
			set 
			{ 
				_MethodName = value;
			}
		}
		private string _Guide;
		public string Guide
		{ 
			get 
			{ 
				return _Guide;
			}
			set 
			{ 
				_Guide = value;
			}
		}
		private Int64 _Fee;
		public Int64 Fee
		{ 
			get 
			{ 
				return _Fee;
			}
			set 
			{ 
				_Fee = value;
			}
		}
		#endregion

		#region ***** Init Methods ***** 
		public PaymentMethodsInfo()
		{
		}
		public PaymentMethodsInfo(int methodid)
		{
			this.MethodID = methodid;
		}
        public PaymentMethodsInfo(int methodid, string methodname, string guide, Int64 fee)
		{
			this.MethodID = methodid;
			this.MethodName = methodname;
			this.Guide = guide;
			this.Fee = fee;
		}
		#endregion

    }
}
