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
    public class PessoaFisicaCommand : ICommand
    {

        // Form Pessoa
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Nome precisa estar entre 3 e 30 caracteres. ")]
        public string Nome { get; set; }

        [StringLength(100, MinimumLength = 3, ErrorMessage = "Nome precisa estar entre 3 e 100 caracteres. ")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória", AllowEmptyStrings = false)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Rg é obrigatório", AllowEmptyStrings = false)]
        public string RG { get; set; }

        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$",
            ErrorMessage = "O campo {0} deve ser um CPF válido.")]
        public string CPF { get; set; }


        //Endereço
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Estado precisa estar entre 3 e 30 caracteres. ")]
        public string Estado { get; set; }

        [StringLength(30, MinimumLength = 3, ErrorMessage = "Cidade precisa estar entre 3 e 30 caracteres. ")]
        public string Cidade { get; set; }

        [RegularExpression(@"^\d{5}-\d{3}$",
            ErrorMessage = "O campo CEP deve estar no formato 'XXXXX-XXX', onde X é um dígito.")]
        public string CEP { get; set; }

        [StringLength(30, MinimumLength = 3, ErrorMessage = "Logradouro precisa estar entre 3 e 30 caracteres. ")]
        public string Logradouro { get; set; }

        [StringLength(30, MinimumLength = 3, ErrorMessage = "Complemento precisa estar entre 3 e 30 caracteres. ")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Número é um campo obrigatório.")]
        public int Numero { get; set; }

        //Contato
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
            ErrorMessage = "Informe um endereço de e-mail válido.")]
        public string Email { get; set; }

        [RegularExpression(@"^\([1-9]{2}\) 9[6-9][0-9]{3}\-[0-9]{4}$",
            ErrorMessage = "O campo telefone deve estar no formato (XX) 9XXXX-XXXX.")]
        public string TelefoneCelular { get; set; }

        //Usuario
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Username precisa estar entre 8 e 30 caracteres. ")]
        [Required(ErrorMessage = "Username é obrigatório", AllowEmptyStrings = false)]
        public string Username { get; set; }

        [StringLength(20, MinimumLength = 8, ErrorMessage = "Username precisa estar entre 8 e 20 caracteres. ")]
        [Required(ErrorMessage = "Password é obrigatório", AllowEmptyStrings = false)]
        public string Senha { get; set; }

    }
}
