using Microsoft.EntityFrameworkCore;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class LancamentosRepository : ILancamentosRepository
    {
        public void Atualizar(Lancamentos lancamento)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Lancamentos LancamentoBuscado = ctx.Lancamentos.FirstOrDefault(x => x.IdLanc == lancamento.IdLanc);
                // update categorias set nome = @nome
                LancamentoBuscado.Titulo = lancamento.Titulo;
                // insert - add, delete - remove, update - update
                ctx.Lancamentos.Update(LancamentoBuscado);
                // efetivar
                ctx.SaveChanges();
            }
        }

        public Lancamentos BuscarPorData(DateTime DataLancamento)
        {
            using(OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Lancamentos.FirstOrDefault(x => x.DataLanc == DataLancamento);
            }
        }

        public Lancamentos BuscarPorId(int id)
        {
            using(OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Lancamentos.FirstOrDefault(x => x.IdLanc == id);
            }
        }

        public void Cadastrar(Lancamentos lancamento)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Lancamentos.Add(lancamento);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using(OpFlixContext ctx = new OpFlixContext())
            {
                Lancamentos Lancamento = ctx.Lancamentos.Find(id);
                ctx.Lancamentos.Remove(Lancamento);
                ctx.SaveChanges(); 
            }
        }

        public List<Lancamentos> Listar()
        {
            using(OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Lancamentos.Include(x => x.IdCategoriaNavigation).Include(x => x.IdPlataformaNavigation).ToList();
            }
        }
    }
}
