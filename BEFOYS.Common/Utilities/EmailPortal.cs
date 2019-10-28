using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace BEFOYS.Common.Utilities
{
    public class EmailPortal
    {
        static string SiteEmailAddress = "info@kalagram.com";
        static string SiteEmailPassword = "Abtin123@";
        static string SiteEmailHost = "mail.kalagram.com";
        public static void SendEmail(string Email, string Title, string Body)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient();
                NetworkCredential basicCredential = new NetworkCredential(SiteEmailAddress, SiteEmailPassword);
                MailMessage message = new MailMessage();
                MailAddress fromAddress = new MailAddress(SiteEmailAddress);
                smtpClient.Host = SiteEmailHost;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = basicCredential;
                message.From = fromAddress;
                message.Subject = Title;
                message.IsBodyHtml = true;
                message.Body = Body;
                message.To.Add(Email);
                smtpClient.Send(message);
            }
            catch (Exception) { }
        }
    }
}
