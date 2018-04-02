using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scaweb.Models {
    public class Disciplina {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public Curso Curso { get; set; }

        public Disciplina() {
        }

        public Disciplina(int id, string descricao, Curso curso) {
            Id = id;
            Descricao = descricao;
            this.Curso = curso;
        }

        public override string ToString() => "id=" + Id + ", descricao=" + Descricao + ", curso=" + Curso;

    }
}