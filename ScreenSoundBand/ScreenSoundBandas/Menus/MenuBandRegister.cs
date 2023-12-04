namespace ScreenSound.Menus;

internal class MenuBandRegister : Menu
{
    public override void Execute(Dictionary<string, Band> registredBands)
    {
        base.Execute(registredBands);
        ShowTitle("Registro das bandas");
        Console.Write("Digite o nome da banda que deseja registrar: ");
        string nameBand = Console.ReadLine()!;
        Band band = new Band(nameBand);
        registredBands.Add(nameBand, band);
        Console.WriteLine($"A banda {nameBand} foi registrada com sucesso!");
        Thread.Sleep(2000);
        Console.Clear();
    }
}
    
