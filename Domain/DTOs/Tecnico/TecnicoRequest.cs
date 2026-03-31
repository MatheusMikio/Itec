using Domain.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs.Tecnico
{
    public class TecnicoRequest : BaseUserRequest
    {
        public IList<HorarioDisponibilidade> Horarios { get; private set; } = [];
        public string CnpjCpf { get; set; } = string.Empty;
        public string Descricao { get; private set; } = string.Empty;
    }
}
