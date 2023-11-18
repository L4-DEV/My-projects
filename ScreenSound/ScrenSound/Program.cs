
Genero GeneroRock = new Genero();
GeneroRock.Nome = "Rock";


Album albumDoTDG = new Album();
albumDoTDG.Nome = "One-X";

Musica musica1 = new Musica();
musica1.Nome = "Animal I Have Become";
musica1.Duracao = 290;

Musica musica2 = new Musica();
musica2.Nome = "Riot";
musica2.Duracao = 340;

albumDoTDG.AddMusica(musica1);
albumDoTDG.AddMusica(musica2); 

albumDoTDG.ShowAlbum(); 