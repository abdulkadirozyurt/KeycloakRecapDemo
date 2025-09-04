using KeycloakRecapDemo.Application.Auth;
using KeycloakRecapDemo.Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TS.MediatR;

namespace KeycloakRecapDemo.WebAPI.Controllers
{
    [Route("api/auth/")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController(ISender sender) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand request, CancellationToken cancellationToken = default)
        {
            var response = await sender.Send(request, cancellationToken);

            return Ok(response);
        }
    }
}
