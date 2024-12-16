using MagicVilla_VillaAPI.Models;

namespace MagicVilla_VillaAPI.Repository.IRepository
{
    public interface IVillaNbRepository
    {
        Task<VillaNb> UpdateAsync(VillaNb entity);
    }
}
