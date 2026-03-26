using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs.Servico
{
    public class ServicoRequest
    {
        public string Nome { get; set; } = string.Empty;
        public decimal MinPreco { get; set; } = decimal.Zero;
        public decimal MaxPreco { get; private set; } = decimal.Zero;
        public string Descricao { get; private set; } = string.Empty;
        public Categorias Categoria { get; private set; } 
        public long TecnicoId { get; private set; } 
    }
}
