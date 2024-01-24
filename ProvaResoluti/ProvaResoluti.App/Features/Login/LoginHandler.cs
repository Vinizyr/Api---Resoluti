using ProvaResoluti.App.Features.Autenticacao;
using ProvaResoluti.Domain.IRepository;
using ProvaResoluti.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaResoluti.App.Features.Login
{
    public class LoginHandler : ICommandHandler<LoginCommand>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly TokenService _tokenService;

        public LoginHandler(IUsuarioRepository usuarioRepository, TokenService tokenService)
        {
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
        }

        public async Task<ICommandResult> Handle(LoginCommand command)
        {
            var usuario = await _usuarioRepository.GetByUsername(command.Username);

            if(usuario == null)
            {
                return new LoginResult()
                {
                    Sucesso = false,
                    Mensagem = "Usuário ou senha incorretos. "
                };
            }

            var senhaCript = _tokenService.VerificarSenha(command.Senha, usuario.Senha);

            if (!senhaCript)
            {
                return new LoginResult()
                {
                    Sucesso = false,
                    Mensagem = "Usuário ou senha incorretos. "
                };
            }

            var token = await _tokenService.GenerateToken(usuario);

            return new LoginResult()
            {
                Sucesso = true,
                Mensagem = "Token gerado",
                token = token
            };
        }
    }
}
