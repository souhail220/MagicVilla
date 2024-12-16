using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI.Models.DTO
{
    public class VillaNbDTO
    {
        [Required]
        public int VillaNb { get; set; }
        public string SpecialDetails { get; set; }
    }
}
