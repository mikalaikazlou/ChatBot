using System;
using System.IO;

namespace Project_minibot.Logger
{
    class Logger
    {
        private const long maxSize = 30000;
        public static int Count { get; set;}
       
        public enum LogStatus
        {
            INFO,
            DEBUG,
            ERROR
        }

        public static void Verify()
        {
            FileInfo info=new FileInfo($@"D:\itacademy\DOTNET_PROJECT_miniBot\Project_minibot\Logger\logs\log {DateTime.Now:yyyyMMdd}_[{Count}].txt");
            if (info.Exists)
            {
                Console.WriteLine("log exists");
            }
            else
            {
                Console.WriteLine("log dosn't exists");
            }

        }
        public static async void LoggerCreat(string nameSpace, string methodName,LogStatus status, string message)
        {
            string path = $@"D:\itacademy\DOTNET_PROJECT_miniBot\Project_minibot\Logger\logs\log {DateTime.Now:yyyyMMdd}_[{Count}].txt";
            FileInfo fileInfo = new FileInfo(path);
            FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);
            long sizeFile = fileStream.Length;
            fileStream.Close();
        
            if (fileInfo.Exists && sizeFile > maxSize)
            {
                try
                {
                    int num1 = path.IndexOf('[') + 1;
                    int num2 = path.IndexOf(']');
                    int leng = num2 - num1;
                    string numb = path.Substring(num1, leng);
                    int number = Convert.ToInt32(numb);
                    ++number;
                    Count = number;
                    string path1 = $@"D:\log {DateTime.Now:yyyyMMdd}_[{number}].txt";

                    using (StreamWriter streamWrite = new StreamWriter(path1, true))
                    {
                        await streamWrite.WriteLineAsync($"{DateTime.Now:g}   {status}   {nameSpace.ToString()}   {methodName.ToString()}   {message}");
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(path, true))
                {
                    await streamWriter.WriteLineAsync($"{DateTime.Now:g}   {status}   {nameSpace.ToString()}   {methodName.ToString()}   {message}");
                }
            }
        }
    }
}