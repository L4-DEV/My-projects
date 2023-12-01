using System.ComponentModel.DataAnnotations;

namespace WebApi.Models;

public class Cinema
{
    [Key]
    [Required]
    public int Id { get; set; }

    public string Nome { get; set; }    

    [Required(ErrorMessage = "O campo nome é obrigatório!")]
    public int EnderecoId { get; set; }
    public virtual Endereco Endereco { get; set; }

    public virtual ICollection<Sessao> Sessoes { get; set; }

}

