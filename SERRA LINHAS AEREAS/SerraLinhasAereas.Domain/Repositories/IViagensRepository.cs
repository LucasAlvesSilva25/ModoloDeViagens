using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerraLinhasAereas.Domain.Repositories
{
    public interface IViagensRepository
    {
        public void MarcarViagem(Viagens viagem);
        public List<Viagens> BuscarTodasViagensCliente(int CPF);
        public void RemarcarViagem(Viagens viagem);
    }
}
