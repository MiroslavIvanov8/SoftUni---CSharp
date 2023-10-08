using LogForU.Core.Appenders;
using LogForU.Core.Enum;
using LogForU.Core.Loggers;
using LogForU.Core.Loggers.Interfaces;

namespace LofForU.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var consoleAppender = new ConsoleAppender();
            consoleAppender.ReportLevel = ReportLevel.Error;

            var logger = new Logger(consoleAppender);

            logger.Info("3/31/2015 5:33:07 PM", "Everything seems fine");
            logger.Warning("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent");
            logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
            logger.Critical("3/31/2015 5:33:07 PM", "No connection string found in App.config");
            logger.Fatal("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond");


        }
    }
}