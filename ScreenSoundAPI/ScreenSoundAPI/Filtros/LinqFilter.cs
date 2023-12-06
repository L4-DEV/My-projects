
using ScreenSoundAPI.Modelos;

namespace ScreenSoundAPI.Filtros;

internal class LinqFilter
{
    public static void FiltrarTodosGeneros (List<Musica> musicas)
    {
        var GenerosMusicais = musicas.Select(genero => genero.Genero).Distinct().ToList();
        foreach (var genero in GenerosMusicais)
        {
            Console.WriteLine($"- {genero}");
        }
    }
}
