using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GeekLifeAPI.Models
{
    public class Produto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int SubId { get; set; } 

        public virtual Sub Sub { get; set; }

        public int CDId { get; set; }

        public virtual CD CD { get; set; }

        public string NomeDoProduto { get; set; } 

        public string Descricao { get; set; } 

        public float Peso { get; set; }

        public float Altura { get; set; }

        public float Largura { get; set; }

        public float Comprimento { get; set; }

        public float Valor { get; set; }

        public int QuantidadeEstoque { get; set; }

        [JsonIgnore]
        public bool Atividade { get; set; } = true;

        public string Status { get; set; } = "ativa";

        public DateTime HoraDaCriacao { get; set; }
    
        public DateTime HoraDaModificacao { get; set; }

    }
}



