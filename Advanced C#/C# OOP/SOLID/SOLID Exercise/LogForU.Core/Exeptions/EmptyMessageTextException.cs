using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogForU.Core.Exeptions
{
    public class EmptyMessageTextException : Exception
    {
        private const string DefaultMessage = "Text message cannot be null or white spase!";
        public EmptyMessageTextException() : base(DefaultMessage)            
        {

        }
        public EmptyMessageTextException(string message) :
            base(message)
        {

        }
    }
}
