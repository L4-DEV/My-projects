class Musica
{
 
    public string? Nome { get; set; }

    public string Artista { get; set; }

    public int Duracao { get; set; }

    public bool Disponivel { get; set; }

    public Genero Genero { get; set; }

    public string Descricao =>
        $"A música {Nome}  pertence á  banda {Artista}";



    public void ShowData ()
    {
        Console.WriteLine($"Nome  {Nome}");
        Console.WriteLine($"Artista  {Artista}");
        Console.WriteLine($"Artista  {Disponivel}");
        Console.WriteLine($"Genero {Genero.Nome}");

        if (Disponivel)
        {
            Console.WriteLine("Dísponível no plano");       
        }
        else
        {
            Console.WriteLine("Adquira o plano PLUS");
        }

        
    }
 
}

