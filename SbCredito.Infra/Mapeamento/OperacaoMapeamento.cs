using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SbCredito.Dominio;
using SbCredito.Dominio.Enums;

namespace SbCredito.Infra.Mapeamento;
public class OperacaoMapeamento : IEntityTypeConfiguration<Operacao>
{
    public void Configure(EntityTypeBuilder<Operacao> builder)
    {
        builder.Ignore(e => e.SomaTitulos);

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("id");

        builder.HasMany(e => e.Titulos)
            .WithOne(e => e.Operacao)
            .HasForeignKey(e => e.IdOperacao);

        builder.Property(e => e.Status)
            .HasConversion(v => v.ToString(), 
            v => (StatusOperacao)Enum.Parse(typeof(StatusOperacao), v))
            .HasColumnName("status");

        builder.Property(e => e.DataHoraCriacao).HasColumnName("data_hora_criacao");
    }
}
