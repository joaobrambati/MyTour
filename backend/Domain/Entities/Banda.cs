using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Banda
{
    [Key]
    public int Id { get; set; }
    public required string Nome { get; set; }
}
