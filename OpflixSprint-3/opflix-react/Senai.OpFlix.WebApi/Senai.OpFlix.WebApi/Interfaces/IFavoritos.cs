using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    interface IFavoritos
    {
        List<Favoritos> Listar();

        void Cadastrar(Favoritos favoritos);

    }
}
