using ProvaResoluti.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaResoluti.Domain.IRepository
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetByUsername(string username);
        Task<Usuario> GetUsuarioLogin(string username, string password);
    }
}
