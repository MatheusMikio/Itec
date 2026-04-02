using Application.Services;
using Domain.DTOs.Tecnico;
using Domain.Interfaces.Services;
using Itec.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Itec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "TecnicoOrAdmin")]
    public class TecnicoController : BaseUserController<TecnicoResponse, TecnicoRequest, TecnicoUpdate, ITecnicoService>
    {
        private readonly ITecnicoService _tecnicoService;
        public TecnicoController(ITecnicoService service) : base(service)
        {
            _tecnicoService = service;
        }

        [HttpGet("public")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllPublic([FromQuery] int page = 1, [FromQuery] int size = 12)
        {
            page = page < 1 ? 1 : page;
            size = size < 12 ? 12 : Math.Min(size, 100);

            var result = await _tecnicoService.GetAllPublic(page, size);

            if (result.Success != true) return StatusCode(result.StatusCode, result.Errors);

            return StatusCode(result.StatusCode, result.Data);
        }
    }
}