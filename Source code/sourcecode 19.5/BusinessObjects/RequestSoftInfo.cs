using System;

namespace BusinessObjects
{
    public class RequestSoftInfo
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
		private string _FullName;
		public string FullName
		{ 
			get 
			{ 
				return _FullName;
			}
			set 
			{ 
				_FullName = value;
			}
		}
		private string _Company;
		public string Company
		{ 
			get 
			{ 
				return _Company;
			}
			set 
			{ 
				_Company = value;
			}
		}
		private string _Phone;
		public string Phone
		{ 
			get 
			{ 
				return _Phone;
			}
			set 
			{ 
				_Phone = value;
			}
		}
		
		private string _Email;
		public string Email
		{ 
			get 
			{ 
				return _Email;
			}
			set 
			{ 
				_Email = value;
			}
		}
		private string _SoftTitle;
		public string SoftTitle
		{ 
			get 
			{ 
				return _SoftTitle;
			}
			set 
			{ 
				_SoftTitle = value;
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
		private bool _StatusID;
		public bool StatusID
		{ 
			get 
			{ 
				return _StatusID;
			}
			set 
			{ 
				_StatusID = value;
			}
		}
		private DateTime _RequestDate;
		public DateTime RequestDate
		{ 
			get 
			{ 
				return _RequestDate;
			}
			set 
			{ 
				_RequestDate = value;
			}
		}
		#endregion

		#region ***** Init Methods ***** 
        public RequestSoftInfo()
		{
		}
		public RequestSoftInfo(int id)
		{
			this.ID = id;
		}
        public RequestSoftInfo(int stt, int id, string fullname, string Company, string phone, string email, string SoftTitle, string content, bool statusid, DateTime Requestdate)
		{
            this.STT = stt;
			this.ID = id;
			this.FullName = fullname;
			this.Company = Company;
			this.Phone = phone;
			this.Email = email;
			this.SoftTitle = SoftTitle;
			this.Content = content;
			this.StatusID = statusid;
			this.RequestDate = Requestdate;
		}
		#endregion

    }
}
