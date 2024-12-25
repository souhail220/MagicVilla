using MagicVilla_Web.Models.DTO;

namespace MagicVilla_Web.Services.IServices
{
    public interface IVillaNbService
    {
        Task<T> GetAllAsync<T>(string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(VillaNbRequestDTO dto, string token);
        Task<T> UpdateAsync<T>(VillaNbRequestDTO dto, string token);
        Task<T> DeleteAsync<T>(int id, string token);
    }
}