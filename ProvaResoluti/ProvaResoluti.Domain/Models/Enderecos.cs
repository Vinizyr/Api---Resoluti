using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaResoluti.Domain.Models
{
    public class Enderecos
    {
        public Enderecos()
        {
            PessoaFisica = new PessoaFisica();
        } 
        public int EnderecoId { get; set; } //int pq é uma aplicação pequena
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public string Complemento { get; set; }

        // Chave estrangeira referenciando PessoaFisica
        public int PessoaId { get; set; }
        public virtual PessoaFisica PessoaFisica { get; set; }
    }
}
