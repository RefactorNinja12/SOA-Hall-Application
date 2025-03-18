using Hall_App.Models;
using System;
using System.Text.Json;
using static System.Net.WebRequestMethods;

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
            List<ArcadeHall>? arcadeHalls = await GetAllFromApi<ArcadeHall>("https://localhost:7234/api/ArcadeHall");


            return arcadeHalls;
        }

        public async Task<T?> GetApiById<T>(int id)
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
        public async Task<ArcadeHall?> GetById(int id)
        {
            ArcadeHall? arcadeHall = await GetApiById<ArcadeHall>(id);
            return arcadeHall;
        }

    }
}
