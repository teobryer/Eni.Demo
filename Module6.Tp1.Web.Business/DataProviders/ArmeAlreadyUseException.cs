using System;
using System.Runtime.Serialization;

namespace Module6.Tp1.Web.Business.DataProviders
{
    [Serializable]
    public class ArmeAlreadyUseException : Exception
    {
        public ArmeAlreadyUseException()
        {
        }

        public ArmeAlreadyUseException(string message) : base(message)
        {
        }

        public ArmeAlreadyUseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ArmeAlreadyUseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}