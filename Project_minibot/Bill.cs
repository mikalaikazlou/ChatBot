using System;
using System.IO;
using Project_minibot.Food;

namespace Project_minibot
{
    class Bill
    {
        public static double sumBill = Sushi.Sum + Rolls.Sum + Drinks.getSumDrinks + SauccesGarnish.getSumSaucces;
       
        public virtual double BillCount()
        {
            double percent = 0.0;
            var day = DateTime.Now.DayOfWeek;

            switch (day)
            {
                case DayOfWeek.Monday:
                case DayOfWeek.Tuesday: 
                    percent = (double)DayDiscount.Monday;
                    break;
                case DayOfWeek.Wednesday:
                case DayOfWeek.Thursday:
                case DayOfWeek.Friday:
                    percent = (double)DayDiscount.Wednesday;
                    break;
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    percent = (double)DayDiscount.Saterday;
                    break;
            }
            
            double sumSale = (sumBill * percent) / 100;
            return sumSale;
        }

        public void WriteBill()
        {
            string path = @"D:\itacademy\DOTNET_PROJECT_miniBot\Project_minibot\The_Bill.txt";

            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                fileStream.Close();
                StreamWriter newWriter = new StreamWriter(path);
                newWriter.WriteLine($"{AddressCustomer.NameCustomer}, Ваш заказ успешно оформлен");
                newWriter.WriteLine($"\nСумма Вашего заказа составила {Bill.sumBill} рублей!");
                newWriter.WriteLine($"\nВключая: \nСуши - {Sushi.Sum} рублей\nРоллы - {Rolls.Sum} рублей\nСоусы/Гарниры - {SauccesGarnish.getSumSaucces} рублей\nНапитки - {Drinks.getSumDrinks} рублей.");
                newWriter.WriteLine($"\nСумма к оплате, с учетом скидки {BillCount()} рубля(ей), составляет {Bill.sumBill - BillCount()} рублей!");
                newWriter.Close();
            }

            Logger.Logger.LoggerCreat("Project_minibot", "WriteBill", 0, "Чек заказа успешно оформлен");
        }
    }
}