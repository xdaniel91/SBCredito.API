using Microsoft.EntityFrameworkCore;
using SbCredito.Dominio;
using SbCredito.Infra.Mapeamento;

namespace SbCredito.Infra;

public class SbCreditoContext : DbContext
{
    public DbSet<Titulo> titulos { get; set; }
    public DbSet<Operacao> operacoes { get; set; }

    public SbCreditoContext(DbContextOptions<SbCreditoContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TituloMapeamento).Assembly);
    }
}
