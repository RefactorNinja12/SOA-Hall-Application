using System.Diagnostics;
using Hall_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hall_App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Arcadehalls()
        {
            return View();
        }

    }
}
