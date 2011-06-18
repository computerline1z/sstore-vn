using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjects
{
    public class ProductCommentsInfo
    {
        #region ***** Fields & Properties ***** 
		private int _CommentID;
		public int CommentID
		{ 
			get 
			{ 
				return _CommentID;
			}
			set 
			{ 
				_CommentID = value;
			}
		}
		private string _ProductID;
		public string ProductID
		{ 
			get 
			{ 
				return _ProductID;
			}
			set 
			{ 
				_ProductID = value;
			}
		}
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
		private string _CommentContent;
		public string CommentContent
		{ 
			get 
			{ 
				return _CommentContent;
			}
			set 
			{ 
				_CommentContent = value;
			}
		}
		private DateTime _CommentDate;
		public DateTime CommentDate
		{ 
			get 
			{ 
				return _CommentDate;
			}
			set 
			{ 
				_CommentDate = value;
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
		private int _PublishBy;
		public int PublishBy
		{ 
			get 
			{ 
				return _PublishBy;
			}
			set 
			{ 
				_PublishBy = value;
			}
		}
		private DateTime _PublishDate;
		public DateTime PublishDate
		{ 
			get 
			{ 
				return _PublishDate;
			}
			set 
			{ 
				_PublishDate = value;
			}
		}
		#endregion

		#region ***** Init Methods ***** 
		public ProductCommentsInfo()
		{
		}
		public ProductCommentsInfo(int commentid)
		{
			this.CommentID = commentid;
		}
		public ProductCommentsInfo(int commentid, string productid, int memberid, string commentcontent, DateTime commentdate, bool ispublish, int publishby, DateTime publishdate)
		{
			this.CommentID = commentid;
			this.ProductID = productid;
			this.MemberID = memberid;
			this.CommentContent = commentcontent;
			this.CommentDate = commentdate;
			this.IsPublish = ispublish;
			this.PublishBy = publishby;
			this.PublishDate = publishdate;
		}
		#endregion
    }
}
