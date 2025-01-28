namespace SbCredito.Aplicacao.Repositorios;
public interface IRepositorioBase
{
    public Task<bool> CommitAsync();
}
