using Microsoft.AspNetCore.Mvc;

namespace prakt_8_trpo.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        public IActionResult Index ()
        {
            return View( );
        }
    }
}
