using System;


namespace BusinessObjects
{
    public class PackageInfo
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
		private string _PackageName;
		public string PackageName
		{ 
			get 
			{ 
				return _PackageName;
			}
			set 
			{ 
				_PackageName = value;
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
		public PackageInfo()
		{
		}
		public PackageInfo(int PackageID)
		{
			this.PackageID = PackageID;
		}
        public PackageInfo(int stt, int PackageID, string PackageName, string Description, bool status, DateTime createddate)
		{
            this.STT = stt;
			this.PackageID = PackageID;
			this.PackageName = PackageName;
			this.Description = Description;
			this.Status = status;
			this.CreatedDate = createddate;
		}
		#endregion

    }
}
