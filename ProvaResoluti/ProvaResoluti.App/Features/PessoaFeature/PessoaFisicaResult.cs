using ProvaResoluti.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaResoluti.App.Features.PessoaFeature
{
    public class PessoaFisicaResult : ICommandResult
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
    }
}
