using Domain.DTOs.Cliente;
using Domain.Interfaces.Services;
using Itec.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Itec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : BaseUserController<ClienteResponse, IClienteService>
    {
        public ClienteController(IClienteService service) : base(service)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClienteRequest request)
        {
            OperationResult result = await _service.Create(request);

            if (result.Success != true) return StatusCode(result.StatusCode, result.Errors);

            return StatusCode(result.StatusCode);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ClienteUpdate request)
        {
            OperationResult result = await _service.Update(request);

            if (result.Success != true) return StatusCode(result.StatusCode, result.Errors);

            return StatusCode(result.StatusCode);
        }
    }
}