namespace AluraFlix.Business.Notificacoes
{
    public class Notificacao
    {
        public Notificacao(string menssagem)
        {
            Menssagem = menssagem;
        }

        public string Menssagem { get; }
    }
}