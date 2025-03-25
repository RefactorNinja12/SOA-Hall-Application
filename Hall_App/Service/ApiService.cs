using Hall_App.Models;
using System;
using System.Text;
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
        public async Task<List<ArcadeHall>?> GetAllArcadeHalls()
        {
            List<ArcadeHall>? arcadeHalls = await GetAllFromApi<ArcadeHall>("https://informatik6.ei.hv.se/arcadehallapi/api/ArcadeHall");


            return arcadeHalls;
        }
        public async Task<bool> DeleteById(string endpoint, int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"{endpoint}{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<T?> GetApiById<T>(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://informatik6.ei.hv.se/arcadehallapi/api/ArcadeHall{ id}");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Error: {response.StatusCode}");
                return default;
            }
            string json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        public async Task<ArcadeHall?> GetArcadeHallById(int id)
        {
            ArcadeHall? arcadeHall = await GetApiById<ArcadeHall>(id);
            return arcadeHall;
        }
        public async Task<bool> CreatebyApi<T>(string endpoint, T dataObject)
        {
            string json = JsonSerializer.Serialize(dataObject);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(endpoint, content);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> UpdateByApi<T>(string endpoint, T dataObject, int id)
        {
            string json = JsonSerializer.Serialize(dataObject);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage respone = await _httpClient.PutAsync($"{endpoint}{id}", content);
            return respone.IsSuccessStatusCode;
        }

    }
}
