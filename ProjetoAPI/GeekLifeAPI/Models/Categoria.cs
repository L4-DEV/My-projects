
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GeekLifeAPI.Models;

public class Categoria
{
    [Key]
    [Required]
    public int Id { get; set; }
   
    public string NomeDaCategoria { get; set; }

    [JsonIgnore]
    public bool Atividade { get; set; } = true;

    public string Status { get; set; } = "ativa";

    public DateTime HoraDaCriacao { get; set; } 

    public DateTime HoraDaModificacao { get; set; }

    public virtual ICollection<Sub> Subs { get; set; }

}
   
