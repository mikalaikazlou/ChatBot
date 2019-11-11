using System;
using System.Collections.Generic;

namespace Project_minibot.Food
{
    public class SauccesGarnish : JapaneseFood
    {
        public int sumSaucces;
        public static int getSumSaucces;

        public List<SauccesGarnish> MenuSauccesGarnishes()
        {
            string[] nameSaucces = new string[] { "Соус соевый", "Соус ореховый", "Соус терияки", "Васаби      ", "Имбирь      " };
            List<SauccesGarnish> sauccesGarnishes = new List<SauccesGarnish>();

            for (int i = 0; i < nameSaucces.Length; i++)
            {
                SauccesGarnish saucces = new SauccesGarnish();
                saucces.Number = i + 1;
                saucces.Name = nameSaucces[i];
                saucces.Price = 2;
                sauccesGarnishes.Add(saucces);
            }
            return sauccesGarnishes;
        }

        public void QuestionsOrderSaucces()
        {
            Logger.Logger.LoggerCreat("Project_minibot.Food", "QuestionsOrderSaucces", Logger.Logger.LogStatus.DEBUG, "Выбор и заказ суши");
            Console.WriteLine("\nХотите что-нибудь заказать?");
            SauccesGarnish sauccesOder = new SauccesGarnish();
            sauccesOder.MenuSauccesGarnishes();
            string answerCustomer = Console.ReadLine();

            if (answerCustomer.Equals("да", StringComparison.CurrentCultureIgnoreCase))
            {
                while (true)
                {
                    Console.WriteLine("\nУкажите номер позиции меню, которую выбрали");
                    int number = int.Parse(Console.ReadLine()) - 1;
                   
                    Console.WriteLine("\nУкажите количество");
                    int count = int.Parse(Console.ReadLine());
                    
                    int sum1 = (sauccesOder.MenuSauccesGarnishes()[number].Price) * count;
                    sumSaucces += sum1;
                    Console.WriteLine("\nЕщё?");
                    if (Console.ReadLine() == "нет") break;
                }
            }

            if (answerCustomer.Equals("нет", StringComparison.CurrentCultureIgnoreCase)) { };
            
            getSumSaucces += sumSaucces;
            Console.WriteLine(getSumSaucces);
        }
    }
}