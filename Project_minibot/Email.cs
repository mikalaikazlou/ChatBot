using System.Net;
using System.Net.Mail;

namespace Project_minibot
{
    class Email
    {
        public static string EmailAddress { get; set; }
        public static string EmailPassword { get; set; }
        public static int Port { get; set; }
        public static string SmptHost { get; set; }
        
        public static void SendEmail()
        {
            Logger.Logger.LoggerCreat("Project_minibot", "SendEmail", 0, "Отправка сообщения");
            MailAddress from = new MailAddress(EmailAddress, AddressCustomer.NameCustomer);
            MailAddress to = new MailAddress(EmailAddress);
            MailMessage mail = new MailMessage(from, to);
            mail.Subject = "Заказ суши";
            mail.Attachments.Add(new Attachment(@"D:\itacademy\DOTNET_PROJECT_miniBot\Project_minibot\The_Bill.txt"));
            SmtpClient smtp = new SmtpClient($"smtp.{SmptHost}", Port);
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(EmailAddress, EmailPassword);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(mail);
            mail.Dispose();
            Logger.Logger.LoggerCreat("Project_minibot", "SendEmail", 0, "Сообщение отправлено успешно");
        }
    }
}