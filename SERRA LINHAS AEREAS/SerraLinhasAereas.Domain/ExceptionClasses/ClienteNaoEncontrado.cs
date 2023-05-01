using System;
using System.Runtime.Serialization;

namespace SerraLinhasAereas.Domain.ExceptionClasses
{
    [Serializable]
    public class ClienteNaoEncontrado : Exception
    {
        public ClienteNaoEncontrado()
        {
        }

        public ClienteNaoEncontrado(string message) : base(message)
        {
        }

        public ClienteNaoEncontrado(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ClienteNaoEncontrado(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}