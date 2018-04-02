using System;
using System.Collections.Generic;

namespace clinvet.Models
{
    public partial class VendaServico
    {
        public VendaServico()
        {
            ProdutoServicoVendaServico = new HashSet<ProdutoServicoVendaServico>();
            VendaServicoFormaDePagamento = new HashSet<VendaServicoFormaDePagamento>();
        }

        public long Id { get; set; }
        public decimal ValorTotal { get; set; }
        public string Descricao { get; set; }
        public long IdFuncionario { get; set; }
        public long IdCliente { get; set; }
        public DateTime DataServico { get; set; }

        public Cliente IdClienteNavigation { get; set; }
        public Funcionario IdFuncionarioNavigation { get; set; }
        public ICollection<ProdutoServicoVendaServico> ProdutoServicoVendaServico { get; set; }
        public ICollection<VendaServicoFormaDePagamento> VendaServicoFormaDePagamento { get; set; }
    }
}
