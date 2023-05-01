using Microsoft.AspNetCore.Mvc;
using SerraLinhasAereas.Domain;
using SerraLinhasAereas.Domain.Repositories;
using SerraLinhasAereas.Infra.Data;
using System;

namespace SerraLinhasAereas.WebApi.Controllers
{
    [ApiController]
    [Route("api/viagens")]
    public class ViagensControllers : ControllerBase
    {
        private readonly IViagensRepository _repository;

        public ViagensControllers()
        {
            _repository = new ViagensRepository();
        }

        [HttpPost]
        public IActionResult PostViagem(Viagens viagem)
        {     
            try
            {
                _repository.MarcarViagem(viagem);
                return Ok("Viagem cadastrada com sucesso!");
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao cadastrar viagem: '{e}'");
            }
        }

        [HttpPut]
        public IActionResult RemarcarViagem(Viagens viagem)
        {
            _repository.RemarcarViagem(viagem);
            return Ok("Viagem remarcada com sucesso!");
        }

        [HttpGet]
        public IActionResult GetViagensDeUmCliente(int cpf)
        {
            try
            {
                var todosClientes = _repository.BuscarTodasViagensCliente(cpf);
                if (todosClientes.Count == 0)
                    return BadRequest("Nenhum viagem encontrada com esse CPF!");
                return Ok(todosClientes);
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao buscar Viagem: '{e}'");
            }
        }

    }
}
