using System;
using System.Collections.Generic;

namespace clinvet.Models
{
    public partial class VendaServicoFormaDePagamento
    {
        public long IdVendaServico { get; set; }
        public long IdFormaDePagamento { get; set; }

        public FormaDePagamento IdFormaDePagamentoNavigation { get; set; }
        public VendaServico IdVendaServicoNavigation { get; set; }
    }
}
