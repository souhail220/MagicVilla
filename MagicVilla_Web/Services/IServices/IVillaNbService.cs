using MagicVilla_Web.Models.DTO;

namespace MagicVilla_Web.Services.IServices
{
    public interface IVillaNbService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(VillaNbRequestDTO dto);
        Task<T> UpdateAsync<T>(VillaNbRequestDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }
}