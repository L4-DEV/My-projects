using GeekLifeAPI.Dtos.SubDtos;
using GeekLifeAPI.Dtos.CDDtos;

namespace GeekLifeAPI.Dtos.ProdutoDtos
{
    public class ReadProdutoDto
    {
        public int Id { get; set; }

        public string NomeDoProduto { get; set; }

        public string Descricao { get; set; }

        public float Peso { get; set; }

        public float Altura { get; set; }

        public float Largura { get; set; }

        public float Comprimento { get; set; }

        public decimal Valor { get; set; }

        public int QuantidadeEstoque { get; set; }

        public string Atividade { get; set; }

        public DateTime HoraDaCriacao { get; set; }

        public DateTime HoraDaModificacao { get; set; }

        public ReadSubDtoEnd Sub { get; set; }

        public ReadCDDtoSupport CD { get; set; }

    }
}

