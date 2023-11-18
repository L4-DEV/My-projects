class Album
{

    private List<Musica> musicas = new List<Musica> ();
    public string Nome { get; set; }

    public int DuracaoTotal => musicas.Sum(m => m.Duracao);

    public void AddMusica (Musica musica)
    {
        musicas.Add(musica);
    }

    public void ShowAlbum()
    {
        Console.WriteLine($"Lista de músicas do álbum {Nome}:\n");
        foreach (var musica in musicas)
        {
            Console.WriteLine($"Música: {musica.Nome}");
        }
        Console.WriteLine($"\nPara ouvir esta álbum inteiro você precisa de {DuracaoTotal}");
    }
}
