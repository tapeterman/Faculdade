using System;
using System.Collections.Generic;

namespace clinvet.Models
{
    public partial class ContasAPagar
    {
        public long Id { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public long IdFornecedor { get; set; }
        public long IdTipoDeConta { get; set; }

        public Fornecedor IdFornecedorNavigation { get; set; }
        public TipoDeConta IdTipoDeContaNavigation { get; set; }
    }
}
