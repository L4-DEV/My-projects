using GeekLifeAPI.Dtos.CategoriaDtos;
using GeekLifeAPI.Dtos.ProdutoDtos;

namespace GeekLifeAPI.Dtos.SubDtos
{
    public class ReadSubDto
    {
        public int Id { get; set; }

        public string NomeDaSub { get; set; }

        public string Atividade { get; set; }

        public DateTime HoraDaCriacao { get; set; }
        public DateTime HoraDaModificacao { get; set; }

        public ReadCategoriaDtoSupport Categoria { get; set; }

        public ICollection<ReadProdutoDtoSupport> Produto { get; set; }

    }
}

