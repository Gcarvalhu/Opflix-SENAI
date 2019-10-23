using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Lancamentos
    {
        public Lancamentos()
        {
            Favoritos = new HashSet<Favoritos>();
        }

        public int IdLanc { get; set; }
        public string Titulo { get; set; }
        public string Sinopse { get; set; }
        public string Tipo { get; set; }
        public DateTime DataLanc { get; set; }
        public TimeSpan Duracao { get; set; }
        public int? IdCategoria { get; set; }
        public int? IdPlataforma { get; set; }

        public Categoria IdCategoriaNavigation { get; set; }
        public Plataforma IdPlataformaNavigation { get; set; }
        public ICollection<Favoritos> Favoritos { get; set; }
    }
}
