using System;
using System.Runtime.Serialization;

namespace Dal.Dal
{
    [Serializable]
    internal class EntityExistsException : Exception
    {
        public EntityExistsException()
        {
        }

        public EntityExistsException(string message) : base(message)
        {
        }

        public EntityExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EntityExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}