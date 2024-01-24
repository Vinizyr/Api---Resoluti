using ProvaResoluti.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaResoluti.Domain.IRepository
{
    public interface IPessoaFisicaRepository
    {
        Task Save(PessoaFisica pessoaFisica);
        Task Delete(int pessoaId);
        Task Edit(PessoaFisica pessoa);
        Task<IList<PessoaFisica>> GetAll();
        Task<bool> PessoaExiste(string cpf);
        Task<bool> UsernameExiste(string username);
        Task<PessoaFisica> GetById(int id);
    }
}
