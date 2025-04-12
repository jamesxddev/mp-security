using Microsoft.AspNetCore.Mvc;
using mp.security.Dtos.Auth;
using mp.security.Services.Interfaces;

namespace mp.security.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = await authService.RegisterAsync(request);
            if (result != null)
            {
                return BadRequest(result);
            }
            return Ok(new { message = "User registered successfully" });
        }
    }
}
