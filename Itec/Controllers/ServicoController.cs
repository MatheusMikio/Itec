using Domain.DTOs.Servico;
using Domain.Interfaces.Services;
using Itec.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Itec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : BaseController<ServicoResponse, ServicoRequest, ServicoUpdate, IServicoService>
    {
        public ServicoController(IServicoService service) : base(service)
        {
        }
    }
}
