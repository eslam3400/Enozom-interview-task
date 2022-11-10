using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using TaskModels.DTOs.User;
using TaskModels;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using TaskServices.Interfacs;

namespace Task.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        public AuthController(IAuthService authService) { this.authService = authService; }
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody]UserLoginDTO _user)
        {
            var token = authService.Login(_user);
            if (token == null) return NotFound();
            return Ok(token);
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody]UserRegisterDTO _user)
        {
            authService.Register(_user);
            return Ok();
        }
    }
}
