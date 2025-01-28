using FluentValidation;
using SbCredito.Aplicacao.Factories;

namespace SbCredito.Teste.Aplicacao.Factories;
public class TituloFactoryTeste
{
    private static string _bairro = "centro";
    private static string _cep = "12345678";
    private static string _uf = "go";
    private static string _seuNumero = "666";
    private static string _cidade = "goiania";
    private static string _cnpj = "98949541000165";
    private static string _enderecoCobranca = "praça 3";
    private static string _nomeSacado = "fernando";
    private static string _telefoneSacado = "993005544";
    private static decimal _valorDesconto = 1000;
    private static decimal _valorFace = 5000;
    private static long _idOperacao = 5;
    private static DateOnly _dataEmissao = new DateOnly(2025, 01, 01);
    private static DateOnly _dataVencimento = new DateOnly(2026, 01, 01);


    [Fact]
    public void TituloFactory_DadosValidos_RetornaTitulo()
    {
        //Arrange + act
        var titulo = TituloFactory.CriarTitulo(
            _cnpj,
            _nomeSacado,
            _telefoneSacado,
            _cep,
            _enderecoCobranca,
            _uf,
            _cidade,
            _bairro,
            _dataEmissao,
            _dataVencimento,
            _valorDesconto,
            _valorFace,
            _seuNumero,
            _idOperacao);

        //Assert
        Assert.Equal(titulo.Cnpj, _cnpj);
        Assert.Equal(titulo.NomeSacado, _nomeSacado);
        Assert.Equal(titulo.TelefoneSacado, _telefoneSacado);
        Assert.Equal(titulo.Cep, _cep);
        Assert.Equal(titulo.EnderecoCobranca, _enderecoCobranca);
        Assert.Equal(titulo.Uf, _uf);
        Assert.Equal(titulo.Cidade, _cidade);
        Assert.Equal(titulo.Bairro, _bairro);
        Assert.Equal(titulo.DataEmissao, _dataEmissao);
        Assert.Equal(titulo.DataVencimento, _dataVencimento);
        Assert.Equal(titulo.ValorDesconto, _valorDesconto);
        Assert.Equal(titulo.ValorFace, _valorFace);
        Assert.Equal(titulo.SeuNumero, _seuNumero);
        Assert.Equal(titulo.IdOperacao, _idOperacao);
    }

    [Fact]
    public void TituloFactory_CnpjInvalido_RetornaExcecao()
    {
        //Arrange + act
        string cnpj = "0000";
        var exception = Assert.Throws<ValidationException>(() =>
        TituloFactory.CriarTitulo(
            cnpj,
            _nomeSacado,
            _telefoneSacado,
            _cep,
            _enderecoCobranca,
            _uf,
            _cidade,
            _bairro,
            _dataEmissao,
            _dataVencimento,
            _valorDesconto,
            _valorFace,
            _seuNumero,
            _idOperacao));
    }

    [Fact]
    public void TituloFactory_NomeSacadoInvalido_RetornaExcecao()
    {
        //Arrange + act
        string nomeSacado = "";
        var exception = Assert.Throws<ValidationException>(() =>
        TituloFactory.CriarTitulo(
            _cnpj,
            nomeSacado,
            _telefoneSacado,
            _cep,
            _enderecoCobranca,
            _uf,
            _cidade,
            _bairro,
            _dataEmissao,
            _dataVencimento,
            _valorDesconto,
            _valorFace,
            _seuNumero,
            _idOperacao));
    }

    [Fact]
    public void TituloFactory_TelefoneSacadoInvalido_RetornaExcecao()
    {
        //Arrange + act
        string telefoneSacado = "";
        var exception = Assert.Throws<ValidationException>(() =>
        TituloFactory.CriarTitulo(
            _cnpj,
            _nomeSacado,
            telefoneSacado,
            _cep,
            _enderecoCobranca,
            _uf,
            _cidade,
            _bairro,
            _dataEmissao,
            _dataVencimento,
            _valorDesconto,
            _valorFace,
            _seuNumero,
            _idOperacao));
    }

    [Fact]
    public void TituloFactory_CepInvalido_RetornaExcecao()
    {
        //Arrange + act
        string cep = "000";
        var exception = Assert.Throws<ValidationException>(() =>
        TituloFactory.CriarTitulo(
            _cnpj,
            _nomeSacado,
            _telefoneSacado,
            cep,
            _enderecoCobranca,
            _uf,
            _cidade,
            _bairro,
            _dataEmissao,
            _dataVencimento,
            _valorDesconto,
            _valorFace,
            _seuNumero,
            _idOperacao));
    }

    [Fact]
    public void TituloFactory_EnderecoCobrancaInvalido_RetornaExcecao()
    {
        //Arrange + act
        string enderecoCobranca = "";
        var exception = Assert.Throws<ValidationException>(() =>
        TituloFactory.CriarTitulo(
            _cnpj,
            _nomeSacado,
            _telefoneSacado,
            _cep,
            enderecoCobranca,
            _uf,
            _cidade,
            _bairro,
            _dataEmissao,
            _dataVencimento,
            _valorDesconto,
            _valorFace,
            _seuNumero,
            _idOperacao));
    }

    [Fact]
    public void TituloFactory_UfInvalido_RetornaExcecao()
    {
        //Arrange + act
        string uf = "000";
        var exception = Assert.Throws<ValidationException>(() =>
        TituloFactory.CriarTitulo(
            _cnpj,
            _nomeSacado,
            _telefoneSacado,
            _cep,
            _enderecoCobranca,
            uf,
            _cidade,
            _bairro,
            _dataEmissao,
            _dataVencimento,
            _valorDesconto,
            _valorFace,
            _seuNumero,
            _idOperacao));
    }

    [Fact]
    public void TituloFactory_CidadeInvalido_RetornaExcecao()
    {
        //Arrange + act
        string cidade = "";
        var exception = Assert.Throws<ValidationException>(() =>
        TituloFactory.CriarTitulo(
            _cnpj,
            _nomeSacado,
            _telefoneSacado,
            _cep,
            _enderecoCobranca,
            _uf,
            cidade,
            _bairro,
            _dataEmissao,
            _dataVencimento,
            _valorDesconto,
            _valorFace,
            _seuNumero,
            _idOperacao));
    }

    [Fact]
    public void TituloFactory_BairroInvalido_RetornaExcecao()
    {
        //Arrange + act
        string bairro = default;
        var exception = Assert.Throws<ValidationException>(() =>
        TituloFactory.CriarTitulo(
            _cnpj,
            _nomeSacado,
            _telefoneSacado,
            _cep,
            _enderecoCobranca,
            _uf,
            _cidade,
            bairro,
            _dataEmissao,
            _dataVencimento,
            _valorDesconto,
            _valorFace,
            _seuNumero,
            _idOperacao));
    }

    [Fact]
    public void TituloFactory_DataEmissaoInvalido_RetornaExcecao()
    {
        //Arrange + act
        DateOnly dataEmissao = default;
        var exception = Assert.Throws<ValidationException>(() =>
        TituloFactory.CriarTitulo(
            _cnpj,
            _nomeSacado,
            _telefoneSacado,
            _cep,
            _enderecoCobranca,
            _uf,
            _cidade,
            _bairro,
            dataEmissao,
            _dataVencimento,
            _valorDesconto,
            _valorFace,
            _seuNumero,
            _idOperacao));
    }

    [Fact]
    public void TituloFactory_DataVencimentoInvalido_RetornaExcecao()
    {
        //Arrange + act
        DateOnly dataVencimento = _dataEmissao.AddMonths(-5);
        var exception = Assert.Throws<ValidationException>(() =>
        TituloFactory.CriarTitulo(
            _cnpj,
            _nomeSacado,
            _telefoneSacado,
            _cep,
            _enderecoCobranca,
            _uf,
            _cidade,
            _bairro,
            _dataEmissao,
            dataVencimento,
            _valorDesconto,
            _valorFace,
            _seuNumero,
            _idOperacao));
    }

    [Fact]
    public void TituloFactory_ValorDescontoInvalido_RetornaExcecao()
    {
        //Arrange + act
        decimal valorDesconto = -80;
        var exception = Assert.Throws<ValidationException>(() =>
        TituloFactory.CriarTitulo(
            _cnpj,
            _nomeSacado,
            _telefoneSacado,
            _cep,
            _enderecoCobranca,
            _uf,
            _cidade,
            _bairro,
            _dataEmissao,
            _dataVencimento,
            valorDesconto,
            _valorFace,
            _seuNumero,
            _idOperacao));
    }

    [Fact]
    public void TituloFactory_ValorDescontoMaiorQueValorFace_RetornaExcecao()
    {
        //Arrange + act
        decimal valorDesconto = _valorFace + 100;
        var exception = Assert.Throws<ValidationException>(() =>
        TituloFactory.CriarTitulo(
            _cnpj,
            _nomeSacado,
            _telefoneSacado,
            _cep,
            _enderecoCobranca,
            _uf,
            _cidade,
            _bairro,
            _dataEmissao,
            _dataVencimento,
            valorDesconto,
            _valorFace,
            _seuNumero,
            _idOperacao));
    }

    [Fact]
    public void TituloFactory_ValorFaceInvalido_RetornaExcecao()
    {
        //Arrange + act
        decimal valorFace = -100;
        var exception = Assert.Throws<ValidationException>(() =>
        TituloFactory.CriarTitulo(
            _cnpj,
            _nomeSacado,
            _telefoneSacado,
            _cep,
            _enderecoCobranca,
            _uf,
            _cidade,
            _bairro,
            _dataEmissao,
            _dataVencimento,
            _valorDesconto,
            valorFace,
            _seuNumero,
            _idOperacao));
    }

    [Fact]
    public void TituloFactory_SeuNumeroInvalido_RetornaExcecao()
    {
        //Arrange + act
        string seuNumero = "";
        var exception = Assert.Throws<ValidationException>(() =>
        TituloFactory.CriarTitulo(
            _cnpj,
            _nomeSacado,
            _telefoneSacado,
            _cep,
            _enderecoCobranca,
            _uf,
            _cidade,
            _bairro,
            _dataEmissao,
            _dataVencimento,
            _valorDesconto,
            _valorFace,
            seuNumero,
            _idOperacao));
    }
}
