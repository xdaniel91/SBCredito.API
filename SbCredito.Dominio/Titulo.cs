namespace SbCredito.Dominio;

public class Titulo : EntidadeBasePersistencia
{
    public string Cnpj { get; private set; }
    public string NomeSacado { get; private set; }
    public string TelefoneSacado { get; private set; }
    public string Cep { get; private set; }
    public string EnderecoCobranca { get; private set; }
    public string Uf { get; private set; }
    public string Cidade { get; private set; }
    public string Bairro { get; private set; }
    public DateOnly DataEmissao { get; private set; }
    public DateOnly DataVencimento { get; private set; }
    public decimal ValorDesconto { get; private set; }
    public decimal ValorFace { get; private set; }
    public string SeuNumero { get; private set; }
    public long IdOperacao { get; private set; }
    public Operacao Operacao { get; private set; }

    public Titulo(
        string cnpj, 
        string nomeSacado, 
        string telefoneSacado, 
        string cep, 
        string enderecoCobranca, 
        string uf, 
        string cidade, 
        string bairro, 
        DateOnly dataEmissao, 
        DateOnly dataVencimento, 
        decimal valorDesconto, 
        decimal valorFace, 
        string seuNumero,
        long idOperacao)
    {
        Cnpj = cnpj;
        NomeSacado = nomeSacado;
        TelefoneSacado = telefoneSacado;
        Cep = cep;
        EnderecoCobranca = enderecoCobranca;
        Uf = uf;
        Cidade = cidade;
        Bairro = bairro;
        DataEmissao = dataEmissao;
        DataVencimento = dataVencimento;
        ValorDesconto = valorDesconto;
        ValorFace = valorFace;
        SeuNumero = seuNumero;
        IdOperacao = idOperacao;
    }

    public void Atualizar(string nomeSacado,
    string telefoneSacado,
    string cep,
    string enderecoCobranca,
    string uf,
    string cidade,
    string bairro,
    string seuNumero)
    {
        NomeSacado = nomeSacado;
        TelefoneSacado = telefoneSacado;
        Cep = cep;
        EnderecoCobranca = enderecoCobranca;
        Uf = uf;
        Cidade = cidade;
        Bairro = bairro;
        SeuNumero = seuNumero;
    }
}
