using Microsoft.AspNetCore.Mvc;
using SerraLinhasAereas.Domain;
using SerraLinhasAereas.Domain.Repositories;
using SerraLinhasAereas.Infra.Data;
using System;

namespace SerraLinhasAereas.WebApi.Controllers
{
    [ApiController]
    [Route("api/passagens")]
    public class PassagensControllers : ControllerBase
    {
        private readonly IPassagensRepository _passagensRepository;

        public PassagensControllers()
        {
            _passagensRepository = new PassagemRepository();
        }

        [HttpPost]
        public IActionResult PostPassagem(Passagens novaPassagem)
        {
            try
            {
                _passagensRepository.AdiconarPassagem(novaPassagem);
                return Ok("Passagem cadastrada com sucesso!");
            }
            catch (Exception e)
            {

                throw new Exception($"Erro ao cadastrar passagem: {e}"); ;
            }
            
        }

        [HttpDelete]
        public IActionResult DeletePassagem(int id)
        {
            _passagensRepository.DeletarPassagem(id);
            return Ok("Deletado com sucesso!");
        }

        [HttpPut]
        public IActionResult AtulizarPassagem(Passagens passagens)
        {
            _passagensRepository.AtualizarPassagem(passagens);
            return Ok($"Passagem modificada com sucesso!");
        }

        [HttpGet]
        public IActionResult GetPassagens()
        {
            var todasPassagens = _passagensRepository.BuscarTodasPassagens();
            if (todasPassagens.Count == 0)
                return BadRequest("Nenhuma passagem encontrado!");
            return Ok(todasPassagens);
        }

        [HttpGet("passagemDestino/{destino}")]
        public IActionResult GetPassagemDestino(string destino)
        {
            var passagemDestino = _passagensRepository.BuscarPassagemDestino(destino);
            if (passagemDestino.Count == 0)
                return BadRequest("Nenhuma passagem encontrado!");
            return Ok(passagemDestino);
        }

        [HttpGet("passagemOrigem/{origem}")]
        public IActionResult GetPassagemOrigem(string origem)
        {
            var passagemOrigem = _passagensRepository.BuscarPassagemOrigem(origem);
            if (passagemOrigem.Count == 0)
                return BadRequest("Nenhuma passagem encontrado!");
            return Ok(passagemOrigem);
        }

        [HttpGet("passagensDataDestino/{dataDestino}")]
        public IActionResult GetPassagemDataDestino(DateTime dataPassagemDestino)
        {
            var passagensDataDestino = _passagensRepository.BuscarPassagemDataDestino(dataPassagemDestino);
            if (passagensDataDestino.Count == 0)
                return BadRequest("Nenhuma passagem encontrado!");
            return Ok(passagensDataDestino);
        }
        [HttpGet("passagemDataOrigem/{dataOrigem}")]
        public IActionResult GetPassagemDataOrigem(DateTime dataPassagemOrigem)
        {
            var passagemDataOrigem = _passagensRepository.BuscarPassagemDataOrigem(dataPassagemOrigem);
            if (passagemDataOrigem.Count == 0)
                return BadRequest("Nenhuma passagem encontrado!");
            return Ok(passagemDataOrigem);
        }


    }
}
