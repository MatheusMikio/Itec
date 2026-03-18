using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.models
{
    public class Cartao(string numero, string bandeira, DateTime validade)
    {
        public string Numero { get; private set; } = numero;
        public string Bandeira { get; private set; } = bandeira;
        public DateTime Validade { get; private set; } = validade;
    }
}