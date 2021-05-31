using EO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EO.Infra.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Cpf).HasMaxLength(11).IsRequired();
            builder.Property(x => x.Nome).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Telefone).HasMaxLength(11).IsRequired();
            builder.Property(x => x.Tipo).IsRequired();
            builder.Property(x => x.ChavePix).HasMaxLength(100).IsRequired();
        }
    }
}