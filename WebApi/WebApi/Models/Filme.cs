using System.ComponentModel.DataAnnotations;

namespace WebApi.Models;

public class Filme
{
    [Required]
    public string Titulo { get; set; }

    public string Genero { get; set; }

    public int Duracao { get; set; }
    //{
    //    get
    //    {
    //        if (Duracao < 0) return 0;
    //        else if (Duracao > 240) return 240;
    //        else return Duracao;
    //    }

    //    set { Duracao = value; }
    //}
}