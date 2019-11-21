using System;
using System.IO;

namespace FileWatcherService
{
    public static class Logger
    {
        public static void Log(string message)
        {
            try
            {
                var message_ = $"{message} {Environment.NewLine}";
                File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "Logfile.txt", message_);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}