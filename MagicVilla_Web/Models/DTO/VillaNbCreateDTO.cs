using System.ComponentModel.DataAnnotations;

namespace MagicVilla_Web.Models.DTO
{
    public class VillaNbCreateDTO
    {
        [Required]
        public int VillaNumber { get; set; }
        public string SpecialDetails { get; set; }
        [Required]
        public int VillaID { get; set; }
    }
}
