using FluentValidation;
using SbCredito.Dominio;

namespace SbCredito.Aplicacao.Validadores;
public class OperacaoValidador : AbstractValidator<Operacao>
{
    public OperacaoValidador()
    {
        RuleFor(e => e.DataHoraCriacao).NotEmpty();
    }
}
