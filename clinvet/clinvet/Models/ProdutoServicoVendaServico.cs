using System;
using System.Collections.Generic;

namespace clinvet.Models
{
    public partial class ProdutoServicoVendaServico
    {
        public long IdProdutoServico { get; set; }
        public long IdVendaServico { get; set; }
        public int QuantidadeProduto { get; set; }
        public decimal ValorProduto { get; set; }

        public ProdutoServico IdProdutoServicoNavigation { get; set; }
        public VendaServico IdVendaServicoNavigation { get; set; }
    }
}
