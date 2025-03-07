using LibraryApi.Data;
using LibraryApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(LibraryDbContext context) : ControllerBase
    {
        private readonly LibraryDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return Ok(await _context.Users.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            if(user == null)
                return BadRequest();

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(User user,int id)
        {
            var newUser = await _context.Users.FindAsync(id);
            if(newUser is null)
                return NotFound();

            newUser.Name = user.Name;
            newUser.Email = user.Email;
            newUser.Username = user.Username;
            newUser.Password = user.Password;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<User>> Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user is null) 
                return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();


            return NoContent();
        }
    }
}
