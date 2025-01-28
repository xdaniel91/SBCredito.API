using SbCredito.Aplicacao.Factories;
using SbCredito.Dominio;
using SbCredito.Dominio.Enums;

namespace SbCredito.Teste.Dominio;
public class OperacaoTeste
{

    [Fact]
    public void Operacao_DeveTerStatusPendenteAoCriar()
    {
        // Arrange & Act
        var operacao = OperacaoFactory.CriarOperacao();

        // Assert
        Assert.Equal(StatusOperacao.Pendente, operacao.Status);
    }

    [Fact]
    public void Operacao_DeveTerDataHoraCriacaoDefinidaAoCriar()
    {
        // Arrange & Act
        var operacao = OperacaoFactory.CriarOperacao();

        // Assert
        var dataHoraCriacao = operacao.DataHoraCriacao.ToString("yyyyMMddHHmm");
        var horaNow = DateTimeOffset.UtcNow.ToString("yyyyMMddHHmm");
        Assert.Equal(horaNow, dataHoraCriacao);
    }

    [Fact]
    public void AdicionarTitulo_DeveAdicionarTituloNaLista()
    {
        // Arrange
        string cnpj = "123456789012345";
        string nomeSacado = "teste";
        string telefoneSacado = "993006666";
        string cep = "7569000";
        string enderecoCobranca = "praça sete";
        string uf = "RJ";
        string cidade = "RIO DE JANEIRO";
        string bairro = "centro";
        DateOnly dataEmissao = new(2025, 01, 25);
        DateOnly dataVencimento = new(2025, 12, 25);
        decimal valorDesconto = 1000;
        decimal valorFace = 500000;
        string seuNumero = "89643";
        long idOperacao = 50;

        var operacao = OperacaoFactory.CriarOperacao();
        var titulo = TituloFactory.CriarTitulo(cnpj,
        nomeSacado,
        telefoneSacado,
        cep,
        enderecoCobranca,
        uf,
        cidade,
        bairro,
        dataEmissao,
        dataVencimento,
        valorDesconto,
        valorFace,
        seuNumero,
        idOperacao);

        // Act
        operacao.AdicionarTitulo(titulo);

        // Assert
        Assert.Contains(titulo, operacao.Titulos);
    }

    [Fact]
    public void RemoverTitulo_DeveRemoverTituloDaLista()
    {
        // Arrange
        string cnpj = "123456789012345";
        string nomeSacado = "teste";
        string telefoneSacado = "993006666";
        string cep = "7569000";
        string enderecoCobranca = "praça sete";
        string uf = "RJ";
        string cidade = "RIO DE JANEIRO";
        string bairro = "centro";
        DateOnly dataEmissao = new(2025, 01, 25);
        DateOnly dataVencimento = new(2025, 12, 25);
        decimal valorDesconto = 1000;
        decimal valorFace = 500000;
        string seuNumero = "89643";
        long idOperacao = 50;

        var operacao = OperacaoFactory.CriarOperacao();
        var titulo = TituloFactory.CriarTitulo(cnpj,
        nomeSacado,
        telefoneSacado,
        cep,
        enderecoCobranca,
        uf,
        cidade,
        bairro,
        dataEmissao,
        dataVencimento,
        valorDesconto,
        valorFace,
        seuNumero,
        idOperacao);
        operacao.AdicionarTitulo(titulo);

        // Act
        operacao.RemoverTitulo(titulo);

        // Assert
        Assert.DoesNotContain(titulo, operacao.Titulos);
    }

    [Fact]
    public void SomaTitulos_DeveCalcularCorretamente()
    {
        // Arrange
        string cnpj = "123456789012345";
        string nomeSacado = "teste";
        string telefoneSacado = "993006666";
        string cep = "7569000";
        string enderecoCobranca = "praça sete";
        string uf = "RJ";
        string cidade = "RIO DE JANEIRO";
        string bairro = "centro";
        DateOnly dataEmissao = new(2025, 01, 25);
        DateOnly dataVencimento = new(2025, 12, 25);
        decimal valorDesconto = 1000;
        decimal valorFace = 2000;
        string seuNumero = "89643";
        long idOperacao = 50;

        var operacao = OperacaoFactory.CriarOperacao();
        var titulo_1 = TituloFactory.CriarTitulo(cnpj,
        nomeSacado,
        telefoneSacado,
        cep,
        enderecoCobranca,
        uf,
        cidade,
        bairro,
        dataEmissao,
        dataVencimento,
        valorDesconto,
        valorFace,
        seuNumero,
        idOperacao);

        var titulo_2 = TituloFactory.CriarTitulo(cnpj,
        nomeSacado,
        telefoneSacado,
        cep,
        enderecoCobranca,
        uf,
        cidade,
        bairro,
        dataEmissao,
        dataVencimento,
        valorDesconto,
        valorFace,
        seuNumero,
        idOperacao);

        titulo_1.Id = 1;
        titulo_2.Id = 2;

        operacao.AdicionarTitulo(titulo_1);
        operacao.AdicionarTitulo(titulo_2);

        // Act
        var somaTitulos = operacao.SomaTitulos;

        // Assert
        decimal valor = (titulo_1.ValorFace - titulo_1.ValorDesconto) + (titulo_2.ValorFace - titulo_2.ValorDesconto);
        Assert.Equal(valor, somaTitulos);

    }
}
