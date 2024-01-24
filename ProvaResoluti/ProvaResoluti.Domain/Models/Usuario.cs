using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaResoluti.Domain.Models
{
    public class Usuario
    {
        public Usuario()
        {
            PessoaFisica = new PessoaFisica();
        }
        public int UsuarioId { get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }

        // Chave estrangeira referenciando PessoaFisica
        public virtual PessoaFisica PessoaFisica { get; set; }

    }
}
