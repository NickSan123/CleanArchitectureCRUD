using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

       public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("/User/all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userRepository.GetAllAsync());
        }
        [HttpGet("/User/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) 
                return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if(user == null)
                return BadRequest();
            return Ok(await _userRepository.CreateAsync(user));
        }

        [HttpPatch]
        public async Task<IActionResult> CreateOrUpdate(User user)
        {
            var user1 = await _userRepository.GetByIdAsync(user.Id);
            if (user1 == null)
                return Ok(await _userRepository.CreateAsync(user));
            return Ok(await _userRepository.UpdateAsync(user));
        }
    }
}
