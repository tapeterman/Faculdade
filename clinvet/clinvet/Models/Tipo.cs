using System;
using System.Collections.Generic;

namespace clinvet.Models
{
    public partial class Tipo
    {
        public Tipo()
        {
            ProdutoServico = new HashSet<ProdutoServico>();
        }

        public long Id { get; set; }
        public string Descricao { get; set; }

        public ICollection<ProdutoServico> ProdutoServico { get; set; }
    }
}
