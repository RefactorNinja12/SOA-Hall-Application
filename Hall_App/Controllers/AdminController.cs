using Microsoft.AspNetCore.Mvc;

namespace Hall_App.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
