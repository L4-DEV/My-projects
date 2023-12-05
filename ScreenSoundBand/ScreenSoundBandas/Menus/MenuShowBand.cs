namespace ScreenSound.Menus;

internal class MenuShowBand:Menu
{
    public override void Execute(Dictionary<string, Band> registredBands)
    {
        base.Execute(registredBands);
        ShowTitle("Exibindo todas as bandas registradas");

        foreach (string band in registredBands.Keys)
        {
            Console.WriteLine($"Banda: {band}");
        }

        Console.WriteLine("\nDigite um tecla para voltar ao menu principal...");
        Console.ReadKey();
        Console.Clear();
    }
}
