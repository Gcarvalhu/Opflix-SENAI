using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public opflixContext opflixContext = new opflixContext();

        public void Atualizar(Categoria categoria)
        {
            using (opflixContext ctx = new opflixContext())
            {
                Categoria CategoriaBuscada = ctx.Categoria.FirstOrDefault(x => x.IdCategoria == categoria.IdCategoria);
                CategoriaBuscada.NomeCategoria = categoria.NomeCategoria;
                ctx.Categoria.Update(CategoriaBuscada);
                ctx.SaveChanges();
            }
        }

        public Categoria BuscarPorId(int id)
        {
            using(opflixContext ctx = new opflixContext())
            {
                return ctx.Categoria.FirstOrDefault(x => x.IdCategoria == id);
            }
        }

        public void Cadastrar(Categoria categoria)
        {
            using (opflixContext ctx = new opflixContext())
            {
                ctx.Categoria.Add(categoria);
                ctx.SaveChanges();
            }
        }

        public List<Categoria> Listar()
        {
            using (opflixContext ctx = new opflixContext())
            {
                return ctx.Categoria.ToList();
            }
        }
    }
}
