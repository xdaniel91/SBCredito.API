using SbCredito.Dominio;
using SbCredito.Dominio.Enums;

namespace SbCredito.Aplicacao.Dtos.Respostas;
public class OperacaoResposta
{
    public StatusOperacao Status { get; set; }
    public DateTimeOffset DataHoraCriacao { get; set; }
    public IEnumerable<TituloResposta> Titulos { get; set; }

    public static OperacaoResposta ConverterParaResposta(Operacao operacao)
    {
        return new OperacaoResposta
        {
            Status = operacao.Status,
            DataHoraCriacao = operacao.DataHoraCriacao.ToUniversalTime(),
            Titulos = operacao.Titulos.Select(TituloResposta.ConverterParaResposta)
        };
    }
}
