using OpenAI_API;

namespace ScreenSound.Menus;

internal class MenuBandRegister : Menu
{
    public override void Execute (Dictionary<string, Band> registredBands)
    {
        base.Execute(registredBands);
        ShowTitle("Registro das bandas");
        Console.Write("Digite o nome da banda que deseja registrar: ");
        string nameBand = Console.ReadLine()!;
        Band band = new Band(nameBand);
        registredBands.Add(nameBand, band);

        //var client = new OpenAIAPI("<SUA API KEY AQUI>");
        //var chat = client.Chat.CreateConversation();
        //chat.AppendSystemMessage($"Resuma a banda {nameBand} , em um parágrafo. Adote um estilo descolado.");
        //string response = chat.GetResponseFromChatbotAsync().GetAwaiter().GetResult();
        //band.Summary = response;

        Console.WriteLine($"A banda {nameBand} foi registrada com sucesso!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal...");
        Console.ReadKey();
        Console.Clear();
    }
}
    
