using System;
using System.Collections.Generic;
using Project_minibot.Database;

namespace Project_minibot.Food
{
    public class Rolls : JapaneseFood
    {
        public static int Sum { get; set; }

        RollsDatabase dbRolls = new RollsDatabase();
        List<JapaneseFood> customerOrder = new List<JapaneseFood>();

        public int QuestionsOrderRolls()
        {
            Logger.Logger.LoggerCreat("Project_minibot.Food", "QuestionsOrderRolls", Logger.Logger.LogStatus.DEBUG, "Выбор и заказ роллов");
            
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
                        customerOrder.Add(dbRolls.GetRolls()[number]);

                    Console.WriteLine("\nЕщё?");
                    foodBasket = new FoodBasket(customerOrder);

                    if (Console.ReadLine() == "нет")
                        break;
                }
            }

            if (answerCustomer.Equals("нет", StringComparison.CurrentCultureIgnoreCase)){}; 
            return Sum = foodBasket.SumRolls;
        } 

        public static void PrintMenuRolls(List<Rolls> list)
        {
            Console.WriteLine("\n\t Меню роллов:\n\nНОМЕР \tНАЗВАНИЕ\tЦЕНА\n");
            
            foreach (Rolls s in list)
            {
                Console.WriteLine(s.Number + "\t" + s.Name + "\t" + s.Price);
            }
        }
    }
}