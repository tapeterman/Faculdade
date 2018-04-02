using System;
using System.Collections.Generic;

namespace clinvet.Models
{
    public partial class ProdutoServico
    {
        public ProdutoServico()
        {
            FornecedorProdutoServico = new HashSet<FornecedorProdutoServico>();
            ProdutoServicoAgendamentoConsultas = new HashSet<ProdutoServicoAgendamentoConsultas>();
            ProdutoServicoVendaServico = new HashSet<ProdutoServicoVendaServico>();
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public decimal PrecoDeVenda { get; set; }
        public decimal PrecoDeCompra { get; set; }
        public DateTime Validade { get; set; }
        public string Lote { get; set; }
        public long IdTipo { get; set; }

        public Tipo IdTipoNavigation { get; set; }
        public ICollection<FornecedorProdutoServico> FornecedorProdutoServico { get; set; }
        public ICollection<ProdutoServicoAgendamentoConsultas> ProdutoServicoAgendamentoConsultas { get; set; }
        public ICollection<ProdutoServicoVendaServico> ProdutoServicoVendaServico { get; set; }
    }
}
