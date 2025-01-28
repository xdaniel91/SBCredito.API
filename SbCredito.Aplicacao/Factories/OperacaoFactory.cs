using FluentValidation;
using SbCredito.Aplicacao.Validadores;
using SbCredito.Dominio;

namespace SbCredito.Aplicacao.Factories;
public static class OperacaoFactory
{
    private static readonly OperacaoValidador _validador = new();

    public static Operacao CriarOperacao()
    {
        var operacao = new Operacao();
        var validationResult = _validador.Validate(operacao);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return operacao;
    }
}
