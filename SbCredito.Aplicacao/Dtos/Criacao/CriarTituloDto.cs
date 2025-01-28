namespace SbCredito.Aplicacao.Dtos.Criacao;

public class CriarTituloDto
{
    public string Cnpj { get;  set; }
    public string NomeSacado { get;  set; }
    public string TelefoneSacado { get;  set; }
    public string Cep { get; set; }
    public string EnderecoCobranca { get;  set; }
    public string Uf { get;  set; }
    public string Cidade { get;  set; }
    public string Bairro { get;  set; }
    public DateOnly DataEmissao { get;  set; }
    public DateOnly DataVencimento { get;  set; }
    public decimal ValorDesconto { get;  set; }
    public decimal ValorFace { get;  set; }
    public string SeuNumero { get;  set; }
}
