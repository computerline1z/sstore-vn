using System;

namespace BusinessObjects
{
    public class ReceiveMethodsInfo
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
		private string _ReceiveTime;
		public string ReceiveTime
		{ 
			get 
			{ 
				return _ReceiveTime;
			}
			set 
			{ 
				_ReceiveTime = value;
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
		public ReceiveMethodsInfo()
		{
		}
		public ReceiveMethodsInfo(int methodid)
		{
			this.MethodID = methodid;
		}
        public ReceiveMethodsInfo(int methodid, string methodname, string receivetime, Int64 fee)
		{
			this.MethodID = methodid;
			this.MethodName = methodname;
			this.ReceiveTime = receivetime;
			this.Fee = fee;
		}
		#endregion

    }
}
