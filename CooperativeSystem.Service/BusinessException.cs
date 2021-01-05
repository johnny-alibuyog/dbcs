using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters
{
    public class BusinessException : Exception
    {
        public BusinessException(string message)
            : base(message) { }

        public BusinessException(string message, Exception innerException)
            : base(message, innerException) { }

        public BusinessException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext contex)
            : base(info, contex) { }
    }
}
