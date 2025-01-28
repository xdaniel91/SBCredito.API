using SbCredito.Aplicacao.Dtos.Criacao;
using SbCredito.Aplicacao.Dtos.Respostas;

namespace SbCredito.Aplicacao.Interfaces;
public interface IOperacaoService
{
    public Task AdicionarTitulOAsync(long idOperacao, CriarTituloDto tituloDto);
    public Task RemoverTituloAsync(long idOperacao, long idTitulo);
    public Task CriarOperacaoAsync(CriarOperacaoDto operacaoDto);
    public Task<IEnumerable<OperacaoResposta>> ObterOperacoesAsync();
    public Task<OperacaoResposta> ObterOperacaoAsync(long idOperacao);
}
