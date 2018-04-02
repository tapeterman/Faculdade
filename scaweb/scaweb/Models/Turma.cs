using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scaweb.Models {
    public class Turma {
        public long Id { get; set; }
        public int Ano { get; internal set; }
        public long Numero { get; set; }
        public int Semestre { get; set; }
        public Curso Curso { get; set; }
        public Instituicao Instituicao { get; set; }
        public Professor Professor { get; set; }

        public Turma() {
        }

        public Turma(long id, int ano, long numero, int semestre, Curso Curso, Instituicao instituicao, Professor professor) {
            Id = id;
            Ano = ano;
            Numero = numero;
            Semestre = semestre;
            Curso = Curso;
            Instituicao = instituicao;
            Professor = professor;
        }


        public override string ToString() => "id=" + Id + ", numero=" + Numero + ", ano=" + Ano + ", semestre=" + Semestre + ", instituicoes=" + Instituicao + ", professores=" + Professor + ", Cursos=" + Curso;
    }


}