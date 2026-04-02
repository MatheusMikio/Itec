using Domain.DTOs;
using Domain.Enums;
using Domain.models;

namespace Domain.entities.baseEntities
{
    public abstract class BaseUser : BaseModel
    {

        public string Nome { get; private set; }
        public Guid PublicId { get; private set; } = Guid.NewGuid();
        public Role Role { get; private set; }
        public string SenhaHash { get; private set; }
        public FormaPagamento FormaPagamento { get; private set; }
        public Contato Contato { get; private set; }
        public Endereco Endereco { get; private set; }
        public IList<Agendamento> HistoricoAgendamento { get; private set; } = [];
        public bool Ativo { get; private set; } = true;
        public string RefreshToken { get; private set; }
        public DateTime TokenIssuedAt { get; private set; }
        
        protected BaseUser(BaseUserRequest request)
        {
            Nome = request.Nome;
            Role = request.Role;
            SenhaHash = request.SenhaHash;
            FormaPagamento = request.FormaPagamento;
            Contato = request.Contato;
            Endereco = request.Endereco;
        }

        protected BaseUser() { }

        public void SetRefreshToken(string refreshToken)
        {
            RefreshToken = refreshToken;
            TokenIssuedAt = DateTime.UtcNow;
        }

        public void ClearRefreshToken()
        {
            RefreshToken = string.Empty;
            TokenIssuedAt = DateTime.MinValue;
        }

        public bool IsRefreshTokenValid(string refreshToken)
        {
            if (string.IsNullOrEmpty(RefreshToken)) return false;
            if (RefreshToken != refreshToken) return false;
            
            var expirationDate = TokenIssuedAt.AddDays(7);
            return DateTime.UtcNow < expirationDate;
        }
    }
}