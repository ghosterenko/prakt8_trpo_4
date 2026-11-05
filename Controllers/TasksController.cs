using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using prakt_8_trpo.Models;
using Microsoft.AspNetCore.Authorization;

namespace prakt_8_trpo.Controllers
{
    [ApiController]
    [Route("api/v1/tasks")]
    [Authorize]
    public class TasksController :Controller
    {
        private static TasksDbContext _context = new TasksDbContext( );

        [HttpGet("all")]
        [Authorize(Roles = "admin")]
        public IActionResult GetAll ()
        {
            return Ok(_context.Tasks.ToList());
        }

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            return Ok(_context.Tasks.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_context.Tasks.FirstOrDefault(t => t.Id == id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Models.Task task)
        {
            if(_context.Tasks.Find(task.Id) != null)
                return BadRequest( );
            if (task != null)
            {
                _context.Tasks.Add(task);
                _context.SaveChanges( );
                return Created( );
            }
            return BadRequest( );
        }
    }
}
