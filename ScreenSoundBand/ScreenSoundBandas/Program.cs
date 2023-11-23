using ScreenSound.Modelos;
using System.Diagnostics;


class Program
{
    static void Main(string[] args)
    {
        
        var message = "Welcome!!!";

        Band audioSlave = new Band("AudioSlave");
        audioSlave.AddNote(10);
        audioSlave.AddNote(8);
        audioSlave.AddNote(6);

        Band nickelback = new Band("Nickelback");

        Dictionary<string, Band> RegistredBands = new ();
        RegistredBands.Add(audioSlave.Name, audioSlave);
        RegistredBands.Add(nickelback.Name, nickelback );
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
            string opcao = Console.ReadLine()!;
            int opcaoNum = int.Parse(opcao);

            switch (opcaoNum)
            {

                case 1:
                    BandRegister();
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


        void AlbumRegister()
        {
            Console.Clear();
            ShowTitle("Registro de álbuns");
            Console.WriteLine("Dite a banda cujo álbum deseja registrar: ");
            string bandName = Console.ReadLine();

            if(RegistredBands.ContainsKey(bandName))
            {
                Console.WriteLine("Agora digite o título do álbum: ");
                string albumTitle = Console.ReadLine()!;
                Band band = RegistredBands[bandName];
                band.AddAlbum(new Album(albumTitle));
                Console.WriteLine($"O álbum {albumTitle} de {bandName} foi registrado com sucesso!");
                Thread.Sleep(4000);
                Console.Clear();
            }


        }


        void BandRegister()
        {
            Console.Clear();
            ShowTitle("Registro das bandas");
            Console.Write("Digite o nome da banda que deseja registrar: ");
            string nameBand = Console.ReadLine()!;
            Band band = new Band(nameBand);
            RegistredBands.Add(nameBand, band);
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
            int lettersAmount = title.Length; //indentifica a quantidade de caracteres ' Length ' .
            string asteristicos = string.Empty.PadLeft(lettersAmount, '*'); //selecionando uma variável vazia e utilizando PadLeft,insere a esquerda  o caractere especificado, o numero de vezes que esta na variável lettersAmount definida pelo length...
            Console.WriteLine(asteristicos);
            Console.WriteLine(title);
            Console.WriteLine(asteristicos + "\n");
        }

        void BandRate()
        {
            //digite a banda que deseja avaliar.
            //se a banda existir no dicionario >>> atribuir nota.
            //senão, volta ao menu principal.

            Console.Clear();
            ShowTitle("Avaliar Banda");
            Console.Write("Digite o nome da banda que deseja avaliar: ");
            string bandName = Console.ReadLine()!; //exclamação para não aceitar valor null.
            if (RegistredBands.ContainsKey(bandName))
            {
                Band band = RegistredBands[bandName];
                Console.Write($"Qual a nota que a {bandName} merece: ");
                int note = int.Parse(Console.ReadLine()!);
                band.AddNote(note);
                Console.WriteLine($"\nA nota {note}, foi registrada com sucesso para a banda {bandName}");
                Thread.Sleep(4000); //Contará 4 segundos antes de retornar a tela.
                Console.Clear();
                ShowMenu();
            }
            else
            {
                Console.WriteLine($"\n A banda {bandName} não foi encontrada");
                Console.WriteLine("Digite uma tecla para voltar ao menu principal...");
                Console.ReadKey();
                Console.Clear();
                ShowMenu();
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
                Band band = RegistredBands[bandName];
                Console.Write($"\nA nota média da banda {bandName} é : {band.NoteAverage}!");
                Thread.Sleep(5000);
                Console.Clear();
                ShowMenu();
            }
            else
            {
                if (!RegistredBands.ContainsKey(bandName))
                {
                    Console.WriteLine($"\n A banda {bandName} não foi encontrada");
                    Console.WriteLine("Digite uma tecla para voltar ao menu principal...");
                    Console.ReadKey();
                    ShowMenu();
                }

            }
            ShowMenu();
        }
    
    }

}
