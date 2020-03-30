using System;

namespace Project_minibot
{
    class DataInput
    {
        public static string NameCustomer { get; set; }
       
        public  void AddressAndEmail()
        {
            Logger.Logger.LoggerCreat("Project_minibot", "AddressAndEmail", Logger.Logger.LogStatus.DEBUG, "Ввод данных пользователя. Отправка сообщения о заказе суши");
            
            Console.WriteLine("\nДля завершения заказа, укажите адрес электронной почты!");
            Console.WriteLine("\nВаш Email:");
            Email.EmailAddress = Console.ReadLine();
            Console.WriteLine("\nПароль:");
            Email.EmailPassword = Console.ReadLine();

            string getEmail = Email.EmailAddress;
            int indexNumber = getEmail.IndexOf('@') + 1;
            string smtpPort = getEmail.Substring(indexNumber);

            switch (smtpPort)
            {
                case "gmail.com":
                    Email.SmptHost = "smtp.gmail.com"; ;
                    Email.Port = 587;
                    break;
                case "mail.ru":
                    Email.SmptHost = "smtp.mail.ru"; ;
                    Email.Port = 465;
                    break;
                case "yandex.ru":
                    Email.SmptHost = "smtp.yandex.ru"; ;
                    Email.Port = 465;
                    break;
                case "icloud.com":
                    Email.SmptHost = "smtp.mail.me.com";
                    Email.Port = 587;
                    break;
                case "yahoo.com":
                    Email.SmptHost = "smtp.mail.yahoo.com";
                    Email.Port = 465;
                    break;
                case "outlook.com":
                    Email.SmptHost = "smtp.outlook.com"; ;
                    Email.Port = 587;
                    break;
                case "rambler.ru":
                    Email.SmptHost = "smtp.rambler.ru"; ;
                    Email.Port = 465;
                    break;
                case "tut.by":
                    Email.SmptHost = "smtp.yandex.ru"; ;
                    Email.Port = 465;
                    break;
            }

            Logger.Logger.LoggerCreat("Project_minibot", "AddressAndEmail", Logger.Logger.LogStatus.INFO, "Отправка сообщения о заказе, выполнена успешно");
        }
    }
}