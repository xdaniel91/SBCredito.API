using SbCredito.Dominio.Enums;

namespace SbCredito.Dominio;
public class Operacao : EntidadeBasePersistencia
{
    private readonly List<Titulo> _titulos = new();

    public StatusOperacao Status { get; private set; }
    public DateTimeOffset DataHoraCriacao { get; private set; }
    public decimal SomaTitulos => _titulos.Sum(e => e.ValorFace - e.ValorDesconto);
    public IReadOnlyCollection<Titulo> Titulos => _titulos;

    public Operacao()
    {
        Status = StatusOperacao.Pendente;
        DataHoraCriacao = DateTimeOffset.Now.ToUniversalTime();
    }

    public void AdicionarTitulo(Titulo titulo)
    {
        if (!_titulos.Any(e => e.Id == titulo.Id))
            _titulos.Add(titulo);
    }

    public void RemoverTitulo(Titulo titulo)
    {
        _titulos.Remove(titulo);
    }
}
