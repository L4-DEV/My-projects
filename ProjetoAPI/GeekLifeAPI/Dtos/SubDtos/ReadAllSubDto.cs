using GeekLifeAPI.Dtos.CategoriaDtos;

namespace GeekLifeAPI.Dtos.SubDtos
{
    public class ReadAllSubDto
    {
        public int Id { get; set; }

        public string NomeDaSub { get; set; }

        public string Atividade { get; set; }

        public DateTime HoraDaCriacao { get; set; }
        public DateTime HoraDaModificacao { get; set; }

    }
}
