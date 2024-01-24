using Microsoft.IdentityModel.Tokens;
using ProvaResoluti.Domain.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProvaResoluti.App.Features.Autenticacao
{
    public class TokenService
    {

        public async Task<string> GenerateToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Username)

                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string CriptografarSenha(string senha)
        {
            // Gera um salt aleatório
            string salt = BCrypt.Net.BCrypt.GenerateSalt();

            // Criptografa a senha com o salt
            string senhaCriptografada = BCrypt.Net.BCrypt.HashPassword(senha, salt);

            return senhaCriptografada;
        }
        public bool VerificarSenha(string senha, string senhaCriptografada)
        {
            // Verifica se a senha corresponde à versão criptografada
            return BCrypt.Net.BCrypt.Verify(senha, senhaCriptografada);
        }
    }
}
