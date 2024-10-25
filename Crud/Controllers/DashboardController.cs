using Microsoft.AspNetCore.Mvc;

namespace Crud.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
