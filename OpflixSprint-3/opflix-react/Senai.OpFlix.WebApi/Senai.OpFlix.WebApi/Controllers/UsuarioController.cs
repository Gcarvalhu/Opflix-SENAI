using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.Repositories;
using Senai.OpFlix.WebApi.ViewModels;

namespace Senai.OpFlix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        IUsuarioRepository UsuarioRepository { get; set; }

        public UsuarioController()
        {
            UsuarioRepository = new UsuarioRepository();
        }
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(UsuarioRepository.Listar());
        }
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut]
        public IActionResult Atualizar(Usuarios usuario)
        {
            try
            {

                Usuarios UsuarioBuscado = UsuarioRepository.BuscarPorId(usuario.IdUsuario);

                if (UsuarioBuscado == null)
                    return NotFound();

                UsuarioRepository.Atualizar(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "ERRO" });
            }
        }
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId (int id)
        {
            try
            {
                Usuarios usuario = UsuarioRepository.BuscarPorId(id);
                if (usuario == null)
                    return NotFound();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
        [HttpPost] 
        public IActionResult Cadastrar (Usuarios usuario)
        {
            try
            {
                UsuarioRepository.Cadastrar(usuario);
                LoginViewModel login = new LoginViewModel();
                login.Email = usuario.Email;
                login.Senha = usuario.Senha;

                Usuarios usuarioBuscado = UsuarioRepository.BuscarPorEmailSenha(login);
                if (usuarioBuscado == null)
                {
                    return NotFound(new { mensagem = "Errou feio colega" });
                }

                var claims = new[]
                {
                    new Claim("foto", usuarioBuscado.FotoUsuario),
                    new Claim("nome", usuarioBuscado.Nome),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role,usuarioBuscado.Permissao),
                };
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("opflix-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "OpFlix.WebApi",
                    audience: "OpFlix.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            }   
            catch (Exception ex)
            {
                return BadRequest();
            }    
        }
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar (int id)
        {
            UsuarioRepository.Deletar(id);
            return Ok();
        } 
    }
}   