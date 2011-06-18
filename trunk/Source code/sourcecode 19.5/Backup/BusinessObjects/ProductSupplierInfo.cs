using System;


namespace BusinessObjects
{
    public class ProductSupplierInfo
    {
        #region ***** Fields & Properties ***** 
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
		private string _SupplierName;
		public string SupplierName
		{ 
			get 
			{ 
				return _SupplierName;
			}
			set 
			{ 
				_SupplierName = value;
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
		#endregion

		#region ***** Init Methods ***** 
		public ProductSupplierInfo()
		{
		}
		public ProductSupplierInfo(int SupplierID)
		{
			this.SupplierID = SupplierID;
		}
        public ProductSupplierInfo(int stt, int SupplierID, string SupplierName, string Description, bool status, DateTime createddate)
		{
            this.STT = stt;
			this.SupplierID = SupplierID;
			this.SupplierName = SupplierName;
			this.Description = Description;
			this.Status = status;
			this.CreatedDate = createddate;
		}
		#endregion

    }
}
