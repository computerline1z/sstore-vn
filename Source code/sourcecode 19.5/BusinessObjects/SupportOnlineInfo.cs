using System;

namespace BusinessObjects
{
    public class SupportOnlineInfo
	{
		#region ***** Fields & Properties ***** 
        private int stt;
        public int Stt
        {
            get { return stt; }
            set { stt = value; }
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
		private int _TypeID;
		public int TypeID
		{ 
			get 
			{ 
				return _TypeID;
			}
			set 
			{ 
				_TypeID = value;
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
        private int _IndexNumber;
        public int IndexNumber
        {
            get
            {
                return _IndexNumber;
            }
            set
            {
                _IndexNumber = value;
            }
        }
        private string nick;
        public string Nick
        {
            get { return nick; }
            set { nick = value; }
        }

		#endregion

		#region ***** Init Methods ***** 
		public SupportOnlineInfo()
		{
		}
        public SupportOnlineInfo(int stt, int id, string name, string nick, int typeid, bool statusid, DateTime createddate, int indexnumber)
		{
            Stt = stt;
			this.ID = id;
			this.Name = name;
			this.TypeID = typeid;
			this.StatusID = statusid;
			this.CreatedDate = createddate;
            this.IndexNumber = indexnumber;
            this.nick = nick;
		}
		#endregion
	}
}

