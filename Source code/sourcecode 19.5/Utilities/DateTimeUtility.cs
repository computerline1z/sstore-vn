using System;
using System.Collections;

namespace Utilities
{
    public class DateTimeUtility
    {
        public static string GetDayOfWeekName(DateTime date)
        {
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return "Thứ Hai";

                case DayOfWeek.Tuesday:
                    return "Thứ Ba";

                case DayOfWeek.Wednesday:
                    return "Thứ Tư";

                case DayOfWeek.Thursday:
                    return "Thứ Năm";

                case DayOfWeek.Friday:
                    return "Thứ Sáu";

                case DayOfWeek.Saturday:
                    return "Thứ Bảy";

                case DayOfWeek.Sunday:
                    return "Chủ Nhật";
            }
            return String.Empty;
        }

        public static int GetDayOfWeekValue(DateTime date)
        {
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return 2;

                case DayOfWeek.Tuesday:
                    return 3;

                case DayOfWeek.Wednesday:
                    return 4;

                case DayOfWeek.Thursday:
                    return 5;

                case DayOfWeek.Friday:
                    return 6;

                case DayOfWeek.Saturday:
                    return 7;

                case DayOfWeek.Sunday:
                    return 8;
            }
            return 0;
        }

        public static DateTime[] GetDaysOfWeek(DateTime date)
        {
            DateTime dateTime = GetStartDateOfWeek(date);
            ArrayList arrayList = new ArrayList();
            for (int i = 0; i < 7; i++)
            {
                arrayList.Add(dateTime);
                dateTime = dateTime.AddDays(1.0);
            }
            return (DateTime[])arrayList.ToArray(typeof(DateTime));
        }

        public static DateTime GetEndDateOfWeek(DateTime date)
        {
            return date.AddDays(8 - GetDayOfWeekValue(date));
        }
        public static DateTime GetStartDateOfWeek(DateTime date)
        {
            return date.AddDays(2 - GetDayOfWeekValue(date));
        }
        public static int GetWeekNumber(DateTime date)
        {
            //Constants
            const int JAN = 1;
            const int DEC = 12;
            const int LASTDAYOFDEC = 31;
            const int FIRSTDAYOFJAN = 1;
            const int THURSDAY = 4;
            bool thursdayFlag = false;
            int dayOfYear = date.DayOfYear;
            int startWeekDayOfYear = (int)(new DateTime(date.Year, JAN, FIRSTDAYOFJAN)).DayOfWeek;
            int endWeekDayOfYear = (int)(new DateTime(date.Year, DEC, LASTDAYOFDEC)).DayOfWeek;
            if (startWeekDayOfYear == 0)
                startWeekDayOfYear = 7;
            if (endWeekDayOfYear == 0)
                endWeekDayOfYear = 7;
            int daysInFirstWeek = 8 - (startWeekDayOfYear);

            if (startWeekDayOfYear == THURSDAY || endWeekDayOfYear == THURSDAY)
                thursdayFlag = true;
            int fullWeeks = (int)Math.Ceiling((dayOfYear - (daysInFirstWeek)) / 7.0);
            int resultWeekNumber = fullWeeks;
            if (daysInFirstWeek >= THURSDAY)
                resultWeekNumber = resultWeekNumber + 1;
            if (resultWeekNumber > 52 && !thursdayFlag)
                resultWeekNumber = 1;
            if (resultWeekNumber == 0)
                resultWeekNumber = GetWeekNumber(new DateTime(date.Year - 1, DEC, LASTDAYOFDEC));
            return resultWeekNumber;
        }

        public static string GenarateFolderString(DateTime date)
        {
            return date.Year + "/" + date.Month + "/" + date.Day;
        }
        public static string GenarateFolderSaved(DateTime date)
        {
            return date.Year + "-" + date.Month + "-" + date.Day;
        }
    }
    public class NgayThangInfo
    {
        private DateTime ngayThang;
        private string ngay;
        private string thu;

        public NgayThangInfo(DateTime nt, string ngay, string thu)
        {
            NgayThang = nt;
            Ngay = ngay;
            Thu = thu;
        }
        public NgayThangInfo()
        {
            
        }
        public DateTime NgayThang
        {
            get { return ngayThang; }
            set { ngayThang = value; }
        }

        public string Ngay
        {
            get { return ngay; }
            set { ngay = value; }
        }

        public string Thu
        {
            get { return thu; }
            set { thu = value; }
        }
    }
}
