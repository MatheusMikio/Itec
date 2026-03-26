using Domain.DTOs.Agendamento;
using Domain.Interfaces.Services;
using Itec.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Itec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : BaseController<AgendamentoResponse, IAgendamentoService>
    {
        public AgendamentoController(IAgendamentoService service) : base(service)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AgendamentoRequest request)
        {
            OperationResult result = await _service.Create(request);

            if (result.Success != true) return StatusCode(result.StatusCode, result.Errors);

            return StatusCode(result.StatusCode);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AgendamentoUpdate request)
        {
            OperationResult result = await _service.Update(request);

            if (result.Success != true) return StatusCode(result.StatusCode, result.Errors);

            return StatusCode(result.StatusCode);
        }
    }
}
