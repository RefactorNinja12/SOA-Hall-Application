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
            ArcadeHall arcadeHall = new ArcadeHall()
            {
                Genre = "IT takes 2",
                Name = "Shoooter hall",
                ImageUrl = "Example of something",
                Id = 3
            };
            bool isUpdated = await _apiService.UpdateByApi("https://localhost:7234/api/ArcadeHall/", arcadeHall, arcadeHall.Id);
            if (isUpdated)
            {
                Console.WriteLine("Updatering succeed");
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }
            return View();
        }

    }
}
