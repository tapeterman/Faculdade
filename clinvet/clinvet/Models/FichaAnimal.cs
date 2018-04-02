using System;
using System.Collections.Generic;

namespace clinvet.Models
{
    public partial class FichaAnimal
    {
        public FichaAnimal()
        {
            Anamnese = new HashSet<Anamnese>();
            Vacina = new HashSet<Vacina>();
        }

        public long Id { get; set; }
        public string PesoPorteAntesDosProcedimentos { get; set; }
        public long IdAnimal { get; set; }

        public Animal IdAnimalNavigation { get; set; }
        public ICollection<Anamnese> Anamnese { get; set; }
        public ICollection<Vacina> Vacina { get; set; }
    }
}
