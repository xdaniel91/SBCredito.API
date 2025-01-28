using FluentValidation;
using SbCredito.Dominio;

namespace SbCredito.Aplicacao.Validadores;
public class TituloValidador : AbstractValidator<Titulo>
{
    public TituloValidador()
    {
        RuleFor(e => e.Bairro).NotEmpty();
        RuleFor(e => e.Cep).Length(8);
        RuleFor(e => e.Uf).Length(2);
        RuleFor(e => e.SeuNumero).NotEmpty();
        RuleFor(e => e.Cidade).NotEmpty();
        RuleFor(e => e.Cnpj).NotEmpty().Length(14);
        RuleFor(e => e.DataEmissao).NotEmpty();
        RuleFor(e => e.DataVencimento).GreaterThan(e => e.DataEmissao);
        RuleFor(e => e.EnderecoCobranca).NotEmpty();
        RuleFor(e => e.NomeSacado).NotEmpty();
        RuleFor(e => e.TelefoneSacado).NotEmpty();
        RuleFor(e => e.ValorDesconto).GreaterThanOrEqualTo(0).LessThan(e => e.ValorFace);
        RuleFor(e => e.ValorFace).GreaterThanOrEqualTo(0);
    }
}
