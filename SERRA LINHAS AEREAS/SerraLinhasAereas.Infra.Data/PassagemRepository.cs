using SerraLinhasAereas.Domain;
using SerraLinhasAereas.Domain.Repositories;
using SerraLinhasAereas.Infra.Data.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerraLinhasAereas.Infra.Data
{
    public class PassagemRepository : IPassagensRepository
    {
        PassagensDao _passagensDao = new PassagensDao();
        public void AdiconarPassagem(Passagens passagem)
        {
            _passagensDao.AdiconarPassagem(passagem);
        }

        public void AtualizarPassagem(Passagens passagens)
        {
            var validarSePassagemExiste = _passagensDao.BuscarPassagemID(passagens.ID);
            if (validarSePassagemExiste == null)
            {
                throw new Exception("Nenhum passagem encontrada com o ID informado!");
            }
            _passagensDao.AtualizarPassagem(passagens);
        }

        public List<Passagens> BuscarPassagemDataDestino(DateTime dataPassagemDestino)
        {
            var passagensDataDestino = _passagensDao.BuscarPassagemDataDestino(dataPassagemDestino);
            return passagensDataDestino;
        }

        public List<Passagens> BuscarPassagemDataOrigem(DateTime dataPassagemOrigem)
        {
            var passagemDataOrigem = _passagensDao.BuscarPassagemDataOrigem(dataPassagemOrigem);
            return passagemDataOrigem;
        }

        public List<Passagens> BuscarPassagemDestino(string destino)
        {
            var passagemDestino = _passagensDao.BuscarPassagemDestino(destino);
            return passagemDestino;
        }

        public List<Passagens> BuscarPassagemOrigem(string origem)
        {
            var passagemOrigem = _passagensDao.BuscarPassagemOrigem(origem);
            return passagemOrigem;
        }

        public List<Passagens> BuscarTodasPassagens()
        {
            var todasPassagens = _passagensDao.BuscarTodasPassagens();
            return todasPassagens;
        }

        public void DeletarPassagem(int id)
        {
            var validarSePassagemExiste = _passagensDao.BuscarPassagemID(id);
            if (validarSePassagemExiste == null)
            {
                throw new Exception("Nenhum passagem encontrada com o ID informado!"); 
            }
            _passagensDao.DeletarPassagem(id);
        }
    }
}
