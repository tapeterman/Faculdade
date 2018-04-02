using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scaweb.Models {
    public class Pessoa {
        public long Id { get; set; }
        public String Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Identidade { get; set; }
    }
}