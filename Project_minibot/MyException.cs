using System;

namespace Project_minibot
{
    public class MyExceptionMessage:Exception
    {
       public MyExceptionMessage (string message):base(message)
        {
            Console.WriteLine(message);
        }
    }
}