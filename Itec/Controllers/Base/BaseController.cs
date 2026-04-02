using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Itec.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TResponseDTO, TRequestDTO, TUpdateDTO, TService> : ControllerBase
        where TResponseDTO : class
        where TRequestDTO : class
        where TUpdateDTO : class
        where TService : ICrudService<TResponseDTO, TRequestDTO, TUpdateDTO>
    {
        protected readonly TService _service;

        public BaseController(TService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int size = 12)
        {
            var result = await _service.GetAll(page, size);

            if (result.Success != true) return StatusCode(result.StatusCode, result.Errors);

            return StatusCode(result.StatusCode, result.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _service.GetById(id);

            if (result.Success != true) return StatusCode(result.StatusCode, result.Errors);

            return StatusCode(result.StatusCode, result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TRequestDTO request)
        {
            var result = await _service.Create(request);

            if (result.Success != true) return StatusCode(result.StatusCode, result.Errors);

            return StatusCode(result.StatusCode);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TUpdateDTO request)
        {
            var result = await _service.Update(request);

            if (result.Success != true) return StatusCode(result.StatusCode, result.Errors);

            return StatusCode(result.StatusCode);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _service.Delete(id);

            if (result.Success != true) return StatusCode(result.StatusCode, result.Errors);

            return StatusCode(result.StatusCode);
        }
    }
}