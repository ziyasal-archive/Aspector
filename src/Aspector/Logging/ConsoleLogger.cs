using System;
using Aspector.Interface;

namespace Aspector.Logging
{
    public class ConsoleLogger : ILogger
    {
        public void Debug(string message)
        {
            Console.WriteLine(message);
        }

        public void Debug(string message, Exception exception)
        {
            Console.WriteLine("DEBUG: Message: {0}, Exception:{1}", message, exception.Message);
        }

        public void Error(string message)
        {
            Console.WriteLine(message);
        }

        public void Error(string message, Exception exception)
        {
            Console.WriteLine("ERROR: Message: {0}, Exception:{1}", message, exception.Message);
        }

        public void Info(string message)
        {
            Console.WriteLine(message);
        }

        public void Info(string message, Exception exception)
        {
            Console.WriteLine("INFO: Message: {0}, Exception:{1}", message, exception.Message);
        }

        public void Warn(string message)
        {
            Console.WriteLine(message);
        }

        public void Warn(string message, Exception exception)
        {
            Console.WriteLine("WARNING: Message: {0}, Exception:{1}", message, exception.Message);
        }

        public void Fatal(string message)
        {
            Console.WriteLine(message);
        }

        public void Fatal(string message, Exception exception)
        {
            Console.WriteLine("FATAL: Message: {0}, Exception:{1}", message, exception.Message);
        }
    }
}