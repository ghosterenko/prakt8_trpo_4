using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using prakt_8_trpo.Models;

namespace prakt_8_trpo.Controllers
{
    [ApiController]
    [Route("api/v1/tasks")]
    public class TasksController :Controller
    {
        private static TasksDbContext _context = new TasksDbContext( );

        [HttpGet]
        public IActionResult GetAll ()
        {
            return Ok(_context.Tasks.ToList());
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
