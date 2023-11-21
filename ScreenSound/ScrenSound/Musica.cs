class Musica
{
    public Musica(Banda artista, string nome) 
    {
        Artista = artista;
        Nome = nome;
    }


    public string? Nome { get; set; }

    public Banda Artista { get;}

    public int Duracao { get; set; }

    public bool Disponivel { get; set; }


    public string Descricao =>
        $"A música {Nome}  pertence á  banda: {Artista}";



    public void ShowData ()
    {
        Console.WriteLine($"\nNome: {Nome}");
        Console.WriteLine($"Artista:  {Artista.Nome}");
        Console.WriteLine($"Duração: {Duracao}");
    

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

