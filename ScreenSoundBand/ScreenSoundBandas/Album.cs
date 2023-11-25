namespace ScreenSound.Modelos;


internal class Album
{
    private List<Music> music = new List<Music>();
    public Album(string name)
    {
        Name = name;
    }
 
    public string Name { get; set; }

    public int TotalDuration => music.Sum(m => m.Duration);

    public void AddMusica(Music music1)
    {
        music.Add(music1);
    }


    public void ShowAlbum()
    {
        Console.WriteLine($"Lista de músicas do álbum {Name}:\n");
        foreach (var music in music)
        {
            Console.WriteLine($"Música: {music.Name}");
        }
        Console.WriteLine($"\nPara ouvir esta álbum inteiro você precisa de {TotalDuration}");
    }
}
