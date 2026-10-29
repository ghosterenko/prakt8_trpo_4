using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;

namespace prakt_8_trpo.Controllers
{
    [ApiController]
    [Route("api/v1/tasks")]
    public class TasksController :Controller
    {
        public IActionResult Index ()
        {
            return View( );
        }
    }
}
