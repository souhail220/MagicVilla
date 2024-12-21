using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MagicVilla_Web.Models
{
    public class VillaNb
    {
        public int VillaNumber { get; set; }
        public int VillaID { get; set; }
        public Villa Villa { get; set; }
        public string SpecialDetails { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
