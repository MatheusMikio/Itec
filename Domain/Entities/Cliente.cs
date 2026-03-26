using Domain.DTOs.Cliente;
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

        public Cliente(ClienteRequest request) : base(request)
        {
            CPF = request.CPF;
        }

        protected Cliente() { }
    }
}