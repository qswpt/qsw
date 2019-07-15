using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Framework.Common.Exceptions
{
    public class MessageException : Exception
    {
        public MessageException(string message) : base(message)
        {
        }
    }
}
