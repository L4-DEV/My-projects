

namespace GeekLifeAPI.Dtos.ProdutoDtos
{
    public class UpdateProdutoDtoPatch
    {

        public string? NomeDoProduto { get; set; }

        public bool? Atividade { get; set; }

        public string? Status => Atividade.HasValue ? (Atividade.Value ? "ativa" : "inativa") : null;

        public string? Descricao { get; set; }

        public float Peso { get; set; }

        public float Altura { get; set; }

        public float Largura { get; set; }

        public float Comprimento { get; set; }

        public float Valor { get; set; }

        public int QuantidadeEstoque { get; set; }
        public DateTime HoraDaModificacao { get; internal set; } = DateTime.Now;
    }
}
