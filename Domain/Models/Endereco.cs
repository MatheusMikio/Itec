using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.models
{
    public class Endereco
    {
        public string Rua { get; private set; } = string.Empty;
        public string Numero { get; private set; } = string.Empty;
        public string Bairro { get; private set; } = string.Empty;
        public string Estado { get; private set; } = string.Empty;
        public string Pais { get; private set; } = string.Empty;

        public Endereco(string rua, string numero, string bairro, string estado, string pais)
        {
            Rua = rua;
            Numero = numero;
            Bairro = bairro;
            Estado = estado;
            Pais = pais;
        }

        protected Endereco()
        {
        }
    }
}