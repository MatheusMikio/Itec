using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.models
{
    public class FormaPagamento(Cartao cartao, string chavePix = "")
    {
        public Cartao Cartao { get; private set; } = cartao;
        public string ChavePix { get; private set; } = chavePix;
    }
}