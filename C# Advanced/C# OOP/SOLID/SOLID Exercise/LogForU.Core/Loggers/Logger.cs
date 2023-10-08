using LogForU.Core.Appenders.Interfaces;
using LogForU.Core.Enum;
using LogForU.Core.Loggers.Interfaces;
using LogForU.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogForU.Core.Loggers
{
    public class Logger : ILogger
    {
        private readonly ICollection<IAppender> appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        public void Info(string dateTime, string massage)
        {
            AppendAll(dateTime, massage, ReportLevel.Info);
        }
        public void Warning(string dateTime, string massage)
        {
            AppendAll(dateTime, massage, ReportLevel.Warning);
        }        

        public void Error(string dateTime, string massage)
        {
            AppendAll(dateTime, massage, ReportLevel.Error);
        }

        public void Critical(string dateTime, string massage)
        {
            AppendAll(dateTime, massage, ReportLevel.Critical);
        }

        public void Fatal(string dateTime, string massage)
        {
            AppendAll(dateTime, massage, ReportLevel.Fatal);
        }
        private void AppendAll(string dateTime, string text, ReportLevel reportLevel)
        {
            Message message = new Message(dateTime, text, reportLevel);
             
            foreach (var appender in appenders)
            {
                if (message.ReportLevel >= appender.ReportLevel)
                {
                    appender.AppendMessage(message);                    
                }

            }
        }

    }
}
