public class Dice
{
    private Random _gerador; // _ quando a var é interna, só a própria classe pode ver
    public Dice() // construtor 
    {
        _gerador = new Random();
    }
    public int Rolar()
    {
        return _gerador.Next(1, 7); //Sorteia nm de 1 a 6
    }


}
