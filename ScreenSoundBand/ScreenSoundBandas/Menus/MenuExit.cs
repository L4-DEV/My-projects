namespace ScreenSound.Menus;

internal class MenuExit:Menu
{
    public override void Execute(Dictionary<string, Band> registredBands)
    {
        Console.WriteLine("Tchau tchau :)");
    }
}
