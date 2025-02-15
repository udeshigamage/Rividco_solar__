using Microsoft.AspNetCore.Mvc;

namespace Rividco_solar__.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
