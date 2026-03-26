using Domain.entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs.Servico
{
    public class ServicoUpdate
    {
        public long Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal MinPreco { get; set; } = decimal.Zero;
        public decimal MaxPreco { get; set; } = decimal.Zero;
        public string Descricao { get; set; } = string.Empty;
        public Categorias Categoria { get; set; }
        public long TecnicoId { get; set; }
    }
}
