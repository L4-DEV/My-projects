namespace ScreenSound.Modelos;


internal class Album
{
    private List<Music> music = new List<Music>();
    private List<Rate> notes = new List<Rate>();
    public Album(string name)
    {
        Name = name;
    }
 
    public string Name { get; set; }

    public double NoteAverage
    {
        get
        {
            if (notes.Count == 0) return 0;
            else return notes.Average(r => r.Note);
        }
    }

    public List<Music> Music => music;
    public int TotalDuration => music.Sum(m => m.Duration);

    public void AddMusica(Music song)
    {
        music.Add(song);
    }

    public void AddNote(Rate note)
    {
        notes.Add(note);
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
