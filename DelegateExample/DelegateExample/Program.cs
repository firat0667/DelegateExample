using System;
using System.IO;
namespace DelegateExample
{
   
    class Program
    {
        delegate void LogDel(string text);
        static void Main(string[] args)
        {
            Log log = new Log();
            LogDel LogtextToScreenDel, LogTextToFileDel;
            LogtextToScreenDel = new LogDel(log.LogTextToScreen);
            LogTextToFileDel = new LogDel(log.LogTextToFile);

            LogDel multiLogDel = LogtextToScreenDel + LogTextToFileDel;

            Console.WriteLine("Please Enter Your Name");
            var name = Console.ReadLine();

            LogText(multiLogDel, name);

            Console.ReadKey();
        }
        static void LogText(LogDel logDel,string text)
        {
            logDel(text);
        }
      
    }
    public class Log
    {
       public void LogTextToScreen(string text)
        {
            Console.WriteLine($"{DateTime.Now}:{text}");
        }


       public void LogTextToFile(string text)
        {
            // save log pc 
            using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt"), true))
            {

                sw.WriteLine($"{DateTime.Now}:{text}");
            }
        }
    }
}
