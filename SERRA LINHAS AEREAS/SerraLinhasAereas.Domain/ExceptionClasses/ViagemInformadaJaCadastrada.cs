using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerraLinhasAereas.Domain.ExceptionClasses
{
    public class ViagemInformadaJaCadastrada : Exception
    {
        public ViagemInformadaJaCadastrada()
        {
        }

        public ViagemInformadaJaCadastrada(string message) : base(message)
        {
        }
    }
}
