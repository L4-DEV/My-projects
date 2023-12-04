namespace ScreenSound.Menus;

internal class MenuShowDetails:Menu
{ 
    public override void Execute (Dictionary<string, Band> registredBands)
    {
        base.Execute (registredBands);
        ShowTitle("Mostrar  nota média da banda");
        Console.Write("Digite o nome da banda que deseja ver a média :");
        string bandName = Console.ReadLine()!;
        if (registredBands.ContainsKey(bandName))
        {
            Band band = registredBands[bandName];
            Console.Write($"\nA nota média da banda {bandName} é : {band.NoteAverage}!");
            Thread.Sleep(5000);
            Console.Clear();   
        }
        else
        {
            Console.WriteLine($"\n A banda {bandName} não foi encontrada");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal...");           
        }
    }
}
