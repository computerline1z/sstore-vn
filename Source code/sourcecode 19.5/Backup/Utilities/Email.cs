using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using Logger;

namespace Utilities
{
    public class Email
    {
        

        public static bool IsValidEmailAddress(string EmailAddress)
        {
            if (EmailAddress != null)
            {
                Regex regEmail =
                    new Regex(
                        @"^[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
                if (regEmail.IsMatch(EmailAddress))
                    return true;
                return false;
            }
            else return false;
        }
        public static void SendEmail(string smtp, string from, string user, string pass, string to, string subject, string body)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress(from);
                message.To.Add(new MailAddress(to));
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;
                message.BodyEncoding = Encoding.UTF8;

                SmtpClient _SmtpClient = new SmtpClient(smtp);
                _SmtpClient.Port = 25;
                NetworkCredential _Credentials = new NetworkCredential(user, pass);

                _SmtpClient.Credentials = _Credentials;
                _SmtpClient.Send(message);

            }
            catch (Exception ex)
            {
                Log.info("SendEmail err: " + ex.Message);
            }
        }
        public static void SendEmail(string smtp, string from, string user, string pass, IList<MailAddress> sendto, string subject, string body)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress(from);
                for (int i = 0; i < sendto.Count; i++ )
                    message.To.Add(sendto[i]);
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;
                message.BodyEncoding = Encoding.UTF8;

                SmtpClient _SmtpClient = new SmtpClient(smtp);
                _SmtpClient.Port = 25;
                NetworkCredential _Credentials = new NetworkCredential(user, pass);

                _SmtpClient.Credentials = _Credentials;
                _SmtpClient.Send(message);

            }
            catch (Exception ex)
            {
                Log.info("SendEmail err: " + ex.Message);
            }
        }


        
    }
    
}
