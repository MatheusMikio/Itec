using Domain.entities.baseEntities;
using Domain.Enums;
using Domain.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.entities
{
    public class Tecnico : BaseUser
    {
        public string CpfCnpj { get; private set; }
        public string Descricao { get; private set; }
        public IList<Servico> Servicos { get; private set; } = new List<Servico>();


        public Tecnico(string cpfCnpj, string descricao, string nome, Role role, string senhaHash, FormaPagamento formaPagamento, Contato contato, Endereco endereco)
            : base(nome, role, senhaHash, formaPagamento, contato, endereco)
        {
            CpfCnpj = cpfCnpj;
            Descricao = descricao;
        }

        protected Tecnico() { }
    }
}