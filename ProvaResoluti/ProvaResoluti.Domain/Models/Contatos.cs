using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaResoluti.Domain.Models
{
    public class Contatos
    {
        public int ContatoId { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        // Chave estrangeira referenciando PessoaFisica
        public int PessoaId { get; set; }
        public virtual PessoaFisica PessoaFisica { get; set; }
    }
}
