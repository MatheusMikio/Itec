using Domain.DTOs.Servico;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IServicoService : ICrudService<ServicoResponse, ServicoRequest, ServicoUpdate>
    {
    }
}
