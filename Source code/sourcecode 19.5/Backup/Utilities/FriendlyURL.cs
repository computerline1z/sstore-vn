using System.Globalization;
using System.Text;

namespace Utilities
{
    public class FriendlyURL
    {
        public static string ConvertToUnSignWithSpace(string s)
        {
            try
            {
                string stFormD = s.Normalize(NormalizationForm.FormD);
                StringBuilder sb = new StringBuilder();
                for (int ich = 0; ich < stFormD.Length; ich++)
                {
                    UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                    if (uc != UnicodeCategory.NonSpacingMark)
                    {
                        sb.Append(stFormD[ich]);
                    }
                }
                sb = sb.Replace('Đ', 'D');
                sb = sb.Replace('đ', 'd');
                sb = sb.Replace('&', '-');
                sb = sb.Replace('?', '-');
                sb = sb.Replace('/', '-');
                //sb = sb.Replace(" ", "-");
                return (sb.ToString().Normalize(NormalizationForm.FormD));
            }
            catch
            {
                return null;
            }
        }
        public static string ConvertUrlFriendlyNoExt(object s)
        {
            string stFormD = s.ToString().Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int ich = 0; ich < stFormD.Length; ich++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(stFormD[ich]);
                }
            }
            sb = sb.Replace("? ", "-");
            sb = sb.Replace(" - ", "-");
            sb = sb.Replace('Đ', 'D');
            sb = sb.Replace('đ', 'd');
            sb = sb.Replace('&', '-');
            sb = sb.Replace('?', '-');
            sb = sb.Replace('/', '-');
            sb = sb.Replace(",", "");
            sb = sb.Replace(".", "");
            sb = sb.Replace(":", "");
            sb = sb.Replace("\"", "");
            sb = sb.Replace("“", "");
            sb = sb.Replace(" ", "-");
            sb = sb.Replace("---", "-");
            sb = sb.Replace("*", "-");
            char[] c = new char[] { '-' };
            return (sb.ToString().Normalize(NormalizationForm.FormD).TrimEnd(c));
        }
        public static string ConvertUrlFriendly(object str)
        {
            string s = str.ToString().ToLower();
            string stFormD = s.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int ich = 0; ich < stFormD.Length; ich++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(stFormD[ich]);
                }
            }
            sb = sb.Replace('Đ', 'D');
            sb = sb.Replace('đ', 'd');
            sb = sb.Replace('&', '-');
            sb = sb.Replace('?', '-');
            sb = sb.Replace("\"", "");
            sb = sb.Replace("“", "");
            sb = sb.Replace(":", "");
            sb = sb.Replace('/', '-');
            sb = sb.Replace(" ", "-");
            sb = sb.Replace("--", "-");
            sb = sb.Replace("---", "-");
            return (sb.ToString().Normalize(NormalizationForm.FormD) + ".html");
        }
    }
}
