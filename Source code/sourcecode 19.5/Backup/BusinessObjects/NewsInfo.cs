using System;


namespace BusinessObjects
{
    public class NewsInfo
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
		private string _Title;
		public string Title
		{ 
			get 
			{ 
				return _Title;
			}
			set 
			{ 
				_Title = value;
			}
		}
		private string _Intro;
		public string Intro
		{ 
			get 
			{ 
				return _Intro;
			}
			set 
			{ 
				_Intro = value;
			}
		}
		private string _Content;
		public string Content
		{ 
			get 
			{ 
				return _Content;
			}
			set 
			{ 
				_Content = value;
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
		private string _PicNote;
		public string PicNote
		{ 
			get 
			{ 
				return _PicNote;
			}
			set 
			{ 
				_PicNote = value;
			}
		}
		private bool _IsHot;
		public bool IsHot
		{ 
			get 
			{ 
				return _IsHot;
			}
			set 
			{ 
				_IsHot = value;
			}
		}
		private int _CreatedBy;
		public int CreatedBy
		{ 
			get 
			{ 
				return _CreatedBy;
			}
			set 
			{ 
				_CreatedBy = value;
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
		private bool _IsPublish;
		public bool IsPublish
		{ 
			get 
			{ 
				return _IsPublish;
			}
			set 
			{ 
				_IsPublish = value;
			}
		}
		private int _PublishedBy;
		public int PublishedBy
		{ 
			get 
			{ 
				return _PublishedBy;
			}
			set 
			{ 
				_PublishedBy = value;
			}
		}
		private DateTime _PublishedDate;
		public DateTime PublishedDate
		{ 
			get 
			{ 
				return _PublishedDate;
			}
			set 
			{ 
				_PublishedDate = value;
			}
		}
		#endregion

		#region ***** Init Methods ***** 
        public NewsInfo()
		{
		}
		public NewsInfo(int id)
		{
			this.ID = id;
		}
        public NewsInfo(int stt, int id, int categoryid, string title, string intro, string content, string picture, string picnote, bool ishot, int createdby, DateTime createddate, bool ispublish, int publishedby, DateTime publisheddate)
		{
            this.STT = stt;
			this.ID = id;
			this.CategoryID = categoryid;
			this.Title = title;
			this.Intro = intro;
			this.Content = content;
			this.Picture = picture;
			this.PicNote = picnote;
			this.IsHot = ishot;
			this.CreatedBy = createdby;
			this.CreatedDate = createddate;
			this.IsPublish = ispublish;
			this.PublishedBy = publishedby;
			this.PublishedDate = publisheddate;
		}
		#endregion
    }
}
