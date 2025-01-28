using Microsoft.EntityFrameworkCore;
using SbCredito.Aplicacao.Repositorios;
using SbCredito.Dominio;

namespace SbCredito.Infra.Repositorios;
public class OperacaoRepositorio : IOperacaoRepositorio
{
    private readonly SbCreditoContext _context;

    public OperacaoRepositorio(SbCreditoContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(Operacao operacao)
    {
        await _context.operacoes.AddAsync(operacao);
        await CommitAsync();
    }

    public async Task<bool> CommitAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<Operacao> ObterOperacaoAsNoTrackingAsync(long idOperacao)
    {
        return await _context.operacoes.AsNoTracking().Include(e => e.Titulos).SingleOrDefaultAsync(e => e.Id == idOperacao);
    }
    public async Task<IEnumerable<Operacao>> ObterOperacoesAsNoTrackingAsync()
    {
        return _context.operacoes.Include(e => e.Titulos).AsNoTracking().AsEnumerable();
    }

    public async Task<Operacao> ObterOperacaoAsync(long idOperacao)
    {
        return await _context.operacoes.Include(e => e.Titulos).SingleOrDefaultAsync(e => e.Id == idOperacao);
    }
}
