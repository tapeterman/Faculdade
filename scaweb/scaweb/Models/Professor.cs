using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scaweb.Models {
    public class Professor : Pessoa {
        public string Matricula { get; set; }
        public int TitulacaoMaxima { get; set; }
        public List<Curso> Cursos { get; set; }

        public Professor() {
        }

        public Professor(string matricula, int titulacaoMaxima, List<Curso> cursos) {
            Matricula = matricula;
            TitulacaoMaxima = titulacaoMaxima;
            Cursos = cursos;
        }

        public override string ToString() => "matricula=" + Matricula + ", titulacaomaxima=" + TitulacaoMaxima;
    }
}