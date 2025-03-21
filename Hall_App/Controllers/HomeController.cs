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
            List<ArcadeHall>? arcadeHalls = await _apiService.GetAllArcadeHalls();
            return View(arcadeHalls);
        }
       
        public IActionResult CreateArcadeHalls()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateArcadeHalls(ArcadeHall arcadeHall)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("CreateArcadeHalls");
            }
            bool isCreated = await _apiService.CreatebyApi<ArcadeHall>("https://informatik6.ei.hv.se//arcadehallapi/api/ArcadeHall/", arcadeHall);
            if (isCreated)
            {
                return RedirectToAction("ArcadeHalls");
            }
            
            return RedirectToAction("CreateArcadeHalls");
        }
    
        public async Task<IActionResult> Edit(int? id)
        {
            var arcadeHall = new ArcadeHall();
            if (id.HasValue)
            {
                arcadeHall.Id = id.Value;
            }
            return View(arcadeHall);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ArcadeHall arcadeHall)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit");
            }
            if(arcadeHall.Id <= 0)
            {
                return RedirectToAction("Edit");
            }
            bool IsUpated = await _apiService.UpdateByApi<ArcadeHall>("https://informatik6.ei.hv.se//arcadehallapi/api/ArcadeHall/", arcadeHall, arcadeHall.Id);
            if (IsUpated)
            {
                return RedirectToAction("ArcadeHalls");
            }
            return RedirectToAction("Edit");
        }

    }
}
