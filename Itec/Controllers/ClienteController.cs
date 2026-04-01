using Domain.DTOs.Cliente;
using Domain.Interfaces.Services;
using Itec.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Itec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : BaseUserController<ClienteResponse, ClienteRequest, ClienteUpdate, IClienteService>
    {
        public ClienteController(IClienteService service) : base(service)
        {
        }
    }
}