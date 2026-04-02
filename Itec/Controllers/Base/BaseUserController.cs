using Domain.Interfaces.Services;
using Domain.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Itec.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public abstract class BaseUserController<TResponseDTO, TRequestDTO, TUpdateDTO, TService> : BaseController<TResponseDTO, TRequestDTO, TUpdateDTO, TService>
        where TResponseDTO : class
        where TRequestDTO : class
        where TUpdateDTO : class
        where TService : ICrudService<TResponseDTO, TRequestDTO, TUpdateDTO>, IBaseUserService<TResponseDTO>
    {
        protected BaseUserController(TService service) : base(service)
        {
        }

        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int size = 12)
        {
            page = page < 1 ? 1 : page;
            size = size < 12 ? 12 : Math.Min(size, 100);

            var result = await _service.GetAll(page, size);

            if (result.Success != true) return StatusCode(result.StatusCode, result.Errors);

            return StatusCode(result.StatusCode, result.Data);
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetMyInfo()
        {
            var publicIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            if (string.IsNullOrEmpty(publicIdClaim) || !Guid.TryParse(publicIdClaim, out Guid publicId)) 
                return Unauthorized(OperationResult.Unauthorized(new MensagemErro("Não autorizado.", "Usuario inválido")));

            var result = await _service.GetMyInfo(publicId);

            if (result.Success != true) return StatusCode(result.StatusCode, result.Errors);

            return StatusCode(result.StatusCode, result.Data);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.GetById(id);

            if (result.Success != true) return StatusCode(result.StatusCode, result.Errors);

            return StatusCode(result.StatusCode, result.Data);
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Policy ="AdminOnly")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _service.Delete(id);

            if (result.Success != true) return StatusCode(result.StatusCode, result.Errors);

            return StatusCode(result.StatusCode);
        }
    }
}