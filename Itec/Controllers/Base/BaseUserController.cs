using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Itec.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseUserController<TResponseDTO, TService> : BaseController<TResponseDTO, TService>
        where TResponseDTO : class
        where TService : IBaseService<TResponseDTO>, IBaseUserService<TResponseDTO>
    {
        protected BaseUserController(TService service) : base(service)
        {
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.GetById(id);

            if (result.Success != true) return StatusCode(result.StatusCode, result.Errors);

            return StatusCode(result.StatusCode, result.Data);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _service.Delete(id);

            if (result.Success != true) return StatusCode(result.StatusCode, result.Errors);

            return StatusCode(result.StatusCode);
        }
    }
}