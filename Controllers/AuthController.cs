using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using prakt_8_trpo.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace prakt_8_trpo.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        private static TasksDbContext _context = new TasksDbContext( );
        private readonly IConfiguration _configuration;
        
        
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

        private string GenerateJwtToken(User user)
        {
            var claims = new [ ]
            {
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "TasksApi",
                audience: "TasksApiClient",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler( ).WriteToken(token);
        }

    }
}
