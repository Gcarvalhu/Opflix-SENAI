using Microsoft.EntityFrameworkCore;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public void Atualizar(Usuarios usuario)
        {
            using (opflixContext ctx = new opflixContext())
            {
                Usuarios usuarioBuscado = ctx.Usuarios.FirstOrDefault(x => x.IdUsuario == usuario.IdUsuario);
                ctx.Usuarios.Update(usuarioBuscado);
                ctx.SaveChanges();
            }
        }

        public Usuarios BuscarPorEmailSenha(LoginViewModel login)
        {
            using (opflixContext ctx = new opflixContext())
            {
                Usuarios usuario = ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                if (usuario == null)
                    return null;
                return usuario;
            }
        }

        public Usuarios BuscarPorId(int id)
        {
            using (opflixContext ctx = new opflixContext())
            {
                return ctx.Usuarios.Find(id);
            }
        }

        public void Cadastrar(Usuarios usuario)
        {
            using (opflixContext ctx = new opflixContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (opflixContext ctx = new opflixContext())
            {
                Usuarios Usuario = ctx.Usuarios.Find(id);
                ctx.Usuarios.Remove(Usuario);
                ctx.SaveChanges();
            }
        }

        public List<Usuarios> Listar()
        {
            using (opflixContext ctx = new opflixContext())
            {
                return ctx.Usuarios.ToList();
            }
        }
    }
}
