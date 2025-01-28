using SbCredito.Aplicacao.Dtos.Criacao;
using SbCredito.Aplicacao.Dtos.Respostas;
using SbCredito.Aplicacao.Factories;
using SbCredito.Aplicacao.Interfaces;
using SbCredito.Aplicacao.Repositorios;
using SbCredito.Dominio;

namespace SbCredito.Aplicacao.Servicos;
public class OperacaoService : IOperacaoService
{
    private readonly IOperacaoRepositorio _operacaoRepositorio;
    private readonly ITituloService _tituloService;
    private readonly ITituloRepositorio _tituloRepositorio;

    public OperacaoService(IOperacaoRepositorio operacaoRepositorio, ITituloService tituloService, ITituloRepositorio tituloRepositorio)
    {
        _operacaoRepositorio = operacaoRepositorio;
        _tituloService = tituloService;
        _tituloRepositorio = tituloRepositorio;
    }

    public async Task AdicionarTitulOAsync(long idOperacao, CriarTituloDto tituloDto)
    { 
        var operacao = await _operacaoRepositorio.ObterOperacaoAsync(idOperacao);

        if (operacao is null)
            throw new Exception($"operação nº {idOperacao} não encontrada.");

        var novoTitulo = await _tituloService.AdicionarAsync(tituloDto, idOperacao);

        operacao.AdicionarTitulo(novoTitulo);

    }

    public async Task CriarOperacaoAsync(CriarOperacaoDto operacaoDto)
    {
        var operacao = OperacaoFactory.CriarOperacao();
        await _operacaoRepositorio.AdicionarAsync(operacao);
        var titulo = await _tituloService.AdicionarAsync(operacaoDto.Titulo, operacao.Id);
        operacao.AdicionarTitulo(titulo);
    }

    public async Task<OperacaoResposta> ObterOperacaoAsync(long idOperacao)
    {
        var operacao = await _operacaoRepositorio.ObterOperacaoAsync(idOperacao);
        return OperacaoResposta.ConverterParaResposta(operacao);
    }

    public async Task<IEnumerable<OperacaoResposta>> ObterOperacoesAsync()
    {
        var operacoes = await _operacaoRepositorio.ObterOperacoesAsNoTrackingAsync();

        return operacoes.Select(OperacaoResposta.ConverterParaResposta);
    }

    public async Task RemoverTituloAsync(long idOperacao, long idTitulo)
    {
        var operacao = await _operacaoRepositorio.ObterOperacaoAsync(idOperacao);
        var tituloRemover = operacao.Titulos.SingleOrDefault(e => e.Id == idTitulo);

        if (tituloRemover is null)
            return;

        operacao.RemoverTitulo(tituloRemover);
        await _operacaoRepositorio.CommitAsync();
    }

    public async Task AtualizarTitulo(long idTitulo)
    {
        var operacao = _tituloRepositorio.ObterTituloAsync(idTitulo);
        

    }
}
