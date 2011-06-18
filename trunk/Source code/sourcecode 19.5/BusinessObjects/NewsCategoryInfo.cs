using System;

namespace BusinessObjects
{
    public class NewsCategoryInfo
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
		private string _CategoryName;
		public string CategoryName
		{ 
			get 
			{ 
				return _CategoryName;
			}
			set 
			{ 
				_CategoryName = value;
			}
		}
		private int _SortOrder;
		public int SortOrder
		{ 
			get 
			{ 
				return _SortOrder;
			}
			set 
			{ 
				_SortOrder = value;
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
		public NewsCategoryInfo()
		{
		}
		public NewsCategoryInfo(int categoryid)
		{
			this.CategoryID = categoryid;
		}
        public NewsCategoryInfo(int stt, int categoryid, string categoryname, int sortorder, bool status, DateTime createddate)
		{
            this.STT = stt;
			this.CategoryID = categoryid;
			this.CategoryName = categoryname;
			this.SortOrder = sortorder;
			this.Status = status;
			this.CreatedDate = createddate;
		}
		#endregion

    }
}
