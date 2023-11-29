using System.ComponentModel.DataAnnotations;

namespace WebApi.Dtos;

public class PatchCinemaDto
{
    [Required(ErrorMessage = "O campo nome é obrigatório!")]
    public string Nome { get; set; }
}
