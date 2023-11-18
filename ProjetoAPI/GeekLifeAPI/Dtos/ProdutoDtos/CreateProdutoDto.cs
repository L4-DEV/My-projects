using System.ComponentModel.DataAnnotations;
using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;

namespace GeekLifeAPI.Dtos.ProdutoDtos
{
    public class CreateProdutoDto
    {
        public int SubId { get; set; }

        public int CDId { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-zÀ-ÿ0-9\s]{1,128}$", ErrorMessage = "O nome do produto deve conter apenas caracteres alfanuméricos!")]
        [StringLength(128, MinimumLength = 3, ErrorMessage = "E deve conter entre 3 e 128 caracteres")]
        public string NomeDoProduto { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-zÀ-ÿ0-9\s]{1,128}$", ErrorMessage = "A descrição do produto deve conter apenas caracteres alfanuméricos!")]
        [StringLength(512, MinimumLength = 3, ErrorMessage = "E deve conter entre 3 e 128 caracteres")]

        public string Descricao { get; set; }

        [Required]
        public float Peso { get; set; }
        [Required]
        public float Altura { get; set; }
        [Required]
        public float Largura { get; set; }
        [Required]
        public float Comprimento { get; set; }
        [Required]
        public float Valor { get; set; }
        [Required]
        public int QuantidadeEstoque { get; set; }

        [JsonIgnore]
        public bool Atividade { get; set; } = true;

        public string Status
        {
            get { return Atividade ? "ativa" : "inativa"; }
        }

        public DateTime HoraDaCriacao { get; internal set; } = DateTime.Now;

        [JsonIgnore]
        public DateTime HoraDaModificacao { get; private set; }

    }


}