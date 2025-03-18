using Hall_App.Models;

namespace Hall_App.Service
{
    public interface IApiService
    {
        Task<List<ArcadeHall>?> GetAll();
        Task<List<T>?> GetAllFromApi<T>(string endpoint);
        Task<T?> GetById<T>(int id);
    }
}