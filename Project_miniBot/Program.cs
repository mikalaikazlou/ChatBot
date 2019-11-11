using System;
using System.Threading;
using Project_minibot.Food;
using Project_minibot.Database;

namespace Project_minibot
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.Logger.LoggerCreat("Project_minibot", "Main", 0, "Программа запущена");
            Thread thread = new Thread(new ThreadStart(Welcome.WelcomeCustomer));
            thread.Start();

            SushiDatabase dbSushi = new SushiDatabase();
            RollsDatabase dbRolls = new RollsDatabase();
            Sushi sushi = new Sushi();
            Rolls rolls = new Rolls();
            DisplayMenu menu = new DisplayMenu();
            AddressCustomer address = new AddressCustomer();
            AddressCustomer.NameCustomer = Console.ReadLine();

            while (true)
            {
                Console.WriteLine($"\n{AddressCustomer.NameCustomer},Вот наше меню:{DisplayMenu.menuStart} {MyExtension.CutString(DisplayMenu.menuStart)}");
                Console.WriteLine($"\n{AddressCustomer.NameCustomer}, укажите номер меню, которое Вы желаете посмотреть?");

                int numberMenu = int.Parse(Console.ReadLine());

                if (numberMenu > 4 || numberMenu < 0)
                {
                    Logger.Logger.LoggerCreat("Project_minibot", "Main", Logger.Logger.LogStatus.ERROR, "Недопустимое значение!");
                    throw new MyExceptionMessage("\nТакой позиции в меню нет!");
                }

                menu.DisplayMenuFood(numberMenu);

                switch (numberMenu)
                {
                    case 1:
                        sushi.QuestionsOrderSushi();
                        break;
                    case 2:
                        rolls.QuestionsOrderRolls();
                        break;
                    case 3:
                        new SauccesGarnish().QuestionsOrderSaucces();
                        break;
                    case 4:
                        new Drinks().QuestionsOrderDrink();
                        break;
                }

                Console.WriteLine("\nХотите ещё что-нибудь заказать? Не желаете посмотреть меню?");
                string answer = Console.ReadLine();
                if (answer == "нет") break;
            }

            Logger.Logger.LoggerCreat("Project_minibot", "Main", 0, "Начало процесса оформления заказа");
           
            menu.BillCount();
            address.AddressAndEmail();
            new Bill().WriteBill();
            Email.SendEmail();

            Logger.Logger.Verify();
            Logger.Logger.LoggerCreat("Project_minibot", "Main", 0, "Завершение процесса оформления заказа");
            Logger.Logger.LoggerCreat("Project_minibot", "Main", 0, "Программа завершена успешно");
        }
    }
}