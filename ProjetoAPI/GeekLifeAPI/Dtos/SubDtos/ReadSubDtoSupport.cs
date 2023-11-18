using GeekLifeAPI.Dtos.ProdutoDtos;

namespace GeekLifeAPI.Dtos.SubDtos
{
    public class ReadSubDtoSupport
    {
        public string NomeDaSub { get; set; }

        public string Atividade { get; set; }

        public ICollection<ReadProdutoDtoSupport> Produto { get; set; }

    }
}
