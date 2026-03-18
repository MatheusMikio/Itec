using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.models
{
    public class Contato(string telefone, string email)
    {
        public string Telefone { get; private set; } = telefone;
        public string Email { get; private set; } = email;
    }
}