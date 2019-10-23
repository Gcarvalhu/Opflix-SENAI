//using Senai.OpFlix.WebApi.Domains;
//using Senai.OpFlix.WebApi.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Senai.OpFlix.WebApi.Repositories
//{
//    public class FavoritosRepository : IFavoritos
//    {
//        public void Cadastrar(Favoritos favoritos)
//        {
//            using (OpFlixContext ctx = new OpFlixContext())
//            {
//                ctx.Favoritos.Add(favoritos);
//                ctx.SaveChanges();
//            }
//        }

//        public List<Favoritos> Listar()
//        {
//            using (OpFlixContext ctx = new OpFlixContext())
//            {
//                return ctx.Favoritos.ToList();
//            }
//        }
//    }
//}
