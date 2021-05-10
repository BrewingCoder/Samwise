using Microsoft.AspNetCore.Mvc;
using OrchardCore.Data;
using Samwise.DataServices;
using YesSql;

namespace Samwise.Module1.Controllers
{
    
    [Route("Module1")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _uow;
        
        public HomeController(IStore store, IDbConnectionAccessor accessor)
        {
            _uow = new NHibernateUnitOfWork(store,accessor);
        }
        protected override void Dispose(bool disposing)
        {
            _uow.Dispose();
            base.Dispose(disposing);
        }
        
        public ActionResult Index()
        {
            
            return View();
        }
    }
}
