using LibraryApi.Application.Interfaces;
using LibraryApi.Data;
using LibraryApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;


        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return Ok(_userService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user is null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            if(user == null)
                return BadRequest();

            await _userService.CreateAsync(user);

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(User user,int id)
        {
            await _userService.UpdateAsync(id, user);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<User>> Delete(int id)
        {
            await _userService.DeleteAsync(id);

            return NoContent();
        }
    }
}
