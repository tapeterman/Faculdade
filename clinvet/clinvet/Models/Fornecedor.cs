using System;
using System.Collections.Generic;

namespace clinvet.Models
{
    public partial class Fornecedor
    {
        public Fornecedor()
        {
            ContasAPagar = new HashSet<ContasAPagar>();
            FornecedorProdutoServico = new HashSet<FornecedorProdutoServico>();
        }

        public long Id { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string Telefone { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }

        public ICollection<ContasAPagar> ContasAPagar { get; set; }
        public ICollection<FornecedorProdutoServico> FornecedorProdutoServico { get; set; }
    }
}
