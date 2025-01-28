using FluentValidation;
using SbCredito.Aplicacao.Validadores;
using SbCredito.Dominio;

namespace SbCredito.Aplicacao.Factories;
public static class TituloFactory
{
    private static readonly TituloValidador _validador = new();

    public static Titulo CriarTitulo(
        string cnpj,
        string nomeSacado,
        string telefoneSacado,
        string cep,
        string enderecoCobranca,
        string uf,
        string cidade,
        string bairro,
        DateOnly dataEmissao,
        DateOnly dataVencimento,
        decimal valorDesconto,
        decimal valorFace,
        string seuNumero,
        long idOperacao)
    {
        var titulo = new Titulo(
        cnpj,
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

        _validador.Validate(titulo);
        var validacaoResultado = _validador.Validate(titulo);

        if (!validacaoResultado.IsValid)
            throw new ValidationException(validacaoResultado.Errors);

        return titulo;
    }

}
