using System.ComponentModel.DataAnnotations;

namespace WebApi.Models;

public class Filme
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public string Titulo{ get; set; }

    public string Genero { get; set; }

    public int Duracao { get; set; }
}