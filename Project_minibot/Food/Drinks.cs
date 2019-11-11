using System;
using System.Collections.Generic;

namespace Project_minibot.Food
{
    public class Drinks:JapaneseFood
    {
        public int sumDrinks;
        public static int getSumDrinks;

        public List<Drinks> MenuDrinks()
        {
            string[] nameDrinks = new string[] { "Кола", "Пепси", "Миринда", "Спрайт", "Лидский" };
            List<Drinks> drinkses = new List<Drinks>();

            for (int i = 0; i < nameDrinks.Length; i++)
            {
                Drinks drink = new Drinks();
                drink.Number = i + 1;
                drink.Name = nameDrinks[i];
                drink.Price = 3;
                drinkses.Add(drink);
            }

         return drinkses;
        }

        public void QuestionsOrderDrink()
        {
            Logger.Logger.LoggerCreat("Project_minibot.Food", "QuestionsOrderDrink", Logger.Logger.LogStatus.DEBUG, "Выбор и заказ напитков");
            
            Console.WriteLine("\nХотите что-нибудь заказать?");
            Drinks drinksOder = new Drinks();
            drinksOder.MenuDrinks();
            string answerCustomer = Console.ReadLine();

            if (answerCustomer.Equals("да", StringComparison.CurrentCultureIgnoreCase))
            {
                while (true)
                {
                    Console.WriteLine("\nУкажите номер позиции меню, которую выбрали");
                    int number = int.Parse(Console.ReadLine()) - 1;

                    Console.WriteLine("\nУкажите количество");
                    int count = int.Parse(Console.ReadLine());

                    int sum1 = (drinksOder.MenuDrinks()[number].Price) * count;
                    sumDrinks += sum1;
                    Console.WriteLine("\nЕщё?");
                    if (Console.ReadLine() == "нет") break;
                }
            }

            getSumDrinks+= sumDrinks;

            if (answerCustomer.Equals("нет", StringComparison.CurrentCultureIgnoreCase))
           
            Console.WriteLine(getSumDrinks);
        }
    }
}