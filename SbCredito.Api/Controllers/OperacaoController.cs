using Microsoft.AspNetCore.Mvc;
using SbCredito.Aplicacao.Dtos.Atualizacao;
using SbCredito.Aplicacao.Dtos.Criacao;
using SbCredito.Aplicacao.Interfaces;
using SbCredito.Dominio;

namespace SbCredito.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OperacaoController : ControllerBase
{
    private readonly IOperacaoService _operacaoService;
    private readonly ITituloService _tituloService;

    public OperacaoController(IOperacaoService operacaoService, ITituloService tituloService)
    {
        _operacaoService = operacaoService;
        _tituloService = tituloService;
    }

    [HttpPost]
    public async Task<IActionResult> CriarOperacaoAsync([FromBody] CriarOperacaoDto criarOperacaoDto)
    {
        await _operacaoService.CriarOperacaoAsync(criarOperacaoDto);
        return Ok();
    }

    [HttpPost("{idOperacao}/titulos")]
    public async Task<IActionResult> CriarOperacao(long idOperacao, [FromBody] CriarTituloDto criarTituloDto)
    {
        await _operacaoService.AdicionarTitulOAsync(idOperacao, criarTituloDto);
        return Ok();
    }

    [HttpDelete("{idOperacao}/titulos/{idTitulo}")]
    public async Task<IActionResult> CriarOperacao(long idOperacao, long idTitulo)
    {
        await _operacaoService.RemoverTituloAsync(idOperacao, idTitulo);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> ObterOperacoesAsync()
    {
        var operacoes = await _operacaoService.ObterOperacoesAsync();
        return Ok(operacoes);
    }

    [HttpPut("/titulos/{idTitulo}")]
    public async Task<IActionResult> AtualizarTituloAsync(long idTitulo, [FromBody] AtualizarTituloDto atualizarTituloDto)
    {
        await _tituloService.AtualizarTituloAsync(idTitulo, atualizarTituloDto);
        return Ok();
    }

}
