
using System.ComponentModel.DataAnnotations;
using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;

namespace GeekLifeAPI.Dtos.CategoriaDtos;

public class CreateCategoriaDto
{

    [Required(ErrorMessage = "O campo nome é obrigatório")]
    [RegularExpression(@"^[A-Za-zÀ-ÿ0-9\s]{1,128}$", ErrorMessage = "O nome da categoria deve conter apenas caracteres alfanuméricos.")]
    [StringLength(128, MinimumLength = 1, ErrorMessage = "E deve conter entre 1 e 128 caracteres")]
    public string NomeDaCategoria { get; set; }
    [JsonIgnore]
    public bool Atividade { get; set; } = true;

    public string Status
    {
        get { return Atividade ? "ativa" : "inativa"; }
    }

    public DateTime HoraDaCriacao { get; private set; } = DateTime.Now;

    public DateTime HoraDaModificacao { get; set; }
}

