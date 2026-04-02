using Domain.DTOs.Auth;
using Domain.DTOs.Cliente;
using Domain.DTOs.Tecnico;
using Domain.Enums;
using Domain.Interfaces.Services;
using Domain.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Itec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            OperationResult<object> result = await _authService.Login(request);
            
            if (result.Success) return StatusCode(result.StatusCode, result.Data);

            return StatusCode(result.StatusCode, result.Errors);
        }

        [HttpPost("refresh")]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            var result = await _authService.RefreshToken(request);
            
            if (result.Success) return StatusCode(result.StatusCode, result.Data);

            return StatusCode(result.StatusCode, result.Errors);
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            var publicIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            if (string.IsNullOrEmpty(publicIdClaim) || !Guid.TryParse(publicIdClaim, out Guid publicId)) 
                return Unauthorized(OperationResult.Unauthorized(new MensagemErro("Logout", "Token inválido")));

            var result = await _authService.Logout(publicId);

            if (result.Success) return Ok(OperationResult.Ok());

            return StatusCode(result.StatusCode, result.Errors);
        }
    }
}
