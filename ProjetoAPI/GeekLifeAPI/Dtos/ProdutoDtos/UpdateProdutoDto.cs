﻿using System.ComponentModel.DataAnnotations;


namespace GeekLifeAPI.Dtos.ProdutoDtos
{
    public class UpdateProdutoDto
    {

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
        public decimal Valor { get; set; }
        [Required]
        public int QuantidadeEstoque { get; set; }

        public bool Atividade { get; set; }

        public string Status
        {
            get { return Atividade ? "ativa" : "inativa"; }
        }

        public DateTime HoraDaModificacao { get; set; } = DateTime.Now;
    }
}
