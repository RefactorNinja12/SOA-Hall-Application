using System.Diagnostics;
using System.Text.Json;
using Hall_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hall_App.Controllers
{

    public class GetAPI
    {
        private readonly HttpClient _httpClient;

        public GetAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ArcadeHall>> GetAPIAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7234/api/ArcadeHall");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<ArcadeHall>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            return null;
        }
    }
    public class HomeController : Controller
    {
        private readonly GetAPI _getAPI;

        public HomeController(GetAPI getAPI)
        {
            _getAPI = getAPI;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _getAPI.GetAPIAsync();
            return View(data);
        }        
    }
}
