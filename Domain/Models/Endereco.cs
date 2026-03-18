using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.models
{
    public class Endereco(string rua, string numero, string bairro, string estado, string pais)
    {
        public string Rua { get; private set; } = rua;
        public string Numero { get; private set; } = numero;
        public string Bairro { get; private set; } = bairro;
        public string Estado { get; private set; } = estado;
        public string Pais { get; private set; } = pais;
    }
}