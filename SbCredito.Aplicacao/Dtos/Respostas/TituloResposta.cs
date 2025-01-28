using SbCredito.Dominio;

namespace SbCredito.Aplicacao.Dtos.Respostas;
public class TituloResposta
{
    public string Cnpj { get; set; }
    public string NomeSacado { get; set; }
    public string TelefoneSacado { get; set; }
    public string Cep { get; set; }
    public string EnderecoCobranca { get; set; }
    public string Uf { get; set; }
    public string Cidade { get; set; }
    public string Bairro { get; set; }
    public DateOnly DataEmissao { get; set; }
    public DateOnly DataVencimento { get; set; }
    public decimal ValorDesconto { get; set; }
    public decimal ValorFace { get; set; }
    public string SeuNumero { get; set; }

    public static TituloResposta ConverterParaResposta(Titulo titulo)
    {
        return new TituloResposta
        {
            Cnpj = titulo.Cnpj,
            Bairro = titulo.Bairro,
            Cep = titulo.Cep,
            Cidade = titulo.Cidade,
            DataEmissao = titulo.DataEmissao,
            DataVencimento = titulo.DataVencimento,
            EnderecoCobranca = titulo.EnderecoCobranca,
            NomeSacado = titulo.NomeSacado,
            SeuNumero = titulo.SeuNumero,
            TelefoneSacado = titulo.TelefoneSacado,
            Uf = titulo.Uf,
            ValorDesconto = titulo.ValorDesconto,
            ValorFace = titulo.ValorFace
        };
    }
}
