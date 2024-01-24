using Microsoft.AspNetCore.Mvc;
using ProvaResoluti.Shared.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaResoluti.App.Features.PessoaFeature.Commands
{
    public class UpdatePessoaFisicaCommand : ICommand
    {
        
        public int PessoaId { get; set; }

        public string? PessoaLogada { get; set; }

        //Form Pessoa
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Nome precisa estar entre 3 e 30 caracteres. ")]
        public string Nome { get; set; }

        [StringLength(100, MinimumLength = 3, ErrorMessage = "Nome precisa estar entre 3 e 100 caracteres. ")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória", AllowEmptyStrings = false)]
        public string DataNascimento { get; set; }

        [Required(ErrorMessage = "Rg é obrigatório", AllowEmptyStrings = false)]
        public string RG { get; set; }

        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$",
            ErrorMessage = "O campo {0} deve ser um CPF válido.")]
        public string CPF { get; set; }

        //[FromBody]
        //public Body Body { get; set; }

    }

    //public class Body
    //{
    //    // Form Pessoa
    //    [StringLength(30, MinimumLength = 3, ErrorMessage = "Nome precisa estar entre 3 e 30 caracteres. ")]
    //    public string Nome { get; set; }

    //    [StringLength(100, MinimumLength = 3, ErrorMessage = "Nome precisa estar entre 3 e 100 caracteres. ")]
    //    public string Sobrenome { get; set; }

    //    [Required(ErrorMessage = "A data de nascimento é obrigatória", AllowEmptyStrings = false)]
    //    public DateTime DataNascimento { get; set; }

    //    [Required(ErrorMessage = "Rg é obrigatório", AllowEmptyStrings = false)]
    //    public string RG { get; set; }

    //    [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$",
    //        ErrorMessage = "O campo {0} deve ser um CPF válido.")]
    //    public string CPF { get; set; }
    //}
}
