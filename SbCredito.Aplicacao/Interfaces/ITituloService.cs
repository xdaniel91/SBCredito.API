using SbCredito.Aplicacao.Dtos.Atualizacao;
using SbCredito.Aplicacao.Dtos.Criacao;
using SbCredito.Dominio;

namespace SbCredito.Aplicacao.Interfaces;
public interface ITituloService
{
    public Task<Titulo> AdicionarAsync(CriarTituloDto criarTituloDto, long idOperacao);
    public Task AtualizarTituloAsync(long idTitulo, AtualizarTituloDto atualizarTituloDto);
}
