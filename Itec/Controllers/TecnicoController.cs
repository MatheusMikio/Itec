using Domain.DTOs.Tecnico;
using Domain.Interfaces.Services;
using Itec.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Itec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TecnicoController : BaseUserController<TecnicoResponse, ITecnicoService>
    {
        public TecnicoController(ITecnicoService service) : base(service)
        {
        }

        public async Task<IActionResult> Create([FromBody] TecnicoRequest request)
        {
            OperationResult result = await _service.Create(request);

            if (result.Success != true) return StatusCode(result.StatusCode, result.Errors);

            return StatusCode(result.StatusCode);
        }

        public async Task<IActionResult> Update([FromBody] TecnicoUpdate request)
        {
            OperationResult result = await _service.Update(request);

            if (result.Success != true) return StatusCode(result.StatusCode, result.Errors);

            return StatusCode(result.StatusCode);
        }
    }
}