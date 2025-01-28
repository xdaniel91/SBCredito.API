using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SbCredito.Dominio;

namespace SbCredito.Infra.Mapeamento;
public class TituloMapeamento : IEntityTypeConfiguration<Titulo>
{
    public void Configure(EntityTypeBuilder<Titulo> builder)
    {
        builder.ToTable("titulos");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Bairro).HasColumnName("bairro");
        builder.Property(e => e.Cep).HasColumnName("cep");
        builder.Property(e => e.Cidade).HasColumnName("cidade");
        builder.Property(e => e.Cnpj).HasColumnName("cnpj");
        builder.Property(e => e.DataEmissao).HasColumnName("data_emissao");
        builder.Property(e => e.DataVencimento).HasColumnName("data_vencimento");
        builder.Property(e => e.EnderecoCobranca).HasColumnName("endereco_cobranca");
        builder.Property(e => e.SeuNumero).HasColumnName("seu_numero");
        builder.Property(e => e.TelefoneSacado).HasColumnName("telefone_sacado");
        builder.Property(e => e.Uf).HasColumnName("uf");
        builder.Property(e => e.ValorDesconto).HasColumnName("valor_desconto");
        builder.Property(e => e.ValorFace).HasColumnName("valor_face");
        builder.Property(e => e.IdOperacao).HasColumnName("id_operacao");
        builder.Property(e => e.NomeSacado).HasColumnName("nome_sacado");

        builder.HasOne(e => e.Operacao).WithMany(e => e.Titulos).HasForeignKey(e => e.IdOperacao);
    }
}
