using System;
using System.Collections.Generic;

namespace clinvet.Models
{
    public partial class FornecedorProdutoServico
    {
        public long IdFornecedor { get; set; }
        public long IdProduto { get; set; }

        public Fornecedor IdFornecedorNavigation { get; set; }
        public ProdutoServico IdProdutoNavigation { get; set; }
    }
}
