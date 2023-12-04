using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuAlbumRegister:Menu
{
    public override void Execute(Dictionary<string, Band> registredBands)
    {

        base.Execute(registredBands);
        ShowTitle("Registro de álbuns");
        Console.WriteLine("Dite a banda cujo álbum deseja registrar: ");
        string bandName = Console.ReadLine();

        if (registredBands.ContainsKey(bandName))
        {
            Console.WriteLine("Agora digite o título do álbum: ");
            string albumTitle = Console.ReadLine()!;
            Band band = registredBands[bandName];
            band.AddAlbum(new Album(albumTitle));
            Console.WriteLine($"O álbum {albumTitle} de {bandName} foi registrado com sucesso!");
            Thread.Sleep(4000);
            Console.Clear();
        }
        else
        {
            Console.WriteLine($"\n A banda {bandName} não foi encontrada");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal...");
            Console.ReadKey();
            Console.Clear();
        }
    }

}
