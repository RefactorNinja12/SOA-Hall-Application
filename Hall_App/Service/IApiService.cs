﻿using Hall_App.Models;

namespace Hall_App.Service
{
    public interface IApiService
    {
        Task<bool> DeleteById(string endpoint, int id);
        Task<List<ArcadeHall>?> GetAll();
        Task<List<T>?> GetAllFromApi<T>(string endpoint);
        Task<T?> GetApiById<T>(int id);
        Task<ArcadeHall?> GetById(int id);
    }
}