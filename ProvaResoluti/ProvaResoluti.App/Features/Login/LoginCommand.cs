using ProvaResoluti.Shared.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaResoluti.App.Features.Login
{
    public class LoginCommand : ICommand
    {
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Username precisa estar entre 8 e 30 caracteres. ")]
        [Required(ErrorMessage = "Username é obrigatório", AllowEmptyStrings = false)]
        public string Username { get; set; }

        [StringLength(20, MinimumLength = 8, ErrorMessage = "Username precisa estar entre 8 e 20 caracteres. ")]
        [Required(ErrorMessage = "Password é obrigatório", AllowEmptyStrings = false)]
        public string Senha { get; set; }
    }
}
