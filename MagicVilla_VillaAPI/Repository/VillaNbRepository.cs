using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Repository.IRepository;

namespace MagicVilla_VillaAPI.Repository
{
    public class VillaNbRepository : Repository<VillaNb>, IVillaNbRepository
    {
        private readonly ApplicationDbContext _db;
        public VillaNbRepository(ApplicationDbContext db) : base(db) {
            _db = db;
        }
        public async Task<VillaNb> UpdateAsync(VillaNb entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.VillasNb_API.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
