using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class PlataformaRepository : IPlataformaRepository
    {
        public void Atualizar(Plataforma plataforma)
        {
            using(OpFlixContext ctx = new OpFlixContext())
            {
                Plataforma PlataformaBuscada = ctx.Plataforma.FirstOrDefault(x => x.IdPlataforma == plataforma.IdPlataforma);
                PlataformaBuscada.NomePlataforma = plataforma.NomePlataforma;
                ctx.Plataforma.Update(PlataformaBuscada);
                ctx.SaveChanges();
            }
        }

        public Plataforma BuscarPorId(int id)
        {
            using(OpFlixContext ctx = new OpFlixContext())
            {
               return ctx.Plataforma.FirstOrDefault(x => x.IdPlataforma == id);
            }
        }

        public Plataforma BuscarPorPlataforma(string plataforma)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Plataforma.FirstOrDefault(x => x.NomePlataforma == plataforma);
            }
        }

        public void Cadastrar(Plataforma plataforma)
        {
            using(OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Plataforma.Add(plataforma);
                ctx.SaveChanges();
            }
        }

        public List<Plataforma> Listar()
        {
            using(OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Plataforma.ToList();
            }
        }
    }
}
