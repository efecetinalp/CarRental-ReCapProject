using Business.Abstract;
using Core.Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var result = _authService.Login(userForLoginDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            var getToken = _authService.CreateAccessToken(result.Data);
            if (getToken.Success)
            {
                return Ok(getToken);
            }
            return BadRequest(getToken);
        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var result = _authService.UserExists(userForRegisterDto.Email);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            var register = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var getToken = _authService.CreateAccessToken(register.Data);
            if (getToken.Success)
            {
                return Ok(getToken);
            }
            return BadRequest(getToken);
        }
    }
}
