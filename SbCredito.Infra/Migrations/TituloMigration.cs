using FluentMigrator;

namespace SbCredito.Infra.Migrations;
[Migration(20250124203923, "criar tabela titulo")]
public class TituloMigration : Migration
{
    public override void Down()
    {
    }

    public override void Up()
    {
        Create.Table("titulos")
            .WithColumn("id").AsInt64().PrimaryKey().Identity()
            .WithColumn("cnpj").AsString().NotNullable()
            .WithColumn("nome_sacado").AsString().NotNullable()
            .WithColumn("telefone_sacado").AsString()
            .WithColumn("cep").AsString()
            .WithColumn("endereco_cobranca").AsString()
            .WithColumn("uf").AsString(2)
            .WithColumn("cidade").AsString()
            .WithColumn("bairro").AsString()
           .WithColumn("data_emissao").AsDate()
           .WithColumn("data_vencimento").AsDate()
           .WithColumn("valor_desconto").AsDecimal()
           .WithColumn("valor_face").AsDecimal()
           .WithColumn("seu_numero").AsAnsiString();
    }
}

[Migration(20250125074323, "adiciona coluna id operacao")]
public class TituloAdicionarIdOperacaoMigration : Migration
{
    public override void Down()
    {
        
    }

    public override void Up()
    {
        Alter.Table("titulos")
            .AddColumn("id_operacao")
            .AsInt64()
            .NotNullable();

        Create.ForeignKey("fk_titulos_operacao")
            .FromTable("titulos")
            .ForeignColumn("id_operacao")
            .ToTable("operacoes")
            .PrimaryColumn("id");
    }
}
