using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scaweb.Models {
    public class Diario {
        public decimal V1 { get; set; }
        public decimal V2 { get; set; }
        public decimal Vs { get; set; }
        public decimal Vt { get; set; }
        public int Faltas { get; set; }
        public Turma Turmas;
        public Aluno Alunos;

        public Diario() {
        }

        public Diario(decimal v1, decimal v2, decimal vs, decimal vt, int faltas, Turma turmas, Aluno alunos) {
            V1 = v1;
            V2 = v2;
            Vs = vs;
            Vt = vt;
            Faltas = faltas;
            this.Turmas = turmas;
            this.Alunos = alunos;
        }

        public override string ToString() => "v1=" + V1 + ", v2=" + V2 + ", vs=" + Vs + ", vt=" + Vt + ", faltas=" + Faltas + ", turmas=" + Turmas + ", alunos=" + Alunos;
    }
}