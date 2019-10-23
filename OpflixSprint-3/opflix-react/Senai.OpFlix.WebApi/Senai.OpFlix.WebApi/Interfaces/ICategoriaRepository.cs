using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    interface ICategoriaRepository
    {
        List<Categoria> Listar();

        void Cadastrar(Categoria categoria);

        Categoria BuscarPorId(int id);

        void Atualizar(Categoria categoria);
    }
}
