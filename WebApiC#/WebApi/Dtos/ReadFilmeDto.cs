using System.ComponentModel.DataAnnotations;
using WebApi.Models;

namespace WebApi.Dtos
{
    public class ReadFilmeDto
    {
  
        public string Titulo { get; set; }

        public string Genero { get; set; }
        public int Duracao { get; set; }

        public DateTime HoraDaConsulta { get;  } =DateTime.Now;

        public virtual ICollection<ReadSessaoDto> Sessoes { get; set; }

        
    }
}
