using System;


namespace BusinessObjects
{
    public class MembersInfo
    {
        #region ***** Fields & Properties ***** 
		private int _MemberID;
		public int MemberID
		{ 
			get 
			{ 
				return _MemberID;
			}
			set 
			{ 
				_MemberID = value;
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
		private string _UserName;
		public string UserName
		{ 
			get 
			{ 
				return _UserName;
			}
			set 
			{ 
				_UserName = value;
			}
		}
		private string _Password;
		public string Password
		{ 
			get 
			{ 
				return _Password;
			}
			set 
			{ 
				_Password = value;
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
		private DateTime _RegisteredDate;
		public DateTime RegisteredDate
		{ 
			get 
			{ 
				return _RegisteredDate;
			}
			set 
			{ 
				_RegisteredDate = value;
			}
		}
		private DateTime _LastLogin;
		public DateTime LastLogin
		{ 
			get 
			{ 
				return _LastLogin;
			}
			set 
			{ 
				_LastLogin = value;
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
        private string _Avatar;
        public string Avatar
        {
            get
            {
                return _Avatar;
            }
            set
            {
                _Avatar = value;
            }
        }
		#endregion

		#region ***** Init Methods ***** 
        public MembersInfo()
		{
		}
        public MembersInfo(int stt, int memberid, string fullname, string username, string password, string address, string phone, string mobile, string email, DateTime registereddate, DateTime lastlogin, bool status, string avatar)
		{
            this.STT = stt;
			this.MemberID = memberid;
			this.FullName = fullname;
			this.UserName = username;
			this.Password = password;
			this.Address = address;
			this.Phone = phone;
			this.Mobile = mobile;
			this.Email = email;
			this.RegisteredDate = registereddate;
			this.LastLogin = lastlogin;
			this.Status = status;
            this.Avatar = avatar;
		}
		#endregion

    }
}
