using GeekLifeAPI.Dtos.SubDtos;

namespace GeekLifeAPI.Dtos.CategoriaDtos
{
    public class ReadAllCategoriaDto
    {

        public int Id { get; set; }
        public string NomeDaCategoria { get; set; }
        public string Atividade { get; set; }
        public DateTime HoraDaCriacao { get; private set; }
        public DateTime HoraDaModificacao { get; private set; }
       
    }
}
