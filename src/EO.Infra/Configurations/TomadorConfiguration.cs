using EO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EO.Infra.Configurations
{
    public class TomadorConfiguration : IEntityTypeConfiguration<Tomador>
    {
        public void Configure(EntityTypeBuilder<Tomador> builder)
        {
            builder.ToTable("Tomadores");

            builder.Property(x => x.RendaMensal)
                .IsRequired()
                .HasColumnType("decima(18,2)");

            builder.HasOne(x => x.Endereco);
            builder.HasOne(x => x.Usuario);
            builder.HasMany(x => x.Solicitacoes);
        }
    }
}