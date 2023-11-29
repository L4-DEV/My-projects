using System.ComponentModel.DataAnnotations;

namespace WebApi.Dtos
{
    public class ReadCinemaDto
    {
        [Required(ErrorMessage = "O campo nome é obrigatório!")]
        public string Nome { get; set; }
        public ReadEnderecoDto ReadEnderecoDto { get; set; }
    }
}
