using Hall_App.Models;

namespace Hall_App.Service
{
    public interface IApiService
    {
        Task<bool> CreatebyApi<T>(string endpoint, T dataObject);
        Task<bool> DeleteById(string endpoint, int id);
        Task<List<ArcadeHall>?> GetAllArcadeHalls();
        Task<List<T>?> GetAllFromApi<T>(string endpoint);
        Task<T?> GetApiById<T>(int id);
        Task<ArcadeHall?> GetArcadeHallById(int id);
        Task<bool> UpdateByApi<T>(string endpoint, T dataObject, int id);
    }
}