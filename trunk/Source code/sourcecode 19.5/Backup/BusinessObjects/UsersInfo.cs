using System;

namespace BusinessObjects
{
    public class UsersInfo
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
		private int _GroupID;
		public int GroupID
		{ 
			get 
			{ 
				return _GroupID;
			}
			set 
			{ 
				_GroupID = value;
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
		#endregion

		#region ***** Init Methods ***** 
		public UsersInfo()
		{
		}
		public UsersInfo(int id)
		{
			this.ID = id;
		}
        public UsersInfo(int stt, int id, string fullname, string address, string phone, string mobile, string email, string description, string username, string password, int groupid, bool statusid, DateTime createddate, DateTime lastlogin)
		{
            this.STT = stt;
			this.ID = id;
			this.FullName = fullname;
			this.Address = address;
			this.Phone = phone;
			this.Mobile = mobile;
			this.Email = email;
			this.Description = description;
			this.UserName = username;
			this.Password = password;
			this.GroupID = groupid;
			this.StatusID = statusid;
			this.CreatedDate = createddate;
			this.LastLogin = lastlogin;
		}
		#endregion

    }
}
