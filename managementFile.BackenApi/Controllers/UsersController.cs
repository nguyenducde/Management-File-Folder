using managementFile.BLL.Users;
using managementFile.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace managementFile.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("get-users")]

        public async Task< IActionResult> GetUsers()
        {
            var data = await _userService.GetUsers();
            return Ok(new { data });

        } 
        
        [HttpGet("get-user-by-id")]

        public IActionResult GetUserById([FromQuery]UserDTO request)
        {
            var data = _userService.GetUserById(request);
            return Ok(data);

        }

        [AllowAnonymous]
        [HttpPost("insert")]

        public IActionResult Insert(UserDTO request)
        {
           var isSuccess = _userService.Insert(request);
            return isSuccess ? Ok("Success") : BadRequest("Fail");
        } 
        
        [HttpPut("update")]

        public async Task<IActionResult> Update(UserDTO request)
        {
           var isSuccess = await _userService.Update(request);
            return isSuccess ? Ok("Success") : BadRequest("Fail");
        }
        
        [HttpDelete("delete")]

        public async Task<IActionResult> Delete(UserDTO request)
        {
           var isSuccess = await _userService.Delete(request);
           return isSuccess ? Ok("Success") : BadRequest("Fail");
        }
    }
}
