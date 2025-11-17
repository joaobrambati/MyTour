using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;
public class Amigo
{
    [Key]
    public int Id { get; set; }
    public required string Nome { get; set; }
}