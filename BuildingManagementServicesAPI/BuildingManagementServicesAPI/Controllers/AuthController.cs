using BusinessLayer.Abstract;
using BusinessLayer.Model.DTOs.UserDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Building_Management_Services_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService) { 
            _authService = authService; 
        }
        [HttpPost("login")]
        public IActionResult Login(UserLoginDto userdto) {
            var token = _authService.Login(userdto);
            return Ok(token);

        }
    }
}
