using System;
using System.Collections.Generic;

namespace clinvet.Models
{
    public partial class ProdutoServicoAgendamentoConsultas
    {
        public long IdProdutoServico { get; set; }
        public long IdAgendamentoConsulta { get; set; }

        public AgendamentoConsulta IdAgendamentoConsultaNavigation { get; set; }
        public ProdutoServico IdProdutoServicoNavigation { get; set; }
    }
}
