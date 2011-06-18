using System;

namespace BusinessObjects
{
    public class ProductCategoryInfo
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
		private int _ParentID;
        public int ParentID
		{ 
			get 
			{
                return _ParentID;
			}
			set 
			{
                _ParentID = value;
			}
		}
        private int _Level;
        public int Level
        {
            get
            {
                return _Level;
            }
            set
            {
                _Level = value;
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
		#endregion

		#region ***** Init Methods ***** 
		public ProductCategoryInfo()
		{
		}
		public ProductCategoryInfo(int branchid)
		{
            this.CategoryID = branchid;
		}
        public ProductCategoryInfo(int stt, int Categoryid, string Categoryname, int sortorder, bool status, DateTime createddate, int ParentID)
		{
            this.STT = stt;
            this.CategoryID = Categoryid;
            this.CategoryName = Categoryname;
			this.SortOrder = sortorder;
			this.Status = status;
			this.CreatedDate = createddate;
            this.ParentID = ParentID;
		}
		#endregion

    }
}
