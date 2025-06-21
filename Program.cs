//User Interface - Frontend; Pode alterar a interface sem alterar o programa
UI.ExibeTelaInicial();

// //               Cria o obj do tipo Dice
// Dice meuDado = new Dice(); //Grava ele em uma nova variável do tipo Dice
// int valor = meuDado.Rolar(); //Chama a função rolar fazendo referfência ao Dice que foi criado
// Console.WriteLine(valor);


Jogo jogo = new Jogo(UI.ObtemNomeJogadorHumano());
//                 class jogo.qual é        se for   = true
UI.ExibeJogadorInicial(jogo.JogadorAtual == jogo.Pig, jogo.Humano.Nome);//Descobre qul é o jogador, se fir Pig será true, vai 
Console.WriteLine($"{jogo.Pig.Nome} x {jogo.Humano.Nome}"); //Exibe o nome dos jogadores

while (true) //programar as rodadas do jogo, loop principal, cada passada do loop, uma rodada
{

    
    break; //finaliza jogo
}