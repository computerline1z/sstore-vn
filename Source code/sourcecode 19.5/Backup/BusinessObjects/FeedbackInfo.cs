using System;

namespace BusinessObjects
{
    public class FeedbackInfo
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
		private string _Address;
		public string Address
		{ 
			get 
			{ 
				return _Address;
			}
			set 
			{ 
				_Address = value;
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
		private string _Mobile;
		public string Mobile
		{ 
			get 
			{ 
				return _Mobile;
			}
			set 
			{ 
				_Mobile = value;
			}
		}
		private string _Fax;
		public string Fax
		{ 
			get 
			{ 
				return _Fax;
			}
			set 
			{ 
				_Fax = value;
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
		private string _Subject;
		public string Subject
		{ 
			get 
			{ 
				return _Subject;
			}
			set 
			{ 
				_Subject = value;
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
        public FeedbackInfo()
		{
		}
		public FeedbackInfo(int id)
		{
			this.ID = id;
		}
        public FeedbackInfo(int stt, int id, string fullname, string address, string phone, string mobile, string fax, string email, string subject, string content, bool statusid, DateTime createddate)
		{
            this.STT = stt;
			this.ID = id;
			this.FullName = fullname;
			this.Address = address;
			this.Phone = phone;
			this.Mobile = mobile;
			this.Fax = fax;
			this.Email = email;
			this.Subject = subject;
			this.Content = content;
			this.StatusID = statusid;
			this.CreatedDate = createddate;
		}
		#endregion

    }
}
