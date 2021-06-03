using EO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EO.Infra.Configurations
{
    public class SolicitacaoEmprestimoConfiguration : IEntityTypeConfiguration<SolicitacaoEmprestimo>
    {
        public void Configure(EntityTypeBuilder<SolicitacaoEmprestimo> builder)
        {
            builder.Property(x => x.TomadorId)
                .IsRequired();

            builder.Property(x => x.Valor)
                .IsRequired()
                .HasColumnType("decima(18,2)");

            builder.Property(x => x.Parcelas)
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(25);
        }
    }
}