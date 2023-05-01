using SerraLinhasAereas.Domain;
using SerraLinhasAereas.Domain.ExceptionClasses;
using SerraLinhasAereas.Domain.Repositories;
using SerraLinhasAereas.Infra.Data.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerraLinhasAereas.Infra.Data
{
    public class ClienteRepository : IClienteRepository
    {
        ClienteDao _clienteDao = new ClienteDao();

        public void AtualizarCliente(Cliente clienteAtualizar)
        {
            var validarSeClienteExiste = _clienteDao.BuscarClienteCpf(clienteAtualizar.Cpf);
            if(validarSeClienteExiste == null)
            {
                throw new ClienteNaoEncontrado("Nenhum cliente encontrado com o Cpf informado!");
            }

            _clienteDao.AtualizarCliente(clienteAtualizar);
        }

        public Cliente BuscarClienteCPF(int Cpf)
        {
            var validarSeClienteExiste = _clienteDao.BuscarClienteCpf(Cpf);
            if (validarSeClienteExiste == null)
            {
                throw new ClienteNaoEncontrado("Nenhum cliente encontrado com o Cpf informado!");
            }

            var clienteBuscado = _clienteDao.BuscarClienteCpf(Cpf);
            return clienteBuscado;
        }

        public List<Cliente> BuscarTodosCliente()
        {
            var listaCliente = _clienteDao.BuscarTodosCliente();
            return listaCliente;
        }

        public void DeletarCliente(int Cpf)
        {
            var validarSeClienteExiste = _clienteDao.BuscarClienteCpf(Cpf);
            if (validarSeClienteExiste == null)
            {
                throw new ClienteNaoEncontrado("Nenhum cliente encontrado com o Cpf informado!");
            }

            _clienteDao.DeletarCliente(Cpf);
        }

        public void AdicionarCliente(Cliente clienteInserir)
        {
            _clienteDao.AdicionarCliente(clienteInserir);
        }
    }
}
