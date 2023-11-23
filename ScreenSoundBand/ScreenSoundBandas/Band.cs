using ScreenSound.Modelos;

class Band
{

    //private List<Album> albuns = new List<Album>();

    private List<Album> albuns => albuns;

    private List<int> notes = new List <int>();
    public Band(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public double NoteAverage => notes.Average();



    public void AddAlbum(Album album)
    {
        albuns.Add(album);
    }

    public void AddNote (int note)
    {
        notes.Add(note);
    }

    public void ExibirDiscografia()
    {
        Console.WriteLine($"Discografia da banda {Name}");
        foreach (Album album in albuns)
        {
            Console.WriteLine($"Álbum: {album.Name} ({album.TotalDuration})");
        }
    }

}