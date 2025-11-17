using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Show
{
    [Key]
    public int Id { get; set; }

    public int BandaPrincipalId { get; set; }
    public required Banda BandaPrincipal { get; set; }

    public ICollection<Banda> BandasAbertura { get; set; } = new List<Banda>();

    public DateTime Data { get; set; }
    public required string Genero { get; set; }
    public decimal? ValorIngresso { get; set; }
    public int Avaliacao { get; set; }
    public string? Observacao { get; set; }

    public ICollection<Amigo> Amigos { get; set; } = new List<Amigo>();
}