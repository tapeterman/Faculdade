using System;
using System.Collections.Generic;

namespace clinvet.Models
{
    public partial class Vacina
    {
        public long Id { get; set; }
        public string Marca { get; set; }
        public string Lote { get; set; }
        public string Fornecedor { get; set; }
        public DateTime Validade { get; set; }
        public decimal Custo { get; set; }
        public long IdFichaAnimal { get; set; }
        public long IdTiposDeVacina { get; set; }

        public FichaAnimal IdFichaAnimalNavigation { get; set; }
        public TiposDeVacina IdTiposDeVacinaNavigation { get; set; }
    }
}
