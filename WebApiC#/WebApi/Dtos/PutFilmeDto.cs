using System.ComponentModel.DataAnnotations;

namespace WebApi.Dtos;

public class PutFilmeDto
{
    [Required(ErrorMessage = "O campo nome é obrigatório")]
    [RegularExpression(@"^[A-Za-zÀ-ÿ0-9\s]{1,128}$", ErrorMessage = "O nome da categoria deve conter apenas caracteres alfanuméricos.")]
    [StringLength(128, MinimumLength = 1, ErrorMessage = "E deve conter entre 1 e 128 caracteres")]
    public string Titulo { get; set; }


    [Required(ErrorMessage = "O campo nome é obrigatório")]
    [RegularExpression(@"^[A-Za-zÀ-ÿ0-9\s]{1,128}$", ErrorMessage = "O nome da categoria deve conter apenas caracteres alfanuméricos.")]
    [StringLength(128, MinimumLength = 1, ErrorMessage = "E deve conter entre 1 e 128 caracteres")]
    public string Genero { get; set; }

    [Required(ErrorMessage = "O campo nome é obrigatório")]
    [Range(60, 360)]
    public int Duracao { get; set; }
}
