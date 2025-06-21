//User Interface - Frontend; Pode alterar a interface sem alterar o programa
UI.ExibeTelaInicial();

// //               Cria o obj do tipo Dice
// Dice meuDado = new Dice(); //Grava ele em uma nova variável do tipo Dice
// int valor = meuDado.Rolar(); //Chama a função rolar fazendo referfência ao Dice que foi criado
// Console.WriteLine(valor);
//Objetivo, extrair a maior quantidade de lógica das ou tras unidades menores, função mais coesa

Jogo jogo = new Jogo(UI.ObtemNomeJogadorHumano());
//                 class jogo.qual é        se for   = true
UI.ExibeJogadorInicial(jogo.JogadorAtual == jogo.Pig, jogo.Humano.Nome);//Descobre qul é o jogador, se fir Pig será true, vai 
Console.WriteLine($"{jogo.Pig.Nome} x {jogo.Humano.Nome}"); //Exibe o nome dos jogadores

int pontuacaoNaRodada = 0;

while (true) //programar as rodadas do jogo, loop principal, cada passada do loop uma rodada
{
    UI.ExibeInicioNovaJogada(
        jogo.JogadorAtual.Nome,
        jogo.JogadorAtual.Placar,
        jogo.PlacarJogadorAdversario(),
        pontuacaoNaRodada
    );

    ResultadoJogada jogada = jogo.JogaRodadaAtual(); //MOVI DE LUGAR, VAI DAR RUM?

    if (jogada.PerdeTudo)
    {
        jogo.JogadorAtual.Zerar();
    }

    if (jogada.DevePassarAVez)
    {
        pontuacaoNaRodada = 0;
    }

    else
    {
        pontuacaoNaRodada += jogada.PontosNaJogada;
    }

    UI.ExibeRolagens(jogada.Dice1, jogada.Dice2);
    UI.ExibeResultadoRolagens(jogada.PerdeTudo, jogada.PontosNaJogada);

    int placarTemporário = jogo.JogadorAtual.Placar + pontuacaoNaRodada;

    if (jogo.JogadorAtualVenceu(placarTemporário))
    {
        jogo.JogadorAtual.Pontuar(pontuacaoNaRodada); //Transforma o placar em definitivo
        UI.ExibePlacarFinal(
            jogo.JogadorAtual.Nome,
            jogo.JogadorAtual.Placar,
            jogo.PlacarJogadorAdversario()
        );

        if (jogo.JogadorAtualEhHumano())
        {
            UI.ExibeVitoriaHumano();
        }
        else
        {
            UI.ExibeVitoriaPig();
        }
        break; //Termina a rodada aqui
    }


    bool jogadorVaiPassarAVez = true; //ajustar
    // lógica de passe 
    if (jogada.DevePassarAVez)
    {
        jogadorVaiPassarAVez = true;
    }
    else
    {
        if (jogo.JogadorAtualEhHumano())//Decisão do usuário
        {
            UI.ExibePlacarCasoPasseAVez(
                placarTemporário,
                jogo.PlacarJogadorAdversario()
            );
            jogadorVaiPassarAVez = UI.ObtemDecisaoPassar(); //se o valor que o usuáriodigitar for "P", vai passar a vez
            
        }
        else //decisão da IA
        {
        
        }
    }

    if (jogadorVaiPassarAVez) //Lógica para passar a vez
    {
        jogo.JogadorAtual.Pontuar(pontuacaoNaRodada);
        UI.ExibeFinalJogada(
            jogo.JogadorAtual.Placar,
            jogo.DiferencaPontos()
        );
        jogo.PassaAVez();
        pontuacaoNaRodada = 0;
    }
    else
    {
        UI.Aguarda();
    }
}

