using System;
using System.Collections.Generic;

namespace clinvet.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Funcionario = new HashSet<Funcionario>();
        }

        public string Login { get; set; }
        public string Senha { get; set; }

        public ICollection<Funcionario> Funcionario { get; set; }
    }
}
