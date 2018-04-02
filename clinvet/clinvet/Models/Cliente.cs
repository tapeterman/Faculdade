using System;
using System.Collections.Generic;

namespace clinvet.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            AgendamentoConsulta = new HashSet<AgendamentoConsulta>();
            Animal = new HashSet<Animal>();
            VendaServico = new HashSet<VendaServico>();
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }

        public ICollection<AgendamentoConsulta> AgendamentoConsulta { get; set; }
        public ICollection<Animal> Animal { get; set; }
        public ICollection<VendaServico> VendaServico { get; set; }
    }
}
