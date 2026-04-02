namespace Domain.DTOs.Cliente
{
    public class ClienteRequest : BaseUserRequest
    {
        public string CPF { get; set; } = string.Empty;
    }
}