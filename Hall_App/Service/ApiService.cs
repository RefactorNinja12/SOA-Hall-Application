using Hall_App.Models;
using System;
using System.Text.Json;

namespace Hall_App.Service
{
    public class ApiService : IApiService
    {


        private readonly HttpClient _httpClient;
        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<T>?> GetAllFromApi<T>(string endpoint)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Error: {response.StatusCode}");
                return null;
            }
            string json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<T>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });


        }
        public async Task<List<ArcadeHall>?> GetAll()
        {
            // Anropa den generiska metoden och specificera typparametern som List<ArcadeHall>
            List<ArcadeHall> arcadeHalls = await GetAllFromApi<ArcadeHall>("https://localhost:7234/api/ArcadeHall");

            // Returnera resultatet
            return arcadeHalls;
        }

        public async Task<T?> GetById<T>(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://localhost:7234/api/ArcadeHall/{id}");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Error: {response.StatusCode}");
                return default;
            }
            string json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

    }
}
