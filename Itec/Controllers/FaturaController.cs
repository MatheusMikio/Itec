using Domain.DTOs.Fatura;
using Domain.Interfaces.Services;
using Itec.Controllers.Base;
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
    }
}
