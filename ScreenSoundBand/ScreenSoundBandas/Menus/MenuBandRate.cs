using ScreenSound.Modelos;

namespace ScreenSound.Menus;

internal class MenuBandRate:Menu
{
    public override void Execute(Dictionary<string, Band> registredBands) 
    {
        base.Execute(registredBands);
        ShowTitle("Avaliar Banda");
        Console.Write("Digite o nome da banda que deseja avaliar: ");
        string bandName = Console.ReadLine()!; //exclamação para não aceitar valor null.
        if (registredBands.ContainsKey(bandName))
        {
            Band band = registredBands[bandName];
            Console.Write($"Qual a nota que a {bandName} merece: ");
            Rate note = Rate.Parse(Console.ReadLine()!);
            band.AddNote(note);
            Console.WriteLine($"\nA nota {note.Note}, foi registrada com sucesso para a banda {bandName}");
            Thread.Sleep(2000);
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
