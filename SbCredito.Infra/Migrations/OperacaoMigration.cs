using FluentMigrator;

namespace SbCredito.Infra.Migrations;
[Migration(20250125074322, "tabela operacoes")]
public class OperacaoMigration : Migration
{
    public override void Down()
    {

    }

    public override void Up()
    {
        Create.Table("operacoes")
                    .WithColumn("id").AsInt64().PrimaryKey().Identity()
                    .WithColumn("status").AsString().NotNullable()
                    .WithColumn("data_hora_criacao").AsDateTimeOffset().NotNullable();
    }
}
