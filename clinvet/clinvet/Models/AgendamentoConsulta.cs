using System;
using System.Collections.Generic;

namespace clinvet.Models
{
    public partial class AgendamentoConsulta
    {
        public AgendamentoConsulta()
        {
            ProdutoServicoAgendamentoConsultas = new HashSet<ProdutoServicoAgendamentoConsultas>();
        }

        public long Id { get; set; }
        public DateTime DataDeAgendamento { get; set; }
        public string Descricao { get; set; }
        public string Estatus { get; set; }
        public long IdCliente { get; set; }

        public Cliente IdClienteNavigation { get; set; }
        public ICollection<ProdutoServicoAgendamentoConsultas> ProdutoServicoAgendamentoConsultas { get; set; }
    }
}
