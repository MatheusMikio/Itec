using Domain.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs.Tecnico
{
    public class TecnicoUpdate
    {
        public long Id { get; set; }
        public string CnpjCpf { get; set; } = string.Empty;
        public string Descricao { get; private set; } = string.Empty;
        public IList<HorarioDisponibilidade> Horarios { get; set; } = [];
    }
}
