//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Senai.OpFlix.WebApi.Domains;
//using Senai.OpFlix.WebApi.Interfaces;
//using Senai.OpFlix.WebApi.Repositories;

//namespace Senai.OpFlix.WebApi.Controllers
//{
//    [Route("api/[controller]")]
//    [Produces("application/json")]
//    [ApiController]
//    public class FavoritosController : ControllerBase
//    {
//        private IFavoritos FavoritosRepository { get; set; }

//        public FavoritosController()
//        {
//            FavoritosRepository = new FavoritosRepository();
//        }
//        [Authorize]
//        [HttpGet]
//        public IActionResult Listar()
//        {
//            return Ok(FavoritosRepository.Listar());
//        }
//        [Authorize]
//        [HttpPost]
//        public IActionResult Cadastrar(Favoritos favorito)
//        {
//            FavoritosRepository.Cadastrar(favorito);
//            return Ok();
//        }
//    }
//}