

using ScreenSound.Modelos;
using System.Runtime;
using System.Threading.Channels;

namespace ScreenSound.Menus
{
    internal class MenuAlbumRate:Menu
    {
        public override void Execute(Dictionary<string, Band> registredBands)
        {
            base.Execute(registredBands);
            ShowTitle("Avaliar Albúm");
            Console.Write("Digite o nome da banda que deseja avaliar :");
            string bandName = Console.ReadLine()!;
            if (registredBands.ContainsKey(bandName))
            {
                Band band = registredBands[bandName];

                Console.WriteLine("Agora digite o título do álbum: ");
                string albumTitle = Console.ReadLine()!;

                if (band.Albuns.Any(a => a.Name.Equals(albumTitle)))
                {
                    Album album = band.Albuns.First(album => album.Name.Equals(albumTitle));
                    Console.WriteLine($"Qual a nota que o Álbum {albumTitle} merece: ");
                    Rate note = Rate.Parse(Console.ReadLine()!);
                    album.AddNote(note);
                    Console.WriteLine($"\nA nota {note.Note} foi registrada com sucesso para o álbum {albumTitle}");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine($"\nA banda  {albumTitle}  não foi encontrada!");
                    Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            else
            {
                Console.WriteLine($"\nA banda {bandName} não foi encontrada!");
                Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
