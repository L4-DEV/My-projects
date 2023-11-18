using GeekLifeAPI.Dtos.SubDtos;

namespace GeekLifeAPI.Dtos.CategoriaDtos
{
    public class ReadCategoriaDtoSupport
    {
        public string NomeDaCategoria { get; set; }

        public string Atividade { get; set; }

        public ICollection<ReadSubDtoSupport> Sub { get; set; }
    }
}
