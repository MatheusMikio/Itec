public class Cartao
{
    public string CustomerId { get; private set; } = string.Empty;
    public string CardId { get; private set; } = string.Empty;

    public string UltimosQuatroDigitos { get; private set; } = string.Empty;
    public string Bandeira { get; private set; } = string.Empty;

    public int MesExpiracao { get; private set; }
    public int AnoExpiracao { get; private set; }

    public Cartao(
        string ultimosQuatroDigitos,
        string bandeira,
        int mesExpiracao,
        int anoExpiracao,
        string customerId,
        string cardId)
    {
        CustomerId = customerId;
        CardId = cardId;
        UltimosQuatroDigitos = ultimosQuatroDigitos;
        Bandeira = bandeira;
        MesExpiracao = mesExpiracao;
        AnoExpiracao = anoExpiracao;
    }

    protected Cartao() { }
}