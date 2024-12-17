using MagicVilla_VillaAPI.Models;

namespace MagicVilla_VillaAPI.Repository.IRepository
{
    public interface IVillaNbRepository : IRepository<VillaNb>
    {
        Task<VillaNb> UpdateAsync(VillaNb entity);
    }
}
