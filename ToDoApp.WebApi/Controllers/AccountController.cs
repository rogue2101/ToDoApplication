using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using ToDoApp.WebApi.DAL.Identity;
using ToDoApp.WebApi.Services.Implementations;
using ToDoApp.WebApi.Services.Interfaces;

namespace ToDoApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public AccountController(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(string username, string password)
        {
            var result = await _userService.RegisterUserAsync(username, password);
            ApplicationUser applicationUser = new ApplicationUser();
            applicationUser.UserName = username;
            if (result.Succeeded)
            {
                var authenticationResponse =  _jwtService.CreateJwtToken(applicationUser);
                return Ok(authenticationResponse);
            }
            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(string username, string password)
        {
            var result = await _userService.SignInUserAsync(username, password);
            ApplicationUser applicationUser = new ApplicationUser();
            applicationUser.UserName = username;
            if (result.Succeeded)
            {
                var authenticationResponse = _jwtService.CreateJwtToken(applicationUser);
                return Ok(authenticationResponse);
            }
            return Unauthorized("Invalid login attempt");
        }
    }
}
