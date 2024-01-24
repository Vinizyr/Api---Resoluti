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
    public class UsuarioBuilder : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.UsuarioId);

            builder.HasOne(x => x.PessoaFisica)
                .WithOne(x => x.Usuario)
                .HasForeignKey<Usuario>(x => x.UsuarioId);

            
        }
    }
}
