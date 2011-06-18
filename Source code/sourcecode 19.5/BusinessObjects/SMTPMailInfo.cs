

namespace BusinessObjects
{
    public class SMTPMailInfo
    {
        private string sMTP;
        private string mailAddress;
        private string userName;
        private string password;

        public string SMTP
        {
            get { return sMTP; }
            set { sMTP = value; }
        }

        public string MailAddress
        {
            get { return mailAddress; }
            set { mailAddress = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
