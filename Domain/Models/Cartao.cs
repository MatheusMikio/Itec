using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.models
{
    public class Cartao
    {
        public string Numero { get; private set; } = string.Empty;
        public string Bandeira { get; private set; } = string.Empty;
        public DateTime Validade { get; private set; }

        public Cartao(string numero, string bandeira, DateTime validade)
        {
            Numero = numero;
            Bandeira = bandeira;
            Validade = validade;
        }

        protected Cartao()
        {
        }
    }
}