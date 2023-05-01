using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerraLinhasAereas.Domain.Repositories
{
    public interface IPassagensRepository
    {
        public void AdiconarPassagem(Passagens passagem);
        public List<Passagens> BuscarTodasPassagens();
        public List<Passagens> BuscarPassagemDataOrigem(DateTime dataPassagemOrigem);
        public List<Passagens> BuscarPassagemDataDestino(DateTime dataPassagemDestino);
        public List<Passagens> BuscarPassagemOrigem(string origem);
        public List<Passagens> BuscarPassagemDestino(string destino);
        public void AtualizarPassagem(Passagens passagens);
        public void DeletarPassagem(int id);
    }
}
