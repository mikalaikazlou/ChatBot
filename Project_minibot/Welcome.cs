using System;

namespace Project_minibot
{
    class Welcome
    {
        public static void WelcomeCustomer()
        {
            int hour = DateTime.Now.Hour;
            
            if (hour >= 6 & hour < 12)
                Console.WriteLine("Доброе утро! Как Вас зовут?");
            else if (hour >= 12 & hour < 18)
                Console.WriteLine("Добрый день! Как Вас зовут?");
            else if (hour >= 18 & hour < 23)
                Console.WriteLine("Добрый вечер! Как Вас зовут?");
            else if (hour >= 23 || hour < 6 || hour>=0)
                Console.WriteLine("Доброй ночи! Как Вас зовут?");
        }
    }
}