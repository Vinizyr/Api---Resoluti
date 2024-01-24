using Microsoft.EntityFrameworkCore;
using ProvaResoluti.Domain.IRepository;
using ProvaResoluti.Domain.Models;
using ProvaResoluti.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProvaResoluti.Infra.Repositories
{
    public class PessoaFisicaRepository : IPessoaFisicaRepository
    {
        private readonly ResolutiContext _context;

        public PessoaFisicaRepository(ResolutiContext context)
        {
            _context = context;
        }

        public async Task Delete(int pessoaId)
        {
            var pessoa = _context.PessoasFisicas
                    .Where(p => p.PessoaId == pessoaId)
                        .FirstOrDefault();

            _context.PessoasFisicas.Remove(pessoa!);
            await _context.SaveChangesAsync();

        }

        public async Task Edit(PessoaFisica pessoaFisica)
        {
            _context.Entry(pessoaFisica).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IList<PessoaFisica>> GetAll()
        {
            var pessoas = await _context.PessoasFisicas
                .Include(x => x.Contatos)
                .Include(x => x.Enderecos)
                .Include(x => x.Usuario).Take(10).ToListAsync();

            return pessoas;
        }

        public async Task<PessoaFisica> GetById(int id)
        {
            var pessoa = await _context.PessoasFisicas
                .Include(x => x.Contatos)
                .Include(x => x.Enderecos)
                .Include(x => x.Usuario)
                .Where(x => x.PessoaId == id)
                .FirstOrDefaultAsync();

            return pessoa!;
        }

        public async Task<bool> PessoaExiste(string cpf)
        {
            var pessoaCpf = await _context.PessoasFisicas
                    .Where(x => x.CPF == cpf).FirstOrDefaultAsync();

            if(pessoaCpf != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task Save(PessoaFisica pessoaFisica)
        {
            _context.PessoasFisicas.Add(pessoaFisica);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UsernameExiste(string username)
        {
            var pessoaCpf = await _context.Usuario
                    .Where(x => x.Username == username).FirstOrDefaultAsync();

            if (pessoaCpf != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
