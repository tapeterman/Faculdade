using System;
using System.Collections.Generic;

namespace clinvet.Models
{
    public partial class TiposDeVacina
    {
        public TiposDeVacina()
        {
            Vacina = new HashSet<Vacina>();
        }

        public long Id { get; set; }
        public string Descricao { get; set; }

        public ICollection<Vacina> Vacina { get; set; }
    }
}
