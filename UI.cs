public class UI //User Interface - Frontend; Pode alterar a interface sem alterar o programa
{
    public static void ExibeTelaInicial()
    {
        Console.ResetColor();
        Console.Clear();
        Console.WriteLine("-- Bem vindo");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(@"
              _
         <`--'\>______
         /. .  `'     \
        (`')           @
         `-._,        /
            )-)_/--( >  
           ''''  ''''
        
        ");
        Console.ResetColor();


    }
}