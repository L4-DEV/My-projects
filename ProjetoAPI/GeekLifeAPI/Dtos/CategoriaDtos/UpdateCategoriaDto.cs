using System.ComponentModel.DataAnnotations;

namespace GeekLifeAPI.Dtos.CategoriaDtos;

public class UpdateCategoriaDto
{

    [Required]
    [RegularExpression(@"^[A-Za-zÀ-ÿ0-9\s]{3,128}$", ErrorMessage = "O nome da categoria deve conter apenas letras.")]
    [StringLength(128, MinimumLength = 3, ErrorMessage = "E deve conter entre 3 e 128 caracteres")]
    public string NomeDaCategoria { get; set; }

    public bool Atividade { get; set; }

    public string Status
    {
        get { return Atividade ? "ativa" : "inativa"; }
    }

    public DateTime HoraDaModificacao { get; private set; } = DateTime.Now;

}
