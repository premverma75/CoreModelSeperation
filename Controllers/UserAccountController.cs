using CoreModelSeperation.DataTransferObjects;
using CoreModelSeperation.Domain;
using CoreModelSeperation.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CoreModelSeperation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserAccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            Log.Information("This is an Information log");
            Log.Warning("This is a Warning log");
            Log.Error("This is an Error log");

            return Ok("Serilog working");
        }

        [HttpGet]
        [Route("GetUserName/{userId}")]
        public async Task<IActionResult> GetUserName(Guid userId)
        {
            var userName = await _userService.GetUserNameAsync(userId);
            if (userName == null)
            {
                return NotFound();
            }
            return Ok(userName);
        }

        [HttpPost]
        [Route("AddUpdateUser")]
        [HttpPost]
        public IActionResult Create([FromBody] CreateUserRequestDto createUserRequestDto)
        {
            if (createUserRequestDto == null)
            {
                return BadRequest("Invalid user data.");
            }
            else
            {
                var result = _userService.AddUpdateUser(createUserRequestDto);
                return Ok(result);
            }
        }

        [HttpGet]
        [Route("GetUserDetails/{userId}")]
        public async Task<IActionResult> GetUserDetails(Guid userId)
        {
            var user = _userService.GetUserDetails(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpDelete]
        [Route("DeleteUser/{userId}")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            bool result = await _userService.DeleteUser(userId);
            if (result == false)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }
    }
}