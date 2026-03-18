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

        public Servico(string nome, decimal minPreco, decimal maxPreco, string descricao, long tecnicoId, Categorias categoria)
        {
            Nome = nome;
            MinPreco = minPreco;
            MaxPreco = maxPreco;
            Descricao = descricao;
            TecnicoId = tecnicoId;
            Categoria = categoria;
        }

        protected Servico() { }
    }
}