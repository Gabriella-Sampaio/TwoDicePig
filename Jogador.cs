public class Jogador
{
    public string Nome { get; private set; } //Propriedade; Privada pq n pode mudar
    public int Placar { get; set; } //Propriedade
    private Dice _dice = new Dice(); //Cria uma var do tipo Dice; cada jogador tem um dado
    public Jogador(string nome) //Subrotina cm o msm nome da classe, que roda quando a classe iniciar
    {
        //Agora colocar um nome dentro dos parentes é obrigatório para criar um jogador
        Nome = nome;
        Zerar();
    }
    public void Pontuar(int pontos)
    {
        Placar += pontos;
    }
    public void Zerar()
    {
        Placar = 0;
    }
    public int Rolar() //Rolagem do jogador
    {
        return _dice.Rolar(); //vai retornar a rolagem do dado, o q já foi programado
    }
}