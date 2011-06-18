using System;

namespace BusinessObjects
{
    public class AdvsInfo
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
		private string _AdvName;
		public string AdvName
		{ 
			get 
			{ 
				return _AdvName;
			}
			set 
			{ 
				_AdvName = value;
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
		private int _Width;
		public int Width
		{ 
			get 
			{ 
				return _Width;
			}
			set 
			{ 
				_Width = value;
			}
		}
		private int _Height;
		public int Height
		{ 
			get 
			{ 
				return _Height;
			}
			set 
			{ 
				_Height = value;
			}
		}
		private DateTime _StartedDate;
		public DateTime StartedDate
		{ 
			get 
			{ 
				return _StartedDate;
			}
			set 
			{ 
				_StartedDate = value;
			}
		}
		private DateTime _ExpireDate;
		public DateTime ExpireDate
		{ 
			get 
			{ 
				return _ExpireDate;
			}
			set 
			{ 
				_ExpireDate = value;
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
		public AdvsInfo()
		{
		}
		public AdvsInfo(int id)
		{
			this.ID = id;
		}
        public AdvsInfo(int stt, int id, string advname, string picture, string url, string description, int sortorder, int width, int height, DateTime starteddate, DateTime expiredate)
		{
            this.STT = stt;
			this.ID = id;
			this.AdvName = advname;
			this.Picture = picture;
			this.Url = url;
			this.Description = description;
			this.SortOrder = sortorder;
			this.Width = width;
			this.Height = height;
			this.StartedDate = starteddate;
			this.ExpireDate = expiredate;
		}
		#endregion

    }
}
