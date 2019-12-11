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
            using(opflixContext ctx = new opflixContext())
            {
                Plataforma PlataformaBuscada = ctx.Plataforma.FirstOrDefault(x => x.IdPlataforma == plataforma.IdPlataforma);
                PlataformaBuscada.NomePlataforma = plataforma.NomePlataforma;
                ctx.Plataforma.Update(PlataformaBuscada);
                ctx.SaveChanges();
            }
        }

        public Plataforma BuscarPorId(int id)
        {
            using(opflixContext ctx = new opflixContext())
            {
               return ctx.Plataforma.FirstOrDefault(x => x.IdPlataforma == id);
            }
        }

        public Plataforma BuscarPorPlataforma(string plataforma)
        {
            using (opflixContext ctx = new opflixContext())
            {
                return ctx.Plataforma.FirstOrDefault(x => x.NomePlataforma == plataforma);
            }
        }

        public void Cadastrar(Plataforma plataforma)
        {
            using(opflixContext ctx = new opflixContext())
            {
                ctx.Plataforma.Add(plataforma);
                ctx.SaveChanges();
            }
        }

        public List<Plataforma> Listar()
        {
            using(opflixContext ctx = new opflixContext())
            {
                return ctx.Plataforma.ToList();
            }
        }
    }
}
