using System.ComponentModel.DataAnnotations;
using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;
using GeekLifeAPI.Validations.Attributes;

namespace GeekLifeAPI.Dtos.CDDtos
{
    public class CreateCDDto
    {
        [Required(ErrorMessage = "O campo NomeDoCd é obrigatório")]
        [RegularExpression(@"^[A-Za-zÀ-ÿ0-9\s]{1,128}$", ErrorMessage = "O nome d0 NomeDoCD deve conter apenas caracteres alfanuméricos.")]
        [StringLength(128, MinimumLength = 1, ErrorMessage = "E deve conter entre 1 e 128 caracteres")]
        public string NomeDoCD { get; set; }

        public int Numero { get; set; }

        [Required(ErrorMessage = "O campo Complemento é obrigatório")]
        [RegularExpression(@"^[A-Za-zÀ-ÿ0-9\s]{1,128}$", ErrorMessage = "O Complemento deve conter apenas caracteres alfanuméricos.")]
        [StringLength(128, MinimumLength = 1, ErrorMessage = "E deve conter entre 1 e 128 caracteres")]
        public string Complemento { get; set; }

        [BrazilianUF]
        public string UF { get; set; } 

        public string CEP { get; set; }

        [JsonIgnore]
        public bool Atividade { get; set; } = true;

        public string Status
        {
            get { return Atividade ? "ativa" : "inativa"; }
        }

        public DateTime HoraDaCriacao { get; private set; } = DateTime.Now;
        public DateTime HoraDaModificacao { get; private set; }

    }

   
}

