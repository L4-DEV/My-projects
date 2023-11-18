using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;

namespace GeekLifeAPI.Dtos.SubDtos
{
    public class CreateSubDto
    {

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [RegularExpression(@"^[A-Za-zÀ-ÿ0-9\s]{1,128}$", ErrorMessage = "O nome da categoria deve conter apenas caracteres alfanuméricos.")]
        [StringLength(128, MinimumLength = 3, ErrorMessage = "E deve conter entre 3 e 128 caracteres")]
        public string NomeDaSub { get; set; }

        [JsonIgnore]
        public bool Atividade { get; set; } = true;

        public string Status
        {
            get { return Atividade ? "ativa" : "inativa"; }
        }

        public DateTime HoraDaCriacao { get; internal set; } = DateTime.Now;

        [JsonIgnore]
        [ReadOnly(true)]
        public DateTime HoraDaModificacao { get; set; }

        public int CategoriaId { get; set; }
    }
}
