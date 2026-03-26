using Domain.DTOs.Servico;
using Domain.entities.baseEntities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.entities
{
    public class Servico : BaseModel
    {
        public string Nome { get; private set; }
        public decimal MinPreco { get; private set; }
        public decimal MaxPreco { get; private set; }
        public string Descricao { get; private set; }
        public Categorias Categoria { get; private set; }
        public long TecnicoId { get; private set; }
        public Tecnico Tecnico { get; set; }

        public Servico(ServicoRequest request)
        {
            Nome = request.Nome;
            MinPreco = request.MinPreco;
            MaxPreco = request.MaxPreco;
            Descricao = request.Descricao;
            TecnicoId = request.TecnicoId;
            Categoria = request.Categoria;
        }

        protected Servico() { }
    }
}