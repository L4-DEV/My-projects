using ScreenSoundAPI.Modelos;
using System.Text.Json;
using ScreenSoundAPI.Filtros;

using (HttpClient client = new HttpClient()) 
{
   
    try
    {
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        Console.WriteLine(resposta);

        
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;  /*Desserializção */
        LinqFilter.FiltrarTodosGeneros(musicas);
        


    }
    catch (Exception ex)
    {
        Console.WriteLine($"We have a problem: {ex.Message}");
    }

   
}