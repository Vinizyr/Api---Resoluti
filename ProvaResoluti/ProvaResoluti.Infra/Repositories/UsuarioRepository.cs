using Microsoft.EntityFrameworkCore;
using ProvaResoluti.Domain.IRepository;
using ProvaResoluti.Domain.Models;
using ProvaResoluti.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaResoluti.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ResolutiContext _context;

        public UsuarioRepository(ResolutiContext context)
        {
            _context = context;
        }

        public async Task<Usuario> GetByUsername(string username)
        {
            var user = await _context.Usuario.Where(u => u.Username == username).FirstOrDefaultAsync();
            return user!;
        }

        public async Task<Usuario> GetUsuarioLogin(string username, string password)
        {
            var usuario = await _context.Usuario
                .Where(x => x.Username == username &&
                            x.Senha == password)
                .FirstOrDefaultAsync();

            return usuario!;
        }
    }
}
