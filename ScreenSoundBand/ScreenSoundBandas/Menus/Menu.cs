namespace ScreenSound.Menus;
internal class Menu
{
   public  void ShowTitle(string title)
   {
        int lettersAmount = title.Length; //indentifica a quantidade de caracteres ' Length ' .
        string asteristicos = string.Empty.PadLeft(lettersAmount, '*'); //selecionando uma variável vazia e utilizando PadLeft,insere a esquerda  o caractere especificado, o numero de vezes que esta na variável lettersAmount definida pelo length...
        Console.WriteLine(asteristicos);
        Console.WriteLine(title);
        Console.WriteLine(asteristicos + "\n");
   }

    public virtual void Execute (Dictionary<string, Band> registredBands)
    {
        Console.Clear();
    }

}
