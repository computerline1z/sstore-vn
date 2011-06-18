using System;

namespace BusinessObjects
{
    public class BrandsInfo
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
		private string _Name;
		public string Name
		{ 
			get 
			{ 
				return _Name;
			}
			set 
			{ 
				_Name = value;
			}
		}
		private string _Picture;
		public string Picture
		{ 
			get 
			{ 
				return _Picture;
			}
			set 
			{ 
				_Picture = value;
			}
		}
		private string _Url;
		public string Url
		{ 
			get 
			{ 
				return _Url;
			}
			set 
			{ 
				_Url = value;
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
		public BrandsInfo()
		{
		}
		public BrandsInfo(int id)
		{
			this.ID = id;
		}
        public BrandsInfo(int stt, int id, string Name, string picture, string url, string description, int sortorder)
		{
            this.STT = stt;
			this.ID = id;
			this.Name = Name;
			this.Picture = picture;
			this.Url = url;
			this.Description = description;
			this.SortOrder = sortorder;
		}
		#endregion

    }
}
