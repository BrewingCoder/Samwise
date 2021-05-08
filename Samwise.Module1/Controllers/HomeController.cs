using Microsoft.AspNetCore.Mvc;
using OrchardCore.Data;

namespace Samwise.Module1.Controllers
{
    [Route("Module1")]
    public class HomeController : Controller
    {
        private readonly IDbConnectionAccessor _dbAccessor;

        public HomeController(IDbConnectionAccessor dbAccessor)
        {
            _dbAccessor = dbAccessor;
            var y = dbAccessor;
        }
        
        public ActionResult Index()
        {
            
            return View();
        }
    }
}
