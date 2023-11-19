class Program
{
    
    static void Main(string[] args)
    {
        var bandName= string.Empty;
        var message = "Welcome!!!";
        //List<string> bandList = new List<string> { "U2", "The Bleattles", "Calypso" };

        Dictionary <string,List<int>> RegistredBands= new Dictionary<string, List<int>>();
        RegistredBands.Add("Linkin Park", new List<int> { 10, 8, 6 });
        RegistredBands.Add("The Beatles", new List<int> { });
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
        void ShowMenu()
        {
            Console.Clear();
            ShowLogo();
            Console.WriteLine("\n[1] Registrar");
            Console.WriteLine("[2] Ver todas as bandas");
            Console.WriteLine("[3] Avaliar uma banda");
            Console.WriteLine("[4] Para exibir a média de uma banda");
            Console.WriteLine("[-1] Exit\n");

            Console.Write(" Digita a opção desejada:");
            string opcao = Console.ReadLine();
            int opcaoNum = int.Parse(opcao);

            switch (opcaoNum)
            {

                case 1:
                    Register();
                    break;
                case 2:
                    ShowListBand();
                    break;
                case 3:
                    BandRate();
                    break;
                case 4:
                    ShowAverage();
                    break;
                case -1:
                    Console.WriteLine("Até logo!");
                    break;

                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }

        void Register()
        {
            Console.Clear();
            ShowTitle("Registro das bandas");
            Console.Write("Digite o nome da banda que deseja registrar: ");
            string nameBand = Console.ReadLine()!;
            RegistredBands.Add(nameBand, new List<int> ());
            Console.WriteLine($"A banda {nameBand} foi registrada com sucesso!");
            Thread.Sleep(2000);
            Console.Clear();
            ShowMenu();
        }
        void ShowListBand()
        {
            Console.Clear();
            ShowTitle("Exibindo todas as bandas registradas");

            foreach (string band in RegistredBands.Keys)
            {
                Console.WriteLine($"Banda: {band}");
            }

            Console.WriteLine("\nDigite um tecla para voltar ao menu principal...");
            Console.ReadKey();
            Console.Clear();
            ShowMenu();
        }
        ShowLogo();

        ShowMenu();

        void ShowTitle(string title)
        {
            int lettersAmount = title.Length;
            string asteristicos = string.Empty.PadLeft(lettersAmount, '*');
            Console.WriteLine(asteristicos);
            Console.WriteLine(title);
            Console.WriteLine(asteristicos + "\n");
        }

        void BandRate ()
        {
            //digite a banda que deseja avaliar.
            //se a banda existir no dicionario >>> atribuir nota.
            //senão, volta ao menu principal.

            Console.Clear ();
            ShowTitle("Avaliar Banda");
            Console.Write("Digite o nome da banda que deseja avaliar: ");
            string bandName = Console.ReadLine()!; //exclamação para não aceitar valor null.
            if (RegistredBands.ContainsKey(bandName)) 
            {
                Console.Write($"Qual a nota que a {bandName} merece: ");               
                int note = int.Parse(Console.ReadLine()!);
                RegistredBands[bandName].Add(note);
                Console.WriteLine($"\nA nota {note}, foi registrada com sucesso para a banda {bandName}");
                Thread.Sleep(4000); //Contará 2 segundos antes de retornar a tela.
                Console.Clear();
                ShowMenu();
            }
            else
            {
                NotFoundBand();
            }

        }

        void ShowAverage()
        {
            Console.Clear();
            ShowTitle("Mostrar  nota média da banda");
            Console.Write("Digite o nome da banda que deseja ver a média :");
            string bandName = Console.ReadLine()!;
            if (RegistredBands.ContainsKey(bandName))
            {
                double showAverage = RegistredBands[bandName].Average();
                Console.Write($"\nA nota média da banda {bandName} é : {showAverage}!");
                Thread.Sleep(5000);
                Console.Clear();
                ShowMenu();
            }
            else
            {
                NotFoundBand();

            }
        }

        void NotFoundBand()
        {
            if (!RegistredBands.ContainsKey(bandName))
            {
                Console.WriteLine($"\n A banda {bandName} não foi encontrada");
                Console.WriteLine("Digite uma tecla para voltar ao menu principal...");
                Console.ReadKey();
                ShowMenu();
            }
        }
    }

}
