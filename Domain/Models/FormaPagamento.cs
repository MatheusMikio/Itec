using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.models
{
    public class FormaPagamento
    {
        public Cartao Cartao { get; private set; }
        public string ChavePix { get; private set; } = string.Empty;

        public FormaPagamento(Cartao cartao, string chavePix = "")
        {
            Cartao = cartao;
            ChavePix = chavePix;
        }

        protected FormaPagamento()
        {
        }
    }
}