using System;

namespace BusinessObjects
{
    public class HelpInfo
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
        public HelpInfo()
		{
		}
		public HelpInfo(int id)
		{
			this.ID = id;
		}
        public HelpInfo(int stt, int id, string title, string content, bool status, DateTime createddate)
		{
            this.STT = stt;
			this.ID = id;
			this.Title = title;
			this.Content = content;
			this.Status = status;
			this.CreatedDate = createddate;
		}
		#endregion

    }
}
