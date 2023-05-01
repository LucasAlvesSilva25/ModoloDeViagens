using SerraLinhasAereas.Domain;
using SerraLinhasAereas.Domain.Repositories;
using SerraLinhasAereas.Domain.ExceptionClasses;
using SerraLinhasAereas.Infra.Data.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerraLinhasAereas.Infra.Data
{
    public class ViagensRepository : IViagensRepository
    {
        ViagensDao _viagensDao = new ViagensDao();
        ClienteDao _clienteDao = new ClienteDao();
        PassagensDao _passagensDao = new PassagensDao();

        public List<Viagens> BuscarTodasViagensCliente(int Cpf)
        {
            var cliente = _clienteDao.BuscarClienteCpf(Cpf);
            if (cliente == null)
            {
                throw new ClienteNaoEncontrado("Nenhum cliente encontrado com o Cpf informado!");
            }

            var viagensEncontradas = _viagensDao.BuscarTodasViagensCliente(Cpf);
            return viagensEncontradas;
        }
        public void MarcarViagem(Viagens viagens)
        {
            // GERAR DADOS DE VIAGEM E VALIDAR INFORMAÇÕES

            // Validar passagens
            var validarSePassagemIdaEstarDisponivel = _viagensDao.BuscarPassagemId(viagens.PassagemIda.ID);
            
            if (validarSePassagemIdaEstarDisponivel != null)
            {
                throw new PassagensNaoDisponivel("Passagem já vinculada a outra viagem!");
            }

            var validarSePassagemVoltaEstarDisponivel = _viagensDao.BuscarPassagemId(viagens.PassagemVolta.ID);

            if (validarSePassagemVoltaEstarDisponivel != null)
            {
                throw new PassagensNaoDisponivel("Passagem já vinculada a outra viagem!");
            }

            viagens.PassagemIda = _passagensDao.BuscarPassagemID(viagens.PassagemIda.ID); // Necessário buscar viagem Ida para montar o Resumo da viagem
            viagens.PassagemVolta = _passagensDao.BuscarPassagemID(viagens.PassagemVolta.ID);  // Necessário buscar viagem Volta para montar o Resumo da viagem          
            viagens.ClienteViagens = _clienteDao.BuscarClienteCpf(viagens.ClienteViagens.Cpf); // Validar se cliente Existe e buscar informações para montar Resumo da viagem

            if (viagens.ClienteViagens == null)
            {
                throw new ClienteNaoEncontrado("Nenhum cliente encontrado com o Cpf informado!");
            }

            viagens.GerarResumoViagens(viagens.IdaVolta); // Gerar resumo da viagem

            _viagensDao.MarcarViagem(viagens);
        }
        public void RemarcarViagem(Viagens viagem)
        {
            // É necessário realizar a validação das informações antes de editar? 

            viagem.PassagemIda = _passagensDao.BuscarPassagemID(viagem.PassagemIda.ID); // Necessário buscar viagem Ida para montar o Resumo
            viagem.PassagemVolta = _passagensDao.BuscarPassagemID(viagem.PassagemVolta.ID);  // Necessário buscar viagem Volta para montar o Resumo  
            viagem.ClienteViagens = _clienteDao.BuscarClienteCpf(viagem.ClienteViagens.Cpf); // Necessário buscar Cliente para montar o Resumo
            viagem.GerarResumoViagens(viagem.IdaVolta); // Atualizar resumo da viagem
            _viagensDao.RemarcarViagem(viagem);
        }
    }
}
