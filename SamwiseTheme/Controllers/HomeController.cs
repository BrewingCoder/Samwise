using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace SamwiseTheme.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
