//A combinação de todos esses dados é o resultado da jogada
public class ResultadoJogada //não terá comportamento, só valores
{
    public int Dice1 { get; set; }
    public int Dice2 { get; set; }
    public int PontosNaJogada { get; set; }
    public bool DevePassarAVez { get; set; }
    public bool PerdeTudo { get; set; }
}