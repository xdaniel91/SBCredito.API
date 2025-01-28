using SbCredito.Dominio;

namespace SbCredito.Aplicacao.Repositorios;
public interface ITituloRepositorio : IRepositorioBase
{
    public Task AdicionarAsync(Titulo titulo);
    public Task<Titulo> ObterTituloAsync(long idTitulo);
}
