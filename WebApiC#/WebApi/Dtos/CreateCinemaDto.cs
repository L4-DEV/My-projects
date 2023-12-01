

using System.ComponentModel.DataAnnotations;

namespace WebApi.Dtos;

public class CreateCinemaDto
{

    [Required(ErrorMessage = "O campo nome é obrigatório")]
    [RegularExpression(@"^[A-Za-zÀ-ÿ0-9\s]{1,128}$", ErrorMessage = "O nome da categoria deve conter apenas caracteres alfanuméricos.")]
    [StringLength(128, MinimumLength = 1, ErrorMessage = "E deve conter entre 1 e 128 caracteres")]
    public string Nome { get; set; }

    
    public int EnderecoId { get; set; }
}
