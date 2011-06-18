using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Utilities
{
    public class SqlObject
    {
        public static string getString(SqlDataReader rdr, int i)
        {
            string str;
            if (rdr.IsDBNull(i))
            {
                str = null;
            }
            else
            {
                str = rdr.GetString(i);
            }
            return str;
        }
        public static int getByte(SqlDataReader rdr, int i)
        {
            int ii;
            if (rdr.IsDBNull(i))
            {
                ii = 0;
            }
            else
            {
                ii = rdr.GetByte(i);
            }
            return ii;
        }
        public static int getInt32(SqlDataReader rdr, int i)
        {
            int ii;
            if (rdr.IsDBNull(i))
            {
                ii = 0;
            }
            else
            {
                ii = rdr.GetInt32(i);
            }
            return ii;
        }
        public static long getInt64(SqlDataReader rdr, int i)
        {
            long ii;
            if (rdr.IsDBNull(i))
            {
                ii = 0;
            }
            else
            {
                ii = rdr.GetInt64(i);
            }
            return ii;
        }
        public static bool getBool(SqlDataReader rdr, int i)
        {
            bool ii;
            if (rdr.IsDBNull(i))
            {
                ii = false;
            }
            else
            {
                ii = rdr.GetBoolean(i);
            }
            return ii;
        }
        public static float getFloat(SqlDataReader rdr, int i)
        {
            float ii;
            if (rdr.IsDBNull(i))
            {
                ii = 0;
            }
            else
            {
                ii = float.Parse(rdr.GetValue(i).ToString());

            }
            return ii;
        }
        public static double getDouble(SqlDataReader rdr, int i)
        {
            double ii;
            if (rdr.IsDBNull(i))
            {
                ii = 0;
            }
            else
            {
                ii = double.Parse(rdr.GetValue(i).ToString());

            }
            return ii;
        }
        /// <summary>
        /// if null, return DateTime.Now
        /// </summary>
        /// <param name="rdr"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static DateTime getDateTime(SqlDataReader rdr, int i)
        {
            DateTime ii;
            if (rdr.IsDBNull(i))
            {
                ii = DateTime.Now;
            }
            else
            {
                ii = rdr.GetDateTime(i);
            }
            return ii;
        }
        /// <summary>
        /// if null, return 01/01/1900 00:00:00
        /// </summary>
        /// <param name="rdr"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static DateTime getDateTime2(SqlDataReader rdr, int i)
        {
            DateTime ii;
            if (rdr.IsDBNull(i))
            {
                ii = NullDateTimeValue();
            }
            else
            {
                ii = rdr.GetDateTime(i);
            }
            return ii;
        }
        public static DateTime NullDateTimeValue()
        {
            return DateTime.Parse("01/01/1900 00:00:00");
        }
    }
}
