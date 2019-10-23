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
    [ApiController]
    public class PlataformaController : ControllerBase
    {
        private IPlataformaRepository PlataformaRepository { get; set; }

        public PlataformaController()
        {
            PlataformaRepository = new PlataformaRepository();
        }
        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(PlataformaRepository.Listar());
        }
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Plataforma plataforma)
        {
            PlataformaRepository.Cadastrar(plataforma);
            return Ok();
        }
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut]
        public IActionResult Atualizar(Plataforma plataforma)
        {
            Plataforma PlataformaBuscada = PlataformaRepository.BuscarPorId(plataforma.IdPlataforma);
            if (PlataformaBuscada == null)
                return NotFound();
            PlataformaRepository.Atualizar(plataforma);
            return Ok();
        }
        [Authorize]
        [HttpGet("Filtro/{plataforma}")]
        public IActionResult BuscarPorNomePlataforma(string plataforma)
        {
            try
            {
                Plataforma varplataforma = PlataformaRepository.BuscarPorPlataforma(plataforma);
                if (varplataforma == null)
                    return NotFound();
                return Ok(plataforma);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}