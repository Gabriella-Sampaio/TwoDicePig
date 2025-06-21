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
    public int PlacarJogadorAdversario()
    {
        //            o jog atual é hum   ?   se true  :   se false
        return JogadorAtual == Humano ? Pig.Placar : Humano.Placar;
    }

    public ResultadoJogada JogaRodadaAtual() //usa todos os dados da class ResultadoJogada
    {
        //Rola dois dados
        int rolagem1 = JogadorAtual.Rolar(); //chama a função pra rolar os dados e grava na var
        int rolagem2 = JogadorAtual.Rolar();

        ResultadoJogada resultado = new ResultadoJogada
        {
            Dice1 = rolagem1, //Dado 1 é o resultado da prim rolagem
            Dice2 = rolagem2,

            DevePassarAVez = rolagem1 == 1 || rolagem2 == 1, //Se um dos dados for 1, passa a vez
            PerdeTudo = rolagem1 == 1 && rolagem2 == 1, //Se os dois dados forem 1, perde tudo
        };

        if (resultado.DevePassarAVez)
        {
            resultado.PontosNaJogada = 0;
        }
        else
        {
            resultado.PontosNaJogada = resultado.Dice1 + resultado.Dice2;
        }
        return resultado;
    }
    public bool JogadorAtualVenceu(int placarQueTeraSePassaAVez)
    {
        return placarQueTeraSePassaAVez >= 100;
    }
    public bool JogadorAtualEhHumano()
    {
        return JogadorAtual == Humano;
    }
    public int DiferencaPontos()
    {
        return JogadorAtual.Placar - PlacarJogadorAdversario();
    }
    public void PassaAVez()
    {
        JogadorAtual = JogadorAtual == Humano ? Pig : Humano;
    }


}