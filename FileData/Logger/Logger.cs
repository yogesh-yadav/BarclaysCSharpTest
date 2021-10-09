using System;

namespace FileData.Logger
{
    public static class Logger
    {
        public static void Error(string type, string message)
        {
            Console.WriteLine(string.Format("Error: {0} - {1}", type, message));
        }

        public static void Info(string message)
        {
            Console.WriteLine(string.Format("Info: {0}", message));
        }
    }
}
