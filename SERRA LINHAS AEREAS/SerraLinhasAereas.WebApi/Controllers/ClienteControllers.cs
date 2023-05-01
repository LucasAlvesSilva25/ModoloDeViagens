using Microsoft.AspNetCore.Mvc;
using SerraLinhasAereas.Domain;
using SerraLinhasAereas.Domain.Repositories;
using SerraLinhasAereas.Infra.Data;
using System;
using System.Text.Json;

namespace SerraLinhasAereas.WebApi.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClienteControllers : ControllerBase
    {
        private readonly IClienteRepository _repository;

        public ClienteControllers()
        {
            _repository = new ClienteRepository();
        }

        [HttpPost]
        public IActionResult PostCliente(Cliente novoCliente)
        {
            try
            {
                _repository.AdicionarCliente(novoCliente);
                return Ok("Cliente cadastrado com sucesso!");
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao cadastrar cliente: {e}");
            }
            
        }

        [HttpPut]
        public IActionResult AtualizarCliente(Cliente modificarCliente)
        {
            _repository.AtualizarCliente(modificarCliente);
            return Ok($"Cliente modificado com sucesso!");
        }

        [HttpDelete]
        public IActionResult DeletarCliente(int Cpf)
        {
            _repository.DeletarCliente(Cpf);
            return Ok("Deletado com sucesso!");
        }

        [HttpGet]
        public IActionResult GetCliente()
        {
            var todosClientes = _repository.BuscarTodosCliente();
            if (todosClientes.Count == 0)
                return BadRequest("Nenhum cliente encontrado!");
            return Ok(todosClientes);
        }

        [HttpGet("{Cpf}")]
        public IActionResult GetCleinteCpf(int Cpf)
        {
            var clienteEncontrado = _repository.BuscarClienteCPF(Cpf);
            return Ok(clienteEncontrado);
        }

    }
}