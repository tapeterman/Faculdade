using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using scaweb.Models;

namespace scaweb.Models {
    public class Curso {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public Professor professores { get; set; }
        public Curso() {
        }

        public Curso(long id, string descricao,Professor professores) {
            Id = id;
            Descricao = descricao;
            this.professores = professores;
        }

        public override string ToString() => "id=" + Id + ", descricao=" + Descricao + ", professores=" + professores;
    }
}