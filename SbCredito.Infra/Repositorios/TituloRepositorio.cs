using Microsoft.EntityFrameworkCore;
using SbCredito.Aplicacao.Repositorios;
using SbCredito.Dominio;

namespace SbCredito.Infra.Repositorios;
public class TituloRepositorio : ITituloRepositorio
{
    private readonly SbCreditoContext _context;

    public TituloRepositorio(SbCreditoContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(Titulo titulo)
    {
        await _context.titulos.AddAsync(titulo);
        await CommitAsync();
    }

    public async Task<bool> CommitAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<Titulo> ObterTituloAsync(long idTitulo)
    {
        return await _context.titulos.SingleOrDefaultAsync(e => e.Id == idTitulo);
    }
}
