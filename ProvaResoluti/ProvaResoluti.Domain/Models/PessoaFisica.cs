using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaResoluti.Domain.Models
{
    public class PessoaFisica
    {
        public PessoaFisica()
        {
            Enderecos = new List<Enderecos>();
            Contatos = new List<Contatos>();
        }   
        public int PessoaId { get; set; } //int pq é uma aplicação pequena
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }

        // Relacionamento com a tabela Endereco
        public virtual ICollection<Enderecos> Enderecos { get; set; }

        // Relacionamento com a tabela Contato
        public virtual ICollection<Contatos> Contatos { get; set; }

        // Relacionamento com a tabela Usuario
        public virtual Usuario Usuario { get; set; }

    }


}
