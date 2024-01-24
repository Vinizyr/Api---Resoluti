using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProvaResoluti.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaResoluti.Infra.Builders
{
    public class PessoaFisicaBuilder : IEntityTypeConfiguration<PessoaFisica>
    {
        public void Configure(EntityTypeBuilder<PessoaFisica> builder)
        {
            builder.HasKey(x => x.PessoaId);

            builder.Property(p => p.DataNascimento)
                .HasColumnType("date");

            builder.HasOne(p => p.Usuario)
            .WithOne(a => a.PessoaFisica)
            .HasForeignKey<Usuario>(a => a.UsuarioId);

            builder.HasMany(p => p.Contatos)
            .WithOne(a => a.PessoaFisica)
            .HasForeignKey(a => a.PessoaId);

            builder.HasMany(p => p.Enderecos)
            .WithOne(a => a.PessoaFisica)
            .HasForeignKey(a => a.PessoaId);
        }
    }
}
