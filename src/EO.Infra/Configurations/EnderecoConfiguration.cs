using EO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EO.Infra.Configurations
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Enderecos");

            builder.Property(x => x.Cep).HasMaxLength(8).IsRequired();
            builder.Property(x => x.Logradouro).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Rua).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Bairro).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Cidade).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Estado).HasMaxLength(25).IsRequired();
            builder.Property(x => x.Pais).HasMaxLength(25).IsRequired();
        }
    }
}