using managementFile.BLL.Auths;
using managementFile.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace managementFile.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthsController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]

        public async Task<IActionResult> Login(UserDTO request)
        {
            var token = await _authService.Login(request);

            if (token != "")
            {
                return Ok(new { token });
            }
            return Unauthorized();
        }
    }
}
