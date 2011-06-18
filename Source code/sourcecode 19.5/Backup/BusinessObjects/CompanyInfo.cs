
namespace BusinessObjects
{
    public class CompanyInfo
    {
        #region ***** Fields & Properties ***** 
		private string _CompanyName;
		public string CompanyName
		{ 
			get 
			{ 
				return _CompanyName;
			}
			set 
			{ 
				_CompanyName = value;
			}
		}
		private string _CompanyNameEn;
		public string CompanyNameEn
		{ 
			get 
			{ 
				return _CompanyNameEn;
			}
			set 
			{ 
				_CompanyNameEn = value;
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
		private string _HotLine;
		public string HotLine
		{ 
			get 
			{ 
				return _HotLine;
			}
			set 
			{ 
				_HotLine = value;
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
		private string _Website;
		public string Website
		{ 
			get 
			{ 
				return _Website;
			}
			set 
			{ 
				_Website = value;
			}
		}
		private string _Map;
		public string Map
		{ 
			get 
			{ 
				return _Map;
			}
			set 
			{ 
				_Map = value;
			}
		}
		private string _MoreContent;
		public string MoreContent
		{ 
			get 
			{ 
				return _MoreContent;
			}
			set 
			{ 
				_MoreContent = value;
			}
		}
		#endregion

	    #region ***** Init Methods ***** 
        public CompanyInfo()
	    {
	    }
	    public CompanyInfo(string companyname, string companynameen, string address, string phone, string fax, string hotline, string email, string website, string map, string morecontent)
	    {
		    this.CompanyName = companyname;
		    this.CompanyNameEn = companynameen;
		    this.Address = address;
		    this.Phone = phone;
		    this.Fax = fax;
		    this.HotLine = hotline;
		    this.Email = email;
		    this.Website = website;
		    this.Map = map;
		    this.MoreContent = morecontent;
	    }
	    #endregion
    }
}
