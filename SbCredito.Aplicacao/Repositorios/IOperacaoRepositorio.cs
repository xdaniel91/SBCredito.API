using SbCredito.Dominio;

namespace SbCredito.Aplicacao.Repositorios;
public interface IOperacaoRepositorio : IRepositorioBase
{
    public Task<Operacao> ObterOperacaoAsync(long idOperacao);
    public Task<Operacao> ObterOperacaoAsNoTrackingAsync(long idOperacao);
    public Task AdicionarAsync(Operacao operacao);
    public Task<IEnumerable<Operacao>> ObterOperacoesAsNoTrackingAsync();
}
