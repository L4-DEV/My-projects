namespace ScreenSound.Modelos;

class Music
{
    public Music(Band artist, string name)
    {
        Artist = artist;
        Name = name;
    }

    public string? Name { get; set; }

    public Band Artist { get; }

    public int Duration { get; set; }

    public bool Available { get; set; }

    public string description =>
        $"A música {Name}  pertence á  banda: {Artist}";


    public void ShowData()
    {
        Console.WriteLine($"\nNome: {Name}");
        Console.WriteLine($"Artista:  {Artist.Name}");
        Console.WriteLine($"Duração: {Duration}");


        if (Available)
        {
            Console.WriteLine("Dísponível no plano");
        }
        else
        {
            Console.WriteLine("Adquira o plano PLUS");
        }


    }

}

