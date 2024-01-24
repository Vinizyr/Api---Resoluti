using Microsoft.EntityFrameworkCore;
using ProvaResoluti.Domain.Models;
using ProvaResoluti.Infra.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaResoluti.Infra.Contexts
{
    public class ResolutiContext : DbContext
    {
        public ResolutiContext(DbContextOptions<ResolutiContext> options) : base(options)
        {

        }

        public DbSet<Contatos> Contatos { get; set; }
        public DbSet<Enderecos> Enderecos { get; set; }
        public DbSet<PessoaFisica> PessoasFisicas { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Resoluti");

            modelBuilder.ApplyConfiguration(new UsuarioBuilder());
            modelBuilder.ApplyConfiguration(new PessoaFisicaBuilder());
            modelBuilder.ApplyConfiguration(new EnderecoBuilder());
            modelBuilder.ApplyConfiguration(new ContatosBuilder());

        }
    }
}
