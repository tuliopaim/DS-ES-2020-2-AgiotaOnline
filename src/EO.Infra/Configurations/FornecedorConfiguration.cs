using EO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EO.Infra.Configurations
{
    public class FornecedorConfiguration : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("Fornecedores");

            builder.Property(x => x.Capital)
                .IsRequired()
                .HasColumnType("decima(18,2)");

            builder.HasOne(x => x.Usuario);
        }
    }
}