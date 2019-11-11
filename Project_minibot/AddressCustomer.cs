using System;

namespace Project_minibot
{
    class AddressCustomer
    {
        public static string NameCustomer { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int NumberHouse { get; set; }
        public int NumberFlat { get; set; }
        
        public  void AddressAndEmail()
        {
            Console.WriteLine("\nДля завершения заказа, укажите адрес доставки!");
            Console.WriteLine("\nГород:");
            Logger.Logger.LoggerCreat("Project_minibot", "AddressAndEmail", Logger.Logger.LogStatus.DEBUG, "Ввод данных пользователя. Отправка сообщения о заказе суши");
            City = Console.ReadLine();
            Console.WriteLine("\nУлица:");
            Street = Console.ReadLine();
            Console.WriteLine("\nДом:");
            NumberHouse = int.Parse(Console.ReadLine());
            Console.WriteLine("\nКвартира:");
            NumberFlat = int.Parse(Console.ReadLine());
            Console.WriteLine("\nВаш Email:");
            Email.EmailAddress = Console.ReadLine(); 
            Console.WriteLine("\nПароль:");
            Email.EmailPassword = Console.ReadLine();
            Console.WriteLine("\nПорт smtp: (например для Gmail- 587");
            Email.Port = int.Parse(Console.ReadLine());
            Console.WriteLine("\nSmtp host (например - gmail.com // yandex.ru // mail.ru):");
            Email.SmptHost = Console.ReadLine();
            Logger.Logger.LoggerCreat("Project_minibot", "AddressAndEmail", Logger.Logger.LogStatus.INFO, "Отправка сообщения о заказе, выполнена успешно");
        }
    }
}