using Microsoft.AspNetCore.Mvc;
using PromoAPI.Data.Repository.Interface;
using PromoAPI.Data.Request;
using PromoAPI.Data.Response;
using PromoAPI.Models;

namespace PromoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository user)
        {
            _userRepository = user;
        }

        [HttpGet(Name = "GetLogin")]
        public IActionResult Login(string cpf, string password)
        {            
            var userResponse=_userRepository.login(cpf, password);
            if (userResponse.Id > 0)
            {
                return Ok(userResponse);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public IActionResult Create([FromBody] UserRequest userRequest)
        {            
          
            var userResponse = _userRepository.Create(userRequest);
            if (userResponse.Id>0)
            {
                return Ok(userResponse);
            }
            else
            {
                return NotFound(userResponse);
            }

        }
    }
}
