using System;
using System.Collections.Generic;

namespace Project_minibot.Food
{
    public class Sushi : JapaneseFood
    {
        public static int Sum { get; set; }

        SushiDatabase dbSushi = new SushiDatabase();
        List<JapaneseFood> customerOrder = new List<JapaneseFood>();
        
        public int QuestionsOrderSushi()
        {
            Logger.Logger.LoggerCreat("Project_minibot.Food", "QuestionsOrderSushi", Logger.Logger.LogStatus.DEBUG, "Выбор и заказ суши");
            
            Console.WriteLine("\nХотите что-нибудь заказать?");
            string answerCustomer = Console.ReadLine();
            FoodBasket foodBasket = new FoodBasket(customerOrder);
            
            if (answerCustomer.Equals("да", StringComparison.CurrentCultureIgnoreCase))
            {
                while (true)
                {
                    Console.WriteLine("\nУкажите номер позиции меню, которую выбрали");
                    int number = int.Parse(Console.ReadLine()) - 1;
                    
                    Console.WriteLine("\nУкажите количество");
                    int count = int.Parse(Console.ReadLine());
                    for (int i = 0; i < count; i++)
                        customerOrder.Add(dbSushi.GetSushi()[number]);

                    Console.WriteLine("\nЕщё?");
                    foodBasket = new FoodBasket(customerOrder);

                    if (Console.ReadLine() == "нет")
                        break;
                }
            }
            
            if (answerCustomer.Equals("нет", StringComparison.CurrentCultureIgnoreCase)) { };
            return Sum = foodBasket.SumSushi;
        }

        public static void PrintMenuSushi(List<Sushi> list)
        {
            Console.WriteLine("\n\t Меню суши:\n\nНОМЕР\t  НАЗВАНИЕ\t\tЦЕНА\n");
            
            foreach (Sushi s in list)
            {
                Console.WriteLine(s.Number + "\t" + s.Name + "  \t  " + s.Price);
            }
        }
    }
}