
namespace BusinessObjects
{
    public class UserGroupInfo
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
		#endregion

		#region ***** Init Methods ***** 
		public UserGroupInfo()
		{
		}
		public UserGroupInfo(int id)
		{
			this.ID = id;
		}
        public UserGroupInfo(int stt, int id, string name)
		{
            this.STT = stt;
			this.ID = id;
			this.Name = name;
		}
		#endregion

    }
}
