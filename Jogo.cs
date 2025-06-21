//Abstração do jogo
using System.Threading.Tasks.Dataflow;

public class Jogo
{
    public Jogador Humano { get; private set; } //duas propriedades do tipo jogador; Private pq n pode ser mudado
    public Jogador Pig { get; private set; }
    public Jogador JogadorAtual { get; private set; }
    public Jogo(string nomeJogadorHumano) //Subrotina cm o msm nome da classe, que roda quando a classe iniciar
    {
        Pig = new Jogador("Pig");
        Humano = new Jogador(nomeJogadorHumano);
        JogadorAtual = SorteiaJogadorInicial();
    }
    private Jogador SorteiaJogadorInicial()
    {
        //Rola um dado para cada jogdor
        int resultadoHumano = Humano.Rolar();
        int resultadoPig = Pig.Rolar();

        //Enquanto forem iguais, repete
        while (resultadoHumano == resultadoPig)
        {
            resultadoHumano = Humano.Rolar();
            resultadoPig = Pig.Rolar();
        }

        //O maior dado é do jogador inicial
        if (resultadoPig > resultadoHumano)
        {
            return Pig;
        }
        return Humano;
        //Também daria para sortear dois numeros, 1 e 2, e se fosse 1 seria Pig, e etc
    }
}