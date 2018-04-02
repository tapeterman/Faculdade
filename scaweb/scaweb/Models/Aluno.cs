using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace scaweb.Models {
    public class Aluno : Pessoa {
        public string Matricula { get; set; }
        public int AnoInicio { get; set; }
        public int SemestreInicio { get; set; }
        List<Situacao> Situacoes;

        public Aluno() {
        }

        public Aluno(string matricula, int anoInicio, int semestreInicio, List<Situacao> situacoes) {
            Matricula = matricula;
            AnoInicio = anoInicio;
            SemestreInicio = semestreInicio;
            Situacoes = situacoes;
        }

        public override string ToString() => "Aluno{" + "matricula=" + Matricula + ", anoInicio=" + AnoInicio + ", semestreInicio=" + SemestreInicio + ", situacoes=" + Situacoes;

        }
    }


    
    

