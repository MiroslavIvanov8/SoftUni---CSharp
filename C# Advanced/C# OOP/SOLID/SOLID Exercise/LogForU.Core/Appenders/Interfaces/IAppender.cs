using LogForU.Core.Enum;
using LogForU.Core.Models;

namespace LogForU.Core.Appenders.Interfaces
{
    public interface IAppender
    {
        //TODO : Add Layout
        ReportLevel ReportLevel { get; set; }
        int MessegesAppended { get; }
        void AppendMessage(Message message);
    }
}