using Domain.DTOs.Agendamento;
using Domain.Interfaces.Services;
using Itec.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Itec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : BaseController<AgendamentoResponse, AgendamentoRequest, AgendamentoUpdate, IAgendamentoService>
    {
        public AgendamentoController(IAgendamentoService service) : base(service)
        {
        }
    }
}
