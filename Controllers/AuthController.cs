using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using prakt_8_trpo.Models;

namespace prakt_8_trpo.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        private static TasksDbContext _context = new TasksDbContext( );
        
        
        [HttpPost("register")]
        public IActionResult PostRegister ([FromBody] User user)
        {
            if (_context.Tasks.Find(user.Id) != null)
                return BadRequest( );
            if (user != null)
            {
                _context.Users.Add(user);
                _context.SaveChanges( );
                return Created( );
            }
            return BadRequest( );
        }
        [HttpPost("login")]
        public IActionResult PostLogin ([FromBody] User user)
        {
            return Ok( );
        }



    }
}
