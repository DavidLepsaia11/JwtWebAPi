using JwtWebAPi.DTOs;
using JwtWebAPi.Interfaces.Service;
using JwtWebAPi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtWebAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IRegisterService _registerService;
        private ILoginService _loginService;
        public static User user = new User();

        public AuthController( IRegisterService registerService, ILoginService loginService)
        {
            _registerService = registerService;
            _loginService = loginService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            if (user.Username != request.Username)
            {
              return BadRequest("User not found");
            }
            if (!_loginService.VerifyPasswordHash(request.Password, user.PasswordHash , user.passwordSalt))
            {
                return BadRequest("Invalid Password");
            }
            var token = _loginService.CreateToken(user);

            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            _registerService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.Username = request.Username;
            user.PasswordHash = passwordHash;
            user.passwordSalt = passwordSalt;
            
            return Ok(user);    
        }
    }
}
