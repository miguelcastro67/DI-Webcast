using System;
using System.Linq;

namespace DI.Tutorial.Stage3
{
    public class Logger : ILogger
    {
        void ILogger.Log(string message)
        {
            Type thisType = this.GetType();
            Console.WriteLine("Message logged: {0}", message);
        }
    }

    public interface ILogger
    {
        void Log(string message);
    }
}
