using SbCredito.Aplicacao.Factories;

namespace SbCredito.Teste.Dominio;
public class TituloTeste
{
    [Fact]
    public void Titulo_DeveConterDadosInformadosAoCriar()
    {
        //arrange
        string cnpj = "123456789";
        string nomeSacado = "teste";
        string telefoneSacado = "993006666";
        string cep = "7569000";
        string enderecoCobranca = "praça sete";
        string uf = "RJ";
        string cidade = "Caldas novas";
        string bairro = "centro";
        DateOnly dataEmissao = new(2025, 01, 25);
        DateOnly dataVencimento = new(2025, 12, 25);
        decimal valorDesconto = 1000;
        decimal valorFace = 500000;
        string seuNumero = "89643";
        long idOperacao = 50;

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

        //Assert
        Assert.Equal(titulo.NomeSacado, nomeSacado);
        Assert.Equal(titulo.Cnpj, cnpj);
        Assert.Equal(titulo.TelefoneSacado, telefoneSacado);
        Assert.Equal(titulo.Cep, cep);
        Assert.Equal(titulo.EnderecoCobranca, enderecoCobranca);
        Assert.Equal(titulo.Uf, uf);
        Assert.Equal(titulo.Cidade, cidade);
        Assert.Equal(titulo.Bairro, bairro);
        Assert.Equal(titulo.DataEmissao, dataEmissao);
        Assert.Equal(titulo.DataVencimento, dataVencimento);
        Assert.Equal(titulo.ValorDesconto, valorDesconto);
        Assert.Equal(titulo.ValorFace, valorFace);
        Assert.Equal(titulo.SeuNumero, seuNumero);
        Assert.Equal(titulo.IdOperacao, idOperacao);
    }

    [Fact]
    public void Titulo_DeveAlterarDadosAoAtualizar()
    {
        //arrange
        string cnpj = "123456789";
        string nomeSacado = "teste";
        string telefoneSacado = "993006666";
        string cep = "7569000";
        string enderecoCobranca = "praça sete";
        string uf = "RJ";
        string cidade = "Caldas novas";
        string bairro = "centro";
        DateOnly dataEmissao = new(2025, 01, 25);
        DateOnly dataVencimento = new(2025, 12, 25);
        decimal valorDesconto = 1000;
        decimal valorFace = 500000;
        string seuNumero = "89643";
        long idOperacao = 50;

        string nomeSacadoAlterar = "nomesacado2";
        string telefoneSacadoAlterar = "99097161";
        string cepAlterar = "8374232";
        string enderecoCobrancaAlterar = "praça 3";
        string ufAlterar = "sp";
        string cidadeAlterar = "SJP";
        string bairroAlterar = "vila nova";
        string seuNumeroAlterar = "12939102";

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



        titulo.Atualizar(
            nomeSacadoAlterar,
            telefoneSacadoAlterar,
            cepAlterar,
            enderecoCobrancaAlterar,
            ufAlterar,
            cidadeAlterar,
            bairroAlterar,
            seuNumeroAlterar);

        Assert.Equal(titulo.NomeSacado, nomeSacadoAlterar);
        Assert.Equal(titulo.TelefoneSacado, telefoneSacadoAlterar);
        Assert.Equal(titulo.Cep, cepAlterar);
        Assert.Equal(titulo.EnderecoCobranca, enderecoCobrancaAlterar);
        Assert.Equal(titulo.Uf, ufAlterar);
        Assert.Equal(titulo.Cidade, cidadeAlterar);
        Assert.Equal(titulo.Bairro, bairroAlterar);
        Assert.Equal(titulo.SeuNumero, seuNumeroAlterar);
    }
}
