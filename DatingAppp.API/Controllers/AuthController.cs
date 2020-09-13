using System.Threading.Tasks;
using DatingAppp.API.Data;
using DatingAppp.API.Dtos;
using DatingAppp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingAppp.API.Controllers
{
    [Route("api/[controller]")]
   // [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;

        }
        [HttpPost("register")]

        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            //validate request
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if(await _repo.UserExists(userForRegisterDto.Username))
            return BadRequest("Username already exists");
            
            var userToCreate = new User
            {
                Username = userForRegisterDto.Username
            };
            
            var createdUser = await _repo.Register(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);
        }
    }
}