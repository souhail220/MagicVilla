using System.ComponentModel.DataAnnotations;

namespace MagicVilla_Web.Models.DTO
{
    public class VillaNbDTO
    {
        [Required]
        public int VillaNumber { get; set; }
        public string SpecialDetails { get; set; }
    }
}
