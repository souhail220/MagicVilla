using MagicVilla_VillaAPI.Models.DTO;

namespace MagicVilla_VillaAPI.Data
{
    public class VillaStore
    {
        public static List<VillaDTO> villaStore = new List<VillaDTO>
            {
                new VillaDTO { Id = 1, Name = "Pool View" },
                new VillaDTO { Id = 2, Name = "Beach View" }
            };
    }
}
