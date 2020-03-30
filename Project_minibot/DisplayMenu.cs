using System;
using Project_minibot.Database;
using Project_minibot.Food;

namespace Project_minibot
{
    class DisplayMenu:Bill
    {
        public const string menuStart = "\n\n\tМеню:\n1.Суши\n2.Роллы\n3.Соусы/Гарниры\n4.Напитки";
       
        public override double BillCount()
        {
            Console.WriteLine($"\nСумма Вашего заказа составила {Bill.sumBill} рублей!");
            Console.WriteLine($"\nВключая: \nСуши - {Sushi.Sum} рублей\nРоллы - {Rolls.Sum} рублей\nСоусы/Гарниры - {SauccesGarnish.getSumSaucces} рублей\nНапитки - {Drinks.getSumDrinks} рублей.");
            Console.WriteLine($"\nСумма к оплате, с учетом скидки {base.BillCount()} рубля(ей), составляет {Bill.sumBill- base.BillCount()} рублей.");
            return base.BillCount();
        }

        public void DisplayMenuFood(int numberMenu)
        {
            if (numberMenu is 1)
            {
                SushiDatabase dbSushi = new SushiDatabase();
                Sushi.PrintMenuSushi(dbSushi.GetSushi());
            }

            if (numberMenu is 2)
            {
                RollsDatabase dbRolls = new RollsDatabase();
                Rolls.PrintMenuRolls(dbRolls.GetRolls());
            }

            if (numberMenu is 3)
            {
                SauccesGarnish sg = new SauccesGarnish();
                Console.WriteLine("\n\t Меню соусы/гарниры:\n\nНОМЕР\tНАЗВАНИЕ\tЦЕНА\n");
                
                foreach (SauccesGarnish s in sg.MenuSauccesGarnishes())
                {
                    Console.WriteLine(s.Number + "\t" + s.Name + "\t " + s.Price);
                }
            }

            if (numberMenu is 4)
            {
                Drinks dr = new Drinks();
                Console.WriteLine("\n\t Меню напитков:\n\nНОМЕР\tНАЗВАНИЕ\tЦЕНА\n");
                
                foreach (Drinks d in dr.MenuDrinks())
                {
                    Console.WriteLine(d.Number + "\t" + d.Name + "\t\t" + d.Price);
                }
            }
        }
    }
}