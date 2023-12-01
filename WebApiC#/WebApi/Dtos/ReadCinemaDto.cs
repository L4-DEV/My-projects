using System.ComponentModel.DataAnnotations;
using WebApi.Models;

namespace WebApi.Dtos
{
    public class ReadCinemaDto
    { 
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório!")]
        public string Nome { get; set; }
        public virtual ICollection<ReadSessaoDto> Sessoes { get; set; }

        public virtual ReadEnderecoDto Endereco { get; set; }  
    }
}
