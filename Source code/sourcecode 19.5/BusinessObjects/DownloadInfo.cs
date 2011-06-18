using System;

namespace BusinessObjects
{
    public class DownloadInfo
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
		#endregion

		#region ***** Init Methods ***** 
		public DownloadInfo()
		{
		}
		public DownloadInfo(int id)
		{
			this.ID = id;
		}
        public DownloadInfo(int stt, int id, string title, string description, string filename, DateTime createddate, bool ispublish)
		{
            this.STT = stt;
			this.ID = id;
			this.Title = title;
			this.Description = description;
			this.FileName = filename;
			this.CreatedDate = createddate;
			this.IsPublish = ispublish;
		}
		#endregion

    }
}
