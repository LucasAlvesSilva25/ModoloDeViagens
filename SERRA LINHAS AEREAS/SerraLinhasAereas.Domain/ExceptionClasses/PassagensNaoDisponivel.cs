using System;
using System.Runtime.Serialization;

namespace SerraLinhasAereas.Domain.ExceptionClasses
{
    [Serializable]
    public class PassagensNaoDisponivel : Exception
    {
        public PassagensNaoDisponivel()
        {
        }

        public PassagensNaoDisponivel(string message) : base(message)
        {
        }
    }
}
