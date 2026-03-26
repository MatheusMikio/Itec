using Domain.DTOs.Servico;
using Domain.Interfaces.Services;
using Itec.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Itec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : BaseController<ServicoResponse, IServicoService>
    {
        public ServicoController(IServicoService service) : base(service)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ServicoRequest request)
        {
            OperationResult result = await _service.Create(request);

            if (result.Success != true) return StatusCode(result.StatusCode, result.Errors);

            return StatusCode(result.StatusCode);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ServicoUpdate request)
        {
            OperationResult result = await _service.Update(request);

            if (result.Success != true) return StatusCode(result.StatusCode, result.Errors);

            return StatusCode(result.StatusCode);
        }
    }
}
