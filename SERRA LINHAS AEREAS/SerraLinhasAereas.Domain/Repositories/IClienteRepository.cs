using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerraLinhasAereas.Domain.Repositories
{
    public interface IClienteRepository
    {
        public Cliente BuscarClienteCPF(int cpf);
        public List<Cliente> BuscarTodosCliente();
        public void AtualizarCliente(Cliente clienteAtualizar);
        public void DeletarCliente(int Cpf);
        public void AdicionarCliente(Cliente clienteInserir);
    }
}
