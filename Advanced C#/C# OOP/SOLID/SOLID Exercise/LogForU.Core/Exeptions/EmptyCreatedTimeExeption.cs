using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogForU.Core.Exeptions
{
    public class EmptyCreatedTimeException : Exception
    {
        private const string DefaultMessage = "Created time of a message cannot be null or white spase!";
        public EmptyCreatedTimeException() :
            base(DefaultMessage)
        {

        }
        public EmptyCreatedTimeException(string message) :
            base(message)        
        {

        }
    }
}
