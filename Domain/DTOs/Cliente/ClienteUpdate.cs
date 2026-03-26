using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs.Cliente
{
    public class ClienteUpdate : BaseUserRequest
    {
        public long Id { get; set; }
        public string CPF { get; set; } = string.Empty;
    }
}
