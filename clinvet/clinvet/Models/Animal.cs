using System;
using System.Collections.Generic;

namespace clinvet.Models
{
    public partial class Animal
    {
        public Animal()
        {
            FichaAnimal = new HashSet<FichaAnimal>();
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public string Raça { get; set; }
        public string PesoOuPorte { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Espécie { get; set; }
        public string Sexo { get; set; }
        public long IdCliente { get; set; }

        public Cliente IdClienteNavigation { get; set; }
        public ICollection<FichaAnimal> FichaAnimal { get; set; }
    }
}
