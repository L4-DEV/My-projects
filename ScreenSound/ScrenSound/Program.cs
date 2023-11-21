
Banda tdg = new Banda("Three Days Grace");

Album albumDoTDG = new Album("One-X");

Musica musica1 = new Musica(tdg, "Animal I Have Become")
{
    Duracao = 290,
    Disponivel = true,
};


Musica musica2 = new Musica(tdg, "Riot")
{
    Duracao = 340,
    Disponivel = false,
};

albumDoTDG.AddMusica(musica1);
albumDoTDG.AddMusica(musica2);
tdg.AddAlbum(albumDoTDG);


musica1.ShowData();
musica2.ShowData();
albumDoTDG.ShowAlbum();
tdg.ExibirDiscografia();