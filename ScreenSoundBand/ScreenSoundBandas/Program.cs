using ScreenSound.Menus;
using ScreenSound.Modelos;

var message = "Welcome!!!";

Band audioSlave = new Band("AudioSlave");
audioSlave.AddNote(new Rate(10));
audioSlave.AddNote(new Rate(8));
audioSlave.AddNote(new Rate(6));
Band nickelback = new Band("Nickelback");

Dictionary<string, Band> registredBands = new();
registredBands.Add(audioSlave.Name, audioSlave);
registredBands.Add(nickelback.Name, nickelback);
#region
void ShowLogo()
{
    Console.WriteLine(@"
███╗░░░███╗██╗░░░██╗░██████╗██╗░█████╗░  ██████╗░░█████╗░███╗░░██╗██████╗░  ░█████╗░██████╗░██████╗░
████╗░████║██║░░░██║██╔════╝██║██╔══██╗  ██╔══██╗██╔══██╗████╗░██║██╔══██╗  ██╔══██╗██╔══██╗██╔══██╗
██╔████╔██║██║░░░██║╚█████╗░██║██║░░╚═╝  ██████╦╝███████║██╔██╗██║██║░░██║  ███████║██████╔╝██████╔╝
██║╚██╔╝██║██║░░░██║░╚═══██╗██║██║░░██╗  ██╔══██╗██╔══██║██║╚████║██║░░██║  ██╔══██║██╔═══╝░██╔═══╝░
██║░╚═╝░██║╚██████╔╝██████╔╝██║╚█████╔╝  ██████╦╝██║░░██║██║░╚███║██████╔╝  ██║░░██║██║░░░░░██║░░░░░
╚═╝░░░░░╚═╝░╚═════╝░╚═════╝░╚═╝░╚════╝░  ╚═════╝░╚═╝░░╚═╝╚═╝░░╚══╝╚═════╝░  ╚═╝░░╚═╝╚═╝░░░░░╚═╝░░░░░");
    Console.WriteLine(message);
    #endregion
}

Dictionary<int, Menu> options = new Dictionary<int, Menu>();
options.Add(1, new MenuBandRegister());
options.Add(2, new MenuAlbumRegister());
options.Add(3, new MenuShowBand());
options.Add(4, new MenuBandRate());
options.Add(5, new MenuShowDetails());
options.Add(-1, new MenuExit());
void ShowMenu()
{
    Console.Clear();
    ShowLogo();
    Console.WriteLine("\n[1] Registrar");
    Console.WriteLine("[2] Registrar álbum de uma banda");
    Console.WriteLine("[3] Ver todas as bandas");
    Console.WriteLine("[4] Avaliar uma banda");
    Console.WriteLine("[5] Para exibir a média de uma banda");
    Console.WriteLine("[-1] Exit\n");
    Console.Write(" Digita a opção desejada:");
    string choicedOption = Console.ReadLine()!;
    int choicedOptionNum = int.Parse(choicedOption);

    if (options.ContainsKey(choicedOptionNum))
    {
        Menu menuDisplayed = options[choicedOptionNum];
        menuDisplayed.Execute(registredBands);
        if (choicedOptionNum > 0) ShowMenu();
    }
    else
    {
        Console.WriteLine("Opção inválida");
    }
}

ShowMenu();



