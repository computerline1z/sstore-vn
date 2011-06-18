using System;

namespace Utilities
{
	/// <summary>
	/// Parse String in to token
	/// Modification history:
	/// 
	/// </summary>
	public class StringTokenizer
	{
		private int currentPosition;
		private int newPosition;
		private int maxPosition;
		private String str;
		private String delim;
		private bool returnDelim; 
		private bool delimsChanged;
		private char maxDelimChar;
		public StringTokenizer(String str) :this(str," \t\n\r\f",false)
		{
		}

		public StringTokenizer(String str,String delim) :this(str,delim,false)
		{
		}
		public StringTokenizer(String str,String delim,bool returnDelim)
		{
			this.currentPosition = 0;
			this.newPosition = -1;
			this.str=str;
			this.delim=delim;
			this.returnDelim=returnDelim;
			maxPosition = str.Length;
			setMaxDelimChar();
			delimsChanged = false;
		}

		private void setMaxDelimChar()
		{
			if(delim  == null)
			{
				maxDelimChar = '\0';
				return;
			}
			char c = '\0';
			for(int i = 0; i < delim.Length; i++)
			{
				char c1 = delim[i];
				if(c < c1)
					c = c1;
			}
			maxDelimChar = c;
		}
		private int skipDelimiters(int i)
		{
			if(delim  == null)
				throw new NullReferenceException();
			int j;
			for(j = i; !returnDelim && j < maxPosition; j++)
			{
				char c = str[j];
				if(c > maxDelimChar || delim.IndexOf(c) < 0)
					break;
			}
			return j;
		}

		private int scanToken(int i)
		{
			int j;
			for(j = i; j < maxPosition; j++)
			{
				char c = str[j];
				if(c <= maxDelimChar && delim.IndexOf(c) >= 0)
					break;
			}

			if(returnDelim && i == j)
			{
				char c1 = str[j];
				if(c1 <= maxDelimChar && delim.IndexOf(c1) >= 0)
					j++;
			}
			return j;
		}

		public bool hasMoreTokens()
		{
			newPosition = skipDelimiters(currentPosition);
			return newPosition < maxPosition;
		}

		public String nextToken() 
		{
			String sToken="";
			currentPosition = newPosition < 0 || delimsChanged ? skipDelimiters(currentPosition) : newPosition;
			delimsChanged = false;
			newPosition = -1;
			if(currentPosition >= maxPosition)
			{
				throw new Exception("NoSuchElement");
			} 
			else
			{
				int i = currentPosition;
				currentPosition = scanToken(currentPosition);
				sToken=str.Substring(i, currentPosition-i);
				return sToken;
			}
		}

		public String nextToken(String s)
		{
			delim = s;
			delimsChanged = true;
			setMaxDelimChar();
			return nextToken();
		}

		public bool hasMoreElements()
		{
			return hasMoreTokens();
		}

		public Object nextElement()
		{
			return nextToken();
		}

		public int countTokens()
		{
			int i = 0;
			for(int j = currentPosition; j < maxPosition;)
			{
				j = skipDelimiters(j);
				if(j >= maxPosition)
					break;
				j = scanToken(j);
				i++;
			}

			return i;
		}

	}
}
