using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Repository_Interface;
using Portfolio.Services;

namespace Portfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthentication authentication;
        private readonly TokenService tokenService;

        private readonly IConfiguration configuration;

        public AuthenticationController(
            IAuthentication authentication,
            TokenService tokenService,

            IConfiguration configuration)
        {
            this.authentication = authentication;
            this.tokenService = tokenService;

            this.configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest user)
        {
            try
            {
                var validUser = await authentication.Login(user.UserName, user.Password);
                if (validUser == null)
                    return Unauthorized("Invalid credentials");

                var token = tokenService.GenerateToken(user.UserName);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserRequest userRequest)
        {
            try
            {
                var user = new User
                {

                    UserName = userRequest.UserName,
                    Email = userRequest.Email,
                    Password = userRequest.Password, // Assume you have a HashPassword method
                    Phone = userRequest.Phone // Uncomment if you want to store phone numbers
                };

                var res = await authentication.Add(user);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
