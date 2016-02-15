using System;
using System.Web.Mail;
using MailMessage = System.Web.Mail.MailMessage;


namespace Base
{
    /// <summary>
    /// Summary description for MailService
    /// </summary>
    public static class MailService
    {
        public static String From;
        public static String Password;
        public static String SmtpHost;
        public static String SmtpPort;

        static public void Send(String To, String Subject, String Body, String domainName)
        {
            MailMessage Mail = MailService.CreateMailMessage(To, Subject, Body, domainName);
            MailService.Send(Mail);
        }
        static MailMessage CreateMailMessage(String To, String Subject, String Body, String domainName)
        {
            MailMessage Mail = new MailMessage();
            Mail.BodyFormat = MailFormat.Html;
            Mail.From = From;
            Mail.To = To;
            Mail.Subject = Subject;
            Mail.Body = Body;
            Mail.BodyFormat = MailFormat.Html;
            Mail.BodyEncoding = System.Text.Encoding.UTF8;


            Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", "smtp.gmail.com");
            Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", "587");
            Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", "2");
            Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
            Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "webfindingjobsmvcmodel.net@gmail.com");
            Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "abcABC123!@#$");
            Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "true");

            return Mail;
        }

        static void Send(MailMessage Mail)
        {
            SmtpMail.SmtpServer = "smtp.gmail.com:587";
            SmtpMail.Send(Mail);
        }
    }
}

