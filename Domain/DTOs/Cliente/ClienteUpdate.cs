namespace Domain.DTOs.Cliente
{
    public class ClienteUpdate : BaseUserRequest
    {
        public long Id { get; set; }
        public string CPF { get; set; } = string.Empty;
    }
}