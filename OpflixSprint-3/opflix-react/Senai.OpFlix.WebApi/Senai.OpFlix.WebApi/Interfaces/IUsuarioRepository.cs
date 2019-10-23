using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        Usuarios BuscarPorEmailSenha(LoginViewModel login);

        List<Usuarios> Listar();

        void Cadastrar(Usuarios usuario);

        Usuarios BuscarPorId(int id);

        void Atualizar(Usuarios usuario);

        void Deletar(int id);

    }
}
