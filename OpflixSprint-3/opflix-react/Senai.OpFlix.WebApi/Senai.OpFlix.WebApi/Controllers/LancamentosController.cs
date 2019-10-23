using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.Repositories;

namespace Senai.OpFlix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LancamentosController : ControllerBase
    {
        private ILancamentosRepository LancamentosRepository { get; set; }

        public LancamentosController()
        {
            LancamentosRepository = new LancamentosRepository();
        }
        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(LancamentosRepository.Listar());
        }
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut]
        public IActionResult Atualizar(Lancamentos lancamento)
        {
            try
            {
                Lancamentos LancamentoBuscado = LancamentosRepository.BuscarPorId(lancamento.IdLanc);

                if (LancamentoBuscado == null)
                    return NotFound();

                LancamentosRepository.Atualizar(lancamento);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "ERRO" +ex.Message});
            }
        }
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Lancamentos lancamento = LancamentosRepository.BuscarPorId(id);
                if (lancamento == null)
                    return NotFound();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Lancamentos lancamento)
        {
            try
            {
                if (lancamento == null)
                {
                    return BadRequest(new { mensagem = "Não cadastrado, algum dado nulo ;-;" });
                }
                LancamentosRepository.Cadastrar(lancamento);

                return Ok();

            }
            catch (Exception exe)
            {
                return BadRequest(new { mensagem = "Erro eminente ao cadastrar, veja mais meu caro >:" + exe.Message });
            }                   
        }
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            LancamentosRepository.Deletar(id);
            return Ok();
        }
        [Authorize]
        [HttpGet("Filtro/{DataLanc}")]
        public IActionResult BuscarPorData(DateTime DataLanc)
        {
            try
            {
                Lancamentos lancamento = LancamentosRepository.BuscarPorData(DataLanc);
                if (lancamento == null)
                    return NotFound();
                return Ok(DataLanc);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}