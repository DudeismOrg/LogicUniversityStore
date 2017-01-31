using System;
using System.Runtime.Serialization;

namespace LogicUniversityStore.Controller
{
    [Serializable]
    internal class InvalidConstructorException : Exception
    {
        public InvalidConstructorException()
        {
        }

        public InvalidConstructorException(string message) : base(message)
        {
        }

        public InvalidConstructorException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidConstructorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}