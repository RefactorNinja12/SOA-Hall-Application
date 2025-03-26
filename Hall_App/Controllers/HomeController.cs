using System.Diagnostics;
using System.Security.Claims;
using Hall_App.Dto;
using Hall_App.Models;
using Hall_App.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hall_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApiService _apiService;
        private readonly ILoginService _loginService;
        public HomeController(IApiService apiService, ILoginService loginService)
        {
            _apiService = apiService;
            _loginService = loginService;
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
        
      //  [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Admin()
        {
            List<ArcadeHall>? arcadeHalls = await _apiService.GetAllArcadeHalls();
            return View(arcadeHalls);
        }

     //   [Authorize(Roles = "Admin")]
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
            bool isCreated = await _apiService.CreatebyApi<ArcadeHall>("https://localhost:7234/api/ArcadeHall", arcadeHall);
            if (isCreated)
            {
                return RedirectToAction("Admin");
            }
            
            return RedirectToAction("CreateArcadeHalls");
        }
   //     [Authorize(Roles = "Admin")]
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
            bool IsUpated = await _apiService.UpdateByApi<ArcadeHall>("https://localhost:7234/api/ArcadeHall", arcadeHall, arcadeHall.Id);
            if (IsUpated)
            {
                return RedirectToAction("ArcadeHalls");
            }
            return RedirectToAction("Edit");
        }
       // [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
          if (id <= 0)
            {
                return RedirectToAction("Home", "Arcadehalls");
            }

            bool isDeleted = await _apiService.DeleteById("https://localhost:7234/api/ArcadeHall", id);

            return RedirectToAction("Admin");
        }
        #region Login
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserDto userDto)
        {
            if (_loginService.ValidateUser(userDto))
            {
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, userDto.Email),
                        new Claim(ClaimTypes.Role, "Admin"),
                    };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
                return RedirectToAction("Admin");
            }

            return Unauthorized();
        }
        #endregion

    }
}
