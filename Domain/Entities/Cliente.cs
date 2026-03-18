using Domain.entities.baseEntities;
using Domain.Enums;
using Domain.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.entities
{
    public class Cliente : BaseUser
    {
        public string CPF { get; private set; }

        public Cliente(string cpf, string nome, Role role, string senhaHash, FormaPagamento formaPagamento, Contato contato, Endereco endereco)
            : base(nome, role, senhaHash, formaPagamento, contato, endereco)
        {
            CPF = cpf;
        }

        protected Cliente() { }
    }
}