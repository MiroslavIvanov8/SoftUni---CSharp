using LogForU.Core.Appenders.Interfaces;
using LogForU.Core.Enum;
using LogForU.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogForU.Core.Appenders
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ReportLevel reportLevel = ReportLevel.Info)
        {
            ReportLevel = reportLevel; 
        }
        public ReportLevel ReportLevel { get; set; }
        public int MessegesAppended { get; set; }

        public void AppendMessage(Message message)
        {
            //TODO : Layout
            Console.WriteLine(message.CreatedTime);
            Console.WriteLine(message.Text);
            Console.WriteLine(message.ReportLevel.ToString());
            MessegesAppended++;
        }
    }
}
