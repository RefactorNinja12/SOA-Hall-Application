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
            ArcadeHall arcadeHall = await _apiService.GetById(1);
            return View();
        }

        public async Task<IActionResult> Arcadehalls()
        {
             
            return View();
        }

    }
}
