namespace ScreenSound;

internal class Rate
{
    public Rate (int note) 
    {
        Note = note;
    }
    public int Note { get; }

    public static Rate Parse(string texto)
    {
        int note = int.Parse(texto);
        return new Rate(note);
    }
}
