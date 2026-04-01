using Domain.DTOs.Tecnico;
using Domain.Interfaces.Services;
using Itec.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Itec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TecnicoController : BaseUserController<TecnicoResponse, TecnicoRequest, TecnicoUpdate, ITecnicoService>
    {
        public TecnicoController(ITecnicoService service) : base(service)
        {
        }
    }
}