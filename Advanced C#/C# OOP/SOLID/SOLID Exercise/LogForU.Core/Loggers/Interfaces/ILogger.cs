using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogForU.Core.Loggers.Interfaces
{
    public interface ILogger
    {

        void Info(string dateTime, string massage);
        void Warning(string dateTime, string massage);
        void Error(string dateTime, string massage);
        void Critical(string dateTime, string massage);
        void Fatal(string dateTime, string massage);

    }
}
