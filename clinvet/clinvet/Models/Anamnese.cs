using System;
using System.Collections.Generic;

namespace clinvet.Models
{
    public partial class Anamnese
    {
        public long Id { get; set; }
        public string Diagnostico { get; set; }
        public string Anamnese1 { get; set; }
        public string Medicamentos { get; set; }
        public string ProcedimentosRealizados { get; set; }
        public long IdFichaAnimal { get; set; }

        public FichaAnimal IdFichaAnimalNavigation { get; set; }
    }
}
