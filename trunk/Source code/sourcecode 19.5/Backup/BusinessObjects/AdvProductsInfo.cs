

namespace BusinessObjects
{
    public class AdvProductsInfo
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
		private string _FileName;
		public string FileName
		{ 
			get 
			{ 
				return _FileName;
			}
			set 
			{ 
				_FileName = value;
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
		#endregion

		#region ***** Init Methods ***** 
		public AdvProductsInfo()
		{
		}
		public AdvProductsInfo(int id)
		{
			this.ID = id;
		}
        public AdvProductsInfo(int id, int categoryid, string advname, string filename, int width, int height)
		{
			this.ID = id;
			this.CategoryID = categoryid;
			this.AdvName = advname;
			this.FileName = filename;
			this.Width = width;
			this.Height = height;
		}
		#endregion

    }
}
