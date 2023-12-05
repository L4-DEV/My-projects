using ScreenSound.Modelos;

internal class Band:IAssessable
{
    
    private List<Album> albuns = new List<Album>();
    private List<Rate> notes = new List <Rate>();

    public Band(string name)
    {
        Name = name;
        
    }

    public string Name { get; }

    public double NoteAverage
    {
        get
        {
            if (notes.Count == 0) return 0;
            else return  notes.Average(r => r.Note);
        }
    }

    public string? Summary { get; set; }

    public List<Album> Albuns => albuns;
    public void AddAlbum(Album album)
    {
        albuns.Add(album);
    }

    public void AddNote (Rate note)
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