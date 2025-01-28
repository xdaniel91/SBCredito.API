using SbCredito.Aplicacao.Dtos.Atualizacao;
using SbCredito.Aplicacao.Dtos.Criacao;
using SbCredito.Aplicacao.Factories;
using SbCredito.Aplicacao.Interfaces;
using SbCredito.Aplicacao.Repositorios;
using SbCredito.Dominio;

namespace SbCredito.Aplicacao.Servicos;
public class TituloService : ITituloService
{
    private readonly ITituloRepositorio _repositorio;

    public TituloService(ITituloRepositorio repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<Titulo> AdicionarAsync(CriarTituloDto criarTituloDto, long idOperacao)
    {
        var titulo = TituloFactory.CriarTitulo(
        criarTituloDto.Cnpj,
        criarTituloDto.NomeSacado,
        criarTituloDto.TelefoneSacado,
        criarTituloDto.Cep,
        criarTituloDto.EnderecoCobranca,
        criarTituloDto.Uf,
        criarTituloDto.Cidade,
        criarTituloDto.Bairro,
        criarTituloDto.DataEmissao,
        criarTituloDto.DataVencimento,
        criarTituloDto.ValorDesconto,
        criarTituloDto.ValorFace,
        criarTituloDto.SeuNumero,
        idOperacao);

        await _repositorio.AdicionarAsync(titulo);
        return titulo;
    }

    public async Task AtualizarTituloAsync(long idTitulo, AtualizarTituloDto atualizarTituloDto)
    {
        Titulo? tituloAtualizar = await _repositorio.ObterTituloAsync(idTitulo);

        if (tituloAtualizar is null)
            throw new Exception($"Titulo com com numero {idTitulo} não encontrado");

        tituloAtualizar.Atualizar(
            atualizarTituloDto.NomeSacado,
            atualizarTituloDto.TelefoneSacado,
            atualizarTituloDto.Cep,
            atualizarTituloDto.EnderecoCobranca,
            atualizarTituloDto.Uf,
            atualizarTituloDto.Cidade,
            atualizarTituloDto.Bairro,
            atualizarTituloDto.SeuNumero);

        await _repositorio.CommitAsync();
    }
}
