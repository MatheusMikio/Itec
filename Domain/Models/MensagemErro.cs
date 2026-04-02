namespace Domain.models
{
    public class MensagemErro(string propriedade, string mensagem)
    {
        public string Propriedade { get; set; } = propriedade;
        public string Mensagem { get; set; } = mensagem;
    }
}