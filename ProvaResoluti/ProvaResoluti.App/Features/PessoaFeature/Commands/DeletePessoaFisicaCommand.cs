using Microsoft.AspNetCore.Mvc;
using ProvaResoluti.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaResoluti.App.Features.PessoaFeature.Commands
{
    public class DeletePessoaFisicaCommand : ICommand
    {
        public string? PessoaLogada { get; set; }

        [FromRoute]
        public int PessoaId { get; set; }
    }
}
