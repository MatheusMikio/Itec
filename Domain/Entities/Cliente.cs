using Domain.DTOs.Cliente;
using Domain.entities.baseEntities;

namespace Domain.entities
{
    public class Cliente : BaseUser
    {
        public string CPF { get; private set; }

        public Cliente(ClienteRequest request) : base(request)
        {
            CPF = request.CPF;
        }

        protected Cliente() { }
    }
}