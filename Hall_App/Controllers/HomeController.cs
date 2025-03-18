using System.Diagnostics;
using Hall_App.Models;
using Hall_App.Service;
using Microsoft.AspNetCore.Mvc;

namespace Hall_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApiService _apiService;
        public HomeController(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<IActionResult> Index()
        {
           
            return View();
        }

        public async Task<IActionResult> Arcadehalls()
        {
            List<ArcadeHall> arcadeHalls =await _apiService.GetAll(); 
            return View(arcadeHalls);
        }

    }
}
