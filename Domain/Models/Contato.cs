namespace Domain.models
{
    public class Contato
    {
        public string Telefone { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;

        public Contato(string telefone, string email)
        {
            Telefone = telefone;
            Email = email;
        }

        protected Contato()
        {
        }
    }
}