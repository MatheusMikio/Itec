using Domain.DTOs.Tecnico;
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
        public string CpfCnpj { get; private set; } = string.Empty;
        public string Descricao { get; private set; } = string.Empty;
        public IList<Servico> Servicos { get; private set; } = new List<Servico>();


        public Tecnico(TecnicoRequest request) : base(request)
        {
            CpfCnpj = request.CnpjCpf;
            Descricao = request.Descricao;
        }

        protected Tecnico() { }
    }
}