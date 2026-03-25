using Domain.DTOs.Fatura;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Itec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaturaController : BaseController<FaturaResponse, IFaturaService>
    {
        public FaturaController(IFaturaService service) : base(service)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FaturaRequest request)
        {
            OperationResult result = await _service.Create(request);

            if (result.Success != true) return StatusCode(result.StatusCode, result.Errors);

            return StatusCode(result.StatusCode);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] FaturaUpdate request)
        {
            OperationResult result = await _service.Update(request);

            if (result.Success != true) return StatusCode(result.StatusCode, result.Errors);

            return StatusCode(result.StatusCode);
        }
    }
}
