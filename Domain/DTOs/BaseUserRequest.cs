using Domain.Enums;
using Domain.models;

namespace Domain.DTOs
{
    public class BaseUserRequest()
    {
        public string Nome { get;  set; } = string.Empty;
        public Role Role { get;  set; }
        public string SenhaHash { get;  set; } = string.Empty;
        public FormaPagamento FormaPagamento { get; set; }
        public Contato Contato { get;  set; }
        public Endereco Endereco { get;  set; }
    }
}