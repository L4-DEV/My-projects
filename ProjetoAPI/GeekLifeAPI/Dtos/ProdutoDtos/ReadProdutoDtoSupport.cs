using GeekLifeAPI.Dtos.CDDtos;
using GeekLifeAPI.Dtos.SubDtos;

namespace GeekLifeAPI.Dtos.ProdutoDtos
{
    public class ReadProdutoDtoSupport
    {
        public string NomeDoProduto { get; set; }

        public string Atividade { get; set; }

        public ReadCDDtoSupport CD { get; set; }

        public ReadSubDtoEnd Sub { get; set; }
    }

   


    
}
