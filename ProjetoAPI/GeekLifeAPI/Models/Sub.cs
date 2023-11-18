using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace GeekLifeAPI.Models;

public class Sub
{
    [Key]
    [Required]
    public int Id { get; set; }

    public string NomeDaSub { get; set; }

    [JsonIgnore]
    public bool Atividade { get; set; } = true;

    public string Status { get; set; } = "ativa";

    public DateTime HoraDaCriacao { get; set; }

    public DateTime HoraDaModificacao { get; set; }

    [Required]
    public int CategoriaId { get; set; }

    public virtual Categoria Categoria { get; set; }

    public virtual ICollection<Produto> Produtos { get; set; }
}

