using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scaweb.Models {
    public class Situacao {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public int AnoSemestre { get; set; }
        public List<Aluno> Alunos { get; set; }

        public Situacao() {
        }

        public Situacao(long id, string descricao, int anoSemestre, List<Aluno> alunos) {
            Id = id;
            this.Descricao = descricao;
            AnoSemestre = anoSemestre;
            this.Alunos = alunos;
        }

        public override string ToString() => "id=" + Id + ", descricao=" + Descricao + ", anoSemestre=" + AnoSemestre;
    }
}