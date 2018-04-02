using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scaweb.Models {
    public class Instituicao {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }

        public Instituicao() {
        }

        public Instituicao(long id, string nome, string cnpj) {
            Id = id;
            Nome = nome;
            Cnpj = cnpj;
        }

        public override string ToString() => base.ToString() + "id" + Id + "Nome" + Nome + "Cnpj" + Cnpj;

    }

    
    
    
}